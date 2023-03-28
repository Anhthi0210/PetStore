namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHMUC")]
    public partial class DANHMUC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DANHMUC()
        {
            SANPHAM = new HashSet<SANPHAM>();
        }

        [Key]
        [Required(ErrorMessage = "Cannot be blank!")]
        [RegularExpression(@"^[A-Za-z 0-9]*$", ErrorMessage = "Cannot use special characters in Category Name.")]
        [StringLength(50)]
        [Display(Name = "Mã Danh mục")]
        public string MaDM { get; set; }

        [Required(ErrorMessage = "Category Name cannot be blank!")]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-z 0-9]*$", ErrorMessage ="Cannot use special characters in Category Name.")]
        [MinLength(10,ErrorMessage ="Category Name should contain at least 10 characters.")]
        [Display(Name = "Tên Danh mục")]
        public string TenDM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAM { get; set; }
    }
}
