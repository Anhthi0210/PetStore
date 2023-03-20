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
    public class BaiDangController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/BaiDang
        public ActionResult Index()
        {
            var bAIDANGs = db.BAIDANGs.Include(b => b.TAIKHOAN);
            return View(bAIDANGs.ToList());
        }

        // GET: Admin/BaiDang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAIDANG bAIDANG = db.BAIDANGs.Find(id);
            if (bAIDANG == null)
            {
                return HttpNotFound();
            }
            return View(bAIDANG);
        }

        // GET: Admin/BaiDang/Create
        public ActionResult Create()
        {
            ViewBag.TenDangNhap = new SelectList(db.TAIKHOANs, "TenDangNhap", "MatKhau");
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
                db.BAIDANGs.Add(bAIDANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TenDangNhap = new SelectList(db.TAIKHOANs, "TenDangNhap", "MatKhau", bAIDANG.TenDangNhap);
            return View(bAIDANG);
        }

        // GET: Admin/BaiDang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAIDANG bAIDANG = db.BAIDANGs.Find(id);
            if (bAIDANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenDangNhap = new SelectList(db.TAIKHOANs, "TenDangNhap", "MatKhau", bAIDANG.TenDangNhap);
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
            ViewBag.TenDangNhap = new SelectList(db.TAIKHOANs, "TenDangNhap", "MatKhau", bAIDANG.TenDangNhap);
            return View(bAIDANG);
        }

        // GET: Admin/BaiDang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAIDANG bAIDANG = db.BAIDANGs.Find(id);
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
            BAIDANG bAIDANG = db.BAIDANGs.Find(id);
            db.BAIDANGs.Remove(bAIDANG);
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
