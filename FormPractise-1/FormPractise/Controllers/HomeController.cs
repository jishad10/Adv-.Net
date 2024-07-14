using FormPractise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FormPractise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new Login());
        }

        [HttpPost]
        public ActionResult Login(Login logi)
        {
            if(ModelState.IsValid)
            {
                if (logi.Uname.Equals("jishad") && logi.Pass.Equals("1234"))
                {
                    TempData["Msg"] = "Login Successfull";
                    return RedirectToAction("About");
                }
                else
                {
                    ViewBag.Msg = "Username password mismatch";
                }
            }
            return View(logi);
        }


        public ActionResult SignUp()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}