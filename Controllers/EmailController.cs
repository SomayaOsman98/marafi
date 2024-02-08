using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using marafi1.Models;
using System.Net.Mail;
using System.Web.Http;


namespace marafi1.Controllers
{
    public class EmailController : Controller
    {
       
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }
        public IHttpActionResult sendmail(EmailClass ec)
        {
            string subject = ec.subject;
            string body = ec.body;
            string to = ec.to;
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("somaya998osman@gmail.com");
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp@gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("somaya998osman@gmail.com", "password");
            smtp.Send(mm);
            return Ok();

        }

        private IHttpActionResult Ok()
        {
            throw new NotImplementedException();
        }
    }
}