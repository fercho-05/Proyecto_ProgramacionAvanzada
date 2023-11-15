using APICloudCash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APICloudCash.Controllers
{
    public class AuthenticatedController : ApiController
    {
        [HttpGet]
        [Route("ListarClientes")]
        public List<System.Web.Mvc.SelectListItem> ListarClientes()
        {
            try
            {
                using (var context = new DBCC())
                {

                    var datos = context.SP_ListarClientes().ToList();

                    var lista = new List<System.Web.Mvc.SelectListItem>();

                    foreach (var x in datos)


                    {
                        var nombreCompleto = x.nombre + " " + x.apellidoUno + " " + x.apellidoDos;
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
        [Route("ListarTarjetaPorCedula")]
        public List<entTarjetas> ListarTarjetas(string cedula)
        {
            try
            {
                using (var context = new DBCC())
                {

                    var idUsuario = context.Usuarios
                                          .Where(u => u.cedula == cedula)
                                          .Select(u => u.id_Usuario)
                                          .FirstOrDefault();
                    if (idUsuario != 0)
                    {

                        var idCliente = context.Clientes
                                               .Where(c => c.id_Usuario == idUsuario)
                                               .Select(c => c.id_Cliente)
                                               .FirstOrDefault();
                        if (idCliente != 0)
                        {
                            var tarjetas = context.Tarjetas
                                                  .Where(t => t.id_Cliente == idCliente)
                                                  .ToList();
                            var entTarjetas = tarjetas.Select(t => new entTarjetas
                            {
                                id_Tarjeta = t.id_Tarjeta,
                                id_Cliente = t.id_Cliente,
                                numeroTarjeta = t.numeroTarjeta,
                                nombrePoseedor = t.nombrePoseedor,
                                fechaVencimiento = t.fechaVencimiento,
                                cvc = (short)t.cvc,
                                saldo = t.saldo,
                                id_TipoDivisa = t.id_TipoDivisa,
                                activa = t.activa,
                                id_TipoTarjeta = t.id_TipoTarjeta
                            }).ToList();

                            return entTarjetas;
                        }
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return new List<entTarjetas>();
            }
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