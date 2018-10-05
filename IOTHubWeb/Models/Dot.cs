using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace IOTHub.Models
{
    public class Dot
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NodeId { get; set; }

        [Required]
        [ForeignKey("DotType")]
        public int Type { get; set; }
        [ScriptIgnore]
        public virtual DotType DotType { get; set; }

        public string Model { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}