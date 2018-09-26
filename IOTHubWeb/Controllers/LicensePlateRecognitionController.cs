using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using IOTHub.BusinessLogic;
using IOTHubWeb.BusinessLogic;

namespace IOTHub.Controllers
{
    public class LicensePlateRecognitionController : Controller
    {
        public ActionResult Index()
        {
            HostingEnvironment.QueueBackgroundWorkItem(ct => RunLicensePlateRecognition());
            return View();
        }

        private bool RunLicensePlateRecognition()
        {
            string folderPath = Server.MapPath(@"~/App_Data/");
            ImgImport imgImport = new ImgImport(folderPath);
            ProcessImage processImage = new ProcessImage();
            if (!imgImport.IsEmpty())
            {
                foreach(Mat img in imgImport.LoadImages())
                processImage.Process(img, "");
                return true;
            }
            else return false;
        }
    }
}