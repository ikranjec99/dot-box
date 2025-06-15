using DotBox.Core.Business.Interfaces;
using DotBox.Core.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotBox.Api.Controllers;

[ApiController]
[Route("dot-box/{version:apiVersion}/folders")]
public class FolderController : ControllerBase
{
    private readonly IFolderHandler _folderHandler;

    public FolderController(IFolderHandler folderHandler)
        => _folderHandler = folderHandler;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateFolderRequest request)
    {
        await _folderHandler.Create(request.Name, request.ParentId);
        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        await _folderHandler.Delete(id);
        return NoContent();
    }
}
