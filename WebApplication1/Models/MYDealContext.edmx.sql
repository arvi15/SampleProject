
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/05/2016 08:54:48
-- Generated from EDMX file: C:\Users\aravind\Documents\Visual Studio 2013\Projects\GetWeatherDetails_old\WebApplication1\WebApplication1\Models\MYDealContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyDealDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PNL_ToFileList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PNL] DROP CONSTRAINT [FK_PNL_ToFileList];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FileList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileList];
GO
IF OBJECT_ID(N'[dbo].[PNL]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PNL];
GO
IF OBJECT_ID(N'[dbo].[URLMapper]', 'U') IS NOT NULL
    DROP TABLE [dbo].[URLMapper];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'URLMappers'
CREATE TABLE [dbo].[URLMappers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [shortURL] varchar(100)  NULL,
    [longUrl] varchar(500)  NULL
);
GO

-- Creating table 'FileLists'
CREATE TABLE [dbo].[FileLists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileName] varchar(50)  NULL
);
GO

-- Creating table 'PNLs'
CREATE TABLE [dbo].[PNLs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [pnlType] varchar(50)  NULL,
    [name] varchar(50)  NULL,
    [key] varchar(50)  NULL,
    [booking] varchar(50)  NULL,
    [FileListId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'URLMappers'
ALTER TABLE [dbo].[URLMappers]
ADD CONSTRAINT [PK_URLMappers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FileLists'
ALTER TABLE [dbo].[FileLists]
ADD CONSTRAINT [PK_FileLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PNLs'
ALTER TABLE [dbo].[PNLs]
ADD CONSTRAINT [PK_PNLs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FileListId] in table 'PNLs'
ALTER TABLE [dbo].[PNLs]
ADD CONSTRAINT [FK_FileListPNL]
    FOREIGN KEY ([FileListId])
    REFERENCES [dbo].[FileLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileListPNL'
CREATE INDEX [IX_FK_FileListPNL]
ON [dbo].[PNLs]
    ([FileListId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------