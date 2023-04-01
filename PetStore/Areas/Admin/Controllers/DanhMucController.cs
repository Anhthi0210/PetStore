using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetStore.Models;
using PetStore.DAL;
using System.Data.SqlClient;

namespace PetStore.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        DANHMUC_DAL dANHMUC_DAL = new DANHMUC_DAL();
        DataContext dt = new DataContext();
        // GET: Admin/DanhMuc
        public void getNewId()
        {
            // Kết nối tới cơ sở dữ liệu
            // Truy vấn lấy id của sản phẩm cuối cùng có dạng SP0x
            var reader = dt.DANHMUC
                        .Where(d => d.MaDM.StartsWith("DM"))
                        .OrderByDescending(d => d.MaDM)
                        .Select(d => d.MaDM)
                        .FirstOrDefault(); ;
            int lastId = 0;
            lastId = int.Parse(reader.Substring(2));
            lastId += 1;
            string id = "DM" + lastId.ToString();
            ViewBag.lastId = id.ToString();
        }
        public ActionResult Index()
        {
            return View(dANHMUC_DAL.getList());
        }

        // GET: Admin/DanhMuc/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUC dANHMUC = dANHMUC_DAL.getRow(id);
            if (dANHMUC == null)
            {
                return HttpNotFound();
            }
            return View(dANHMUC);
        }

        // GET: Admin/DanhMuc/Create
        public ActionResult Create()
        {
            getNewId();
            return View();
        }

        // POST: Admin/DanhMuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDM,TenDM")] DANHMUC dANHMUC,FormCollection collection)
        {
            string name = collection["TenDM"].ToString();
            var reader = dt.DANHMUC.FirstOrDefault(x => x.TenDM == name);
            if (reader != null)
            {
                TempData["message"] = new PushNoti("danger", "Danh mục '"+name+ "' đã tồn tại!");
                return RedirectToAction("Create");
            }
            if (ModelState.IsValid)
            {
                dANHMUC_DAL.Insert(dANHMUC);
                TempData["message"] = new PushNoti("success", "Thêm Danh mục thành công !");
                return RedirectToAction("Index");
            }

            return View(dANHMUC);
        }

        // GET: Admin/DanhMuc/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUC dANHMUC = dANHMUC_DAL.getRow(id);
            if (dANHMUC == null)
            {
                return HttpNotFound();
            }
            return View(dANHMUC);
        }

        // POST: Admin/DanhMuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDM,TenDM")] DANHMUC dANHMUC, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                dANHMUC_DAL.Edit(dANHMUC);
                TempData["Message"] = new PushNoti("info", "Cập nhật Danh mục thành công !");
                return RedirectToAction("Index");
            }
            return View(dANHMUC);
        }

        // GET: Admin/DanhMuc/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUC dANHMUC = dANHMUC_DAL.getRow(id);
            if (dANHMUC == null)
            {
                return HttpNotFound();
            }
            return View(dANHMUC);
        }

        // POST: Admin/DanhMuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DANHMUC dANHMUC = dANHMUC_DAL.getRow(id);
            dANHMUC_DAL.Delete(dANHMUC);
            TempData["message"] = new PushNoti("danger", "Xóa Danh mục thành công !");
            return RedirectToAction("Index");
        }


    }
}
