//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webAI_UNAM
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblClientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblClientes()
        {
            this.tblContactosCliente = new HashSet<tblContactosCliente>();
        }
    
        public System.Guid ClientesID { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> TipoRFCID { get; set; }
        public string RFC { get; set; }
        public string CorreoPersonal { get; set; }
        public string CorreoTrabajo { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public int UbicacionID { get; set; }
        public Nullable<int> EstatusRegistroID { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public System.Guid CorporativoID { get; set; }
    
        public virtual tblCorporativo tblCorporativo { get; set; }
        public virtual tblUbicaciones tblUbicaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblContactosCliente> tblContactosCliente { get; set; }
    }
}