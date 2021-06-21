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
    public class UsuariosController : Controller
    {
        private contextTienda db = new contextTienda();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.TipoUsuario);
            return View(usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.Id_TipoUsuario = new SelectList(db.TipoUsuario, "Id", "Nombre");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido_Paterno,Apellido_Materno,Fecha_Nacimiento,Telefono,Correo,Id_TipoUsuario,Username,Password,Estado")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_TipoUsuario = new SelectList(db.TipoUsuario, "Id", "Nombre", usuarios.Id_TipoUsuario);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_TipoUsuario = new SelectList(db.TipoUsuario, "Id", "Nombre", usuarios.Id_TipoUsuario);
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido_Paterno,Apellido_Materno,Fecha_Nacimiento,Telefono,Correo,Id_TipoUsuario,Username,Password,Estado")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_TipoUsuario = new SelectList(db.TipoUsuario, "Id", "Nombre", usuarios.Id_TipoUsuario);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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

        // GET: Usuarios/Create
        public ActionResult Clientes(string correo)
        {
            ViewBag.Id_TipoUsuario = new SelectList(db.TipoUsuario, "Id", "Nombre");
            ViewBag.correo = correo;
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Clientes([Bind(Include = "Id,Nombre,Apellido_Paterno,Apellido_Materno,Fecha_Nacimiento,Telefono,Correo,Id_TipoUsuario,Username,Password,Estado")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                usuarios.TipoUsuario = db.TipoUsuario.Find(2);
                usuarios.Estado = "1";
                db.Usuarios.Add(usuarios); 
                
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Id_TipoUsuario = new SelectList(db.TipoUsuario, "Id", "Nombre", usuarios.Id_TipoUsuario);
            return View(usuarios);
        }
    }
}
