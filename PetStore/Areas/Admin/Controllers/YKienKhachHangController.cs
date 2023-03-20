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
    public class YKienKhachHangController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/YKienKhachHang
        public ActionResult Index()
        {
            var yKIENKHACHHANGs = db.YKIENKHACHHANGs.Include(y => y.TAIKHOAN);
            return View(yKIENKHACHHANGs.ToList());
        }

        // GET: Admin/YKienKhachHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YKIENKHACHHANG yKIENKHACHHANG = db.YKIENKHACHHANGs.Find(id);
            if (yKIENKHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(yKIENKHACHHANG);
        }

        // GET: Admin/YKienKhachHang/Create
        public ActionResult Create()
        {
            ViewBag.TenDangNhap = new SelectList(db.TAIKHOANs, "TenDangNhap", "MatKhau");
            return View();
        }

        // POST: Admin/YKienKhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaYKKH,NgayDang,SĐT,Email,NoiDung,TenDangNhap")] YKIENKHACHHANG yKIENKHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.YKIENKHACHHANGs.Add(yKIENKHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TenDangNhap = new SelectList(db.TAIKHOANs, "TenDangNhap", "MatKhau", yKIENKHACHHANG.TenDangNhap);
            return View(yKIENKHACHHANG);
        }

        // GET: Admin/YKienKhachHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YKIENKHACHHANG yKIENKHACHHANG = db.YKIENKHACHHANGs.Find(id);
            if (yKIENKHACHHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenDangNhap = new SelectList(db.TAIKHOANs, "TenDangNhap", "MatKhau", yKIENKHACHHANG.TenDangNhap);
            return View(yKIENKHACHHANG);
        }

        // POST: Admin/YKienKhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaYKKH,NgayDang,SĐT,Email,NoiDung,TenDangNhap")] YKIENKHACHHANG yKIENKHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yKIENKHACHHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenDangNhap = new SelectList(db.TAIKHOANs, "TenDangNhap", "MatKhau", yKIENKHACHHANG.TenDangNhap);
            return View(yKIENKHACHHANG);
        }

        // GET: Admin/YKienKhachHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YKIENKHACHHANG yKIENKHACHHANG = db.YKIENKHACHHANGs.Find(id);
            if (yKIENKHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(yKIENKHACHHANG);
        }

        // POST: Admin/YKienKhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            YKIENKHACHHANG yKIENKHACHHANG = db.YKIENKHACHHANGs.Find(id);
            db.YKIENKHACHHANGs.Remove(yKIENKHACHHANG);
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
