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
    public class ProveedoresController : Controller
    {
        private ReparacionesContext db = new ReparacionesContext();

        // GET: Proveedores
        public ActionResult Index()
        {
            return View(db.Proveedor.ToList());
        }
        [HttpPost]
        public ActionResult Index(string palabra)
        {
            try
            {
                IEnumerable<Proveedor> proveedor;
                proveedor = db.Proveedor;
                if (!String.IsNullOrEmpty(palabra))
                {
                    proveedor = proveedor.Where(p => p.Nombre.ToUpper().Contains(palabra.ToUpper()) || Convert.ToString(p.Cuit).ToUpper().Contains(palabra.ToUpper())).ToList();
                }
                proveedor = proveedor.ToList();
                return View(proveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.returnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            ViewBag.returnUrl = Request.UrlReferrer;
            return View();
        }

        // POST: Proveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Cuit,Direccion,Email,Telefono,Estado")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Proveedor.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proveedor);
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.returnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Cuit,Direccion,Email,Telefono,Estado")] Proveedor proveedor)
        {
            ViewBag.returnUrl = Request.UrlReferrer;
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            Proveedor proveedor = db.Proveedor.Find(id);
            db.Proveedor.Remove(proveedor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //// POST: Proveedores/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Proveedor proveedor = db.Proveedor.Find(id);
        //    db.Proveedor.Remove(proveedor);
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
