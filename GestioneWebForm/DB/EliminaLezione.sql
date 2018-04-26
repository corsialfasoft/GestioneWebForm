Create procedure EliminaLezione
@IdLezione int
as
begin transaction;
begin try
	Delete Lezioni where id=@IdLezione
	commit transaction;
end try
begin catch  
	select   
        ERROR_NUMBER() AS ErrorNumber, 
		ERROR_MESSAGE() AS ErrorMessage;  
	rollback transaction;
end catch
go