namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAIDANG")]
    public partial class BAIDANG
    {
        [Key]
        [StringLength(50)]
        public string MaBD { get; set; }

        [Required]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Required]
        [Display(Name = "Ngày đăng")]
        public DateTime NgayDang { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ảnh bài đăng")]
        public string Hinh { get; set; }

        [Required]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên tài khoản đăng")]
        public string TenDangNhap { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
