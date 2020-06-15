using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservaDeVuelos.Models;
using ReservaDeVuelos.Models.VistaRegistrosModel;
using ReservaDeVuelos.Models.RegistroUsuarioModel;


namespace ReservaDeVuelos.Controllers
{
    public class RegistrosController : Controller
    {
        // GET: Registros
        public ActionResult Registro()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Registros()
        {
            var data = new bdVuelosEntities();
            var model = new RegistroUsuarios();
            //model.Registros = new SelectList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Registros (RegistroUsuarios modelo)
        {

            {
                if (!ModelState.IsValid)
                {
                    return View(modelo);
                }
                using (var data = new bdVuelosEntities())
                {
                    RegistroUsuarios objRegistro = new RegistroUsuarios();
                    objRegistro.NOMBRES_USER = modelo.NOMBRES_USER;
                    objRegistro.APELLIDOS_USER = modelo.APELLIDOS_USER;
                    objRegistro.EDAD = modelo.EDAD;
                    objRegistro.FECHA_USER = modelo.FECHA_USER;
                    objRegistro.DIRRECION = modelo.DIRRECION;
                    objRegistro.MAIL_USER = modelo.MAIL_USER;                   
                   
                    objRegistro.USER = modelo.USER;
                    objRegistro.GENERO = modelo.GENERO;
                    objRegistro.PASSWORD = modelo.PASSWORD;
                }
                return Redirect(Url.Content("~/Registros"));
            }

        }
    }
}