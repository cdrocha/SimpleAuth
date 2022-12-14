USE [master]
GO
/****** Object:  Database [SimpleAuthDB]    Script Date: 11/11/2022 8:49:42 ******/
CREATE DATABASE [SimpleAuthDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SimpleAuthDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\DATA\SimpleAuthDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SimpleAuthDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\DATA\SimpleAuthDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SimpleAuthDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SimpleAuthDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SimpleAuthDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SimpleAuthDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SimpleAuthDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SimpleAuthDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SimpleAuthDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SimpleAuthDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET RECOVERY FULL 
GO
ALTER DATABASE [SimpleAuthDB] SET  MULTI_USER 
GO
ALTER DATABASE [SimpleAuthDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SimpleAuthDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SimpleAuthDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SimpleAuthDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SimpleAuthDB', N'ON'
GO
USE [SimpleAuthDB]
GO
/****** Object:  Table [dbo].[Funcion]    Script Date: 11/11/2022 8:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcion](
	[funcionID] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[activo] [bit] NOT NULL,
	[usuarioAltaID] [bigint] NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[usuarioModificacionID] [bigint] NULL,
	[fechaModificacion] [datetime] NULL,
	[usuarioBajaID] [bigint] NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Funcion] PRIMARY KEY CLUSTERED 
(
	[funcionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginLog]    Script Date: 11/11/2022 8:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginLog](
	[loginLogID] [bigint] IDENTITY(1,1) NOT NULL,
	[usuarioLoginID] [bigint] NOT NULL,
	[exitoso] [bit] NOT NULL,
	[error] [nvarchar](max) NULL,
	[fechaAlta] [datetime] NOT NULL,
 CONSTRAINT [PK_LoginLog] PRIMARY KEY CLUSTERED 
(
	[loginLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 11/11/2022 8:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[rolID] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[activo] [bit] NOT NULL,
	[usuarioAltaID] [bigint] NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[usuarioModificacionID] [bigint] NULL,
	[fechaModificacion] [datetime] NULL,
	[usuarioBajaID] [bigint] NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[rolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RolFuncion]    Script Date: 11/11/2022 8:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolFuncion](
	[rolFuncionID] [bigint] IDENTITY(1,1) NOT NULL,
	[rolID] [bigint] NOT NULL,
	[funcionID] [bigint] NOT NULL,
	[activo] [bit] NOT NULL,
	[usuarioAltaID] [bigint] NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[usuarioModificacionID] [bigint] NULL,
	[fechaModificacion] [datetime] NULL,
	[usuarioBajaID] [bigint] NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_RolFuncion] PRIMARY KEY CLUSTERED 
(
	[rolFuncionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/11/2022 8:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuarioID] [bigint] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](100) NULL,
	[telefono] [nvarchar](20) NULL,
	[nombre] [nvarchar](20) NULL,
	[apellido] [nvarchar](20) NULL,
	[perfil] [nvarchar](max) NULL,
	[activo] [bit] NOT NULL,
	[usuarioAltaID] [bigint] NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[usuarioModificacionID] [bigint] NULL,
	[fechaModificacion] [datetime] NULL,
	[usuarioBajaID] [bigint] NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsuarioLogin]    Script Date: 11/11/2022 8:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioLogin](
	[usuarioLoginID] [bigint] IDENTITY(1,1) NOT NULL,
	[usuarioID] [bigint] NOT NULL,
	[nombreUsuario] [nvarchar](30) NOT NULL,
	[proveedor] [nvarchar](30) NULL,
	[identificadorExterno] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[validado] [bit] NOT NULL,
	[usuarioAltaID] [bigint] NULL,
	[fechaAlta] [datetime] NOT NULL,
	[usuarioModificacionID] [bigint] NULL,
	[fechaModificacion] [datetime] NULL,
	[usuarioBajaID] [bigint] NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_UsuarioLogin] PRIMARY KEY CLUSTERED 
(
	[usuarioLoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsuarioRol]    Script Date: 11/11/2022 8:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRol](
	[usuarioRolID] [bigint] IDENTITY(1,1) NOT NULL,
	[usuarioID] [bigint] NOT NULL,
	[rolID] [bigint] NOT NULL,
	[activo] [bit] NOT NULL,
	[usuarioAltaID] [bigint] NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[usuarioModificacionID] [bigint] NULL,
	[fechaModificacion] [datetime] NULL,
	[usuarioBajaID] [bigint] NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_UsuarioRol] PRIMARY KEY CLUSTERED 
(
	[usuarioRolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Funcion] ON 

INSERT [dbo].[Funcion] ([funcionID], [nombre], [activo], [usuarioAltaID], [fechaAlta], [usuarioModificacionID], [fechaModificacion], [usuarioBajaID], [fechaBaja]) VALUES (1, N'admin', 1, 1, CAST(0x0000AF4800000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[Funcion] ([funcionID], [nombre], [activo], [usuarioAltaID], [fechaAlta], [usuarioModificacionID], [fechaModificacion], [usuarioBajaID], [fechaBaja]) VALUES (2, N'UsuarioCrear', 1, 1, CAST(0x0000AF4800000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[Funcion] ([funcionID], [nombre], [activo], [usuarioAltaID], [fechaAlta], [usuarioModificacionID], [fechaModificacion], [usuarioBajaID], [fechaBaja]) VALUES (3, N'UsuarioAsociarRol', 1, 1, CAST(0x0000AF4800000000 AS DateTime), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Funcion] OFF
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([rolID], [nombre], [activo], [usuarioAltaID], [fechaAlta], [usuarioModificacionID], [fechaModificacion], [usuarioBajaID], [fechaBaja]) VALUES (1, N'Admin', 1, 1, CAST(0x0000AF4800000000 AS DateTime), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Rol] OFF
SET IDENTITY_INSERT [dbo].[RolFuncion] ON 

INSERT [dbo].[RolFuncion] ([rolFuncionID], [rolID], [funcionID], [activo], [usuarioAltaID], [fechaAlta], [usuarioModificacionID], [fechaModificacion], [usuarioBajaID], [fechaBaja]) VALUES (1, 1, 1, 1, 1, CAST(0x0000AF4800000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[RolFuncion] ([rolFuncionID], [rolID], [funcionID], [activo], [usuarioAltaID], [fechaAlta], [usuarioModificacionID], [fechaModificacion], [usuarioBajaID], [fechaBaja]) VALUES (3, 1, 2, 1, 1, CAST(0x0000AF4800000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[RolFuncion] ([rolFuncionID], [rolID], [funcionID], [activo], [usuarioAltaID], [fechaAlta], [usuarioModificacionID], [fechaModificacion], [usuarioBajaID], [fechaBaja]) VALUES (4, 1, 3, 1, 1, CAST(0x0000AF4800000000 AS DateTime), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[RolFuncion] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([usuarioID], [email], [telefono], [nombre], [apellido], [perfil], [activo], [usuarioAltaID], [fechaAlta], [usuarioModificacionID], [fechaModificacion], [usuarioBajaID], [fechaBaja]) VALUES (1, N'cdrocha82@gmail.com', N'1166654622', N'Daniel', N'Rocha', NULL, 1, 1, CAST(0x0000AF4700000000 AS DateTime), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET IDENTITY_INSERT [dbo].[UsuarioLogin] ON 

INSERT [dbo].[UsuarioLogin] ([usuarioLoginID], [usuarioID], [nombreUsuario], [proveedor], [identificadorExterno], [password], [validado], [usuarioAltaID], [fechaAlta], [usuarioModificacionID], [fechaModificacion], [usuarioBajaID], [fechaBaja]) VALUES (1, 1, N'cdrocha82@gmail.com', N'local', NULL, N'Strong@Password15', 1, 1, CAST(0x0000AF4700000000 AS DateTime), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UsuarioLogin] OFF
SET IDENTITY_INSERT [dbo].[UsuarioRol] ON 

INSERT [dbo].[UsuarioRol] ([usuarioRolID], [usuarioID], [rolID], [activo], [usuarioAltaID], [fechaAlta], [usuarioModificacionID], [fechaModificacion], [usuarioBajaID], [fechaBaja]) VALUES (1, 1, 1, 1, 1, CAST(0x0000AF4800000000 AS DateTime), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UsuarioRol] OFF
/****** Object:  Index [IX_RolFuncion_Rol]    Script Date: 11/11/2022 8:49:42 ******/
CREATE NONCLUSTERED INDEX [IX_RolFuncion_Rol] ON [dbo].[RolFuncion]
(
	[rolFuncionID] ASC,
	[rolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UK_RolFuncion]    Script Date: 11/11/2022 8:49:42 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UK_RolFuncion] ON [dbo].[RolFuncion]
(
	[rolID] ASC,
	[funcionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_NombreUsuarioUnico]    Script Date: 11/11/2022 8:49:42 ******/
ALTER TABLE [dbo].[UsuarioLogin] ADD  CONSTRAINT [UK_NombreUsuarioUnico] UNIQUE NONCLUSTERED 
(
	[nombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UK_UsuarioRol]    Script Date: 11/11/2022 8:49:42 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UK_UsuarioRol] ON [dbo].[UsuarioRol]
(
	[rolID] ASC,
	[usuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UsuarioLogin] ADD  DEFAULT ((0)) FOR [validado]
GO
ALTER TABLE [dbo].[LoginLog]  WITH CHECK ADD  CONSTRAINT [FK_LoginLog_UsuarioLogin] FOREIGN KEY([usuarioLoginID])
REFERENCES [dbo].[UsuarioLogin] ([usuarioLoginID])
GO
ALTER TABLE [dbo].[LoginLog] CHECK CONSTRAINT [FK_LoginLog_UsuarioLogin]
GO
ALTER TABLE [dbo].[RolFuncion]  WITH CHECK ADD  CONSTRAINT [FK_RolFuncion_Funcion] FOREIGN KEY([funcionID])
REFERENCES [dbo].[Funcion] ([funcionID])
GO
ALTER TABLE [dbo].[RolFuncion] CHECK CONSTRAINT [FK_RolFuncion_Funcion]
GO
ALTER TABLE [dbo].[RolFuncion]  WITH CHECK ADD  CONSTRAINT [FK_RolFuncion_Rol] FOREIGN KEY([rolID])
REFERENCES [dbo].[Rol] ([rolID])
GO
ALTER TABLE [dbo].[RolFuncion] CHECK CONSTRAINT [FK_RolFuncion_Rol]
GO
ALTER TABLE [dbo].[UsuarioLogin]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioLogin_Usuario] FOREIGN KEY([usuarioID])
REFERENCES [dbo].[Usuario] ([usuarioID])
GO
ALTER TABLE [dbo].[UsuarioLogin] CHECK CONSTRAINT [FK_UsuarioLogin_Usuario]
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Rol] FOREIGN KEY([rolID])
REFERENCES [dbo].[Rol] ([rolID])
GO
ALTER TABLE [dbo].[UsuarioRol] CHECK CONSTRAINT [FK_UsuarioRol_Rol]
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Usuario] FOREIGN KEY([usuarioID])
REFERENCES [dbo].[Usuario] ([usuarioID])
GO
ALTER TABLE [dbo].[UsuarioRol] CHECK CONSTRAINT [FK_UsuarioRol_Usuario]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indice para mejorar la velocidad de busqueda' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolFuncion', @level2type=N'INDEX',@level2name=N'IX_RolFuncion_Rol'
GO
USE [master]
GO
ALTER DATABASE [SimpleAuthDB] SET  READ_WRITE 
GO
