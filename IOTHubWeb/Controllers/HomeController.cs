using IOTHub.Models;
using IOTHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IOTHub.Controllers
{
    public class HomeController : BaseController
    {
        private CancellationToken id;

        public async Task<ActionResult> Index()
        {
            string userId = GetUserId();
            List<Node> nodes = await db.Nodes.Where(x => x.OwnerID == userId).ToListAsync();
            return View(nodes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}