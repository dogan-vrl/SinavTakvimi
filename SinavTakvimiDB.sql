USE [master]
GO
/****** Object:  Database [SinavTakvimi]    Script Date: 22.06.2020 04:18:50 ******/
CREATE DATABASE [SinavTakvimi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SinavTakvimi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SinavTakvimi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SinavTakvimi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SinavTakvimi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SinavTakvimi] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SinavTakvimi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SinavTakvimi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SinavTakvimi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SinavTakvimi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SinavTakvimi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SinavTakvimi] SET ARITHABORT OFF 
GO
ALTER DATABASE [SinavTakvimi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SinavTakvimi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SinavTakvimi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SinavTakvimi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SinavTakvimi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SinavTakvimi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SinavTakvimi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SinavTakvimi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SinavTakvimi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SinavTakvimi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SinavTakvimi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SinavTakvimi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SinavTakvimi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SinavTakvimi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SinavTakvimi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SinavTakvimi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SinavTakvimi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SinavTakvimi] SET RECOVERY FULL 
GO
ALTER DATABASE [SinavTakvimi] SET  MULTI_USER 
GO
ALTER DATABASE [SinavTakvimi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SinavTakvimi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SinavTakvimi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SinavTakvimi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SinavTakvimi] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SinavTakvimi', N'ON'
GO
ALTER DATABASE [SinavTakvimi] SET QUERY_STORE = OFF
GO
USE [SinavTakvimi]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 22.06.2020 04:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](150) NULL,
	[Soyad] [nvarchar](150) NULL,
	[KullaniciAdi] [nvarchar](50) NULL,
	[Sifre] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asistanlar]    Script Date: 22.06.2020 04:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistanlar](
	[Id] [nvarchar](50) NOT NULL,
	[BolumId] [int] NULL,
	[Adi] [nvarchar](150) NULL,
	[Soyadi] [nvarchar](150) NULL,
	[Cinsiyeti] [bit] NULL,
 CONSTRAINT [PK_Asistanlar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bolumler]    Script Date: 22.06.2020 04:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bolumler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BolumKod] [nvarchar](50) NULL,
	[BolumAdi] [nvarchar](500) NULL,
 CONSTRAINT [PK_Bolumler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dersler]    Script Date: 22.06.2020 04:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dersler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BolumId] [int] NULL,
	[DersKodu] [nvarchar](50) NULL,
	[DersAdi] [nvarchar](150) NULL,
	[DersiAlanOgrenciSayisi] [int] NULL,
	[EngelliDurumu] [bit] NULL,
	[DersinHocasi] [nvarchar](250) NULL,
 CONSTRAINT [PK_Dersler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Derslikler]    Script Date: 22.06.2020 04:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Derslikler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BolumId] [int] NULL,
	[DerslikKod] [nvarchar](50) NULL,
	[DerslikAdi] [nvarchar](150) NULL,
	[DerslikKapasitesi] [int] NULL,
	[DerslikKat] [tinyint] NULL,
	[Aciklama] [nvarchar](max) NULL,
 CONSTRAINT [PK_Derslikler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Izinler]    Script Date: 22.06.2020 04:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Izinler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AsistanId] [nvarchar](50) NULL,
	[IzinAdi] [nvarchar](150) NULL,
	[IzinAciklama] [nvarchar](max) NULL,
	[IzinBasSaati] [time](7) NULL,
	[IzinBitisSaati] [time](7) NULL,
	[IzınBasTarihi] [date] NULL,
	[IzinBitisTarihi] [date] NULL,
 CONSTRAINT [PK_Izinler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sekreterler]    Script Date: 22.06.2020 04:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sekreterler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BolumId] [int] NULL,
	[Adi] [nvarchar](150) NULL,
	[Soyadi] [nvarchar](150) NULL,
	[KullaniciAdi] [nvarchar](150) NULL,
	[Sifre] [nvarchar](150) NULL,
 CONSTRAINT [PK_Sekreterler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sinavlar]    Script Date: 22.06.2020 04:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sinavlar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BolumId] [int] NULL,
	[DersId] [int] NULL,
	[DerslikId] [int] NULL,
	[AsistanId] [nvarchar](50) NULL,
	[Tarih] [date] NULL,
	[BaslangicSaati] [time](7) NULL,
	[BitisSaati] [time](7) NULL,
 CONSTRAINT [PK_Sinavlar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asistanlar]  WITH CHECK ADD  CONSTRAINT [FK_Asistanlar_Bolumler] FOREIGN KEY([BolumId])
