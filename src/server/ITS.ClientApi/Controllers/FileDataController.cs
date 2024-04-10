using System;
using System.Threading.Tasks;
using ITS.Business.Models;
using ITS.Business.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ITS.ClientApi.Controllers
{
    [Route("api/file-data")]
    [ApiController]
    public class FileDataController : ControllerBase
    {
        private readonly IFileDataService _fileDataService;

        public FileDataController(IFileDataService fileDataService)
        {
            _fileDataService = fileDataService ?? throw new ArgumentNullException(nameof(fileDataService));
        }

        [HttpGet]
        public async Task<IActionResult> GetDataAsync()
        {
            var result = await _fileDataService.GetFileDataAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UploadDataAsync([FromBody] FileDataUploadModel fileDataUploadModel)
        {
            await _fileDataService.UploadFileDataAsync(fileDataUploadModel);
            return Ok();
        }
    }
}
