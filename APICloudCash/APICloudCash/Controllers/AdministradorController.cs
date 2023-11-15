using APICloudCash.Entities;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Contexts;
using System.Web.Http;

namespace APICloudCash.Controllers
{
    public class AdministradorController : ApiController
    {
        //REGISTROS
        [HttpPost]
        [Route("IngresarCliente")]
        public string IngresarCliente(entClientes entCliente) {

            try {
                using (var context = new DBCC())
                {
                    
                return  context.SP_IngresarCliente( //Procedimiento Almacenado
                        entCliente.cedula,
                        entCliente.nombreUsuario,
                        entCliente.nombre,
                        entCliente.contrasena,
                        entCliente.apellidoUno,
                        entCliente.apellidoDos,
                        entCliente.telefono,
                        entCliente.correo,
                        true //Siempre que se crea una cuenta por defecto tiene que quedar activa

                        ).FirstOrDefault();//Devuelve el registro    
                } 
            }catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return string.Empty;
            }
        }

        [HttpPost]
        [Route("IngresarAdministrador")]
        public string IngresarAdministrador(entAdministradores entAdministrador)
        {
            try {
                using (var context = new DBCC())
                {
                    return context.SP_IngresarAdministrador(
                        entAdministrador.cedula,
                        entAdministrador.nombreUsuario,
                        entAdministrador.nombre,
                        entAdministrador.contrasena,
                        entAdministrador.apellidoUno,
                        entAdministrador.apellidoDos,
                        entAdministrador.telefono,
                        entAdministrador.correo,
                        true
                        ).FirstOrDefault();
                }
            }
            catch (Exception e) {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return string.Empty;
            }
        }

        [HttpGet]
        [Route("ListarTipoUsuarios")]
        public List<System.Web.Mvc.SelectListItem> ListarTipoUsuarios()
        {
            try
            {
                using (var context = new DBCC())
                {
                    var datos = (from x in context.TipoUsuarios select x).ToList();//Entity Framework

                    var lista = new List<System.Web.Mvc.SelectListItem>();

                    foreach (var x in datos)
                    {
                        lista.Add(new System.Web.Mvc.SelectListItem { Value = x.id_TipoUsuario.ToString(), Text = x.descripcion });
                    }
                    return lista;
                }
            }
            catch (Exception e) {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return new List<System.Web.Mvc.SelectListItem>();
            }
        }

