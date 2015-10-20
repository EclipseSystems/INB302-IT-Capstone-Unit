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

        public string getFilePath(string fileName)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var filePath = Path.Combine(documentsPath, fileName);
            return filePath;
        }

        public void SaveText(string fileName, string text)
        {
            var filePath = getFilePath(fileName);
            System.IO.File.WriteAllText(filePath, text);
        }

        public string LoadText(string fileName)
        {
            var filePath = getFilePath(fileName);
            return System.IO.File.ReadAllText(filePath);
        }

        public Stream getReadStream(string fileName)
        {
            var filePath = getFilePath(fileName);
            return File.OpenRead(filePath);
        }

        public void saveImageToGallery(string fileName, byte[] imageData)
        {
            //var filePath = getFilePath(fileName);
            //using (var fs = File.Create(filePath))
            //{
            //    streamIn.CopyTo(fs);
            //}

            var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            var pictures = dir.AbsolutePath;
            //adding a time stamp time file name to allow saving more than one image... otherwise it overwrites the previous saved image of the same name
            string name = fileName + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
            string filePath = System.IO.Path.Combine(pictures, name);
            try
            {
                System.IO.File.WriteAllBytes(filePath, imageData);
                //mediascan adds the saved image into the gallery
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Android.Net.Uri.Parse(filePath));
                Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
        }

        public void checkCameraAccess()
        {
            App.cameraAccessGranted = true;
        }

        #endregion
    }
}