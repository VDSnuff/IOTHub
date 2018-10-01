﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IOTHub.Models;

namespace IOTHub.Controllers
{
    public class DotsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NodeId,Name,Description,Model,Place,Latitude,Longitude")] Dot dot)
        {
            if (ModelState.IsValid)
            {
                db.Dots.Add(dot);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dot);
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
