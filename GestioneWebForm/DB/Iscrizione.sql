create procedure Iscrizione
@IdCorso int,
@matr nvarchar(10)
as
begin transaction;
begin try
	insert into StudentiCorsi values (@IdCorso,@matr);
	commit transaction;
end try
begin catch  
	select   
        ERROR_NUMBER() AS ErrorNumber, 
		ERROR_MESSAGE() AS ErrorMessage;  
	rollback transaction;
end catch
go