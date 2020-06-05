using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservaDeVuelos.Controllers
{
    public class CerrarSesionController : Controller
    {
        // GET: CerrarSesion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CerrarSesion()
        {
            Session["user"] = null;

            return RedirectToAction("Login", "Acceso");
        }
    }
}