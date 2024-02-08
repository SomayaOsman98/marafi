using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using marafi1.Models;
using System.Net;
using System.Net.Mail;

namespace marafi1.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(marafi1.Models.Gmail model)
        {
                MailMessage mm = new MailMessage("somaya998osman@gmail.com", model.To);
                mm.Subject = model.Subject;
                mm.Body = model.Body;
                mm.IsBodyHtml = false;

                SmtpClient smtp = new  SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                NetworkCredential nc = new NetworkCredential("somaya998osman@gmail.com", "dhbuzxwbpuhbdzlg");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Send(mm);
            if (ModelState.IsValid == true)
            {
                ViewBag.Message = "Mail Has Been Sent Successfully!";
            }
            else
            {
                ViewBag.Message = "ERROR";
            }
                return View();
        }
    }
}