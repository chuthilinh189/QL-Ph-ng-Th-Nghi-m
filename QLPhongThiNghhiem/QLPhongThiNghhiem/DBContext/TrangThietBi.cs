namespace QLPhongThiNghhiem.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrangThietBi")]
    public partial class TrangThietBi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrangThietBi()
        {
            ChiTietSuDung = new HashSet<ChiTietSuDung>();
        }

        [Key]
        [StringLength(10)]
        public string MaTTB { get; set; }

        [StringLength(10)]
        public string MaLTTB { get; set; }

        [StringLength(10)]
        public string MaNSX { get; set; }

        [StringLength(10)]
        public string MaPhong { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTTB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        public int? GiaTien { get; set; }

        [Required]
        [StringLength(50)]
        public string TinhTrang { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuDung> ChiTietSuDung { get; set; }

        public virtual LoaiTTB LoaiTTB { get; set; }

        public virtual NhaSanXuat NhaSanXuat { get; set; }

        public virtual PhongThiNghiem PhongThiNghiem { get; set; }
    }
}
