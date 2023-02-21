using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Models
{
     class NVTrangThietBiMod
     {
          static DBContext.DBPTNContext context = new DBContext.DBPTNContext();

          public string MaTTB { get; set; }
          public string TenTTB { get; set; }
          public string TenPhong { get; set; }
          public string TenLoai { get; set; }
          public string TenNSX { get; set; }
          public DateTime NgayNhap { get; set; }
          public int GiaTien { get; set; }
          public string TinhTrang { get; set; }
          public string GhiChu { get; set; }
          public bool XuatKho { get; set; }

          public NVTrangThietBiMod() { }

          public NVTrangThietBiMod(string _MaTTB)
          {
               MaTTB = _MaTTB;
          }

          public NVTrangThietBiMod(string _TenLoai, string _TenPhong)
          {
               TenLoai = _TenLoai;
               TenPhong = _TenPhong;
          }

          public NVTrangThietBiMod(string _MaTTB, string _TenTTB, string _TenPhong, string _TenLoai, string _TenNSX, DateTime _NgayNhap, int _GiaTien, string _TinhTrang, string _GhiChu, bool _XuatKho)
          {
               MaTTB = _MaTTB;
               TenTTB = _TenTTB;
               TenPhong = _TenPhong;
               TenNSX = _TenNSX;
               TenLoai = _TenLoai;
               NgayNhap = _NgayNhap;
               GiaTien = _GiaTien;
               TinhTrang = _TinhTrang;
               GhiChu = _GhiChu;
               XuatKho = _XuatKho;
          }

          public List<NVTrangThietBiMod> getTrangThietBiByLtttPtn()
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@TenLoai", TenLoai));
                    paralist.Add(new SqlParameter("@TenPhong", TenPhong));
                    return (context.Database.SqlQuery<NVTrangThietBiMod>("spGetTrangThietBiByLttbPtn @TenLoai, @TenPhong", paralist.ToArray()).ToList<NVTrangThietBiMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVTrangThietBiMod>();
               }
          }

          public int InsertTrangThietBi()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaTTB", MaTTB));
               paralist.Add(new SqlParameter("@TenLoai", TenLoai));
               paralist.Add(new SqlParameter("@TenNSX", TenNSX));
               paralist.Add(new SqlParameter("@TenPhong", TenPhong));
               paralist.Add(new SqlParameter("@TenTTB", TenTTB));
               paralist.Add(new SqlParameter("@NgayNhap", NgayNhap));
               paralist.Add(new SqlParameter("@GiaTien", GiaTien));
               paralist.Add(new SqlParameter("@TinhTrang", TinhTrang));
               paralist.Add(new SqlParameter("@GhiChu", GhiChu));
               paralist.Add(new SqlParameter("@XuatKho", XuatKho));
               return context.Database.ExecuteSqlCommand("spInsertTrangThietBi @MaTTB, @TenLoai, @TenNSX, @TenPhong, @TenTTB, @NgayNhap, @GiaTien, @TinhTrang, @GhiChu, @XuatKho", paralist.ToArray());
          }

          public int UpdateTrangThietBi()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaTTB", MaTTB));
               paralist.Add(new SqlParameter("@TenLoai", TenLoai));
               paralist.Add(new SqlParameter("@TenNSX", TenNSX));
               paralist.Add(new SqlParameter("@TenPhong", TenPhong));
               paralist.Add(new SqlParameter("@TenTTB", TenTTB));
               paralist.Add(new SqlParameter("@NgayNhap", NgayNhap));
               paralist.Add(new SqlParameter("@GiaTien", GiaTien));
               paralist.Add(new SqlParameter("@TinhTrang", TinhTrang));
               paralist.Add(new SqlParameter("@GhiChu", GhiChu));
               paralist.Add(new SqlParameter("@XuatKho", XuatKho));
               return context.Database.ExecuteSqlCommand("spUpdateTrangThietBi @MaTTB, @TenLoai, @TenNSX, @TenPhong, @TenTTB, @NgayNhap, @GiaTien, @TinhTrang, @GhiChu, @XuatKho", paralist.ToArray());
          }

          public int DeleteTrangThietBi()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaTTB", MaTTB));
               return context.Database.ExecuteSqlCommand("spDeleteTrangThietBi @MaTTB", paralist.ToArray());
          }

          public List<NVTrangThietBiMod> getTrangThietBiByKey(string Key)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@TenLoai", TenLoai));
                    paralist.Add(new SqlParameter("@TenPhong", TenPhong));
                    paralist.Add(new SqlParameter("@Key", Key));
                    return (context.Database.SqlQuery<NVTrangThietBiMod>("spGetTrangThietBiByKey @TenLoai, @TenPhong, @Key", paralist.ToArray()).ToList<NVTrangThietBiMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVTrangThietBiMod>();
               }
          }
     }
}
