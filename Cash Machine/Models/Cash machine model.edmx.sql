
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/16/2016 17:03:46
-- Generated from EDMX file: C:\Users\bonda\OneDrive\Work\Cash Machine\Cash Machine\Views\Home\Cash machine model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dataart-cash-machine];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CardCardOperation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CardOperationSet] DROP CONSTRAINT [FK_CardCardOperation];
GO
IF OBJECT_ID(N'[dbo].[FK_OperationTypeCardOperation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CardOperationSet] DROP CONSTRAINT [FK_OperationTypeCardOperation];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CardSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CardSet];
GO
IF OBJECT_ID(N'[dbo].[CardOperationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CardOperationSet];
GO
IF OBJECT_ID(N'[dbo].[OperationTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OperationTypeSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CardSet'
CREATE TABLE [dbo].[CardSet] (
    [Id] uniqueidentifier  NOT NULL,
    [IsBlocked] bit  NOT NULL,
    [Balance] decimal(18,0)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Number] nvarchar(max)  NULL
);
GO

-- Creating table 'CardOperationSet'
CREATE TABLE [dbo].[CardOperationSet] (
    [Id] uniqueidentifier  NOT NULL,
    [CardId] uniqueidentifier  NOT NULL,
    [OperationTypeId] uniqueidentifier  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'OperationTypeSet'
CREATE TABLE [dbo].[OperationTypeSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CardSet'
ALTER TABLE [dbo].[CardSet]
ADD CONSTRAINT [PK_CardSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CardOperationSet'
ALTER TABLE [dbo].[CardOperationSet]
ADD CONSTRAINT [PK_CardOperationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OperationTypeSet'
ALTER TABLE [dbo].[OperationTypeSet]
ADD CONSTRAINT [PK_OperationTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CardId] in table 'CardOperationSet'
ALTER TABLE [dbo].[CardOperationSet]
ADD CONSTRAINT [FK_CardCardOperation]
    FOREIGN KEY ([CardId])
    REFERENCES [dbo].[CardSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CardCardOperation'
CREATE INDEX [IX_FK_CardCardOperation]
ON [dbo].[CardOperationSet]
    ([CardId]);
GO

-- Creating foreign key on [OperationTypeId] in table 'CardOperationSet'
ALTER TABLE [dbo].[CardOperationSet]
ADD CONSTRAINT [FK_OperationTypeCardOperation]
    FOREIGN KEY ([OperationTypeId])
    REFERENCES [dbo].[OperationTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OperationTypeCardOperation'
CREATE INDEX [IX_FK_OperationTypeCardOperation]
ON [dbo].[CardOperationSet]
    ([OperationTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------