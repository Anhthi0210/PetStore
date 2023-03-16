namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRANGTHAI")]
    public partial class TRANGTHAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRANGTHAI()
        {
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        [StringLength(50)]
        public string MaTT { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
