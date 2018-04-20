create procedure AddLezione
	@idCorso int,
	@argomento nvarchar (30),
	@durata int
as 
	begin transaction
	begin try 
		insert into Lezioni(argomento,durata,idCorso) values (@argomento,@durata,@idCorso)
		commit transaction;
	end try
	begin catch
		select 
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage;
		rollback transaction;
	end catch
go

exec AddLezione 1,'Prima lezione del corso',2

