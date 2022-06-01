#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntrooApi.Models;
using IntrooApi.Data;
using IntrooApi.Services;

namespace IntrooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileStoreService fileStore;
        private readonly IConfiguration config;

        public FilesController(IFileStoreService fileStore, IConfiguration config)
        {
            this.fileStore = fileStore;
            this.config = config;
        }

        [HttpGet("{accessCode}")]
        public async Task<IActionResult> GetFile(Guid accessCode)
        {
            var fileData = await fileStore.GetFile(accessCode);

            var fileStream = System.IO.File.OpenRead(fileData.AbsoluteDirectory);
            if (fileStream is null) return NotFound();

            return File(fileStream, "application/octet-stream", fileData.FileName);
        }
    }
}