Create Procedure GetComp
	@Matricola nvarchar(10)
as
	declare @idc int  ;
	set @idc = (select top 1 c.IdCv from Curriculum c where c.Matricola=@Matricola);
	select c.IdCs, c.Livello,c.Tipo from Competenze c where c.IdCv=@idc;
go