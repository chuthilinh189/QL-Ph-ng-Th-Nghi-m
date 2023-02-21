using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Models
{
     class NVChiTietSuDungMod
     {
          static DBContext.DBPTNContext context = new DBContext.DBPTNContext();
          public string MaChiTietSD { get; set; }
          public string MaCTDK { get; set; }
          public string MaTTB { get; set; }
          public string TenTTB { get; set; }

          public NVChiTietSuDungMod() { }

          public NVChiTietSuDungMod(string _MaChiTietSD)
          {
               MaChiTietSD = _MaChiTietSD;
          }

          public NVChiTietSuDungMod(string _MaChiTietSD, string _MaCTDK, string _MaTTB)
          {
               MaChiTietSD = _MaChiTietSD;
               MaCTDK = _MaCTDK;
               MaTTB = _MaTTB;
          }

          public NVChiTietSuDungMod(string _MaChiTietSD, string _MaCTDK, string _MaTTB,string _TenTTB)
          {
               MaChiTietSD = _MaChiTietSD;
               MaCTDK = _MaCTDK;
               MaTTB = _MaTTB;
               TenTTB = _TenTTB;
          }

          public static List<NVChiTietSuDungMod> getChiTietSuDung()
          {
               try
               {
                    return (context.Database.SqlQuery<NVChiTietSuDungMod>("spGetChiTietSuDung").ToList<NVChiTietSuDungMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVChiTietSuDungMod>();
               }
          }

          public static List<NVChiTietSuDungMod> getChiTietSuDungByMaCTDK(string MaCTDK)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@MaCTDK", MaCTDK));
                    return (context.Database.SqlQuery<NVChiTietSuDungMod>("spGetChiTietSuDungByMaCTDK @MaCTDK", paralist.ToArray()).ToList<NVChiTietSuDungMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVChiTietSuDungMod>();
               }
          }

          public int InsertChiTietSuDung()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaChiTietSD", MaChiTietSD));
               paralist.Add(new SqlParameter("@MaCTDK", MaCTDK));
               paralist.Add(new SqlParameter("@MaTTB", MaTTB));
               return context.Database.ExecuteSqlCommand("spInsertChiTietSuDung @MaChiTietSD, @MaCTDK, @MaTTB", paralist.ToArray());
          }

          public int UpdateChiTietSuDung()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaChiTietSD", MaChiTietSD));
               paralist.Add(new SqlParameter("@MaCTDK", MaCTDK));
               paralist.Add(new SqlParameter("@MaTTB", MaTTB));
               return context.Database.ExecuteSqlCommand("spUpdateChiTietSuDung @MaChiTietSD, @MaCTDK, @MaTTB", paralist.ToArray());
          }

          public int DeleteChiTietSuDung()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaChiTietSD", MaChiTietSD));
               return context.Database.ExecuteSqlCommand("spDeleteChiTietSuDung @MaChiTietSD", paralist.ToArray());
          }

          public static List<NVChiTietSuDungMod> getChiTietSuDungByKey(string MaCTDK, string Key)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@MaCTDK", MaCTDK));
                    paralist.Add(new SqlParameter("@Key", Key));
                    return (context.Database.SqlQuery<NVChiTietSuDungMod>("spGetChiTietSuDungByKey @Key", paralist.ToArray()).ToList<NVChiTietSuDungMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVChiTietSuDungMod>();
               }
          }
     }
}
