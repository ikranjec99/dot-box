--DECLARE @FolderId BIGINT = 1
--DECLARE @Name		NVARCHAR(255) = 'Test'

INSERT INTO [dbo].[File] ([FolderId], [Name])
VALUES (@FolderId, @Name);