--DECLARE @Name		NVARCHAR(255) = 'Test'
--DECLARE @ParentId BIGINT = 1

INSERT INTO [dbo].[Folder] ([Name], [ParentId])
VALUES (@Name, @ParentId);