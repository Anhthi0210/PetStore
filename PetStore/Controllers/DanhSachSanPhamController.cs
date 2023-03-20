using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using PetStore.Models;
using PagedList;

namespace PetStore.Controllers
{
    public class DanhSachSanPhamController : Controller
    {
        private DataContext db = new DataContext();

        // GET: DanhSachSanPham
        public ActionResult Index(int ? page)
        {
            if (page == null) page = 1;
            //var all_Sach = (from s in data.Saches select s).OrderBy(m => m.masach);
            int pageSize = 16;
            int pageNum = page ?? 1;

            //return View(all_Sach.ToPagedList(pageNum, pageSize));
            var sANPHAMs = db.SANPHAMs.Include(s => s.DANHMUC).Include(s => s.LOAIPET).Include(s => s.NHACUNGCAP);
            return View(sANPHAMs.ToList().ToPagedList(pageNum, pageSize));
        }

        // GET: DanhSachSanPham/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: DanhSachSanPham/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DANHMUCs, "MaDM", "TenDM");
            ViewBag.MaLoaiPet = new SelectList(db.LOAIPETs, "MaLoaiPet", "TenLoaiPet");
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC");
            return View();
        }

        // POST: DanhSachSanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,DonGia,MoTa,SoLuong,Hinh,MaLoaiPet,MaNCC,MaDM")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.DANHMUCs, "MaDM", "TenDM", sANPHAM.MaDM);
            ViewBag.MaLoaiPet = new SelectList(db.LOAIPETs, "MaLoaiPet", "TenLoaiPet", sANPHAM.MaLoaiPet);
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC", sANPHAM.MaNCC);
            return View(sANPHAM);
        }

        // GET: DanhSachSanPham/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DANHMUCs, "MaDM", "TenDM", sANPHAM.MaDM);
            ViewBag.MaLoaiPet = new SelectList(db.LOAIPETs, "MaLoaiPet", "TenLoaiPet", sANPHAM.MaLoaiPet);
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC", sANPHAM.MaNCC);
            return View(sANPHAM);
        }

        // POST: DanhSachSanPham/Edit/5
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
                return RedirectToAction("Index");
            }
            ViewBag.MaDM = new SelectList(db.DANHMUCs, "MaDM", "TenDM", sANPHAM.MaDM);
            ViewBag.MaLoaiPet = new SelectList(db.LOAIPETs, "MaLoaiPet", "TenLoaiPet", sANPHAM.MaLoaiPet);
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC", sANPHAM.MaNCC);
            return View(sANPHAM);
        }

        // GET: DanhSachSanPham/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: DanhSachSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
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
