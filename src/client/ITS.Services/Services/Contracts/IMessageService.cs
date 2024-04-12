using ITS.Models.Models;

namespace ITS.Services.Services.Contracts
{
    public interface IMessageService
    {
        Task<List<DataModel>> GetDataAsync();
        Task SendDataAsync(string text, byte[] imageData);
    }
}
