﻿using ITS.Business.Models;
using ITS.Business.Services.Contracts;
using ITS.Data.Models;
using ITS.Data.Repositories.Contracts;

namespace ITS.Business.Services
{
    internal class FileDataService : IFileDataService
    {
        private readonly IImageFileDataRepository _imageFileDataRepository;
        private readonly ITextFileDataRepository _textFileDataRepository;

        public FileDataService(IImageFileDataRepository imageFileDataRepository, ITextFileDataRepository textFileDataRepository)
        {
            _imageFileDataRepository = imageFileDataRepository ?? throw new ArgumentNullException(nameof(imageFileDataRepository));
            _textFileDataRepository = textFileDataRepository ?? throw new ArgumentNullException( nameof(textFileDataRepository));
        }

        public async Task<List<FileDataViewModel>> GetFileDataAsync()
        {
            var fileDataViewModels = new List<FileDataViewModel>();
            var textFileDataModels = await _textFileDataRepository.GetTextDataAsync();

            foreach (var textFileDataModel in textFileDataModels)
            {
                fileDataViewModels.Add(new FileDataViewModel()
                {
                    Text = textFileDataModel.Text,
                    ImageData = await _imageFileDataRepository.ReadImageAsync(textFileDataModel.ImageFilePath)
                });
            }

            return fileDataViewModels;
        }

        public async Task UploadFileDataAsync(FileDataUploadModel fileDataUploadModel)
        {
            if (fileDataUploadModel == null)
            {
                throw new ArgumentNullException(nameof(fileDataUploadModel));
            }

            using var stream = new MemoryStream();
            await fileDataUploadModel.ImageData.CopyToAsync(stream);

            var imageFilePath = await _imageFileDataRepository.UploadImageAsync(stream.ToArray());
            var textFileDataModel = new TextFileDataModel()
            {
                Text = fileDataUploadModel.Text,
                ImageFilePath = imageFilePath
            };

            await _textFileDataRepository.AddFileDataAsync(textFileDataModel);
        }
    }
}
