using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {  

        public ActionResult Index()
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("UserLogin", "User");
            }
            return View();
        }

        public ActionResult About()
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("UserLogin", "User");
            }
            return View();
        }

        public ActionResult Courses()
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("UserLogin", "User");
            }
            return View();
        }
        public ActionResult Testmonial()
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("UserLogin", "User");
            }
            return View();
        }

        public ActionResult Contact()
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("UserLogin", "User");
            }
            return View();
        }
    }
}