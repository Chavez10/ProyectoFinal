using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservaDeVuelos.Models;
using ReservaDeVuelos.Models.VistaUsuariosModel;
using ReservaDeVuelos.Models.CRUD;

namespace ReservaDeVuelos.Controllers
{
    public class USUARIOSController : Controller
    {
        // GET: USUARIOS
        public ActionResult Index()
        {
            List<InfoUser> lista = null;
            using(bdVuelosEntities1 data = new bdVuelosEntities1())
            {
                lista = (from info in data.USUARIOS
                         join rol in data.ROLES on info.ROL equals rol.COD_ROL
                         where info.ESTADO == true
                         orderby info.COD_USUARIO ascending
                         select new InfoUser
                         {
                             COD_USER = info.COD_USUARIO,
                             NOM_USER = info.NOMBRES,
                             MAIL_USER = info.EMAIL,
                             COD_ROL = rol.ROL,
                             COD_ESTADO = info.ESTADO
                         }).ToList();
            }
            return View(lista);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            var data = new bdVuelosEntities1();
            var model = new UserViewCrud();
            model.Roles = new SelectList(data.ROLES, "COD_ROL", "ROL", 1);
            return View(model);
        }
        [HttpPost]
        public ActionResult Insert(UserViewCrud modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            using (var data = new bdVuelosEntities1())
            {
                USUARIOS objUser = new USUARIOS();
                objUser.ESTADO = modelo.COD_ESTADO;
                objUser.EMAIL = modelo.MAIL_USER;
                objUser.APELLIDOS = modelo.APELLIDOS;
                objUser.DIRECCION = modelo.DIRECCION;
                objUser.EDAD = modelo.EDADES;
                objUser.GENERO = modelo.GENERO;
                objUser.NOMBRES = modelo.NOMB_USER;
                objUser.USUARIO = modelo.NOM_USU;
                objUser.ROL = modelo.COD_ROL;
                objUser.FECHA_CREACION= Convert.ToDateTime( DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                objUser.COD_USUARIO = modelo.COD_USER;
                objUser.PASSWORD = modelo.PASS_USER;
                data.USUARIOS.Add(objUser);
                data.SaveChanges();
            }
            return Redirect(Url.Content("~/USUARIOS"));
        }
    }
}