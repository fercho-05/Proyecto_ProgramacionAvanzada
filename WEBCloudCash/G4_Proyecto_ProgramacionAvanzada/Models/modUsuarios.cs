using WEBCloudCash.Entities;
using Newtonsoft.Json;
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
                string url = urlApi + "IngresarAdministrador";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<SelectListItem> ListarTipoUsuarios()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ListarTipoUsuarios";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        public string ActualizarEstadoUsuario(entUsuarios entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ActualizarEstadoUsuario";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PutAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public string ActualizarUsuario(entUsuarios entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ActualizarUsuario";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PutAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }
        
        public void EliminarUsuario(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "EliminarUsuario?q=" + q;
                var resp = client.DeleteAsync(url).Result;
            }
        }

        public entUsuarios MostrarUsuario(long q)
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "MostrarUsuario?q=" + q;
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<entUsuarios>().Result;
            }
        }

        public string RecuperarContrasena(entUsuarios entUsuario)
        {

            using (var client = new HttpClient())
            {
                string url = urlApi + "RecuperarContrasena";
                JsonContent contenido = JsonContent.Create(entUsuario);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<SelectListItem> ListarClientesEleccion()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ListarClientesEleccion";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        public List<entUsuarios> ListarClientesTabla()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ListarClientesTabla";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<entUsuarios>>().Result;
            }
        }

        public string cambiarContrasena(entUsuarios usuario)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "CambiarContrasena";
                JsonContent contenido = JsonContent.Create(usuario);
                var resp = client.PostAsync(url, contenido).Result;
                var result = resp.Content.ReadAsStringAsync().Result;
                return result;
            }



        }

        public string cambiarUsuario(entUsuarios usuario)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "CambiarUsuario";
                JsonContent contenido = JsonContent.Create(usuario);
                var resp = client.PostAsync(url, contenido).Result;
                var result = resp.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        public string cambiarTelefono(entUsuarios usuario)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "CambiarTelefono";
                JsonContent contenido = JsonContent.Create(usuario);
                var resp = client.PostAsync(url, contenido).Result;
                var result = resp.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        public string cambiarCorreo(entUsuarios usuario)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "CambiarCorreo";
                JsonContent contenido = JsonContent.Create(usuario);
                var resp = client.PostAsync(url, contenido).Result;
                var result = resp.Content.ReadAsStringAsync().Result;
                return result;
            }
        }
    }
}