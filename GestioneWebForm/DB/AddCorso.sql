create procedure AddCorso
	@nome nvarchar(50),
	@descrizione nvarchar (200),
	@dInizio date,
	@dFine date
as 
	begin transaction
	begin try 
		insert into Corsi (nome,descrizione,dInizio,dFine) values (@nome,@descrizione,@dInizio,@dFine)
		commit transaction;
	end try
	begin catch
		select 
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage;
		rollback transaction;
	end catch
go

