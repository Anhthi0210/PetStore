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
        public void getNewId()
        {
            // Kết nối tới cơ sở dữ liệu
            // Truy vấn lấy id của sản phẩm cuối cùng có dạng SP0x
            var reader = db.PHUONGTHUCGIAOHANG
                        .Where(d => d.MaPTGH.StartsWith("PTGH"))
                        .OrderByDescending(d => d.MaPTGH)
                        .Select(d => d.MaPTGH)
                        .FirstOrDefault(); ;
            int lastId = 0;
            lastId = int.Parse(reader.Substring(4));
            lastId += 1;
            string id = "PTGH" + lastId.ToString();
            ViewBag.lastId = id.ToString();
        }
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
            getNewId();
            return View();
        }

        // POST: Admin/PhuongThucGiaoHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPTGH,TenPTGH")] PHUONGTHUCGIAOHANG pHUONGTHUCGIAOHANG,FormCollection collection)
        {
            string name = collection["TenPTGH"].ToString();
            var rname = db.PHUONGTHUCGIAOHANG.FirstOrDefault(x => x.TenPTGH == name);
            if (rname != null)
            {
                TempData["message"] = new PushNoti("danger", "Phương thức '" + name + "' đã tồn tại!");
                return RedirectToAction("Create");
            }
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
