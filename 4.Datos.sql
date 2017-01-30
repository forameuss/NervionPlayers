--Datos
USE [NervionPlayers]
GO

INSERT INTO [dbo].[Alumnos]
           ([Nombre]
           ,[Contraseña]
           ,[Apellidos]
           ,[Alias]
           ,[Correo]
           ,[Curso]
           ,[Letra]
           ,[Confirmado])
     VALUES
		   ('Francisco Javier','Constrase�a','Ruiz Rodr�guez','Javieraeros','pajarrurro@gmail.com',1,'a',0),
		   ('Adrian','123','Pol Alcala','adripol94','prueba5dripol@gmail.com',1,'a',0),
		   ('dummy','123','Das Dum','dummy1','dummy1@gmail.com',2,'d',0),
		   ('dummy2','123','dom dym','dummy2','prueba6adripol@gmail.com',1,'a',0),
		   ('Dummy4','123','dem','dumm3','dummon@gmail.com',1,'a',0),
		   ('Paco','123','Alcarajo','pacoAlca','pacoAlca@gmail.com',2,'a',0),
		   ('Mario','123','Parlatori','marPar','marioPar@gmail.com',2,'a',0),
		   ('Loco','123','Man','locoMan','mariola@gmail.com',3,'a',0)
GO

USE [NervionPlayers]
GO

INSERT INTO [dbo].[Equipos]
           ([Id_Creador]
           ,[Nombre]
           ,[Confirmado])
     VALUES
			(1,'Prueba',0),
		   (2, 'Los de primero', 0),
		   (3, 'Ya no me se mas', 0),
		   (4, 'equipo dummy',0),
		   (5, 'Los Googles', 0)
GO

USE [NervionPlayers]
GO

INSERT INTO [dbo].[Deportes]
           ([Nombre])
     VALUES
           ('Futbol'),
		   ('Baloncesto'),
		   ('Tenis'),
		   ('Petanca')
GO


USE [NervionPlayers]
GO

INSERT INTO [dbo].[Partidos]
           ([Id_Local]
           ,[Id_Visitante]
           ,[Id_Deporte]
           ,[Fecha_Partido]
           ,[Resultado_Local]
           ,[Resultado_Visitante]
           ,[Lugar]
           ,[Notas])
     VALUES
           (1,2,1,'20170115',4,3,'Pista1','No se que no se cuanto'),
		   (2,1,1,'20170124',1,2,'Pista2','No se que no se cuanto'),
		   (3,1,2,'20170215',1,1,'Pista1',NULL),
		   (1,2,1,'20170112',1,2,'Pista3','No se que no se cuanto')
GO

USE [NervionPlayers]
GO

INSERT INTO [dbo].[Duelos]
           ([Id_Local]
           ,[Id_Visitante]
           ,[Id_Deporte]
           ,[Fecha_Duelo]
           ,[Foto]
           ,[Resultado_Local]
           ,[Resultado_Visitante]
           ,[Lugar]
           ,[Notas])
     VALUES
           (1,2,3,'20161206',NULL,1 ,1,'Pista1',NULL),
		   (1,2,3,'20161206',NULL,2 ,3,'Pista1',NULL),
		   (1,2,3,'20161206',NULL,0 ,0,'Pista1',NULL),
		   (1,2,3,'20161206',NULL,0 ,1,'Pista1',NULL)
GO


USE [NervionPlayers]
GO

INSERT INTO [dbo].[ResultadosPartidos]
           ([Id_Equipo]
           ,[Ganados]
           ,[Empatados]
           ,[Perdidos])
     VALUES
           (1,1,1,0)
GO

USE [NervionPlayers]
GO

INSERT INTO [dbo].[AlumnosEquipos]
           ([Id_Alumno]
           ,[Id_Equipo])
     VALUES
           (1,1),
		   (2,1),
		   (3,1),
		   (4,1),
		   (5,2),
		   (6,2),
		   (7,2)
GO















