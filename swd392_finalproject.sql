USE [master]
GO
/****** Object:  Database [SWD392_FinalProject]    Script Date: 7/17/2023 3:48:34 PM ******/
CREATE DATABASE [SWD392_FinalProject]
GO
ALTER DATABASE [SWD392_FinalProject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SWD392_FinalProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SWD392_FinalProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SWD392_FinalProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SWD392_FinalProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SWD392_FinalProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SWD392_FinalProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SWD392_FinalProject] SET  MULTI_USER 
GO
ALTER DATABASE [SWD392_FinalProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SWD392_FinalProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SWD392_FinalProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SWD392_FinalProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SWD392_FinalProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SWD392_FinalProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SWD392_FinalProject] SET QUERY_STORE = OFF
GO
USE [SWD392_FinalProject]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/17/2023 3:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[accountId] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](100) NULL,
	[password] [text] NULL,
	[roleId] [int] NULL,
	[name] [nvarchar](100) NULL,
	[gender] [nvarchar](6) NULL,
	[dob] [date] NULL,
	[phoneNumber] [varchar](11) NULL,
	[address] [nvarchar](50) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[accountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 7/17/2023 3:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[departmentID] [int] IDENTITY(1,1) NOT NULL,
	[departmentName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[departmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 7/17/2023 3:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[accountId] [int] NOT NULL,
	[code] [int] IDENTITY(1,1) NOT NULL,
	[hireDate] [date] NULL,
	[expertiseDetail] [text] NULL,
	[departmentId] [int] NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExaminationForm]    Script Date: 7/17/2023 3:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExaminationForm](
	[ExaminationFormId] [int] IDENTITY(1,1) NOT NULL,
	[MeetingDate] [datetime] NULL,
	[Note] [nvarchar](200) NULL,
	[PatientId] [int] NULL,
	[DoctorCode] [int] NULL,
 CONSTRAINT [PK_ExaminationForm] PRIMARY KEY CLUSTERED 
(
	[ExaminationFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExaminationResult]    Script Date: 7/17/2023 3:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExaminationResult](
	[resultId] [int] IDENTITY(1,1) NOT NULL,
	[medicalRecord] [int] NOT NULL,
	[doctorId] [int] NOT NULL,
	[serviceId] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[modified_at] [datetime] NULL,
 CONSTRAINT [PK_ExaminationResult] PRIMARY KEY CLUSTERED 
(
	[resultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalRecord]    Script Date: 7/17/2023 3:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalRecord](
	[medicalRecordId] [int] IDENTITY(1,1) NOT NULL,
	[patientId] [int] NULL,
	[Note] [text] NULL,
 CONSTRAINT [PK_MedicalRecord] PRIMARY KEY CLUSTERED 
(
	[medicalRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PracinicalCategory]    Script Date: 7/17/2023 3:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PracinicalCategory](
	[pracinicalCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[pracinicalCategoryName] [nvarchar](50) NULL,
	[desctiption] [text] NULL,
	[departmentId] [int] NOT NULL,
	[created_by] [int] NULL,
	[created_date] [date] NULL,
 CONSTRAINT [PK_PracinicalCategory] PRIMARY KEY CLUSTERED 
(
	[pracinicalCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PracinicalService]    Script Date: 7/17/2023 3:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PracinicalService](
	[pracinicalServiceId] [int] IDENTITY(1,1) NOT NULL,
	[categoryId] [int] NOT NULL,
	[serviceName] [nvarchar](100) NULL,
	[serviceDescription] [text] NULL,
	[price] [money] NULL,
 CONSTRAINT [PK_PracinicalService] PRIMARY KEY CLUSTERED 
(
	[pracinicalServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/17/2023 3:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[roleId] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [ddddd] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [ddddd]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Account] FOREIGN KEY([accountId])
REFERENCES [dbo].[Account] ([accountId])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Account]
GO
ALTER TABLE [dbo].[ExaminationForm]  WITH CHECK ADD  CONSTRAINT [FK_ExaminationForm_Account] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Account] ([accountId])
GO
ALTER TABLE [dbo].[ExaminationForm] CHECK CONSTRAINT [FK_ExaminationForm_Account]
GO
ALTER TABLE [dbo].[ExaminationForm]  WITH CHECK ADD  CONSTRAINT [FK_ExaminationForm_Doctor] FOREIGN KEY([DoctorCode])
REFERENCES [dbo].[Doctor] ([code])
GO
ALTER TABLE [dbo].[ExaminationForm] CHECK CONSTRAINT [FK_ExaminationForm_Doctor]
GO
ALTER TABLE [dbo].[ExaminationResult]  WITH CHECK ADD  CONSTRAINT [FK_ExaminationResult_Doctor] FOREIGN KEY([doctorId])
REFERENCES [dbo].[Doctor] ([code])
GO
ALTER TABLE [dbo].[ExaminationResult] CHECK CONSTRAINT [FK_ExaminationResult_Doctor]
GO
ALTER TABLE [dbo].[ExaminationResult]  WITH CHECK ADD  CONSTRAINT [FK_ExaminationResult_MedicalRecord] FOREIGN KEY([medicalRecord])
REFERENCES [dbo].[MedicalRecord] ([medicalRecordId])
GO
ALTER TABLE [dbo].[ExaminationResult] CHECK CONSTRAINT [FK_ExaminationResult_MedicalRecord]
GO
ALTER TABLE [dbo].[ExaminationResult]  WITH CHECK ADD  CONSTRAINT [FK_ExaminationResult_PracinicalService] FOREIGN KEY([serviceId])
REFERENCES [dbo].[PracinicalService] ([pracinicalServiceId])
GO
ALTER TABLE [dbo].[ExaminationResult] CHECK CONSTRAINT [FK_ExaminationResult_PracinicalService]
GO
ALTER TABLE [dbo].[MedicalRecord]  WITH CHECK ADD  CONSTRAINT [FK_MedicalRecord_Account] FOREIGN KEY([patientId])
REFERENCES [dbo].[Account] ([accountId])
GO
ALTER TABLE [dbo].[MedicalRecord] CHECK CONSTRAINT [FK_MedicalRecord_Account]
GO
ALTER TABLE [dbo].[PracinicalCategory]  WITH CHECK ADD  CONSTRAINT [ddddddddddddddddddddd] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([departmentID])
GO
ALTER TABLE [dbo].[PracinicalCategory] CHECK CONSTRAINT [ddddddddddddddddddddd]
GO
ALTER TABLE [dbo].[PracinicalService]  WITH CHECK ADD  CONSTRAINT [FK_PracinicalService_PracinicalCategory] FOREIGN KEY([categoryId])
REFERENCES [dbo].[PracinicalCategory] ([pracinicalCategoryId])
GO
ALTER TABLE [dbo].[PracinicalService] CHECK CONSTRAINT [FK_PracinicalService_PracinicalCategory]
GO
USE [master]
GO
ALTER DATABASE [SWD392_FinalProject] SET  READ_WRITE 
GO

INSERT INTO Role
VALUES ('patient'), ('doctor'), ('manager')


INSERT INTO Account(email, password, roleId, name)
VALUES ('hospitalpatient@gmail.com', '123456789', 1, 'Patient'),
('hospitaldoctor@gmail.com', '123456789', 2, 'Doctor'),
('hospitalmanager@gmail.com', '123456789', 3, 'Manager')