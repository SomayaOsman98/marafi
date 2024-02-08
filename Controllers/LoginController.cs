using marafi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace marafi1.Controllers
{
    public class LoginController : Controller
    {
        marafiEntities1 db = new marafiEntities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Admin log)
        {
            var user = db.Admin.Where(x => x.user_name == log.user_name && x.password == log.password).Count();
            if (user > 0)
            {
                return RedirectToAction("Index","Companies");
            }
            else
            {
                return View();
            }
        }
    }
}