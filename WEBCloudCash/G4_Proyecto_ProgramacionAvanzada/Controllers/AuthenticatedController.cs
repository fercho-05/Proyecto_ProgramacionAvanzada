using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WEBCloudCash.Entities;
using WEBCloudCash.Models;



namespace WEBCloudCash.Controllers
{
    public class AuthenticatedController : Controller
    {
        modUsuarios modUsuario = new modUsuarios();

        [HttpGet]
        public ActionResult Perfil()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Productos()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EnviarDinero()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PagarServicios()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MiCredito()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TarjetaCredito()
        {
            string cedula = Session["CedulaUsuario"] as string; //aqui es para buscar las tarjetas usando la cedula almacenada en la variable de sesion
            var model = new modTarjeta();
            model.Tarjetas = model.ListarTarjetasPorCedula(cedula);
            return View(model);
        }

        [HttpGet]
        public ActionResult TarjetaDebito()
        {
            string cedula = Session["CedulaUsuario"] as string; //aqui es para buscar las tarjetas usando la cedula almacenada en la variable de sesion
            var model = new modTarjeta();
            model.Tarjetas = model.ListarTarjetasPorCedula(cedula);
            return View(model);
        }

        [HttpGet]
        public ActionResult CuentaAhorro()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CuentaCorriente()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CuentaPlanilla()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CambiarContrasena()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult CambiarContrasena(entUsuarios usuario)
        {
            string respuestaApi = modUsuario.cambiarContrasena(usuario);

            if (respuestaApi?.IndexOf("exitosamente", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                ViewBag.mensaje = respuestaApi;
                return View();
            }
            else
            {
                ViewBag.mensaje = respuestaApi;
                return View();
            }
        
        }

        [HttpGet]
        public ActionResult CambiarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CambiarUsuario(entUsuarios usuario)
        {
            string respuestaApi = modUsuario.cambiarUsuario(usuario);

            if (respuestaApi?.IndexOf("exitosamente", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                ViewBag.mensaje = respuestaApi;
                Session["userName"] = usuario.nuevoUsuario;
                return View();
            }
            else
            {
                ViewBag.mensaje = respuestaApi;
                return View();
            }

        }


        [HttpGet]
        public ActionResult CambiarTelefono()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CambiarTelefono(entUsuarios usuario)
        {
            string respuestaApi = modUsuario.cambiarTelefono(usuario);

            if (respuestaApi?.IndexOf("exitosamente", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                ViewBag.mensaje = respuestaApi;
                Session["TelefonoUsuario"] = usuario.nuevoTelefono;
                return View();
            }
            else
            {
                ViewBag.mensaje = respuestaApi;
                return View();
            }

        }

        [HttpGet]
        public ActionResult CambiarCorreo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CambiarCorreo(entUsuarios usuario)
        {
            string respuestaApi = modUsuario.cambiarCorreo(usuario);

            if (respuestaApi?.IndexOf("exitosamente", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                ViewBag.mensaje = respuestaApi;
                Session["CorreoUsuario"] = usuario.nuevoCorreo;
                return View();
            }
            else
            {
                ViewBag.mensaje = respuestaApi;
                return View();
            }

        }




    }
}
