using ITS.Data.Models.Configuration;
using ITS.Data.Helpers;
using ITS.Data.Repositories.Contracts;
using Microsoft.Extensions.Options;

namespace ITS.Data.Repositories
{
    internal class ImageFileDataRepository : IImageFileDataRepository
    {
        private readonly FileStorageSettings _fileStorageSettings;

        public ImageFileDataRepository(IOptions<FileStorageSettings> fileStorageOptions)
        {
            _fileStorageSettings = fileStorageOptions.Value;
        }

        public async Task<string> UploadImageAsync(byte[] imageData)
        {
            if (!Directory.Exists(_fileStorageSettings.ImageFilesLocation))
            {
                Directory.CreateDirectory(_fileStorageSettings.TextFilesLocation);
            }

            var filePath = FilePathHelper.GetImageFilePath(_fileStorageSettings.ImageFilesLocation);
            await File.WriteAllBytesAsync(filePath, imageData);
            return filePath;
        }

        public async Task<byte[]> ReadImageAsync(string filePath)
        {
            byte[] imageData = null;

            if (File.Exists(filePath))
            {
                imageData = await File.ReadAllBytesAsync(filePath);
            }

            return imageData;
        }
    }
}
