using System.IO;
using System.Windows;
using ITS.Models.Models;
using ITS.ViewModels.ViewModels;
using Microsoft.Win32;

namespace ITS.ViewModels.Commands
{
    public class DataUploadCommand : CommandBase
    {
        private readonly DataUploadViewModel _dataUploadViewModel;
        private readonly DataUploadModel _dataUploadModel;

        public DataUploadCommand(DataUploadViewModel dataUploadViewModel, DataUploadModel dataUploadModel)
        {
            _dataUploadViewModel = dataUploadViewModel;
            _dataUploadModel = dataUploadModel;
        }

        public override async void Execute(object parameter)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != true)
            {
                MessageBox.Show("Select image");
                return;
            }

            _dataUploadModel.ImageData = await File.ReadAllBytesAsync(openFileDialog.FileName);
        }
    }
}
