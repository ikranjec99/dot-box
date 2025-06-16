--DECLARE @Name NVARCHAR(255) = 'config.yaml'

SELECT TOP 10 * FROM [dbo].[File]
WHERE [Name] LIKE @Name + '%'
ORDER BY [Name];