namespace QLPhongThiNghhiem.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaoVien")]
    public partial class GiaoVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiaoVien()
        {
            BanDangKy = new HashSet<BanDangKy>();
        }

        [Key]
        [StringLength(10)]
        public string MaGV { get; set; }

        [StringLength(10)]
        public string MaTK { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [Column(TypeName = "ntext")]
        public string GioiThieu { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanDangKy> BanDangKy { get; set; }

        public virtual TaiKhoanGV TaiKhoanGV { get; set; }
    }
}
