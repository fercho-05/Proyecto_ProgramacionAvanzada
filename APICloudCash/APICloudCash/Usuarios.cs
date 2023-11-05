//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APICloudCash
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.Administradores = new HashSet<Administradores>();
            this.Clientes = new HashSet<Clientes>();
        }
    
        public long id_Usuario { get; set; }
        public string cedula { get; set; }
        public string nombreUsuario { get; set; }
        public string contrasena { get; set; }
        public string nombre { get; set; }
        public string apellidoUno { get; set; }
        public string apellidoDos { get; set; }
        public Nullable<int> telefono { get; set; }
        public string correo { get; set; }
        public System.DateTime fechaRegistro { get; set; }
        public bool activo { get; set; }
        public int id_TipoUsuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Administradores> Administradores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clientes> Clientes { get; set; }
        public virtual TipoUsuarios TipoUsuarios { get; set; }
    }
}
