﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace ToDoApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileProvider _fileProvider;

        public FilesController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile? file, CancellationToken cancellationToken)
        {
            if (file is not { Length: > 0 }) return BadRequest("hata");
            var root = _fileProvider.GetDirectoryContents("wwwroot");
            var picturesDirectory = root.First(x => x.IsDirectory && x is { Exists: true, Name: "files" });

            var path = Path.Combine(picturesDirectory.PhysicalPath, file.FileName);

            await using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream, cancellationToken);

            var returnPath = file.FileName;

            return Created(string.Empty, null);
        }
    }
}
