﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Congreso_1.Models;
using Congreso_1.ViewModels;

namespace Congreso_1.Controllers
{
    public class WebinarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Webinars
        public ActionResult Index()
        {
            return View(db.Tb_Webinar.ToList());
        }

        // GET: Webinars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webinar webinar = db.Tb_Webinar.Find(id);
            if (webinar == null)
            {
                return HttpNotFound();
            }
            return View(webinar);
        }

        // GET: Webinars/Create
        public ActionResult Create()
        {
            var cw = new CreateWebinar
            {
                WebinarTheme = "",
                congressList = db.Tb_Congress.ToList()
            };
            return View(cw);
        }

        // POST: Webinars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WebinarId,WebinarTheme,WebinarInitialDate,WebinarEndDate,available,congressId")] Webinar webinar)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Webinar.Add(webinar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webinar);
        }

        public ActionResult CreateWebinarViewModel(CreateWebinar cw)
        {
            var webinar = new Webinar
            {
                WebinarTheme = cw.WebinarTheme,
                WebinarInitialDate = cw.WebinarInitialDate,
                WebinarEndDate = cw.WebinarEndDate,
                CongressId = cw.congressId
            };
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        // GET: Webinars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webinar webinar = db.Tb_Webinar.Find(id);
            if (webinar == null)
            {
                return HttpNotFound();
            }
            return View(webinar);
        }

        // POST: Webinars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WebinarId,WebinarTheme,WebinarInitialDate,WebinarEndDate,UserCount,available")] Webinar webinar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webinar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webinar);
        }

        // GET: Webinars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webinar webinar = db.Tb_Webinar.Find(id);
            if (webinar == null)
            {
                return HttpNotFound();
            }
            return View(webinar);
        }

        // POST: Webinars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Webinar webinar = db.Tb_Webinar.Find(id);
            db.Tb_Webinar.Remove(webinar);
            db.SaveChanges();
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
