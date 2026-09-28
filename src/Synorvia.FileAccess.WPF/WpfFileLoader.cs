using Synorvia.FileAccess.Contracts;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace Synorvia.FileAccess.WPF
{
    public class WpfFileLoader : IFileLoader
    {
        public byte[] ReadDataFromFile(string filename)
        {
            byte[] result = null;

            try
            {
                result = File.ReadAllBytes(filename);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }

            return result;
        }

        public bool ShowOpenFileDialog(out string selectedFilename,
                                       string defaultFilename = "",
                                       string defaultFileExtension = "",
                                       string initialDirectory = "",
                                       string filter = "All Files (*.*)|*.*",
                                       string title = "Open file...")
        {
            bool result = false;
            selectedFilename = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = title;

            if (!string.IsNullOrEmpty(filter))
            {
                openFileDialog.Filter = filter;
            }
            if (!string.IsNullOrEmpty(defaultFilename))
            {
                openFileDialog.FileName = defaultFilename;
            }
            if (!string.IsNullOrEmpty(defaultFileExtension))
            {
                openFileDialog.DefaultExt = defaultFileExtension;
            }
            if (!string.IsNullOrEmpty(initialDirectory))
            {
                openFileDialog.InitialDirectory = initialDirectory;
            }

            bool? dialogResult = openFileDialog.ShowDialog();

            if (dialogResult.HasValue)
            {
                if (dialogResult.Value == true)
                {
                    selectedFilename = openFileDialog.FileName;
                    result = true;
                }
            }

            return result;
        }
    }
}
