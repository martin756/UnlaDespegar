USE [UnlaDespegar]
GO
/****** Object:  Table [dbo].[Vuelo]    Script Date: 12/10/2023 20:10:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vuelo]') AND type in (N'U'))
DROP TABLE [dbo].[Vuelo]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/10/2023 20:10:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[TipoRegimen]    Script Date: 12/10/2023 20:10:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoRegimen]') AND type in (N'U'))
DROP TABLE [dbo].[TipoRegimen]
GO
/****** Object:  Table [dbo].[TipoAlojamiento]    Script Date: 12/10/2023 20:10:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoAlojamiento]') AND type in (N'U'))
DROP TABLE [dbo].[TipoAlojamiento]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 12/10/2023 20:10:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reserva]') AND type in (N'U'))
DROP TABLE [dbo].[Reserva]
GO
/****** Object:  Table [dbo].[Pasajero]    Script Date: 12/10/2023 20:10:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pasajero]') AND type in (N'U'))
DROP TABLE [dbo].[Pasajero]
GO
/****** Object:  Table [dbo].[Paquete]    Script Date: 12/10/2023 20:10:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Paquete]') AND type in (N'U'))
DROP TABLE [dbo].[Paquete]
GO
/****** Object:  Table [dbo].[Destino]    Script Date: 12/10/2023 20:10:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Destino]') AND type in (N'U'))
DROP TABLE [dbo].[Destino]
GO
/****** Object:  Table [dbo].[Alojamiento]    Script Date: 12/10/2023 20:10:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Alojamiento]') AND type in (N'U'))
DROP TABLE [dbo].[Alojamiento]
GO
/****** Object:  Table [dbo].[Actividad]    Script Date: 12/10/2023 20:10:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Actividad]') AND type in (N'U'))
DROP TABLE [dbo].[Actividad]
GO
/****** Object:  Table [dbo].[Actividad]    Script Date: 12/10/2023 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fechaDesde] [datetime] NOT NULL,
	[fechaHasta] [datetime] NOT NULL,
	[nombreActividad] [varchar](50) NOT NULL,
	[link] [varchar](max) NULL,
	[descripcion] [varchar](50) NULL,
	[franjaHoraria] [varchar](50) NULL,
	[valoracion] [varchar](50) NULL,
	[accesoDiscapacitados] [bit] NOT NULL,
	[destino] [int] NOT NULL,
	[precio] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Actividad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alojamiento]    Script Date: 12/10/2023 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alojamiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cantidadEstrellas] [int] NULL,
	[nombreAlojamiento] [varchar](50) NOT NULL,
	[link] [varchar](max) NULL,
	[tipoServicio] [varchar](50) NOT NULL,
	[tipoHabitacion] [varchar](50) NOT NULL,
	[accesoDiscapacitados] [bit] NOT NULL,
	[destino] [int] NOT NULL,
	[tipoAlojamiento] [int] NOT NULL,
	[tipoRegimen] [int] NOT NULL,
	[precio] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Alojamiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destino]    Script Date: 12/10/2023 20:10:59 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paquete]    Script Date: 12/10/2023 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paquete](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipoPaquete] [varchar](50) NOT NULL,
	[destino] [int] NOT NULL,
	[fechaIda] [datetime] NOT NULL,
	[fechaVuelta] [datetime] NOT NULL,
	[alojamiento] [int] NOT NULL,
	[vuelo] [int] NOT NULL,
	[actividad] [int] NOT NULL,
	[cantidadPersonas] [int] NOT NULL,
	[habitaciones] [int] NOT NULL,
	[accesoDiscapacitados] [bit] NOT NULL,
	[precio] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Paquete] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pasajero]    Script Date: 12/10/2023 20:10:59 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 12/10/2023 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nroReserva] [varchar](50) NOT NULL,
	[usuario] [int] NOT NULL,
	[destino] [int] NOT NULL,
	[alojamiento] [int] NULL,
	[actividad] [int] NULL,
	[vuelo] [int] NULL,
	[esUnPaquete] [bit] NOT NULL,
	[paquete] [int] NULL,
	[importe] [numeric](18, 2) NOT NULL,
	[reservaFinalizada] [bit] NOT NULL,
	[fechaEntrada] [datetime] NULL,
	[fechaSalida] [datetime] NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAlojamiento]    Script Date: 12/10/2023 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAlojamiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TipoAlojamiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoRegimen]    Script Date: 12/10/2023 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoRegimen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TipoRegimen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/10/2023 20:10:59 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelo]    Script Date: 12/10/2023 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vuelo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fechaIda] [datetime] NOT NULL,
	[fechaVuelta] [datetime] NOT NULL,
	[nombreAerolinea] [varchar](50) NOT NULL,
	[link] [varchar](max) NULL,
	[origen] [int] NOT NULL,
	[destino] [int] NOT NULL,
	[idaVuelta] [bit] NOT NULL,
	[valoracionAerolinea] [int] NULL,
	[clase] [varchar](20) NOT NULL,
	[conEscala] [bit] NOT NULL,
	[accesoDiscapacitados] [bit] NOT NULL,
	[precio] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Vuelo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Actividad] ON 

INSERT [dbo].[Actividad] ([id], [fechaDesde], [fechaHasta], [nombreActividad], [link], [descripcion], [franjaHoraria], [valoracion], [accesoDiscapacitados], [destino], [precio]) VALUES (1, CAST(N'2021-01-10T11:00:00.000' AS DateTime), CAST(N'2021-01-10T18:00:00.000' AS DateTime), N'La Cumbrecita', N'https://www.cordobaturismo.gov.ar/wp-content/uploads/2019/05/41982653_1884186558293776_513421000449196032_o.jpg', N'Excursion con traslados incluidos.', N'7 horas', N'4 estrellas', 1, 1, CAST(1000.00 AS Numeric(18, 2)))
INSERT [dbo].[Actividad] ([id], [fechaDesde], [fechaHasta], [nombreActividad], [link], [descripcion], [franjaHoraria], [valoracion], [accesoDiscapacitados], [destino], [precio]) VALUES (2, CAST(N'2021-01-11T09:00:00.000' AS DateTime), CAST(N'2021-01-11T17:00:00.000' AS DateTime), N'Glaciar Perito Moreno', N'https://upload.wikimedia.org/wikipedia/commons/5/5c/Perito_Moreno_Glacier_Patagonia_Argentina_Luca_Galuzzi_2005.JPG', N'Excursion con traslados incluidos.', N'8 horas', N'5 estrellas', 1, 2, CAST(7000.00 AS Numeric(18, 2)))
INSERT [dbo].[Actividad] ([id], [fechaDesde], [fechaHasta], [nombreActividad], [link], [descripcion], [franjaHoraria], [valoracion], [accesoDiscapacitados], [destino], [precio]) VALUES (3, CAST(N'2021-01-12T07:00:00.000' AS DateTime), CAST(N'2021-01-12T15:00:00.000' AS DateTime), N'Cataratas del Iguazú', N'https://iguazuargentina.com/uploads/cms_slider/77f7f04071a1b55518ad3b767d4bc747.jpg', N'Excursion con traslado y entrada incluida.', N'8 horas', N'5 estrellas', 1, 3, CAST(1500.00 AS Numeric(18, 2)))
INSERT [dbo].[Actividad] ([id], [fechaDesde], [fechaHasta], [nombreActividad], [link], [descripcion], [franjaHoraria], [valoracion], [accesoDiscapacitados], [destino], [precio]) VALUES (4, CAST(N'2021-01-13T10:00:00.000' AS DateTime), CAST(N'2021-01-13T16:00:00.000' AS DateTime), N'Tour Estadio de Boca Juniors', N'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b1/Alberto_J_Armando.jpg/368px-Alberto_J_Arman', N'Entrada al estadio del club y su museo.', N'6 horas', N'5 estrellas', 1, 4, CAST(500.00 AS Numeric(18, 2)))
INSERT [dbo].[Actividad] ([id], [fechaDesde], [fechaHasta], [nombreActividad], [link], [descripcion], [franjaHoraria], [valoracion], [accesoDiscapacitados], [destino], [precio]) VALUES (5, CAST(N'2021-01-14T09:00:00.000' AS DateTime), CAST(N'2021-01-14T19:00:00.000' AS DateTime), N'San Martin de los Andes', N'https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/SAN_MARTIN_DE_LOS_ANDES_LACAR.JPG/1200px-SAN_MARTIN_DE_LOS_ANDES_LACAR.JPG', N'Excursion con recorrido por el lago.', N'10 horas', N'5 estrellas', 0, 5, CAST(8000.00 AS Numeric(18, 2)))
INSERT [dbo].[Actividad] ([id], [fechaDesde], [fechaHasta], [nombreActividad], [link], [descripcion], [franjaHoraria], [valoracion], [accesoDiscapacitados], [destino], [precio]) VALUES (6, CAST(N'2021-01-15T07:10:00.000' AS DateTime), CAST(N'2021-01-15T19:40:00.000' AS DateTime), N'Bodegas de Cafayate', N'https://www.welcomeargentina.com/paseos/todas_las_hojas/camino-cafayate-1.jpg', N'Excursion que incluye degustacion de vinos.', N'12h 30m', N'4 estrellas', 0, 6, CAST(2500.00 AS Numeric(18, 2)))
INSERT [dbo].[Actividad] ([id], [fechaDesde], [fechaHasta], [nombreActividad], [link], [descripcion], [franjaHoraria], [valoracion], [accesoDiscapacitados], [destino], [precio]) VALUES (7, CAST(N'2021-01-16T07:00:00.000' AS DateTime), CAST(N'2021-01-16T19:00:00.000' AS DateTime), N'Visita Minas de Wanda', N'https://static.turismomisiones.com/25/wanda-1024x1024.jpg', N'Excursion con traslado incluido.', N'4 - 12 horas', N'4 estrellas', 0, 3, CAST(400.00 AS Numeric(18, 2)))
INSERT [dbo].[Actividad] ([id], [fechaDesde], [fechaHasta], [nombreActividad], [link], [descripcion], [franjaHoraria], [valoracion], [accesoDiscapacitados], [destino], [precio]) VALUES (8, CAST(N'2021-01-17T18:00:00.000' AS DateTime), CAST(N'2021-01-17T22:00:00.000' AS DateTime), N'Cerro Catedral', N'https://upload.wikimedia.org/wikipedia/commons/6/68/Basecat.JPG', N'Traslado y entrada al centro de ski.', N'4 horas', N'5 estrellas', 1, 5, CAST(2000.00 AS Numeric(18, 2)))
INSERT [dbo].[Actividad] ([id], [fechaDesde], [fechaHasta], [nombreActividad], [link], [descripcion], [franjaHoraria], [valoracion], [accesoDiscapacitados], [destino], [precio]) VALUES (9, CAST(N'2021-01-18T07:00:00.000' AS DateTime), CAST(N'2021-01-18T17:00:00.000' AS DateTime), N'Visita guiada a Colonia del Sacramento', N'https://i.pinimg.com/736x/04/da/8c/04da8c62f40e4ebf7fe1e2ca8f3c1bc0.jpg', N'Recorrido por el centro historico.', N'4 horas', N'5 estrellas', 1, 7, CAST(5000.00 AS Numeric(18, 2)))
INSERT [dbo].[Actividad] ([id], [fechaDesde], [fechaHasta], [nombreActividad], [link], [descripcion], [franjaHoraria], [valoracion], [accesoDiscapacitados], [destino], [precio]) VALUES (10, CAST(N'2021-02-15T07:00:00.000' AS DateTime), CAST(N'2021-02-15T17:00:00.000' AS DateTime), N'Cristo Redentor', N'https://upload.wikimedia.org/wikipedia/commons/0/0b/Cristo_redentor.jpg', N'Excursion al Cristo con entrada y foto incluida.', N'4 horas', N'5 estrellas', 1, 8, CAST(7000.00 AS Numeric(18, 2)))
INSERT [dbo].[Actividad] ([id], [fechaDesde], [fechaHasta], [nombreActividad], [link], [descripcion], [franjaHoraria], [valoracion], [accesoDiscapacitados], [destino], [precio]) VALUES (11, CAST(N'2021-02-16T07:00:00.000' AS DateTime), CAST(N'2021-02-16T17:00:00.000' AS DateTime), N'Carnaval de Rio', N'https://upload.wikimedia.org/wikipedia/commons/4/4b/Desfile_Portela_2014_%28906185%29.jpg', N'Entrada y traslado al Carnaval.', N'4 horas', N'5 estrellas', 1, 8, CAST(9000.00 AS Numeric(18, 2)))
INSERT [dbo].[Actividad] ([id], [fechaDesde], [fechaHasta], [nombreActividad], [link], [descripcion], [franjaHoraria], [valoracion], [accesoDiscapacitados], [destino], [precio]) VALUES (12, CAST(N'2021-10-12T07:00:00.000' AS DateTime), CAST(N'2021-10-12T17:00:00.000' AS DateTime), N'Oktoberfest Villa General Belgrano', N'https://www.welcomeargentina.com/paseos/fiesta_nacional_cerveza/oktoberfest-fiesta-cerveza-1-.jpg', N'Entrada con 2 cervezas por pasajero.', N'4 horas', N'5 estrellas', 1, 5, CAST(1500.00 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[Actividad] OFF
GO
SET IDENTITY_INSERT [dbo].[Alojamiento] ON 

INSERT [dbo].[Alojamiento] ([id], [cantidadEstrellas], [nombreAlojamiento], [link], [tipoServicio], [tipoHabitacion], [accesoDiscapacitados], [destino], [tipoAlojamiento], [tipoRegimen], [precio]) VALUES (1, 5, N'Llao Llao', NULL, N'Suite', N'Suite', 1, 5, 7, 4, CAST(20000.00 AS Numeric(18, 2)))
INSERT [dbo].[Alojamiento] ([id], [cantidadEstrellas], [nombreAlojamiento], [link], [tipoServicio], [tipoHabitacion], [accesoDiscapacitados], [destino], [tipoAlojamiento], [tipoRegimen], [precio]) VALUES (2, 5, N'Charming Luxury Lodge', N'www.charming-bariloche.com/', N'Suite y Apartamento', N'Suite', 1, 5, 4, 3, CAST(5500.00 AS Numeric(18, 2)))
INSERT [dbo].[Alojamiento] ([id], [cantidadEstrellas], [nombreAlojamiento], [link], [tipoServicio], [tipoHabitacion], [accesoDiscapacitados], [destino], [tipoAlojamiento], [tipoRegimen], [precio]) VALUES (3, 5, N'Santa Monica', NULL, N'Suite', N'Suite', 1, 2, 4, 3, CAST(2500.00 AS Numeric(18, 2)))
INSERT [dbo].[Alojamiento] ([id], [cantidadEstrellas], [nombreAlojamiento], [link], [tipoServicio], [tipoHabitacion], [accesoDiscapacitados], [destino], [tipoAlojamiento], [tipoRegimen], [precio]) VALUES (4, 3, N'Lupama', NULL, N'Suite', N'Suite Nupcial', 1, 2, 8, 3, CAST(6000.00 AS Numeric(18, 2)))
INSERT [dbo].[Alojamiento] ([id], [cantidadEstrellas], [nombreAlojamiento], [link], [tipoServicio], [tipoHabitacion], [accesoDiscapacitados], [destino], [tipoAlojamiento], [tipoRegimen], [precio]) VALUES (5, 4, N'Vain Boutique', NULL, N'Desayuno gratis', N'Suite', 1, 4, 6, 5, CAST(2000.00 AS Numeric(18, 2)))
INSERT [dbo].[Alojamiento] ([id], [cantidadEstrellas], [nombreAlojamiento], [link], [tipoServicio], [tipoHabitacion], [accesoDiscapacitados], [destino], [tipoAlojamiento], [tipoRegimen], [precio]) VALUES (6, 5, N'Loi Suites', NULL, N'Suite', N'Suite', 1, 3, 1, 4, CAST(9000.00 AS Numeric(18, 2)))
INSERT [dbo].[Alojamiento] ([id], [cantidadEstrellas], [nombreAlojamiento], [link], [tipoServicio], [tipoHabitacion], [accesoDiscapacitados], [destino], [tipoAlojamiento], [tipoRegimen], [precio]) VALUES (7, 5, N'Falls Iguazú', NULL, N'Suite', N'Suite', 1, 3, 1, 5, CAST(15000.00 AS Numeric(18, 2)))
INSERT [dbo].[Alojamiento] ([id], [cantidadEstrellas], [nombreAlojamiento], [link], [tipoServicio], [tipoHabitacion], [accesoDiscapacitados], [destino], [tipoAlojamiento], [tipoRegimen], [precio]) VALUES (8, 5, N'Sheraton', NULL, N'Suite', N'Suite', 1, 1, 10, 4, CAST(7000.00 AS Numeric(18, 2)))
INSERT [dbo].[Alojamiento] ([id], [cantidadEstrellas], [nombreAlojamiento], [link], [tipoServicio], [tipoHabitacion], [accesoDiscapacitados], [destino], [tipoAlojamiento], [tipoRegimen], [precio]) VALUES (9, 4, N'Nuquen', NULL, N'Suite', N'Suite', 1, 6, 4, 2, CAST(900.00 AS Numeric(18, 2)))
INSERT [dbo].[Alojamiento] ([id], [cantidadEstrellas], [nombreAlojamiento], [link], [tipoServicio], [tipoHabitacion], [accesoDiscapacitados], [destino], [tipoAlojamiento], [tipoRegimen], [precio]) VALUES (10, 4, N'Montevideo Resort', NULL, N'Suite', N'Suite', 1, 7, 4, 2, CAST(3000.00 AS Numeric(18, 2)))
INSERT [dbo].[Alojamiento] ([id], [cantidadEstrellas], [nombreAlojamiento], [link], [tipoServicio], [tipoHabitacion], [accesoDiscapacitados], [destino], [tipoAlojamiento], [tipoRegimen], [precio]) VALUES (11, 4, N'Ipanema Inn', NULL, N'Suite', N'Suite', 1, 8, 4, 2, CAST(12000.00 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[Alojamiento] OFF
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
SET IDENTITY_INSERT [dbo].[Paquete] ON 

INSERT [dbo].[Paquete] ([id], [tipoPaquete], [destino], [fechaIda], [fechaVuelta], [alojamiento], [vuelo], [actividad], [cantidadPersonas], [habitaciones], [accesoDiscapacitados], [precio]) VALUES (1, N'Circuito', 1, CAST(N'2020-01-10T10:00:00.000' AS DateTime), CAST(N'2020-01-30T11:00:00.000' AS DateTime), 8, 1, 1, 4, 1, 1, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Paquete] ([id], [tipoPaquete], [destino], [fechaIda], [fechaVuelta], [alojamiento], [vuelo], [actividad], [cantidadPersonas], [habitaciones], [accesoDiscapacitados], [precio]) VALUES (2, N'Larga Distancia', 2, CAST(N'2020-01-11T13:00:00.000' AS DateTime), CAST(N'2020-01-31T14:00:00.000' AS DateTime), 3, 2, 2, 10, 3, 0, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Paquete] ([id], [tipoPaquete], [destino], [fechaIda], [fechaVuelta], [alojamiento], [vuelo], [actividad], [cantidadPersonas], [habitaciones], [accesoDiscapacitados], [precio]) VALUES (3, N'Programas de Estancia', 3, CAST(N'2020-01-12T15:00:00.000' AS DateTime), CAST(N'2020-02-01T03:00:00.000' AS DateTime), 7, 3, 3, 5, 2, 0, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Paquete] ([id], [tipoPaquete], [destino], [fechaIda], [fechaVuelta], [alojamiento], [vuelo], [actividad], [cantidadPersonas], [habitaciones], [accesoDiscapacitados], [precio]) VALUES (4, N'Viajes alternativo', 4, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime), 5, 4, 4, 2, 1, 1, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Paquete] ([id], [tipoPaquete], [destino], [fechaIda], [fechaVuelta], [alojamiento], [vuelo], [actividad], [cantidadPersonas], [habitaciones], [accesoDiscapacitados], [precio]) VALUES (5, N'Circuito', 5, CAST(N'2020-01-14T13:00:00.000' AS DateTime), CAST(N'2020-02-03T14:00:00.000' AS DateTime), 1, 5, 5, 3, 1, 1, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Paquete] ([id], [tipoPaquete], [destino], [fechaIda], [fechaVuelta], [alojamiento], [vuelo], [actividad], [cantidadPersonas], [habitaciones], [accesoDiscapacitados], [precio]) VALUES (6, N'Circuito', 6, CAST(N'2020-01-15T05:00:00.000' AS DateTime), CAST(N'2020-02-04T03:00:00.000' AS DateTime), 9, 6, 6, 1, 1, 0, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Paquete] ([id], [tipoPaquete], [destino], [fechaIda], [fechaVuelta], [alojamiento], [vuelo], [actividad], [cantidadPersonas], [habitaciones], [accesoDiscapacitados], [precio]) VALUES (7, N'Viajes alternativos', 4, CAST(N'2020-01-16T09:00:00.000' AS DateTime), CAST(N'2020-02-05T10:00:00.000' AS DateTime), 4, 9, 4, 3, 2, 1, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Paquete] ([id], [tipoPaquete], [destino], [fechaIda], [fechaVuelta], [alojamiento], [vuelo], [actividad], [cantidadPersonas], [habitaciones], [accesoDiscapacitados], [precio]) VALUES (8, N'Programas de estancia', 3, CAST(N'2020-01-17T08:00:00.000' AS DateTime), CAST(N'2020-02-06T10:00:00.000' AS DateTime), 6, 5, 7, 11, 4, 1, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Paquete] ([id], [tipoPaquete], [destino], [fechaIda], [fechaVuelta], [alojamiento], [vuelo], [actividad], [cantidadPersonas], [habitaciones], [accesoDiscapacitados], [precio]) VALUES (9, N'Circuito', 1, CAST(N'2020-01-18T13:00:00.000' AS DateTime), CAST(N'2020-02-07T15:00:00.000' AS DateTime), 8, 7, 1, 6, 1, 1, CAST(0.00 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[Paquete] OFF
GO
SET IDENTITY_INSERT [dbo].[Pasajero] ON 

INSERT [dbo].[Pasajero] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [reserva]) VALUES (1, 10000001, N'Martin', N'Agostino', N'Argentino', N'H. Yrigoyen', N'martinagostino75@yahoo.com.ar', N'14532532', 5)
INSERT [dbo].[Pasajero] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [reserva]) VALUES (2, 10000002, N'Luciano', N'Otegui', N'Argentino', N'Galbán', N'luchootegui@gmail.com', N'33236334', 5)
INSERT [dbo].[Pasajero] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [reserva]) VALUES (3, 10000003, N'Mauro', N'Pereyra', N'Argentino', N'Gabaston', N'mpereyra@andreani.com', N'24243435', 6)
INSERT [dbo].[Pasajero] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [reserva]) VALUES (11013, 10000001, N'Martin', N'Agostino', N'Argentino', N'H. Yrigoyen', N'martinagostino75@yahoo.com.ar', N'14532532', 11017)
INSERT [dbo].[Pasajero] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [reserva]) VALUES (11014, 10000001, N'Martin', N'Agostino', N'Argentino', N'H. Yrigoyen', N'martinagostino75@yahoo.com.ar', N'14532532', 11018)
INSERT [dbo].[Pasajero] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [reserva]) VALUES (11015, 10000001, N'Martin', N'Agostino', N'Argentino', N'H. Yrigoyen', N'martinagostino75@yahoo.com.ar', N'14532532', 11019)
INSERT [dbo].[Pasajero] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [reserva]) VALUES (15022, 10000001, N'Martin', N'Agostino', N'Argentino', N'H. Yrigoyen', N'martinagostino75@yahoo.com.ar', N'14532532', 15026)
SET IDENTITY_INSERT [dbo].[Pasajero] OFF
GO
SET IDENTITY_INSERT [dbo].[Reserva] ON 

INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [alojamiento], [actividad], [vuelo], [esUnPaquete], [paquete], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (2, N'1001', 2, 2, NULL, NULL, NULL, 1, 2, CAST(0.00 AS Numeric(18, 2)), 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [alojamiento], [actividad], [vuelo], [esUnPaquete], [paquete], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (3, N'1002', 3, 3, NULL, NULL, NULL, 1, 3, CAST(0.00 AS Numeric(18, 2)), 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [alojamiento], [actividad], [vuelo], [esUnPaquete], [paquete], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (4, N'1003', 4, 4, NULL, NULL, NULL, 1, 4, CAST(0.00 AS Numeric(18, 2)), 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [alojamiento], [actividad], [vuelo], [esUnPaquete], [paquete], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (5, N'1004', 5, 5, NULL, NULL, NULL, 1, 5, CAST(0.00 AS Numeric(18, 2)), 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [alojamiento], [actividad], [vuelo], [esUnPaquete], [paquete], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (6, N'1005', 6, 3, 4, 2, NULL, 0, NULL, CAST(0.00 AS Numeric(18, 2)), 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [alojamiento], [actividad], [vuelo], [esUnPaquete], [paquete], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (7, N'1006', 7, 5, 4, NULL, 6, 0, NULL, CAST(0.00 AS Numeric(18, 2)), 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [alojamiento], [actividad], [vuelo], [esUnPaquete], [paquete], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (8, N'1007', 7, 4, NULL, 7, 9, 0, NULL, CAST(0.00 AS Numeric(18, 2)), 0, CAST(N'2020-01-13T16:00:00.000' AS DateTime), CAST(N'2020-02-02T17:00:00.000' AS DateTime))
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [alojamiento], [actividad], [vuelo], [esUnPaquete], [paquete], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (11017, N'1', 1, 2, NULL, NULL, 2, 0, NULL, CAST(0.00 AS Numeric(18, 2)), 1, NULL, NULL)
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [alojamiento], [actividad], [vuelo], [esUnPaquete], [paquete], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (11018, N'1', 1, 5, NULL, NULL, 3, 0, NULL, CAST(0.00 AS Numeric(18, 2)), 1, NULL, NULL)
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [alojamiento], [actividad], [vuelo], [esUnPaquete], [paquete], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (11019, N'1', 1, 1, NULL, NULL, 1, 0, NULL, CAST(0.00 AS Numeric(18, 2)), 1, NULL, NULL)
INSERT [dbo].[Reserva] ([id], [nroReserva], [usuario], [destino], [alojamiento], [actividad], [vuelo], [esUnPaquete], [paquete], [importe], [reservaFinalizada], [fechaEntrada], [fechaSalida]) VALUES (15026, N'1', 1, 1, NULL, NULL, 1, 0, NULL, CAST(0.00 AS Numeric(18, 2)), 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Reserva] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoAlojamiento] ON 

INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (1, N'Hotel')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (2, N'Hostel')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (3, N'Motel')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (4, N'Apart-Hotel')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (5, N'Apartment')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (6, N'Boutique Hotel')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (7, N'Resort')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (8, N'Bed and Breakfast (B&B)')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (9, N'Guest House')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (10, N'Lodge')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (11, N'Casa Rural')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (12, N'Inn')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (13, N'Pop-up Hotel')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (14, N'Business Hotel')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (15, N'Pensión')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (16, N'Poshtel')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (17, N'Eco Hotel')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (18, N'Capsule Hotel')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (19, N'Love Hotel')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (20, N'Camping')
INSERT [dbo].[TipoAlojamiento] ([id], [descripcion]) VALUES (21, N'Glamping')
SET IDENTITY_INSERT [dbo].[TipoAlojamiento] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoRegimen] ON 

INSERT [dbo].[TipoRegimen] ([id], [descripcion]) VALUES (1, N'SA (Solo Alojamiento)')
INSERT [dbo].[TipoRegimen] ([id], [descripcion]) VALUES (2, N'MP (Media Pensión)')
INSERT [dbo].[TipoRegimen] ([id], [descripcion]) VALUES (3, N'AD (Alojamiento y Desayuno)')
INSERT [dbo].[TipoRegimen] ([id], [descripcion]) VALUES (4, N'TI (Todo Incluido)')
INSERT [dbo].[TipoRegimen] ([id], [descripcion]) VALUES (5, N'PC (Pensión Completa)')
INSERT [dbo].[TipoRegimen] ([id], [descripcion]) VALUES (6, N'SC (Sin Servicio de Comidas)')
INSERT [dbo].[TipoRegimen] ([id], [descripcion]) VALUES (7, N'SP (servicio según el programa vacacional)')
SET IDENTITY_INSERT [dbo].[TipoRegimen] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (1, 10000001, N'Martin', N'Agostino', N'Argentino', N'H. Yrigoyen', N'martinagostino75@yahoo.com.ar', N'14532532', N'12345', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (2, 10000002, N'Luciano', N'Otegui', N'Argentino', N'Galbán', N'luchootegui@gmail.com', N'33236334', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (3, 10000003, N'Mauro', N'Pereyra', N'Argentino', N'Gabaston', N'mpereyra@andreani.com', N'24243435', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (4, 10000004, N'Tomas', N'Pereyra', N'Argentino', N'Santamarina', N'tomas.pereyra@gmail.com', N'34245663', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (5, 10000005, N'Gian', N'Nativo', N'Argentino', N'Legarreta', N'giannativo@gmail.com', N'62348742', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (6, 10000006, N'Leo', N'Messi', N'Argentino', N'Barcelona', N'messi10@gmail.com', N'63464774', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (7, 10000007, N'Gonzalo', N'Higuain', N'Argentino', N'Torino', N'higuain9@gmail.com', N'34674437', N'123456', 0)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (8, 1, N'UNLaDespegar', N'Admin', N'Admin', N'Admin', N'admin@unladespegar.com', N'63652534', N'123456', 1)
INSERT [dbo].[Usuario] ([id], [dni], [nombre], [apellido], [nacionalidad], [domicilio], [mail], [telefono], [contraseña], [isAdmin]) VALUES (9, 42344234, N'Juan', N'Duarte', N'Argentino', N'Cardeza 1934', N'jduarte@gmail.com', N'11345522335', N'123456', 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Vuelo] ON 

INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAerolinea], [link], [origen], [destino], [idaVuelta], [valoracionAerolinea], [clase], [conEscala], [accesoDiscapacitados], [precio]) VALUES (1, CAST(N'2024-01-10T06:00:00.000' AS DateTime), CAST(N'2024-01-30T20:00:00.000' AS DateTime), N'Aerolíneas Argentinas', N'https://ar.staticontent.com/flights-images/22.8.3/common/airlines/25x25/AR.png', 4, 1, 1, 4, N'Ejecutivo', 1, 1, CAST(9000.00 AS Numeric(18, 2)))
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAerolinea], [link], [origen], [destino], [idaVuelta], [valoracionAerolinea], [clase], [conEscala], [accesoDiscapacitados], [precio]) VALUES (2, CAST(N'2024-01-11T07:00:00.000' AS DateTime), CAST(N'2024-01-31T15:00:00.000' AS DateTime), N'FlyBondi', N'https://ar.staticontent.com/flights-images/22.8.3/common/airlines/25x25/FO.png', 4, 2, 0, 5, N'Económica', 1, 1, CAST(3000.00 AS Numeric(18, 2)))
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAerolinea], [link], [origen], [destino], [idaVuelta], [valoracionAerolinea], [clase], [conEscala], [accesoDiscapacitados], [precio]) VALUES (3, CAST(N'2024-01-12T05:00:00.000' AS DateTime), CAST(N'2024-02-01T16:00:00.000' AS DateTime), N'IBERIA', N'https://ar.staticontent.com/flights-images/22.8.3/common/airlines/25x25/IB.png', 2, 5, 1, 3, N'Económica', 0, 1, CAST(6000.00 AS Numeric(18, 2)))
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAerolinea], [link], [origen], [destino], [idaVuelta], [valoracionAerolinea], [clase], [conEscala], [accesoDiscapacitados], [precio]) VALUES (4, CAST(N'2024-01-13T07:00:00.000' AS DateTime), CAST(N'2024-02-02T17:00:00.000' AS DateTime), N'Aerolíneas Argentinas', N'https://ar.staticontent.com/flights-images/22.8.3/common/airlines/25x25/AR.png', 2, 6, 1, 4, N'Económica', 1, 1, CAST(8000.00 AS Numeric(18, 2)))
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAerolinea], [link], [origen], [destino], [idaVuelta], [valoracionAerolinea], [clase], [conEscala], [accesoDiscapacitados], [precio]) VALUES (5, CAST(N'2024-01-14T08:00:00.000' AS DateTime), CAST(N'2024-02-03T18:00:00.000' AS DateTime), N'Aerolíneas Argentinas', N'https://ar.staticontent.com/flights-images/22.8.3/common/airlines/25x25/AR.png', 1, 3, 0, 4, N'Primera Clase', 1, 1, CAST(12000.00 AS Numeric(18, 2)))
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAerolinea], [link], [origen], [destino], [idaVuelta], [valoracionAerolinea], [clase], [conEscala], [accesoDiscapacitados], [precio]) VALUES (6, CAST(N'2024-01-15T10:00:00.000' AS DateTime), CAST(N'2024-02-04T11:00:00.000' AS DateTime), N'FlyBondi', N'https://ar.staticontent.com/flights-images/22.8.3/common/airlines/25x25/FO.png', 2, 5, 1, 5, N'Ejecutivo', 0, 1, CAST(8000.00 AS Numeric(18, 2)))
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAerolinea], [link], [origen], [destino], [idaVuelta], [valoracionAerolinea], [clase], [conEscala], [accesoDiscapacitados], [precio]) VALUES (7, CAST(N'2024-01-16T13:00:00.000' AS DateTime), CAST(N'2024-02-05T15:00:00.000' AS DateTime), N'FlyBondi', N'https://ar.staticontent.com/flights-images/22.8.3/common/airlines/25x25/FO.png', 3, 1, 1, 3, N'Económica', 0, 0, CAST(4000.00 AS Numeric(18, 2)))
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAerolinea], [link], [origen], [destino], [idaVuelta], [valoracionAerolinea], [clase], [conEscala], [accesoDiscapacitados], [precio]) VALUES (8, CAST(N'2024-01-17T15:00:00.000' AS DateTime), CAST(N'2024-02-06T23:00:00.000' AS DateTime), N'IBERIA', N'https://ar.staticontent.com/flights-images/22.8.3/common/airlines/25x25/IB.png', 4, 2, 0, 2, N'Económica', 1, 1, CAST(3500.00 AS Numeric(18, 2)))
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAerolinea], [link], [origen], [destino], [idaVuelta], [valoracionAerolinea], [clase], [conEscala], [accesoDiscapacitados], [precio]) VALUES (9, CAST(N'2024-01-18T19:00:00.000' AS DateTime), CAST(N'2024-02-07T01:00:00.000' AS DateTime), N'IBERIA', N'https://ar.staticontent.com/flights-images/22.8.3/common/airlines/25x25/IB.png', 3, 4, 1, 5, N'Ejecutivo', 1, 1, CAST(10000.00 AS Numeric(18, 2)))
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAerolinea], [link], [origen], [destino], [idaVuelta], [valoracionAerolinea], [clase], [conEscala], [accesoDiscapacitados], [precio]) VALUES (10, CAST(N'2024-02-10T19:00:00.000' AS DateTime), CAST(N'2024-02-25T01:00:00.000' AS DateTime), N'IBERIA', N'https://ar.staticontent.com/flights-images/22.8.3/common/airlines/25x25/IB.png', 4, 8, 1, 5, N'Ejecutivo', 1, 1, CAST(23000.00 AS Numeric(18, 2)))
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAerolinea], [link], [origen], [destino], [idaVuelta], [valoracionAerolinea], [clase], [conEscala], [accesoDiscapacitados], [precio]) VALUES (11, CAST(N'2024-02-08T19:00:00.000' AS DateTime), CAST(N'2024-02-22T01:00:00.000' AS DateTime), N'IBERIA', N'https://ar.staticontent.com/flights-images/22.8.3/common/airlines/25x25/IB.png', 1, 8, 1, 5, N'Primera Clase', 1, 1, CAST(32000.00 AS Numeric(18, 2)))
INSERT [dbo].[Vuelo] ([id], [fechaIda], [fechaVuelta], [nombreAerolinea], [link], [origen], [destino], [idaVuelta], [valoracionAerolinea], [clase], [conEscala], [accesoDiscapacitados], [precio]) VALUES (12, CAST(N'2024-01-02T10:00:00.000' AS DateTime), CAST(N'2024-01-30T11:00:00.000' AS DateTime), N'FlyBondi', N'https://ar.staticontent.com/flights-images/22.8.3/common/airlines/25x25/FO.png', 4, 7, 1, 5, N'Económica', 0, 1, CAST(1600.00 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[Vuelo] OFF
GO
ALTER TABLE [dbo].[Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Actividad_Destino] FOREIGN KEY([destino])
REFERENCES [dbo].[Destino] ([id])
GO
ALTER TABLE [dbo].[Actividad] CHECK CONSTRAINT [FK_Actividad_Destino]
GO
ALTER TABLE [dbo].[Alojamiento]  WITH CHECK ADD  CONSTRAINT [FK_Alojamiento_Destino] FOREIGN KEY([destino])
REFERENCES [dbo].[Destino] ([id])
GO
ALTER TABLE [dbo].[Alojamiento] CHECK CONSTRAINT [FK_Alojamiento_Destino]
GO
ALTER TABLE [dbo].[Alojamiento]  WITH CHECK ADD  CONSTRAINT [FK_Alojamiento_TipoAlojamiento] FOREIGN KEY([tipoAlojamiento])
REFERENCES [dbo].[TipoAlojamiento] ([id])
GO
ALTER TABLE [dbo].[Alojamiento] CHECK CONSTRAINT [FK_Alojamiento_TipoAlojamiento]
GO
ALTER TABLE [dbo].[Alojamiento]  WITH CHECK ADD  CONSTRAINT [FK_Alojamiento_TipoRegimen] FOREIGN KEY([tipoRegimen])
REFERENCES [dbo].[TipoRegimen] ([id])
GO
ALTER TABLE [dbo].[Alojamiento] CHECK CONSTRAINT [FK_Alojamiento_TipoRegimen]
GO
ALTER TABLE [dbo].[Paquete]  WITH CHECK ADD  CONSTRAINT [FK_Paquete_Actividad] FOREIGN KEY([actividad])
REFERENCES [dbo].[Actividad] ([id])
GO
ALTER TABLE [dbo].[Paquete] CHECK CONSTRAINT [FK_Paquete_Actividad]
GO
ALTER TABLE [dbo].[Paquete]  WITH CHECK ADD  CONSTRAINT [FK_Paquete_Alojamiento] FOREIGN KEY([alojamiento])
REFERENCES [dbo].[Alojamiento] ([id])
GO
ALTER TABLE [dbo].[Paquete] CHECK CONSTRAINT [FK_Paquete_Alojamiento]
GO
ALTER TABLE [dbo].[Paquete]  WITH CHECK ADD  CONSTRAINT [FK_Paquete_Destino] FOREIGN KEY([destino])
REFERENCES [dbo].[Destino] ([id])
GO
ALTER TABLE [dbo].[Paquete] CHECK CONSTRAINT [FK_Paquete_Destino]
GO
ALTER TABLE [dbo].[Paquete]  WITH CHECK ADD  CONSTRAINT [FK_Paquete_Vuelo] FOREIGN KEY([vuelo])
REFERENCES [dbo].[Vuelo] ([id])
GO
ALTER TABLE [dbo].[Paquete] CHECK CONSTRAINT [FK_Paquete_Vuelo]
GO
ALTER TABLE [dbo].[Pasajero]  WITH CHECK ADD  CONSTRAINT [FK_Pasajero_Reserva] FOREIGN KEY([reserva])
REFERENCES [dbo].[Reserva] ([id])
GO
ALTER TABLE [dbo].[Pasajero] CHECK CONSTRAINT [FK_Pasajero_Reserva]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Actividad] FOREIGN KEY([actividad])
REFERENCES [dbo].[Actividad] ([id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Actividad]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Alojamiento] FOREIGN KEY([alojamiento])
REFERENCES [dbo].[Alojamiento] ([id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Alojamiento]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Destino] FOREIGN KEY([destino])
REFERENCES [dbo].[Destino] ([id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Destino]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Paquete] FOREIGN KEY([paquete])
REFERENCES [dbo].[Paquete] ([id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Paquete]
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
USE [master]
GO
ALTER DATABASE [UnlaDespegar] SET  READ_WRITE 
GO
