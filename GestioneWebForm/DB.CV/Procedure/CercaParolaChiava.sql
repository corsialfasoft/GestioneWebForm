create PROCEDURE CercaParolaChiava
	@parola nvarchar(20)
AS
	SELECT C.Matricola 
	FROM Curriculum C
		left JOIN PercorsoStudi PS ON C.IdCv = PS.IdCv 
		left JOIN EspLav EL ON C.IdCv = EL.IdCv 
		left JOIN Competenze CS ON C.IdCv = CS.IdCv 
	WHERE C.Nome like '%'+ @parola +'%'
		OR C.Cognome like '%'+ @parola +'%'
		OR C.email like '%'+ @parola +'%'
		OR C.Residenza like '%'+ @parola +'%'
		OR PS.Titolo like '%'+ @parola +'%'
		OR PS.Descrizione like '%'+ @parola +'%'
		OR EL.Qualifica like '%'+ @parola +'%'
		OR EL.Descrizione like '%'+ @parola +'%'
		OR CS.Tipo like '%'+ @parola +'%'
GO
exec CercaParolaChiava 'a'