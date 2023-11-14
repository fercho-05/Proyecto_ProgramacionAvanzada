using WEBCloudCash.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

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



    }
}