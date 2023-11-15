﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APICloudCash
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBCC : DbContext
    {
        public DBCC()
            : base("name=DBCC")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administradores> Administradores { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Errores> Errores { get; set; }
        public virtual DbSet<MarcasTarjetas> MarcasTarjetas { get; set; }
        public virtual DbSet<Prestamos> Prestamos { get; set; }
        public virtual DbSet<Tarjetas> Tarjetas { get; set; }
        public virtual DbSet<TCreditos> TCreditos { get; set; }
        public virtual DbSet<TDebitos> TDebitos { get; set; }
        public virtual DbSet<TipoDivisas> TipoDivisas { get; set; }
        public virtual DbSet<TipoTarjetas> TipoTarjetas { get; set; }
        public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    
        public virtual ObjectResult<string> SP_CrearTarjetaCredito(Nullable<long> id_Cliente, string numeroTarjeta, string nombrePoseedor, Nullable<System.DateTime> fechaVencimiento, Nullable<short> cvc, Nullable<long> saldo, Nullable<int> id_TipoDivisa, Nullable<int> id_MarcaTarjeta, Nullable<bool> activa)
        {
            var id_ClienteParameter = id_Cliente.HasValue ?
                new ObjectParameter("id_Cliente", id_Cliente) :
                new ObjectParameter("id_Cliente", typeof(long));
    
            var numeroTarjetaParameter = numeroTarjeta != null ?
                new ObjectParameter("numeroTarjeta", numeroTarjeta) :
                new ObjectParameter("numeroTarjeta", typeof(string));
    
            var nombrePoseedorParameter = nombrePoseedor != null ?
                new ObjectParameter("nombrePoseedor", nombrePoseedor) :
                new ObjectParameter("nombrePoseedor", typeof(string));
    
            var fechaVencimientoParameter = fechaVencimiento.HasValue ?
                new ObjectParameter("fechaVencimiento", fechaVencimiento) :
                new ObjectParameter("fechaVencimiento", typeof(System.DateTime));
    
            var cvcParameter = cvc.HasValue ?
                new ObjectParameter("cvc", cvc) :
                new ObjectParameter("cvc", typeof(short));
    
            var saldoParameter = saldo.HasValue ?
                new ObjectParameter("saldo", saldo) :
                new ObjectParameter("saldo", typeof(long));
    
            var id_TipoDivisaParameter = id_TipoDivisa.HasValue ?
                new ObjectParameter("id_TipoDivisa", id_TipoDivisa) :
                new ObjectParameter("id_TipoDivisa", typeof(int));
    
            var id_MarcaTarjetaParameter = id_MarcaTarjeta.HasValue ?
                new ObjectParameter("id_MarcaTarjeta", id_MarcaTarjeta) :
                new ObjectParameter("id_MarcaTarjeta", typeof(int));
    
            var activaParameter = activa.HasValue ?
                new ObjectParameter("activa", activa) :
                new ObjectParameter("activa", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_CrearTarjetaCredito", id_ClienteParameter, numeroTarjetaParameter, nombrePoseedorParameter, fechaVencimientoParameter, cvcParameter, saldoParameter, id_TipoDivisaParameter, id_MarcaTarjetaParameter, activaParameter);
        }
    
        public virtual ObjectResult<string> SP_CrearTarjetaDebito(Nullable<long> id_Cliente, string numeroTarjeta, string nombrePoseedor, Nullable<System.DateTime> fechaVencimiento, Nullable<short> cvc, Nullable<long> saldo, Nullable<int> id_TipoDivisa, Nullable<int> id_MarcaTarjeta, Nullable<bool> activa)
        {
            var id_ClienteParameter = id_Cliente.HasValue ?
                new ObjectParameter("id_Cliente", id_Cliente) :
                new ObjectParameter("id_Cliente", typeof(long));
    
            var numeroTarjetaParameter = numeroTarjeta != null ?
                new ObjectParameter("numeroTarjeta", numeroTarjeta) :
                new ObjectParameter("numeroTarjeta", typeof(string));
    
            var nombrePoseedorParameter = nombrePoseedor != null ?
                new ObjectParameter("nombrePoseedor", nombrePoseedor) :
                new ObjectParameter("nombrePoseedor", typeof(string));
    
            var fechaVencimientoParameter = fechaVencimiento.HasValue ?
                new ObjectParameter("fechaVencimiento", fechaVencimiento) :
                new ObjectParameter("fechaVencimiento", typeof(System.DateTime));
    
            var cvcParameter = cvc.HasValue ?
                new ObjectParameter("cvc", cvc) :
                new ObjectParameter("cvc", typeof(short));
    
            var saldoParameter = saldo.HasValue ?
                new ObjectParameter("saldo", saldo) :
                new ObjectParameter("saldo", typeof(long));
    
            var id_TipoDivisaParameter = id_TipoDivisa.HasValue ?
                new ObjectParameter("id_TipoDivisa", id_TipoDivisa) :
                new ObjectParameter("id_TipoDivisa", typeof(int));
    
            var id_MarcaTarjetaParameter = id_MarcaTarjeta.HasValue ?
                new ObjectParameter("id_MarcaTarjeta", id_MarcaTarjeta) :
                new ObjectParameter("id_MarcaTarjeta", typeof(int));
    
            var activaParameter = activa.HasValue ?
                new ObjectParameter("activa", activa) :
                new ObjectParameter("activa", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_CrearTarjetaDebito", id_ClienteParameter, numeroTarjetaParameter, nombrePoseedorParameter, fechaVencimientoParameter, cvcParameter, saldoParameter, id_TipoDivisaParameter, id_MarcaTarjetaParameter, activaParameter);
        }
    
        public virtual ObjectResult<string> SP_IngresarAdministrador(string cedula, string nombreUsuario, string nombre, string contrasena, string apellidoUno, string apellidoDos, Nullable<int> telefono, string correo, Nullable<bool> activo)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(string));
    
            var nombreUsuarioParameter = nombreUsuario != null ?
                new ObjectParameter("nombreUsuario", nombreUsuario) :
                new ObjectParameter("nombreUsuario", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("contrasena", contrasena) :
                new ObjectParameter("contrasena", typeof(string));
    
            var apellidoUnoParameter = apellidoUno != null ?
                new ObjectParameter("apellidoUno", apellidoUno) :
                new ObjectParameter("apellidoUno", typeof(string));
    
            var apellidoDosParameter = apellidoDos != null ?
                new ObjectParameter("apellidoDos", apellidoDos) :
                new ObjectParameter("apellidoDos", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(int));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_IngresarAdministrador", cedulaParameter, nombreUsuarioParameter, nombreParameter, contrasenaParameter, apellidoUnoParameter, apellidoDosParameter, telefonoParameter, correoParameter, activoParameter);
        }
    
        public virtual ObjectResult<string> SP_IngresarCliente(string cedula, string nombreUsuario, string nombre, string contrasena, string apellidoUno, string apellidoDos, Nullable<int> telefono, string correo, Nullable<bool> activo)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(string));
    
            var nombreUsuarioParameter = nombreUsuario != null ?
                new ObjectParameter("nombreUsuario", nombreUsuario) :
                new ObjectParameter("nombreUsuario", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("contrasena", contrasena) :
                new ObjectParameter("contrasena", typeof(string));
    
            var apellidoUnoParameter = apellidoUno != null ?
                new ObjectParameter("apellidoUno", apellidoUno) :
                new ObjectParameter("apellidoUno", typeof(string));
    
            var apellidoDosParameter = apellidoDos != null ?
                new ObjectParameter("apellidoDos", apellidoDos) :
                new ObjectParameter("apellidoDos", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(int));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_IngresarCliente", cedulaParameter, nombreUsuarioParameter, nombreParameter, contrasenaParameter, apellidoUnoParameter, apellidoDosParameter, telefonoParameter, correoParameter, activoParameter);
        }
    
        public virtual ObjectResult<SP_IniciarSesion_Result> SP_IniciarSesion(string nombreUsuario, string contrasena)
        {
            var nombreUsuarioParameter = nombreUsuario != null ?
                new ObjectParameter("nombreUsuario", nombreUsuario) :
                new ObjectParameter("nombreUsuario", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("contrasena", contrasena) :
                new ObjectParameter("contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_IniciarSesion_Result>("SP_IniciarSesion", nombreUsuarioParameter, contrasenaParameter);
        }
    
        public virtual ObjectResult<SP_ListarClientes_Result> SP_ListarClientes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ListarClientes_Result>("SP_ListarClientes");
        }
    }
}
