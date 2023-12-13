using WEBCloudCash.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WEBCloudCash.Models
{
    public class modCreditoVivienda
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public entCreditoVivienda credito {  get; set; }

        public entCreditoVivienda ListarCreditoVivienda(string cedula)
        {
            credito = new entCreditoVivienda();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}ListarCreditoVivienda?cedula={cedula}";
                var resp = client.GetAsync(url).Result;
                credito = resp.Content.ReadFromJsonAsync<entCreditoVivienda>().Result;
                return credito;
            }
        }
      
    }
}