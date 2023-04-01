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
    public class NhaCungCapController : Controller
    {
        private DataContext db = new DataContext();
        public void getNewId()
        {
            // Kết nối tới cơ sở dữ liệu
            // Truy vấn lấy id của sản phẩm cuối cùng có dạng SP0x
            var reader = db.NHACUNGCAP
                        .Where(d => d.MaNCC.StartsWith("NCC"))
                        .OrderByDescending(d => d.MaNCC)
                        .Select(d => d.MaNCC)
                        .FirstOrDefault(); ;
            int lastId = 0;
            lastId = int.Parse(reader.Substring(3));
            lastId += 1;
            string id = "NCC" + lastId.ToString();
            ViewBag.lastId = id.ToString();
        }
        // GET: Admin/NhaCungCap
        public ActionResult Index()
        {
            return View(db.NHACUNGCAP.ToList());
        }

        // GET: Admin/NhaCungCap/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHACUNGCAP nHACUNGCAP = db.NHACUNGCAP.Find(id);
            if (nHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(nHACUNGCAP);
        }

        // GET: Admin/NhaCungCap/Create
        public ActionResult Create()
        {
            getNewId();
            return View();
        }

        // POST: Admin/NhaCungCap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNCC,TenNCC,SĐT,DiaChi")] NHACUNGCAP nHACUNGCAP, FormCollection collection)
        {
            string name = collection["TenNCC"].ToString();
            var rname = db.NHACUNGCAP.FirstOrDefault(x => x.TenNCC == name);
            if (rname != null)
            {
                TempData["message"] = new PushNoti("danger", "Nhà Cung Cấp '" + name + "' đã tồn tại!");
                return RedirectToAction("Create");
            }
            string num = collection["SĐT"].ToString();
            var rnum = db.NHACUNGCAP.FirstOrDefault(x => x.SĐT == num);
            if (rnum != null)
            {
                TempData["message"] = new PushNoti("danger", "Liên hệ bị trùng '" + rnum + "' !");
                return RedirectToAction("Create");
            }
            string addr = collection["DiaChi"].ToString();
            var raddr = db.NHACUNGCAP.FirstOrDefault(x => x.DiaChi == addr);
            if (raddr != null)
            {
                TempData["message"] = new PushNoti("danger", "Địa chỉ bị trùng '" + raddr + "' !");
                return RedirectToAction("Create");
            }
            if (ModelState.IsValid)
            {
                db.NHACUNGCAP.Add(nHACUNGCAP);
                db.SaveChanges();
                TempData["message"] = new PushNoti("success", "Thêm Nhà Cung cấp thành công !");
                return RedirectToAction("Index");
            }

            return View(nHACUNGCAP);
        }

        // GET: Admin/NhaCungCap/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHACUNGCAP nHACUNGCAP = db.NHACUNGCAP.Find(id);
            if (nHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(nHACUNGCAP);
        }

        // POST: Admin/NhaCungCap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNCC,TenNCC,SĐT,DiaChi")] NHACUNGCAP nHACUNGCAP, FormCollection collection)
        {
            /*string name = collection["TenNCC"].ToString();
            var rname = db.NHACUNGCAP.FirstOrDefault(x => x.TenNCC == name);
            if (rname != null)
            {
                TempData["message"] = new PushNoti("danger", "Nhà Cung Cấp '" + name + "' đã tồn tại!");
                return RedirectToAction("Edit");
            }
            string num = collection["SĐT"].ToString();
            var rnum = db.NHACUNGCAP.FirstOrDefault(x => x.SĐT == num);
            if (rnum != null)
            {
                TempData["message"] = new PushNoti("danger", "Liên hệ bị trùng '" + num + "' !");
                return RedirectToAction("Edit");
            }
            string addr = collection["DiaChi"].ToString();
            var raddr = db.NHACUNGCAP.FirstOrDefault(x => x.DiaChi == addr);
            if (raddr != null)
            {
                TempData["message"] = new PushNoti("danger", "Địa chỉ bị trùng '" + addr + "' !");
                return RedirectToAction("Edit");
            }*/
            if (ModelState.IsValid)
            {
                db.Entry(nHACUNGCAP).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = new PushNoti("info", "Cập nhật Danh mục thành công !");
                return RedirectToAction("Index");
            }
            return View(nHACUNGCAP);
        }

        // GET: Admin/NhaCungCap/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHACUNGCAP nHACUNGCAP = db.NHACUNGCAP.Find(id);
            if (nHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(nHACUNGCAP);
        }

        // POST: Admin/NhaCungCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHACUNGCAP nHACUNGCAP = db.NHACUNGCAP.Find(id);
            db.NHACUNGCAP.Remove(nHACUNGCAP);
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
