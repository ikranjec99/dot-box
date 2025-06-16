namespace DotBox.Core.Business.Interfaces;

public interface IFolderHandler
{
    Task Create(string name, long? parentId);

    Task Delete(long id);
}
