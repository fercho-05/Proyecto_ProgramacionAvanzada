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

        public List<entEnvioDinero> envios { get; set; }
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
        
        public List<SelectListItem> ListarCuentasPorCed(string cedula)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}ListarCuentasPorCed?cedula={cedula}";
                var resp = client.GetAsync(url).Result;
                if (resp.IsSuccessStatusCode)
                    return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
                else
                    return new List<SelectListItem>();
            }
        }

        public string EnviarDinero(entEnvioDinero envioDinero)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "EnviarDinero";
                JsonContent contenido = JsonContent.Create(envioDinero);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<SelectListItem> ListarTipoCuentas()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ListarTipoCuentas";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        public string RegistrarCuenta(entCuentas entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "RegistrarCuenta";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<entCuentas> ListarCuentas()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ListarCuentas";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<entCuentas>>().Result;
            }
        }

        public string ActualizarEstadoCuenta(entCuentas entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ActualizarEstadoCuenta";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PutAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<entEnvioDinero> VerEnvios(string cedula)
        {      
            envios = new List<entEnvioDinero>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEnvios?cedula={cedula}";
                var resp = client.GetAsync(url).Result;
                envios = resp.Content.ReadFromJsonAsync<List<entEnvioDinero>>().Result;
                return envios;
            }          
        }

    }
}