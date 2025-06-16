namespace DotBox.Core.DataAccess.DropBoxDb.Models;

public class Folder
{
    public virtual long Id { get; set; }

    public virtual required string Name { get; set; }

    public virtual long? ParentId { get; set; }

    public virtual DateTime Created { get; set; }
}
