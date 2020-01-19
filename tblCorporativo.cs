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
    
    public partial class tblCorporativo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCorporativo()
        {
            this.tblCentro = new HashSet<tblCentro>();
            this.tblClientes = new HashSet<tblClientes>();
            this.tblCorreoNotificacion = new HashSet<tblCorreoNotificacion>();
            this.tblFiscales = new HashSet<tblFiscales>();
            this.tblProductosCategoria = new HashSet<tblProductosCategoria>();
            this.tblProspectos = new HashSet<tblProspectos>();
            this.tblProveedores = new HashSet<tblProveedores>();
            this.tblUsuarios = new HashSet<tblUsuarios>();
        }
    
        public System.Guid CorporativoID { get; set; }
        public string Nombre { get; set; }
        public byte[] CorreoElecronico { get; set; }
        public byte[] Telefono { get; set; }
        public int UbicacionID { get; set; }
        public int EstatusRegistroID { get; set; }
        public System.DateTime FechaRegistro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCentro> tblCentro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClientes> tblClientes { get; set; }
        public virtual tblUbicaciones tblUbicaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCorreoNotificacion> tblCorreoNotificacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFiscales> tblFiscales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductosCategoria> tblProductosCategoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProspectos> tblProspectos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProveedores> tblProveedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUsuarios> tblUsuarios { get; set; }
    }
}
