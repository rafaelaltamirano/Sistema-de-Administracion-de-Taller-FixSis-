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
    public class IngresosController : Controller
    {
        private ReparacionesContext db = new ReparacionesContext();

        // GET: Ingresos
        public ActionResult Index()
        {
          
            if (Convert.ToInt32(Session["TipoUsuario"])==1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            { 
            //db.Ingresos.Select(x=>x.idEstado==1 && == 2 )
            // List<Ingreso> IngresoList = db.Ingresos.Where(i => i.idEstado == 1 && i.idEstado == 2).ToList();
            //db.Ingresos.Where(i => i.idEstado == 1 || i.idEstado == 2).ToList()
            TempData["url"] = "http://localhost:63934/Ingresos/Index";
            return View(db.Ingresos.Where(i => i.idEstado == 1 || i.idEstado == 2 || i.idEstado==3).ToList());
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }
        [HttpPost]
        public ActionResult Index(string palabra)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                try
                {
                    IEnumerable<Ingreso> ingreso;


                    ingreso = db.Ingresos;


                    if (!String.IsNullOrEmpty(palabra))
                    {
                        ingreso = ingreso.Where(i => i.NombreCliente.ToUpper().Contains(palabra.ToUpper()) || i.ApellidoCliente.ToUpper().Contains(palabra.ToUpper()) || Convert.ToString(i.Id).ToUpper().Contains(palabra.ToUpper())).ToList();
                    }
                    else
                    {
                        ingreso = db.Ingresos.Where(i => i.idEstado == 1 || i.idEstado == 2 || i.idEstado == 3).ToList();
                    }

                    return View(ingreso);
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
        // GET: EN REPARACION
        public ActionResult EnReparacion()
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                TempData["url"] = "http://localhost:63934/Ingresos/EnReparacion";
                return View(db.Ingresos.Where(i => i.idEstado == 4).ToList());
            }

            else
            {
                return Redirect("/Login/LoginView");
            }

        }
        [HttpPost]
        public ActionResult EnReparacion(string palabra)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                try
                {
                    IEnumerable<Ingreso> ingreso;
                    ingreso = db.Ingresos;
                    if (!String.IsNullOrEmpty(palabra))
                    {
                        ingreso = ingreso.Where(i => i.NombreCliente.ToUpper().Contains(palabra.ToUpper()) || i.ApellidoCliente.ToUpper().Contains(palabra.ToUpper()) || Convert.ToString(i.Id).ToUpper().Contains(palabra.ToUpper()));
                    }
                    else
                    {
                        ingreso = db.Ingresos.Where(i => i.idEstado == 4).ToList();
                    }

                    return View(ingreso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            {
                return Redirect("/Login/LoginView");
            }
        }
        // GET: ENTREGAR
        public ActionResult Entregar()
        {
            TempData["url"] = "http://localhost:63934/Ingresos/Entregar";
            return View(db.Ingresos.Where(i => i.idEstado == 5).ToList());
        }
        [HttpPost]
        public ActionResult Entregar(string palabra)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                try
                {
                    IEnumerable<Ingreso> ingreso;
                    ingreso = db.Ingresos;
                    if (!String.IsNullOrEmpty(palabra))
                    {
                        ingreso = ingreso.Where(i => i.NombreCliente.ToUpper().Contains(palabra.ToUpper()) || i.ApellidoCliente.ToUpper().Contains(palabra.ToUpper()) || Convert.ToString(i.Id).ToUpper().Contains(palabra.ToUpper()));
                    }
                    else
                    {
                        ingreso = db.Ingresos.Where(i => i.idEstado == 5).ToList();
                    }

                    return View(ingreso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            {
                return Redirect("/Login/LoginView");
            }
        }

        // GET: HISTORICO
        public ActionResult Historico()
        {   
            //ViewBag.returnUrl = Request.UrlReferrer;
            TempData["url"] = "http://localhost:63934/Ingresos/Historico";
            return View(db.Ingresos.Where(i => i.idEstado == 6).ToList());
        }
        [HttpPost]
        public ActionResult Historico(string palabra)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                try
                {
                    IEnumerable<Ingreso> ingreso;
                    ingreso = db.Ingresos;
                    if (!String.IsNullOrEmpty(palabra))
                    {
                        ingreso = ingreso.Where(i => i.NombreCliente.ToUpper().Contains(palabra.ToUpper()) || i.ApellidoCliente.ToUpper().Contains(palabra.ToUpper()) || Convert.ToString(i.Id).ToUpper().Contains(palabra.ToUpper()));
                    }
                    else
                    {
                        ingreso = db.Ingresos.Where(i => i.idEstado == 6).ToList();
                    }

                    return View(ingreso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            {
                return Redirect("/Login/LoginView");
            }
        }
        // GET: Ingresos/Details/5
        public ActionResult Details(int? id)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                // Grab the previous URL and add it to the Model using ViewData or ViewBag
                ViewBag.returnUrl = Request.UrlReferrer;
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Ingreso ingreso = db.Ingresos.Find(id);
                if (ingreso == null)
                {
                    return HttpNotFound();
                }
                return View(ingreso);
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        // GET: Ingresos/Create
        public ActionResult Create(int? id)//int? abreviacion de  nulleable int
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                // Grab the previous URL and add it to the Model using ViewData or ViewBag
                ViewBag.returnUrl = Request.UrlReferrer;
                var clie = from c in db.Cliente select c;
                Ingreso ingreso = new Ingreso();
                //var clie = db.Cliente.Where(i => i.Id == id);

                ViewBag.ListaIngresos = new SelectList(db.Ingresos.ToList(), "ID");
                ViewBag.ListaEstados = new SelectList(db.Estado.ToList(), "ID", "Nombre");
                if (id == null)
                {
                    return View();
                }
                else
                {
                    foreach (var l in clie)
                    {
                        if (l.Id == id)
                        {

                            ingreso.NombreCliente = l.Nombre;
                            ingreso.ApellidoCliente = l.Apellido;
                            ingreso.EmailCliente = l.Email;
                            ingreso.DireccionCliente = l.Direccion;
                            ingreso.Telefono = l.Telefono;

                            return View(ingreso);
                        }
                    }
                    return View();
                }
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }


        // POST: Ingresos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreCliente,ApellidoCliente,Telefono,EmailCliente,DireccionCliente,Modelo,Marca,FallaCliente,PassEquipo,Accesorios,Presupuesto,PrecioFinal,FallaDetectada,ReparacionRealizada")] Ingreso ingreso, int idEstado)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {

                if (ModelState.IsValid)
                {
                    Ingreso AuxIngreso = new Ingreso();


                    AuxIngreso.Id = ingreso.Id;
                    AuxIngreso.NombreCliente = ingreso.NombreCliente;
                    AuxIngreso.ApellidoCliente = ingreso.ApellidoCliente;
                    AuxIngreso.Telefono = ingreso.Telefono;
                    AuxIngreso.EmailCliente = ingreso.EmailCliente;
                    AuxIngreso.DireccionCliente = ingreso.DireccionCliente;
                    AuxIngreso.Modelo = ingreso.Modelo;
                    AuxIngreso.Marca = ingreso.Marca;
                    AuxIngreso.FallaCliente = ingreso.FallaCliente;
                    AuxIngreso.PassEquipo = ingreso.PassEquipo;
                    AuxIngreso.Accesorios = ingreso.Accesorios;
                    AuxIngreso.Presupuesto = ingreso.Presupuesto;
                    AuxIngreso.idEstado = idEstado;
                    AuxIngreso.FechaHora = DateTime.Now;
                    db.Ingresos.Add(AuxIngreso);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {

                    }
                }
                return View(ingreso);
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        // GET: Ingresos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                // Grab the previous URL and add it to the Model using ViewData or ViewBag
                ViewBag.returnUrl = Request.UrlReferrer;
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Ingreso ingreso = db.Ingresos.Find(id);
                if (ingreso == null)
                {
                    return HttpNotFound();
                }
                return View(ingreso);
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        // POST: Ingresos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreCliente,ApellidoCliente,Telefono,EmailCliente,DireccionCliente,Modelo,Marca,FallaCliente,PassEquipo,Accesorios,Presupuesto,PrecioFinal,FallaDetectada,ReparacionRealizada")] Ingreso ingreso, int idEstado, string returnUrl)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                if (ModelState.IsValid)
                {
                    var entity = db.Ingresos.Find(ingreso.Id);// entity variable guardar cosas de la base 

                    ingreso.idEstado = idEstado;

                    db.Entry(entity).CurrentValues.SetValues(ingreso);// actualizacion de los datos 

                    db.SaveChanges();
                    return Redirect(returnUrl);
                }
                return View(ingreso);
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        // GET: Ingresos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToInt32(Session["TipoUsuario"]) == 1 || Convert.ToInt32(Session["TipoUsuario"]) == 2)
            {
                Ingreso ingreso = db.Ingresos.Find(id);
                string url = TempData["url"].ToString();
                db.Ingresos.Remove(ingreso);
                db.SaveChanges();
                return Redirect(url);
            }
            else
            {
                return Redirect("/Login/LoginView");
            }
        }

        //// POST: Ingresos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Ingreso ingreso = db.Ingresos.Find(id);
        //    db.Ingresos.Remove(ingreso);
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
