using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PetStore.Models
{
    public class Giohang
    {
        DataContext data = new DataContext();
        public string MaSP { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string TenSP { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string Hinh { get; set; }
        [Display(Name = "Giá bán")]
        public Double DonGia { get; set; }
        [Display(Name = "Số lượng")]
        public int iSoluong { get; set; }
        [Display(Name = "Giảm giá")]
        public int DiemTichLuy { get; set; }
        [Display(Name = "Thành tiền")]
        public Double dThanhtien
        {
            get { return iSoluong * DonGia * (DiemTichLuy /100); }
        }
        public Giohang(string id)
        {
            MaSP = id;
            SANPHAM sach = data.SANPHAM.Single(n => (n.MaSP == MaSP));
            TenSP = sach.TenSP;
            Hinh = sach.Hinh;
            DonGia = double.Parse(sach.DonGia.ToString());
            iSoluong = 1;
        }
    }
}