using System.Collections.ObjectModel;
using System.Windows;
using ITS.Models.Models;
using ITS.Services.Services;
using ITS.Services.Services.Contracts;

namespace ITS.ViewModels.ViewModels
{
    public class DataViewModel : ViewModelBase
    {
        public ObservableCollection<DataModel> Items { get; set; }
        private readonly IMessageService _messageService;

        public DataViewModel()
        {
            _messageService = new MessageService();
            _ = InitDataAsync();
        }

        public async Task InitDataAsync()
        {
            try
            {
                var data = await _messageService.GetDataAsync();
                Items = new ObservableCollection<DataModel>(data);
                OnPropertyChanged(nameof(Items));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while receiving data from the server: " + ex.Message);
                return;
            }
        }
    }
}
