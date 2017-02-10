Use NervionPlayers
go
/*Programación NerviónPlayers
TODO
Añadir Procedimiento sin parámetros, que cada cierto tiempo limpie los dispositivos que llevan sin usarse más de una semana, y estén inactivos.
Trigger que compruebe que en un equipo solo haya jugadores de uan misma categoría
*/
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

--Trigger EquipoCategoría
Create Trigger CategoriaEquipo on AlumnosEquipos after insert,update as
/*declare @Categoria int
declare @Curso tinyint
declare @TotalInserciones int,@i int=0
Select @TotalInserciones=count(*) from inserted
while(@i<@TotalInserciones)
	Begin
		Select @Categoria=Categoria from Equipos where Id=(Select Id_Equipo from inserted where =@i)
		Select @Curso=Curso from Alumnos where Id=(Select Id_Alumno from inserted where =@i)
		set @i=@i+1
		If not (@Categoria=1 and(@Curso between 1 and 3) or (@Categoria=2 and(@Curso between 4 and 6)))
			rollback
	End
	*/
if exists(Select i.Id_Alumno from inserted as i
	inner join Alumnos as a
	on i.Id_Alumno=a.Id
	inner join Equipos as e
	on i.Id_Equipo=e.Id
	where (a.Curso between 1 and 3 and e.Categoria<>1) or (a.Curso between 4 and 8 and e.Categoria<>2) ) 
rollback
go

--Trigger PartidoCategoría


go
--Trigger Correo
Create Trigger CorreoValidoProfesor on Profesores after insert as
declare @Correo nvarchar(100)
Select @Correo=Correo from inserted 
if exists(Select Id from Alumnos where Correo=@Correo)
rollback
go
--Trigger Correo
Create Trigger CorreoValidoAlumno on Alumnos after insert as
declare @Correo nvarchar(100)
Select @Correo=Correo from inserted 
if exists(Select Id from Profesores where Correo=@Correo)
rollback
go