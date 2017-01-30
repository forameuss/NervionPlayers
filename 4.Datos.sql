--Datos
USE [NervionPlayers]
GO

Date var @date = GETDATE(); 

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
           ,[Foto]
           ,[Confirmado])
     VALUES
           (1, '', '', '', '', ''),
		   (2, '', '', '', '', ''),
		   (3, '', '', '', '', ''),
		   (4, '', '', '', '', ''),
		   (5, '', '', '', '', '')
GO

