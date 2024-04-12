namespace ITS.Data.Repositories.Contracts
{
    public interface IImageFileDataRepository
    {
        Task<string> UploadImageAsync(byte[] imageData);
        Task<byte[]> ReadImageAsync(string filePath);
    }
}
