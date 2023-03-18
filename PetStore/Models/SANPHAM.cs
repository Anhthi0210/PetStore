namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.InteropServices;

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
        [Display(Name = "Mã Sản phẩm")]
        public string MaSP { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Tên")]
        public string TenSP { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Đơn giá")]
        public decimal DonGia { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Required]
        [Display(Name = "Số lượng tồn")]
        public int SoLuong { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ảnh")]
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
