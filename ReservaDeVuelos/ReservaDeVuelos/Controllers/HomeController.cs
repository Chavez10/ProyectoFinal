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
                    orderby ar.NOM_AERO ascending
                    select new
                    {
                        id = ra.COD_REG_AER,
                        regiones = ar.NOM_AERO + ", " + r.REGION
                    }
                );
            var aerolist = (from arP in data.AEROLINEA_AEROPUERTO
                            join ra in data.REGION_AEROPUERTO on arP.REGION_AEROPUERTO equals ra.COD_REG_AER
                            join psa in data.PAIS_AEROLINEA on arP.PAIS_AEROLINEA equals psa.COD_PAIS_AEROLINEA
                            join arL in data.AEROLINEAS on psa.AEROLINEA equals arL.COD_AEROLINEA
                            where arP.REGION_AEROPUERTO == ra.COD_REG_AER
                            select new
                            {
                                id = arP.COD_AL_AP
                            }
                );
            

            ViewBag.Origen = new SelectList(list, "id", "regiones");
            ViewBag.Destino = new SelectList(list, "id", "regiones");
            return View();
        }

        [HttpPost]
        public ActionResult InsertarReserva(int id)
        {
            return View();
        }
    }
}