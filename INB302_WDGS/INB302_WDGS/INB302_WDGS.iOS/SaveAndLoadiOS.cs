using INB302_WDGS.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoadiOS))]

namespace INB302_WDGS.iOS
{
    public class SaveAndLoadiOS : ISaveAndLoad
    {
        #region ISaveAndLoad implementation

        public void SaveText(string filename, string text)
        {
            System.IO.File.WriteAllText(filename, text);
        }

        public string LoadText(string filename)
        {
            return System.IO.File.ReadAllText(filename);
        }

        public bool fileExists(string filename)
        {
            return System.IO.File.Exists(filename);
        }

        #endregion
    }
}
