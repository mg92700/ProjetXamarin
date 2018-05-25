using System;
using System.IO;
using Apu.Droid;
using Apu.Helpers;
using Xamarin.Forms;

[assembly:Dependency(typeof(FileHelper))]
namespace Apu.Droid
{
    public class FileHelper: Apu.Helpers.IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
