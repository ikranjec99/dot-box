using DotBox.Core.DataAccess.DropBoxDb.Models;
using File = DotBox.Core.DataAccess.DropBoxDb.Models.File;

namespace DotBox.Core.DataAccess.DropBoxDb.Interfaces;

public interface IFileRepository
{
    Task Add(InsertFileQuery query);

    Task Delete(DeleteFileQuery query);

    Task<IEnumerable<File>> Get(SelectFileQuery query);
}
