namespace DotBox.Core.DataAccess.DropBoxDb.Models;

public class File
{
    public virtual long Id { get; set; }

    public virtual required string Name { get; set; }

    public virtual long FolderId { get; set; }

    public virtual DateTime Created {  get; set; }
}