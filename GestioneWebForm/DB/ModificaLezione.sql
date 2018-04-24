create procedure ModificaLezione
@idLezione int,
@argomento nvarchar(30),
@durata int
as
begin transaction;
begin try
	Update Lezioni set argomento=@argomento , durata=@durata where id=@idLezione
	commit transaction;
end try
begin catch  
	select   
        ERROR_NUMBER() AS ErrorNumber, 
		ERROR_MESSAGE() AS ErrorMessage;  
	rollback transaction;
end catch
go