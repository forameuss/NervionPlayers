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
           ('Francisco Javier','Constraseña','Ruiz Rodríguez','Javieraeros','pajarrurro@gmail.com',1,'a',0),
		   ('Adrian','123','Pol Alcala','adripol94','pruebaadripol@gmail.com',1,'a',0),
		   ('dummy','123','Das Dum','dummy1','dummy1@gmail.com',2,'d',0),
		   ('dummy2','123','dom dym','dummy2','pruebaadripol@gmail.com',1,'a',0),
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
           ,[Fecha_Creacion]
           ,[Confirmado])
     VALUES
           (1, 'Los malotes', '20160224', 0),
		   (2, 'Los de primero', '20160224', 0),
		   (3, 'Ya no me se mas', '20160224', 0),
		   (4, 'equipo dummy', '20160224',0),
		   (5, 'Los Googles', '20160224', 0)
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
           ,[Fecha_Creacion]
           ,[Resultado_Local]
           ,[Resultado_Visitante]
           ,[Lugar]
           ,[Notas])
     VALUES
           (1,2,1,20170115,20161224,4,3,'Pista1','No se que no se cuanto'),
		   (2,1,1,20170124,20161224,null,null,'Pista2','No se que no se cuanto'),
		   (3,1,2,20170215,20161224,null,null,'Pista1',NULL),
		   (1,2,1,20170112,20161224,1,2,'Pista3','No se que no se cuanto')
GO









