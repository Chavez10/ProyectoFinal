﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;

namespace ReservaDeVuelos.Models.RegistroUsuarioModel
{
    public class RegistroUsuarios
    {
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "No cumple el tamaño", MinimumLength = 1)]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Correo de usuario")]
        public string MAIL_USER { get; set; }
        [Required]
        [StringLength(10, ErrorMessage ="No cumple el tamaño",MinimumLength =5)]
        [DataType(DataType.Text)]
        [Display(Name ="Usuario")]
        public string USER { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "No cumple el tamaño", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name ="Contraseña")]
        public string PASSWORD { get; set; }
        [Display(Name ="Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("PASSWORD", ErrorMessage ="Las contraseñas no coniciden")]
        public string CONFIR_PASS { get; set; }
        [Required]
        public int COD_ROL { get; set; }
       
        
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombres de Usuario")]
        public string NOMBRES_USER { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Apellidos de Usuario")]
        public string APELLIDOS_USER { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Dirreccion")]
        public string DIRECCION { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Edad ")]
        public int EDAD { get; set; }
        
        public bool ESTADO { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Genero ")]
        public string GENERO { get; set; }
    }
}