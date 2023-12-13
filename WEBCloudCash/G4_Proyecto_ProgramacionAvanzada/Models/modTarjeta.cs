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
    public class modTarjeta
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];

        public List<entTarjetas> Tarjetas { get; set; } //esto lo utilizaré para guardar la lista de las tarjetas para luego usarla en vista de tarjetas

        public List<entTarjetas> ListarTarjetasPorCedula(string cedula)
        {
            Tarjetas = new List<entTarjetas>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}ListarTarjetaPorCedula?cedula={cedula}";
                var resp = client.GetAsync(url).Result;
                Tarjetas = resp.Content.ReadFromJsonAsync<List<entTarjetas>>().Result;
                return Tarjetas;
            }
        }
        
        public List<SelectListItem> ListarTipoTarjetas()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ListarTipoTarjetas";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        public List<SelectListItem> ListarMarcasTarjetas()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ListarMarcasTarjetas";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        public List<SelectListItem> ListarTipoDivisas()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ListarTipoDivisas";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }
        
        public string IngresarTarjetaDebito(entTarjetas entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "IngresarTarjetaDebito";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public string IngresarTarjetaCredito(entTarjetas entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "IngresarTarjetaCredito";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<entTarjetas> ListarTarjetas()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ListarTarjetas";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<entTarjetas>>().Result;
            }
        }

        public string ActualizarEstadoTarjeta(entTarjetas entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ActualizarEstadoTarjeta";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PutAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }



    }
}