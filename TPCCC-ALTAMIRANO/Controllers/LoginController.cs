using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TPCCC_ALTAMIRANO.DAL;

namespace TPCCC_ALTAMIRANO.Controllers
{

    public class LoginController : Controller
    {
        //private ReparacionesContext db = new ReparacionesContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //// GET: Login/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Login/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Login/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Login/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Login/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Login/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Login/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        // GET: Login
        //        public ActionResult Login(Login login)
        //        {
        //            {
        //                if (ModelState.IsValid)
        //                {
        //                    //DBEntity db = new DBEntity();
        //                    var user = (from userlist in db.Usuarios
        //                                where userlist.Alias == login.UserName && userlist.Pass == login.Password
        //                                select new
        //                                {
        //                                    userlist.Id,
        //                                    userlist.Alias
        //                                }).ToList();
        //                    if (user.FirstOrDefault() != null)
        //                    {
        //                        Session["Alias"] = user.FirstOrDefault().Alias;
        //                        Session["Id"] = user.FirstOrDefault().Id;
        //                        return Redirect("/home/welcomepage");
        //                    }
        //                    else
        //                    {
        //                        ModelState.AddModelError("", "Invalid login credentials.");
        //                    }
        //                }
        //                return View(login);
        //            }

        //            //public ActionResult WelcomePage()
        //            //{
        //            //    return View();
        //            //}
        //        }
    }

}
