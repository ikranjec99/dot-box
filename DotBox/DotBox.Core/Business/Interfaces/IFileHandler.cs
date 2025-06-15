namespace DotBox.Core.Business.Interfaces;

public interface IFileHandler
{
    Task Create(long folderId, string name);

    Task Delete(long id);
}
