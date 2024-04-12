using ITS.Models.Models;

namespace ITS.ViewModels.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public DataUploadViewModel DataUploadViewModel { get; set; }
        public DataViewModel DataViewModel { get; set; }

        public MainViewModel(DataUploadModel dataUploadModel)
        {
            DataUploadViewModel = new DataUploadViewModel(dataUploadModel);
            DataViewModel = new DataViewModel();
        }
    }
}
