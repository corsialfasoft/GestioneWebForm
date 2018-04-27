create procedure GetMatrFromPerStud
	@idPerStud int
as
	declare @idCurr int;
	set @idCurr = (select p.IdCv  from PercorsoStudi p where  p.IdPs= @idPerStud)
	select c.Matricola from Curriculum c where c.IdCv=@idCurr;
go

exec GetMatrFromPerStud 2;