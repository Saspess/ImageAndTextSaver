using System.Text.Json.Serialization;

namespace ITS.Models.Models
{
    public class DataModel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("imageData")]
        public byte[] ImageData { get; set; }

        public DataModel()
        {
        }
    }
}
