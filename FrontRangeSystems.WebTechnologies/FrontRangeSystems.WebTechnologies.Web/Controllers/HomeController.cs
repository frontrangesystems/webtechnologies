using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontRangeSystems.WebTechnologies.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Angular1()
        {
            return View();
        }

        public ActionResult Angular2()
        {
            return View();
        }

        public ActionResult Mvc()
        {
            return View();
        }
    }
}
