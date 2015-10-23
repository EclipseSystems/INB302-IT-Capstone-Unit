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
    /*
     * Android implementation of the ISaveAndLoad shared project interface
     * Used for saving and reading files on the users device
     */ 
    public class SaveAndLoadDroid : ISaveAndLoad
    {
        #region ISaveAndLoad implementation

        /*
         * gets the file path of a provided file
         * 
         * Params:
         * string fileName: the file name to either save to, or load from
         * 
         * Returns:
         * the file path of the file provided in the users devices personal
         * documents folder
         */ 
        public string getFilePath(string fileName)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var filePath = Path.Combine(documentsPath, fileName);
            return filePath;
        }

        /*
         * saves text to a file on the users device
         * 
         * Params:
         * string fileName: the file name to save as
         * string text: the text to be saved
         * 
         * Returns:
         * none
         */ 
        public void SaveText(string fileName, string text)
        {
            var filePath = getFilePath(fileName);
            System.IO.File.WriteAllText(filePath, text);
        }

        /*
         * loads text from a file
         * 
         * Params:
         * string fileName: the name of the file the text is stored under
         * 
         * Returns:
         * the full text as a string from the given file name
         */ 
        public string LoadText(string fileName)
        {
            var filePath = getFilePath(fileName);
            return System.IO.File.ReadAllText(filePath);
        }

        /*
         * saves an image taken with the camera to the users gallery
         * 
         * Params:
         * string fileName: the file name to save the image under
         * byte[] imageBytes: a byte array of the image data
         * 
         * Returns:
         * a string message indicating if the save was successful or failed
         */ 
        public String saveImageToGallery(string fileName, byte[] imageBytes)
        {
            var message = "";
            var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            var pictures = dir.AbsolutePath;
            //adding a time stamp time file name to allow saving more than one image... 
            //otherwise it overwrites the previous saved image of the same name
            string name = fileName + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
            string filePath = System.IO.Path.Combine(pictures, name);
            try
            {
                System.IO.File.WriteAllBytes(filePath, imageBytes);
                //mediascan adds the saved image into the gallery
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Android.Net.Uri.Parse(filePath));
                Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
            }
            catch (System.Exception e)
            {
                message = "error";
            }
            return message;
        }

        /*
         * checks if the user has granted camera access
         * 
         * On android this is always true as access is granted
         * through the androidmanifest / project properties
         * 
         * Params:
         * none
         * 
         * Returns:
         * none
         */ 
        public void checkCameraAccess()
        {
            App.cameraAccessGranted = true;
        }

        #endregion
    }
}