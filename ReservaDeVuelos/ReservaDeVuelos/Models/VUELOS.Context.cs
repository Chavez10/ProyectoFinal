﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReservaDeVuelos.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BD_RESERVAS_VUELOSEntities : DbContext
    {
        public BD_RESERVAS_VUELOSEntities()
            : base("name=BD_RESERVAS_VUELOSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AEROLINEAS> AEROLINEAS { get; set; }
        public virtual DbSet<AEROPUERTOS> AEROPUERTOS { get; set; }
        public virtual DbSet<ASIGNA_AP_AL> ASIGNA_AP_AL { get; set; }
        public virtual DbSet<AVIONES> AVIONES { get; set; }
        public virtual DbSet<CONTACTOS_DOCUMENTOS> CONTACTOS_DOCUMENTOS { get; set; }
        public virtual DbSet<MODULOS> MODULOS { get; set; }
        public virtual DbSet<OPC_VUELOS> OPC_VUELOS { get; set; }
        public virtual DbSet<OPERACIONES> OPERACIONES { get; set; }
        public virtual DbSet<PAISES> PAISES { get; set; }
        public virtual DbSet<PAISES_REGIONES> PAISES_REGIONES { get; set; }
        public virtual DbSet<PRECIOS_VUELOS> PRECIOS_VUELOS { get; set; }
        public virtual DbSet<PROC_PAGOS_VUELOS> PROC_PAGOS_VUELOS { get; set; }
        public virtual DbSet<REGIONES> REGIONES { get; set; }
        public virtual DbSet<RESERVAS_ASIENTOS> RESERVAS_ASIENTOS { get; set; }
        public virtual DbSet<RESERVAS_VUELOS> RESERVAS_VUELOS { get; set; }
        public virtual DbSet<ROL_OPERA> ROL_OPERA { get; set; }
        public virtual DbSet<ROLES> ROLES { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TIPO_CONTACTOS> TIPO_CONTACTOS { get; set; }
        public virtual DbSet<TIPO_DOCUMENTOS> TIPO_DOCUMENTOS { get; set; }
        public virtual DbSet<TIPO_VUELOS> TIPO_VUELOS { get; set; }
        public virtual DbSet<TIPOS_PAGOS> TIPOS_PAGOS { get; set; }
        public virtual DbSet<USUARIOS> USUARIOS { get; set; }
        public virtual DbSet<RESERVAS_DESTINOS> RESERVAS_DESTINOS { get; set; }
    }
}
