CREATE TABLE [dbo].[Folder] (
	[Id]            BIGINT NOT NULL PRIMARY KEY IDENTITY,
    [Name]          NVARCHAR(255) NOT NULL,
    [ParentId]      BIGINT NULL,
    [Created]       DATETIME2(3) NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ParentId) REFERENCES Folder(Id) ON DELETE CASCADE,
    CONSTRAINT UQ_Folder_Name_ParentId UNIQUE ([Name], [ParentId])
);