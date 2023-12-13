using APICloudCash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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



        [HttpPost]
        [Route("CambiarContrasena")]
        public string CambiarContrasena(entUsuarios usuario)
        {
            try
            {
                using (var context = new DBCC())
                {
                    var datosBase = context.Usuarios
                                          .Where(u => u.cedula == usuario.cedula)
                                          .FirstOrDefault();

                    if (datosBase != null)
                    {
                        if (usuario.contrasena == datosBase.contrasena)
                        {
                            datosBase.contrasena = usuario.nuevaContrasena;
                            context.SaveChanges();
                            return "Actualizada exitosamente";
                        }
                        else
                        {
                            return "Contraseña actual incorrecta";
                        }                       
                    }
                    else
                    {
                        return "Usuario no encontrado";
                    }
                }
            }
            catch (Exception e)
            {
                // Loguea el error para depuración
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);
                return "Error: " + e.Message;
            }
        }

        [HttpPost]
        [Route("CambiarUsuario")]
        public string CambiarUsuario(entUsuarios usuario)
        {
            try
            {
                using (var context = new DBCC())
                {
                    var datosBase = context.Usuarios
                                          .Where(u => u.cedula == usuario.cedula)
                                          .FirstOrDefault();

                    if (datosBase != null)
                    {
                        if (usuario.contrasena == datosBase.contrasena)
                        {
                            datosBase.nombreUsuario = usuario.nuevoUsuario;
                            context.SaveChanges();
                            return "Actualizado exitosamente";
                        }
                        else
                        {
                            return "Contraseña actual incorrecta";
                        }
                    }
                    else
                    {
                        return "Usuario no encontrado";
                    }
                }
            }
            catch (Exception e)
            {
                // Loguea el error para depuración
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);
                return "Error: " + e.Message;
            }
        }

        [HttpPost]
        [Route("CambiarTelefono")]
        public string CambiarTelefono(entUsuarios usuario)
        {
            try
            {
                using (var context = new DBCC())
                {
                    var datosBase = context.Usuarios
                                          .Where(u => u.cedula == usuario.cedula)
                                          .FirstOrDefault();

                    if (datosBase != null)
                    {
                        if (usuario.contrasena == datosBase.contrasena)
                        {
                            datosBase.telefono = usuario.nuevoTelefono;
                            context.SaveChanges();
                            return "Actualizado exitosamente";
                        }
                        else
                        {
                            return "Contraseña actual incorrecta";
                        }
                    }
                    else
                    {
                        return "Usuario no encontrado";
                    }
                }
            }
            catch (Exception e)
            {
                // Loguea el error para depuración
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);
                return "Error: " + e.Message;
            }
        }

        [HttpPost]
        [Route("CambiarCorreo")]
        public string CambiarCorreo(entUsuarios usuario)
        {
            try
            {
                using (var context = new DBCC())
                {
                    var datosBase = context.Usuarios
                                          .Where(u => u.cedula == usuario.cedula)
                                          .FirstOrDefault();

                    if (datosBase != null)
                    {
                        if (usuario.contrasena == datosBase.contrasena)
                        {
                            datosBase.correo = usuario.nuevoCorreo;
                            context.SaveChanges();
                            return "Actualizado exitosamente";
                        }
                        else
                        {
                            return "Contraseña actual incorrecta";
                        }
                    }
                    else
                    {
                        return "Usuario no encontrado";
                    }
                }
            }
            catch (Exception e)
            {
                // Loguea el error para depuración
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);
                return "Error: " + e.Message;
            }
        }

        [HttpGet]
        [Route("ListarCuentasPorCedula")]
        public List<entCuentas> ListarCuentas(string cedula)
        {
            try
            {
                using (var context = new DBCC())
                {

                    var idUsuario = context.Usuarios
                                          .Where(u => u.cedula == cedula)
                                          .Select(u => u.id_Usuario)
                                          .FirstOrDefault();
                    var idCliente = context.Clientes
                                          .Where(u => u.id_Usuario == idUsuario)
                                          .Select(u => u.id_Cliente)
                                          .FirstOrDefault();
                    if (idCliente != 0)
                    {        
                        var cuentas = context.Cuentas
                                                  .Where(t => t.id_Cliente == idCliente)
                                                  .ToList();
                        var entCuentas = cuentas.Select(t => new entCuentas
                        {
                            id_Cuenta = t.id_Cuenta,
                            id_Cliente = t.id_Cliente,
                            id_TipoCuenta = t.id_TipoCuenta,
                            saldo = t.saldo,
                            id_TipoDivisa = t.id_TipoDivisa,
                            activa = t.activa,
                            numeroCuenta = t.numeroCuenta
                        }).ToList();

                        return entCuentas;

                    }
                }

                return null;
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return new List<entCuentas>();
            }
        }

        [HttpGet]
        [Route("ListarCuentasPorCed")]
        public List<System.Web.Mvc.SelectListItem> ListarCuentasPorCed(string cedula)
        {
            try
            {

                using (var context = new DBCC())
                {
                    var idUsuario = context.Usuarios
                                              .Where(u => u.cedula == cedula)
                                              .Select(u => u.id_Usuario)
                                              .FirstOrDefault();
                    var idCliente = context.Clientes
                                          .Where(u => u.id_Usuario == idUsuario)
                                          .Select(u => u.id_Cliente)
                                          .FirstOrDefault();
                    if (idCliente != 0)
                    {
                        var cuentas = context.Cuentas
                                                  .Where(t => t.id_Cliente == idCliente)
                                                  .ToList();

                        var combo = new List<System.Web.Mvc.SelectListItem>();
                        foreach (var item in cuentas)
                            {
                                combo.Add(new System.Web.Mvc.SelectListItem
                                {
                                    Value = item.id_Cuenta.ToString(),
                                    Text = item.numeroCuenta.ToString()
                                });
                            }

                        return combo;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return null;
            }
        }

        [HttpPost]
        [Route("EnviarDinero")]
        public string EnviarDinero(entEnvioDinero envioDinero)
        {
            try
            {
                using (var context = new DBCC())
                {
                    var cuentaOrigen = context.Cuentas
                                          .Where(u => u.id_Cuenta == envioDinero.id_Cuenta)
                                          .FirstOrDefault();

                    if (cuentaOrigen != null)
                    {
                        if (cuentaOrigen.saldo >= envioDinero.monto)
                        {
                            var nuevoEnvio = new EnvioDinero();
                            nuevoEnvio.id_Cuenta = envioDinero.id_Cuenta;
                            nuevoEnvio.nombreReceptor = envioDinero.nombreReceptor;
                            nuevoEnvio.numeroCuentaReceptor = envioDinero.numeroCuentaReceptor;
                            nuevoEnvio.monto = envioDinero.monto;
                            nuevoEnvio.asunto = envioDinero.asunto;

                            context.EnvioDinero.Add(nuevoEnvio);

                            cuentaOrigen.saldo -= envioDinero.monto;

                            context.SaveChanges();

                            return "Transferencia exitosa";
                        }
                        else
                        {
                            return "Fondos insuficientes";
                        }
                    }
                    else
                    {
                        return "Cuenta no encontrada";
                    }
                }
            }
            catch (Exception e)
            {
                // Loguea el error para depuración
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);
                return "Error: " + e.Message;
            }
        }

        [HttpGet]
        [Route("ListarCreditoVivienda")]
        public entCreditoVivienda ListarCreditoVivienda(string cedula)
        {
            try
            {
                using (var context = new DBCC())
                {

                    var idUsuario = context.Usuarios
                                          .Where(u => u.cedula == cedula)
                                          .Select(u => u.id_Usuario)
                                          .FirstOrDefault();
                    var idCliente = context.Clientes
                                          .Where(u => u.id_Usuario == idUsuario)
                                          .Select(u => u.id_Cliente)
                                          .FirstOrDefault();
                    if (idCliente != 0)
                    {
                        var creditoVivienda = context.CreditoVivienda
                                                  .Where(t => t.id_Cliente == idCliente)
                                                  .FirstOrDefault();
                        var creditoEntidad = context.CreditoVivienda
                              .Where(t => t.id_Cliente == idCliente)
                              .Select(c => new entCreditoVivienda
                              {
                                  id_Cliente = c.id_Cliente,
                                  id_CreditoVivienda = c.id_CreditoVivienda,
                                  id_TipoDivisa = c.id_TipoDivisa,
                                  Monto = c.Monto,
                                  PorcentajeInteres = c.PorcentajeInteres,
                                  PlazoAnnios = c.PlazoAnnios,
                                  FechaAprobacion = c.FechaAprobacion
                              })
                              .FirstOrDefault();

                        return creditoEntidad;

                    }
                }

                return null;
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return null;
            }
        }
        [HttpGet]
        [Route("VerEnvios")]
        public List<entEnvioDinero> VerEnvios(string cedula)
        {
            try
            {
                using (var context = new DBCC())
                {
                    var idCliente = context.Usuarios
                                          .Where(u => u.cedula == cedula)
                                          .Join(context.Clientes,
                                                u => u.id_Usuario,
                                                c => c.id_Usuario,
                                                (u, c) => c.id_Cliente)
                                          .FirstOrDefault();

                    if (idCliente != 0)
                    {
                        var envioDinero = context.EnvioDinero
                                                   .Join(context.Cuentas,
                                                         ed => ed.id_Cuenta,
                                                         c => c.id_Cuenta,
                                                         (ed, c) => new { EnvioDinero = ed, Cuenta = c })
                                                   .Where(joinResult => joinResult.Cuenta.id_Cliente == idCliente)
                                                   .Select(joinResult => joinResult.EnvioDinero)
                                                   .ToList();

                        var entEnvioDinero = envioDinero.Select(t => new entEnvioDinero
                        {
                            numeroCuentaReceptor = t.numeroCuentaReceptor,
                            id_Cuenta = t.id_Cuenta,
                            id_EnvioDinero = t.id_EnvioDinero,
                            nombreReceptor = t.nombreReceptor,
                            monto = t.monto,
                            asunto = t.asunto

                        }).ToList();

                        return entEnvioDinero;

                    }
                }

                return null;
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return new List<entEnvioDinero>();
            }
        }


        [HttpPut]
        [Route("AgregarFoto")]
        public string AgregarFoto(entUsuarios usuario)
        {
            try
            {
                using (var context = new DBCC())
                {
                    var datos = (from x in context.Usuarios
                                 where x.id_Usuario == usuario.id_Usuario
                                 select x).FirstOrDefault();

                    if (datos != null)
                    {
                        datos.foto = usuario.foto;
                        context.SaveChanges();
                    }

                    return "OK";
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                ReporteErrores(mensaje);

                return string.Empty;
            }
        }





    }
}