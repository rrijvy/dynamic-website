using Alphasoft.IServices;

namespace Alphasoft.Services
{
    public class ImagePath : IImagePath
    {
        private readonly IWebHostEnvironment _environment;
        public ImagePath(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string GetImagePath(string fileName, string parentFolderName, string folderName)
        {
            string path = _environment.WebRootPath + "\\" + "images" + "\\" + parentFolderName + "\\" + folderName;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path + fileName;
        }

        public string GetImagePathForDb(string imagePath)
        {
            string webRootFolder = _environment.WebRootPath;

            imagePath = imagePath.Replace(webRootFolder, "");

            imagePath = imagePath.Replace(@"\", "/");

            return imagePath;
        }
    }
}
