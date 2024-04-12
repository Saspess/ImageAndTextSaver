using System.Windows.Input;
using ITS.ViewModels.Commands;
using ITS.Models.Models;

namespace ITS.ViewModels.ViewModels
{
    public class DataUploadViewModel : ViewModelBase
    {
        private string _text;
        public string Text
        {
            get 
            { 
                return _text; 
            }
            set 
            { 
                _text = value; 
                OnPropertyChanged(nameof(Text));
            }
        }

        public ICommand UploadImage { get; }
        public ICommand SendData { get; }

        public DataUploadViewModel(DataUploadModel dataUploadModel)
        {
            UploadImage = new DataUploadCommand(dataUploadModel);
            SendData = new SendDataCommand(this, dataUploadModel);
        }
    }
}
