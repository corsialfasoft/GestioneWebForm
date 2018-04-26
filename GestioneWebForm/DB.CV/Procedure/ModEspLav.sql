create procedure ModEspLav
	@id int,
	@annoIMod int ,
	@annoFMod int ,
	@qualificaMod nvarchar(50),
	@descrMod nvarchar(200)
as
	update EspLav set AnnoI = @annoIMod , AnnoF= @annoFMod, Qualifica = @qualificaMod , Descrizione=@descrMod
		where IdEl = @id;
go
