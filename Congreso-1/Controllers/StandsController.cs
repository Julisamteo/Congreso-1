using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Congreso_1.Models;

namespace Congreso_1.Controllers
{
    public class StandsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stands
        public ActionResult Index()
        {
            var tb_Stand = db.Tb_Stand.Include(s => s.Stand_Type);
            return View(tb_Stand.ToList());
        }

        // GET: Stands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stand stand = db.Tb_Stand.Find(id);
            if (stand == null)
            {
                return HttpNotFound();
            }
            return View(stand);
        }

        // GET: Stands/Create
        public ActionResult Create()
        {
            ViewBag.StandTypeId = new SelectList(db.Tb_Stand_Type, "StandType", "StandName");
            return View();
        }

        // POST: Stands/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase EnterpriseLogo, HttpPostedFileBase EnterpriseBanner,[Bind(Include = "Stand_id,StandTypeId,StandColorA,StandColorB,StandColorC,Available")] Stand stand)
        {
            if (ModelState.IsValid)
            {
                if (EnterpriseLogo != null)
                {
                    var fecha = DateTime.Now.ToString().Replace(" ", "-");
                    String ruta = Server.MapPath("~/Archivos/");
                    var rutaLink = ("../../Archivos/"+ (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + EnterpriseLogo.FileName).ToLower());
                    ruta += (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + EnterpriseLogo.FileName).ToLower();
                    EnterpriseLogo.SaveAs(ruta);
                    stand.EnterpriseLogo = rutaLink;
                }
                if(EnterpriseBanner != null)
                {
                    String ruta = Server.MapPath("~/Archivos/");
                    var rutaLink = ("../../Archivos/" + (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + EnterpriseBanner.FileName).ToLower());
                    ruta += (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + EnterpriseBanner.FileName).ToLower(); 
                    EnterpriseBanner.SaveAs(ruta);
                    stand.EnterpriseBanner = rutaLink;
                }
                db.Tb_Stand.Add(stand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StandTypeId = new SelectList(db.Tb_Stand_Type, "StandType", "StandName", stand.StandTypeId);
            return View(stand);
        }

        // GET: Stands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stand stand = db.Tb_Stand.Find(id);
            if (stand == null)
            {
                return HttpNotFound();
            }
            ViewBag.StandTypeId = new SelectList(db.Tb_Stand_Type, "StandType", "StandName", stand.StandTypeId);
            return View(stand);
        }

        // POST: Stands/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stand_id,StandTypeId,EnterpriseLogo,EnterpriseBanner,StandColorA,StandColorB,StandColorC,Available")] Stand stand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StandTypeId = new SelectList(db.Tb_Stand_Type, "StandType", "StandName", stand.StandTypeId);
            return View(stand);
        }

        // GET: Stands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stand stand = db.Tb_Stand.Find(id);
            if (stand == null)
            {
                return HttpNotFound();
            }
            return View(stand);
        }

        // POST: Stands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stand stand = db.Tb_Stand.Find(id);
            db.Tb_Stand.Remove(stand);
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
