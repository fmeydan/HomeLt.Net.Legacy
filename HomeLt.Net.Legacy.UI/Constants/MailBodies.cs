using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HomeLt.Net.Legacy.UI.Constants
{
    public static class MailBodies
    {
        public static string VerificationMail(string reciever,string verificationCode,string sender)
        {
            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append($"<div class='jumbotron'><h1>Hello, {reciever}! </h1>");
            //stringBuilder.Append("<p class='lead'>Thank you for register to HomeLT. You are one step closer to your dreams. </p><hr class='my-4'>");
            //stringBuilder.Append("<p>Please click button for confirm your email.</p>");
            //stringBuilder.Append($"<a class='btn btn-primary btn-lg' href='https://www.homelt.com/User/Confirm?ConfirmCode='+{varificationCode} role='button'>Confirm</a></div>");
            return $"<div class=\"jumbotron\">< h1 class=\"display-4\">Hello, world!</h1><p class=\"lead\">This is a simple hero unit, a simple jumbotron-style component for calling extra attention to featured content or information.</p><hr class=\"my-4\"><p>It uses utility classes for typography and spacing to space content out within the larger container.</p><a class=\"btn btn-primary btn-lg\" href=\"https://www.homelt.com/User/Verify?=Code={verificationCode}\" role=\"button\">Learn more</a></div>";

            //return stringBuilder.ToString();
        }

       
    }
}