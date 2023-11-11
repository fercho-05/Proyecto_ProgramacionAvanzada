using WEBCloudCash.Entities;
using WEBCloudCash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBCloudCash.Controllers
{
    public class LoginController : Controller
    {
        //Controller para llamar todo lo relacionado a usuarios(login, cerrar sesion, registro...)
        modUsuarios modUsuario = new modUsuarios();


        [HttpGet]
        public ActionResult LogIn()
        {
            ViewBag.IniciarSesion = true;
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(entUsuarios entidad)
        {
            var resp = modUsuario.IniciarSesion(entidad);

            if (resp != null)
            {
                Session["CodigoUsuario"] = resp.id_Usuario;
                Session["NombreCompleto"] = resp.nombre +" "+ resp.apellidoUno + " "+ resp.apellidoDos;
                return RedirectToAction("Perfil", "Authenticated");
            }
            else
            {
                ViewBag.MensajeUsuario = "Compruebe la información de sus credenciales.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult RecuperarContrasena() { 
        
            return View();


        }

        [HttpPost]
        public ActionResult RecuperarContrasena(entUsuarios entUsuario)
        {

            ViewBag.mensaje =  modUsuario.RecuperarContrasena(entUsuario);
            return View();


        }







    }
}