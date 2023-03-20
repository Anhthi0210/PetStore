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
    public class PhuongThucThanhToanController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/PhuongThucThanhToan
        public ActionResult Index()
        {
            return View(db.PHUONGTHUCTHANHTOANs.ToList());
        }

        // GET: Admin/PhuongThucThanhToan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHUONGTHUCTHANHTOAN pHUONGTHUCTHANHTOAN = db.PHUONGTHUCTHANHTOANs.Find(id);
            if (pHUONGTHUCTHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(pHUONGTHUCTHANHTOAN);
        }

        // GET: Admin/PhuongThucThanhToan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhuongThucThanhToan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPTTT,TenPTTT")] PHUONGTHUCTHANHTOAN pHUONGTHUCTHANHTOAN)
        {
            if (ModelState.IsValid)
            {
                db.PHUONGTHUCTHANHTOANs.Add(pHUONGTHUCTHANHTOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHUONGTHUCTHANHTOAN);
        }

        // GET: Admin/PhuongThucThanhToan/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHUONGTHUCTHANHTOAN pHUONGTHUCTHANHTOAN = db.PHUONGTHUCTHANHTOANs.Find(id);
            if (pHUONGTHUCTHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(pHUONGTHUCTHANHTOAN);
        }

        // POST: Admin/PhuongThucThanhToan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPTTT,TenPTTT")] PHUONGTHUCTHANHTOAN pHUONGTHUCTHANHTOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHUONGTHUCTHANHTOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHUONGTHUCTHANHTOAN);
        }

        // GET: Admin/PhuongThucThanhToan/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHUONGTHUCTHANHTOAN pHUONGTHUCTHANHTOAN = db.PHUONGTHUCTHANHTOANs.Find(id);
            if (pHUONGTHUCTHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(pHUONGTHUCTHANHTOAN);
        }

        // POST: Admin/PhuongThucThanhToan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHUONGTHUCTHANHTOAN pHUONGTHUCTHANHTOAN = db.PHUONGTHUCTHANHTOANs.Find(id);
            db.PHUONGTHUCTHANHTOANs.Remove(pHUONGTHUCTHANHTOAN);
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
