create PROCEDURE AddCvStudi
    @AnnoI Int, 
  	@AnnoF Int,
	@Titolo VARCHAR(50), 
  	@Descrizione VARCHAR(50), 
  	@MatrCv NVARCHAR(10)
as
	declare @IdControl int;
	set @IdControl = (select top 1 IdCv from Curriculum where Matricola = @MatrCv )
	if @IdControl is null
		begin
			print 'Warning! ID non trovato';
			THROW 51000,'Warning! ID non trovato',@IdControl;
		end
	 else 	
		begin
			print 'Warning! ID trovato';	
			INSERT INTO PercorsoStudi (AnnoI, AnnoF, Titolo, Descrizione, IdCv )
				VALUES(@AnnoI,@AnnoF,@Titolo,@Descrizione,@IdControl);				 
		end
go