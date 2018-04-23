create PROCEDURE AddCompetenze
	@Tipo NVARCHAR(50),
    @Livello Int,
    @MatrCv nvarchar(10)
as
	declare @IdControl int;
	set @IdControl = (select IdCv from Curriculum where Matricola = @MatrCv )

	if @IdControl is null
		begin
			print 'Warning! ID non trovato';
			THROW 51000,'Warning! ID non trovato',@IdControl;			
		end
	 else 	
		begin
			print 'Warning! ID trovato';	
			INSERT INTO Competenze (Tipo, Livello, IdCv)
						VALUES (@Tipo,@Livello,@IdControl)					 
		end	
go