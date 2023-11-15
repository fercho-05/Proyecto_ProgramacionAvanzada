using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICloudCash.Entities
{
    public class entTarjetas
    {
        public long id_Tarjeta { get; set; }
        public long id_Cliente { get; set; }
        public string numeroTarjeta { get; set; }
        public string nombrePoseedor { get; set; }
        public System.DateTime fechaVencimiento { get; set; }
        public short cvc { get; set; }
        public long saldo { get; set; }
        public int id_TipoDivisa { get; set; }
        public bool activa { get; set; }
        public int id_TipoTarjeta { get; set; }
        public int id_MarcaTarjeta { get; set; }
        public string mensaje { get; set; }

    }
}