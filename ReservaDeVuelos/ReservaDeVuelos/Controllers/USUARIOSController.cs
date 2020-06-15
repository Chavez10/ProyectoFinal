using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservaDeVuelos.Models;
using ReservaDeVuelos.Models.VistaRegistrosModel;
using ReservaDeVuelos.Models.CRUD;

namespace ReservaDeVuelos.Controllers
{
    public class USUARIOSController : Controller
    {
        // GET: USUARIOS
        public ActionResult Index()
        {
            List<InfoUser> lista = null;
            using (bdVuelosEntities1 data = new bdVuelosEntities1())
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
                objUser.FECHA_CREACION = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                objUser.COD_USUARIO = modelo.COD_USER;
                objUser.PASSWORD = modelo.PASS_USER;
                data.USUARIOS.Add(objUser);
                data.SaveChanges();
            }
            return Redirect(Url.Content("~/USUARIOS"));
        }
        public ActionResult Edit(int id)
        {

            UserViewEditar modelo = new UserViewEditar();

          
            using (var data = new bdVuelosEntities1())
            {
              var actUser = data.USUARIOS.Find(id);
               modelo.COD_ESTADO =  actUser.ESTADO;                     
               modelo.MAIL_USER  =  actUser.EMAIL;                      
               modelo.APELLIDOS  =  actUser.APELLIDOS;                  
               modelo.DIRECCION  =  actUser.DIRECCION;                  
               modelo.EDADES     =  actUser.EDAD;                       
               modelo.GENERO     =  actUser.GENERO;                     
               modelo.NOMB_USER  =  actUser.NOMBRES;                    
               modelo.NOM_USU    =  actUser.USUARIO;
               
               modelo.COD_USER   = actUser.COD_USUARIO;
               modelo.PASS_USER  = actUser.PASSWORD;
               modelo.COD_ROL = actUser.ROL;

            }
          
            return View(modelo);
        }
        [HttpPost]
        public ActionResult Edit(UserViewEditar modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            using (var data = new bdVuelosEntities1())
            {
                var objUser = data.USUARIOS.Find(modelo.COD_USER);
                objUser.EMAIL = modelo.MAIL_USER;
                objUser.USUARIO = modelo.NOM_USU;
                if(modelo.PASS_USER !=null && modelo.PASS_USER.Trim() != "")
                {
                    objUser.PASSWORD = modelo.PASS_USER;
                }
                objUser.ROL = modelo.COD_ROL;
                objUser.FECHA_CREACION= Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                objUser.NOMBRES = modelo.NOMB_USER;
                objUser.APELLIDOS = modelo.APELLIDOS;
                objUser.DIRECCION = modelo.DIRECCION;
                objUser.EDAD = modelo.EDADES;
                objUser.ESTADO = modelo.COD_ESTADO;
                objUser.GENERO = modelo.GENERO;
                data.Entry(objUser).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();

                return Redirect(Url.Content("~/USUARIOS"));
            }
        }
        [HttpPost]

        public ActionResult Borrar(int id)
        {
            using (var data = new bdVuelosEntities1())
            {
                var objUser = data.USUARIOS.Find(id);
                objUser.ESTADO = false;
                data.Entry(objUser).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
            }
            return Content("1");
        }
    }
}