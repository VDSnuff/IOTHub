using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace IOTHub.BusinessLogic
{
    public class ProcessImage
    {
        private LicensePlateRecognitionEngine _licensePlateRecognitionEngine;

        public void Process(IInputOutputArray image, string path)
        {
            Stopwatch watch = Stopwatch.StartNew();

            _licensePlateRecognitionEngine = new LicensePlateRecognitionEngine(path);
            List<IInputOutputArray> licensePlateImagesList = new List<IInputOutputArray>();
            List<IInputOutputArray> filteredLicensePlateImagesList = new List<IInputOutputArray>();
            List<RotatedRect> licenseBoxList = new List<RotatedRect>();
            List<string> words = _licensePlateRecognitionEngine.DetectLicensePlate(
               image,
               licensePlateImagesList,
               filteredLicensePlateImagesList,
               licenseBoxList);

            watch.Stop();
        }
    }
}