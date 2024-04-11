namespace ITS.Services.Services.Contracts
{
    public interface IMessageService
    {
        Task SendDataAsync(string text, byte[] imageData);
    }
}
