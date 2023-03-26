using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class GioHangController : Controller
    {
        DataContext data = new DataContext();


        // lay thong tin gio hang
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<Giohang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }
        public ActionResult ThemGioHang(string id, string strURL)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.Find(n => n.MaSP == id);
            if (sanpham == null)
            {
                sanpham = new Giohang(id);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<Giohang> lstGiohang = Session["GioHang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                tsl = lstGiohang.Sum(n => n.iSoluong);
            }
            return tsl;
        }
        private int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<Giohang> lstGiohang = Session["GioHang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                tsl = lstGiohang.Count;
            }
            return tsl;
        }
        private double TongTien()
        {
            double tt = 0;
            List<Giohang> lstGiohang = Session["GioHang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                tt = lstGiohang.Sum(n => n.dThanhtien);
            }
            return tt;
        }
        public ActionResult GioHang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(lstGiohang);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return PartialView();
        }
        public ActionResult XoaGioHang(string id)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.MaSP == id);
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.MaSP == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult CapnhatGiohang(string id, FormCollection collection)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.MaSP == id);
            if (sanpham != null)
            {
                sanpham.iSoluong = int.Parse(collection["txtSolg"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            lstGiohang.Clear();
            return RedirectToAction("GioHang");
        }
        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "DanhSachSanPham");
            }
            List<Giohang> lstGiohang = Laygiohang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(lstGiohang);

        }
        public ActionResult DatHang(FormCollection collection)
        {
            DONHANG dh = new DONHANG();
            KHACHHANG kh = (KHACHHANG)Session["TaiKhoan"];
            SANPHAM s = new SANPHAM();
            PHUONGTHUCTHANHTOAN pttt = new PHUONGTHUCTHANHTOAN();
            PHUONGTHUCGIAOHANG ptgh = new PHUONGTHUCGIAOHANG();
            TRANGTHAI tt = new TRANGTHAI();

            List<Giohang> gh = Laygiohang();
            var ngaygiao = String.Format("{0:dd/MM/yyyy}", collection["NgayGiao"]);

            dh.MaKH = kh.MaKH;
            dh.NgayDatHang = DateTime.Now;
            dh.NgayGiaoHang = DateTime.Parse(ngaygiao);
            dh.DiaChiNhan = kh.DiaChi;
            dh.MaPTTT = pttt.MaPTTT;
            dh.MaPTGH = ptgh.MaPTGH;
            dh.MaTT = tt.MaTT;
            //dh.Note = false;
            //dh.thanhtoan = false;

            data.DONHANG.Add(dh);
            data.SaveChanges();
            foreach (var item in gh)
            {
                CHITIETDONHANG ctdh = new CHITIETDONHANG();
                ctdh.MaDH = dh.MaDH;
                ctdh.MaSP = item.MaSP;
                ctdh.SoLuongDat = item.iSoluong;
                ctdh.DonGia = (decimal)item.DonGia;
                s = data.SANPHAM.Single(n => n.MaSP == item.MaSP);
                s.SoLuong -= ctdh.SoLuongDat;
                data.SaveChanges();

                data.CHITIETDONHANG.Add(ctdh);
            }
            data.SaveChanges();
            Session["Giohang"] = null;
            return RedirectToAction("XacnhanDonhang", "GioHang");
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XacnhanDonhang()
        {
            return View();
        }
    }
}