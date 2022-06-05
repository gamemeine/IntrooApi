using IntrooApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntrooApi.Controllers;

[Route("api/[controller]")]
public class ResourceController : ControllerBase
{
    private readonly IFileStoreService fileStoreService;

    public ResourceController(IFileStoreService fileStoreService)
    {
        this.fileStoreService = fileStoreService;
    }

    [HttpGet("{fileName}")]
    public async Task<IActionResult> GetResource(string fileName)
    {
        var fileData = await fileStoreService.GetFileByName(fileName);
        if (fileData is null) return NotFound();

        var fileStream = System.IO.File.OpenRead(fileData.AbsoluteDirectory);

        return File(fileStream, "application/octet-stream", fileData.Name);
    }


}