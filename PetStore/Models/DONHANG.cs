namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        [StringLength(50)]
        public string MaDH { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNguoiNhan { get; set; }

        [Required]
        public string DiaChiNhan { get; set; }

        [Required]
        [StringLength(50)]
        public string SĐT { get; set; }

        public DateTime NgayDatHang { get; set; }

        public DateTime NgayGiaoHang { get; set; }

        [Required]
        [StringLength(50)]
        public string Note { get; set; }

        [Column(TypeName = "money")]
        public decimal TongTien { get; set; }

        [Required]
        [StringLength(50)]
        public string MaKH { get; set; }

        [Required]
        [StringLength(50)]
        public string MaPTTT { get; set; }

        [Required]
        [StringLength(50)]
        public string MaPTGH { get; set; }

        [Required]
        [StringLength(50)]
        public string MaTT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual PHUONGTHUCGIAOHANG PHUONGTHUCGIAOHANG { get; set; }

        public virtual PHUONGTHUCTHANHTOAN PHUONGTHUCTHANHTOAN { get; set; }

        public virtual TRANGTHAI TRANGTHAI { get; set; }
    }
}
