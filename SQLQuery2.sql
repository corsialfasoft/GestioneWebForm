USE [GeCo]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[EliminaLezione]
		@IdLezione = 6

SELECT	@return_value as 'Return Value'

GO
