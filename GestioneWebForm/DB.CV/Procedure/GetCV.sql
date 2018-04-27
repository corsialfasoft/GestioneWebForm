Create Procedure GetCV
	@Matricola nvarchar(10)
as
	select top 1 c.nome,c.cognome,c.eta,c.matricola,c.email,c.residenza,c.telefono
	from Curriculum c where c.Matricola=@Matricola;
go