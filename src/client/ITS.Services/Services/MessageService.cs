using System.Net.Http;
using System.Text.Json;
using ITS.Models.Models;
using ITS.Services.Constants;
using ITS.Services.Services.Contracts;

namespace ITS.Services.Services
{
    public class MessageService : IMessageService
    {
        public async Task<List<DataModel>> GetDataAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{ServerLocations.ClientApi}/{ApiEndpoints.FileData}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<DataModel>>(content);

            return data;
        }

        public async Task SendDataAsync(string text, byte[] imageData)
        {
            using var client = new HttpClient();
            using var formData = new MultipartFormDataContent()
            {
                { new StringContent(text), ContentNames.Text },
                { new ByteArrayContent(imageData), ContentNames.Image, ContentFileNames.Image }
            };

            var response = await client.PostAsync($"{ServerLocations.ClientApi}/{ApiEndpoints.FileData}", formData);
            response.EnsureSuccessStatusCode();
        }
    }
}
