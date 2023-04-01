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
        public void getNewId()
        {
            // Kết nối tới cơ sở dữ liệu
            // Truy vấn lấy id của sản phẩm cuối cùng có dạng SP0x
            var reader = db.KHACHHANG
                        .OrderByDescending(d => d.MaKH)
                        .Select(d => d.MaKH)
                        .FirstOrDefault(); ;
            int lastId = 0;
            lastId = int.Parse(reader.ToString());
            lastId += 1;
            string id = lastId.ToString();
            ViewBag.lastId = id.ToString();
        }
        // GET: Admin/KhachHang
        public ActionResult Index()
        {
            return View(db.KHACHHANG.ToList());
        }

        // GET: Admin/KhachHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANG.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // GET: Admin/KhachHang/Create
        public ActionResult Create()
        {
            getNewId();
            return View();
        }

        // POST: Admin/KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,TenKH,GioTinh,NgaySinh,DiaChi,SĐT,Email,DiemTichLuy,TenDangNhap,MatKhau")] KHACHHANG kHACHHANG,FormCollection collection)
        {
            string mail = collection["Email"].ToString();
            var rmail = db.KHACHHANG.FirstOrDefault(x => x.Email == mail);
            if (rmail != null)
            {
                TempData["message"] = new PushNoti("danger", "Email '" + mail + "' trùng!");
                return RedirectToAction("Create");
            }
            string num = collection["SĐT"].ToString();
            var rnum = db.KHACHHANG.FirstOrDefault(x => x.SĐT == num);
            if (rnum != null)
            {
                TempData["message"] = new PushNoti("danger", "Liên hệ bị trùng '" + rnum + "' !");
                return RedirectToAction("Create");
            }
            var currentDate = DateTime.Today;

            // Kiểm tra ngày sinh của khách hàng có ít nhất 1 năm trước so với ngày hiện tại hay không
            if (kHACHHANG.NgaySinh.AddYears(1) > currentDate)
            {
                ModelState.AddModelError("NgaySinh", "Ngày sinh phải ít nhất 1 năm trước ngày hiện tại");
                return View(kHACHHANG);
            }
            if (ModelState.IsValid)
            {
                db.KHACHHANG.Add(kHACHHANG);
                db.SaveChanges();
                TempData["message"] = new PushNoti("success", "Thêm Khách hàng thành công !");
                return RedirectToAction("Index");
            }

            return View(kHACHHANG);
        }

        // GET: Admin/KhachHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANG.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: Admin/KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,TenKH,GioTinh,NgaySinh,DiaChi,SĐT,Email,DiemTichLuy,TenDangNhap,MatKhau")] KHACHHANG kHACHHANG,FormCollection collection)
        {
            string mail = collection["Email"].ToString();
            var rmail = db.KHACHHANG.FirstOrDefault(x => x.Email == mail);
            if (rmail != null)
            {
                TempData["message"] = new PushNoti("danger", "Email '" + mail + "' trùng!");
                return RedirectToAction("Create");
            }
            string num = collection["SĐT"].ToString();
            var rnum = db.KHACHHANG.FirstOrDefault(x => x.SĐT == num);
            if (rnum != null)
            {
                TempData["message"] = new PushNoti("danger", "Liên hệ bị trùng '" + rnum + "' !");
                return RedirectToAction("Create");
            }
            var currentDate = DateTime.Today;

            // Kiểm tra ngày sinh của khách hàng có ít nhất 1 năm trước so với ngày hiện tại hay không
            if (kHACHHANG.NgaySinh.AddYears(1) > currentDate)
            {
                ModelState.AddModelError("NgaySinh", "Ngày sinh phải ít nhất 1 năm trước ngày hiện tại");
                return View(kHACHHANG);
            }
            if (ModelState.IsValid)
            {
                db.Entry(kHACHHANG).State = EntityState.Modified;
                db.SaveChanges(); 
                TempData["Message"] = new PushNoti("info", "Cập nhật Khách hàng thành công!");
                return RedirectToAction("Index");
            }
            return View(kHACHHANG);
        }

        // GET: Admin/KhachHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANG.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: Admin/KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHACHHANG kHACHHANG = db.KHACHHANG.Find(id);
            db.KHACHHANG.Remove(kHACHHANG);
            db.SaveChanges();
            TempData["Message"] = new PushNoti("danger", "Xóa Khách hàng Thành công!");
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
