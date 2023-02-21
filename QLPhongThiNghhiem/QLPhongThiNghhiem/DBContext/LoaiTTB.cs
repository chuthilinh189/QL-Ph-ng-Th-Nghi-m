namespace QLPhongThiNghhiem.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiTTB")]
    public partial class LoaiTTB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiTTB()
        {
            ChiTietTTBCanDung = new HashSet<ChiTietTTBCanDung>();
            TrangThietBi = new HashSet<TrangThietBi>();
        }

        [Key]
        [StringLength(10)]
        public string MaLTTB { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLoai { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTTBCanDung> ChiTietTTBCanDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrangThietBi> TrangThietBi { get; set; }
    }
}
