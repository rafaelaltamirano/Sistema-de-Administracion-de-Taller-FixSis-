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
    public class ServiciosController : Controller
    {
        private ReparacionesContext db = new ReparacionesContext();

        // GET: Servicios
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {

                ViewBag.ListaRepuestos = new SelectList(db.Repuesto.ToList(), "Id", "Nombre");
          
            return View(db.Servicio.ToList());
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }
        [HttpPost]
        public ActionResult Index(string palabra)
        {

            if (Convert.ToInt32(Session["TipoUsuario"]) == 1)
            {
                try
                {
                    IEnumerable<Servicio> servicio;


                    servicio = db.Servicio;


                    if (!String.IsNullOrEmpty(palabra))
                    {
                       servicio= servicio.Where(i => i.Nombre.ToUpper().Contains(palabra.ToUpper()) ||  Convert.ToString(i.Id).ToUpper().Contains(palabra.ToUpper())).ToList();
                        return View(servicio);
                    }

                    servicio = servicio.ToList();

                    return View(servicio);
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

        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                ViewBag.ListaRepuestos = new SelectList(db.Repuesto.ToList(), "ID", "Nombre");
            return View();
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public ActionResult Create(Servicio servicio, [Bind(Include = "ID")] Repuesto repuesto)// me trae solo el id de marca

        {
            //para guardar servicio en caso de pasar a otra pagina, pausado por que el navegador resuelve igual
           // if (!string.IsNullOrEmpty(save))
           // {
           //     Servicio auxServicio = new Servicio();
           //     auxServicio = Session["auxServicio"] as Servicio;
           //     Session["nombreServicioAux"] = servicio.Nombre;
           //     Session["descripcionServicioAux"] = servicio.Descripcion;
           //     Session["costoServicioAux"] = servicio.Costo;
           //     Session["IdRepuestoServicioAux"] = repuesto.Id;             
           //     return RedirectToAction("Create", "Repuestos");              
           // }
           //else   
            //{
                Servicio auxServicio = new Servicio();
                if (ModelState.IsValid)
                {
                    auxServicio.Nombre = servicio.Nombre;
                    auxServicio.Descripcion = servicio.Descripcion;
                    auxServicio.Repuesto = repuesto;
                    auxServicio.Costo = servicio.Costo;

                    db.Servicio.Add(auxServicio);
                    db.Repuesto.Attach(repuesto);// esto hace que marca no sea modificado en la base de datos
                                                 //db.ObjectStateManager.ChangeObjectState(repuesto.Marca,
                                                 //                                 EntityState.Unchanged);una prueba fallida
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(repuesto);
            //}
            
        }
        

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        // POST: Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Costo")] Servicio servicio, [Bind(Include = "ID")] Repuesto repuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicio);
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                Servicio servicio = db.Servicio.Find(id);
            db.Servicio.Remove(servicio);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        // POST: Servicios/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Servicio servicio = db.Servicio.Find(id);
        //    db.Servicio.Remove(servicio);
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
