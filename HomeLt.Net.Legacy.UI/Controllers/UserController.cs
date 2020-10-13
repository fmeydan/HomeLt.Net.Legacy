using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.UI.Helpers;
using HomeLt.Net.Legacy.UI.Models;
using HomeLt.Net.Legacy.UI.Models.User;
using ImageSaver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;


namespace HomeLt.Net.Legacy.UI.Controllers
{
    public class UserController : Controller
    {
        
        public ActionResult Login(LoginViewModel model)
        {
            using (UserManager manager = new UserManager())
            {
                var result = manager.Get(f => f.Email == model.Email && f.Password == model.Password);
                if (result != null)
                {
                    Session.Add(Constants.Sessions.SessionUser, result);

                }
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register (HomeLt.Net.Legacy.ENTITIES.User user,HttpPostedFileBase ProfilePic)
        {
           
            user.ActivationCode = Guid.NewGuid();
            using (UserManager manager = new UserManager())
            {
                
                if (!manager.CheckUser(user.Email))
                {
                    if (manager.Add(user))
                    {

                        using (UserMediaManager mediaManager = new UserMediaManager())
                        {
                            using (ImageSave imageSaver = new ImageSave())
                            {
                                string imagePath = imageSaver.SaveImage(ProfilePic, user.FirstName + user.LastName, Constants.ConstantPaths.UserImagePath + user.FirstName + user.LastName);
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
                    TempData["message"] = new TempDataDictionary { { "class", "alert alert-success" }, { "msg", "Registiration is success. please check your email." } };
                    return RedirectToAction("Register");
                }
                TempData["message"] = new TempDataDictionary { { "class", "alert alert-danger" }, { "msg", "This E-Mail is already registered." } };
                return RedirectToAction("Register");
            }
           

           
            
        }
        //[HttpPost]
        //public JsonResult Register(RegisterViewModel model)
        //{
        //    using (UserManager manager = new UserManager())
        //    {
        //        var result = manager.Add(new ENTITIES.User
        //        {
        //            Email = model.Email,
        //            Password = model.Password,
        //            ActivationCode = new Guid()
        //        });
        //        return result == true ? Json("Success") : Json("Fail");
        //    }


        //}
    }
}