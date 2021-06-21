using MerceriaGit.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MerceriaGit.Controllers
{
    public class CarroController : Controller
    {
        // GET: Carro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agregar(int id)
        {
            ProdCarro carro = new ProdCarro();
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                Productos P = carro.find(id);
                string nam = P.Nombre;
                cart.Add(new Item { Product = carro.find(id), Cantidad = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Cantidad++;
                }
                else
                {
                    Productos P = carro.find(id);
                    string nam = P.Nombre;
                    cart.Add(new Item { Product = carro.find(id), Cantidad = 1 });

                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }


        public ActionResult Eliminar(int id)
        {
            List<Item> carro = (List<Item>)Session["cart"];
            int index = isExist(id);
            Debug.WriteLine(index);
            carro.RemoveAt(index);
            Session["Cart"] = carro;
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar2(int id)
        {
            ProdCarro carro = new ProdCarro();
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            if (index != -1)
            {
                cart[index].Cantidad--;
            }
            else
            {
                Eliminar(id);
            }
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        public ActionResult preOrden()
        {
            return View();
        }


        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }
    }
}