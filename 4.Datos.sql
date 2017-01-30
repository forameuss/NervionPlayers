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
           ('Francisco Javier'
           ,'Constraseña'
           ,'Ruiz Rodríguez'
           ,'Javieraeros'
           ,'pajarrurro@gmail.com'
           ,1
           ,'a'
           ,0)
GO
