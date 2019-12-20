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
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                //var userName = (Usuario)Session["NombreUsuario"];
                return View();
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        public ActionResult About()
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                ViewBag.Message = "Your application description page.";

            return View();
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        public ActionResult Contact()
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                ViewBag.Message = "Your contact page.";

            return View();
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }
    }
}