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
        public string TieuDe { get; set; }

        public DateTime NgayDang { get; set; }

        [Required]
        [StringLength(50)]
        public string Hinh { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
