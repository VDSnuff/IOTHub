using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace IOTHub.Models
{
    public class DotType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}