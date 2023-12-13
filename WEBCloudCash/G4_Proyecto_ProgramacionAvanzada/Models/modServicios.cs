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
    public class modServicios
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];

        public string RegistrarServicio(entServicios entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "RegistrarServicio";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<entServicios> ListarServicios()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ListarServicios";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<entServicios>>().Result;
            }
        }

        public string ActualizarEstadoServicio(entServicios entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ActualizarEstadoServicio";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PutAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

    }
}