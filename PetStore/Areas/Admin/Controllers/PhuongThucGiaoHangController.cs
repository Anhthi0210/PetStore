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
    public class PhuongThucGiaoHangController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/PhuongThucGiaoHang
        public ActionResult Index()
        {
            return View(db.PHUONGTHUCGIAOHANG.ToList());
        }

        // GET: Admin/PhuongThucGiaoHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHUONGTHUCGIAOHANG pHUONGTHUCGIAOHANG = db.PHUONGTHUCGIAOHANG.Find(id);
            if (pHUONGTHUCGIAOHANG == null)
            {
                return HttpNotFound();
            }
            return View(pHUONGTHUCGIAOHANG);
        }

        // GET: Admin/PhuongThucGiaoHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhuongThucGiaoHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPTGH,TenPTGH")] PHUONGTHUCGIAOHANG pHUONGTHUCGIAOHANG)
        {
            if (ModelState.IsValid)
            {
                db.PHUONGTHUCGIAOHANG.Add(pHUONGTHUCGIAOHANG);
                db.SaveChanges();
                TempData["message"] = new PushNoti("success", "Thêm thành công !");
                return RedirectToAction("Index");
            }

            return View(pHUONGTHUCGIAOHANG);
        }

        // GET: Admin/PhuongThucGiaoHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHUONGTHUCGIAOHANG pHUONGTHUCGIAOHANG = db.PHUONGTHUCGIAOHANG.Find(id);
            if (pHUONGTHUCGIAOHANG == null)
            {
                return HttpNotFound();
            }
            return View(pHUONGTHUCGIAOHANG);
        }

        // POST: Admin/PhuongThucGiaoHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPTGH,TenPTGH")] PHUONGTHUCGIAOHANG pHUONGTHUCGIAOHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHUONGTHUCGIAOHANG).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = new PushNoti("info", "Cập nhật thành công !");
                return RedirectToAction("Index");
            }
            return View(pHUONGTHUCGIAOHANG);
        }

        // GET: Admin/PhuongThucGiaoHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHUONGTHUCGIAOHANG pHUONGTHUCGIAOHANG = db.PHUONGTHUCGIAOHANG.Find(id);
            if (pHUONGTHUCGIAOHANG == null)
            {
                return HttpNotFound();
            }
            return View(pHUONGTHUCGIAOHANG);
        }

        // POST: Admin/PhuongThucGiaoHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHUONGTHUCGIAOHANG pHUONGTHUCGIAOHANG = db.PHUONGTHUCGIAOHANG.Find(id);
            db.PHUONGTHUCGIAOHANG.Remove(pHUONGTHUCGIAOHANG);
            db.SaveChanges();
            TempData["message"] = new PushNoti("danger", "Xóa thành công !");
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
