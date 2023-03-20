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

namespace PetStore.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        DANHMUC_DAL dANHMUC_DAL= new DANHMUC_DAL();

        // GET: Admin/DanhMuc
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
            return View();
        }

        // POST: Admin/DanhMuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDM,TenDM")] DANHMUC dANHMUC)
        {
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
        public ActionResult Edit([Bind(Include = "MaDM,TenDM")] DANHMUC dANHMUC)
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
