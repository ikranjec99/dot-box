--DECLARE @FolderId		BIGINT = 1
--DECLARE @Name			NVARCHAR(255) = 'config.yaml'

SELECT TOP 10 * FROM [dbo].[File]
WHERE (@FolderId IS NULL OR [FolderId] = @FolderId) AND [Name] LIKE @Name + '%'
ORDER BY [Name];