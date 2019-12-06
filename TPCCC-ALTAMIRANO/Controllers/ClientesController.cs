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
        // GET: Clientes/Elegr Cliente
        public ActionResult ElegirCliente()
        {
            return View(db.Cliente.ToList());
        }

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Cliente.ToList());
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

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
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
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
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
