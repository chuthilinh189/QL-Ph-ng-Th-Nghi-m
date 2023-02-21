namespace QLPhongThiNghhiem.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            ChiTietDangKi = new HashSet<ChiTietDangKi>();
        }

        [Key]
        [StringLength(10)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(20)]
        public string ChucVu { get; set; }

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

        [StringLength(200)]
        public string DiaChi { get; set; }

        [Column(TypeName = "ntext")]
        public string GioiThieu { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDangKi> ChiTietDangKi { get; set; }

        public virtual TaiKhoanNV TaiKhoanNV { get; set; }
    }
}
