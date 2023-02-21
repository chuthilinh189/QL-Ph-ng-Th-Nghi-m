namespace QLPhongThiNghhiem.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongThiNghiem")]
    public partial class PhongThiNghiem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongThiNghiem()
        {
            ChiTietDangKi = new HashSet<ChiTietDangKi>();
            TrangThietBi = new HashSet<TrangThietBi>();
        }

        [Key]
        [StringLength(10)]
        public string MaPhong { get; set; }

        [Required]
        [StringLength(50)]
        public string TenPhong { get; set; }

        [Required]
        [StringLength(50)]
        public string ViTri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDangKi> ChiTietDangKi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrangThietBi> TrangThietBi { get; set; }
    }
}
