using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBCloudCash.Controllers
{
    public class HomeController : Controller
    {
        //Controller solo para llamar a la página de inicio
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
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
            return View();
        }

        [HttpGet]
        public ActionResult CuentaPlanilla()
        {
            return View();
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
        public ActionResult CreditoVivienda()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Promociones()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EnvioDinero()
        {
            return View();
        }
    }
}
