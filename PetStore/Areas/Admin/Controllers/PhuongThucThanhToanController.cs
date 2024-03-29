﻿using System;
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
        public void getNewId()
        {
            // Kết nối tới cơ sở dữ liệu
            // Truy vấn lấy id của sản phẩm cuối cùng có dạng SP0x
            var reader = db.PHUONGTHUCTHANHTOAN
                        .Where(d => d.MaPTTT.StartsWith("PTTT"))
                        .OrderByDescending(d => d.MaPTTT)
                        .Select(d => d.MaPTTT)
                        .FirstOrDefault(); ;
            int lastId = 0;
            lastId = int.Parse(reader.Substring(4));
            lastId += 1;
            string id = "PTTT" + lastId.ToString();
            ViewBag.lastId = id.ToString();
        }
        // GET: Admin/PhuongThucThanhToan
        public ActionResult Index()
        {
            return View(db.PHUONGTHUCTHANHTOAN.ToList());
        }

        // GET: Admin/PhuongThucThanhToan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHUONGTHUCTHANHTOAN pHUONGTHUCTHANHTOAN = db.PHUONGTHUCTHANHTOAN.Find(id);
            if (pHUONGTHUCTHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(pHUONGTHUCTHANHTOAN);
        }

        // GET: Admin/PhuongThucThanhToan/Create
        public ActionResult Create()
        {
            getNewId();
            return View();
        }

        // POST: Admin/PhuongThucThanhToan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPTTT,TenPTTT")] PHUONGTHUCTHANHTOAN pHUONGTHUCTHANHTOAN,FormCollection collection)
        {
            string name = collection["TenPTTT"].ToString();
            var rname = db.PHUONGTHUCTHANHTOAN.FirstOrDefault(x => x.TenPTTT == name);
            if (rname != null)
            {
                TempData["message"] = new PushNoti("danger", "Phương thức '" + name + "' đã tồn tại!");
                return RedirectToAction("Create");
            }
            if (ModelState.IsValid)
            {
                db.PHUONGTHUCTHANHTOAN.Add(pHUONGTHUCTHANHTOAN);
                db.SaveChanges();
                TempData["message"] = new PushNoti("success", "Thêm thành công !");
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
            PHUONGTHUCTHANHTOAN pHUONGTHUCTHANHTOAN = db.PHUONGTHUCTHANHTOAN.Find(id);
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
                TempData["Message"] = new PushNoti("info", "Cập nhật thành công !");
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
            PHUONGTHUCTHANHTOAN pHUONGTHUCTHANHTOAN = db.PHUONGTHUCTHANHTOAN.Find(id);
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
            PHUONGTHUCTHANHTOAN pHUONGTHUCTHANHTOAN = db.PHUONGTHUCTHANHTOAN.Find(id);
            db.PHUONGTHUCTHANHTOAN.Remove(pHUONGTHUCTHANHTOAN);
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
