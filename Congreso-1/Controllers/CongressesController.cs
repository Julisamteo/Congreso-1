﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Congreso_1.Models;
using Microsoft.AspNet.Identity;

namespace Congreso_1.Controllers
{
    public class CongressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUser Usuario = new ApplicationUser();
        // GET: Congresses
        public ActionResult Index()
        {
            var usuarioID = User.Identity.GetUserId();
            Usuario = db.Users.Where(x => x.Id == usuarioID).FirstOrDefault();
            var consulta = (from congreso in db.Tb_Congress
                            join CongresoEmpresa in db.Tb_Congress_Enterprise on congreso.CongressId equals CongresoEmpresa.CongressId
                            join empresa in db.Tb_Enterprise on CongresoEmpresa.EnterpriseId equals empresa.EnterpriseId
                            where empresa.EnterpriseId == Usuario.EnterpriseId
                            select congreso).ToList();
            return View(consulta);
        }

        // GET: Congresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Congress congress = db.Tb_Congress.Find(id);
            if (congress == null)
            {
                return HttpNotFound();
            }
            return View(congress);
        }

        // GET: Congresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Congresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CongressId,CongressName,CongressTheme,CongressInitialDate,CongressFinalDate,Available")] Congress congress)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Congress.Add(congress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(congress);
        }

        // GET: Congresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Congress congress = db.Tb_Congress.Find(id);
            if (congress == null)
            {
                return HttpNotFound();
            }
            return View(congress);
        }

        // POST: Congresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CongressId,CongressName,CongressTheme,CongressInitialDate,CongressFinalDate,Available")] Congress congress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(congress);
        }

        // GET: Congresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Congress congress = db.Tb_Congress.Find(id);
            if (congress == null)
            {
                return HttpNotFound();
            }
            return View(congress);
        }

        // POST: Congresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Congress congress = db.Tb_Congress.Find(id);
            db.Tb_Congress.Remove(congress);
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
