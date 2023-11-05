using G4_Proyecto_ProgramacionAvanzada.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace G4_Proyecto_ProgramacionAvanzada.Models
{
    public class UsuarioModel
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
    }
}