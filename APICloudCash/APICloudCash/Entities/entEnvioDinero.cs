using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICloudCash.Entities
{
    public class entEnvioDinero
    {
        public long id_EnvioDinero { get; set; }
        public long id_Cuenta { get; set; }
        public string nombreReceptor { get; set; }
        public string numeroCuentaReceptor { get; set; }
        public string asunto { get; set; }
        public long monto { get; set; }
    }
}