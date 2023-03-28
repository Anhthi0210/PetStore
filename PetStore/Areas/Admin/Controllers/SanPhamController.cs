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
    public class SanPhamController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/SanPham
        public ActionResult Index()
        {
            var sANPHAMs = db.SANPHAM.Include(s => s.DANHMUC).Include(s => s.LOAIPET).Include(s => s.NHACUNGCAP);
            return View(sANPHAMs.ToList());
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
        // GET: Admin/SanPham/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAM.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DANHMUC, "MaDM", "TenDM");
            ViewBag.MaLoaiPet = new SelectList(db.LOAIPET, "MaLoaiPet", "TenLoaiPet");
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAP, "MaNCC", "TenNCC");
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,DonGia,MoTa,SoLuong,Hinh,MaLoaiPet,MaNCC,MaDM")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAM.Add(sANPHAM);
                db.SaveChanges();
                TempData["message"] = new PushNoti("success", "Thêm Danh mục thành công !");
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.DANHMUC, "MaDM", "TenDM", sANPHAM.MaDM);
            ViewBag.MaLoaiPet = new SelectList(db.LOAIPET, "MaLoaiPet", "TenLoaiPet", sANPHAM.MaLoaiPet);
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAP, "MaNCC", "TenNCC", sANPHAM.MaNCC);
            return View(sANPHAM);
        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAM.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DANHMUC, "MaDM", "TenDM", sANPHAM.MaDM);
            ViewBag.MaLoaiPet = new SelectList(db.LOAIPET, "MaLoaiPet", "TenLoaiPet", sANPHAM.MaLoaiPet);
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAP, "MaNCC", "TenNCC", sANPHAM.MaNCC);
            return View(sANPHAM);
        }

        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,DonGia,MoTa,SoLuong,Hinh,MaLoaiPet,MaNCC,MaDM")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = new PushNoti("info", "Cập nhật Danh mục thành công !");
                return RedirectToAction("Index");
            }
            ViewBag.MaDM = new SelectList(db.DANHMUC, "MaDM", "TenDM", sANPHAM.MaDM);
            ViewBag.MaLoaiPet = new SelectList(db.LOAIPET, "MaLoaiPet", "TenLoaiPet", sANPHAM.MaLoaiPet);
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAP, "MaNCC", "TenNCC", sANPHAM.MaNCC);
            return View(sANPHAM);
        }

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAM.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SANPHAM sANPHAM = db.SANPHAM.Find(id);
            db.SANPHAM.Remove(sANPHAM);
            db.SaveChanges();
            TempData["message"] = new PushNoti("danger", "Xóa Danh mục thành công !");
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
