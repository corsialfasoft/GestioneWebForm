create procedure SearchLezioni
	@idCorso int
as 
	select l.id,l.argomento,l.durata from Lezioni l where l.idCorso = @idCorso
go

exec SearchLezioni 1