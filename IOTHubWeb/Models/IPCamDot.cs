using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IOTHub.Models
{
    public class IPCamDot
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DotId { get; set; }
        public string IP { get; set; }
        public int? Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}