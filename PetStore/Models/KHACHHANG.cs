namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONHANG = new HashSet<DONHANG>();
        }

        [Key]
        [Display(Name = "Mã Khách hàng")]
        public int MaKH { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Họ Tên")]
        public string TenKH { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Giới tính")]
        public string GioTinh { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "SĐT")]
        public string SĐT { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Điểm Tích Lũy")]
        public int? DiemTichLuy { get; set; }
        [Required]

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANG { get; set; }
    }
}
