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

                    return context.SP_IngresarCliente( //Procedimiento Almacenado
                        entCliente.cedula,
                        entCliente.nombreUsuario,
                        entCliente.nombre,
                        entCliente.contrasena,
                        entCliente.apellidoUno,
                        entCliente.apellidoDos,
                        entCliente.telefono,
                        entCliente.correo,
                        entCliente.activo

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
        [Route("ObtenerTipoUsuarios")]
        public List<System.Web.Mvc.SelectListItem> ObtenerTipoUsuarios()
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
        [Route("ObtenerTipoDivisas")]
        public List<System.Web.Mvc.SelectListItem> ObtenerTipoDivisas()
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
        [Route("IngresarTarjetaDebito")]
        public string IngresarTarjetaCredito(entTDebitos entTCredito)
        {

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

    }
}
