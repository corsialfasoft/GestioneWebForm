create procedure ModPerStud
	@id int,
	@annoIMod int , @annoFMod int ,
	@titoloMod nvarchar(50),
	@descrMod nvarchar(200)
as
	update PercorsoStudi  set AnnoI = @annoIMod , AnnoF= @annoFMod, Titolo = @titoloMod , Descrizione=@descrMod
		where IdPs = @id;
go