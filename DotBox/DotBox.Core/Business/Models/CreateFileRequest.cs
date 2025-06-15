namespace DotBox.Core.Business.Models;

public class CreateFileRequest
{
    public long FolderId { get; set; }

    public required string Name { get; set; }
}
