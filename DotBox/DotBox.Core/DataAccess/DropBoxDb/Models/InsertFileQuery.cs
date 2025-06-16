namespace DotBox.Core.DataAccess.DropBoxDb.Models;

public class InsertFileQuery
{
    public long FolderId { get; set; }

    public required string Name { get; set; }
}
