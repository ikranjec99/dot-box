using DotBox.Core.Business.Interfaces;
using DotBox.Core.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotBox.Api.Controllers;

[ApiController]
[Route("dot-box/{version:apiVersion}/files")]
public class FileController : ControllerBase
{
    private readonly IFileHandler _fileHandler;

    public FileController(IFileHandler fileHandler)
        => _fileHandler = fileHandler;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateFileRequest request)
    {
        await _fileHandler.Create(request.FolderId, request.Name);
        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        await _fileHandler.Delete(id);
        return NoContent();
    }
}
