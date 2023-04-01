namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIPET")]
    public partial class LOAIPET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIPET()
        {
            SANPHAM = new HashSet<SANPHAM>();
        }

        [Key]
        [StringLength(50)]
        [Required(ErrorMessage ="Cannot be blank!")]
        [Display(Name = "Mã Loài Pet")]
        public string MaLoaiPet { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\sàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹ]+$", ErrorMessage = "Ten Loai cannot use special characters!")]
        [Display(Name = "Tên Loài")]
        public string TenLoaiPet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAM { get; set; }
    }
}
