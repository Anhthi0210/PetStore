namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VOUCHER")]
    public partial class VOUCHER
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "Mã Voucher")]
        public string MaGiam { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên Voucher")]
        public string TenMaGiam { get; set; }

        [Required]
        [StringLength(50)]
        public string MaKH { get; set; }

        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Display(Name = "Ngày Bắt đầu")]
        public DateTime NgayBatDau { get; set; }

        [Display(Name = "Ngày Kết thúc")]
        public DateTime NgayKetThuc { get; set; }
    }
}
