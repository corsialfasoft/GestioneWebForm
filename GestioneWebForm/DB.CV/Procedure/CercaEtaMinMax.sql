create procedure CercaEtaMinMax
	@e_min int , 
	@e_max int 
as
	Select c.Matricola from Curriculum c  where c.Eta between @e_min and @e_max ;
go