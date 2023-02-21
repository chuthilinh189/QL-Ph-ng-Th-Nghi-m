namespace QLPhongThiNghhiem.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiThiNghiem")]
    public partial class BaiThiNghiem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiThiNghiem()
        {
            ChiTietDangKi = new HashSet<ChiTietDangKi>();
            ChiTietTTBCanDung = new HashSet<ChiTietTTBCanDung>();
        }

        [Key]
        [StringLength(10)]
        public string MaBTN { get; set; }

        [Required]
        [StringLength(50)]
        public string TenBTN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDangKi> ChiTietDangKi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTTBCanDung> ChiTietTTBCanDung { get; set; }
    }
}
