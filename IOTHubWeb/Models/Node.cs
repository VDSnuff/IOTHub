using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IOTHub.Models
{
    public class Node
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OwnerID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}