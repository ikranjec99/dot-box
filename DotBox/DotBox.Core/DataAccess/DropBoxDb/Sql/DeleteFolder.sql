--DECLARE @Id BIGINT = 1

IF EXISTS (SELECT 1 FROM [dbo].[Folder] WHERE Id = @Id)
BEGIN
    WITH RecursiveFolders AS (
        SELECT Id FROM [dbo].[Folder] WHERE Id = @Id
        UNION ALL
        SELECT f.Id FROM [dbo].[Folder] f
        INNER JOIN RecursiveFolders rf ON f.ParentId = rf.Id
    )
    DELETE FROM [dbo].[Folder] WHERE Id IN (SELECT Id FROM RecursiveFolders);
END