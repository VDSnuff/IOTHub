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
using IOTHub.ViewModels;

namespace IOTHub.Controllers
{
    [Authorize]
    public class CarsController : BaseController
    {
        // GET: Cars
        public async Task<ActionResult> Index()
        {
            List<CarsViewModel> carsViewModel = new List<CarsViewModel>();
            List<Car> cars = await db.Cars.ToListAsync();
            IEnumerable<ApplicationUser> userName = db.Users.ToList().Where(x => x.Id == cars.FirstOrDefault().OwnerId);
            foreach (var car in cars)
            {
                CarsViewModel carsVO = new CarsViewModel
                {
                    Id = car.Id,
                    LicensePlateNumber = car.LicensePlateNumber,
                    Model = car.Model,
                    OwnerId = car.OwnerId,
                    Brand = car.Brand,
                    Color = car.Color,
                    UserName = userName.FirstOrDefault().UserName
                };
                carsViewModel.Add(carsVO);
            }

            return View(carsViewModel);
        }

        // GET: Cars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LicensePlateNumber,Brand,Model,Color")] Car car)
        {
            car.OwnerId = GetUserId();
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OwnerId,LicensePlateNumber,Brand,Model,Color")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Car car = await db.Cars.FindAsync(id);
            db.Cars.Remove(car);
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
