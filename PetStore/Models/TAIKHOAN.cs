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
        [Display(Name = "Tài Khoản")]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(50)]
        public string MaPQ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAIDANG> BAIDANG { get; set; }

        public virtual PHANQUYEN PHANQUYEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YKIENKHACHHANG> YKIENKHACHHANG { get; set; }
    }
}
