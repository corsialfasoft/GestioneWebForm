Create procedure CercaCognome
	@cognome nvarchar(40)
as
	Select c.Matricola from Curriculum c where c.cognome= @cognome;
go