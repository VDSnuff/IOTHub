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
using IOTHub.ViewModels;

namespace IOTHub.Controllers
{

    [Authorize]
    public class DotsController : BaseController
    {

        // GET: Dots
        public async Task<ActionResult> Index()
        {
            return View(await db.Dots.ToListAsync());
        }

        // GET: Dots/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dot dot = await db.Dots.FindAsync(id);
            if (dot == null)
            {
                return HttpNotFound();
            }
            return View(dot);
        }

        // GET: Dots/Create
        public ActionResult Create(int nodeId)
        {

            Node node = db.Nodes.Find(nodeId);
            DotViewModels dotView = new DotViewModels();
            dotView.Dot.NodeId = node.Id;



            // Drop Down List For Teachers
            dotView.DotTypes = db.DotTypes.ToList();
            List<SelectListItem> itemsT = new List<SelectListItem>();
            foreach (var item in dotView.DotTypes)
            {
                itemsT.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Type });
            }
            dotView.ValuesT = itemsT;

            return View(dotView);
        }

        // POST: Dots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DotViewModels dotView)
        {
            DotType dotType = new DotType();
            dotType = db.DotTypes.Find(dotView.SelectedValuesT.FirstOrDefault());
            Dot dot = new Dot();
            dot = dotView.Dot;
            dot.Type = dotType.Id;

            db.Dots.Add(dot);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Dots/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dot dot = await db.Dots.FindAsync(id);
            if (dot == null)
            {
                return HttpNotFound();
            }
            return View(dot);
        }

        // POST: Dots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NodeId,Name,Description,Model,Place,Latitude,Longitude")] Dot dot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dot).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dot);
        }

        // GET: Dots/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dot dot = await db.Dots.FindAsync(id);
            if (dot == null)
            {
                return HttpNotFound();
            }
            return View(dot);
        }

        // POST: Dots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Dot dot = await db.Dots.FindAsync(id);
            db.Dots.Remove(dot);
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
