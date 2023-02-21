namespace QLPhongThiNghhiem.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSuDung")]
    public partial class ChiTietSuDung
    {
        [Key]
        [StringLength(10)]
        public string MaChiTietSD { get; set; }

        [Required]
        [StringLength(10)]
        public string MaCTDK { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTTB { get; set; }

        [StringLength(10)]
        public string GhiChu { get; set; }

        public virtual ChiTietDangKi ChiTietDangKi { get; set; }

        public virtual TrangThietBi TrangThietBi { get; set; }
    }
}
