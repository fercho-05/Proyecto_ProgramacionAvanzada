using WEBCloudCash.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace WEBCloudCash.Models
{
    public class modCreditos
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];

        public string RegistrarCreditoVivienda(entCreditoVivienda entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "RegistrarCreditoVivienda";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<entCreditoVivienda> ListarCreditos()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ListarCreditos";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<entCreditoVivienda>>().Result;
            }
        }

        public string ActualizarEstadoCredito(entCreditoVivienda entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ActualizarEstadoCredito";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PutAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

    }
}