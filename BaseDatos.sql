USE [PruebaNTTData]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 25/8/2022 21:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPersona] [bigint] NULL,
	[Contrasena] [varchar](150) NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 25/8/2022 21:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[IdCuenta] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCliente] [bigint] NULL,
	[Numero] [varchar](100) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[SaldoInicial] [decimal](18, 4) NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 25/8/2022 21:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[IdMovimiento] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCuenta] [bigint] NULL,
	[Fecha] [datetime] NOT NULL,
	[TipoMovimiento] [varchar](100) NOT NULL,
	[Valor] [decimal](18, 4) NOT NULL,
	[Saldo] [decimal](18, 4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 25/8/2022 21:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[IdPersona] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](300) NOT NULL,
	[Genero] [varchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [varchar](100) NOT NULL,
	[Direccion] [varchar](300) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([IdCliente], [IdPersona], [Contrasena], [Estado]) VALUES (1, 1, N'1234', 1)
INSERT [dbo].[Cliente] ([IdCliente], [IdPersona], [Contrasena], [Estado]) VALUES (2, 2, N'5678', 1)
INSERT [dbo].[Cliente] ([IdCliente], [IdPersona], [Contrasena], [Estado]) VALUES (3, 3, N'1245', 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuenta] ON 

INSERT [dbo].[Cuenta] ([IdCuenta], [IdCliente], [Numero], [Tipo], [SaldoInicial], [Estado]) VALUES (1, 1, N'478758', N'Ahorro', CAST(2000.0000 AS Decimal(18, 4)), 1)
INSERT [dbo].[Cuenta] ([IdCuenta], [IdCliente], [Numero], [Tipo], [SaldoInicial], [Estado]) VALUES (2, 2, N'225487', N'Corriente', CAST(100.0000 AS Decimal(18, 4)), 1)
INSERT [dbo].[Cuenta] ([IdCuenta], [IdCliente], [Numero], [Tipo], [SaldoInicial], [Estado]) VALUES (3, 3, N'495878', N'Ahorros', CAST(0.0000 AS Decimal(18, 4)), 1)
INSERT [dbo].[Cuenta] ([IdCuenta], [IdCliente], [Numero], [Tipo], [SaldoInicial], [Estado]) VALUES (4, 2, N'496825', N'Ahorros', CAST(540.0000 AS Decimal(18, 4)), 1)
INSERT [dbo].[Cuenta] ([IdCuenta], [IdCliente], [Numero], [Tipo], [SaldoInicial], [Estado]) VALUES (5, 1, N'585545', N'Corriente', CAST(1000.0000 AS Decimal(18, 4)), 1)
SET IDENTITY_INSERT [dbo].[Cuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimientos] ON 

INSERT [dbo].[Movimientos] ([IdMovimiento], [IdCuenta], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (1, 2, CAST(N'2022-02-10T00:00:00.000' AS DateTime), N'CREDITO', CAST(600.0000 AS Decimal(18, 4)), CAST(700.0000 AS Decimal(18, 4)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [IdCuenta], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (2, 3, CAST(N'2022-02-09T00:00:00.000' AS DateTime), N'CREDITO', CAST(150.0000 AS Decimal(18, 4)), CAST(150.0000 AS Decimal(18, 4)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [IdCuenta], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (3, 4, CAST(N'2022-02-08T00:00:00.000' AS DateTime), N'DEBITO', CAST(-540.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [IdCuenta], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (4, 1, CAST(N'2022-02-11T00:00:00.000' AS DateTime), N'DEBITO', CAST(-575.0000 AS Decimal(18, 4)), CAST(1425.0000 AS Decimal(18, 4)))
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([IdPersona], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (1, N'Jose Lema', N'Masculino', 36, N'0987654321', N'Otavalo sn y principal', N'098254785')
INSERT [dbo].[Persona] ([IdPersona], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (2, N'Marianela Montalvo', N'Femenina', 48, N'0165897456', N'Amazonas y NNUU', N'097548965')
INSERT [dbo].[Persona] ([IdPersona], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (3, N'Juan Osorio', N'Masculino', 30, N'1205698478', N'13 junio y Equinoccial', N'098874587')
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD FOREIGN KEY([IdCuenta])
REFERENCES [dbo].[Cuenta] ([IdCuenta])
GO
