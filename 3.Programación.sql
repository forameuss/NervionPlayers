Use NervionPlayers
go
/*Programación NerviónPlayers
TODO
Añadir Procedimiento sin parámetros, que cada cierto tiempo limpie los dispositivos que llevan sin usarse más de una semana, y estén inactivos.
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

