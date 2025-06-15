namespace DotBox.Core.DataAccess.DropBoxDb.Models;

public class InsertFolderQuery
{
    public virtual required string Name { get; set; }

    public virtual long? ParentId { get; set; }
}
