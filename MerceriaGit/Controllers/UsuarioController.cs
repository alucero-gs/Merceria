using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MerceriaGit.Models;

namespace MerceriaGit.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private contextMerceria db = new contextMerceria();

        // GET: Usuario
        public ActionResult Index(string email)
        {
            if (User.Identity.IsAuthenticated)
            {
                string correo = email;
                string username = "";

                using (db)
                {
                    var query = from st in db.Usuarios
                                where st.Correo == correo
                                select st;
                    var lista = query.ToList();
                    if (lista.Count > 0)
                    {
                        var usuario = query.FirstOrDefault<Usuarios>();
                        string[] nombres = usuario.Nombre.ToString().Split(' ');
                        Session["name"] = nombres[0];
                        Session["usr"] = usuario.Nombre;
                        username = usuario.Username.ToString().TrimEnd();
                    }
                    else
                    {

                    }
                }
                if (username == "pedrito1")
                {
                    return RedirectToAction("Index", "Compras");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
                return RedirectToAction("Index", "Home");
                return View();
        }
    }
}