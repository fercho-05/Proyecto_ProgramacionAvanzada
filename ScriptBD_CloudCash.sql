USE [master]
GO
/****** Object:  Database [CloudCash]    Script Date: 11/5/2023 12:20:32 AM ******/
CREATE DATABASE [CloudCash]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CloudCash', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CloudCash.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CloudCash_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CloudCash_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CloudCash] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CloudCash].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CloudCash] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CloudCash] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CloudCash] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CloudCash] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CloudCash] SET ARITHABORT OFF 
GO
ALTER DATABASE [CloudCash] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CloudCash] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CloudCash] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CloudCash] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CloudCash] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CloudCash] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CloudCash] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CloudCash] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CloudCash] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CloudCash] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CloudCash] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CloudCash] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CloudCash] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CloudCash] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CloudCash] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CloudCash] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CloudCash] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CloudCash] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CloudCash] SET  MULTI_USER 
GO
ALTER DATABASE [CloudCash] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CloudCash] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CloudCash] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CloudCash] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CloudCash] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CloudCash] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CloudCash] SET QUERY_STORE = ON
GO
ALTER DATABASE [CloudCash] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CloudCash]
GO
/****** Object:  Table [dbo].[Administradores]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administradores](
	[id_Administrador] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Usuario] [bigint] NOT NULL,
 CONSTRAINT [PK_Administradores] PRIMARY KEY CLUSTERED 
(
	[id_Administrador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_Cliente] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Usuario] [bigint] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prestamos]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestamos](
	[id_Prestamo] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Cliente] [bigint] NOT NULL,
	[id_TipoPrestamo] [bigint] NOT NULL,
	[id_tipoDivisa] [int] NOT NULL,
	[monto] [nchar](10) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[tasaInteres] [int] NOT NULL,
 CONSTRAINT [PK_Prestamos] PRIMARY KEY CLUSTERED 
(
	[id_Prestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjetas]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjetas](
	[id_Tarjeta] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Cliente] [bigint] NOT NULL,
	[numeroTarjeta] [int] NOT NULL,
	[nombrePoseedor] [varchar](20) NOT NULL,
	[fechaVencimiento] [date] NOT NULL,
	[cvc] [smallint] NOT NULL,
	[saldo] [bigint] NOT NULL,
	[id_TipoDivisa] [int] NOT NULL,
	[activa] [bit] NOT NULL,
	[id_TipoTarjeta] [int] NOT NULL,
 CONSTRAINT [PK_Tarjetas] PRIMARY KEY CLUSTERED 
(
	[id_Tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TCreditos]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TCreditos](
	[id_Credito] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Tarjeta] [bigint] NOT NULL,
 CONSTRAINT [PK_TCreditos] PRIMARY KEY CLUSTERED 
(
	[id_Credito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TDebitos]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TDebitos](
	[id_Debito] [bigint] NOT NULL,
	[id_Tarjeta] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TDebitos] PRIMARY KEY CLUSTERED 
(
	[id_Debito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDivisas]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDivisas](
	[id_TipoDivisa] [int] IDENTITY(1,1) NOT NULL,
	[Abreviado] [varchar](3) NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TipoDivisa] PRIMARY KEY CLUSTERED 
(
	[id_TipoDivisa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoTarjetas]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoTarjetas](
	[id_TipoTarjeta] [int] NOT NULL,
	[descripcion] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TipoTarjetas] PRIMARY KEY CLUSTERED 
(
	[id_TipoTarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuarios]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuarios](
	[id_TipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TipoUsuarios] PRIMARY KEY CLUSTERED 
(
	[id_TipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_Usuario] [bigint] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](20) NOT NULL,
	[nombreUsuario] [varchar](20) NOT NULL,
	[contrasena] [varchar](20) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellidoUno] [varchar](20) NOT NULL,
	[apellidoDos] [varchar](20) NOT NULL,
	[telefono] [int] NULL,
	[correo] [varchar](50) NOT NULL,
	[fechaRegistro] [datetime] NOT NULL,
	[activo] [bit] NOT NULL,
	[id_TipoUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([id_Cliente], [id_Usuario]) VALUES (1, 3)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
INSERT [dbo].[TipoTarjetas] ([id_TipoTarjeta], [descripcion]) VALUES (1, N'Debito')
INSERT [dbo].[TipoTarjetas] ([id_TipoTarjeta], [descripcion]) VALUES (2, N'Credito')
GO
SET IDENTITY_INSERT [dbo].[TipoUsuarios] ON 

INSERT [dbo].[TipoUsuarios] ([id_TipoUsuario], [descripcion]) VALUES (1, N'Admin')
INSERT [dbo].[TipoUsuarios] ([id_TipoUsuario], [descripcion]) VALUES (2, N'Cliente')
SET IDENTITY_INSERT [dbo].[TipoUsuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([id_Usuario], [cedula], [nombreUsuario], [contrasena], [nombre], [apellidoUno], [apellidoDos], [telefono], [correo], [fechaRegistro], [activo], [id_TipoUsuario]) VALUES (1, N'402410759', N'DarkJard', N'1234', N'Jarod', N'Viquez', N'Salazar', 84806994, N'jviquez10759@ufide.ac.cr', CAST(N'2023-11-02T11:26:11.767' AS DateTime), 1, 1)
INSERT [dbo].[Usuarios] ([id_Usuario], [cedula], [nombreUsuario], [contrasena], [nombre], [apellidoUno], [apellidoDos], [telefono], [correo], [fechaRegistro], [activo], [id_TipoUsuario]) VALUES (2, N'110140246', N'Yesi', N'123456', N'Yesenia', N'Salazar', N'Villegas', 83791664, N'yesi1234@gmail.com', CAST(N'2023-11-02T12:53:32.223' AS DateTime), 1, 2)
INSERT [dbo].[Usuarios] ([id_Usuario], [cedula], [nombreUsuario], [contrasena], [nombre], [apellidoUno], [apellidoDos], [telefono], [correo], [fechaRegistro], [activo], [id_TipoUsuario]) VALUES (3, N'412341234', N'Pedro41234', N'41234', N'Pedro', N'Rodriguez', N'Rodriguez', 88888888, N'pedro123@gmail.com', CAST(N'2023-11-04T00:35:29.600' AS DateTime), 0, 2)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [Uk_numeroTarjeta]    Script Date: 11/5/2023 12:20:33 AM ******/
ALTER TABLE [dbo].[Tarjetas] ADD  CONSTRAINT [Uk_numeroTarjeta] UNIQUE NONCLUSTERED 
(
	[id_Tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [Uk_TipoUsuario_Descripcion]    Script Date: 11/5/2023 12:20:33 AM ******/
ALTER TABLE [dbo].[TipoUsuarios] ADD  CONSTRAINT [Uk_TipoUsuario_Descripcion] UNIQUE NONCLUSTERED 
(
	[id_TipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UK_correo]    Script Date: 11/5/2023 12:20:33 AM ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [UK_correo] UNIQUE NONCLUSTERED 
(
	[id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Usuarios_Cedula]    Script Date: 11/5/2023 12:20:33 AM ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [UK_Usuarios_Cedula] UNIQUE NONCLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Usuarios_nombreUsuario]    Script Date: 11/5/2023 12:20:33 AM ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [UK_Usuarios_nombreUsuario] UNIQUE NONCLUSTERED 
(
	[nombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Administradores]  WITH CHECK ADD  CONSTRAINT [FK_Administradores_idUsuario] FOREIGN KEY([id_Usuario])
REFERENCES [dbo].[Usuarios] ([id_Usuario])
GO
ALTER TABLE [dbo].[Administradores] CHECK CONSTRAINT [FK_Administradores_idUsuario]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_idUsuario] FOREIGN KEY([id_Usuario])
REFERENCES [dbo].[Usuarios] ([id_Usuario])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_idUsuario]
GO
ALTER TABLE [dbo].[Prestamos]  WITH CHECK ADD  CONSTRAINT [FK_Prestamos_Clientes] FOREIGN KEY([id_Cliente])
REFERENCES [dbo].[Clientes] ([id_Cliente])
GO
ALTER TABLE [dbo].[Prestamos] CHECK CONSTRAINT [FK_Prestamos_Clientes]
GO
ALTER TABLE [dbo].[Prestamos]  WITH CHECK ADD  CONSTRAINT [FK_Prestamos_TipoDivisas] FOREIGN KEY([id_tipoDivisa])
REFERENCES [dbo].[TipoDivisas] ([id_TipoDivisa])
GO
ALTER TABLE [dbo].[Prestamos] CHECK CONSTRAINT [FK_Prestamos_TipoDivisas]
GO
ALTER TABLE [dbo].[Tarjetas]  WITH CHECK ADD  CONSTRAINT [FK_Tarjetas_Clientes] FOREIGN KEY([id_Cliente])
REFERENCES [dbo].[Clientes] ([id_Cliente])
GO
ALTER TABLE [dbo].[Tarjetas] CHECK CONSTRAINT [FK_Tarjetas_Clientes]
GO
ALTER TABLE [dbo].[Tarjetas]  WITH CHECK ADD  CONSTRAINT [FK_Tarjetas_TipoDivisas] FOREIGN KEY([id_TipoDivisa])
REFERENCES [dbo].[TipoDivisas] ([id_TipoDivisa])
GO
ALTER TABLE [dbo].[Tarjetas] CHECK CONSTRAINT [FK_Tarjetas_TipoDivisas]
GO
ALTER TABLE [dbo].[Tarjetas]  WITH CHECK ADD  CONSTRAINT [FK_Tarjetas_TipoTarjetas] FOREIGN KEY([id_TipoTarjeta])
REFERENCES [dbo].[TipoTarjetas] ([id_TipoTarjeta])
GO
ALTER TABLE [dbo].[Tarjetas] CHECK CONSTRAINT [FK_Tarjetas_TipoTarjetas]
GO
ALTER TABLE [dbo].[TCreditos]  WITH CHECK ADD  CONSTRAINT [FK_TCreditos_Tarjetas] FOREIGN KEY([id_Tarjeta])
REFERENCES [dbo].[Tarjetas] ([id_Tarjeta])
GO
ALTER TABLE [dbo].[TCreditos] CHECK CONSTRAINT [FK_TCreditos_Tarjetas]
GO
ALTER TABLE [dbo].[TDebitos]  WITH CHECK ADD  CONSTRAINT [FK_TDebitos_Tarjetas] FOREIGN KEY([id_Tarjeta])
REFERENCES [dbo].[Tarjetas] ([id_Tarjeta])
GO
ALTER TABLE [dbo].[TDebitos] CHECK CONSTRAINT [FK_TDebitos_Tarjetas]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_TipoUsuarios] FOREIGN KEY([id_TipoUsuario])
REFERENCES [dbo].[TipoUsuarios] ([id_TipoUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_TipoUsuarios]
GO
/****** Object:  StoredProcedure [dbo].[SP_CrearTarjetaCredito]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CrearTarjetaCredito]
--Variables del Usuario

@id_Cliente bigint
,@numeroTarjeta int
,@nombrePoseedor varchar(20)
,@fechaVencimiento datetime
,@cvc smallint
,@saldo bigint
,@id_TipoDivisa int
,@activa bit


AS
BEGIN
---Variables creadas para validar si esta creado la tarjeta previamente---
DECLARE @numeroTarjetaRegistrado bit;
DECLARE @idTarjeta bigint;


---Validar existencia por cedula---
IF EXISTS(SELECT * FROM Tarjetas T WHERE T.numeroTarjeta=@numeroTarjeta)
	SET @numeroTarjetaRegistrado = 1
	ELSE
	SET @numeroTarjetaRegistrado = 0

	--Hacer insercion---
IF(@numeroTarjetaRegistrado=0)
	BEGIN
	INSERT INTO Tarjetas(id_Cliente,numeroTarjeta,nombrePoseedor,fechaVencimiento,cvc,saldo,id_TipoDivisa,activa,id_TipoTarjeta)
	VALUES(@id_Cliente,@numeroTarjeta,@nombrePoseedor,@fechaVencimiento,@cvc,@saldo,@id_TipoDivisa,@activa,2 )
	
	SET @idTarjeta = (SELECT id_Tarjeta FROM Tarjetas where numeroTarjeta = @numeroTarjeta);

	INSERT INTO TCreditos(id_Tarjeta) values (@idTarjeta);
	
	SELECT 'Registrado con exito' 'Mensaje'
	END

	--En el caso de existencia--
	ELSE 
	SELECT 'Esta Tarjeta ya se encuentra registrada' 'Mensaje'
END 
GO
/****** Object:  StoredProcedure [dbo].[SP_CrearTarjetaDebito]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CrearTarjetaDebito]
--Variables del Usuario

@id_Cliente bigint
,@numeroTarjeta int
,@nombrePoseedor varchar(20)
,@fechaVencimiento datetime
,@cvc smallint
,@saldo bigint
,@id_TipoDivisa int
,@activa bit


AS
BEGIN
---Variables creadas para validar si esta creado la tarjeta previamente---
DECLARE @numeroTarjetaRegistrado bit;
DECLARE @idTarjeta bigint;


---Validar existencia por cedula---
IF EXISTS(SELECT * FROM Tarjetas T WHERE T.numeroTarjeta=@numeroTarjeta)
	SET @numeroTarjetaRegistrado = 1
	ELSE
	SET @numeroTarjetaRegistrado = 0

	--Hacer insercion---
IF(@numeroTarjetaRegistrado=0)
	BEGIN
	INSERT INTO Tarjetas(id_Cliente,numeroTarjeta,nombrePoseedor,fechaVencimiento,cvc,saldo,id_TipoDivisa,activa,id_TipoTarjeta)
	VALUES(@id_Cliente,@numeroTarjeta,@nombrePoseedor,@fechaVencimiento,@cvc,@saldo,@id_TipoDivisa,@activa,1 )
	
	SET @idTarjeta = (SELECT id_Tarjeta FROM Tarjetas where numeroTarjeta = @numeroTarjeta);

	INSERT INTO TDebitos(id_Tarjeta) values (@idTarjeta);
	
	SELECT 'Registrado con exito' 'Mensaje'
	END

	--En el caso de existencia--
	ELSE 
	SELECT 'Esta Tarjeta ya se encuentra registrada' 'Mensaje'
END 
GO
/****** Object:  StoredProcedure [dbo].[SP_IngresarAdministrador]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IngresarAdministrador]
--Variables del Usuario
@cedula VARCHAR(20),
@nombreUsuario VARCHAR(20),
@nombre VARCHAR(20),
@contrasena VARCHAR(20),
@apellidoUno VARCHAR(20),
@apellidoDos VARCHAR(20),
@telefono INT,
@correo VARCHAR(50),

@activo BIT

AS
BEGIN
---Variables creadas para validar si esta creado el usuario previamente---
DECLARE @cedulaRegistrada bit;
DECLARE @nombreUsuarioRegistrado bit;
DECLARE @idUsuario bigint;
DECLARE @fechaRegistro DATETIME;

---Validar existencia por cedula---
IF EXISTS(SELECT * FROM Usuarios U WHERE U.cedula=@cedula)
	SET @cedulaRegistrada = 1
	ELSE
	SET @cedulaRegistrada = 0

---Validar existencia por nombre de usuario---

IF EXISTS(SELECT * FROM Usuarios U WHERE U.nombreUsuario=@nombreUsuario)
	SET @nombreUsuarioRegistrado = 1
	ELSE
	SET @nombreUsuarioRegistrado = 0

	--Hacer insercion---
IF(@cedulaRegistrada=0 AND @nombreUsuarioRegistrado=0)
	BEGIN
	SET @fechaRegistro = CURRENT_TIMESTAMP
	INSERT INTO Usuarios(cedula,nombreUsuario,nombre,contrasena,apellidoUno,apellidoDos,telefono,correo,fechaRegistro,activo,id_TipoUsuario)
	VALUES(@cedula,@nombreUsuario,@nombre,@contrasena,@apellidoUno,@apellidoDos,@telefono,@correo,@fechaRegistro,@activo,1)
	
	set @idUsuario = (SELECT id_usuario FROM Usuarios where nombreUsuario = @nombreUsuario);

	INSERT INTO Administradores(id_Usuario) values (@idUsuario);
	
	SELECT 'Registrado con exito' 'Mensaje'
	END

	--En el caso de existencia--
	ELSE IF(@cedulaRegistrada=1 AND @nombreUsuarioRegistrado=0)
	SELECT 'Esta cedula ya se encuentra registrada' 'Mensaje'
	
	ELSE IF(@cedulaRegistrada=0 AND @nombreUsuarioRegistrado=1)
	SELECT 'Este nombre de usuario ya se encuentra registrado' 'Mensaje'
	
	ELSE
	SELECT 'El nombre de usuario y la cedula ya se encuentran registrados' 'Mensaje'

END 
GO
/****** Object:  StoredProcedure [dbo].[SP_IngresarCliente]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IngresarCliente]
--Variables del Usuario
@cedula VARCHAR(20),
@nombreUsuario VARCHAR(20),
@nombre VARCHAR(20),
@contrasena VARCHAR(20),
@apellidoUno VARCHAR(20),
@apellidoDos VARCHAR(20),
@telefono INT,
@correo VARCHAR(50),
@activo BIT

AS
BEGIN
---Variables creadas para validar si esta creado el usuario previamente---
DECLARE @cedulaRegistrada bit;
DECLARE @nombreUsuarioRegistrado bit;
DECLARE @idUsuario bigint;
DECLARE @fechaRegistro DATETIME;

---Validar existencia por cedula---
IF EXISTS(SELECT * FROM Usuarios U WHERE U.cedula=@cedula)
	SET @cedulaRegistrada = 1
	ELSE
	SET @cedulaRegistrada = 0

---Validar existencia por nombre de usuario---

IF EXISTS(SELECT * FROM Usuarios U WHERE U.nombreUsuario=@nombreUsuario)
	SET @nombreUsuarioRegistrado = 1
	ELSE
	SET @nombreUsuarioRegistrado = 0

	--Hacer insercion---
IF(@cedulaRegistrada=0 AND @nombreUsuarioRegistrado=0)
	BEGIN
	SET @fechaRegistro = CURRENT_TIMESTAMP
	INSERT INTO Usuarios(cedula,nombreUsuario,nombre,contrasena,apellidoUno,apellidoDos,telefono,correo,fechaRegistro,activo,id_TipoUsuario)
	VALUES(@cedula,@nombreUsuario,@nombre,@contrasena,@apellidoUno,@apellidoDos,@telefono,@correo,@fechaRegistro,@activo,2)
	
	set @idUsuario = (SELECT id_usuario FROM Usuarios where nombreUsuario = @nombreUsuario);

	INSERT INTO Clientes(id_Usuario) values (@idUsuario);
	
	SELECT 'Registrado con exito' 'Mensaje'
	END

	--En el caso de existencia--
	ELSE IF(@cedulaRegistrada=1 AND @nombreUsuarioRegistrado=0)
	SELECT 'Esta cedula ya se encuentra registrada' 'Mensaje'
	
	ELSE IF(@cedulaRegistrada=0 AND @nombreUsuarioRegistrado=1)
	SELECT 'Este nombre de usuario ya se encuentra registrado' 'Mensaje'
	
	ELSE
	SELECT 'El nombre de usuario y la cedula ya se encuentran registrados' 'Mensaje'

END 
GO
/****** Object:  StoredProcedure [dbo].[SP_IniciarSesion]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IniciarSesion]
@nombreUsuario varchar(20),
@contrasena varchar(20)
AS
BEGIN 
SELECT * FROM Usuarios u WHERE u.nombreUsuario=@nombreUsuario AND u.contrasena=@contrasena
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarClientes]    Script Date: 11/5/2023 12:20:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ListarClientes]
AS
Begin 
SELECT        id_Usuario, cedula, nombreUsuario, contrasena, nombre, apellidoUno, apellidoDos, telefono, correo, fechaRegistro, activo, id_TipoUsuario
FROM            dbo.Usuarios AS u
WHERE        (id_TipoUsuario = 2)
END
GO
USE [master]
GO
ALTER DATABASE [CloudCash] SET  READ_WRITE 
GO
