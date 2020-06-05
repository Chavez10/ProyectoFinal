using ReservaDeVuelos.Controllers;
using ReservaDeVuelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservaDeVuelos.Filters
{
    public class ValidarSesiones : ActionFilterAttribute
    {
        private USUARIOS usu;
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try { 
            base.OnActionExecuted(filterContext);
            usu = (USUARIOS)HttpContext.Current.Session["user"];
            if (usu == null)
            {
                if (filterContext.Controller is AccesoController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceso/Login");
                }
            }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }
        
        }
    
    }
}