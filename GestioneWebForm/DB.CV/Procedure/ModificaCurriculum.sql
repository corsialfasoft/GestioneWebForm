create procedure ModificaCurriculum
	@matricolaM nvarchar(10),
	@nomeM nvarchar(50),
	@cognomeM nvarchar(50),
	@etaM int,
	@emailM nvarchar(30),
	@residenzaM nvarchar(100),
	@telefonoM nvarchar(10)
as
	declare @test int;
	set @test = (select c.IdCv from Curriculum c where c.matricola = @matricolaM);
	if	@test is null
		throw 66666 , 'Matricola Errata!!!!!! RIPROVA' ,2;
	else
		begin 
		UPDATE Curriculum SET Nome= @nomeM , Cognome= @cognomeM , Eta= @etaM ,
				Email = @emailM , Residenza = @residenzaM , Telefono= @telefonoM 
				where IdCv = @test;
		end
go