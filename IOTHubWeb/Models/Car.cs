using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IOTHub.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "License Plate Number")]
        public string LicensePlateNumber { get; set; }
        [MaxLength(150)]
        public string Brand { get; set; }
        [MaxLength(150)]
        public string Model { get; set; }
        [MaxLength(150)]
        public string Color { get; set; }

    }
}