USE [master]
GO
/****** Object:  Database [ProductManagerBackendDB]    Script Date: 3/12/2021 11:33:59 PM ******/
CREATE DATABASE [ProductManagerBackendDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductManagerBackendDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ProductManagerBackendDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductManagerBackendDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ProductManagerBackendDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProductManagerBackendDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductManagerBackendDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductManagerBackendDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductManagerBackendDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductManagerBackendDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProductManagerBackendDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductManagerBackendDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ProductManagerBackendDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ProductManagerBackendDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProductManagerBackendDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductManagerBackendDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductManagerBackendDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductManagerBackendDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductManagerBackendDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProductManagerBackendDB', N'ON'
GO
ALTER DATABASE [ProductManagerBackendDB] SET QUERY_STORE = OFF
GO
USE [ProductManagerBackendDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/12/2021 11:33:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Brands]    Script Date: 3/12/2021 11:33:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](max) NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Companies]    Script Date: 3/12/2021 11:33:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Products]    Script Date: 3/12/2021 11:33:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Amount] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201216112157_db1', N'5.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201217091507_db2', N'5.0.1')
GO
SET IDENTITY_INSERT [dbo].[Tbl_Brands] ON 

INSERT [dbo].[Tbl_Brands] ([Id], [BrandName], [CompanyId]) VALUES (6, N'Asp DotNet Core', 7)
INSERT [dbo].[Tbl_Brands] ([Id], [BrandName], [CompanyId]) VALUES (7, N'Xamarin', 7)
INSERT [dbo].[Tbl_Brands] ([Id], [BrandName], [CompanyId]) VALUES (8, N'Blazor', 7)
INSERT [dbo].[Tbl_Brands] ([Id], [BrandName], [CompanyId]) VALUES (13, N'React', 8)
SET IDENTITY_INSERT [dbo].[Tbl_Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Companies] ON 

INSERT [dbo].[Tbl_Companies] ([Id], [CompanyName]) VALUES (7, N'Microsoft')
INSERT [dbo].[Tbl_Companies] ([Id], [CompanyName]) VALUES (8, N'Facebook')
SET IDENTITY_INSERT [dbo].[Tbl_Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Products] ON 

INSERT [dbo].[Tbl_Products] ([Id], [BrandId], [Name], [Amount], [Price]) VALUES (5, 8, N'Blazor Product Awesome', 20, 1000)
INSERT [dbo].[Tbl_Products] ([Id], [BrandId], [Name], [Amount], [Price]) VALUES (14, 8, N'Awesome Blazor', 123, 123)
INSERT [dbo].[Tbl_Products] ([Id], [BrandId], [Name], [Amount], [Price]) VALUES (15, 13, N'React Js', 33, 55)
SET IDENTITY_INSERT [dbo].[Tbl_Products] OFF
GO
/****** Object:  Index [IX_Tbl_Brands_CompanyId]    Script Date: 3/12/2021 11:33:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tbl_Brands_CompanyId] ON [dbo].[Tbl_Brands]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tbl_Products_BrandId]    Script Date: 3/12/2021 11:33:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tbl_Products_BrandId] ON [dbo].[Tbl_Products]
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tbl_Brands]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Brands_Tbl_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Tbl_Companies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tbl_Brands] CHECK CONSTRAINT [FK_Tbl_Brands_Tbl_Companies_CompanyId]
GO
ALTER TABLE [dbo].[Tbl_Products]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Products_Tbl_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Tbl_Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tbl_Products] CHECK CONSTRAINT [FK_Tbl_Products_Tbl_Brands_BrandId]
GO
USE [master]
GO
ALTER DATABASE [ProductManagerBackendDB] SET  READ_WRITE 
GO
