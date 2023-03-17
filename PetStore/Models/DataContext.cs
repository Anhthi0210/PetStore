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

        public virtual DbSet<BAIDANG> BAIDANGs { get; set; }
        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual DbSet<DANHMUC> DANHMUCs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIPET> LOAIPETs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<PHANQUYEN> PHANQUYENs { get; set; }
        public virtual DbSet<PHUONGTHUCGIAOHANG> PHUONGTHUCGIAOHANGs { get; set; }
        public virtual DbSet<PHUONGTHUCTHANHTOAN> PHUONGTHUCTHANHTOANs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<TRANGTHAI> TRANGTHAIs { get; set; }
        public virtual DbSet<VOUCHER> VOUCHERs { get; set; }
        public virtual DbSet<YKIENKHACHHANG> YKIENKHACHHANGs { get; set; }

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
                .HasMany(e => e.SANPHAMs)
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
                .Property(e => e.MaKH)
                .IsUnicode(false);

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
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.DONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SĐT)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DONHANGs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAIPET>()
                .Property(e => e.MaLoaiPet)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPET>()
                .HasMany(e => e.SANPHAMs)
                .WithRequired(e => e.LOAIPET)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SĐT)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.SANPHAMs)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHANQUYEN>()
                .Property(e => e.MaPQ)
                .IsUnicode(false);

            modelBuilder.Entity<PHANQUYEN>()
                .HasMany(e => e.TAIKHOANs)
                .WithRequired(e => e.PHANQUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHUONGTHUCGIAOHANG>()
                .Property(e => e.MaPTGH)
                .IsUnicode(false);

            modelBuilder.Entity<PHUONGTHUCGIAOHANG>()
                .HasMany(e => e.DONHANGs)
                .WithRequired(e => e.PHUONGTHUCGIAOHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHUONGTHUCTHANHTOAN>()
                .Property(e => e.MaPTTT)
                .IsUnicode(false);

            modelBuilder.Entity<PHUONGTHUCTHANHTOAN>()
                .HasMany(e => e.DONHANGs)
                .WithRequired(e => e.PHUONGTHUCTHANHTOAN)
                .WillCascadeOnDelete(false);

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
                .HasMany(e => e.CHITIETDONHANGs)
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
                .HasMany(e => e.BAIDANGs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.KHACHHANGs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.YKIENKHACHHANGs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRANGTHAI>()
                .Property(e => e.MaTT)
                .IsUnicode(false);

            modelBuilder.Entity<TRANGTHAI>()
                .HasMany(e => e.DONHANGs)
                .WithRequired(e => e.TRANGTHAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VOUCHER>()
                .Property(e => e.MaGiam)
                .IsUnicode(false);

            modelBuilder.Entity<VOUCHER>()
                .Property(e => e.MaKH)
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
