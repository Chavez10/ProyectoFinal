using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservaDeVuelos.Models;
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

        [HttpPost]
        public ActionResult Registro(RegistroUsuarios modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            using (var data = new bdVuelosEntities1())
            {
                USUARIOS objRes = new USUARIOS();
                objRes.NOMBRES = modelo.NOMBRES_USER;
                objRes.APELLIDOS = modelo.APELLIDOS_USER;
                objRes.EDAD = modelo.EDAD;
                objRes.DIRECCION = modelo.DIRRECION;
                objRes.EMAIL = modelo.MAIL_USER;
                objRes.GENERO = modelo.GENERO;
                objRes.FECHA_CREACION = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                objRes.USUARIO = modelo.USER;
                objRes.PASSWORD = modelo.PASSWORD;
                objRes.ESTADO = true;
                data.USUARIOS.Add(objRes);
                data.SaveChanges();
               
            }
                return Redirect(Url.Content("~/Acceso/Login"));
           
        }
        
    }
}