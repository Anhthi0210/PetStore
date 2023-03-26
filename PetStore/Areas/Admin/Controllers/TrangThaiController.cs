using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetStore.Models;

namespace PetStore.Areas.Admin.Controllers
{
    public class TrangThaiController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/TrangThai
        public ActionResult Index()
        {
            return View(db.TRANGTHAI.ToList());
        }

        // GET: Admin/TrangThai/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANGTHAI tRANGTHAI = db.TRANGTHAI.Find(id);
            if (tRANGTHAI == null)
            {
                return HttpNotFound();
            }
            return View(tRANGTHAI);
        }

        // GET: Admin/TrangThai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TrangThai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTT,TenTT")] TRANGTHAI tRANGTHAI)
        {
            if (ModelState.IsValid)
            {
                db.TRANGTHAI.Add(tRANGTHAI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRANGTHAI);
        }

        // GET: Admin/TrangThai/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANGTHAI tRANGTHAI = db.TRANGTHAI.Find(id);
            if (tRANGTHAI == null)
            {
                return HttpNotFound();
            }
            return View(tRANGTHAI);
        }

        // POST: Admin/TrangThai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTT,TenTT")] TRANGTHAI tRANGTHAI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRANGTHAI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tRANGTHAI);
        }

        // GET: Admin/TrangThai/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANGTHAI tRANGTHAI = db.TRANGTHAI.Find(id);
            if (tRANGTHAI == null)
            {
                return HttpNotFound();
            }
            return View(tRANGTHAI);
        }

        // POST: Admin/TrangThai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TRANGTHAI tRANGTHAI = db.TRANGTHAI.Find(id);
            db.TRANGTHAI.Remove(tRANGTHAI);
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
