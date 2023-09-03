--  This file contains the basic data for the application

-- Inserting roles and users
INSERT INTO dbo.Rol
    (descripcionRol)
VALUES
    (N'Administrador'),
    (N'Programador'),
    (N'Operador');

INSERT INTO dbo.Usuario
    (nombreUsuario,pass,Rolid,activo)
VALUES
    (N'admin', N'IJfGn71UwZDNh8XrPR58qg==', 1, 1),
    (N'programador', N'IJfGn71UwZDNh8XrPR58qg==', 2, 1),
    (N'operador', N'IJfGn71UwZDNh8XrPR58qg==', 3, 1);

-- Inserting configuration data

INSERT INTO dbo.TiposSectorPropiedad
    (nombreTipoSector)
VALUES
    (N'CCS'),
    (N'CPA'),
    (N'UBPC');

INSERT INTO dbo.Suministradores
    (TiposSectorPropiedadid,nombreSuministrador,activo)
VALUES
    (1, N'Antonio Maceo', 1),
    (2, N'Julio Peña', 1);

INSERT INTO dbo.CentrosRecepcion
    (nombreCentroRecepcion)
VALUES
    (N'Centro de procesamiento');

INSERT INTO dbo.VariedadCana
    (nombreVariedad)
VALUES
    (N'H44 – 3098'),
    (N'H49 – 104'),
    (N'H50 – 2036'),
    (N'H50 – 7209');

INSERT INTO dbo.EstadoEquipo
    (nombreEstado)
VALUES
    (N'OK'),
    (N'Roto');


-- Inserting data for the harvest

INSERT INTO dbo.Zafras
    (descripcionZafra,fechaInicio,fechaFin)
VALUES
    (N'2022-2023', '2022-09-01 00:00:00.0', '2023-03-30 00:00:00.0'),
    (N'2023-2024', '2023-01-09 00:00:00.0', NULL);

INSERT INTO dbo.ParametrosGenerales
    (nombreEmpresa,fechaActual,zafraAct)
VALUES
    (N'Central Jesus Rabi', '2023-01-09 00:00:00.0', 2);

-- Inserting data equipment

INSERT INTO dbo.TipoEquipos
    (descripcionEquipo)
VALUES
    (N'Cortadora'),
    (N'Tractor'),
    (N'Remolque');

INSERT INTO dbo.ParqueEquipos
    (Suministradoresid,TipoEquiposid,cantidadEquipos)
VALUES
    (1, 1, 5),
    (1, 2, 2),
    (2, 1, 2),
    (2, 2, 3);

-- Inserting data for combine harvester
INSERT INTO dbo.PelotonCombinadas
    (Suministradoresid,parque)
VALUES
    (1, 2),
    (2, 3);

INSERT INTO dbo.MarcasCombinadas
    (nombreCombinada)
VALUES
    (N'KP'),
    (N'YUN');

INSERT INTO dbo.OperadorCombinada
    (nombreOperador,MarcasCombinadasid,PelotonCombinadasid,activo)
VALUES
    (N'Juan', 1, 1, 1),
    (N'Pedro', 2, 2, 1);

-- Inserting data for plans and daily records

INSERT INTO dbo.Campo
    (Suministradoresid,VariedadCanaid,cepa,cantCanaVerde,cantCanaQuemada)
VALUES
    (1, 1, N'p2022', 100.00, 30.00),
    (2, 1, N'p2022', 50.00, 30.00);

INSERT INTO dbo.PlanEquiposAgricZafra
    (ParqueEquiposid,parqueAsignado,tareaDiaria,CentrosRecepcionid,Zafrasid)
VALUES
    (1, 2, 5.00, 1, 2),
    (2, 2, 3.00, 1, 2);

INSERT INTO dbo.PlanOperadoresCombinadas
    (OperadorCombinadaid,tareaDiaria,CentrosRecepcionid,Zafrasid)
VALUES
    (1, 2.00, 1, 2),
    (2, 3.00, 1, 2);

INSERT INTO dbo.DiarioEquiposZafra
    (PlanEquiposAgricZafraid,fecha,arrobasTiradas,parqueParado,Usuarioid,Zafrasid)
VALUES
    (1, '2023-01-09 00:00:00.0', 1.00, 1, 3, 2);

INSERT INTO dbo.DiarioOperadorCombinadas
    (PlanOperadoresCombinadasid,fecha,Campoid,EstadoEquipoid,cantQuemada,cantQuemadaProgram,cantVerde,Usuarioid,Zafrasid)
VALUES
    (1, '2023-01-09 00:00:00.0', 1, 1, 1.00, 1.00, 1.00, 3, 2),
    (2, '2023-01-09 00:00:00.0', 2, 1, 1.00, 1.00, 1.00, 3, 2);
