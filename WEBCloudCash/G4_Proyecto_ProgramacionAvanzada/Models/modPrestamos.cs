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
    public class modPrestamos
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];

        public List<SelectListItem> ListarTipoPrestamos()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ListarTipoPrestamos";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        public string CrearPrestamo(entPrestamos entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "CrearPrestamo";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }



    }
}