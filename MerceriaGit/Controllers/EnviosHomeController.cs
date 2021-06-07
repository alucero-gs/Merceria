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
    }
}