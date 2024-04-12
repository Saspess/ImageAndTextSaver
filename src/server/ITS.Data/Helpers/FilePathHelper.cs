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
            fileName ??= DateTime.UtcNow.ToString("yyyyMMdd_HHmm_ssfff");
            return $"{directoryName}/{fileName}.jpg";
        }
    }
}
