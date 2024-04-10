using ITS.Data.Models;

namespace ITS.Data.Repositories.Contracts
{
    public interface ITextFileDataRepository
    {
        Task<List<TextFileDataModel>> GetTextDataAsync();
        Task AddFileDataAsync(TextFileDataModel textFileDataModel);
    }
}
