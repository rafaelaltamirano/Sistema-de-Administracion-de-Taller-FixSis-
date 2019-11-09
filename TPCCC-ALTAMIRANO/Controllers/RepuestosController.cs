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
            ViewBag.ListaMarcas = new SelectList(db.Marca.ToList(), "ID", "Descripcion");           
            return View();
        }

        // POST: Repuestos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Repuesto repuesto,[Bind(Include = "ID")] Marca marca)// me trae solo el id de marca
        {
            Repuesto auxRepuesto = new Repuesto();
            if (ModelState.IsValid)
            {
                auxRepuesto.Marca = new Marca();
                auxRepuesto.Marca.ID= marca.ID;
                auxRepuesto.Nombre = repuesto.Nombre;
               
                db.Repuesto.Add(auxRepuesto);
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

        // POST: Repuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repuesto repuesto = db.Repuesto.Find(id);
            db.Repuesto.Remove(repuesto);
            db.SaveChanges();
            return RedirectToAction("Index");
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
