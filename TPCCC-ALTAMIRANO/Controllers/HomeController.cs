using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPCCC_ALTAMIRANO.Models;

namespace TPCCC_ALTAMIRANO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
                //var userName = (Usuario)Session["NombreUsuario"];
            return View();
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