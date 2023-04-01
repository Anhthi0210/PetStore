namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            BAIDANG = new HashSet<BAIDANG>();
            YKIENKHACHHANG = new HashSet<YKIENKHACHHANG>();
        }

        [Key]
        [StringLength(50)]
        [Required(ErrorMessage ="Cannot be blank!")]
        [Display(Name = "Tên Đăng nhập")]
        [RegularExpression(@"^[a-z0-9]{5,12}$", ErrorMessage = "Tên đăng nhập gồm chữ thường và số, tối thiểu 5 và tối đa 12")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[!@#$%^&*+=])(?=.{8,})\\S+$", ErrorMessage = "Mật khẩu phải có ít nhất 8 kí tự và gồm ít nhất 1 kí tự đặc biệt và 1 chữ in")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Chọn Loại Tài khoản!")]
        [StringLength(50)]
        public string MaPQ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAIDANG> BAIDANG { get; set; }

        public virtual PHANQUYEN PHANQUYEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YKIENKHACHHANG> YKIENKHACHHANG { get; set; }
    }
}