REFERENCES [dbo].[Bolumler] ([Id])
GO
ALTER TABLE [dbo].[Asistanlar] CHECK CONSTRAINT [FK_Asistanlar_Bolumler]
GO
ALTER TABLE [dbo].[Dersler]  WITH CHECK ADD  CONSTRAINT [FK_Dersler_Bolumler] FOREIGN KEY([BolumId])
REFERENCES [dbo].[Bolumler] ([Id])
GO
ALTER TABLE [dbo].[Dersler] CHECK CONSTRAINT [FK_Dersler_Bolumler]
GO
ALTER TABLE [dbo].[Derslikler]  WITH CHECK ADD  CONSTRAINT [FK_Derslikler_Bolumler] FOREIGN KEY([BolumId])
REFERENCES [dbo].[Bolumler] ([Id])
GO
ALTER TABLE [dbo].[Derslikler] CHECK CONSTRAINT [FK_Derslikler_Bolumler]
GO
ALTER TABLE [dbo].[Izinler]  WITH CHECK ADD  CONSTRAINT [FK_Izinler_Asistanlar] FOREIGN KEY([AsistanId])
REFERENCES [dbo].[Asistanlar] ([Id])
GO
ALTER TABLE [dbo].[Izinler] CHECK CONSTRAINT [FK_Izinler_Asistanlar]
GO
ALTER TABLE [dbo].[Sekreterler]  WITH CHECK ADD  CONSTRAINT [FK_Sekreterler_Bolumler] FOREIGN KEY([BolumId])
REFERENCES [dbo].[Bolumler] ([Id])
GO
ALTER TABLE [dbo].[Sekreterler] CHECK CONSTRAINT [FK_Sekreterler_Bolumler]
GO
ALTER TABLE [dbo].[Sinavlar]  WITH CHECK ADD  CONSTRAINT [FK_Sinavlar_Asistanlar] FOREIGN KEY([AsistanId])
REFERENCES [dbo].[Asistanlar] ([Id])
GO
ALTER TABLE [dbo].[Sinavlar] CHECK CONSTRAINT [FK_Sinavlar_Asistanlar]
GO
ALTER TABLE [dbo].[Sinavlar]  WITH CHECK ADD  CONSTRAINT [FK_Sinavlar_Bolumler] FOREIGN KEY([BolumId])
REFERENCES [dbo].[Bolumler] ([Id])
GO
ALTER TABLE [dbo].[Sinavlar] CHECK CONSTRAINT [FK_Sinavlar_Bolumler]
GO
ALTER TABLE [dbo].[Sinavlar]  WITH CHECK ADD  CONSTRAINT [FK_Sinavlar_Dersler] FOREIGN KEY([DersId])
REFERENCES [dbo].[Dersler] ([Id])
GO
ALTER TABLE [dbo].[Sinavlar] CHECK CONSTRAINT [FK_Sinavlar_Dersler]
GO
ALTER TABLE [dbo].[Sinavlar]  WITH CHECK ADD  CONSTRAINT [FK_Sinavlar_Derslikler] FOREIGN KEY([DerslikId])
REFERENCES [dbo].[Derslikler] ([Id])
GO
ALTER TABLE [dbo].[Sinavlar] CHECK CONSTRAINT [FK_Sinavlar_Derslikler]
GO
USE [master]
GO
ALTER DATABASE [SinavTakvimi] SET  READ_WRITE 
GO
