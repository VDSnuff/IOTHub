using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOTHub.ViewModels
{
    public class CarsViewModel
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string LicensePlateNumber { get; set; }
        public string UserName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }
}