using System.Net.Http;
using System.Windows;
using ITS.Services.Services.Contracts;

namespace ITS.Services.Services
{
    public class MessageService : IMessageService
    {
        public async Task SendDataAsync(string text, byte[] imageData)
        {
            try
            {
                using var client = new HttpClient();
                using var formData = new MultipartFormDataContent()
                {
                    { new StringContent(text), "Text" },
                    { new ByteArrayContent(imageData), "ImageData", "ImageData" }
                };

                var response = await client.PostAsync("http://localhost:5185/api/file-data", formData);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sending data to the server: " + ex.Message);
            }
        }
    }
}
