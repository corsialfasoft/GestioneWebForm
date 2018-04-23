create procedure DeleteCurriculum
	@idcurr nvarchar(50)
as
	declare @test int;
	set @test = (select C.IdCv from Curriculum c where c.Matricola=@idcurr);
	if @test is null
		throw 66666 , 'id errato riprovare!' ,2;
	else
		begin
			delete Competenze from Competenze cs where cs.IdCv = @test;
			delete EspLav from EspLav es where es.IdCv=@test;
			delete PercorsoStudi from PercorsoStudi ps where ps.IdCv=@test;
			delete Curriculum from Curriculum c where c.IdCv=@test;
		end
go