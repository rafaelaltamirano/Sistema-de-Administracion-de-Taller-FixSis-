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
    public class RepuestosController : Controller
    {
        private ReparacionesContext db = new ReparacionesContext();

        // GET: Repuestos
        public ActionResult Index()
        {
            ViewBag.returnUrl = Request.UrlReferrer;
            return View(db.Repuesto.ToList());
        }

        // GET: Repuestos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repuesto repuesto = db.Repuesto.Find(id);
            if (repuesto == null)
            {
                return HttpNotFound();
            }
            return View(repuesto);
        }

        // GET: Repuestos/Create
        public ActionResult Create()
        {
            ViewBag.returnUrl = Request.UrlReferrer;
            ViewBag.ListaMarcas = new SelectList(db.Marca.ToList(), "ID", "Descripcion");
            ViewBag.ListaProveedores = new SelectList(db.Proveedor.ToList(), "ID", "Nombre");
           
            return View();
        }

        // POST: Repuestos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Repuesto repuesto,[Bind(Include = "ID")] Marca marca, [Bind(Include = "ID")] Proveedor proveedor)// me trae solo el id de marca
        {
            Repuesto auxRepuesto = new Repuesto();
            if (ModelState.IsValid)
            {
                auxRepuesto.Marca = marca;
                auxRepuesto.Nombre = repuesto.Nombre;
                
                auxRepuesto.Proveedor = proveedor;
                db.Repuesto.Add(auxRepuesto);
                db.Marca.Attach(marca);
                db.Proveedor.Attach(proveedor);// esto hace que marca no sea modificado en la base de datos
                //db.ObjectStateManager.ChangeObjectState(repuesto.Marca,
                //                                 EntityState.Unchanged);una prueba fallida
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repuesto);
        }

        // GET: Repuestos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repuesto repuesto = db.Repuesto.Find(id);
            if (repuesto == null)
            {
                return HttpNotFound();
            }
            return View(repuesto);
        }

        // POST: Repuestos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Repuesto repuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repuesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repuesto);
        }

        // GET: Repuestos/Delete/5
        public ActionResult Delete(int? id)
        {
            Repuesto repuesto = db.Repuesto.Find(id);
            db.Repuesto.Remove(repuesto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
       // [HttpPost, ActionName("Delete")]
       //[ValidateAntiForgeryToken]
       // public ActionResult DeleteConfirmed(int id)
       // {
       //    Repuesto repuesto = db.Repuesto.Find(id);
       //     db.Repuesto.Remove(repuesto);
       //     db.SaveChanges();
       //     return RedirectToAction("Index");
       // }

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
