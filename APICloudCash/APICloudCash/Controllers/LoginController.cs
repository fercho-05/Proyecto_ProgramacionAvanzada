using APICloudCash.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APICloudCash.Controllers
{
    public class LoginController : ApiController
    {

        Utilitario util = new Utilitario();

        [HttpPost]
        [Route("IniciarSesion")]
        public SP_IniciarSesion_Result IniciarSesion(entUsuarios entUsuario) //Se recibe un objeto de tipo Usuario
        {
            try
            {
                using (var context = new DBCC())
                {
                    return context.SP_IniciarSesion(entUsuario.nombreUsuario, entUsuario.contrasena).FirstOrDefault(); //Con SP(Procedimiento Almacenamiento)
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return null;
            }
        }

        [HttpPost]
        [Route("RecuperarContrasena")]
        public string RecuperarContrasena(entUsuarios entUsuario) {
            try
            {
                using (var context = new DBCC())
                {
                    var datos = (from x in context.Usuarios
                                 where x.nombreUsuario == entUsuario.nombreUsuario
                                 select x).FirstOrDefault();

                    if (datos != null)
                    {
                        string urlHtml = AppDomain.CurrentDomain.BaseDirectory + "Templates\\RecuperacionContrasena.html";
                        string html = File.ReadAllText(urlHtml);
                        html = html.Replace("@@Nombre", datos.nombre + " " + datos.apellidoUno + " " + datos.apellidoDos);
                        html = html.Replace("@@Contrasena", datos.contrasena);
                        util.EnvioCorreos(datos.correo, "Recuperar Contraseña", html);
                        return "OK";
                    }
                    else {
                        return "NO DATA";
                    }

                }
                
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return string.Empty;
            }
        }


        //LLENAR TABLA DE ERRORES TRAS CAER EN UN CATCH
        public void ReporteErrores(string mensaje)
        {
            using (var context = new DBCC())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var user = new Errores();

                user.fecha = DateTime.Now;
                user.mensajeError = mensaje;

                context.Errores.Add(user);
                context.SaveChanges();
            }

        }
    }

}
