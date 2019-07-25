using DataLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ProyectoClase.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Usuario"] != null)
            {
                Session["HomeServed"] = true;
                return View();
            }
            return RedirectToAction("Index", "Login");

        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



    }
}