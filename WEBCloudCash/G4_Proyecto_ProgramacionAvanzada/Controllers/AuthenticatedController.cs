using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G4_Proyecto_ProgramacionAvanzada.Controllers
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
    }
}
