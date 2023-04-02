namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.InteropServices;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONHANG = new HashSet<DONHANG>();
        }

        [Key]
        [Required]
        [Display(Name = "Mã Khách hàng")]
        public int MaKH { get; set; }

        [Required(ErrorMessage ="Cannot be blank!")]
        [RegularExpression(@"^([a-vxyỳọáầảấờễàạằệếýộậốũứĩõúữịỗìềểẩớặòùồợãụủíỹắẫựỉỏừỷởóéửỵẳẹèẽổẵẻỡơôưăêâđ]+)
            ((\s{1}[a-vxyỳọáầảấờễàạằệếýộậốũứĩõúữịỗìềểẩớặòùồợãụủíỹắẫựỉỏừỷởóéửỵẳẹèẽổẵẻỡơôưăêâđ]+){1,})$", ErrorMessage = "cannot use special characters!")]
        [StringLength(50)]
        [Display(Name = "Tên Khách hàng")]
        public string TenKH { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Giới tính")]
        public string GioTinh { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Liên hệ")]
        [StringLength(50)]
        [RegularExpression(@"^(0(32|33|34|35|36|37|38|39|52|56|58|59|70|76|77|78|79|81|82|83|84|85|86|87|88|89|91|93|94|96|97|98|99))+([0-9]{7})\b", ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string SĐT { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Email")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9]+@gmail\.com$", ErrorMessage = "Địa chỉ email không hợp lệ!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Điểm tích lũy")]
        public int? DiemTichLuy { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Tên đăng nhập")]
        [StringLength(50)]
        [RegularExpression(@"^[a-z0-9]{5,12}$", ErrorMessage = "Tên đăng nhập gồm chữ thường và số, tối thiểu 5 và tối đa 12")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Mật khẩu")]
        [StringLength(50)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[!@#$%^&*+=])(?=.{8,})\\S+$", ErrorMessage = "Mật khẩu phải có ít nhất 8 kí tự và gồm ít nhất 1 kí tự đặc biệt và 1 chữ in")]
        public string MatKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANG { get; set; }
    }
}
