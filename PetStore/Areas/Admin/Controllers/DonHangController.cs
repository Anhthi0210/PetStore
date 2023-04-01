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
        public void getNewId()
        {
            // Kết nối tới cơ sở dữ liệu
            // Truy vấn lấy id của sản phẩm cuối cùng có dạng SP0x
            var reader = db.DONHANG
                        .OrderByDescending(d => d.MaDH)
                        .Select(d => d.MaDH)
                        .FirstOrDefault(); ;
            int lastId = 0;
            lastId = int.Parse(reader.ToString());
            lastId += 1;
            string id = lastId.ToString();
            ViewBag.lastId = id.ToString();
        }
        // GET: Admin/DonHang
        public ActionResult Index()
        {
            var dONHANG = db.DONHANG.Include(d => d.KHACHHANG).Include(d => d.PHUONGTHUCGIAOHANG).Include(d => d.PHUONGTHUCTHANHTOAN).Include(d => d.TRANGTHAI);
            return View(dONHANG.ToList());
        }

        // GET: Admin/DonHang/Details/5
        public ActionResult Details(int? id)
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
            getNewId();
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
            List<KHACHHANG> customers = db.KHACHHANG.ToList();
            List<SelectListItem> customerList = new List<SelectListItem>();
            foreach (KHACHHANG customer in customers)
            {
                customerList.Add(new SelectListItem { Value = customer.MaKH.ToString(), Text = customer.TenKH });
            }
            ViewBag.MaKH = customerList;
            ViewBag.MaPTGH = new SelectList(db.PHUONGTHUCGIAOHANG, "MaPTGH", "TenPTGH", dONHANG.MaPTGH);
            ViewBag.MaPTTT = new SelectList(db.PHUONGTHUCTHANHTOAN, "MaPTTT", "TenPTTT", dONHANG.MaPTTT);
            ViewBag.MaTT = new SelectList(db.TRANGTHAI, "MaTT", "TenTT", dONHANG.MaTT);
            if (dONHANG.NgayGiaoHang < dONHANG.NgayDatHang)
            {
                ModelState.AddModelError("NgayGiaoHang", "Ngày giao phải muộn hơn ngày đặt hàng");
                return View(dONHANG);
            }
            if (ModelState.IsValid)
            {
                db.DONHANG.Add(dONHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dONHANG);
        }

        // GET: Admin/DonHang/Edit/5
        public ActionResult Edit(int? id)
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
            List<KHACHHANG> customers = db.KHACHHANG.ToList();
            List<SelectListItem> customerList = new List<SelectListItem>();
            foreach (KHACHHANG customer in customers)
            {
                customerList.Add(new SelectListItem { Value = customer.MaKH.ToString(), Text = customer.TenKH });
            }
            ViewBag.MaKH = customerList;
            ViewBag.MaPTGH = new SelectList(db.PHUONGTHUCGIAOHANG, "MaPTGH", "TenPTGH", dONHANG.MaPTGH);
            ViewBag.MaPTTT = new SelectList(db.PHUONGTHUCTHANHTOAN, "MaPTTT", "TenPTTT", dONHANG.MaPTTT);
            ViewBag.MaTT = new SelectList(db.TRANGTHAI, "MaTT", "TenTT", dONHANG.MaTT);
            if (dONHANG.NgayGiaoHang < dONHANG.NgayDatHang)
            {
                ModelState.AddModelError("NgayGiaoHang", "Ngày giao phải muộn hơn ngày đặt hàng");
                return View(dONHANG);
            }
            if (ModelState.IsValid)
            {
                db.Entry(dONHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dONHANG);
        }

        // GET: Admin/DonHang/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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
