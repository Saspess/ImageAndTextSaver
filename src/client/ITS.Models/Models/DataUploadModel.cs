namespace ITS.Models.Models
{
    public class DataUploadModel
    {
        public string Text { get; }
        public byte[] ImageData { get; set; }

        public DataUploadModel()
        {
        }

        public DataUploadModel(string text)
        {
            Text = text;
        }
    }
}
