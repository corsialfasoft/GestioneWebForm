create procedure SearchCorso
@IdCorso int
as
begin transaction;
begin try
	select * from Corsi where @IdCorso = id;
	commit transaction;
end try
begin catch  
	select   
        ERROR_NUMBER() AS ErrorNumber, 
		ERROR_MESSAGE() AS ErrorMessage;  
	rollback transaction;
end catch
go