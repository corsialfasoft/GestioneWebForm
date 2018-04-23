create procedure CercaCitta
	@citta nvarchar
as
	select c.IdCv from Curriculum c where c.residenza like '%'+@citta+'%';
go