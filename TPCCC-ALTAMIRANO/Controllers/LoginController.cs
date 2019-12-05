using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TPCCC_ALTAMIRANO.DAL;
using TPCCC_ALTAMIRANO.Models;
using System.Globalization;

namespace TPCCC_ALTAMIRANO.Controllers
{
    public class LoginController : Controller
    {
        private ReparacionesContext db = new ReparacionesContext();
        //private ReparacionesContext db = new ReparacionesContext();
        // GET: Login
        public ActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginView([Bind(Include = "NombreUsuario,PassUsuario")] LoginModel login)
        {
            if (ModelState.IsValid)
            {
                //DBEntity db = new DBEntity();
                var user = (from userlist in db.Usuarios
                            where userlist.Alias == login.NombreUsuario && userlist.Pass == login.PassUsuario
                            select new
                            {
                                userlist.Nombre,
                                userlist.Apellido,
                                userlist.Id,
                                userlist.Alias,
                                userlist.TipoUsuario,
                                userlist.IdSucursal
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["IdUsuario"] = user.FirstOrDefault().Id;
                    Session["NombreUsuario"] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.FirstOrDefault().Nombre);
                    Session["NombreApellido"] = user.FirstOrDefault().Apellido;
                    Session["AliasUsuario"] = user.FirstOrDefault().Alias;
                    Session["TipoUsuario"] = user.FirstOrDefault().TipoUsuario;
                    Session["IdSucursal"] = user.FirstOrDefault().IdSucursal;
                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario y/o Contraseña Incorrectos");
                }
            }
            return View(login);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return Redirect("/Login/LoginView");
        }

    }
}
