using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umpraco.Models;

namespace Umpraco.Controller
{
    public class ContactSurfaceController : SurfaceController
    {

        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/Contact/";
        public ActionResult RenderForm()
        {
             return PartialView(PARTIAL_VIEW_FOLDER + "_Contact.cshtml");
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                SendEmail(model);
                TempData["ContactSuccess"] = true;
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        private void SendEmail(ContactModel model)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("unpracotest@gmail.com");
            message.To.Add(model.EmailAddress);
            message.Subject = model.Subject;
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = model.Message;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("unpracotest@gmail.com", "unpracotest");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

        }
    }
}