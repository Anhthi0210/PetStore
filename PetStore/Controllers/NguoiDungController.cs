﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using PetStore.Models;

namespace PetStore.Controllers
{
    public class NguoiDungController : Controller
    {
        private DataContext data = new DataContext();

        
        [HttpGet]
        // GET: NguoiDung
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KHACHHANG kh)
        {
            var hoten = collection["TenKH"];
            var tendn = collection["TenDangNhap"];
            var matkhau = collection["MatKhau"];
            var nhaplaimatkhau = collection["NhaplaiMatkhau"];
            var email = collection["Email"];
            var dienthoai = collection["SĐT"];
            var diachi = collection["DiaChi"];

            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["NgaySinh"]);
            KHACHHANG tempt = data.KHACHHANG.SingleOrDefault(n => n.TenDangNhap.Trim() == tendn.Trim());
            Regex regexMail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match matchMail = regexMail.Match(email);
            Regex regexPhone = new Regex(@"^(84|0[3|5|7|8|9])+([0-9]{8})\b");
            Match matchPhone = regexPhone.Match(dienthoai);
            var checkEmail = data.KHACHHANG.FirstOrDefault(x => x.Email == email);
            if (checkEmail != null)
            {
                ViewData["Loiemail"] = "email đã tồn tại, vui long nha email khac";
                return this.DangKy();
            }
            if (tempt != null)
            {
                ViewData["Loi2"] = "Username đã tồn tại";
            }
            if (String.IsNullOrEmpty(nhaplaimatkhau))
            {
                ViewData["NhapMKXN"] = "phải nhập mật khẩu xác nhận";
            }
            //so sánh ngày hiện tại và ngày sinh
            if (dienthoai.LongCount() < 10 || dienthoai.LongCount() > 10)
            {
                ViewData["loi4"] = "Sdt phải có 10 số";
            }
            else if (dienthoai == kh.SĐT)
            {
                ViewData["loi5"] = "SDT đã có người sử dụng";
            }
            if (DateTime.Compare(DateTime.Now, DateTime.Parse(collection["Ngaysinh"])) == -1)
            {
                ViewData["Loi3"] = "Ngày sinh không được lớn hơn hiện tại";

            }
            else
            {
                if (!matkhau.Equals(nhaplaimatkhau))
                {
                    ViewData["MatKhauGiongNhau"] = "Mật khẩu và mật khẩu xác nhận phải giống nhau";

                }
                else
                {
                    kh.TenKH = hoten;
                    kh.TenDangNhap = tendn;
                    kh.MatKhau = matkhau;
                    kh.Email = email;
                    kh.SĐT = dienthoai;
                    kh.DiaChi = diachi;
                    kh.NgaySinh = DateTime.Parse(ngaysinh);

                    data.KHACHHANG.Add(kh);
                    data.SaveChanges();

                    return RedirectToAction("Index");

                }
            }
            return this.DangKy();
        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var email = collection["Email"];
            var mk = collection["MatKhau"];
            KHACHHANG kh = data.KHACHHANG.SingleOrDefault(n => n.Email.Trim() == email.Trim() && n.MatKhau.Trim() == mk.Trim());
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                Session["TaiKhoan"] = kh;
                Session["Tenkh"] = kh.TenKH;

            }
            else if (kh == null)
            {
                ViewData["ErrorAccount"] = "sai mật khẩu hoặc Tên đăng nhập không tồn tại vui lòng nhập lại";
                return this.Dangnhap();
            }
            else
            {
                ViewData["ErrorPass"] = "Mật khẩu không đúng";
                return this.Dangnhap();
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult Logout()
        {

            Session["TaiKhoan"] = null;
            Session["Taikhoandn"] = null;

            return RedirectToAction("Index", "DanhSachSanPham");
        }
    }
}
