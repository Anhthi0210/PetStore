namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.InteropServices;

    [Table("NHACUNGCAP")]
    public partial class NHACUNGCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACUNGCAP()
        {
            SANPHAM = new HashSet<SANPHAM>();
        }

        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Cannot be blank!")]
        public string MaNCC { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\sàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹ]+$", ErrorMessage = "Danh muc cannot use special characters!")]
        [Display(Name = "Tên Nhà Cung Cấp")]
        public string TenNCC { get; set; }

        [Required(ErrorMessage ="Cannot be blank!")]
        [StringLength(50)]
        [Display(Name = "Liên hệ")]
        [RegularExpression(@"^(0(32|33|34|35|36|37|38|39|52|56|58|59|70|76|77|78|79|81|82|83|84|85|86|87|88|89|91|94|96|97|98|99))+([0-9]{7})\b", ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string SĐT { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAM { get; set; }
    }
}
