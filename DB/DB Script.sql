USE [UnlaDespegar]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vuelo]') AND type in (N'U'))
ALTER TABLE [dbo].[Vuelo] DROP CONSTRAINT IF EXISTS [FK_Vuelo_Origen]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vuelo]') AND type in (N'U'))
ALTER TABLE [dbo].[Vuelo] DROP CONSTRAINT IF EXISTS [FK_Vuelo_Destino]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reserva]') AND type in (N'U'))
ALTER TABLE [dbo].[Reserva] DROP CONSTRAINT IF EXISTS [FK_Reserva_Vuelo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reserva]') AND type in (N'U'))
ALTER TABLE [dbo].[Reserva] DROP CONSTRAINT IF EXISTS [FK_Reserva_Usuario]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reserva]') AND type in (N'U'))
ALTER TABLE [dbo].[Reserva] DROP CONSTRAINT IF EXISTS [FK_Reserva_Destino]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pasajero]') AND type in (N'U'))
ALTER TABLE [dbo].[Pasajero] DROP CONSTRAINT IF EXISTS [FK_Pasajero_Reserva]
GO
/****** Object:  Table [dbo].[Vuelo]    Script Date: 1/9/2023 6:56:21 p. m. ******/
DROP TABLE IF EXISTS [dbo].[Vuelo]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 1/9/2023 6:56:21 p. m. ******/
DROP TABLE IF EXISTS [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 1/9/2023 6:56:21 p. m. ******/
DROP TABLE IF EXISTS [dbo].[Reserva]
GO
/****** Object:  Table [dbo].[Pasajero]    Script Date: 1/9/2020 6:56:21 p. m. ******/
DROP TABLE IF EXISTS [dbo].[Pasajero]
GO
/****** Object:  Table [dbo].[Destino]    Script Date: 1/9/2020 6:56:21 p. m. ******/
DROP TABLE IF EXISTS [dbo].[Destino]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[Destino]    Script Date: 5/9/2020 16:19:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destino](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pais] [varchar](50) NOT NULL,
	[region] [varchar](50) NOT NULL,
	[ciudad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Destino] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 5/9/2023 16:19:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nroReserva] [varchar](50) NOT NULL,
	[usuario] [int] NOT NULL,
	[destino] [int] NOT NULL,
	[vuelo] [int] NULL,
	[importe] [numeric](18, 2) NOT NULL,
	[reservaFinalizada] [bit] NOT NULL,
	[fechaEntrada] [datetime] NULL,
	[fechaSalida] [datetime] NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pasajero]    Script Date: 5/9/2023 16:19:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pasajero](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dni] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[nacionalidad] [varchar](50) NOT NULL,
	[domicilio] [varchar](50) NOT NULL,
	[mail] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[reserva] [int] NOT NULL,
 CONSTRAINT [PK_Pasajero] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/9/2023 16:19:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dni] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[nacionalidad] [varchar](50) NOT NULL,
	[domicilio] [varchar](50) NOT NULL,
	[mail] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[contraseña] [varchar](50) NOT NULL,
	[isAdmin] [bit] NOT NULL,
 CONSTRAINT [PK__Usuario__C0308574275D52DE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelo]    Script Date: 5/9/2023 16:19:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vuelo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fechaIda] [datetime] NOT NULL,
	[fechaVuelta] [datetime] NOT NULL,
	[nombreAereolinea] [varchar](50) NOT NULL,
	[link] [varchar](max) NULL,
	[origen] [int] NOT NULL,
	[destino] [int] NOT NULL,
	[idaVuelta] [bit] NOT NULL,
	[valoracionAereolinea] [int] NULL,
	[clase] [varchar](20) NOT NULL,
	[conEscala] [bit] NOT NULL,
	[accesoDiscapacitados] [bit] NOT NULL,
	[precio] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Vuelo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Destino] ON 

INSERT [dbo].[Destino] ([id], [pais], [region], [ciudad]) VALUES (1, N'Argentina', N'Cordoba', N'Cordoba')
INSERT [dbo].[Destino] ([id], [pais], [region], [ciudad]) VALUES (2, N'Argentina', N'Santa Cruz', N'El Calafate')
INSERT [dbo].[Destino] ([id], [pais], [region], [ciudad]) VALUES (3, N'Argentina', N'Misiones', N'Puerto Iguazú')
INSERT [dbo].[Destino] ([id], [pais], [region], [ciudad]) VALUES (4, N'Argentina', N'Buenos Aires', N'C.A.B.A.')
INSERT [dbo].[Destino] ([id], [pais], [region], [ciudad]) VALUES (5, N'Argentina', N'Rio Negro', N'Bariloche')
INSERT [dbo].[Destino] ([id], [pais], [region], [ciudad]) VALUES (6, N'Argentina', N'Salta', N'Salta')
INSERT [dbo].[Destino] ([id], [pais], [region], [ciudad]) VALUES (7, N'Uruguay', N'Montevideo', N'Montevideo')
INSERT [dbo].[Destino] ([id], [pais], [region], [ciudad]) VALUES (8, N'Brasil', N'Rio de Janeiro', N'Rio de Janeiro')
SET IDENTITY_INSERT [dbo].[Destino] OFF
GO
SET IDENTITY_INSERT [dbo].[Reserva] ON 

INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [vuelo], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (1, N'1000', 1, 1, null, 0, 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [vuelo], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (2, N'1001', 2, 2, null, 0, 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [vuelo], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (3, N'1002', 3, 3, null, 0, 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [vuelo], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (4, N'1003', 4, 4, null, 0, 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [vuelo], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (5, N'1004', 5, 5, null, 0, 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [vuelo], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (6, N'1005', 6, 3, null, 0, 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [vuelo], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (7, N'1006', 7, 5, 6, 0, 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [vuelo], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (8, N'1007', 7, 4, 9, 0, 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [vuelo], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (9, N'1008', 1, 1, 1, 0, 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Reserva] OFF
GO
SET IDENTITY_INSERT [dbo].[Pasajero] ON 

INSERT [dbo].[Pasajero] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [reserva]) VALUES (1, 10000001, N'Martin', N'Agostino', N'Argentino', N'H. Yrigoyen', N'martinagostino75@yahoo.com.ar', N'14532532', 5)
INSERT [dbo].[Pasajero] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [reserva]) VALUES (2, 10000002, N'Luciano', N'Otegui', N'Argentino', N'Galbán', N'luchootegui@gmail.com', N'33236334', 5)
INSERT [dbo].[Pasajero] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [reserva]) VALUES (3, 10000003, N'Mauro', N'Pereyra', N'Argentino', N'Gabaston', N'mpereyra@andreani.com', N'24243435', 6)
SET IDENTITY_INSERT [dbo].[Pasajero] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (1, 10000001, N'Martin', N'Agostino', N'Argentino', N'H. Yrigoyen', N'martinagostino75@yahoo.com.ar', N'14532532', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (2, 10000002, N'Luciano', N'Otegui', N'Argentino', N'Galbán', N'luchootegui@gmail.com', N'33236334', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (3, 10000003, N'Mauro', N'Pereyra', N'Argentino', N'Gabaston', N'mpereyra@andreani.com', N'24243435', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (4, 10000004, N'Tomas', N'Pereyra', N'Argentino', N'Santamarina', N'tomas.pereyra@gmail.com', N'34245663', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (5, 10000005, N'Gian', N'Nativo', N'Argentino', N'Legarreta', N'giannativo@gmail.com', N'62348742', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (6, 10000006, N'Leo', N'Messi', N'Argentino', N'Barcelona', N'messi10@gmail.com', N'63464774', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (7, 10000007, N'Gonzalo', N'Higuain', N'Argentino', N'Torino', N'higuain9@gmail.com', N'34674437', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (8, 1, N'UNLATravel', N'Admin', N'Admin', N'Admin', N'admin@unlatravel.com', N'63652534', N'123456', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Vuelo] ON 

INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAereolinea] ,[origen], [destino], [idaVuelta], [valoracionAereolinea], [clase], [conEscala], [accesoDiscapacitados], [precio], [link]) VALUES (1, CAST(N'2021-01-10T06:00:00.000' AS DateTime), CAST(N'2021-01-30T20:00:00.000' AS DateTime), N'Aereolineas Argentinas',4, 1, 1, 4, N'Ejecutivo', 1, 1, 9000, N'https://www.aerolineas.com.ar/images/flota/boeing.jpg')
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAereolinea] ,[origen], [destino], [idaVuelta], [valoracionAereolinea], [clase], [conEscala], [accesoDiscapacitados], [precio], [link]) VALUES (2, CAST(N'2021-01-11T07:00:00.000' AS DateTime), CAST(N'2021-01-31T15:00:00.000' AS DateTime), N'FlyBondi',4, 2, 0, 5, N'Economica', 1, 1, 3000, N'https://miequipajedemano.com/wp-content/uploads/2018/10/equipaje-permitido-en-flybondi.jpg')
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAereolinea] ,[origen], [destino], [idaVuelta], [valoracionAereolinea], [clase], [conEscala], [accesoDiscapacitados], [precio], [link]) VALUES (3, CAST(N'2021-01-12T05:00:00.000' AS DateTime), CAST(N'2021-02-01T16:00:00.000' AS DateTime), N'LATAM',2, 5, 1, 3, N'Económica', 0, 1, 6000, N'https://www.latam.com/content/dam/LATAM/latam-marca-unica/USA/latam-flights_1500x500.jpg')
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAereolinea] ,[origen], [destino], [idaVuelta], [valoracionAereolinea], [clase], [conEscala], [accesoDiscapacitados], [precio], [link]) VALUES (4, CAST(N'2021-01-13T07:00:00.000' AS DateTime), CAST(N'2021-02-02T17:00:00.000' AS DateTime), N'Aereolineas Argentinas',2, 6, 1, 4, N'Económica', 1, 1, 8000, N'https://www.aerolineas.com.ar/images/flota/boeing.jpg')
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAereolinea] ,[origen], [destino], [idaVuelta], [valoracionAereolinea], [clase], [conEscala], [accesoDiscapacitados], [precio], [link]) VALUES (5, CAST(N'2021-01-14T08:00:00.000' AS DateTime), CAST(N'2021-02-03T18:00:00.000' AS DateTime), N'Aereolineas Argentinas',1, 3, 0, 4, N'Primera clase', 1, 1, 12000, N'https://www.aerolineas.com.ar/images/flota/boeing.jpg')
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAereolinea] ,[origen], [destino], [idaVuelta], [valoracionAereolinea], [clase], [conEscala], [accesoDiscapacitados], [precio], [link]) VALUES (6, CAST(N'2021-01-15T10:00:00.000' AS DateTime), CAST(N'2021-02-04T11:00:00.000' AS DateTime), N'FlyBondi',2, 5, 1, 5, N'Ejecutivo', 0, 1, 8000, N'https://miequipajedemano.com/wp-content/uploads/2018/10/equipaje-permitido-en-flybondi.jpg')
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAereolinea] ,[origen], [destino], [idaVuelta], [valoracionAereolinea], [clase], [conEscala], [accesoDiscapacitados], [precio], [link]) VALUES (7, CAST(N'2021-01-16T13:00:00.000' AS DateTime), CAST(N'2021-02-05T15:00:00.000' AS DateTime), N'FlyBondi',3, 1, 1, 3, N'Economica', 0, 0, 4000, N'https://miequipajedemano.com/wp-content/uploads/2018/10/equipaje-permitido-en-flybondi.jpg')
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAereolinea] ,[origen], [destino], [idaVuelta], [valoracionAereolinea], [clase], [conEscala], [accesoDiscapacitados], [precio], [link]) VALUES (8, CAST(N'2021-01-17T15:00:00.000' AS DateTime), CAST(N'2021-02-06T23:00:00.000' AS DateTime), N'LATAM',4, 2, 0, 2, N'Económica', 1, 1, 3500, N'https://www.latam.com/content/dam/LATAM/latam-marca-unica/USA/latam-flights_1500x500.jpg')
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAereolinea] ,[origen], [destino], [idaVuelta], [valoracionAereolinea], [clase], [conEscala], [accesoDiscapacitados], [precio], [link]) VALUES (9, CAST(N'2021-01-18T19:00:00.000' AS DateTime), CAST(N'2021-02-07T01:00:00.000' AS DateTime), N'LATAM',3, 4, 1, 5, N'Ejecutivo', 1, 1, 10000, N'https://www.latam.com/content/dam/LATAM/latam-marca-unica/USA/latam-flights_1500x500.jpg')
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAereolinea] ,[origen], [destino], [idaVuelta], [valoracionAereolinea], [clase], [conEscala], [accesoDiscapacitados], [precio], [link]) VALUES (10, CAST(N'2021-02-10T19:00:00.000' AS DateTime), CAST(N'2021-02-25T01:00:00.000' AS DateTime), N'LATAM',4, 8, 1, 5, N'Ejecutivo', 1, 1, 23000, N'https://www.latam.com/content/dam/LATAM/latam-marca-unica/USA/latam-flights_1500x500.jpg')
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAereolinea] ,[origen], [destino], [idaVuelta], [valoracionAereolinea], [clase], [conEscala], [accesoDiscapacitados], [precio], [link]) VALUES (11, CAST(N'2021-02-08T19:00:00.000' AS DateTime), CAST(N'2021-02-22T01:00:00.000' AS DateTime), N'LATAM',1, 8, 1, 5, N'Primera Clase', 1, 1, 32000, N'https://www.latam.com/content/dam/LATAM/latam-marca-unica/USA/latam-flights_1500x500.jpg')
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAereolinea] ,[origen], [destino], [idaVuelta], [valoracionAereolinea], [clase], [conEscala], [accesoDiscapacitados], [precio], [link]) VALUES (12, CAST(N'2021-01-02T10:00:00.000' AS DateTime), CAST(N'2021-01-30T11:00:00.000' AS DateTime), N'FlyBondi',4, 7, 1, 5, N'Economica', 0, 1, 1600, N'https://miequipajedemano.com/wp-content/uploads/2018/10/equipaje-permitido-en-flybondi.jpg')
SET IDENTITY_INSERT [dbo].[Vuelo] OFF
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Destino] FOREIGN KEY([destino])
REFERENCES [dbo].[Destino] ([id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Destino]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Usuario] FOREIGN KEY([usuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Usuario]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Vuelo] FOREIGN KEY([vuelo])
REFERENCES [dbo].[Vuelo] ([id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Vuelo]
GO
ALTER TABLE [dbo].[Pasajero]  WITH CHECK ADD  CONSTRAINT [FK_Pasajero_Reserva] FOREIGN KEY([Reserva])
REFERENCES [dbo].[Reserva] ([id])
GO
ALTER TABLE [dbo].[Pasajero] CHECK CONSTRAINT [FK_Pasajero_Reserva]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Destino] FOREIGN KEY([destino])
REFERENCES [dbo].[Destino] ([id])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_Destino]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Origen] FOREIGN KEY([origen])
REFERENCES [dbo].[Destino] ([id])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_Origen]
GO
