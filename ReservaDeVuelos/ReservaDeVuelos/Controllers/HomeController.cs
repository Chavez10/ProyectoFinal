using ReservaDeVuelos.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservaDeVuelos.Controllers
{
    public class HomeController : Controller
    {
        [Autorizaciones(CodOperacion: 1)]
        public ActionResult Index()
        {
            return View();
        }
        [Autorizaciones(CodOperacion: 2)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Autorizaciones(CodOperacion: 3)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /* --- METODOS HA TRABAJAR DESDE AQUÍ --- */
        [Autorizaciones (CodOperacion: 5)]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}