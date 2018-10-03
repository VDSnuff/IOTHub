﻿using IOTHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace IOTHub.BusinessLogic
{
    public class BusinessLogic
    {
        private ApplicationDbContext _applicationDbContext = new ApplicationDbContext();

        public BusinessLogic()
        {

        }

        public bool FindLicensePlateInDB(List<string> words)
        {
            foreach (string word in words)
            {
                if (_applicationDbContext.Cars.Select(x => x.LicensePlateNumber == word).Count() > 0) return true;
            }
            return false;
        }

        public void SendComandToGate(bool status)
        {
            //Do something...
        }
    }
}