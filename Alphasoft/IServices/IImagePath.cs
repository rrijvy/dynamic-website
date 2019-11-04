using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alphasoft.IServices
{
    public interface IImagePath
    {
        string GetImagePath(string fileName, string parentFolderName, string folderName);
        string GetImagePathForDb(string imagePath);
    }
}
