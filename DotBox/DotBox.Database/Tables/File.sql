CREATE TABLE [dbo].[File] (
	[Id]            BIGINT NOT NULL PRIMARY KEY IDENTITY,
    [Name]          NVARCHAR(255) NOT NULL,
    [FolderId]      BIGINT NOT NULL,
    [Created]       DATETIME2(3) NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (FolderId) REFERENCES Folder(Id),
    CONSTRAINT UQ_File_Name_FolderId UNIQUE ([Name], [FolderId])
);