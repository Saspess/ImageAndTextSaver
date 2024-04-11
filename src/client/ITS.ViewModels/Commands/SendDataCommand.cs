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
            await _messageService.SendDataAsync(_dataUploadViewModel.Text, _dataUploadModel.ImageData);
        }
    }
}
