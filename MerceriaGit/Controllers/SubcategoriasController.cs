﻿using System;
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
    public class SubcategoriasController : Controller
    {
        private contextMerceria db = new contextMerceria();

        // GET: Subcategorias
        public ActionResult Index()
        {
            var subcategorias = db.Subcategorias.Include(s => s.Categorias);
            return View(subcategorias.ToList());
        }

        // GET: Subcategorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategorias subcategorias = db.Subcategorias.Find(id);
            if (subcategorias == null)
            {
                return HttpNotFound();
            }
            return View(subcategorias);
        }

        // GET: Subcategorias/Create
        public ActionResult Create()
        {
            ViewBag.Id_Categoria = new SelectList(db.Categorias, "Id", "Nombre");
            return View();
        }

        // POST: Subcategorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Categoria,Nombre,Descripcion,Estado")] Subcategorias subcategorias)
        {
            if (ModelState.IsValid)
            {
                db.Subcategorias.Add(subcategorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Categoria = new SelectList(db.Categorias, "Id", "Nombre", subcategorias.Id_Categoria);
            return View(subcategorias);
        }

        // GET: Subcategorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategorias subcategorias = db.Subcategorias.Find(id);
            if (subcategorias == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Categoria = new SelectList(db.Categorias, "Id", "Nombre", subcategorias.Id_Categoria);
            return View(subcategorias);
        }

        // POST: Subcategorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Categoria,Nombre,Descripcion,Estado")] Subcategorias subcategorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Categoria = new SelectList(db.Categorias, "Id", "Nombre", subcategorias.Id_Categoria);
            return View(subcategorias);
        }

        // GET: Subcategorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategorias subcategorias = db.Subcategorias.Find(id);
            if (subcategorias == null)
            {
                return HttpNotFound();
            }
            return View(subcategorias);
        }

        // POST: Subcategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subcategorias subcategorias = db.Subcategorias.Find(id);
            db.Subcategorias.Remove(subcategorias);
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
