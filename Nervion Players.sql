/*
 *************
 Restricciones
 *************
Las fechas de Creación no se insertarán ni modificarán
*/

Use master
go
If exists(Select * from dbo.sysdatabases where name='NervionPlayers')
Drop database NervionPlayers
go
Create Database NervionPlayers
go

Use NervionPlayers

CREATE TABLE Alumnos(
Id int not null identity(1,1),
Nombre nvarchar(30) not null,
Contraseña nvarchar(255) not null,
Apellidos nvarchar(50) null,
Alias nvarchar(20) unique not null,
Correo nvarchar(50) unique not null,
Fecha_Creacion smalldatetime not null default CURRENT_TIMESTAMP,
Curso tinyint not null,
Letra varchar(10),
Observaciones nvarchar(max),
Confirmado bit not null default 0
)

CREATE TABLE Equipos(
Id int identity(1,1),
Id_Creador int not null,
Nombre nvarchar(20) unique not null,
Fecha_Creacion smalldatetime not null default CURRENT_TIMESTAMP,
Foto varbinary(max) null,
Confirmado bit not null default 0
)

CREATE TABLE Deportes(
Id int identity(1,1),
Nombre nvarchar(20)
)

CREATE TABLE Partidos(
Id int identity(1,1),
Id_Local int,
Id_Visitante int,
Id_Deporte int,
Fecha_Partido smalldatetime not null,
Fecha_Creacion smalldatetime not null default CURRENT_TIMESTAMP,
Foto varbinary(max) null,
Resultado_Local int not null,
Resultado_Visitante int not null,
Lugar nvarchar(30),
Notas nvarchar(max) null
)

CREATE TABLE Duelos(
Id int identity(1,1),
Id_Local int,
Id_Visitante int,
Id_Deporte int,
Fecha_Creacion smalldatetime not null default CURRENT_TIMESTAMP,
Fecha_Duelo smalldatetime not null,
Foto varbinary(max),
Resultado_Local int not null,
Resultado_Visitante int not null,
Lugar nvarchar(30) null,
Notas nvarchar(max) null
)

CREATE TABLE AlumnosEquipos(
Id_Alumno int not null,
Id_Equipo int not null,
Fecha_Creacion smalldatetime not null default CURRENT_TIMESTAMP
)

CREATE TABLE ResultadosDuelos(
Id int identity(1,1),
Id_Alumno int unique not null,
Ganados int not null default 0,
Empatados int not null default 0,
Perdidos int not null default 0
)

CREATE TABLE ResultadosPartidos(
Id int identity(1,1),
Id_Equipo int unique not null,
Ganados int not null default 0,
Empatados int not null default 0,
Perdidos int not null default 0
)

CREATE TABLE Dispositivos(
Id int identity(1,1),
Id_Alumno int,
Token nvarchar(255) unique not null,
Fecha_Creacion smalldatetime not null default CURRENT_TIMESTAMP,
Fecha_Modificacion smalldatetime null,
Activo bit not null
)

--Claves primarias
go
Alter table Alumnos add constraint PK_Alumnos primary key (Id);
Alter table Equipos add constraint PK_Equipos primary key (Id);
Alter table Deportes add constraint PK_Deportes primary key (Id);
Alter table Dispositivos add constraint PK_Dispositivos primary key (Id);
Alter table Partidos add constraint PK_Partidos primary key (Id);
Alter table Duelos add constraint PK_Duelos primary key (Id);
Alter table ResultadosDuelos add constraint PK_ResultadosDuelos primary key (Id);
Alter table ResultadosPartidos add constraint PK_ResultadosPartidos primary key (Id);

Alter table AlumnosEquipos add constraint PK_AlumnosEquipos primary key (Id_Alumno,Id_Equipo);

--Claves foráneas

Alter table Dispositivos add constraint FK_Dispositivos_Alumnos foreign key (Id_Alumno) references Alumnos(Id);
Alter table Duelos add constraint FK_Duelos_Deportes foreign key (Id_Deporte) references Deportes(Id);
Alter table Partidos add constraint FK_Partidos_Deportes foreign key (Id_Deporte) references Deportes(Id);
Alter table Equipos add constraint FK_Equipos_Creador foreign key (Id_Creador) references Alumnos(Id);
Alter table AlumnosEquipos add constraint FK_AG_Alumnos foreign key(Id_Alumno) references Alumnos(Id);
Alter table AlumnosEquipos add constraint FK_AG_Equipos foreign key(Id_Equipo) references Equipos(Id);
Alter table ResultadosDuelos add constraint FK_RD_Alumnos foreign key(Id_Alumno) references Alumnos(Id);
Alter table ResultadosPartidos add constraint FK_RP_Equipos foreign key(Id_Equipo) references Equipos(Id);


Alter table Duelos add constraint FK_Duelos_Local foreign key (Id_Local) references Alumnos(Id);
Alter table Duelos add constraint FK_Duelos_Visitante foreign key (Id_Visitante) references Alumnos(Id);
Alter table Partidos add constraint FK_Partidos_Local foreign key (Id_Local) references Equipos(Id);
Alter table Partidos add constraint FK_Partidos_Visitante foreign key (Id_Visitante) references Equipos(Id);

--Restricciones

Alter table Alumnos add constraint CK_Correo check (Correo like '%@%.%');

--Usuarios
if not exists(Select * from master.sys.sql_logins where name='AlumnoNervion')
Begin
CREATE LOGIN AlumnoNervion
    WITH PASSWORD = '.N3tApe$7aH',Default_database=NervionPlayers; 
	
End 
GO

if not exists(Select * from master.sys.sql_logins where name='ProfesorNervion')
Begin
Create Login ProfesorNervion
	With Password = '1iNu#L0par7€T0',Default_database=NervionPlayers;
