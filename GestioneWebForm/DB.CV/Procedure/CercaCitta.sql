Create procedure CercaEta
	@eta int
as
	Select c.Matricola from Curriculum c Where c.Eta=@eta
go