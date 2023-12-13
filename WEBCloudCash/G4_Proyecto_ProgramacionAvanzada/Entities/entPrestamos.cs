using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBCloudCash.Entities
{
    public class entPrestamos
    {
        public long id_Prestamo { get; set; }
        public long id_Cliente { get; set; }
        public long id_TipoPrestamo { get; set; }
        public int id_TipoDivisa { get; set; }
        public float monto { get; set; }
        public int plazo { get; set; }
        public int tasaInteres { get; set; }
        public bool activo { get; set; }
    }
}