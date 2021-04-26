Use [Tayco]

GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 3/8/2021 9:27:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[AdministradorId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[NombreAdministrador] [nvarchar](50) NOT NULL,
	[PrimerApellido] [nvarchar](50) NOT NULL,
	[SegundoApellido] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Telefono] [int] NULL,
	[Estado] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Administrador] PRIMARY KEY CLUSTERED 
(
	[AdministradorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Equipo]    Script Date: 3/8/2021 9:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipo](
	[EquipoId] [int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo] [nvarchar](50) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[TipoEquipoID] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Equipo] PRIMARY KEY CLUSTERED 
(
	[EquipoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 3/8/2021 9:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[ReservaId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TipoCanchaId] [int] NOT NULL,
	[EquipoId] [int] NOT NULL,
	[FechaReserva] [date] NOT NULL,
	[Hora] [datetime] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[ReservaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/8/2021 9:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoCancha]    Script Date: 3/8/2021 9:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCancha](
	[TipoCanchaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreCancha] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoCancha] PRIMARY KEY CLUSTERED 
(
	[TipoCanchaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoEquipo]    Script Date: 3/8/2021 9:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEquipo](
	[TipoEquipoId] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoEquipo] PRIMARY KEY CLUSTERED 
(
	[TipoEquipoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/8/2021 9:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[PrimerApellido] [nvarchar](50) NOT NULL,
	[SegundoApellido] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

/*Foreigns keys*/
GO
ALTER TABLE [dbo].[Administrador]  WITH CHECK ADD  CONSTRAINT [FK_Administrador_role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])

GO
ALTER TABLE [dbo].[Administrador] CHECK CONSTRAINT [FK_Administrador_role]


GO
ALTER TABLE [dbo].[Equipo]  WITH CHECK ADD  CONSTRAINT [FK_TipoEquipo] FOREIGN KEY([TipoEquipoId])
REFERENCES [dbo].[TipoEquipo] ([TipoEquipoId])

GO
ALTER TABLE [dbo].[Equipo] CHECK CONSTRAINT [FK_TipoEquipo]

GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])

GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Users]

GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_Cancha] FOREIGN KEY([TipoCanchaId])
REFERENCES [dbo].[TipoCancha] ([TipoCanchaId])

GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Tipo_Cancha]

GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Equipo] FOREIGN KEY([EquipoId])
REFERENCES [dbo].[Equipo] ([EquipoId])

GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Equipo]

GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])

GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_role]

GO
