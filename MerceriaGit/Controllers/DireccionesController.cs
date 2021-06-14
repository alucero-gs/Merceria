using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MerceriaGit.Models;

namespace MerceriaGit.Controllers
{
    public class DireccionesController : Controller
    {
        private contextoModelo db = new contextoModelo();

        // GET: Direcciones
        public ActionResult Index()
        {
            var direcciones = db.Direcciones.Include(d => d.Usuarios);
            return View(direcciones.ToList());
        }

        // GET: Direcciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direcciones direcciones = db.Direcciones.Find(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            return View(direcciones);
        }

        // GET: Direcciones/Create
        public ActionResult Create()
        {
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id", "Nombre");
            return View();
        }

        // POST: Direcciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Usuario,Calle,Entidad,Municipio,Numero_Exterior,Numero_Interior,Codigo_Postal,Referencias,Estado")] Direcciones direcciones)
        {
            if (ModelState.IsValid)
            {
                db.Direcciones.Add(direcciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id", "Nombre", direcciones.Id_Usuario);
            return View(direcciones);
        }

        // GET: Direcciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direcciones direcciones = db.Direcciones.Find(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id", "Nombre", direcciones.Id_Usuario);
            return View(direcciones);
        }

        // POST: Direcciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Usuario,Calle,Entidad,Municipio,Numero_Exterior,Numero_Interior,Codigo_Postal,Referencias,Estado")] Direcciones direcciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direcciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id", "Nombre", direcciones.Id_Usuario);
            return View(direcciones);
        }

        // GET: Direcciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direcciones direcciones = db.Direcciones.Find(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            return View(direcciones);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direcciones direcciones = db.Direcciones.Find(id);
            db.Direcciones.Remove(direcciones);
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
