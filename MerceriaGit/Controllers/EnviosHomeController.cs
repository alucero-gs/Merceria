using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MerceriaGit.Models;

namespace MerceriaGit.Controllers
{
    public class EnviosHomeController : Controller
    {
        // GET: EnviosHome
        public ActionResult Index()
        {
            contextTienda db = new contextTienda();

            List<Envios> listaEnvios = db.Envios.ToList();

            ViewBag.listaEnvios = listaEnvios;

            return View();
        }     
        // GET: EnviosHome
        public ActionResult EnviosPendientes()
        {
            contextTienda db = new contextTienda();

            List<Envios> listaEnvios = null;

            var query = from e in db.Envios
                        where e.Estado_Envio ==1
                        select e;
            listaEnvios = query.ToList();

            ViewBag.listaEnvios = listaEnvios;

            return View();

        }// GET: EnviosHome
        public ActionResult EnviosEnCamino()
        {
            contextTienda db = new contextTienda();

            List<Envios> listaEnvios = null;

            var query = from e in db.Envios
                        where e.Estado_Envio ==2
                        select e;
            listaEnvios = query.ToList();

            ViewBag.listaEnvios = listaEnvios;

            return View();
        }

        public ActionResult HistorialEnvios()
        {
            contextTienda db = new contextTienda();

            List<Envios> listaEnvios = null;

            var query = from e in db.Envios
                        where e.Estado_Envio == 3
                        select e;
            listaEnvios = query.ToList();

            ViewBag.listaEnvios = listaEnvios;

            return View();
        }


        public ActionResult RealizarEnvio(int? id)
        {
            contextTienda db = new contextTienda();
            Envios envio = db.Envios.Find(id);
            envio.Estado_Envio = 2;
            envio.Fecha_Envio = DateTime.Now;
            envio.Fecha_Estimada_Entrega = DateTime.Now.AddDays(3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RealizarEnvio2(int? id)
        {
            contextTienda db = new contextTienda();
            Envios envio = db.Envios.Find(id);
            envio.Estado_Envio = 2;
            envio.Fecha_Envio = DateTime.Now;
            envio.Fecha_Estimada_Entrega = DateTime.Now.AddDays(3);
            db.SaveChanges();
            return RedirectToAction("EnviosPendientes");
        }

        public ActionResult RealizarEntrega(int? id)
        {
            contextTienda db = new contextTienda();
            Envios envio = db.Envios.Find(id);
            envio.Estado_Envio = 3;
            envio.Fecha_Entrega = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RealizarEntrega2(int? id)
        {
            contextTienda db = new contextTienda();
            Envios envio = db.Envios.Find(id);
            envio.Estado_Envio = 3;
            envio.Fecha_Entrega = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("EnviosEnCamino");
        }

        public ActionResult Detalles(int? id)
        {
            contextTienda db = new contextTienda();
            Envios envio = db.Envios.Find(id);
            return View(envio);
        }
    }
}