/* ---------------------------------------------------- */
/*  Generated by Enterprise Architect Version 13.0 		*/
/*  Created On : 03-kv�-2021 14:33:18 				*/
/*  DBMS       : SQL Server 2012 						*/
/* ---------------------------------------------------- */

/* Drop Foreign Key Constraints */

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_GenreMix_Movie]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Genremix] DROP CONSTRAINT [FK_GenreMix_Movie]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_GenreMix_Genre]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Genremix] DROP CONSTRAINT [FK_GenreMix_Genre]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Rating_Review]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Rating] DROP CONSTRAINT [FK_Rating_Review]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Report_User]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Report] DROP CONSTRAINT [FK_Report_User]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Review_Comment]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Review] DROP CONSTRAINT [FK_Review_Comment]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Review_Movie]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Review] DROP CONSTRAINT [FK_Review_Movie]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Review_User]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Review] DROP CONSTRAINT [FK_Review_User]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Role_Movie]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Role] DROP CONSTRAINT [FK_Role_Movie]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Role_Cast]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Role] DROP CONSTRAINT [FK_Role_Cast]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_User_Permission]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [User] DROP CONSTRAINT [FK_User_Permission]
GO

/* Drop Tables */

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Cast]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Cast]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Comment]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Comment]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Genre]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Genre]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Genremix]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Genremix]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Movie]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Movie]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Permission]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Permission]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Rating]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Rating]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Report]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Report]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Review]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Review]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Role]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Role]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[User]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [User]
GO

/* Create Tables */

CREATE TABLE [Cast]
(
	[CastID] decimal(8,0) NOT NULL IDENTITY,
	[Name] varchar(15) NOT NULL,
	[Surname] varchar(15) NOT NULL,
	[Age] decimal(2,1) NOT NULL
)
GO

CREATE TABLE [Comment]
(
	[CommentID] decimal(8,0) NOT NULL IDENTITY,
	[Content] text NOT NULL
)
GO

CREATE TABLE [Genre]
(
	[GenreID] decimal(8,0) NOT NULL IDENTITY,
	[Name] varchar(50) NOT NULL
)
GO

CREATE TABLE [Genremix]
(
	[GenremixID] decimal(8,0) NOT NULL IDENTITY,
	[MovieID] decimal(8,0) NOT NULL,
	[GenreID] decimal(8,0) NOT NULL
)
GO

CREATE TABLE [Movie]
(
	[MovieID] decimal(8,0) NOT NULL IDENTITY,
	[Name] varchar(50) NOT NULL,
	[Releasedate] datetime NOT NULL
)
GO

CREATE TABLE [Permission]
(
	[PermissionID] decimal(8,0) NOT NULL IDENTITY,
	[Privilege] varchar(15) NOT NULL
)
GO

CREATE TABLE [Rating]
(
	[RatingID] decimal(8,0) NOT NULL IDENTITY,
	[ReviewID] decimal(8,0) NOT NULL,
	[Numberrating] decimal(3,0) NOT NULL
)
GO

CREATE TABLE [Report]
(
	[ReportID] decimal(8,0) NOT NULL IDENTITY,
	[UserID] decimal(8,0) NULL,
	[Message] varchar(256) NULL,
	[Name] varchar(32) NULL
)
GO

CREATE TABLE [Review]
(
	[ReviewID] decimal(8,0) NOT NULL IDENTITY,
	[UserID] decimal(8,0) NOT NULL,
	[CommentID] decimal(8,0) NOT NULL,
	[MovieID] decimal(8,0) NOT NULL,
	[Datecreated] datetime NOT NULL
)
GO

CREATE TABLE [Role]
(
	[RoleID] decimal(8,0) NOT NULL IDENTITY,
	[MovieID] decimal(8,0) NOT NULL,
	[CastID] decimal(8,0) NOT NULL,
	[Salary] decimal(8,0) NOT NULL,
	[Name] varchar(30) NOT NULL
)
GO

