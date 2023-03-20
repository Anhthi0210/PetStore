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
    public class KhachHangController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/KhachHang
        public ActionResult Index()
        {
            var kHACHHANGs = db.KHACHHANGs.Include(k => k.TAIKHOAN);
            return View(kHACHHANGs.ToList());
        }

        // GET: Admin/KhachHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // GET: Admin/KhachHang/Create
        public ActionResult Create()
        {
            ViewBag.TenDangNhap = new SelectList(db.TAIKHOANs, "TenDangNhap", "MatKhau");
            return View();
        }

        // POST: Admin/KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,TenKH,GioTinh,NgaySinh,DiaChi,SĐT,Email,DiemTichLuy,TenDangNhap")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANGs.Add(kHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TenDangNhap = new SelectList(db.TAIKHOANs, "TenDangNhap", "MatKhau", kHACHHANG.TenDangNhap);
            return View(kHACHHANG);
        }

        // GET: Admin/KhachHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenDangNhap = new SelectList(db.TAIKHOANs, "TenDangNhap", "MatKhau", kHACHHANG.TenDangNhap);
            return View(kHACHHANG);
        }

        // POST: Admin/KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,TenKH,GioTinh,NgaySinh,DiaChi,SĐT,Email,DiemTichLuy,TenDangNhap")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACHHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenDangNhap = new SelectList(db.TAIKHOANs, "TenDangNhap", "MatKhau", kHACHHANG.TenDangNhap);
            return View(kHACHHANG);
        }

        // GET: Admin/KhachHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: Admin/KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            db.KHACHHANGs.Remove(kHACHHANG);
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
