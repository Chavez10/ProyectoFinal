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
                            regiones = ar.NOM_AERO + ", " + r.REGION,
                            
                        }
                );
            

            var aerolist = (from arP in data.AEROLINEA_AEROPUERTO
                            join ra in data.REGION_AEROPUERTO on arP.REGION_AEROPUERTO equals ra.COD_REG_AER
                            join psa in data.PAIS_AEROLINEA on arP.PAIS_AEROLINEA equals psa.COD_PAIS_AEROLINEA
                            join arL in data.AEROLINEAS on psa.AEROLINEA equals arL.COD_AEROLINEA
                            
                            select new
                            {
                                id = arP.COD_AL_AP,
                                aerolinea = arL.NOM_AEROLINEA,
                                id_r = ra.REGIONES
                            }
                ).Distinct();
            var tipoVuelo = (from tip in data.TIPO_VUELOS
                             select new
                             {
                                 id = tip.COD_TIP_VUELO,
                                 tp = tip.TIPO_VUELO
                             }
                
                );
            var OpcVuelo = (from op in data.OPC_VUELOS
                             select new
                             {
                                 id = op.COD_OPC_VUELO,
                                 tp = op.OPCION_VUELO
                             }

                );
            ViewBag.OpcVuelo = new SelectList(OpcVuelo, "id", "tp");
            ViewBag.TipoVuelo = new SelectList(tipoVuelo, "id", "tp");
            ViewBag.Origen = new SelectList(list, "id", "regiones");
            ViewBag.Destino = new SelectList(list, "id", "regiones");
            ViewBag.Aerolinea = new SelectList(aerolist, "id", "aerolinea");
            return View();
        }

        [HttpPost]
        public ActionResult InsertarReserva(FormCollection form)
        {
            var aero = form["Aerolinea"];
            var origen = form["Origen"];
            var destino = form["Destino"];
            var tpVuelo = form["TipoVuelo"];
            var opcVuelo = form["OpcVuelo"];
            var salida = form["salida"];
            var retorno = form["retorno"];
            var asiento = form["asiento"];

            using(var dt = new bdVuelosEntities1())
            {
                RESERVAS_DESTINOS rd = new RESERVAS_DESTINOS();
                RESERVAS_ASIENTOS ra = new RESERVAS_ASIENTOS();
                RESERVAS_VUELOS rv = new RESERVAS_VUELOS();

                ra.COD_TIP_VUELO = int.Parse(tpVuelo);
                ra.ASIENTO = int.Parse(asiento);
                ra.AEROLINEA_AEROPUERTO = int.Parse(aero);
                ra.COD_AVION = 1;
                ra.COD_USUARIO = 14;
                data.RESERVAS_ASIENTOS.Add(ra);
                data.SaveChanges();
                
                rd.COD_OPC_VUELO = int.Parse(opcVuelo);
                rd.SALIDA = Convert.ToDateTime(salida);
                rd.RETORNO = Convert.ToDateTime(retorno);
                rd.ORIGEN = int.Parse(origen);
                rd.DESTINO = int.Parse(destino);
                rd.USUARIO = 14;
                data.RESERVAS_DESTINOS.Add(rd);
                data.SaveChanges();

                rv.COD_USUARIO = 14;
                rv.COD_RESERVA_DESTINO = rd.COD_RESERVA_DESTINO;
                rv.COD_RESERVA_ASIENTO = ra.COD_RESERVA_ASIENTO;
                rv.FECHA_CREACION = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                data.RESERVAS_VUELOS.Add(rv);
                data.SaveChanges();
            }
            return Redirect(Url.Content("~/Pagos"));
        }
    }
}