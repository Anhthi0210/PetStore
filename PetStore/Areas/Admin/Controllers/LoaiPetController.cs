using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetStore.DAL;
using PetStore.Models;

namespace PetStore.Areas.Admin.Controllers
{
    public class LoaiPetController : Controller
    {
        LOAIPET_DAL lOAIPET_DAL=new LOAIPET_DAL();
        DataContext dt= new DataContext();
        public void getNewId()
        {
            // Kết nối tới cơ sở dữ liệu
            // Truy vấn lấy id của sản phẩm cuối cùng có dạng SP0x
            var reader = dt.LOAIPET
                        .Where(d => d.MaLoaiPet.StartsWith("PET"))
                        .OrderByDescending(d => d.MaLoaiPet)
                        .Select(d => d.MaLoaiPet)
                        .FirstOrDefault(); ;
            int lastId = 0;
            lastId = int.Parse(reader.Substring(3));
            lastId += 1;
            string id = "PET0" + lastId.ToString();
            ViewBag.lastId = id.ToString();
        }
        // GET: Admin/LoaiPet
        public ActionResult Index()
        {
            return View(lOAIPET_DAL.getList());
        }

        // GET: Admin/LoaiPet/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIPET lOAIPET= lOAIPET_DAL.getRow(id);
            if (lOAIPET == null)
            {
                return HttpNotFound();
            }
            return View(lOAIPET);
        }

        // GET: Admin/LoaiPet/Create
        public ActionResult Create()
        {
            getNewId();
            return View();
        }

        // POST: Admin/LoaiPet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiPet,TenLoaiPet")] LOAIPET lOAIPET,FormCollection collection)
        {
            string name = collection["TenLoaiPet"].ToString();
            var reader = dt.LOAIPET.FirstOrDefault(x => x.TenLoaiPet == name);
            if (reader != null)
            {
                TempData["message"] = new PushNoti("danger", "Loài '" + name + "' đã tồn tại!");
                return RedirectToAction("Create");
            }
            if (ModelState.IsValid)
            {
                lOAIPET_DAL.Insert(lOAIPET);
                TempData["message"] = new PushNoti("success", "Thêm Loài Pet thành công !");
                return RedirectToAction("Index");
            }

            return View(lOAIPET);
        }

        // GET: Admin/LoaiPet/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIPET lOAIPET = lOAIPET_DAL.getRow(id);
            if (lOAIPET == null)
            {
                return HttpNotFound();
            }
            return View(lOAIPET);
        }

        // POST: Admin/LoaiPet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiPet,TenLoaiPet")] LOAIPET lOAIPET,FormCollection collection)
        {
            string name = collection["TenLoaiPet"].ToString();
            var reader = dt.LOAIPET.FirstOrDefault(x => x.TenLoaiPet == name);
            if (reader != null)
            {
                TempData["message"] = new PushNoti("danger", "Loài '" + name + "' đã tồn tại!");
                return RedirectToAction("Edit");
            }
            if (ModelState.IsValid)
            {
                lOAIPET_DAL.Edit(lOAIPET);
                TempData["Message"] = new PushNoti("info", "Cập nhật Loài Pet thành công!");
                return RedirectToAction("Index");
            }
            return View(lOAIPET);
        }

        // GET: Admin/LoaiPet/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIPET lOAIPET = lOAIPET_DAL.getRow(id);
            if (lOAIPET == null)
            {
                return HttpNotFound();
            }
            return View(lOAIPET);
        }

        // POST: Admin/LoaiPet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAIPET lOAIPET = lOAIPET_DAL.getRow(id);
            lOAIPET_DAL.Delete(lOAIPET);
            TempData["Message"] = new PushNoti("danger", "Xóa loài thú cưng Thành công!");
            return RedirectToAction("Index");
        }


        }
    }

