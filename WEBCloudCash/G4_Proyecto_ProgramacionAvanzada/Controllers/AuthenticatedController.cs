using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WEBCloudCash.Models;

namespace WEBCloudCash.Controllers
{
    public class AuthenticatedController : Controller
    {
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
            return View();
        }

        [HttpGet]
        public ActionResult TarjetaDebito()
        {
            string cedula = Session["CedulaUsuario"] as string;
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


    }
}
