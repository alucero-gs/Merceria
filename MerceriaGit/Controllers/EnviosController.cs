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
    public class EnviosController : Controller
    {
        private contextoModelo db = new contextoModelo();

        // GET: Envios
        public ActionResult Index()
        {
            var envios = db.Envios.Include(e => e.Paqueterias).Include(e => e.Ventas);
            return View(envios.ToList());
        }

        // GET: Envios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envios envios = db.Envios.Find(id);
            if (envios == null)
            {
                return HttpNotFound();
            }
            return View(envios);
        }

        // GET: Envios/Create
        public ActionResult Create()
        {
            ViewBag.Id_Paqueteria = new SelectList(db.Paqueterias, "Id", "Nombre");
            ViewBag.Id_Venta = new SelectList(db.Ventas, "Id", "Id");
            return View();
        }

        // POST: Envios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Paqueteria,Id_Venta,Codigo_Rastreo,Fecha_Envio,Fecha_Estimada_Entrega,Estado_Envio,Fecha_Entrega,Estado")] Envios envios)
        {
            if (ModelState.IsValid)
            {
                envios.Estado = 1;
                db.Envios.Add(envios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Paqueteria = new SelectList(db.Paqueterias, "Id", "Nombre", envios.Id_Paqueteria);
            ViewBag.Id_Venta = new SelectList(db.Ventas, "Id", "Id", envios.Id_Venta);
            return View(envios);
        }

        // GET: Envios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envios envios = db.Envios.Find(id);
            if (envios == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Paqueteria = new SelectList(db.Paqueterias, "Id", "Nombre", envios.Id_Paqueteria);
            ViewBag.Id_Venta = new SelectList(db.Ventas, "Id", "Id", envios.Id_Venta);
            return View(envios);
        }

        // POST: Envios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Paqueteria,Id_Venta,Codigo_Rastreo,Fecha_Envio,Fecha_Estimada_Entrega,Estado_Envio,Fecha_Entrega,Estado")] Envios envios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(envios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Paqueteria = new SelectList(db.Paqueterias, "Id", "Nombre", envios.Id_Paqueteria);
            ViewBag.Id_Venta = new SelectList(db.Ventas, "Id", "Id", envios.Id_Venta);
            return View(envios);
        }

        // GET: Envios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envios envios = db.Envios.Find(id);
            if (envios == null)
            {
                return HttpNotFound();
            }
            return View(envios);
        }

        // POST: Envios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Envios envios = db.Envios.Find(id);
            envios.Estado = 0;
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
