using DotBox.Core.Business.Interfaces;
using DotBox.Core.DataAccess.DropBoxDb.Interfaces;
using DotBox.Core.DataAccess.DropBoxDb.Models;
using Microsoft.Extensions.Logging;

namespace DotBox.Core.Business.Implementations;

public class FolderHandler : IFolderHandler
{
    private readonly ILogger _logger;
    private readonly IFolderRepository _folderRepository;

    public FolderHandler(
        ILogger<FolderHandler> logger,
        IFolderRepository folderRepository)
    {
        _logger = logger;
        _folderRepository = folderRepository;
    }

    public async Task Create(string name, long? parentId)
    {
        await _folderRepository.Add(new InsertFolderQuery
        {
            Name = name,
            ParentId = parentId,
        });
    }
}
