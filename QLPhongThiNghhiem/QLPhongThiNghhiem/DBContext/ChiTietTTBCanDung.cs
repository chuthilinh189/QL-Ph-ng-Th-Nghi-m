namespace QLPhongThiNghhiem.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietTTBCanDung")]
    public partial class ChiTietTTBCanDung
    {
        [Key]
        [StringLength(10)]
        public string MaChiTiet { get; set; }

        [Required]
        [StringLength(10)]
        public string MaBTN { get; set; }

        [Required]
        [StringLength(10)]
        public string MaLTTB { get; set; }

        public int SoLuong { get; set; }

        public virtual BaiThiNghiem BaiThiNghiem { get; set; }

        public virtual LoaiTTB LoaiTTB { get; set; }
    }
}
