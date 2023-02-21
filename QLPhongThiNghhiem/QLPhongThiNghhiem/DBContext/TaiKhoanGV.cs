namespace QLPhongThiNghhiem.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoanGV")]
    public partial class TaiKhoanGV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoanGV()
        {
            GiaoVien = new HashSet<GiaoVien>();
        }

        [Key]
        [StringLength(10)]
        public string MaTK { get; set; }

        [Required]
        [StringLength(20)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(20)]
        public string MatKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaoVien> GiaoVien { get; set; }
    }
}
