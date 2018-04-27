create procedure GetMatrFromEspLav
	@idEsp int
as
	declare @idCurr int;
	set @idCurr = (select e.IdCv  from EspLav e where  e.IdEl= @idEsp)
	select c.Matricola from Curriculum c where c.IdCv=@idCurr;
go

exec GetMatrFromEspLav 2;