﻿Create Procedure GetCompetenza
	@id int
as
	select c.IdCs,c.Tipo, c.Livello from Competenze c where c.IdCv=@id;
go