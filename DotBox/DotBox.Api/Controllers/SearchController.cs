using DotBox.Core.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotBox.Api.Controllers;

[ApiController]
[Route("dot-box/{version:apiVersion}/search")]
public class SearchController : ControllerBase
{
    private readonly IFileHandler _fileHandler;

    public SearchController(IFileHandler fileHandler)
        => _fileHandler = fileHandler;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] long? folderId, [FromQuery] string name)
    {
        return Ok(await _fileHandler.Find(name, folderId));
    }
}
