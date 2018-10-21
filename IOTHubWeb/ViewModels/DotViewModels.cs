using IOTHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOTHub.ViewModels
{
    public class DotViewModels
    {
        public Dot Dot { get; set; }
        public string IP { get; set; }
        public int? Port { get; set; }
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public List<DotType> DotTypes { get; set; }
        public int[] SelectedValuesT { get; set; }
        public IEnumerable<SelectListItem> ValuesT { get; set; }
        public DotViewModels()
        {
            this.DotTypes = new List<DotType>();
            this.Dot = new Dot();
        }
    }
}