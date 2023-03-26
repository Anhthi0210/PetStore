using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PetStore.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<BAIDANG> BAIDANG { get; set; }
        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANG { get; set; }
        public virtual DbSet<DANHMUC> DANHMUC { get; set; }
        public virtual DbSet<DONHANG> DONHANG { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<LOAIPET> LOAIPET { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAP { get; set; }
        public virtual DbSet<PHANQUYEN> PHANQUYEN { get; set; }
        public virtual DbSet<PHUONGTHUCGIAOHANG> PHUONGTHUCGIAOHANG { get; set; }
        public virtual DbSet<PHUONGTHUCTHANHTOAN> PHUONGTHUCTHANHTOAN { get; set; }
        public virtual DbSet<SANPHAM> SANPHAM { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOAN { get; set; }
        public virtual DbSet<TRANGTHAI> TRANGTHAI { get; set; }
        public virtual DbSet<VOUCHER> VOUCHER { get; set; }
        public virtual DbSet<YKIENKHACHHANG> YKIENKHACHHANG { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BAIDANG>()
                .Property(e => e.MaBD)
                .IsUnicode(false);

            modelBuilder.Entity<BAIDANG>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.MaDH)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DANHMUC>()
                .Property(e => e.MaDM)
                .IsUnicode(false);

            modelBuilder.Entity<DANHMUC>()
                .HasMany(e => e.SANPHAM)
                .WithRequired(e => e.DANHMUC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MaDH)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.SĐT)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MaPTTT)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MaPTGH)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MaTT)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .HasMany(e => e.CHITIETDONHANG)
                .WithRequired(e => e.DONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SĐT)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPET>()
                .Property(e => e.MaLoaiPet)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPET>()
                .HasMany(e => e.SANPHAM)
                .WithRequired(e => e.LOAIPET)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SĐT)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.SANPHAM)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHANQUYEN>()
                .Property(e => e.MaPQ)
                .IsUnicode(false);

            modelBuilder.Entity<PHANQUYEN>()
                .HasMany(e => e.TAIKHOAN)
                .WithRequired(e => e.PHANQUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHUONGTHUCGIAOHANG>()
                .Property(e => e.MaPTGH)
                .IsUnicode(false);

            modelBuilder.Entity<PHUONGTHUCTHANHTOAN>()
                .Property(e => e.MaPTTT)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MaLoaiPet)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MaDM)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETDONHANG)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MaPQ)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.BAIDANG)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.YKIENKHACHHANG)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRANGTHAI>()
                .Property(e => e.MaTT)
                .IsUnicode(false);

            modelBuilder.Entity<VOUCHER>()
                .Property(e => e.MaGiam)
                .IsUnicode(false);

            modelBuilder.Entity<YKIENKHACHHANG>()
                .Property(e => e.MaYKKH)
                .IsUnicode(false);

            modelBuilder.Entity<YKIENKHACHHANG>()
                .Property(e => e.SĐT)
                .IsUnicode(false);

            modelBuilder.Entity<YKIENKHACHHANG>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);
        }
    }
}
