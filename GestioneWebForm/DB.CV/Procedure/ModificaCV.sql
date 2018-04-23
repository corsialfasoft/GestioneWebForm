create procedure ModificaCV
	@nome nvarchar(50),
	@cognome nvarchar(50),
	@eta int,
	@matr nvarchar(10),
	@email nvarchar(30),
	@residenza nvarchar(100),
	@telefono nvarchar(10)
as
	update Curriculum  set Nome=@nome,Cognome=@cognome,Eta=@eta,Email=@email,Residenza=@residenza,Telefono=@telefono
		where Matricola=@matr;
go