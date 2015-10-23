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
    /*
     * iOS implementation of the ISaveAndLoad shared project interface
     * Used for saving and reading files on the users device
     */
    public class SaveAndLoadiOS : ISaveAndLoad
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
            var imageToSave = new UIImage(NSData.FromArray(imageBytes));
            imageToSave.SaveToPhotosAlbum((image, error) =>
            {
                if (error != null)
                {
                     message = "error";
                }
            });

            return message;
        }

        /*
         * checks if the user has granted camera access
         * 
         * On iOS this checks if the camera is authorized
         * and sets to false if it isn't. If the camera
         * is authorized for use by the user it sets to true
         * 
         * Params:
         * none
         * 
         * Returns:
         * none
         */ 
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