        [HttpGet]
        [Route("ListarTipoDivisas")]
        public List<System.Web.Mvc.SelectListItem> ListarTipoDivisas()
        {
            try
            {
                using (var context = new DBCC())
                {
                    var datos = (from x in context.TipoDivisas select x).ToList();//Entity Framework

                    var lista = new List<System.Web.Mvc.SelectListItem>();

                    foreach (var x in datos)
                    {
                        lista.Add(new System.Web.Mvc.SelectListItem { Value = x.id_TipoDivisa.ToString(), Text = x.Abreviado });
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return new List<System.Web.Mvc.SelectListItem>();
            }
        }

        [HttpPost]
        [Route("IngresarTarjetaDebito")]
        public string IngresarTarjetaDebito(entTarjetas entTDebito)
        {
            entTDebito.numeroTarjeta = GenerarCuentaNoCreada(entTDebito.id_MarcaTarjeta); //Generar de cuenta Cloud Cash
            entTDebito.cvc = GenerarCVC(); //Generar el codigo CVC
            entTDebito.fechaVencimiento = DateTime.Now.AddYears(4); //Ingresar 4 años a la fecha del registro
            entUsuarios entUsuario = new entUsuarios();
            entUsuario.id_Usuario = entTDebito.id_Cliente;
            var usuario = MostrarUsuario(entUsuario);
            entTDebito.nombrePoseedor = usuario.nombre + " " + usuario.apellidoUno + " " + usuario.apellidoDos;

            try
            {
                using (var context = new DBCC())
                {
                    context.Configuration.LazyLoadingEnabled = false;

                    return context.SP_CrearTarjetaDebito( //Procedimiento Almacenado
                        entTDebito.id_Cliente,
                        entTDebito.numeroTarjeta,
                        entTDebito.nombrePoseedor,
                        entTDebito.fechaVencimiento,
                        entTDebito.cvc,
                        entTDebito.saldo,
                        entTDebito.id_TipoDivisa,
                        entTDebito.id_MarcaTarjeta,
                        true
                        ).FirstOrDefault();//Devuelve el registro
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return string.Empty;
            }
        }

        [HttpPost]
        [Route("IngresarTarjetaCredito")]
        public string IngresarTarjetaCredito(entTarjetas entTCredito)
        {
            entTCredito.numeroTarjeta = GenerarCuentaNoCreada(entTCredito.id_MarcaTarjeta); //Generar de cuenta Cloud Cash
            entTCredito.cvc = GenerarCVC(); //Generar el codigo CVC
            entTCredito.fechaVencimiento = DateTime.Now.AddYears(4); //Ingresar 4 años a la fecha del registro
            entUsuarios entUsuario = new entUsuarios();
            entUsuario.id_Usuario = entTCredito.id_Cliente;
            var usuario = MostrarUsuario(entUsuario);
            entTCredito.nombrePoseedor = usuario.nombre + " " + usuario.apellidoUno + " " + usuario.apellidoDos; 

            try
            {
                using (var context = new DBCC())
                {
                    context.Configuration.LazyLoadingEnabled = false;

                    return context.SP_CrearTarjetaCredito( //Procedimiento Almacenado
                        entTCredito.id_Cliente,
                        entTCredito.numeroTarjeta,
                        entTCredito.nombrePoseedor,
                        entTCredito.fechaVencimiento,
                        entTCredito.cvc,
                        entTCredito.saldo,
                        entTCredito.id_TipoDivisa,
                        entTCredito.id_MarcaTarjeta,
                        true
                        ).FirstOrDefault();//Devuelve el registro
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return string.Empty;
            }
        }

        [HttpGet]
        [Route("ListarTipoTarjetas")]
        public List<System.Web.Mvc.SelectListItem> ListarTipoTarjetas()
        {
            try
            {
                using (var context = new DBCC())
                {
                    var datos = (from x in context.TipoTarjetas select x).ToList();//Entity Framework

                    var lista = new List<System.Web.Mvc.SelectListItem>();

                    foreach (var x in datos)
                    {
                        lista.Add(new System.Web.Mvc.SelectListItem { Value = x.id_TipoTarjeta.ToString(), Text = x.descripcion });
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return new List<System.Web.Mvc.SelectListItem>();
            }
        }

        [HttpGet]
        [Route("ListarMarcasTarjetas")]
        public List<System.Web.Mvc.SelectListItem> ListarMarcasTarjetas()
        {
            try
            {
                using (var context = new DBCC())
                {
                    var datos = (from x in context.MarcasTarjetas select x).ToList();//Entity Framework

                    var lista = new List<System.Web.Mvc.SelectListItem>();

                    foreach (var x in datos)
                    {
                        lista.Add(new System.Web.Mvc.SelectListItem { Value = x.id_MarcaTarjeta.ToString(), Text = x.descripcion });
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return new List<System.Web.Mvc.SelectListItem>();
            }
        }


        //LISTADOS
        [HttpGet]
        [Route("ListarClientesEleccion")]
        public List<System.Web.Mvc.SelectListItem> ListarClientesEleccion()
        {
            try
            {
                using (var context = new DBCC())
                {
                    var datos = context.SP_ListarClientes().ToList();

                    var lista = new List<System.Web.Mvc.SelectListItem>();

                    foreach (var x in datos)
                    {
                        string nombreCompleto = x.nombre + " " + x.apellidoUno + " " + x.apellidoDos;
                        lista.Add(new System.Web.Mvc.SelectListItem { Value = x.id_Usuario.ToString(), Text = nombreCompleto });
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return new List<System.Web.Mvc.SelectListItem>();
            }
        }

        [HttpGet]
        [Route("ListarClientesTabla")]
        public List<Usuarios> ListarClientesTabla()
        {
            try
            {
                using (var context = new DBCC())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return (from x in context.Usuarios
                            select x).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Usuarios>();
            }
        }

        [HttpGet]//Hacer un buscador
        [Route("ListarUsuariosPorCedula")]
        public List<Usuarios> ListarUsuariosPorCedula(entUsuarios entUsuario)
        {
            try
            {
                using (var context = new DBCC())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var datos = (from x in context.Usuarios
                                 where x.nombre.Contains(entUsuario.cedula)
                                 select x).ToList();

                    return datos;

                }

            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return new List<Usuarios>();
            }
        }

        [HttpGet]
        [Route("MostrarTarjeta")]
        public Tarjetas MostrarTarjeta(entTarjetas entTarjeta)
        {
            try
            {
                using (var context = new DBCC())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var datos = (from x in context.Tarjetas
                                 where x.numeroTarjeta == entTarjeta.numeroTarjeta
                                 select x).FirstOrDefault();

                    return datos;
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return  null;
            }
        }

        [HttpGet]
        [Route("MostrarUsuario")]
        public Usuarios MostrarUsuario(entUsuarios entUsuario) {

            try {
                using (var context = new DBCC())
                {
                    var usuario = (from x in context.Usuarios
                                   where x.id_Usuario == entUsuario.id_Usuario
                                   select x).FirstOrDefault();
                    return usuario;
            }
            }catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return null;
            }
        }


        //GENERACION DE NUMEROS TARJETAS/CUENTAS RANDOM
        Random random = new Random();

        public string GenerarCuentaCC() {
            long cuentaTarjetaSinRellenar = (long)(random.NextDouble() * 1000000000000000);//16dig cuenta. Genera un numero entre 0 y 9999 9999 9999 9999,
            string cuentaCC = cuentaTarjetaSinRellenar.ToString().PadLeft(15, '0');//La convierte en string, finalmente la rellena en el caso que no cumpla con los 6 digitos necesarios
            return cuentaCC;
        }

        public string GenerarCuentaNoCreada(int marcaTarjeta) 
        {
            string marcaTarjetaText = marcaTarjeta.ToString(); //Para conservar el 4 si es visa o 5 mastercard

            var tarjetaCreada = true;
            string cuentaCC="";
            entTCreditos entTCredito = new entTCreditos();
            while (tarjetaCreada == true)
            { //Loop para generar una cuenta que no este creada
                cuentaCC = GenerarCuentaCC();
                entTCredito.numeroTarjeta = cuentaCC;
                var resp = MostrarTarjeta(entTCredito);
                if (resp == null)
                {
                    tarjetaCreada = false;
                }
            }
            cuentaCC = marcaTarjetaText + cuentaCC;
            return cuentaCC;
        }

        public short GenerarCVC()
        {
            long cvcSinRellenar = random.Next(1, 1000);//3dig cvc. Genera un numero entre 1 y 999,
            string cvcRellenado = cvcSinRellenar.ToString("D3");//La convierte en string, finalmente la rellena en el caso que no cumpla con los 3 digitos necesarios
            short cvc = short.Parse(cvcRellenado);
            return cvc;
        }

        //LLENAR TABLA DE ERRORES TRAS CAER EN UN CATCH
        public void ReporteErrores(string mensaje)
        {
            using (var context = new DBCC())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var user = new Errores();

                user.fecha = DateTime.Now;
                user.mensajeError = mensaje;

                context.Errores.Add(user);
                context.SaveChanges();
            }
        }


    }
}
