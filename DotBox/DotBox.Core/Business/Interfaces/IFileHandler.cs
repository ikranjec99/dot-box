namespace DotBox.Core.Business.Interfaces;
using File = DataAccess.DropBoxDb.Models.File;

public interface IFileHandler
{
    Task Create(long folderId, string name);

    Task Delete(long id);
    Task<IEnumerable<File>> Find(string name, long? folderId);
}
