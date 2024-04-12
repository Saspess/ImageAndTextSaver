using System.IO;
using System.Windows;
using ITS.Models.Models;
using Microsoft.Win32;

namespace ITS.ViewModels.Commands
{
    public class DataUploadCommand : CommandBase
    {
        private readonly DataUploadModel _dataUploadModel;

        public DataUploadCommand(DataUploadModel dataUploadModel)
        {
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
            MessageBox.Show("Image was uploaded");
        }
    }
}
