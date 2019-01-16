using IOTHub.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Web;

namespace IOTHub.BusinessLogic
{
    public class BusinessLogic
    {
        private ApplicationDbContext _applicationDbContext = new ApplicationDbContext();

        public BusinessLogic()
        {

        }

        public string FindLicensePlateInDB(List<string> words)
        {
            string lpn = "";

            foreach (string word in words)
            {
                string pword = Regex.Replace(word.Trim().ToUpper(), @"\s+", "");
                Car car = _applicationDbContext.Cars.FirstOrDefault(x => x.LicensePlateNumber == pword);
                Debug.WriteLine($"Word: {word}");
                if (car != null) lpn = car.LicensePlateNumber;
                return lpn;
            }
            return lpn;
        }

        public void SendComandToGate(string result)
        {
            if (string.IsNullOrWhiteSpace(result))
            {
                Debug.WriteLine("\n" +
                                "@ !!!!!!!!!!!!!!!!!!!!! @\n" +
                                "@ !!! Do nothing... !!! @\n" +
                                "@ !!!!!!!!!!!!!!!!!!!!! @\n");
            }
            else
            {
                Debug.WriteLine("\n" +
                               "@ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!@\n" +
                               $"  Open the gate (LPN: {result})\n" +
                               "@ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!@\n");
            }
        }
    }
}