using ReservaDeVuelos.Controllers;
using ReservaDeVuelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservaDeVuelos.Filters
{
    public class Autorizaciones : AuthorizeAttribute
    {
        string OPeracionNombre = "";
        string Modulo = "";
        private USUARIOS user;
        private BD_RESERVAS_VUELOSEntities2 data = new BD_RESERVAS_VUELOSEntities2();
        private int Operar;

        public Autorizaciones(int CodOperacion = 0)
        {
            this.Operar = CodOperacion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // base.OnAuthorization(filterContext);
            try
            {
                user = (USUARIOS)HttpContext.Current.Session["user"];
                var misOperaciones = from dt in data.ROL_OPERA
                                     where dt.COD_ROL == user.ROL
                                     && dt.COD_OPERA == Operar
                                     select dt;
                if(misOperaciones.ToList().Count < 1)
                {
                    var operas = data.OPERACIONES.Find(Operar);
                    int? codigoModulo = operas.COD_MOD;
                    OPeracionNombre = getNombOperacion(Operar);
                    Modulo = getNomModulos(codigoModulo);
                    filterContext.Result = new RedirectResult("~/Error/OperacionNoAutorizada?operacion="
                        + OPeracionNombre + ", modulo=" + Modulo + ", error=No_se_Aotoriza");

                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/OperacionNoAutorizada?operacion="
                        + OPeracionNombre + ", modulo=" + Modulo + ", error=No_se_Autoriza");
            }
        }

        private string getNomModulos(int? codigoModulo)
        {
            string nomMod;
            var mod = from mode in data.MODULOS
                      where mode.COD_MOD == codigoModulo
                      select mode.NOM_MOD;

            try
            {
                nomMod = mod.First();
            }
            catch (Exception)
            {
                nomMod = "";
            }

            return nomMod;
        }

        private string getNombOperacion(int operar)
        {
            string nomOpr;
            var opr = from oper in data.OPERACIONES
                      where oper.COD_OPERA == operar
                      select oper.NOM_OPERA;

            try
            {
                nomOpr = opr.First();
            }
            catch (Exception)
            {
                nomOpr = "";
            }

            return nomOpr;
        }
    }
}