
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/23/2022 21:52:42
-- Generated from EDMX file: D:\Visual Stedio\ProjectNet\ProjectNet\Modele\EnitModele.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjectDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DepartementClasse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Classes] DROP CONSTRAINT [FK_DepartementClasse];
GO
IF OBJECT_ID(N'[dbo].[FK_ClasseEtudiant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Etudiants] DROP CONSTRAINT [FK_ClasseEtudiant];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Departements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departements];
GO
IF OBJECT_ID(N'[dbo].[Classes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Classes];
GO
IF OBJECT_ID(N'[dbo].[Etudiants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Etudiants];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Departements'
CREATE TABLE [dbo].[Departements] (
    [IdDep] nvarchar(max)  NOT NULL,
    [NameDep] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Classes'
CREATE TABLE [dbo].[Classes] (
    [IdCl] nvarchar(max)  NOT NULL,
    [NameCl] nvarchar(max)  NOT NULL,
    [DepartementIdDep] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Etudiants'
CREATE TABLE [dbo].[Etudiants] (
    [IdEt] int IDENTITY(1,1) NOT NULL,
    [CIN] nvarchar(max)  NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Prénom] nvarchar(max)  NOT NULL,
    [ClasseIdCl] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdDep] in table 'Departements'
ALTER TABLE [dbo].[Departements]
ADD CONSTRAINT [PK_Departements]
    PRIMARY KEY CLUSTERED ([IdDep] ASC);
GO

-- Creating primary key on [IdCl] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [PK_Classes]
    PRIMARY KEY CLUSTERED ([IdCl] ASC);
GO

-- Creating primary key on [IdEt] in table 'Etudiants'
ALTER TABLE [dbo].[Etudiants]
ADD CONSTRAINT [PK_Etudiants]
    PRIMARY KEY CLUSTERED ([IdEt] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DepartementIdDep] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [FK_DepartementClasse]
    FOREIGN KEY ([DepartementIdDep])
    REFERENCES [dbo].[Departements]
        ([IdDep])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartementClasse'
CREATE INDEX [IX_FK_DepartementClasse]
ON [dbo].[Classes]
    ([DepartementIdDep]);
GO

-- Creating foreign key on [ClasseIdCl] in table 'Etudiants'
ALTER TABLE [dbo].[Etudiants]
ADD CONSTRAINT [FK_ClasseEtudiant]
    FOREIGN KEY ([ClasseIdCl])
    REFERENCES [dbo].[Classes]
        ([IdCl])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClasseEtudiant'
CREATE INDEX [IX_FK_ClasseEtudiant]
ON [dbo].[Etudiants]
    ([ClasseIdCl]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------