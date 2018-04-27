Create procedure GetPerStudi
	@Matricola nvarchar(10)
as
	declare @idc int  ;
	set @idc = (select top 1 c.IdCv from Curriculum c where c.Matricola=@Matricola);
	select p.IdPs, p.AnnoI,p.AnnoF,p.Titolo,p.Descrizione from PercorsoStudi p where p.IdCv=@idc;
go