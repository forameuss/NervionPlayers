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
Foto varbinary(max) null,
Fecha_Creacion smalldatetime not null default CURRENT_TIMESTAMP,
Curso tinyint not null,
Letra varchar(10) null,
Observaciones nvarchar(max) null,
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
Nombre nvarchar(20) not null
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
Lugar nvarchar(30) null,
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
Activo bit not null default 0
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

Alter table Dispositivos add constraint FK_Dispositivos_Alumnos foreign key (Id_Alumno) references Alumnos(Id) on update cascade on delete cascade;
Alter table Duelos add constraint FK_Duelos_Deportes foreign key (Id_Deporte) references Deportes(Id) on update cascade on delete cascade;
Alter table Partidos add constraint FK_Partidos_Deportes foreign key (Id_Deporte) references Deportes(Id) on update cascade on delete cascade;
Alter table Equipos add constraint FK_Equipos_Creador foreign key (Id_Creador) references Alumnos(Id) on update cascade on delete cascade;
Alter table AlumnosEquipos add constraint FK_AG_Alumnos foreign key(Id_Alumno) references Alumnos(Id) on update cascade on delete cascade;
Alter table AlumnosEquipos add constraint FK_AG_Equipos foreign key(Id_Equipo) references Equipos(Id) on update cascade on delete cascade;
Alter table ResultadosDuelos add constraint FK_RD_Alumnos foreign key(Id_Alumno) references Alumnos(Id) on update cascade on delete cascade;
Alter table ResultadosPartidos add constraint FK_RP_Equipos foreign key(Id_Equipo) references Equipos(Id) on update cascade on delete cascade;


Alter table Duelos add constraint FK_Duelos_Local foreign key (Id_Local) references Alumnos(Id) on update cascade on delete cascade;
Alter table Duelos add constraint FK_Duelos_Visitante foreign key (Id_Visitante) references Alumnos(Id) on update cascade on delete cascade;
Alter table Partidos add constraint FK_Partidos_Local foreign key (Id_Local) references Equipos(Id) on update cascade on delete cascade;
Alter table Partidos add constraint FK_Partidos_Visitante foreign key (Id_Visitante) references Equipos(Id) on update cascade on delete cascade;

--Restricciones

Alter table Alumnos add constraint CK_Correo check (Correo like '%@%.%');
Alter table Alumnos add constraint CK_Alias check (Alias like '');
go
