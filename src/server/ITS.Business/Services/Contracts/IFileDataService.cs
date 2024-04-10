using ITS.Business.Models;

namespace ITS.Business.Services.Contracts
{
    public interface IFileDataService
    {
        Task<List<FileDataViewModel>> GetFileDataAsync();
        Task UploadFileDataAsync(FileDataUploadModel fileDataUploadModel);
    }
}
