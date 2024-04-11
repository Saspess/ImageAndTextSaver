using ITS.Models.Models;

namespace ITS.ViewModels.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; set; }

        public MainViewModel(DataUploadModel dataUploadModel)
        {
            CurrentViewModel = new DataUploadViewModel(dataUploadModel);
        }
    }
}
