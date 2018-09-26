using System.IO;
using Emgu.CV;
using System.Collections.Generic;

namespace IOTHubWeb.BusinessLogic
{
    public class ImgImport
    {
        public List<Mat> images;
        public string FolderPath { get => folderPath; set => folderPath = value; }
        private string folderPath;

        public ImgImport(string folderPath)
        {
            FolderPath = folderPath;
        }

        public List<Mat> LoadImages()
        {
            foreach (string file in Directory.EnumerateFiles(FolderPath, "*.jpg"))
            {
                images = new List<Mat>();
                Mat image = new Mat(file);
                images.Add(image);
            }
            return images;
        }

        public bool IsEmpty()
        {
          return Directory.GetFiles(FolderPath).Length > 0 ? false : true;
        }
    }
}