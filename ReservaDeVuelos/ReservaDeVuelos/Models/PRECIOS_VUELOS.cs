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
    
    public partial class PRECIOS_VUELOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRECIOS_VUELOS()
        {
            this.PROC_PAGOS_VUELOS = new HashSet<PROC_PAGOS_VUELOS>();
        }
    
        public int COD_PRECIO_VUELO { get; set; }
        public int ORIGEN { get; set; }
        public int DESTINO { get; set; }
        public int COD_AEROLINEA { get; set; }
        public decimal TOTAL { get; set; }
    
        public virtual AEROLINEAS AEROLINEAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROC_PAGOS_VUELOS> PROC_PAGOS_VUELOS { get; set; }
    }
}
