using APICloudCash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web.Http;

namespace APICloudCash.Controllers
{
    public class AdministradorController : ApiController
    {
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
                return e.Message;
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
                        entAdministrador.activo
                        ).FirstOrDefault();

                }
            }
            catch (Exception e) {
                return e.Message;
            }

        }


        [HttpGet]
        [Route("ListarTipoUsuarios")]
        public List<System.Web.Mvc.SelectListItem> ListarTipoUsuarios()
        {
            using (var context = new DBCC()) 
            {
                var datos = (from x in context.TipoUsuarios select x).ToList();//Entity Framework

                var lista = new List<System.Web.Mvc.SelectListItem>();

                foreach (var x in datos) {
                    lista.Add(new System.Web.Mvc.SelectListItem { Value = x.id_TipoUsuario.ToString(), Text = x.descripcion });
                }

                return lista;
                    
            }

        }

        [HttpGet]
        [Route("ListarTipoDivisas")]
        public List<System.Web.Mvc.SelectListItem> ListarTipoDivisas()
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

        

        [HttpGet]
        [Route("ListarClientes")]
        public List<System.Web.Mvc.SelectListItem> ListarClientes()
        {
            try {
                using (var context = new DBCC())
                {

                    var datos = context.SP_ListarClientes().ToList();

                    var lista = new List<System.Web.Mvc.SelectListItem>();

                    foreach (var x in datos)

                     
                    {
                        var nombreCompleto = x.nombre + " " + x.apellidoUno + " " + x.apellidoDos;
                        lista.Add(new System.Web.Mvc.SelectListItem { Value = x.id_Usuario.ToString(), Text = nombreCompleto});
                    }

                    return lista;

                }

            }
            catch (Exception) {
                return null;
            }
        }

        [HttpPost]
        [Route("IngresarTarjetaDebito")]
        public string IngresarTarjetaDebito(entTDebitos entTDebito)
        {

            try
            {
                using (var context = new DBCC())
                {

                    return context.SP_CrearTarjetaDebito( //Procedimiento Almacenado
                        entTDebito.id_Cliente,
                        entTDebito.numeroTarjeta,
                        entTDebito.nombrePoseedor,
                        entTDebito.fechaVencimiento,
                        entTDebito.cvc,
                        entTDebito.saldo,
                        entTDebito.id_TipoDivisa,
                        entTDebito.activa

                        ).FirstOrDefault();//Devuelve el registro
                }

            }
            catch (Exception e)
            {
                return e.Message;
            }


        }

        [HttpPost]
        [Route("IngresarTarjetaCredito")]
        public string IngresarTarjetaCredito(entTDebitos entTCredito)
        {

            /* Solo para cuentas 
            string codigoBanco = "601"; //1) 3dig codigoBanco. 601 por el codigo del curso
            string oficina = "001"; //2) 3dig oficina. 001 = Oficina principal
            string tipoCuenta = "100"; //3) 3dig tipoCuenta. 100 = Corriente representando cuenta corriente. 200= Ahorros(No diseñado) y 300 = Credito
            string moneda = entTCredito.id_TipoDivisa.ToString(); //4) 1dig moneda. 1 = Colones y 2 = Dolares

            Random random = new Random();
            string cuenta = random.Next(1000000).ToString().PadLeft(6,'0');//6dig cuenta. Genera un numero entre 0 y 999999, la convierte en string, finalmente la rellena en el caso que no cumpla con los 6 digitos necesarios
            

            var cuentaCC = codigoBanco + oficina + tipoCuenta+moneda+cuenta;
            */

            Random random = new Random();
            long cuentaTarjetaSinRellenar = (long)(random.NextDouble() * 10000000000000000);//6dig cuenta. Genera un numero entre 0 y 9999 9999 9999 9999,
            string cuenta = cuentaTarjetaSinRellenar.ToString().PadLeft(16, '0');//La convierte en string, finalmente la rellena en el caso que no cumpla con los 6 digitos necesarios









            try
            {
                using (var context = new DBCC())
                {

                    return context.SP_CrearTarjetaDebito( //Procedimiento Almacenado
                        entTCredito.id_Cliente,
                        entTCredito.numeroTarjeta,
                        entTCredito.nombrePoseedor,
                        entTCredito.fechaVencimiento,
                        entTCredito.cvc,
                        entTCredito.saldo,
                        entTCredito.id_TipoDivisa,
                        entTCredito.activa

                        ).FirstOrDefault();//Devuelve el registro
                }

            }
            catch (Exception e)
            {
                return e.Message;
            }


        }


        [HttpGet]
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
            catch (Exception)
            {
                return new List<Usuarios>();
            }
        }

        [HttpGet]
        [Route("ListarTarjetasPorCuentaCC")]
        public List<Tarjetas> ListarTarjetasPorCuentaCC(entTarjetas entTarjeta)
        {
            try
            {
                using (var context = new DBCC())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var datos = (from x in context.Tarjetas
                                 where x.numeroTarjeta == entTarjeta.numeroTarjeta
                                 select x).ToList();

                    return datos;

                }

            }
            catch (Exception)
            {
                return new List<Tarjetas>();
            }
        }


    }
}
