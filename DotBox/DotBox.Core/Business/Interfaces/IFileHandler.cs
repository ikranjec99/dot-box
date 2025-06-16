namespace DotBox.Core.Business.Interfaces;
using File = DotBox.Core.DataAccess.DropBoxDb.Models.File;

public interface IFileHandler
{
    Task Create(long folderId, string name);

    Task Delete(long id);

    Task<IEnumerable<File>> Find(string name);
}
