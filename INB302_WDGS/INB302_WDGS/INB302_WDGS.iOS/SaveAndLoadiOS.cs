using AVFoundation;
using Foundation;
using INB302_WDGS.iOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoadiOS))]

namespace INB302_WDGS.iOS
{
    public class SaveAndLoadiOS : ISaveAndLoad
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
            var imageToSave = new UIImage(NSData.FromArray(imageData));
            imageToSave.SaveToPhotosAlbum((image, error) =>
            {
                //you can retrieve the saved UI Image as well if needed using
                //var i = image as UIImage;
                if (error != null)
                {
                    Console.WriteLine(error.ToString());
                }
            });
        }

        public void checkCameraAccess()
        {
            if (AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video) != AVAuthorizationStatus.Authorized)
            {
                App.cameraAccessGranted = false;
            }
            else
            {
                App.cameraAccessGranted = true;
            }
        }

        #endregion
    }
}
