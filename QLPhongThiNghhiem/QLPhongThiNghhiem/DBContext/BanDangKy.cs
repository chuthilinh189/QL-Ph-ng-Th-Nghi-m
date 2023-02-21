namespace QLPhongThiNghhiem.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BanDangKy")]
    public partial class BanDangKy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BanDangKy()
        {
            ChiTietDangKi = new HashSet<ChiTietDangKi>();
        }

        [Key]
        [StringLength(10)]
        public string MaDangKy { get; set; }

        [Required]
        [StringLength(10)]
        public string MaGV { get; set; }

        [StringLength(50)]
        public string Lop { get; set; }

        public int QuanSo { get; set; }

        public int HocKy { get; set; }

        [Required]
        [StringLength(50)]
        public string NamHoc { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDangKi> ChiTietDangKi { get; set; }
    }
}
