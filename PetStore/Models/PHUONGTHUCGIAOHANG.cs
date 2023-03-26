namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        public string MaPTGH { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "PTGH")]
        public string TenPTGH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANG { get; set; }
    }
}
