using G4_Proyecto_ProgramacionAvanzada.Entities;
using G4_Proyecto_ProgramacionAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G4_Proyecto_ProgramacionAvanzada.Controllers
{
    public class RegistroController : Controller
    {


        modUsuarios modUsuario = new modUsuarios();

        [HttpGet]
        public ActionResult RegistroUsuarios()
        {
            ViewBag.listaTipoUsuarios = modUsuario.ListarTipoUsuarios();
            return View();
        }

        [HttpPost]
        public ActionResult RegistroUsuarios(entUsuarios entUsuario)
        {
            if (entUsuario.id_TipoUsuario == 0) { 
                ViewBag.mensaje = "Seleccione el tipo de usuario"; 
            }
            else if (entUsuario.id_TipoUsuario == 1)
            {
                var resp =  modUsuario.IngresarAdministrador(entUsuario);
                if (resp == "OK")
                {
                    ViewBag.mensaje = "Usuario Administrador ingresado con exito";
                }
                else
                {
                    ViewBag.listaTipoUsuarios = modUsuario.ListarTipoUsuarios();
                    if (resp == "USUARIO Y CEDULA REPETIDOS")
                    {
                        ViewBag.mensaje = "La cedula y el nombre de usuario ya se encuentra registrado";
                    }
                    else if (resp == "CEDULA REPETIDA")
                    {
                        ViewBag.mensaje = "Esta cedula ya se encuentra registrada";
                    }
                    else if (resp == "USUARIO REPETIDO")
                    {
                        ViewBag.mensaje = "Esta cedula ya se encuentra registrada";
                    }

                }

            }
            else
            {
                var resp = modUsuario.IngresarCliente(entUsuario);
                if (resp == "OK")
                {
                    ViewBag.mensaje = "Usuario Cliente ingresado con exito";
                }
                else
                {
                    ViewBag.listaTipoUsuarios = modUsuario.ListarTipoUsuarios();
                    if (resp == "USUARIO Y CEDULA REPETIDOS")
                    {
                        ViewBag.mensaje = "La cedula y el nombre de usuario ya se encuentra registrado";
                    }
                    else if (resp == "CEDULA REPETIDA")
                    {
                        ViewBag.mensaje = "Esta cedula ya se encuentra registrada";
                    }
                    else if (resp == "USUARIO REPETIDO") {
                        ViewBag.mensaje = "Esta cedula ya se encuentra registrada";
                    }

                }

            }
            ViewBag.listaTipoUsuarios = modUsuario.ListarTipoUsuarios();
            return View();
        }
    }
}