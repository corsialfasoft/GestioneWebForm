create procedure CercaMatricola
	@matri nvarchar
as
	select c.IdCv From Curriculum c where c.matricola=@matri;
go