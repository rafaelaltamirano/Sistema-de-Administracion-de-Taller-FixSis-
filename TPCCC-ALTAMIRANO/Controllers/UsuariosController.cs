using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPCCC_ALTAMIRANO.DAL;
using TPCCC_ALTAMIRANO.Models;

namespace TPCCC_ALTAMIRANO.Controllers
{
    public class UsuariosController : Controller
    {
        private ReparacionesContext db = new ReparacionesContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1)
            {
                return View(db.Usuarios.ToList());
            }
            else
                //si el usuario no es el correcto vuelve a la pag anterior
                return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1)
            {

                try
                {
                    return View();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            else
                //si el usuario no es el correcto vuelve a la pag anterior
                return Redirect(Request.UrlReferrer.ToString());
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,Alias,TipoUsuario,Dni,Pass,IdSucursal,Email")] Usuario usuario)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1)
            {
                if (ModelState.IsValid)
                {
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            else
                //si el usuario no es el correcto vuelve a la pag anterior
                return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.Usuarios.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
            else
                //si el usuario no es el correcto vuelve a la pag anterior
                return Redirect(Request.UrlReferrer.ToString());
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,Alias,TipoUsuario,Dni,Pass,IdSucursal,Estado")] Usuario usuario)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            else
                //si el usuario no es el correcto vuelve a la pag anterior
                return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.Usuarios.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
            else
                //si el usuario no es el correcto vuelve a la pag anterior
                return Redirect(Request.UrlReferrer.ToString());
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1)
            {
                Usuario usuario = db.Usuarios.Find(id);
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                //si el usuario no es el correcto vuelve a la pag anterior
                return Redirect(Request.UrlReferrer.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}
