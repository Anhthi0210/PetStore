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
    public class DonHangController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/DonHang
        public ActionResult Index()
        {
            var dONHANGs = db.DONHANG.Include(d => d.KHACHHANG).Include(d => d.PHUONGTHUCGIAOHANG).Include(d => d.PHUONGTHUCTHANHTOAN).Include(d => d.TRANGTHAI);
            return View(dONHANGs.ToList());
        }

        // GET: Admin/DonHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANG.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // GET: Admin/DonHang/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANG, "MaKH", "TenKH");
            ViewBag.MaPTGH = new SelectList(db.PHUONGTHUCGIAOHANG, "MaPTGH", "TenPTGH");
            ViewBag.MaPTTT = new SelectList(db.PHUONGTHUCTHANHTOAN, "MaPTTT", "TenPTTT");
            ViewBag.MaTT = new SelectList(db.TRANGTHAI, "MaTT", "TenTT");
            return View();
        }

        // POST: Admin/DonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,TenNguoiNhan,DiaChiNhan,SĐT,NgayDatHang,NgayGiaoHang,Note,TongTien,MaKH,MaPTTT,MaPTGH,MaTT")] DONHANG dONHANG)
        {
            if (ModelState.IsValid)
            {
                db.DONHANG.Add(dONHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACHHANG, "MaKH", "TenKH", dONHANG.MaKH);
            ViewBag.MaPTGH = new SelectList(db.PHUONGTHUCGIAOHANG, "MaPTGH", "TenPTGH", dONHANG.MaPTGH);
            ViewBag.MaPTTT = new SelectList(db.PHUONGTHUCTHANHTOAN, "MaPTTT", "TenPTTT", dONHANG.MaPTTT);
            ViewBag.MaTT = new SelectList(db.TRANGTHAI, "MaTT", "TenTT", dONHANG.MaTT);
            return View(dONHANG);
        }

        // GET: Admin/DonHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANG.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANG, "MaKH", "TenKH", dONHANG.MaKH);
            ViewBag.MaPTGH = new SelectList(db.PHUONGTHUCGIAOHANG, "MaPTGH", "TenPTGH", dONHANG.MaPTGH);
            ViewBag.MaPTTT = new SelectList(db.PHUONGTHUCTHANHTOAN, "MaPTTT", "TenPTTT", dONHANG.MaPTTT);
            ViewBag.MaTT = new SelectList(db.TRANGTHAI, "MaTT", "TenTT", dONHANG.MaTT);
            return View(dONHANG);
        }

        // POST: Admin/DonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,TenNguoiNhan,DiaChiNhan,SĐT,NgayDatHang,NgayGiaoHang,Note,TongTien,MaKH,MaPTTT,MaPTGH,MaTT")] DONHANG dONHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANG, "MaKH", "TenKH", dONHANG.MaKH);
            ViewBag.MaPTGH = new SelectList(db.PHUONGTHUCGIAOHANG, "MaPTGH", "TenPTGH", dONHANG.MaPTGH);
            ViewBag.MaPTTT = new SelectList(db.PHUONGTHUCTHANHTOAN, "MaPTTT", "TenPTTT", dONHANG.MaPTTT);
            ViewBag.MaTT = new SelectList(db.TRANGTHAI, "MaTT", "TenTT", dONHANG.MaTT);
            return View(dONHANG);
        }

        // GET: Admin/DonHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANG.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // POST: Admin/DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DONHANG dONHANG = db.DONHANG.Find(id);
            db.DONHANG.Remove(dONHANG);
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
