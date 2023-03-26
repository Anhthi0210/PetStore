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
    public class PhanQuyenController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/PhanQuyen
        public ActionResult Index()
        {
            return View(db.PHANQUYEN.ToList());
        }

        // GET: Admin/PhanQuyen/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANQUYEN pHANQUYEN = db.PHANQUYEN.Find(id);
            if (pHANQUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHANQUYEN);
        }

        // GET: Admin/PhanQuyen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhanQuyen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPQ,TenPQ")] PHANQUYEN pHANQUYEN)
        {
            if (ModelState.IsValid)
            {
                db.PHANQUYEN.Add(pHANQUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHANQUYEN);
        }

        // GET: Admin/PhanQuyen/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANQUYEN pHANQUYEN = db.PHANQUYEN.Find(id);
            if (pHANQUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHANQUYEN);
        }

        // POST: Admin/PhanQuyen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPQ,TenPQ")] PHANQUYEN pHANQUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHANQUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHANQUYEN);
        }

        // GET: Admin/PhanQuyen/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANQUYEN pHANQUYEN = db.PHANQUYEN.Find(id);
            if (pHANQUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHANQUYEN);
        }

        // POST: Admin/PhanQuyen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHANQUYEN pHANQUYEN = db.PHANQUYEN.Find(id);
            db.PHANQUYEN.Remove(pHANQUYEN);
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
