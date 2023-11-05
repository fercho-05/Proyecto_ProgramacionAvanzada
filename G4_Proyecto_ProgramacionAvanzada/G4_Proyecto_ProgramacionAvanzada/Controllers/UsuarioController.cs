using G4_Proyecto_ProgramacionAvanzada.Entities;
using G4_Proyecto_ProgramacionAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G4_Proyecto_ProgramacionAvanzada.Controllers
{
    public class UsuarioController : Controller
    {
        //Controller para llamar todo lo relacionado a usuarios(login, cerrar sesion, registro...)
        UsuarioModel usuarioModel = new UsuarioModel();


        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(entUsuarios entidad)
        {
            var resp = usuarioModel.IniciarSesion(entidad);

            if (resp != null)
            {
                Session["CodigoUsuario"] = resp.id_Usuario;
                Session["NombreCompleto"] = resp.nombre +" "+ resp.apellidoUno;
                return RedirectToAction("Index", "Home");
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
        public ActionResult RegistroUsuarios()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistroUsuarios(entUsuarios entidad)
        {
            var resp = usuarioModel.IngresarCliente(entidad);

            if (resp == "OK")
            {
                return RedirectToAction("LogIn", "Usuario");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha logrado registrar el cliente.";
                return View();
            }
        }






    }
}