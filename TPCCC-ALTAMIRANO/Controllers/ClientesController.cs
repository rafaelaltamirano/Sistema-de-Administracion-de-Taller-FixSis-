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
    public class ClientesController : Controller
    {
        private ReparacionesContext db = new ReparacionesContext();

        [HttpPost]
        public ActionResult ElegirCliente(string palabra)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                try
            {
                IEnumerable<Cliente> cliente;


                cliente = db.Cliente;

                if (!String.IsNullOrEmpty(palabra))
                {
                    cliente = cliente.Where(c => c.Nombre.ToUpper().Contains(palabra.ToUpper()) || c.Apellido.ToUpper().Contains(palabra.ToUpper()) || c.Telefono.ToUpper().Contains(palabra.ToUpper()));
                    return View(cliente);
                }

                cliente = cliente.ToList();


                return View(cliente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }
        // GET: Clientes/Elegr Cliente
        public ActionResult ElegirCliente()
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {

                return View(db.Cliente.ToList());
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        // GET: Clientes
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                return View(db.Cliente.ToList());
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }
        [HttpPost]
        public ActionResult Index(string palabra)
        {
            try
            {
                IEnumerable<Cliente> cliente;
                cliente = db.Cliente;
                if (!String.IsNullOrEmpty(palabra))
                {
                    cliente = cliente.Where(c => c.Nombre.ToUpper().Contains(palabra.ToUpper()) || c.Apellido.ToUpper().Contains(palabra.ToUpper()) || c.Telefono.ToUpper().Contains(palabra.ToUpper()));
                }
                cliente = cliente.ToList();
                return View(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                 if (id == null)
              {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              Cliente cliente = db.Cliente.Find(id);
              if (cliente == null)
              {
                 return HttpNotFound();
              }
              return View(cliente);
             }
             else
            {
                return Redirect("/Login/LoginView");
            }
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                return View();
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,Telefono,Direccion,Email")] Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                ViewBag.returnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,Telefono,Direccion,Email")] Cliente cliente, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Cliente cliente = db.Cliente.Find(id);
            //if (cliente == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(cliente);
        }

        // POST: Clientes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Cliente cliente = db.Cliente.Find(id);
        //    db.Cliente.Remove(cliente);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        
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
