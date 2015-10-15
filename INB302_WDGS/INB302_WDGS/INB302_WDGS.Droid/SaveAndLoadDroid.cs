using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using INB302_WDGS.Droid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoadDroid))]

namespace INB302_WDGS.Droid
{
    public class SaveAndLoadDroid : ISaveAndLoad
    {
        #region ISaveAndLoad implementation

        public void SaveText(string fileName, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var filePath = Path.Combine(documentsPath, fileName);
            System.IO.File.WriteAllText(filePath, text);
        }

        public string LoadText(string fileName)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var filePath = Path.Combine(documentsPath, fileName);
            return System.IO.File.ReadAllText(filePath);
        }

        public bool fileExists(string fileName)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, fileName);
            return System.IO.File.Exists(fileName);
        }

        #endregion
    }
}