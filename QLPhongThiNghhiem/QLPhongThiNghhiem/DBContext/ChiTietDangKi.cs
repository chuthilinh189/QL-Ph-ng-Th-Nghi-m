namespace QLPhongThiNghhiem.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDangKi")]
    public partial class ChiTietDangKi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTietDangKi()
        {
            ChiTietSuDung = new HashSet<ChiTietSuDung>();
        }

        [Key]
        [StringLength(10)]
        public string MaCTDK { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(10)]
        public string MaPTN { get; set; }

        [Required]
        [StringLength(10)]
        public string MaDangKy { get; set; }

        [Required]
        [StringLength(10)]
        public string MaBTN { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySD { get; set; }

        [StringLength(1)]
        public string CaTrongNgay { get; set; }

        public int? SoNhom { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        public virtual BaiThiNghiem BaiThiNghiem { get; set; }

        public virtual BanDangKy BanDangKy { get; set; }

        public virtual PhongThiNghiem PhongThiNghiem { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuDung> ChiTietSuDung { get; set; }
    }
}
