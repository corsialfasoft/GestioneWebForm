create procedure GetMatrFromComp
	@idComp int
as
	declare @idCurr int;
	set @idCurr = (select c.IdCv from Competenze  c where  c.IdCs = @idComp)
	select c.Matricola from Curriculum c where c.IdCv=@idCurr;
go

exec GetMatrFromComp 2;