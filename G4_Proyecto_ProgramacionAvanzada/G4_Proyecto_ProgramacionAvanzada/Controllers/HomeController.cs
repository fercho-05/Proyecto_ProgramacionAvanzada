using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G4_Proyecto_ProgramacionAvanzada.Controllers
{
    public class HomeController : Controller
    {
        //Controller solo para llamar a la página de inicio
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}