using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.ENTITIES;
using HomeLt.Net.Legacy.UI.Helpers;
using HomeLt.Net.Legacy.UI.Models;
using HomeLt.Net.Legacy.UI.Models.User;
using HomeLt.Net.Legacy.UI.Models.UserViewModel;
using ImageSaver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;


namespace HomeLt.Net.Legacy.UI.Controllers
{
    public class UserController : Controller
    {

        public ActionResult LoginRegister()
        {
            var message = TempData["Message"];
            TempData["Message"] = message;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            using (UserManager manager = new UserManager())
            {
                var result = manager.Get(f => f.Email == model.Email && f.Password == model.Password);
                if (result != null)
                {
                    var list = result.Tickets;
                    Session.Add(Constants.Sessions.SessionUser, result);
                    return RedirectToAction("Index", "Home");

                }
                TempData["Message"] = Constants.TempDataMessages.CreateTempDataMessage("alert alert-danger col-12 col-md-6 offset-md-3", "Invalid Email or Password");
                return RedirectToAction("LoginRegister");
            }
        }


        [HttpPost]
        public ActionResult Register (HomeLt.Net.Legacy.ENTITIES.User user,HttpPostedFileBase ProfilePic)
        {
           
            user.ActivationCode = Guid.NewGuid();
            using (UserManager manager = new UserManager())
            {
                
                if (!manager.CheckUser(user.Email))

                {

                    user.RegisterDate = DateTime.Now;
                    if (manager.Add(user))
                    {

                        using (UserMediaManager mediaManager = new UserMediaManager())
                        {
                            using (ImageSave imageSaver = new ImageSave())
                            {
                                string imagePath = imageSaver.SaveImage(ProfilePic, user.FirstName + user.LastName);
                                if (!string.IsNullOrEmpty(imagePath))
                                {
                                    mediaManager.Add(new ENTITIES.UserMedia { UserId = user.UserId, Path = imagePath });
                                }

                            }
                        }

                        using (MailHelper mail = new MailHelper())
                        {
                           mail.SendMail("fuat.meydan@yandex.com", user.Email, Constants.MailBodies.VerificationMail(user.FirstName, user.ActivationCode.ToString(), "fuat.meydan@yandex.com"), "Mail Verification", "fuat.meydan@yandex.com");
                        }

                    }
                    TempData["message"] = Constants.TempDataMessages.CreateTempDataMessage("alert alert-success", "Registiration is success. please check your email.");
                    return RedirectToAction("LoginRegister");
                }
                TempData["message"] = Constants.TempDataMessages.CreateTempDataMessage("alert alert-danger", "This E-Mail has been registered already.");
                return RedirectToAction("LoginRegister");
            }
           
           
           
            
        }



        public ActionResult Profile()
        {
            UserProfileViewModel model = new UserProfileViewModel();
            User currentUser = Session[Constants.Sessions.SessionUser] as User;
            
            using (UserManager manager =new UserManager())
            {
                
                var user = manager.Get(f => f.UserId == currentUser.UserId);
                
               
                return View(user);



            }

            //using (HomeManager homeManager = new HomeManager())
            //{

            //    var homes = homeManager.GetList("PropertyMedias", f => f.UserId == currentUser.UserId);
            //    user.Homes = homes;

            //    model.User = user;
            //    model.Homes = homes;



            //}
            //using (TicketManager ticketManager = new TicketManager())
            //{
            //    model.Tickets = ticketManager.GetList(f => f.UserId == user.UserId);

            //}
            //using (FavoriteManager manager=new FavoriteManager())
            //{
            //    model.Favorites = manager.GetList(f => f.UserId == user.UserId);
            //}


        }


        public ActionResult Editprofile(User user)
        {
            using (UserManager manager=new UserManager())
            {
                
                if (manager.Update(user)) {
                    TempData["Message"]= Constants.TempDataMessages.CreateTempDataMessage("alert alert-success", "Profile updated successfully");

                }
                else
                {
                    TempData["Message"] = Constants.TempDataMessages.CreateTempDataMessage("alert alert-danger", "An error occured while updating profile.");
                }
               
                return RedirectToAction("Profile", "User", new { id = user.UserId });

            }
        }
      
    }
}