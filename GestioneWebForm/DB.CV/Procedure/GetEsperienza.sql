Create Procedure GetEsperienza 
	@id int
as
	select el.IdEl,el.AnnoI,el.AnnoF,el.Qualifica, el.Descrizione from EspLav el where c.IdEl=@id;
go