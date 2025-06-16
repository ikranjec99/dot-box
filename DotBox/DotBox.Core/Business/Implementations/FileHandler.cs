using DotBox.Core.Business.Interfaces;
using DotBox.Core.DataAccess.DropBoxDb.Interfaces;
using DotBox.Core.DataAccess.DropBoxDb.Models;
using Microsoft.Extensions.Logging;

namespace DotBox.Core.Business.Implementations;

public class FileHandler : IFileHandler
{
    private readonly IFileRepository _fileRepository;
    private readonly ILogger _logger;

    public FileHandler(
        ILogger<FileHandler> logger,
        IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
        _logger = logger;
    }

    public async Task Create(long folderId, string name)
    {
        await _fileRepository.Add(new InsertFileQuery
        {
            FolderId = folderId,
            Name = name
        });
    }

    public async Task Delete (long id)
    {
        await _fileRepository.Delete(new DeleteFileQuery { Id = id });
    }
}
