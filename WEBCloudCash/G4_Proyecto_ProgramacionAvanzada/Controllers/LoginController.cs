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
                Session["CedulaUsuario"] = resp.cedula;
                Session["userName"] = resp.nombreUsuario;
                Session["NombreUsuario"] = resp.nombre;
                Session["Apellido1Usuario"] = resp.apellidoUno;
                Session["Apellido2Usuario"] = resp.apellidoDos;
                Session["TelefonoUsuario"] = resp.telefono;
                Session["CorreoUsuario"] = resp.correo;
                Session["NombreCompleto"] = resp.nombre +" "+ resp.apellidoUno + " "+ resp.apellidoDos;
                Session["TipoUsuario"] = resp.id_TipoUsuario;

                if (resp.id_TipoUsuario == 2) //Usuario de tipo 2 es un cliente
                {
                    return RedirectToAction("Perfil", "Authenticated");
                }
                else
                {
                    return RedirectToAction("PerfilAdministrador", "Administrador");
                }
                
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