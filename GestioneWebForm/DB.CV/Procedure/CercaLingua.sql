CREATE PROCEDURE CercaLingua
	@competenza nvarchar(20)
AS
	SELECT C.IdCv 
	FROM Curriculum C INNER JOIN Competenze CS ON C.IdCv = CS.IdCv
	WHERE CS.Tipo like '%'+ @competenza +'%'
GO