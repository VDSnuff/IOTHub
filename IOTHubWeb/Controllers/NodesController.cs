using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IOTHub.Models;
using System.Security.Claims;
using IOTHub.BusinessLogic;
using IOTHub.ViewModels;

namespace IOTHub.Controllers
{
    [Authorize]
    public class NodesController : BaseController
    {
    
        // GET: Nodes
        public async Task<ActionResult> Index()
        {
            return View(await db.Nodes.ToListAsync());
        }

        // GET: Nodes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = new Node();
            node = await db.Nodes.FindAsync(id);
            NodeDetailsViewModels nodeDetailsViewModels = new NodeDetailsViewModels
            {
                NodeDedails = node,
                Dots = new List<Dot>()
            };
            nodeDetailsViewModels.Dots = await db.Dots.Where(x => x.NodeId == node.Id).ToListAsync();
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(nodeDetailsViewModels);
        }

        // GET: Nodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Country,City,Street,Area,Latitude,Longitude")] Node node)
        {
            node.OwnerID = GetUserId();
            //if (ModelState.IsValid)
            //{
                db.Nodes.Add(node);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            //}
           // return View(node);
        }

        // GET: Nodes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // POST: Nodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OwnerID,Name,Description,Country,City,Street,Area,Latitude,Longitude")] Node node)
        {
            if (ModelState.IsValid)
            {
                db.Entry(node).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(node);
        }

        // GET: Nodes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // POST: Nodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Node node = await db.Nodes.FindAsync(id);
            db.Nodes.Remove(node);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
