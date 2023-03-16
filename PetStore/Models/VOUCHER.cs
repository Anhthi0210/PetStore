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
        public string MaGiam { get; set; }

        [Required]
        [StringLength(50)]
        public string TenMaGiam { get; set; }

        [Required]
        [StringLength(50)]
        public string MaKH { get; set; }

        public int SoLuong { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }
    }
}
