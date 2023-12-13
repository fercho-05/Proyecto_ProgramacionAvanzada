using WEBCloudCash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WEBCloudCash.Models;



namespace WEBCloudCash.Controllers
{
    public class AuthenticatedController : Controller
    {
        modUsuarios modUsuario = new modUsuarios();
        modCuenta modCuenta = new modCuenta();
        modCreditoVivienda modCreditoVivienda = new modCreditoVivienda();

        [HttpGet]
        public ActionResult Perfil()
        {
            ViewBag.mensaje = TempData["ViewBagMensaje"];
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
            ViewBag.mensaje = TempData["ViewBagMensaje"];
            var cedula = Session["CedulaUsuario"]?.ToString();
            ViewBag.cuentas = modCuenta.ListarCuentasPorCed(cedula);
            return View();
        }

        [HttpGet]
        public ActionResult VerEnvios()
        {
            var cedula = Session["CedulaUsuario"]?.ToString();
            var envios = modCuenta.VerEnvios(cedula);
            return View(envios);
        }

        [HttpPost]
        public ActionResult EnviarDinero(entEnvioDinero envioDinero)
        {
            string respuestaApi = modCuenta.EnviarDinero(envioDinero);
            var cedula = Session["CedulaUsuario"]?.ToString();
            //ViewBag.cuentas = modCuenta.ListarCuentasPorCed(cedula);

            if (respuestaApi?.IndexOf("exitosa", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                ViewBag.mensaje = respuestaApi;
                TempData["ViewBagMensaje"] = ViewBag.mensaje;
                return RedirectToAction("EnviarDinero", "Authenticated");
            }
            else
            {
                ViewBag.mensaje = respuestaApi;

                // Almacena la información en TempData antes de redirigir
                TempData["ViewBagMensaje"] = ViewBag.mensaje;
                return RedirectToAction("EnviarDinero", "Authenticated");
            }
        }

        [HttpGet]
        public ActionResult PagarServicios()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MiCredito()
        {
            string cedula = Session["CedulaUsuario"] as string;
            var model = new modCreditoVivienda();
            model.credito = model.ListarCreditoVivienda(cedula);
            return View(model);
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
            string cedula = Session["CedulaUsuario"] as string; //aqui es para buscar las cuentas usando la cedula almacenada en la variable de sesion
            var model = new modCuenta();
            model.Cuentas = model.ListarCuentasPorCedula(cedula);
            return View(model);
        }

        [HttpGet]
        public ActionResult CuentaCorriente()
        {
            string cedula = Session["CedulaUsuario"] as string; //aqui es para buscar las cuentas usando la cedula almacenada en la variable de sesion
            var model = new modCuenta();
            model.Cuentas = model.ListarCuentasPorCedula(cedula);
            return View(model);
        }

        [HttpGet]
        public ActionResult CuentaPlanilla()
        {
            string cedula = Session["CedulaUsuario"] as string; //aqui es para buscar las cuentas usando la cedula almacenada en la variable de sesion
            var model = new modCuenta();
            model.Cuentas = model.ListarCuentasPorCedula(cedula);
            return View(model);
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
