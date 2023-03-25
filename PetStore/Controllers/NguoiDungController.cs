using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetStore.Models;

namespace PetStore.Controllers
{
    public class NguoiDungController : Controller
    {
        private DataContext data = new DataContext();

        // GET: NguoiDung
        // GET: NguoiDung/Details/5
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, KHACHHANG kh)
        {
            var hoten = collection["TenKH"];
            var tendn = collection["TenDangNhap"];
            var matkhau = collection["MatKhau"];
            var nhaplaimatkhau = collection["NhaplaiMatkhau"];
            var email = collection["Email"];
            var dienthoai = collection["SĐT"];
            var diachi = collection["DiaChi"];

            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["NgaySinh"]);
            KHACHHANG tempt = data.KHACHHANGs.SingleOrDefault(n => n.TenDangNhap == tendn.Trim());

            if (tempt != null)
            {
                ViewData["Loi2"] = "Username đã tồn tại";
            }
            if (matkhau != nhaplaimatkhau)
            {
                ViewData["Loi1"] = "Nhập lại mật khẩu không đúng";
            }
            else
            {
                //so sánh ngày hiện tại và ngày sinh
                if (DateTime.Compare(DateTime.Now, DateTime.Parse(collection["NgaySinh"])) == -1)
                {
                    ViewData["Loi3"] = "Ngày sinh không được lớn hơn hiện tại";

                }
                kh.TenKH = hoten;
                kh.TenDangNhap = tendn;
                kh.MatKhau = matkhau;               
                kh.Email = email;
                kh.SĐT = dienthoai;
                kh.DiaChi = diachi;
                kh.NgaySinh = DateTime.Parse(ngaysinh);

                data.KHACHHANGs.AddOrUpdate(kh);
                data.SaveChanges();
                return RedirectToAction("Dangnhap", "Nguoidung");
            }
            return this.Dangky();
        }
    }
}
