﻿Create Procedure GetPercorso 
	@id int
as
	select ps.IdPs,ps.AnnoI,ps.AnnoF,ps.Titolo,ps.Descrizione from PercorsoStudi ps where ps.IdPs=@id;
go