CREATE TABLE [User]
(
	[UserID] decimal(8,0) NOT NULL IDENTITY,
	[PermissionID] decimal(8,0) NOT NULL,
	[Username] varchar(10) NOT NULL,
	[Name] varchar(50) NOT NULL,
	[Surname] varchar(50) NOT NULL,
	[Password] varchar(50) NOT NULL,
	[Karma] decimal(4,0) NULL
)
GO

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [Cast] 
 ADD CONSTRAINT [PK_Cast]
	PRIMARY KEY CLUSTERED ([CastID] ASC)
GO

ALTER TABLE [Comment] 
 ADD CONSTRAINT [PK_Comment]
	PRIMARY KEY CLUSTERED ([CommentID] ASC)
GO

ALTER TABLE [Genre] 
 ADD CONSTRAINT [PK_Genre]
	PRIMARY KEY CLUSTERED ([GenreID] ASC)
GO

ALTER TABLE [Genremix] 
 ADD CONSTRAINT [PK_Genremix]
	PRIMARY KEY CLUSTERED ([GenremixID] ASC)
GO

ALTER TABLE [Movie] 
 ADD CONSTRAINT [PK_Movie]
	PRIMARY KEY CLUSTERED ([MovieID] ASC)
GO

ALTER TABLE [Permission] 
 ADD CONSTRAINT [PK_Permission]
	PRIMARY KEY CLUSTERED ([PermissionID] ASC)
GO

ALTER TABLE [Rating] 
 ADD CONSTRAINT [PK_Rating]
	PRIMARY KEY CLUSTERED ([RatingID] ASC)
GO

ALTER TABLE [Report] 
 ADD CONSTRAINT [PK_Report]
	PRIMARY KEY CLUSTERED ([ReportID] ASC)
GO

ALTER TABLE [Review] 
 ADD CONSTRAINT [PK_Review]
	PRIMARY KEY CLUSTERED ([ReviewID] ASC)
GO

ALTER TABLE [Role] 
 ADD CONSTRAINT [PK_Role]
	PRIMARY KEY CLUSTERED ([RoleID] ASC)
GO

ALTER TABLE [User] 
 ADD CONSTRAINT [PK_User]
	PRIMARY KEY CLUSTERED ([UserID] ASC)
GO

/* Create Foreign Key Constraints */

ALTER TABLE [Genremix] ADD CONSTRAINT [FK_GenreMix_Movie]
	FOREIGN KEY ([MovieID]) REFERENCES [Movie] ([MovieID]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Genremix] ADD CONSTRAINT [FK_GenreMix_Genre]
	FOREIGN KEY ([GenreID]) REFERENCES [Genre] ([GenreID]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Rating] ADD CONSTRAINT [FK_Rating_Review]
	FOREIGN KEY ([ReviewID]) REFERENCES [Review] ([ReviewID]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Report] ADD CONSTRAINT [FK_Report_User]
	FOREIGN KEY ([UserID]) REFERENCES [User] ([UserID]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Review] ADD CONSTRAINT [FK_Review_Comment]
	FOREIGN KEY ([CommentID]) REFERENCES [Comment] ([CommentID]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Review] ADD CONSTRAINT [FK_Review_Movie]
	FOREIGN KEY ([MovieID]) REFERENCES [Movie] ([MovieID]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Review] ADD CONSTRAINT [FK_Review_User]
	FOREIGN KEY ([UserID]) REFERENCES [User] ([UserID]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Role] ADD CONSTRAINT [FK_Role_Movie]
	FOREIGN KEY ([MovieID]) REFERENCES [Movie] ([MovieID]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Role] ADD CONSTRAINT [FK_Role_Cast]
	FOREIGN KEY ([CastID]) REFERENCES [Cast] ([CastID]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [User] ADD CONSTRAINT [FK_User_Permission]
	FOREIGN KEY ([PermissionID]) REFERENCES [Permission] ([PermissionID]) ON DELETE No Action ON UPDATE No Action
GO
