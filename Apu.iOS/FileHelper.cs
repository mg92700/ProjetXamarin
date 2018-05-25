using System;
using System.IO;
using Apu.Droid;
using Apu.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Apu.Droid
{
    public class FileHelper : Apu.Helpers.IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
          string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            string libFolder = Path.Combine(docFolder, "..", "Libray", "Databases");
            if (!Directory.Exists(libFolder))
            {

                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, filename);
        }
    }
}
