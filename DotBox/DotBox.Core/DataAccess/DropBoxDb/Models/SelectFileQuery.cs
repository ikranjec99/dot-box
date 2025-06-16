namespace DotBox.Core.DataAccess.DropBoxDb.Models;

public class SelectFileQuery
{
    public long? FolderId { get; set; }

    public required string Name {  get; set; }
}
