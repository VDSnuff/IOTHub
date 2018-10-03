using IOTHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOTHub.ViewModels
{
    public class NodeDetailsViewModels
    {
       public Node NodeDedails { get; set; }
       public List<Dot> Dots { get; set; }
    }
}