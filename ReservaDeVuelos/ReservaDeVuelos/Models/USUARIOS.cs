//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class USUARIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIOS()
        {
            this.CONTACTOS_DOCUMENTOS = new HashSet<CONTACTOS_DOCUMENTOS>();
            this.RESERVAS_ASIENTOS = new HashSet<RESERVAS_ASIENTOS>();
            this.RESERVAS_VUELOS = new HashSet<RESERVAS_VUELOS>();
            this.RESERVAS_DESTINOS = new HashSet<RESERVAS_DESTINOS>();
        }
    
        public int COD_USUARIO { get; set; }
        public string EMAIL { get; set; }
        public string USUARIO { get; set; }
        public string PASSWORD { get; set; }
        public int ROL { get; set; }
        public System.DateTime FECHA_CREACION { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string DIRECCION { get; set; }
        public int EDAD { get; set; }
        public bool ESTADO { get; set; }
        public string GENERO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTACTOS_DOCUMENTOS> CONTACTOS_DOCUMENTOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVAS_ASIENTOS> RESERVAS_ASIENTOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVAS_VUELOS> RESERVAS_VUELOS { get; set; }
        public virtual ROLES ROLES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVAS_DESTINOS> RESERVAS_DESTINOS { get; set; }
    }
}
