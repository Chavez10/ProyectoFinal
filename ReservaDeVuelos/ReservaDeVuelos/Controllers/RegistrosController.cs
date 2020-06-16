using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservaDeVuelos.Models;
using ReservaDeVuelos.Models.RegistroUsuarioModel;
using ReservaDeVuelos.Models.CRUD;

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
        public ActionResult Registro(UserViewCrud modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            using (var data = new bdVuelosEntities1())
            {
                USUARIOS objRes = new USUARIOS();
                objRes.NOMBRES = modelo.NOMB_USER;
                objRes.APELLIDOS = modelo.APELLIDOS;
                objRes.EDAD = modelo.EDADES;
                objRes.DIRECCION = modelo.DIRECCION;
                objRes.EMAIL = modelo.MAIL_USER;
                objRes.GENERO = modelo.GENERO;
                objRes.FECHA_CREACION = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                objRes.USUARIO = modelo.NOM_USU;
                objRes.PASSWORD = modelo.PASS_USER;
                objRes.ESTADO =modelo.COD_ESTADO;
                objRes.ROL = 2;
                data.USUARIOS.Add(objRes);
                data.SaveChanges();
               
            }
                return Redirect(Url.Content("~/Acceso/Login"));
           
        }
        
    }
}