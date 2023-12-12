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
    public class modCuenta
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];

        public List<entCuentas> Cuentas { get; set; } //esto lo utilizaré para guardar la lista de las cuentas

        public List<entCuentas> ListarCuentasPorCedula(string cedula)
        {
            Cuentas = new List<entCuentas>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}ListarCuentasPorCedula?cedula={cedula}";
                var resp = client.GetAsync(url).Result;
                Cuentas = resp.Content.ReadFromJsonAsync<List<entCuentas>>().Result;
                return Cuentas;
            }
        }

    }
}