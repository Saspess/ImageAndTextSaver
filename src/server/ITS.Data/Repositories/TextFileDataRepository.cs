using System.Reflection;
using System.Text.Json;
using ITS.Data.Helpers;
using ITS.Data.Models;
using ITS.Data.Models.Configuration;
using ITS.Data.Repositories.Contracts;
using Microsoft.Extensions.Options;

namespace ITS.Data.Repositories
{
    internal class TextFileDataRepository : ITextFileDataRepository
    {
        private readonly FileStorageSettings _fileStorageSettings;

        public TextFileDataRepository(IOptions<FileStorageSettings> fileStorageOptions)
        {
            _fileStorageSettings = fileStorageOptions.Value;
        }

        public async Task<List<TextFileDataModel>> GetTextDataAsync()
        {
            var filePath = FilePathHelper.GetTextFilePath(_fileStorageSettings.TextFilesLocation, _fileStorageSettings.DefaultTextFileName);
            var textFileDataModels = new List<TextFileDataModel>();

            if (File.Exists(filePath))
            {
                using var reader = new StreamReader(filePath);
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    textFileDataModels.Add(JsonSerializer.Deserialize<TextFileDataModel>(line));
                }
            }

            return textFileDataModels;
        }

        public async Task AddFileDataAsync(TextFileDataModel textFileDataModel)
        {
            if (!Directory.Exists(_fileStorageSettings.TextFilesLocation))
            {
                Directory.CreateDirectory(_fileStorageSettings.TextFilesLocation);
            }

            var filePath = FilePathHelper.GetTextFilePath(_fileStorageSettings.TextFilesLocation, _fileStorageSettings.DefaultTextFileName);
            using var writer = new StreamWriter(filePath, true);
            var json = JsonSerializer.Serialize(textFileDataModel);
            await writer.WriteLineAsync(json);
        }
    }
}
