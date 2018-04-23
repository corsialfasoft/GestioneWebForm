Create procedure GetEspLav
	@Matricola nvarchar(10)
as
	declare @idc int  ;
	set @idc = (select top 1 c.IdCv from Curriculum c where c.Matricola=@Matricola);
	select e.IdEl, e.AnnoI,e.AnnoF,e.Qualifica,e.Descrizione from EspLav e where e.IdCv=@idc;
go