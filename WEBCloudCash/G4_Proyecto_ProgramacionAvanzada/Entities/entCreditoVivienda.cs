using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBCloudCash.Entities
{
    public class entCreditoVivienda
    {
        public long id_CreditoVivienda { get; set; }
        public long id_Cliente { get; set; }
        public long id_TipoDivisa { get; set; }
        public long Monto { get; set; }
        public int PorcentajeInteres { get; set; }
        public int PlazoAnnios { get; set; }
        public DateTime FechaAprobacion { get; set; }

    }
}