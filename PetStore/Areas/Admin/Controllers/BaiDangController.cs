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
    public class BaiDangController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/BaiDang
        public ActionResult Index()
        {
            var bAIDANGs = db.BAIDANG.Include(b => b.TAIKHOAN);
            return View(bAIDANGs.ToList());
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
        // GET: Admin/BaiDang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAIDANG bAIDANG = db.BAIDANG.Find(id);
            if (bAIDANG == null)
            {
                return HttpNotFound();
            }
            return View(bAIDANG);
        }

        // GET: Admin/BaiDang/Create
        public ActionResult Create()
        {
            ViewBag.TenDangNhap = new SelectList(db.TAIKHOAN, "TenDangNhap", "TenDangNhap");
            return View();
        }

        // POST: Admin/BaiDang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBD,TieuDe,NgayDang,Hinh,NoiDung,TenDangNhap")] BAIDANG bAIDANG)
        {
            if (ModelState.IsValid)
            {
                db.BAIDANG.Add(bAIDANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TenDangNhap = new SelectList(db.TAIKHOAN, "TenDangNhap", "TenDangNhap", bAIDANG.TenDangNhap);
            return View(bAIDANG);
        }

        // GET: Admin/BaiDang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAIDANG bAIDANG = db.BAIDANG.Find(id);
            if (bAIDANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenDangNhap = new SelectList(db.TAIKHOAN, "TenDangNhap", "TenDangNhap", bAIDANG.TenDangNhap);
            return View(bAIDANG);
        }

        // POST: Admin/BaiDang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBD,TieuDe,NgayDang,Hinh,NoiDung,TenDangNhap")] BAIDANG bAIDANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAIDANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenDangNhap = new SelectList(db.TAIKHOAN, "TenDangNhap", "TenDangNhap", bAIDANG.TenDangNhap);
            return View(bAIDANG);
        }

        // GET: Admin/BaiDang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAIDANG bAIDANG = db.BAIDANG.Find(id);
            if (bAIDANG == null)
            {
                return HttpNotFound();
            }
            return View(bAIDANG);
        }

        // POST: Admin/BaiDang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BAIDANG bAIDANG = db.BAIDANG.Find(id);
            db.BAIDANG.Remove(bAIDANG);
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
