using AutoMapper;
using IntrooApi.Models;
using IntrooApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntrooApi.Controllers;

[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileStoreService fileStoreService;
    private readonly IMapper mapper;

    public FileController(IFileStoreService fileStoreService, IMapper mapper)
    {
        this.fileStoreService = fileStoreService;
        this.mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StoreFileDetailsDto>> GetFile(int id)
    {
        var file = await fileStoreService.GetFile(id);
        if (file is null) return NotFound();

        return mapper.Map<StoreFileDetailsDto>(file);
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<StoreFileDetailsDto>>> GetAllFiles()
    {
        var files = await fileStoreService.GetAllFiles();
        return mapper.Map<List<StoreFileDetailsDto>>(files);
    }

    [HttpPost]
    public async Task<ActionResult<StoreFileDetailsDto>> CreateFile([FromForm] IFormFile file)
    {
        if (file is null) return BadRequest();

        var createdFile = await fileStoreService.AddFile(file);
        var createdFileDto = mapper.Map<StoreFileDetailsDto>(createdFile);
        return CreatedAtAction("GetFile", new { id = createdFile.Id }, createdFileDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<StoreFileDetailsDto>> DeleteFile(int id)
    {
        await fileStoreService.DeleteFile(id);
        return NoContent();
    }
}