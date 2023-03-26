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
    public class VoucherController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/Voucher
        public ActionResult Index()
        {
            return View(db.VOUCHER.ToList());
        }

        // GET: Admin/Voucher/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VOUCHER vOUCHER = db.VOUCHER.Find(id);
            if (vOUCHER == null)
            {
                return HttpNotFound();
            }
            return View(vOUCHER);
        }

        // GET: Admin/Voucher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Voucher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGiam,TenMaGiam,MaKH,SoLuong,NgayBatDau,NgayKetThuc")] VOUCHER vOUCHER)
        {
            if (ModelState.IsValid)
            {
                db.VOUCHER.Add(vOUCHER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vOUCHER);
        }

        // GET: Admin/Voucher/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VOUCHER vOUCHER = db.VOUCHER.Find(id);
            if (vOUCHER == null)
            {
                return HttpNotFound();
            }
            return View(vOUCHER);
        }

        // POST: Admin/Voucher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGiam,TenMaGiam,MaKH,SoLuong,NgayBatDau,NgayKetThuc")] VOUCHER vOUCHER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vOUCHER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vOUCHER);
        }

        // GET: Admin/Voucher/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VOUCHER vOUCHER = db.VOUCHER.Find(id);
            if (vOUCHER == null)
            {
                return HttpNotFound();
            }
            return View(vOUCHER);
        }

        // POST: Admin/Voucher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VOUCHER vOUCHER = db.VOUCHER.Find(id);
            db.VOUCHER.Remove(vOUCHER);
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
