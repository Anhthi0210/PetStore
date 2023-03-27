using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetStore.Models;

namespace PetStore.Controllers
{
    public class LoginAdminController : Controller
    {
        private DataContext db = new DataContext();

        // GET: LoginAdmin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                TAIKHOAN ad = db.TAIKHOAN.SingleOrDefault(n => n.TenDangNhap.Trim() == tendn.Trim() && n.MatKhau.Trim() == matkhau.Trim());
                if (ad != null)
                {
                    ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["TaikhoanAD"] = ad;
                    Session["UserName"] = ad.TenDangNhap;


                    return RedirectToAction("Index", "Dashbroad");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
    }
}
