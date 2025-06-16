using DotBox.Core.DataAccess.DropBoxDb.Models;

namespace DotBox.Core.DataAccess.DropBoxDb.Interfaces;

public interface IFolderRepository
{
    Task Add(InsertFolderQuery query);
}
