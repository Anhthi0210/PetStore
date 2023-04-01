namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.InteropServices;

    [Table("PHUONGTHUCGIAOHANG")]
    public partial class PHUONGTHUCGIAOHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHUONGTHUCGIAOHANG()
        {
            DONHANG = new HashSet<DONHANG>();
        }

        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Chọn Phương thức! ")]
        [Display(Name = "Mã Phương thức")]
        public string MaPTGH { get; set; }

        [Required(ErrorMessage ="Cannot be blank!")]
        [StringLength(50)]
        [Display(Name = "Phương thức Giao hàng")]
        [RegularExpression(@"^[a-zA-Z0-9\sàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹ]+$", ErrorMessage = "Ten Phuong thuc cannot use special characters!")]
        public string TenPTGH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANG { get; set; }
    }
}
