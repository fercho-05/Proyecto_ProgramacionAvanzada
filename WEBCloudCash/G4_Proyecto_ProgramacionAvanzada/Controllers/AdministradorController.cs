using WEBCloudCash.Entities;
using WEBCloudCash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBCloudCash.Controllers
{
    public class AdministradorController : Controller
    {
        modUsuarios modUsuario = new modUsuarios();
        modTarjeta modTarjeta = new modTarjeta();

        [HttpGet]
        public ActionResult PerfilAdministrador()
        {
            return View();
        }

        //REGISTRO DE USUARIOS
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

        //CONSULTA USUARIOS
        [HttpGet]
        public ActionResult ListadoUsuarios()
        {
            var datos = modUsuario.ListarClientesTabla();
            return View(datos);
        }

        //INACTIVAR/ACTIVAR USUARIOS
        [HttpGet]
        public ActionResult ActualizarEstadoUsuario(long q)
        {
            var usuario = new entUsuarios();
            usuario.id_Usuario = q;

            var resp = modUsuario.ActualizarEstadoUsuario(usuario);

            if (resp == "OK")
            {
                return RedirectToAction("ListadoUsuarios", "Administrador");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se pudo actualizar el estado del usuario";
                return View();
            }
        }

        //ACTUALIZAR Y ELIMINAR USUARIOS
        [HttpGet]
        public ActionResult ActualizarUsuario(long q)
        {
            var datos = modUsuario.MostrarUsuario(q);
            return View(datos);
        }

        [HttpPost]
        public ActionResult ActualizarUsuario(entUsuarios usuario)
        {
            var resp = modUsuario.ActualizarUsuario(usuario);

            if (resp == "OK")
            {
                return RedirectToAction("ListadoUsuarios", "Administrador");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se pudo actualizar el usuario";
                return View();
            }
        }
       
        [HttpGet]
        public ActionResult EliminarUsuario(long q)
        {
            modUsuario.EliminarUsuario(q);
            return RedirectToAction("ListadoUsuarios", "Administrador");    
        }



        //REGISTRO DE TARJETAS
        [HttpGet]
        public ActionResult RegistroTarjetas()
        {
            ViewBag.listaTipoTarjetas = modTarjeta.ListarTipoTarjetas();
            ViewBag.listaMarcasTarjetas = modTarjeta.ListarMarcasTarjetas(); 
            ViewBag.listaClientes = modUsuario.ListarClientesEleccion();
            ViewBag.listaTipoDivisas = modTarjeta.ListarTipoDivisas();
            return View();
        }

        [HttpPost]
        public ActionResult RegistroTarjetas(entTarjetas entTarjeta)
        {
            if (entTarjeta.id_TipoTarjeta == 0)
            {
                ViewBag.mensaje = "Seleccione el tipo de tarjeta deseada";
            }else if (entTarjeta.id_MarcaTarjeta == 0)
            {
                ViewBag.mensaje = "Seleccione la marca de tarjeta deseada";
            }
            else if (entTarjeta.id_TipoTarjeta == 1) //Débito
            {
                var resp = modTarjeta.IngresarTarjetaDebito(entTarjeta);
                if (resp == "OK")
                {
                    ViewBag.mensaje = "Tarjeta de débito registrada con éxito";
                }
                else
                {
                    ViewBag.listaTipoUsuarios = modUsuario.ListarTipoUsuarios();
                    if (resp == "ALREADY CREATED")
                    {
                        ViewBag.mensaje = "Esta tarjeta de débito ya se encuentra registrada";
                    }
                }
            }
            else //Crédito
            {
                var resp = modTarjeta.IngresarTarjetaCredito(entTarjeta);
                if (resp == "OK")
                {
                    ViewBag.mensaje = "Tarjeta de crédito registrada con éxito";
                }
                else
                {
                    ViewBag.listaTipoUsuarios = modUsuario.ListarTipoUsuarios();
                    if (resp == "ALREADY CREATED")
                    {
                        ViewBag.mensaje = "Esta tarjeta de crédito ya se encuentra registrada";
                    }
                }
            }
            ViewBag.listaTipoTarjetas = modTarjeta.ListarTipoTarjetas();
            ViewBag.listaMarcasTarjetas = modTarjeta.ListarMarcasTarjetas();
            ViewBag.listaClientes = modUsuario.ListarClientesEleccion();
            ViewBag.listaTipoDivisas = modTarjeta.ListarTipoDivisas();
            return View();
        }
    }
}