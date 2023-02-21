using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Models
{
     class NVChiTietDangKyMod
     {
          static DBContext.DBPTNContext context = new DBContext.DBPTNContext();

          public string MaCTDK { get; set; }
          public string MaDangKy { get; set; }
          public string HoTenGV { get; set; }
          public string HoTenNV { get; set; }
          public string TenPhong { get; set; }
          public string TenBTN { get; set; }
          public DateTime NgaySD { get; set; }
          public string Lop { get; set; }
          public int CaTrongNgay { get; set; }
          public int SoNhom { get; set; }
          public string TinhTrang { get; set; }
          public string GhiChu { get; set; }

          public NVChiTietDangKyMod() { }

          public NVChiTietDangKyMod(string _MaCTDK)
          {
               MaCTDK = _MaCTDK;
          }

          public NVChiTietDangKyMod(string _MaCTDK, string _MaDangKy, string _HoTenGV, string _HoTenNV, string _TenPhong, string _TenBTN, DateTime _NgaySD, string _Lop, int _CaTrongNgay, int _SoNhom, string _TinhTrang, string _GhiChu)
          {
               MaCTDK = _MaCTDK;
               MaDangKy = _MaDangKy;
               HoTenGV = _HoTenGV;
               TenPhong = _TenPhong;
               HoTenNV = _HoTenNV;
               TenBTN = _TenBTN;
               NgaySD = _NgaySD;
               Lop = _Lop;
               CaTrongNgay = _CaTrongNgay;
               SoNhom = _SoNhom;
               TinhTrang = _TinhTrang;
               GhiChu = _GhiChu;
          }

          public NVChiTietDangKyMod(string _MaCTDK, string _MaDangKy, string _HoTenNV, string _TenPhong, string _TenBTN, DateTime _NgaySD, int _CaTrongNgay, int _SoNhom, string _TinhTrang, string _GhiChu)
          {
               MaCTDK = _MaCTDK;
               MaDangKy = _MaDangKy;
               TenPhong = _TenPhong;
               HoTenNV = _HoTenNV;
               TenBTN = _TenBTN;
               NgaySD = _NgaySD;
               CaTrongNgay = _CaTrongNgay;
               SoNhom = _SoNhom;
               TinhTrang = _TinhTrang;
               GhiChu = _GhiChu;
          }

          public static List<NVChiTietDangKyMod> getChiTietDangKy()
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    return (context.Database.SqlQuery<NVChiTietDangKyMod>("spGetChiTietDangKy", paralist.ToArray()).ToList<NVChiTietDangKyMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVChiTietDangKyMod>();
               }
          }
          public static List<NVChiTietDangKyMod> getChiTietDangKyByMaDangKy(string MaDangKy)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@MaDangKy", MaDangKy));
                    return (context.Database.SqlQuery<NVChiTietDangKyMod>("spGetChiTietDangKyByMaDangKy @MaDangKy", paralist.ToArray()).ToList<NVChiTietDangKyMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVChiTietDangKyMod>();
               }
          }

          public int InsertChiTietDangKy()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaCTDK", MaCTDK));
               paralist.Add(new SqlParameter("@HoTenNV", HoTenNV));
               paralist.Add(new SqlParameter("@TenPhong", TenPhong));
               paralist.Add(new SqlParameter("@MaDangKy", MaDangKy));
               paralist.Add(new SqlParameter("@TenBTN", TenBTN));
               paralist.Add(new SqlParameter("@NgaySD", NgaySD));
               paralist.Add(new SqlParameter("@CaTrongNgay", CaTrongNgay));
               paralist.Add(new SqlParameter("@SoNhom", SoNhom));
               paralist.Add(new SqlParameter("@TinhTrang", TinhTrang));
               paralist.Add(new SqlParameter("@GhiChu", GhiChu));
               return context.Database.ExecuteSqlCommand("spInsertChiTietDangKy @MaCTDK, @HoTenNV, @TenPhong, @MaDangKy, @TenBTN, @NgaySD, @CaTrongNgay, @SoNhom, @TinhTrang, @GhiChu", paralist.ToArray());
          }

          public int UpdateChiTietDangKy()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaCTDK", MaCTDK));
               paralist.Add(new SqlParameter("@HoTenNV", HoTenNV));
               paralist.Add(new SqlParameter("@TenPhong", TenPhong));
               paralist.Add(new SqlParameter("@MaDangKy", MaDangKy));
               paralist.Add(new SqlParameter("@TenBTN", TenBTN));
               paralist.Add(new SqlParameter("@NgaySD", NgaySD));
               paralist.Add(new SqlParameter("@CaTrongNgay", CaTrongNgay));
               paralist.Add(new SqlParameter("@SoNhom", SoNhom));
               paralist.Add(new SqlParameter("@TinhTrang", TinhTrang));
               paralist.Add(new SqlParameter("@GhiChu", GhiChu));
               return context.Database.ExecuteSqlCommand("spUpdateChiTietDangKy @MaCTDK, @HoTenNV, @TenPhong, @MaDangKy, @TenBTN, @NgaySD, @CaTrongNgay, @SoNhom, @TinhTrang, @GhiChu", paralist.ToArray());
          }

          public int DeleteChiTietDangKy()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaCTDK", MaCTDK));
               return context.Database.ExecuteSqlCommand("spDeleteChiTietDangKy @MaCTDK", paralist.ToArray());
          }

          public static List<NVChiTietDangKyMod> getChiTietDangKyByKey(string MaDangKy, string Key)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@MaDangKy", MaDangKy));
                    paralist.Add(new SqlParameter("@Key", Key));
                    return (context.Database.SqlQuery<NVChiTietDangKyMod>("spGetChiTietDangKyByKey @MaDangKy, @Key", paralist.ToArray()).ToList<NVChiTietDangKyMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVChiTietDangKyMod>();
               }
          }
     }
}
