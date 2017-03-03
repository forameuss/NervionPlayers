/*
 *************
 Restricciones
 *************
Las fechas de Creación no se insertarán ni modificarán
En curso de alumno se guardará un nñumer entre 1 y 8, sinedo 5 y 6 primero y segundo de bachillerato y 7 y 8 primero y segundo de ciclo
En un equipo solo podrán ir alumnos de una misma categoría
Categoría podrá valer 1 o 2 (primero a tercero de eso, y de cuarto en adelante)
En un partido solo habrá equipos de una misma categoría
*/

Use master
go
If exists(Select * from dbo.sysdatabases where name='NervionPlayers')
Drop database NervionPlayers
go
Create Database NervionPlayers
go

Use NervionPlayers

CREATE TABLE Profesores(
Id int not null identity(1,1),
Nombre nvarchar(30) not null,
Contraseña nvarchar(255) not null,
Apellidos nvarchar(50) null,
Correo nvarchar(50) unique not null,
Foto varbinary(max) null,
Fecha_Creacion smalldatetime not null default CURRENT_TIMESTAMP,
Observaciones nvarchar(max) null
)

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
Id_Deporte int not null,
Categoria int not null,
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
Resultado_Local int  null,
Resultado_Visitante int null,
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
Resultado_Local int null,
Resultado_Visitante int null,
Lugar nvarchar(30) null,
Notas nvarchar(max) null
)

CREATE TABLE AlumnosEquipos(
Id_Alumno int not null,
Id_Equipo int not null,
Fecha_Creacion smalldatetime not null default CURRENT_TIMESTAMP
)

CREATE TABLE AlumnosDeportes(
Id_Alumno int not null,
Id_Deporte int not null
)

CREATE TABLE ResultadosDuelos(
Id_Alumno int not null,
Id_Deporte int not null,
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
Alter table Alumnos add constraint PK_Profesores primary key (Id);
Alter table Profesores add constraint PK_Alumnos primary key (Id);
Alter table Equipos add constraint PK_Equipos primary key (Id);
Alter table Deportes add constraint PK_Deportes primary key (Id);
Alter table Dispositivos add constraint PK_Dispositivos primary key (Id);
Alter table Partidos add constraint PK_Partidos primary key (Id);
Alter table Duelos add constraint PK_Duelos primary key (Id);
Alter table ResultadosDuelos add constraint PK_ResultadosDuelos primary key (Id_Alumno,Id_Deporte);
Alter table ResultadosPartidos add constraint PK_ResultadosPartidos primary key (Id);

Alter table AlumnosEquipos add constraint PK_AlumnosEquipos primary key (Id_Alumno,Id_Equipo);
Alter table AlumnosDeportes add constraint PK_AlumnosDeportes primary key (Id_Alumno,Id_Deporte);

--Claves foráneas

Alter table Dispositivos add constraint FK_Dispositivos_Alumnos foreign key (Id_Alumno) references Alumnos(Id) on update cascade on delete cascade;
Alter table Duelos add constraint FK_Duelos_Deportes foreign key (Id_Deporte) references Deportes(Id) on update cascade on delete cascade;
Alter table Partidos add constraint FK_Partidos_Deportes foreign key (Id_Deporte) references Deportes(Id) on update cascade on delete cascade;
Alter table Equipos add constraint FK_Equipos_Creador foreign key (Id_Creador) references Alumnos(Id) on update cascade on delete cascade;
Alter table Equipos add constraint FK_Equipos_Deportes foreign key (Id_Deporte) references Deportes(Id) on update cascade on delete cascade;
Alter table AlumnosEquipos add constraint FK_AG_Alumnos foreign key(Id_Alumno) references Alumnos(Id) on update cascade on delete cascade;
Alter table AlumnosEquipos add constraint FK_AG_Equipos foreign key(Id_Equipo) references Equipos(Id) on update no action on delete no action;
Alter table AlumnosDeportes add constraint FK_AD_Alumnos foreign key(Id_Alumno) references Alumnos(Id) on update cascade on delete cascade;
Alter table AlumnosDeportes add constraint FK_AD_Deportes foreign key(Id_Deporte) references Deportes(Id) on update no action on delete no action;


Alter table ResultadosPartidos add constraint FK_RP_Equipos foreign key(Id_Equipo) references Equipos(Id) on update cascade on delete cascade;
Alter table ResultadosDuelos add constraint FK_RD_AlumnosDeportes foreign key(Id_Alumno,Id_Deporte) references AlumnosDeportes(Id_Alumno,Id_Deporte) on update cascade on delete cascade;
Alter table Duelos add constraint FK_Duelos_Local foreign key (Id_Local) references Alumnos(Id) on update cascade on delete cascade;
Alter table Duelos add constraint FK_Duelos_Visitante foreign key (Id_Visitante) references Alumnos(Id) on update no action on delete no action;
Alter table Partidos add constraint FK_Partidos_Local foreign key (Id_Local) references Equipos(Id) on update no action on delete no action;
Alter table Partidos add constraint FK_Partidos_Visitante foreign key (Id_Visitante) references Equipos(Id) on update no action on delete no action;

--Restricciones

Alter table Alumnos add constraint CK_Correo check (Correo like '%@%.%');
Alter table Profesores add constraint CK_CorreoProfe check (Correo like '%@%.%');
Alter table Alumnos add constraint CK_Alias check (Alias not like '%@%');
Alter table Alumnos add constraint CK_Curso check (Curso between 1 and 8);
alter table Equipos add constraint CK_Categoria check(Categoria between 1 and 2);
go