End

CREATE USER AlumnoNervion FOR LOGIN AlumnoNervion;
Grant Select to AlumnoNervion;
Grant Update,Delete,Insert on Alumnos to AlumnoNervion;
Grant Update,Delete,Insert on AlumnosEquipos to AlumnoNervion;
Grant Update,Delete,Insert on Dispositivos to AlumnoNervion;
Grant Update,Delete,Insert on Equipos to AlumnoNervion;
GO  


CREATE USER ProfesorNervion FOR LOGIN ProfesorNervion;
Grant Select,Update,Insert,Delete to ProfesorNervion; 
GO  

--Programación


--Triggers Insert
Create Trigger InsertarValidoAlumnos on Alumnos after insert as
declare @FechaCreacion smalldatetime
Select @FechaCreacion=Fecha_Creacion from inserted
If DateDiff(MI,@FechaCreacion,cast(CURRENT_TIMESTAMP as smalldatetime))>1 or DateDiff(MI,cast(CURRENT_TIMESTAMP as smalldatetime),@FechaCreacion)>1
Begin
rollback
End
go

Create Trigger InsertarValidoEquipos on Equipos after insert as
declare @FechaCreacion smalldatetime
Select @FechaCreacion=Fecha_Creacion from inserted
If DateDiff(MI,@FechaCreacion,cast(CURRENT_TIMESTAMP as smalldatetime))>1 or DateDiff(MI,cast(CURRENT_TIMESTAMP as smalldatetime),@FechaCreacion)>1
Begin
rollback
End
go

Create Trigger InsertarValidoPartidos on Partidos after insert as
declare @FechaCreacion smalldatetime
Select @FechaCreacion=Fecha_Creacion from inserted
If DateDiff(MI,@FechaCreacion,cast(CURRENT_TIMESTAMP as smalldatetime))>1 or DateDiff(MI,cast(CURRENT_TIMESTAMP as smalldatetime),@FechaCreacion)>1
Begin
rollback
End
go

Create Trigger InsertarValidoDuelos on Duelos after insert as
declare @FechaCreacion smalldatetime
Select @FechaCreacion=Fecha_Creacion from inserted
If DateDiff(MI,@FechaCreacion,cast(CURRENT_TIMESTAMP as smalldatetime))>1 or DateDiff(MI,cast(CURRENT_TIMESTAMP as smalldatetime),@FechaCreacion)>1
Begin
rollback
End
go

Create Trigger InsertarValidoAlumnosEquipos on AlumnosEquipos after insert as
declare @FechaCreacion smalldatetime
Select @FechaCreacion=Fecha_Creacion from inserted
If DateDiff(MI,@FechaCreacion,cast(CURRENT_TIMESTAMP as smalldatetime))>1 or DateDiff(MI,cast(CURRENT_TIMESTAMP as smalldatetime),@FechaCreacion)>1
Begin
rollback
End
go

Create Trigger InsertarValidoDispositivos on Dispositivos after insert as
declare @FechaCreacion smalldatetime
Select @FechaCreacion=Fecha_Creacion from inserted
If DateDiff(MI,@FechaCreacion,cast(CURRENT_TIMESTAMP as smalldatetime))>1 or DateDiff(MI,cast(CURRENT_TIMESTAMP as smalldatetime),@FechaCreacion)>1
Begin
rollback
End
go

--Triggers Update

Create Trigger ModificarValidoAlumnos on Alumnos after update as
declare @FechaCreacion smalldatetime
declare @FechaActualizacion smalldatetime
Select @FechaCreacion=Fecha_Creacion from inserted
Select @FechaActualizacion=Fecha_Creacion from deleted
If @FechaCreacion<>@FechaActualizacion
Begin
rollback
End
go

Create Trigger ModificarValidoEquipos on Equipos after update as
declare @FechaCreacion smalldatetime
declare @FechaActualizacion smalldatetime
Select @FechaCreacion=Fecha_Creacion from inserted
Select @FechaActualizacion=Fecha_Creacion from deleted
If @FechaCreacion<>@FechaActualizacion
Begin
rollback
End
go

Create Trigger ModificarValidoPartidos on Partidos after update as
declare @FechaCreacion smalldatetime
declare @FechaActualizacion smalldatetime
Select @FechaCreacion=Fecha_Creacion from inserted
Select @FechaActualizacion=Fecha_Creacion from deleted
If @FechaCreacion<>@FechaActualizacion
Begin
rollback
End
go

Create Trigger ModificarValidoDuelos on Duelos after update as
declare @FechaCreacion smalldatetime
declare @FechaActualizacion smalldatetime
Select @FechaCreacion=Fecha_Creacion from inserted
Select @FechaActualizacion=Fecha_Creacion from deleted
If @FechaCreacion<>@FechaActualizacion
Begin
rollback
End
go

Create Trigger ModificarValidoAlumnosEquipos on AlumnosEquipos after update as
declare @FechaCreacion smalldatetime
declare @FechaActualizacion smalldatetime
Select @FechaCreacion=Fecha_Creacion from inserted
Select @FechaActualizacion=Fecha_Creacion from deleted
If @FechaCreacion<>@FechaActualizacion
Begin
rollback
End
go

Create Trigger ModificarValidoDispositivos on Dispositivos after update as
declare @FechaCreacion smalldatetime
declare @FechaActualizacion smalldatetime
Select @FechaCreacion=Fecha_Creacion from inserted
Select @FechaActualizacion=Fecha_Creacion from deleted
If @FechaCreacion<>@FechaActualizacion
Begin
rollback
End
go

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

--Pruebas
/*
Update Alumnos set Fecha_Creacion=SMALLDATETIMEFROMPARTS(2017,01,28,17,10)
Select * from Alumnos

*/