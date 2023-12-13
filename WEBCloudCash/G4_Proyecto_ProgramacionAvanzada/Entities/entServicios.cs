using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBCloudCash.Entities
{
    public class entServicios
    {
        public int id_TipoServicio { get; set; }
        public string descripcion { get; set; }
        public int monto { get; set; }
        public bool activo { get; set; }
    }
}