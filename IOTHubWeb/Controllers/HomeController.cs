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
    [Authorize]
    public class HomeController : BaseController
    {
        private CancellationToken id;

        public async Task<ActionResult> Index()
        {
            string userId = GetUserId();
            List<Node> nodes = await db.Nodes.Where(x => x.OwnerID == userId).ToListAsync();
            if(nodes.Count() == 0)
            {
                nodes.Add(new Node { Area = "Test Area", City = "City Test", Country = "Test Country", Description = "Test Description", Id = 0, Latitude = 53.122828, Longitude = 17.995526, Name = "Test Name", OwnerID = userId, Street = "Test Street" });
            }
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