using MerceriaGit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MerceriaGit.Controllers
{
    public class SeguimientoEnviosController : Controller
    {
        // GET: SeguimientoEnvios
        public ActionResult Index(int id)
        {
            contextTienda db = new contextTienda();

            List<Envios> listaEnvios = null;

            var query = from e in db.Envios
                        where e.Ventas.Id_Usuario == id
                        select e;
            listaEnvios = query.ToList();

            ViewBag.listaEnvios = listaEnvios;

            return View();
        }
    }
}