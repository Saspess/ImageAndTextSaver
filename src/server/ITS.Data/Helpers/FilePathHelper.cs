namespace ITS.Data.Helpers
{
    public static class FilePathHelper
    {
        public static string GetTextFilePath(string directoryName, string fileName)
        {
            return $"{directoryName}/{fileName}.json";
        }

        public static string GetImageFilePath(string directoryName, string fileName = null)
        {
            fileName ??= DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            return $"{directoryName}/{fileName}.jpg";
        }
    }
}
