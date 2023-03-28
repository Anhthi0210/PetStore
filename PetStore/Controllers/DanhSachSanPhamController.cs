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
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            //var all_Sach = (from s in data.Saches select s).OrderBy(m => m.masach);
            int pageSize = 16;
            int pageNum = page ?? 1;

            //return View(all_Sach.ToPagedList(pageNum, pageSize));
            var sANPHAMs = db.SANPHAM.Include(s => s.DANHMUC).Include(s => s.LOAIPET).Include(s => s.NHACUNGCAP);
            return View(sANPHAMs.ToList().ToPagedList(pageNum, pageSize));
        }

        // GET: DanhSachSanPham/Details/5
        public ActionResult Detail(string id)
        {
            var D_sach = db.SANPHAM.Where(m => m.MaSP == id).First();
            return View(D_sach);
        }
        public ActionResult Search(string keyword)
        {

            var all = db.SANPHAM.Where(x => x.TenSP.Contains(keyword));

            return View(all);
        }
        public ActionResult Hatkho(string id)
        {

            var all = db.SANPHAM.Where(x => x.MaDM == "MD01");

            return View(all);
        }
    }
}
