using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IOTHub.Models
{
    public class Dot
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NodeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Place { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}