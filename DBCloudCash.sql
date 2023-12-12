/****** Object:  Database [CloudCash]    Script Date: 15/11/2023 15:37:11 ******/
CREATE DATABASE CloudCash
USE CloudCash


/****** Object:  Table [dbo].[Administradores]    Script Date: 15/11/2023 15:37:12 ******/
CREATE TABLE [dbo].[Administradores](
	[id_Administrador] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Usuario] [bigint] NOT NULL,
 CONSTRAINT [PK_Administradores] PRIMARY KEY CLUSTERED 
(
	[id_Administrador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 15/11/2023 15:37:12 ******/
CREATE TABLE [dbo].[Clientes](
	[id_Cliente] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Usuario] [bigint] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Errores]    Script Date: 15/11/2023 15:37:12 ******/
CREATE TABLE [dbo].[Errores](
	[idError] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[mensajeError] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Errores] PRIMARY KEY CLUSTERED 
(
	[idError] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MarcasTarjetas]    Script Date: 15/11/2023 15:37:12 ******/
CREATE TABLE [dbo].[MarcasTarjetas](
	[id_MarcaTarjeta] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MarcasTarjetas] PRIMARY KEY CLUSTERED 
(
	[id_MarcaTarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prestamos]    Script Date: 15/11/2023 15:37:12 ******/
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
/****** Object:  Table [dbo].[Tarjetas]    Script Date: 15/11/2023 15:37:12 ******/
CREATE TABLE [dbo].[Tarjetas](
	[id_Tarjeta] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Cliente] [bigint] NOT NULL,
	[numeroTarjeta] [varchar](16) NOT NULL,
	[nombrePoseedor] [varchar](100) NOT NULL,
	[fechaVencimiento] [date] NOT NULL,
	[cvc] [smallint] NULL,
	[saldo] [bigint] NOT NULL,
	[id_TipoDivisa] [int] NOT NULL,
	[activa] [bit] NOT NULL,
	[id_TipoTarjeta] [int] NOT NULL,
	[id_MarcaTarjeta] [int] NOT NULL,
 CONSTRAINT [PK_Tarjetas] PRIMARY KEY CLUSTERED 
(
	[id_Tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TCreditos]    Script Date: 15/11/2023 15:37:12 ******/
CREATE TABLE [dbo].[TCreditos](
	[id_Credito] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Tarjeta] [bigint] NOT NULL,
 CONSTRAINT [PK_TCreditos] PRIMARY KEY CLUSTERED 
(
	[id_Credito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TDebitos]    Script Date: 15/11/2023 15:37:12 ******/
CREATE TABLE [dbo].[TDebitos](
	[id_Debito] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Tarjeta] [bigint] NOT NULL,
 CONSTRAINT [PK_TDebitos] PRIMARY KEY CLUSTERED 
(
	[id_Debito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDivisas]    Script Date: 15/11/2023 15:37:12 ******/
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
/****** Object:  Table [dbo].[TipoTarjetas]    Script Date: 15/11/2023 15:37:12 ******/
CREATE TABLE [dbo].[TipoTarjetas](
	[id_TipoTarjeta] [int] NOT NULL,
	[descripcion] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TipoTarjetas] PRIMARY KEY CLUSTERED 
(
	[id_TipoTarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuarios]    Script Date: 15/11/2023 15:37:12 ******/
CREATE TABLE [dbo].[TipoUsuarios](
	[id_TipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TipoUsuarios] PRIMARY KEY CLUSTERED 
(
	[id_TipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 15/11/2023 15:37:12 ******/
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

/****** Object:  Table [dbo].[TipoCuentas]    Script Date: 12/12/2023 11:03:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoCuentas](
	[id_TipoCuenta] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TipoCuentas] PRIMARY KEY CLUSTERED 
(
	[id_TipoCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Cuentas]    Script Date: 12/12/2023 11:20:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cuentas](
	[id_Cuenta] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Cliente] [bigint] NOT NULL,
	[id_TipoCuenta] [int] NOT NULL,
	[id_TipoDivisa] [int] NOT NULL,
	[numeroCuenta] [varchar](30) NOT NULL,
	[activa] [bit] NOT NULL,
	[saldo] [bigint] NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[id_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Clientes] FOREIGN KEY([id_Cliente])
REFERENCES [dbo].[Clientes] ([id_Cliente])
GO

ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Clientes]
GO

ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_TipoCuenta] FOREIGN KEY([id_TipoCuenta])
REFERENCES [dbo].[TipoCuentas] ([id_TipoCuenta])
GO

ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_TipoCuenta]
GO

ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_TipoDivisa] FOREIGN KEY([id_TipoDivisa])
REFERENCES [dbo].[TipoDivisas] ([id_TipoDivisa])
GO

ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_TipoDivisa]
GO

-- 1. CUENTA AHORRO
-- 2. CUENTA CORRIENTE
-- 3. CUENTA PLANILLA


SET IDENTITY_INSERT [dbo].[Administradores] ON 
GO
INSERT [dbo].[Administradores] ([id_Administrador], [id_Usuario]) VALUES (2, 5)
GO
SET IDENTITY_INSERT [dbo].[Administradores] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([id_Cliente], [id_Usuario]) VALUES (1, 1)
GO
INSERT [dbo].[Clientes] ([id_Cliente], [id_Usuario]) VALUES (2, 2)
GO
INSERT [dbo].[Clientes] ([id_Cliente], [id_Usuario]) VALUES (3, 3)
GO
INSERT [dbo].[Clientes] ([id_Cliente], [id_Usuario]) VALUES (4, 6)
GO
INSERT [dbo].[Clientes] ([id_Cliente], [id_Usuario]) VALUES (5, 7)
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Errores] ON 
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (1, CAST(N'2023-11-15T00:37:18.103' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (2, CAST(N'2023-11-15T00:38:02.717' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (3, CAST(N'2023-11-15T00:40:27.380' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (4, CAST(N'2023-11-15T00:48:04.170' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (5, CAST(N'2023-11-15T00:53:43.940' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (6, CAST(N'2023-11-15T00:54:47.770' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (7, CAST(N'2023-11-15T14:28:27.227' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (8, CAST(N'2023-11-15T14:30:23.837' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (9, CAST(N'2023-11-15T14:30:31.470' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (10, CAST(N'2023-11-15T14:32:04.173' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (11, CAST(N'2023-11-15T14:32:32.320' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (12, CAST(N'2023-11-15T14:32:35.367' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (13, CAST(N'2023-11-15T14:32:46.697' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (14, CAST(N'2023-11-15T14:34:56.920' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (15, CAST(N'2023-11-15T14:40:31.180' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (16, CAST(N'2023-11-15T14:43:10.440' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (17, CAST(N'2023-11-15T14:44:04.867' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (18, CAST(N'2023-11-15T14:48:44.263' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (19, CAST(N'2023-11-15T14:57:12.777' AS DateTime), N'An error occurred while executing the command definition. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (20, CAST(N'2023-11-15T15:14:29.803' AS DateTime), N'An error occurred while updating the entries. See the inner exception for details.')
GO
INSERT [dbo].[Errores] ([idError], [fecha], [mensajeError]) VALUES (21, CAST(N'2023-11-15T15:14:43.983' AS DateTime), N'An error occurred while updating the entries. See the inner exception for details.')
GO
SET IDENTITY_INSERT [dbo].[Errores] OFF
GO
INSERT [dbo].[MarcasTarjetas] ([id_MarcaTarjeta], [descripcion]) VALUES (4, N'Visa')
GO
INSERT [dbo].[MarcasTarjetas] ([id_MarcaTarjeta], [descripcion]) VALUES (5, N'Mastercard')
GO
SET IDENTITY_INSERT [dbo].[Tarjetas] ON 
GO
INSERT [dbo].[Tarjetas] ([id_Tarjeta], [id_Cliente], [numeroTarjeta], [nombrePoseedor], [fechaVencimiento], [cvc], [saldo], [id_TipoDivisa], [activa], [id_TipoTarjeta], [id_MarcaTarjeta]) VALUES (59, 2, N'5323626985458483', N'MARIA ALEXANDRA ALPIZAR RODRIGUEZ', CAST(N'2027-11-15' AS Date), 339, 5000, 1, 1, 1, 5)
GO
INSERT [dbo].[Tarjetas] ([id_Tarjeta], [id_Cliente], [numeroTarjeta], [nombrePoseedor], [fechaVencimiento], [cvc], [saldo], [id_TipoDivisa], [activa], [id_TipoTarjeta], [id_MarcaTarjeta]) VALUES (60, 6, N'4067394887128563', N'AILYN DAYANA PEREZ ALPIZAR', CAST(N'2027-11-15' AS Date), 493, 5000, 1, 1, 1, 4)
GO
SET IDENTITY_INSERT [dbo].[Tarjetas] OFF
GO
SET IDENTITY_INSERT [dbo].[TDebitos] ON 
GO
INSERT [dbo].[TDebitos] ([id_Debito], [id_Tarjeta]) VALUES (12, 59)
GO
INSERT [dbo].[TDebitos] ([id_Debito], [id_Tarjeta]) VALUES (13, 60)
GO
SET IDENTITY_INSERT [dbo].[TDebitos] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoDivisas] ON 
GO
INSERT [dbo].[TipoDivisas] ([id_TipoDivisa], [Abreviado], [Descripcion]) VALUES (1, N'Col', N'Colones')
GO
INSERT [dbo].[TipoDivisas] ([id_TipoDivisa], [Abreviado], [Descripcion]) VALUES (2, N'Dol', N'Dolares')
GO
SET IDENTITY_INSERT [dbo].[TipoDivisas] OFF
GO
INSERT [dbo].[TipoTarjetas] ([id_TipoTarjeta], [descripcion]) VALUES (1, N'Débito')
GO
INSERT [dbo].[TipoTarjetas] ([id_TipoTarjeta], [descripcion]) VALUES (2, N'Crédito')
GO
SET IDENTITY_INSERT [dbo].[TipoUsuarios] ON 
GO
INSERT [dbo].[TipoUsuarios] ([id_TipoUsuario], [descripcion]) VALUES (1, N'Admin')
GO
INSERT [dbo].[TipoUsuarios] ([id_TipoUsuario], [descripcion]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[TipoUsuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([id_Usuario], [cedula], [nombreUsuario], [contrasena], [nombre], [apellidoUno], [apellidoDos], [telefono], [correo], [fechaRegistro], [activo], [id_TipoUsuario]) VALUES (1, N'208270445', N'admin', N'admin', N'FERNANDO JOSE', N'PEREZ', N'ALPIZAR', 11111111, N'admin@gmail.com', CAST(N'2023-11-14T14:18:10.170' AS DateTime), 1, 1)
GO
INSERT [dbo].[Usuarios] ([id_Usuario], [cedula], [nombreUsuario], [contrasena], [nombre], [apellidoUno], [apellidoDos], [telefono], [correo], [fechaRegistro], [activo], [id_TipoUsuario]) VALUES (2, N'109670932', N'user', N'user', N'MARIA ALEXANDRA', N'ALPIZAR', N'RODRIGUEZ', 22222222, N'user@gmail.com', CAST(N'2023-11-14T14:18:40.407' AS DateTime), 1, 2)
GO
INSERT [dbo].[Usuarios] ([id_Usuario], [cedula], [nombreUsuario], [contrasena], [nombre], [apellidoUno], [apellidoDos], [telefono], [correo], [fechaRegistro], [activo], [id_TipoUsuario]) VALUES (3, N'204820828', N'admin2', N'admin', N'LUIS FERNANDO', N'PEREZ', N'ARGUEDAS', 11111111, N'admin2@gmail.com', CAST(N'2023-11-14T14:33:45.583' AS DateTime), 1, 2)
GO
INSERT [dbo].[Usuarios] ([id_Usuario], [cedula], [nombreUsuario], [contrasena], [nombre], [apellidoUno], [apellidoDos], [telefono], [correo], [fechaRegistro], [activo], [id_TipoUsuario]) VALUES (5, N'402410759', N'DarkJard', N'1234', N'JAROD SANTIAGO', N'VIQUEZ', N'SALAZAR', 84806994, N'jarod281@hotmail.com', CAST(N'2023-11-15T00:31:46.233' AS DateTime), 1, 1)
GO
INSERT [dbo].[Usuarios] ([id_Usuario], [cedula], [nombreUsuario], [contrasena], [nombre], [apellidoUno], [apellidoDos], [telefono], [correo], [fechaRegistro], [activo], [id_TipoUsuario]) VALUES (6, N'207520939', N'user3', N'user3', N'AILYN DAYANA', N'PEREZ', N'ALPIZAR', 33333333, N'user3@gmail.com', CAST(N'2023-11-15T14:27:07.010' AS DateTime), 1, 2)
GO
INSERT [dbo].[Usuarios] ([id_Usuario], [cedula], [nombreUsuario], [contrasena], [nombre], [apellidoUno], [apellidoDos], [telefono], [correo], [fechaRegistro], [activo], [id_TipoUsuario]) VALUES (7, N'207520935', N'admin3', N'admin3', N'RAQUEL HORTENSIA', N'VEGA', N'BOGANTES', 55555555, N'admin3@gmail.com', CAST(N'2023-11-15T14:27:31.913' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO



/****** Object:  Index [Uk_numeroTarjeta]    Script Date: 15/11/2023 15:37:12 ******/
ALTER TABLE [dbo].[Tarjetas] ADD  CONSTRAINT [Uk_numeroTarjeta] UNIQUE NONCLUSTERED 
(
	[id_Tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [Uk_TipoUsuario_Descripcion]    Script Date: 15/11/2023 15:37:12 ******/
ALTER TABLE [dbo].[TipoUsuarios] ADD  CONSTRAINT [Uk_TipoUsuario_Descripcion] UNIQUE NONCLUSTERED 
(
	[id_TipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UK_correo]    Script Date: 15/11/2023 15:37:12 ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [UK_correo] UNIQUE NONCLUSTERED 
(
	[id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Usuarios_Cedula]    Script Date: 15/11/2023 15:37:12 ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [UK_Usuarios_Cedula] UNIQUE NONCLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Usuarios_nombreUsuario]    Script Date: 15/11/2023 15:37:12 ******/
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
REFERENCES [dbo].[Usuarios] ([id_Usuario])
GO
ALTER TABLE [dbo].[Tarjetas] CHECK CONSTRAINT [FK_Tarjetas_Clientes]
GO
ALTER TABLE [dbo].[Tarjetas]  WITH CHECK ADD  CONSTRAINT [FK_Tarjetas_MarcasTarjetas] FOREIGN KEY([id_MarcaTarjeta])
REFERENCES [dbo].[MarcasTarjetas] ([id_MarcaTarjeta])
GO
ALTER TABLE [dbo].[Tarjetas] CHECK CONSTRAINT [FK_Tarjetas_MarcasTarjetas]
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



/****** Object:  StoredProcedure [dbo].[SP_CrearTarjetaCredito]    Script Date: 15/11/2023 15:37:12 ******/
CREATE PROCEDURE [dbo].[SP_CrearTarjetaCredito]
--Variables del Usuario

@id_Cliente bigint
,@numeroTarjeta varchar(16)
,@nombrePoseedor varchar(100)
,@fechaVencimiento datetime
,@cvc smallint
,@saldo bigint
,@id_TipoDivisa int
,@id_MarcaTarjeta int
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
	INSERT INTO Tarjetas(id_Cliente,numeroTarjeta,nombrePoseedor,fechaVencimiento,cvc,saldo,id_TipoDivisa,activa,id_TipoTarjeta,id_MarcaTarjeta)
	VALUES(@id_Cliente,@numeroTarjeta,@nombrePoseedor,@fechaVencimiento,@cvc,@saldo,@id_TipoDivisa,@activa,2, @id_MarcaTarjeta )
	
	SET @idTarjeta = (SELECT id_Tarjeta FROM Tarjetas where numeroTarjeta = @numeroTarjeta);

	INSERT INTO TCreditos(id_Tarjeta) values (@idTarjeta);
	
	SELECT 'OK' 'Mensaje'
	END

	--En el caso de existencia--
	ELSE 
	SELECT 'ALREADY CREATED' 'Mensaje'
END 

GO
/****** Object:  StoredProcedure [dbo].[SP_CrearTarjetaDebito]    Script Date: 15/11/2023 15:37:12 ******/
CREATE PROCEDURE [dbo].[SP_CrearTarjetaDebito]
--Variables del Usuario

@id_Cliente bigint
,@numeroTarjeta varchar(16)
,@nombrePoseedor varchar(100)
,@fechaVencimiento datetime
,@cvc smallint
,@saldo bigint
,@id_TipoDivisa int
,@id_MarcaTarjeta int
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
	INSERT INTO Tarjetas(id_Cliente,numeroTarjeta,nombrePoseedor,fechaVencimiento,cvc,saldo,id_TipoDivisa,activa,id_TipoTarjeta,id_MarcaTarjeta)
	VALUES(@id_Cliente,@numeroTarjeta,@nombrePoseedor,@fechaVencimiento,@cvc,@saldo,@id_TipoDivisa,@activa,1, @id_MarcaTarjeta )
	
	SET @idTarjeta = (SELECT id_Tarjeta FROM Tarjetas where numeroTarjeta = @numeroTarjeta);

	INSERT INTO TDebitos(id_Tarjeta) values (@idTarjeta);
	
	SELECT 'OK' 'Mensaje'
	END

	--En el caso de existencia--
	ELSE 
	SELECT 'ALREADY CREATED' 'Mensaje'
END 

GO
/****** Object:  StoredProcedure [dbo].[SP_IngresarAdministrador]    Script Date: 15/11/2023 15:37:12 ******/
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
	
	SELECT 'OK' 'Mensaje'
	END

	--En el caso de existencia--
	ELSE IF(@cedulaRegistrada=1 AND @nombreUsuarioRegistrado=0)
	SELECT 'CEDULA REPETIDA' 'Mensaje'
	
	ELSE IF(@cedulaRegistrada=0 AND @nombreUsuarioRegistrado=1)
	SELECT 'USUARIO REPETIDO' 'Mensaje'
	
	ELSE
	SELECT 'USUARIO Y CEDULA REPETIDOS' 'Mensaje'

END 

GO
/****** Object:  StoredProcedure [dbo].[SP_IngresarCliente]    Script Date: 15/11/2023 15:37:12 ******/
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
	
	SELECT 'OK' 'Mensaje'
	END

	--En el caso de existencia--
	ELSE IF(@cedulaRegistrada=1 AND @nombreUsuarioRegistrado=0)
	SELECT 'CEDULA REPETIDA' 'Mensaje'
	
	ELSE IF(@cedulaRegistrada=0 AND @nombreUsuarioRegistrado=1)
	SELECT 'USUARIO REPETIDO' 'Mensaje'
	
	ELSE
	SELECT 'USUARIO Y CEDULA REPETIDOS' 'Mensaje'

END 

GO
/****** Object:  StoredProcedure [dbo].[SP_IniciarSesion]    Script Date: 15/11/2023 15:37:12 ******/
CREATE PROCEDURE [dbo].[SP_IniciarSesion]
@nombreUsuario varchar(20),
@contrasena varchar(20)
AS
BEGIN 
SELECT * FROM Usuarios u WHERE u.nombreUsuario=@nombreUsuario AND u.contrasena=@contrasena
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ListarClientes]    Script Date: 15/11/2023 15:37:12 ******/
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
