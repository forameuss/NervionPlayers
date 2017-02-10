--Usuarios NervionPLayers
Use NervionPlayers
if not exists(Select * from master.sys.sql_logins where name='InvitadoNervion')
Begin
CREATE LOGIN InvitadoNervion
    WITH PASSWORD = 'P4P,7h€60D!',Default_database=NervionPlayers; 
	
End 
GO

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

Create User InvitadoNervion FOR LOGIN InvitadoNervion;
Grant Select to InvitadoNervion;
go


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
