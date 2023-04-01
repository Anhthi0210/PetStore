namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CHITIETDONHANG = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        [Required(ErrorMessage = "Cannot be blank!")]
        public int MaDH { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Người Nhận")]
        [RegularExpression(@"^[a-zA-Z0-9\sàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹ]+$", ErrorMessage = "Người nhận cannot use special characters!")]
        [StringLength(50)]
        public string TenNguoiNhan { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Nơi Nhận")]
        public string DiaChiNhan { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "SDT")]
        [RegularExpression(@"^(0(32|33|34|35|36|37|38|39|52|56|58|59|70|76|77|78|79|81|82|83|84|85|86|87|88|89|91|94|96|97|98|99))+([0-9]{7})\b", ErrorMessage = "Số điện thoại không hợp lệ.")]
        [StringLength(50)]
        public string SĐT { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Ngày Đặt")]
        public DateTime NgayDatHang { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Ngày Giao")]
        public DateTime NgayGiaoHang { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Note")]
        [StringLength(50)]
        public string Note { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Tổng tiền")]
        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }

        public int MaKH { get; set; }

        [StringLength(50)]
        public string MaPTTT { get; set; }

        [StringLength(50)]
        public string MaPTGH { get; set; }

        [StringLength(50)]
        public string MaTT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual PHUONGTHUCGIAOHANG PHUONGTHUCGIAOHANG { get; set; }

        public virtual PHUONGTHUCTHANHTOAN PHUONGTHUCTHANHTOAN { get; set; }

        public virtual TRANGTHAI TRANGTHAI { get; set; }
    }
}
