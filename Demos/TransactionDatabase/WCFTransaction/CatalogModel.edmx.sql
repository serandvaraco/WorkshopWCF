
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/03/2018 07:45:16
-- Generated from EDMX file: c:\users\nivel pro\source\repos\WCFTransaction\WCFTransaction\CatalogModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CookieCompanyDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

DROP TABLE PRODUCT; 

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(50)  NOT NULL,
    [Image] nvarchar(max)  NULL
);
GO

-- Creating table 'Product_ProductDetails'
CREATE TABLE [dbo].[Product_ProductDetails] (
    [Color] nvarchar(max)  NOT NULL,
    [Size] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Product_ProductDetails'
ALTER TABLE [dbo].[Product_ProductDetails]
ADD CONSTRAINT [PK_Product_ProductDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id] in table 'Product_ProductDetails'
ALTER TABLE [dbo].[Product_ProductDetails]
ADD CONSTRAINT [FK_ProductDetails_inherits_Product]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Product]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------