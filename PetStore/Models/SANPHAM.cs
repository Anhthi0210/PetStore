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
            CHITIETDONHANG = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        [StringLength(50)]
        [Required(ErrorMessage ="Cannot be blank!")]
        [Display(Name = "Mã Sản phẩm")]
        public string MaSP { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Tên Sản phẩm")]
        [RegularExpression(@"^[a-zA-Z0-9\sàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹ]+$", ErrorMessage = "Danh muc cannot use special characters!")]
        [StringLength(255)]
        public string TenSP { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Đơn giá")]
        [Column(TypeName = "money")]
        [RegularExpression(@"^(1[0-9]|[2-9][0-9]|[1-4][0-9]{2}|5000)$", ErrorMessage = "Đơn giá chỉ từ 10,000 > 5,000,000")]
        public decimal DonGia { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Số lượng")]
        [RegularExpression(@"^(1|[1-9][0-9]?|1[0-9]{1,1}|200)$", ErrorMessage = "Số lượng từ 1 -> 200 sản phẩm!")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [StringLength(50)]
        public string MaLoaiPet { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Mã Sản phẩm")]
        [StringLength(50)]
        public string MaNCC { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Mã Sản phẩm")]
        [StringLength(50)]
        public string MaDM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANG { get; set; }

        public virtual DANHMUC DANHMUC { get; set; }

        public virtual LOAIPET LOAIPET { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
