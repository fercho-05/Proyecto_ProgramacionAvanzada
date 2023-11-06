using G4_Proyecto_ProgramacionAvanzada.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace G4_Proyecto_ProgramacionAvanzada.Models
{
    public class modUsuarios
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];

        public entUsuarios IniciarSesion(entUsuarios entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "IniciarSesion";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<entUsuarios>().Result;
            }
        }

        public string IngresarCliente(entUsuarios entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "IngresarCliente";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public string IngresarAdministrador(entUsuarios entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "IngresarCliente";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<SelectListItem> ListarTipoUsuarios() {

            using (var client = new HttpClient())
            {
                string url = urlApi + "ListarTipoUsuarios";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;


            }

        }

    }
}