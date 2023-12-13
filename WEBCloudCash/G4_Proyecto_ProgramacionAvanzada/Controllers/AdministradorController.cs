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
        modCreditos modCreditos = new modCreditos();
        modCuenta modCuenta = new modCuenta();

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
            long idUsuarioActivo = long.Parse(Session["CodigoUsuario"].ToString());
            var datos = modUsuario.ListarClientesTabla().Where(x => x.id_Usuario != idUsuarioActivo).ToList();
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


        //CREAR PRESTAMOS
        [HttpGet]
        public ActionResult RegistroCredito()
        {
            ViewBag.listaClientes = modUsuario.ListarClientesEleccion();
            ViewBag.listaTipoDivisas = modTarjeta.ListarTipoDivisas();
            return View();
        }

        [HttpPost]
        public ActionResult RegistroCredito(entCreditoVivienda entidad)
        {
            ViewBag.listaClientes = modUsuario.ListarClientesEleccion();
            ViewBag.listaTipoDivisas = modTarjeta.ListarTipoDivisas();

            var resp = modCreditos.RegistrarCreditoVivienda(entidad);

            if (resp == "OK")
            {
                ViewBag.listaClientes = modUsuario.ListarClientesEleccion();
                ViewBag.listaTipoDivisas = modTarjeta.ListarTipoDivisas();

                ViewBag.mensaje = "Crédito creado con éxito";
                return View();

                //return RedirectToAction("ListadoPrestamos", "Administrador");
            }
            else
            { 
                ViewBag.listaClientes = modUsuario.ListarClientesEleccion();
                ViewBag.listaTipoDivisas = modTarjeta.ListarTipoDivisas();

                ViewBag.mensaje = "No se ha creado el crédito";
                return View();
            }
        }

        //PRESTAMOS
        [HttpGet]
        public ActionResult ListadoCreditos()
        {
            var datos = modCreditos.ListarCreditos();
            return View(datos);
        }

        [HttpGet]
        public ActionResult ActualizarEstadoCredito(long q)
        {
            var credito = new entCreditoVivienda();
            credito.id_CreditoVivienda = q;

            var resp = modCreditos.ActualizarEstadoCredito(credito);

            if (resp == "OK")
            {
                return RedirectToAction("ListadoCreditos", "Administrador");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se pudo actualizar el estado del crédito";
                return View();
            }
        }

        //TARJETAS
        [HttpGet]
        public ActionResult ListadoTarjetas()
        {
            var datos = modTarjeta.ListarTarjetas();
            return View(datos);
        }

        [HttpGet]
        public ActionResult ActualizarEstadoTarjeta(long q)
        {
            var tarjeta = new entTarjetas();
            tarjeta.id_Tarjeta = q;

            var resp = modTarjeta.ActualizarEstadoTarjeta(tarjeta);

            if (resp == "OK")
            {
                return RedirectToAction("ListadoTarjetas", "Administrador");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se pudo actualizar el estado de la tarjeta";
                return View();
            }
        }

        //CUENTAS
        [HttpGet]
        public ActionResult RegistroCuentas()
        {
            ViewBag.listaClientes = modUsuario.ListarClientesEleccion();
            ViewBag.listaTipoDivisas = modTarjeta.ListarTipoDivisas();
            ViewBag.listaTipoCuentas = modCuenta.ListarTipoCuentas();
            return View();
        }

        [HttpPost]
        public ActionResult RegistroCuentas(entCuentas entidad)
        {
            ViewBag.listaClientes = modUsuario.ListarClientesEleccion();
            ViewBag.listaTipoDivisas = modTarjeta.ListarTipoDivisas();
            ViewBag.listaTipoCuentas = modCuenta.ListarTipoCuentas();

            var resp = modCuenta.RegistrarCuenta(entidad);

            if (resp == "OK")
            {
                ViewBag.listaClientes = modUsuario.ListarClientesEleccion();
                ViewBag.listaTipoDivisas = modTarjeta.ListarTipoDivisas();
                ViewBag.listaTipoCuentas = modCuenta.ListarTipoCuentas();

                ViewBag.mensaje = "Cuenta creada con éxito";
                return View();

                //return RedirectToAction("ListadoCuentas", "Administrador");
            }
            else
            {
                ViewBag.listaClientes = modUsuario.ListarClientesEleccion();
                ViewBag.listaTipoDivisas = modTarjeta.ListarTipoDivisas();
                ViewBag.listaTipoCuentas = modCuenta.ListarTipoCuentas();

                ViewBag.mensaje = "No se ha creado la cuenta";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ListadoCuentas()
        {
            var datos = modCuenta.ListarCuentas();
            return View(datos);
        }

        [HttpGet]
        public ActionResult ActualizarEstadoCuenta(long q)
        {
            var cuenta = new entCuentas();
            cuenta.id_Cuenta = q;

            var resp = modCuenta.ActualizarEstadoCuenta(cuenta);

            if (resp == "OK")
            {
                return RedirectToAction("ListadoCuentas", "Administrador");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se pudo actualizar el estado de la cuenta";
                return View();
            }
        }
    }
}