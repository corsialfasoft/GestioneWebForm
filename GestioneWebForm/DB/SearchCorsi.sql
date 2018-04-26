create procedure SearchCorsi
	@descrizione nvarchar(20)
as 
	begin transaction
	begin try 
		select * from Corsi c where c.nome like '%'+@descrizione+'%' or c.descrizione like '%'+@descrizione+'%'
		commit transaction;
	end try
	begin catch
		select 
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage;
		rollback transaction;
	end catch
go