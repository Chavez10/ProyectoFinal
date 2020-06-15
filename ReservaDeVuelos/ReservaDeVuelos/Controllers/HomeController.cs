using ReservaDeVuelos.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservaDeVuelos.Models;

namespace ReservaDeVuelos.Controllers
{
    public class HomeController : Controller
    {
        private bdVuelosEntities1 data = new bdVuelosEntities1();

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

            
            var list = (from ra in data.REGION_AEROPUERTO
                    join ar in data.AEROPUERTOS on ra.AEROPUERTO equals ar.COD_AERO
                    join r in data.REGIONES on ra.REGION equals r.COD_REGION
                    orderby r.REGION ascending
                    select ar.NOM_AERO +", "+ r.REGION
                ).FirstOrDefault();

            ViewBag.Origen = new SelectList(list, "COD_REG_AER");
            return View();
        }

        [HttpPost]
        public ActionResult InsertarReserva()
        {
            return View();
        }
    }
}