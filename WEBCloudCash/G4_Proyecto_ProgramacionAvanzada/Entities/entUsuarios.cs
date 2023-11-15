using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBCloudCash.Entities
{
    public class entUsuarios
    {
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
        public string mensaje { get; set; }
        public string nuevaContrasena { get; set; }


    }
}