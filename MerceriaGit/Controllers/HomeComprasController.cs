using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MerceriaGit.Models;

namespace MerceriaGit.Controllers
{
    public class HomeComprasController : Controller
    {
        // GET: HomeCompras
        public ActionResult Index()
        {
            contextTienda db = new contextTienda();

            List<Productos> productosPocoStock = null;
            var query = from p in db.Productos
                        where p.Existencia <=10 
                        select p;
            productosPocoStock = query.ToList();

            List<ImagenesProducto> imagenesProductos = db.ImagenesProducto.ToList();

            ViewBag.productosPocoStock = productosPocoStock;
            ViewBag.imagenesProductos = imagenesProductos;
            return View();
        }
    }
}