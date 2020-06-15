using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservaDeVuelos.Models;

namespace ReservaDeVuelos.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string User, string pass)
        {
            try
            {
                using (Models.bdVuelosEntities1 db = new bdVuelosEntities1())
                {
                    var USUARIOS = (from datos in db.USUARIOS
                                    where datos.EMAIL == User.Trim() &&
                                    datos.PASSWORD == pass.Trim()
                                    select datos).FirstOrDefault();
                    if (USUARIOS == null)
                    {
                        ViewBag.Error = "El Usuario No existe";
                        return View();
                    }
                    else
                    {
                        Session["User"] = USUARIOS;
                    }
                    if(USUARIOS.ROL == 1)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                
                return RedirectToAction("Dashboard", "Home");
            }
            catch
            {
                return View();
            }
           
           
            
        }
    }
}