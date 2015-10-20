using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INB302_WDGS
{
    public interface ISaveAndLoad
    {
        string getFilePath(string fileName);
        void SaveText(string fileName, string text);
        string LoadText(string fileName);
        void saveImageToGallery(string fileName, byte[] streamIn);
        Stream getReadStream(string fileName);
        void checkCameraAccess();
    }
}
