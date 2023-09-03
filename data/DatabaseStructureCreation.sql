
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/03/2023 13:45:27
-- Generated from EDMX file: C:\projects\personal\GestionZafra\GestionZafra\Models\ZafraModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [gescor];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FKCampo161005]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Campo] DROP CONSTRAINT [FK_FKCampo161005];
GO
IF OBJECT_ID(N'[dbo].[FK_FKCampo53335]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Campo] DROP CONSTRAINT [FK_FKCampo53335];
GO
IF OBJECT_ID(N'[dbo].[FK_FKDiarioEqui334875]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiarioEquiposZafra] DROP CONSTRAINT [FK_FKDiarioEqui334875];
GO
IF OBJECT_ID(N'[dbo].[FK_FKDiarioEqui435805]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiarioEquiposZafra] DROP CONSTRAINT [FK_FKDiarioEqui435805];
GO
IF OBJECT_ID(N'[dbo].[FK_FKDiarioEqui859692]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiarioEquiposZafra] DROP CONSTRAINT [FK_FKDiarioEqui859692];
GO
IF OBJECT_ID(N'[dbo].[FK_FKDiarioOper100899]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiarioOperadorCombinadas] DROP CONSTRAINT [FK_FKDiarioOper100899];
GO
IF OBJECT_ID(N'[dbo].[FK_FKDiarioOper578327]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiarioOperadorCombinadas] DROP CONSTRAINT [FK_FKDiarioOper578327];
GO
IF OBJECT_ID(N'[dbo].[FK_FKDiarioOper626817]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiarioOperadorCombinadas] DROP CONSTRAINT [FK_FKDiarioOper626817];
GO
IF OBJECT_ID(N'[dbo].[FK_FKDiarioOper822334]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiarioOperadorCombinadas] DROP CONSTRAINT [FK_FKDiarioOper822334];
GO
IF OBJECT_ID(N'[dbo].[FK_FKDiarioOper897999]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiarioOperadorCombinadas] DROP CONSTRAINT [FK_FKDiarioOper897999];
GO
IF OBJECT_ID(N'[dbo].[FK_FKOperadorCo455168]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OperadorCombinada] DROP CONSTRAINT [FK_FKOperadorCo455168];
GO
IF OBJECT_ID(N'[dbo].[FK_FKOperadorCo809279]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OperadorCombinada] DROP CONSTRAINT [FK_FKOperadorCo809279];
GO
IF OBJECT_ID(N'[dbo].[FK_FKParqueEqui172425]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParqueEquipos] DROP CONSTRAINT [FK_FKParqueEqui172425];
GO
IF OBJECT_ID(N'[dbo].[FK_FKParqueEqui70865]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParqueEquipos] DROP CONSTRAINT [FK_FKParqueEqui70865];
GO
IF OBJECT_ID(N'[dbo].[FK_FKPelotonCom54014]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PelotonCombinadas] DROP CONSTRAINT [FK_FKPelotonCom54014];
GO
IF OBJECT_ID(N'[dbo].[FK_FKPlanEquipo297757]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEquiposAgricZafra] DROP CONSTRAINT [FK_FKPlanEquipo297757];
GO
IF OBJECT_ID(N'[dbo].[FK_FKPlanEquipo352056]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEquiposAgricZafra] DROP CONSTRAINT [FK_FKPlanEquipo352056];
GO
IF OBJECT_ID(N'[dbo].[FK_FKPlanEquipo587695]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEquiposAgricZafra] DROP CONSTRAINT [FK_FKPlanEquipo587695];
GO
IF OBJECT_ID(N'[dbo].[FK_FKPlanOperad22800]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanOperadoresCombinadas] DROP CONSTRAINT [FK_FKPlanOperad22800];
GO
IF OBJECT_ID(N'[dbo].[FK_FKPlanOperad482811]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanOperadoresCombinadas] DROP CONSTRAINT [FK_FKPlanOperad482811];
GO
IF OBJECT_ID(N'[dbo].[FK_FKPlanOperad741560]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanOperadoresCombinadas] DROP CONSTRAINT [FK_FKPlanOperad741560];
GO
IF OBJECT_ID(N'[dbo].[FK_FKSuministra562195]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Suministradores] DROP CONSTRAINT [FK_FKSuministra562195];
GO
IF OBJECT_ID(N'[dbo].[FK_FKUsuario38509]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_FKUsuario38509];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Campo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Campo];
GO
IF OBJECT_ID(N'[dbo].[CentrosRecepcion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CentrosRecepcion];
GO
IF OBJECT_ID(N'[dbo].[DiarioEquiposZafra]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DiarioEquiposZafra];
GO
IF OBJECT_ID(N'[dbo].[DiarioOperadorCombinadas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DiarioOperadorCombinadas];
GO
IF OBJECT_ID(N'[dbo].[EstadoEquipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoEquipo];
GO
IF OBJECT_ID(N'[dbo].[MarcasCombinadas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarcasCombinadas];
GO
IF OBJECT_ID(N'[dbo].[OperadorCombinada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OperadorCombinada];
GO
IF OBJECT_ID(N'[dbo].[ParametrosGenerales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParametrosGenerales];
GO
IF OBJECT_ID(N'[dbo].[ParqueEquipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParqueEquipos];
GO
IF OBJECT_ID(N'[dbo].[PelotonCombinadas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PelotonCombinadas];
GO
IF OBJECT_ID(N'[dbo].[PlanEquiposAgricZafra]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanEquiposAgricZafra];
GO
IF OBJECT_ID(N'[dbo].[PlanOperadoresCombinadas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanOperadoresCombinadas];
GO
IF OBJECT_ID(N'[dbo].[Rol]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rol];
GO
IF OBJECT_ID(N'[dbo].[Suministradores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Suministradores];
GO
IF OBJECT_ID(N'[dbo].[TipoEquipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoEquipos];
GO
IF OBJECT_ID(N'[dbo].[TiposSectorPropiedad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TiposSectorPropiedad];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[VariedadCana]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VariedadCana];
GO
IF OBJECT_ID(N'[dbo].[Zafras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zafras];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Campo'
CREATE TABLE [dbo].[Campo] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Suministradoresid] int  NOT NULL,
    [VariedadCanaid] int  NOT NULL,
    [cepa] varchar(50)  NOT NULL,
    [cantCanaVerde] decimal(19,2)  NOT NULL,
    [cantCanaQuemada] decimal(19,2)  NOT NULL
);
GO

-- Creating table 'CentrosRecepcion'
CREATE TABLE [dbo].[CentrosRecepcion] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombreCentroRecepcion] varchar(100)  NOT NULL
);
GO

-- Creating table 'DiarioEquiposZafra'
CREATE TABLE [dbo].[DiarioEquiposZafra] (
    [PlanEquiposAgricZafraid] int  NOT NULL,
    [fecha] datetime  NOT NULL,
    [arrobasTiradas] decimal(19,2)  NOT NULL,
    [parqueParado] int  NOT NULL,
    [Usuarioid] int  NOT NULL,
    [Zafrasid] int  NOT NULL
);
GO

-- Creating table 'DiarioOperadorCombinadas'
CREATE TABLE [dbo].[DiarioOperadorCombinadas] (
    [PlanOperadoresCombinadasid] int  NOT NULL,
    [fecha] datetime  NOT NULL,
    [Campoid] int  NOT NULL,
    [EstadoEquipoid] int  NOT NULL,
    [cantQuemada] decimal(19,2)  NOT NULL,
    [cantQuemadaProgram] decimal(19,2)  NOT NULL,
    [cantVerde] decimal(19,2)  NOT NULL,
    [Usuarioid] int  NOT NULL,
    [Zafrasid] int  NOT NULL
);
GO

-- Creating table 'EstadoEquipo'
CREATE TABLE [dbo].[EstadoEquipo] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombreEstado] varchar(10)  NOT NULL
);
GO

-- Creating table 'MarcasCombinadas'
CREATE TABLE [dbo].[MarcasCombinadas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombreCombinada] varchar(50)  NOT NULL
);
GO

-- Creating table 'OperadorCombinada'
CREATE TABLE [dbo].[OperadorCombinada] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombreOperador] varchar(255)  NOT NULL,
    [MarcasCombinadasid] int  NOT NULL,
    [PelotonCombinadasid] int  NOT NULL,
    [activo] bit  NOT NULL
);
GO

-- Creating table 'ParametrosGenerales'
CREATE TABLE [dbo].[ParametrosGenerales] (
    [codigoEmpresa] int IDENTITY(1,1) NOT NULL,
    [nombreEmpresa] varchar(255)  NOT NULL,
    [fechaActual] datetime  NOT NULL,
    [zafraAct] int  NOT NULL
);
GO

-- Creating table 'ParqueEquipos'
CREATE TABLE [dbo].[ParqueEquipos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Suministradoresid] int  NOT NULL,
    [TipoEquiposid] int  NOT NULL,
    [cantidadEquipos] int  NOT NULL
);
GO

-- Creating table 'PelotonCombinadas'
CREATE TABLE [dbo].[PelotonCombinadas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Suministradoresid] int  NOT NULL,
    [parque] int  NOT NULL
);
GO

-- Creating table 'PlanEquiposAgricZafra'
CREATE TABLE [dbo].[PlanEquiposAgricZafra] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ParqueEquiposid] int  NOT NULL,
    [parqueAsignado] int  NOT NULL,
    [tareaDiaria] decimal(19,2)  NOT NULL,
    [CentrosRecepcionid] int  NOT NULL,
    [Zafrasid] int  NOT NULL
);
GO

-- Creating table 'PlanOperadoresCombinadas'
CREATE TABLE [dbo].[PlanOperadoresCombinadas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [OperadorCombinadaid] int  NOT NULL,
    [tareaDiaria] decimal(19,2)  NOT NULL,
    [CentrosRecepcionid] int  NOT NULL,
    [Zafrasid] int  NOT NULL
);
GO

-- Creating table 'Rol'
CREATE TABLE [dbo].[Rol] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcionRol] varchar(15)  NOT NULL
);
GO

-- Creating table 'Suministradores'
CREATE TABLE [dbo].[Suministradores] (
    [id] int IDENTITY(1,1) NOT NULL,
    [TiposSectorPropiedadid] int  NOT NULL,
    [nombreSuministrador] varchar(100)  NOT NULL,
    [activo] bit  NULL
);
GO

-- Creating table 'TipoEquipos'
CREATE TABLE [dbo].[TipoEquipos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcionEquipo] varchar(100)  NOT NULL
);
GO

-- Creating table 'TiposSectorPropiedad'
CREATE TABLE [dbo].[TiposSectorPropiedad] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombreTipoSector] varchar(10)  NOT NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombreUsuario] varchar(50)  NOT NULL,
    [Rolid] int  NOT NULL,
    [pass] varchar(255)  NOT NULL,
    [activo] bit  NOT NULL
);
GO

-- Creating table 'VariedadCana'
CREATE TABLE [dbo].[VariedadCana] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombreVariedad] varchar(20)  NOT NULL
);
GO

-- Creating table 'Zafras'
CREATE TABLE [dbo].[Zafras] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcionZafra] varchar(9)  NOT NULL,
    [fechaInicio] datetime  NOT NULL,
    [fechaFin] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Campo'
ALTER TABLE [dbo].[Campo]
ADD CONSTRAINT [PK_Campo]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CentrosRecepcion'
ALTER TABLE [dbo].[CentrosRecepcion]
ADD CONSTRAINT [PK_CentrosRecepcion]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [PlanEquiposAgricZafraid], [fecha] in table 'DiarioEquiposZafra'
ALTER TABLE [dbo].[DiarioEquiposZafra]
ADD CONSTRAINT [PK_DiarioEquiposZafra]
    PRIMARY KEY CLUSTERED ([PlanEquiposAgricZafraid], [fecha] ASC);
GO

-- Creating primary key on [PlanOperadoresCombinadasid], [fecha] in table 'DiarioOperadorCombinadas'
ALTER TABLE [dbo].[DiarioOperadorCombinadas]
ADD CONSTRAINT [PK_DiarioOperadorCombinadas]
    PRIMARY KEY CLUSTERED ([PlanOperadoresCombinadasid], [fecha] ASC);
GO

-- Creating primary key on [id] in table 'EstadoEquipo'
ALTER TABLE [dbo].[EstadoEquipo]
ADD CONSTRAINT [PK_EstadoEquipo]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MarcasCombinadas'
ALTER TABLE [dbo].[MarcasCombinadas]
ADD CONSTRAINT [PK_MarcasCombinadas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'OperadorCombinada'
ALTER TABLE [dbo].[OperadorCombinada]
ADD CONSTRAINT [PK_OperadorCombinada]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [codigoEmpresa] in table 'ParametrosGenerales'
ALTER TABLE [dbo].[ParametrosGenerales]
ADD CONSTRAINT [PK_ParametrosGenerales]
    PRIMARY KEY CLUSTERED ([codigoEmpresa] ASC);
GO

-- Creating primary key on [id] in table 'ParqueEquipos'
ALTER TABLE [dbo].[ParqueEquipos]
ADD CONSTRAINT [PK_ParqueEquipos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PelotonCombinadas'
ALTER TABLE [dbo].[PelotonCombinadas]
ADD CONSTRAINT [PK_PelotonCombinadas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PlanEquiposAgricZafra'
ALTER TABLE [dbo].[PlanEquiposAgricZafra]
ADD CONSTRAINT [PK_PlanEquiposAgricZafra]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PlanOperadoresCombinadas'
ALTER TABLE [dbo].[PlanOperadoresCombinadas]
ADD CONSTRAINT [PK_PlanOperadoresCombinadas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Rol'
ALTER TABLE [dbo].[Rol]
ADD CONSTRAINT [PK_Rol]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Suministradores'
ALTER TABLE [dbo].[Suministradores]
ADD CONSTRAINT [PK_Suministradores]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TipoEquipos'
ALTER TABLE [dbo].[TipoEquipos]
ADD CONSTRAINT [PK_TipoEquipos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TiposSectorPropiedad'
ALTER TABLE [dbo].[TiposSectorPropiedad]
ADD CONSTRAINT [PK_TiposSectorPropiedad]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'VariedadCana'
ALTER TABLE [dbo].[VariedadCana]
ADD CONSTRAINT [PK_VariedadCana]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Zafras'
ALTER TABLE [dbo].[Zafras]
ADD CONSTRAINT [PK_Zafras]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Suministradoresid] in table 'Campo'
ALTER TABLE [dbo].[Campo]
ADD CONSTRAINT [FK_FKCampo161005]
    FOREIGN KEY ([Suministradoresid])
    REFERENCES [dbo].[Suministradores]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKCampo161005'
CREATE INDEX [IX_FK_FKCampo161005]
ON [dbo].[Campo]
    ([Suministradoresid]);
GO

-- Creating foreign key on [VariedadCanaid] in table 'Campo'
ALTER TABLE [dbo].[Campo]
ADD CONSTRAINT [FK_FKCampo53335]
    FOREIGN KEY ([VariedadCanaid])
    REFERENCES [dbo].[VariedadCana]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKCampo53335'
CREATE INDEX [IX_FK_FKCampo53335]
ON [dbo].[Campo]
    ([VariedadCanaid]);
GO

-- Creating foreign key on [Campoid] in table 'DiarioOperadorCombinadas'
ALTER TABLE [dbo].[DiarioOperadorCombinadas]
ADD CONSTRAINT [FK_FKDiarioOper822334]
    FOREIGN KEY ([Campoid])
    REFERENCES [dbo].[Campo]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKDiarioOper822334'
CREATE INDEX [IX_FK_FKDiarioOper822334]
ON [dbo].[DiarioOperadorCombinadas]
    ([Campoid]);
GO

-- Creating foreign key on [CentrosRecepcionid] in table 'PlanEquiposAgricZafra'
ALTER TABLE [dbo].[PlanEquiposAgricZafra]
ADD CONSTRAINT [FK_FKPlanEquipo352056]
    FOREIGN KEY ([CentrosRecepcionid])
    REFERENCES [dbo].[CentrosRecepcion]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKPlanEquipo352056'
CREATE INDEX [IX_FK_FKPlanEquipo352056]
ON [dbo].[PlanEquiposAgricZafra]
    ([CentrosRecepcionid]);
GO

-- Creating foreign key on [CentrosRecepcionid] in table 'PlanOperadoresCombinadas'
ALTER TABLE [dbo].[PlanOperadoresCombinadas]
ADD CONSTRAINT [FK_FKPlanOperad22800]
    FOREIGN KEY ([CentrosRecepcionid])
    REFERENCES [dbo].[CentrosRecepcion]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKPlanOperad22800'
CREATE INDEX [IX_FK_FKPlanOperad22800]
ON [dbo].[PlanOperadoresCombinadas]
    ([CentrosRecepcionid]);
GO

-- Creating foreign key on [Zafrasid] in table 'DiarioEquiposZafra'
ALTER TABLE [dbo].[DiarioEquiposZafra]
ADD CONSTRAINT [FK_FKDiarioEqui334875]
    FOREIGN KEY ([Zafrasid])
    REFERENCES [dbo].[Zafras]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKDiarioEqui334875'
CREATE INDEX [IX_FK_FKDiarioEqui334875]
ON [dbo].[DiarioEquiposZafra]
    ([Zafrasid]);
GO

-- Creating foreign key on [PlanEquiposAgricZafraid] in table 'DiarioEquiposZafra'
ALTER TABLE [dbo].[DiarioEquiposZafra]
ADD CONSTRAINT [FK_FKDiarioEqui435805]
    FOREIGN KEY ([PlanEquiposAgricZafraid])
    REFERENCES [dbo].[PlanEquiposAgricZafra]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Usuarioid] in table 'DiarioEquiposZafra'
ALTER TABLE [dbo].[DiarioEquiposZafra]
ADD CONSTRAINT [FK_FKDiarioEqui859692]
    FOREIGN KEY ([Usuarioid])
    REFERENCES [dbo].[Usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKDiarioEqui859692'
CREATE INDEX [IX_FK_FKDiarioEqui859692]
ON [dbo].[DiarioEquiposZafra]
    ([Usuarioid]);
GO

-- Creating foreign key on [PlanOperadoresCombinadasid] in table 'DiarioOperadorCombinadas'
ALTER TABLE [dbo].[DiarioOperadorCombinadas]
ADD CONSTRAINT [FK_FKDiarioOper100899]
    FOREIGN KEY ([PlanOperadoresCombinadasid])
    REFERENCES [dbo].[PlanOperadoresCombinadas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EstadoEquipoid] in table 'DiarioOperadorCombinadas'
ALTER TABLE [dbo].[DiarioOperadorCombinadas]
ADD CONSTRAINT [FK_FKDiarioOper578327]
    FOREIGN KEY ([EstadoEquipoid])
    REFERENCES [dbo].[EstadoEquipo]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKDiarioOper578327'
CREATE INDEX [IX_FK_FKDiarioOper578327]
ON [dbo].[DiarioOperadorCombinadas]
    ([EstadoEquipoid]);
GO

-- Creating foreign key on [Usuarioid] in table 'DiarioOperadorCombinadas'
ALTER TABLE [dbo].[DiarioOperadorCombinadas]
ADD CONSTRAINT [FK_FKDiarioOper626817]
    FOREIGN KEY ([Usuarioid])
    REFERENCES [dbo].[Usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKDiarioOper626817'
CREATE INDEX [IX_FK_FKDiarioOper626817]
ON [dbo].[DiarioOperadorCombinadas]
    ([Usuarioid]);
GO

-- Creating foreign key on [Zafrasid] in table 'DiarioOperadorCombinadas'
ALTER TABLE [dbo].[DiarioOperadorCombinadas]
ADD CONSTRAINT [FK_FKDiarioOper897999]
    FOREIGN KEY ([Zafrasid])
    REFERENCES [dbo].[Zafras]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKDiarioOper897999'
CREATE INDEX [IX_FK_FKDiarioOper897999]
ON [dbo].[DiarioOperadorCombinadas]
    ([Zafrasid]);
GO

-- Creating foreign key on [MarcasCombinadasid] in table 'OperadorCombinada'
ALTER TABLE [dbo].[OperadorCombinada]
ADD CONSTRAINT [FK_FKOperadorCo455168]
    FOREIGN KEY ([MarcasCombinadasid])
    REFERENCES [dbo].[MarcasCombinadas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKOperadorCo455168'
CREATE INDEX [IX_FK_FKOperadorCo455168]
ON [dbo].[OperadorCombinada]
    ([MarcasCombinadasid]);
GO

-- Creating foreign key on [PelotonCombinadasid] in table 'OperadorCombinada'
ALTER TABLE [dbo].[OperadorCombinada]
ADD CONSTRAINT [FK_FKOperadorCo809279]
    FOREIGN KEY ([PelotonCombinadasid])
    REFERENCES [dbo].[PelotonCombinadas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKOperadorCo809279'
CREATE INDEX [IX_FK_FKOperadorCo809279]
ON [dbo].[OperadorCombinada]
    ([PelotonCombinadasid]);
GO

-- Creating foreign key on [OperadorCombinadaid] in table 'PlanOperadoresCombinadas'
ALTER TABLE [dbo].[PlanOperadoresCombinadas]
ADD CONSTRAINT [FK_FKPlanOperad482811]
    FOREIGN KEY ([OperadorCombinadaid])
    REFERENCES [dbo].[OperadorCombinada]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKPlanOperad482811'
CREATE INDEX [IX_FK_FKPlanOperad482811]
ON [dbo].[PlanOperadoresCombinadas]
    ([OperadorCombinadaid]);
GO

-- Creating foreign key on [zafraAct] in table 'ParametrosGenerales'
ALTER TABLE [dbo].[ParametrosGenerales]
ADD CONSTRAINT [FK_FKParametros205676]
    FOREIGN KEY ([zafraAct])
    REFERENCES [dbo].[Zafras]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKParametros205676'
CREATE INDEX [IX_FK_FKParametros205676]
ON [dbo].[ParametrosGenerales]
    ([zafraAct]);
GO

-- Creating foreign key on [Suministradoresid] in table 'ParqueEquipos'
ALTER TABLE [dbo].[ParqueEquipos]
ADD CONSTRAINT [FK_FKParqueEqui172425]
    FOREIGN KEY ([Suministradoresid])
    REFERENCES [dbo].[Suministradores]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKParqueEqui172425'
CREATE INDEX [IX_FK_FKParqueEqui172425]
ON [dbo].[ParqueEquipos]
    ([Suministradoresid]);
GO

-- Creating foreign key on [TipoEquiposid] in table 'ParqueEquipos'
ALTER TABLE [dbo].[ParqueEquipos]
ADD CONSTRAINT [FK_FKParqueEqui70865]
    FOREIGN KEY ([TipoEquiposid])
    REFERENCES [dbo].[TipoEquipos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKParqueEqui70865'
CREATE INDEX [IX_FK_FKParqueEqui70865]
ON [dbo].[ParqueEquipos]
    ([TipoEquiposid]);
GO

-- Creating foreign key on [ParqueEquiposid] in table 'PlanEquiposAgricZafra'
ALTER TABLE [dbo].[PlanEquiposAgricZafra]
ADD CONSTRAINT [FK_FKPlanEquipo297757]
    FOREIGN KEY ([ParqueEquiposid])
    REFERENCES [dbo].[ParqueEquipos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKPlanEquipo297757'
CREATE INDEX [IX_FK_FKPlanEquipo297757]
ON [dbo].[PlanEquiposAgricZafra]
    ([ParqueEquiposid]);
GO

-- Creating foreign key on [Suministradoresid] in table 'PelotonCombinadas'
ALTER TABLE [dbo].[PelotonCombinadas]
ADD CONSTRAINT [FK_FKPelotonCom54014]
    FOREIGN KEY ([Suministradoresid])
    REFERENCES [dbo].[Suministradores]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKPelotonCom54014'
CREATE INDEX [IX_FK_FKPelotonCom54014]
ON [dbo].[PelotonCombinadas]
    ([Suministradoresid]);
GO

-- Creating foreign key on [Zafrasid] in table 'PlanEquiposAgricZafra'
ALTER TABLE [dbo].[PlanEquiposAgricZafra]
ADD CONSTRAINT [FK_FKPlanEquipo587695]
    FOREIGN KEY ([Zafrasid])
    REFERENCES [dbo].[Zafras]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKPlanEquipo587695'
CREATE INDEX [IX_FK_FKPlanEquipo587695]
ON [dbo].[PlanEquiposAgricZafra]
    ([Zafrasid]);
GO

-- Creating foreign key on [Zafrasid] in table 'PlanOperadoresCombinadas'
ALTER TABLE [dbo].[PlanOperadoresCombinadas]
ADD CONSTRAINT [FK_FKPlanOperad741560]
    FOREIGN KEY ([Zafrasid])
    REFERENCES [dbo].[Zafras]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKPlanOperad741560'
CREATE INDEX [IX_FK_FKPlanOperad741560]
ON [dbo].[PlanOperadoresCombinadas]
    ([Zafrasid]);
GO

-- Creating foreign key on [Rolid] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_FKUsuario38509]
    FOREIGN KEY ([Rolid])
    REFERENCES [dbo].[Rol]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKUsuario38509'
CREATE INDEX [IX_FK_FKUsuario38509]
ON [dbo].[Usuario]
    ([Rolid]);
GO

-- Creating foreign key on [TiposSectorPropiedadid] in table 'Suministradores'
ALTER TABLE [dbo].[Suministradores]
ADD CONSTRAINT [FK_FKSuministra562195]
    FOREIGN KEY ([TiposSectorPropiedadid])
    REFERENCES [dbo].[TiposSectorPropiedad]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKSuministra562195'
CREATE INDEX [IX_FK_FKSuministra562195]
ON [dbo].[Suministradores]
    ([TiposSectorPropiedadid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------