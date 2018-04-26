create procedure ModComp
	@id int,
	@titoloMod nvarchar(50),
	@livMod int
as
	UPDATE Competenze set Tipo= @titoloMod , Livello= @livMod where IdCs=@id;
go
delete from Competenze where idCs>11
select * from Competenze
exec ModComp 5,'Prova',9