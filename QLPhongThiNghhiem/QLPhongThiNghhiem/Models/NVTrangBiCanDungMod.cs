using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Models
{
     class NVTrangBiCanDungMod
     {
          static DBContext.DBPTNContext context = new DBContext.DBPTNContext();

          public string MaChiTiet { get; set; }
          public string TenBTN { get; set; }
          public string TenLoai { get; set; }
          public int SoLuong { get; set; }

          public NVTrangBiCanDungMod() { }

          public NVTrangBiCanDungMod(string _MaChiTiet)
          {
               MaChiTiet = _MaChiTiet;
          }

          public NVTrangBiCanDungMod(string _MaChiTiet, string _TenBTN, string _TenLoai, int _SoLuong)
          {
               MaChiTiet = _MaChiTiet;
               TenBTN = _TenBTN;
               TenLoai = _TenLoai;
               SoLuong = _SoLuong;
          }

          public static List<NVTrangBiCanDungMod> getTrangBiCanDung()
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    return (context.Database.SqlQuery<NVTrangBiCanDungMod>("spGetTrangThietBiCanDung", paralist.ToArray()).ToList<NVTrangBiCanDungMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVTrangBiCanDungMod>();
               }
          }

          public static List<NVTrangBiCanDungMod> getTrangBiCanDungByMaBTN(string MaBTN)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@MaBTN", MaBTN));
                    return (context.Database.SqlQuery<NVTrangBiCanDungMod>("spGetTrangThietBiCanDungByMaBTN @MaBTN", paralist.ToArray()).ToList<NVTrangBiCanDungMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVTrangBiCanDungMod>();
               }
          }

          public int InsertTrangBiCanDung()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaChiTiet", MaChiTiet));
               paralist.Add(new SqlParameter("@TenBTN", TenBTN));
               paralist.Add(new SqlParameter("@TenLoai", TenLoai));
               paralist.Add(new SqlParameter("@SoLuong", SoLuong));
               return context.Database.ExecuteSqlCommand("spInsertTrangBiCanDung @MaChiTiet, @TenBTN, @TenLoai, @SoLuong", paralist.ToArray());
          }

          public int UpdateTrangBiCanDung()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaChiTiet", MaChiTiet));
               paralist.Add(new SqlParameter("@TenBTN", TenBTN));
               paralist.Add(new SqlParameter("@TenLoai", TenLoai));
               paralist.Add(new SqlParameter("@SoLuong", SoLuong));
               return context.Database.ExecuteSqlCommand("spUpdateTrangBiCanDung @MaChiTiet, @TenBTN, @TenLoai, @SoLuong", paralist.ToArray());
          }

          public int DeleteTrangBiCanDung()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaChiTiet", MaChiTiet));
               return context.Database.ExecuteSqlCommand("spDeleteTrangBiCanDung @MaTTB", paralist.ToArray());
          }

          public static List<NVTrangBiCanDungMod> getTrangBiCanDungByKey(string MaBTN, string Key)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@MaBTN", MaBTN));
                    paralist.Add(new SqlParameter("@Key", Key));
                    return (context.Database.SqlQuery<NVTrangBiCanDungMod>("spGetTrangThietBiCanDungByKey @MaBTN, @Key", paralist.ToArray()).ToList<NVTrangBiCanDungMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVTrangBiCanDungMod>();
               }
          }
     }
}
