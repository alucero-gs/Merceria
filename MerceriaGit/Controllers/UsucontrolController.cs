using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MerceriaGit.Models;

namespace MerceriaGit.Controllers
{
    public class UsucontrolController : Controller
    {
        private contextTienda db = new contextTienda();

        // GET: Usuarios
        public ActionResult Index(string email)
        {
            contextTienda db = new contextTienda();
            //var usuarios = db.Usuarios.Include(u => u.TipoUsuario);
            //return View(usuarios.ToList());
            if (User.Identity.IsAuthenticated)
            {
                 string correo = email.Trim();
                int Id_TipoUsuario =0;

                using (db)
                {
                    var query = from st in db.Usuarios
                                where st.Correo.Trim() == correo
                                
                                select st;
                    
                    var lista = query.ToList();
                    if (lista.Count > 0)
                    {
                        
                        var empleado = query.FirstOrDefault<Usuarios>();
                        string[] nombres = empleado.Nombre.ToString().Split(' ');
                        Session["name"] = empleado.Nombre;
                        Session["usr"] = empleado.Nombre;
                        Id_TipoUsuario = empleado.Id_TipoUsuario;
                    }
                    else
                    {
                        
                        var query1 = from st in db.Usuarios
                                     where st.Correo.Trim() == correo
                                     select st;
                        var lista1 = query.ToList();
                        if (lista1.Count > 0)
                        {
                            
                            var cliente = query1.FirstOrDefault<Usuarios>();
                            string[] nombres = cliente.Nombre.ToString().Split(' ');
                            Session["name"] = cliente.Nombre;
                            Session["usr"] = cliente.Nombre;
                            Id_TipoUsuario = 3;

                        }


                    }
                    Debug.WriteLine(Id_TipoUsuario);
                    if (Id_TipoUsuario == 1)
                    {
                        return RedirectToAction("Index", "Usuarios");
                    }

                    if (Id_TipoUsuario == 3)
                    {
                        return RedirectToAction("Index", "Subcategorias");
                    }

                    if (Id_TipoUsuario == 2)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    if (Id_TipoUsuario == 4)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    if (Id_TipoUsuario == 5)
                    {
                        return RedirectToAction("Index", "Categorias");
                    }


                }
                


            }
            else
            {
                return RedirectToAction("Index", "Productos");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}