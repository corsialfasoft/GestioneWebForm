create PROCEDURE AddEspLav
    @AnnoI Int, 
  	@AnnoF Int,
	@Qualifica NVARCHAR(50), 
  	@Descrizione NVARCHAR(50), 
  	@matr nvarchar(10)
as		
 	declare @IdControl int;
	set @IdControl = (select IdCv from Curriculum where Matricola = @matr )
	if @IdControl is null
		begin
			print 'Warning! ID non trovato';
			THROW 51000,'Warning! ID non trovato',@IdControl;			
		end
	 else 	
		begin
			INSERT INTO EspLav (AnnoI, AnnoF, Qualifica, Descrizione, IdCv) 
			VALUES (@AnnoI, @AnnoF, @Qualifica,@Descrizione,@IdControl);
		end
go