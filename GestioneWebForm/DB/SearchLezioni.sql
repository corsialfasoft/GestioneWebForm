create procedure SearchLezione
	@idLezione int
as 
	select l.argomento,l.durata from Lezioni l where l.id = @idLezione
go

exec SearchLezione 4