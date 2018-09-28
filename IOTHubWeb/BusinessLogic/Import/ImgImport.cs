using System.IO;
using Emgu.CV;
using System.Collections.Generic;
using System.Net;
using System;
using System.Drawing;

namespace IOTHubWeb.BusinessLogic
{
    public class ImgImport
    {
        public static List<Mat> images;
        public string FolderPath { get => folderPath; set => folderPath = value; }
        public static List<string> filesList;

        private string folderPath;

        public ImgImport(string folderPath)
        {
            FolderPath = folderPath;
        }

        public List<Mat> LoadImages()
        {

            images = new List<Mat>();
            foreach (string file in Directory.EnumerateFiles(FolderPath, "*.jpg"))
            {
   
                Mat image = new Mat(file);
                images.Add(image);
            }
            return images;
        }

        private static List<string> ListFTPDirectory()
        {
            filesList = new List<string>();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://{IOTHub.Properties.Settings.Default.ftpIPWork}/");
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential("v.dovnich@gmail.com", "masikas290");
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            while (!reader.EndOfStream)
            {
                string fileName = reader.ReadLine();
                filesList.Add(fileName);
            }

            reader.Close();
            response.Close();
            
            return filesList;
        }

        //private static List<Mat> DownloadAllFiles()
        //{
        //    images = new List<Mat>();

        //    foreach (var fileName in filesList)
        //    {
        //        using (WebClient client = new WebClient())
        //        {
        //            client.Credentials = new NetworkCredential("v.dovnich@gmail.com", "masikas290");
        //            byte[] img = client.DownloadData($"ftp://{IOTHub.Properties.Settings.Default.ftpIPWork}/{fileName}");

        //            Mat image = new Mat(client.DownloadString($"ftp://{IOTHub.Properties.Settings.Default.ftpIPWork}/{fileName}"));
        //            //Mat image = new Mat(System.Text.UTF8Encoding.UTF8.GetString(client.DownloadData($"ftp://{IOTHub.Properties.Settings.Default.ftpIPWork}/{fileName}")));
        //            images.Add(image);
        //        }
        //    }

        //    return images;
        //}

        private static Image ConvertByteArreyToImage(byte[] img)
        {
            using (MemoryStream ms = new MemoryStream(img))
            {
                return Image.FromStream(ms);
            }
        }

        public bool IsEmpty()
        {
            return Directory.GetFiles(FolderPath).Length > 0 ? false : true;
        }


    }
}