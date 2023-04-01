namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.InteropServices;

    [Table("BAIDANG")]
    public partial class BAIDANG
    {
        [Key]
        [StringLength(50)]
        [Required(ErrorMessage ="Cannot be blank!")]
        [Display(Name = "Mã Bài viết")]
        public string MaBD { get; set; }

        [Required(ErrorMessage = "Cannot be blank!")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\sàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹ]+$", ErrorMessage ="Tieu de cannot use special characters!")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [Display(Name = "Ngày đăng")]
        [Required(ErrorMessage = "Cannot be blank!")]
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy}")]
        public DateTime NgayDang { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ảnh")]
        public string Hinh { get; set; }

        [Required]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên người đăng")]
        public string TenDangNhap { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
