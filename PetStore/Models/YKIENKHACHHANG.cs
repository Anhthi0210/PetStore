namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YKIENKHACHHANG")]
    public partial class YKIENKHACHHANG
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "Mã Ý Kiến")]
        public string MaYKKH { get; set; }
        [Display(Name = "Ngày đăng")]
        public DateTime NgayDang { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "SĐT")]
        public string SĐT { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
