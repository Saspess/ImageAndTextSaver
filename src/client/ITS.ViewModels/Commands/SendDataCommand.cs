using System.Windows;
using ITS.Models.Models;
using ITS.Services.Services;
using ITS.Services.Services.Contracts;
using ITS.ViewModels.ViewModels;

namespace ITS.ViewModels.Commands
{
    public class SendDataCommand : CommandBase
    {
        private readonly DataUploadViewModel _dataUploadViewModel;
        private readonly DataUploadModel _dataUploadModel;
        private readonly IMessageService _messageService;

        public SendDataCommand(DataUploadViewModel dataUploadViewModel, DataUploadModel dataUploadModel)
        {
            _messageService = new MessageService();
            _dataUploadViewModel = dataUploadViewModel;
            _dataUploadModel = dataUploadModel;
        }

        public override async void Execute(object parameter)
        {

            if (string.IsNullOrEmpty(_dataUploadViewModel.Text))
            {
                MessageBox.Show("Enter text");
                return;
            }

            if (_dataUploadModel.ImageData == null)
            {
                MessageBox.Show("Select file");
                return;
            }

            try
            {
                await _messageService.SendDataAsync(_dataUploadViewModel.Text, _dataUploadModel.ImageData);

                MessageBox.Show("The data was successfully saved");
                _dataUploadViewModel.Text = string.Empty;
                _dataUploadModel.ImageData = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sending data to the server: " + ex.Message);
                return;
            }
        }
    }
}
