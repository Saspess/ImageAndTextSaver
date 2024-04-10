using Microsoft.AspNetCore.Http;

namespace ITS.Business.Models
{
    public class FileDataUploadModel
    {
        public string Text { get; set; }
        public IFormFile ImageData { get; set; }
    }
}
