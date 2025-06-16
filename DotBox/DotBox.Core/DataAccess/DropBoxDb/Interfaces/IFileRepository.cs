using DotBox.Core.DataAccess.DropBoxDb.Models;

namespace DotBox.Core.DataAccess.DropBoxDb.Interfaces;

public interface IFileRepository
{
    Task Add(InsertFileQuery query);

    Task Delete(DeleteFileQuery query);
}
