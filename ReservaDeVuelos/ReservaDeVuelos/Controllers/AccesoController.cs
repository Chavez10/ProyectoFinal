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
        public ActionResult Login(string pass)
        {
            BD_RESERVAS_VUELOSEntities1 data = new BD_RESERVAS_VUELOSEntities1();
           
            return View();
        }
    }
}