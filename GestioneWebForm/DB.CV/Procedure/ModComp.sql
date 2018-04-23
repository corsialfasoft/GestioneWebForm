create procedure ModComp
	@id int,
	@titoloMod nvarchar(50),
	@livMod int
as
	UPDATE Competenze set Tipo= @titoloMod , Livello= @livMod where IdCs=@id;
go