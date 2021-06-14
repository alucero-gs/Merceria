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
    public class DetalleVentasController : Controller
    {
        private contextoModelo db = new contextoModelo();

        // GET: DetalleVentas
        public ActionResult Index()
        {
            var detalleVenta = db.DetalleVenta.Include(d => d.Ventas).Include(d => d.Productos);
            return View(detalleVenta.ToList());
        }

        // GET: DetalleVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Venta = new SelectList(db.Ventas, "Id", "Id");
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id", "Nombre");
            return View();
        }

        // POST: DetalleVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Venta,Id_Producto,Cantidad,Subtotal,Estado")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                db.DetalleVenta.Add(detalleVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Venta = new SelectList(db.Ventas, "Id", "Id", detalleVenta.Id_Venta);
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id", "Nombre", detalleVenta.Id_Producto);
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Venta = new SelectList(db.Ventas, "Id", "Id", detalleVenta.Id_Venta);
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id", "Nombre", detalleVenta.Id_Producto);
            return View(detalleVenta);
        }

        // POST: DetalleVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Venta,Id_Producto,Cantidad,Subtotal,Estado")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Venta = new SelectList(db.Ventas, "Id", "Id", detalleVenta.Id_Venta);
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id", "Nombre", detalleVenta.Id_Producto);
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // POST: DetalleVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            db.DetalleVenta.Remove(detalleVenta);
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
