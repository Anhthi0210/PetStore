namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        [StringLength(50)]
        public string MaSP { get; set; }

        [Required]
        [StringLength(255)]
        public string TenSP { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGia { get; set; }

        [Required]
        public string MoTa { get; set; }

        public int SoLuong { get; set; }

        [Required]
        [StringLength(50)]
        public string Hinh { get; set; }

        [Required]
        [StringLength(50)]
        public string MaLoaiPet { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNCC { get; set; }

        [Required]
        [StringLength(50)]
        public string MaDM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual DANHMUC DANHMUC { get; set; }

        public virtual LOAIPET LOAIPET { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
