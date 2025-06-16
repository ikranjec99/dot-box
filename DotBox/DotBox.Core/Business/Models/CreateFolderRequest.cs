namespace DotBox.Core.Business.Models;

public class CreateFolderRequest
{
    public required string Name { get; set; }

    public long? ParentId { get; set; }
}
