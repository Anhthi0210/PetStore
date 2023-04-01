namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.InteropServices;

    [Table("YKIENKHACHHANG")]
    public partial class YKIENKHACHHANG
    {
        [Key]
        [StringLength(50)]
        public string MaYKKH { get; set; }

        public DateTime NgayDang { get; set; }

        [Required]
        [StringLength(50)]
        public string SĐT { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
