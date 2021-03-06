USE [master]
GO
/****** Object:  User [##MS_PolicyEventProcessingLogin##]    Script Date: 6/23/2019 12:01:16 AM ******/
CREATE USER [##MS_PolicyEventProcessingLogin##] FOR LOGIN [##MS_PolicyEventProcessingLogin##] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [##MS_AgentSigningCertificate##]    Script Date: 6/23/2019 12:01:16 AM ******/
CREATE USER [##MS_AgentSigningCertificate##] FOR LOGIN [##MS_AgentSigningCertificate##]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/23/2019 12:01:16 AM ******/
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
/****** Object:  Table [dbo].[DayMuscles]    Script Date: 6/23/2019 12:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DayMuscles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DayID] [int] NOT NULL,
	[MuscleID] [int] NULL,
 CONSTRAINT [PK_DayMuscles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Days]    Script Date: 6/23/2019 12:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Days](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsRest] [bit] NOT NULL,
 CONSTRAINT [PK_Days] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExerciseMuscles]    Script Date: 6/23/2019 12:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseMuscles](
	[ExerciseMuscleID] [int] IDENTITY(1,1) NOT NULL,
	[MuscleID] [int] NOT NULL,
	[percentInvolvement] [int] NOT NULL,
	[ExerciseID] [int] NOT NULL,
 CONSTRAINT [PK_ExerciseMuscles] PRIMARY KEY CLUSTERED 
(
	[ExerciseMuscleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exercises]    Script Date: 6/23/2019 12:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exercises](
	[ExerciseID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ExerciseType] [int] NOT NULL,
	[IsCompound] [bit] NOT NULL,
 CONSTRAINT [PK_Exercises] PRIMARY KEY CLUSTERED 
(
	[ExerciseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Muscles]    Script Date: 6/23/2019 12:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Muscles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Size] [int] NOT NULL,
 CONSTRAINT [PK_Muscles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SplitDays]    Script Date: 6/23/2019 12:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SplitDays](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SplitID] [int] NOT NULL,
	[DayID] [int] NOT NULL,
 CONSTRAINT [PK_SplitDays] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Splits]    Script Date: 6/23/2019 12:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Splits](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Frequency] [int] NOT NULL,
 CONSTRAINT [PK_Splits] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_DayMuscles_DayID]    Script Date: 6/23/2019 12:01:16 AM ******/
CREATE NONCLUSTERED INDEX [IX_DayMuscles_DayID] ON [dbo].[DayMuscles]
(
	[DayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DayMuscles_MuscleID]    Script Date: 6/23/2019 12:01:16 AM ******/
CREATE NONCLUSTERED INDEX [IX_DayMuscles_MuscleID] ON [dbo].[DayMuscles]
(
	[MuscleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExerciseMuscles_ExerciseID]    Script Date: 6/23/2019 12:01:16 AM ******/
CREATE NONCLUSTERED INDEX [IX_ExerciseMuscles_ExerciseID] ON [dbo].[ExerciseMuscles]
(
	[ExerciseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExerciseMuscles_MuscleID]    Script Date: 6/23/2019 12:01:16 AM ******/
CREATE NONCLUSTERED INDEX [IX_ExerciseMuscles_MuscleID] ON [dbo].[ExerciseMuscles]
(
	[MuscleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SplitDays_DayID]    Script Date: 6/23/2019 12:01:16 AM ******/
CREATE NONCLUSTERED INDEX [IX_SplitDays_DayID] ON [dbo].[SplitDays]
(
	[DayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SplitDays_SplitID]    Script Date: 6/23/2019 12:01:16 AM ******/
CREATE NONCLUSTERED INDEX [IX_SplitDays_SplitID] ON [dbo].[SplitDays]
(
	[SplitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Muscles] ADD  DEFAULT ((0)) FOR [Size]
GO
ALTER TABLE [dbo].[Splits] ADD  DEFAULT ((0)) FOR [Frequency]
GO
ALTER TABLE [dbo].[DayMuscles]  WITH CHECK ADD  CONSTRAINT [FK_DayMuscles_Days_DayID] FOREIGN KEY([DayID])
REFERENCES [dbo].[Days] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DayMuscles] CHECK CONSTRAINT [FK_DayMuscles_Days_DayID]
GO
ALTER TABLE [dbo].[DayMuscles]  WITH CHECK ADD  CONSTRAINT [FK_DayMuscles_Muscles_MuscleID] FOREIGN KEY([MuscleID])
REFERENCES [dbo].[Muscles] ([ID])
GO
ALTER TABLE [dbo].[DayMuscles] CHECK CONSTRAINT [FK_DayMuscles_Muscles_MuscleID]
GO
ALTER TABLE [dbo].[ExerciseMuscles]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseMuscles_Exercises_ExerciseID] FOREIGN KEY([ExerciseID])
REFERENCES [dbo].[Exercises] ([ExerciseID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExerciseMuscles] CHECK CONSTRAINT [FK_ExerciseMuscles_Exercises_ExerciseID]
GO
ALTER TABLE [dbo].[ExerciseMuscles]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseMuscles_Muscles_MuscleID] FOREIGN KEY([MuscleID])
REFERENCES [dbo].[Muscles] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExerciseMuscles] CHECK CONSTRAINT [FK_ExerciseMuscles_Muscles_MuscleID]
GO
ALTER TABLE [dbo].[SplitDays]  WITH CHECK ADD  CONSTRAINT [FK_SplitDays_Days_DayID] FOREIGN KEY([DayID])
REFERENCES [dbo].[Days] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SplitDays] CHECK CONSTRAINT [FK_SplitDays_Days_DayID]
GO
ALTER TABLE [dbo].[SplitDays]  WITH CHECK ADD  CONSTRAINT [FK_SplitDays_Splits_SplitID] FOREIGN KEY([SplitID])
REFERENCES [dbo].[Splits] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SplitDays] CHECK CONSTRAINT [FK_SplitDays_Splits_SplitID]
GO
