using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICloudCash.Entities
{
    public class entCuentas
    {
        public long id_Cuenta { get; set; }
        public long id_Cliente { get; set; }
        public int id_TipoCuenta { get; set; }
        public int id_TipoDivisa { get; set; }
        public string numeroCuenta { get; set; }
        public bool activa {  get; set; }
        public long saldo { get; set; }
    }
}