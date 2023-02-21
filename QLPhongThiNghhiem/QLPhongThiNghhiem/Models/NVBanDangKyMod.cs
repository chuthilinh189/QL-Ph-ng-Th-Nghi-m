using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Models
{
     class NVBanDangKyMod
     {

          static DBContext.DBPTNContext context = new DBContext.DBPTNContext();

          public string MaDangKy { get; set; }
          public string HoTen { get; set; }
          public string Lop { get; set; }
          public int QuanSo { get; set; }
          public int HocKy { get; set; }
          public string NamHoc { get; set; }


          public NVBanDangKyMod() { }

          public NVBanDangKyMod(string _MaDangKy)
          {
               MaDangKy = _MaDangKy;
          }

          public NVBanDangKyMod(string _MaDangKy, string _HoTen, string _Lop, int _QuanSo, int _HocKy, string _NamHoc)
          {
               MaDangKy = _MaDangKy;
               HoTen = _HoTen;
               Lop = _Lop;
               QuanSo = _QuanSo;
               HocKy = _HocKy;
               NamHoc = _NamHoc;
          }

          public static List<NVBanDangKyMod> getBanDangKy()
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    return (context.Database.SqlQuery<NVBanDangKyMod>("spGetBanDangKy", paralist.ToArray()).ToList<NVBanDangKyMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVBanDangKyMod>();
               }
          }

          public int InsertBanDangKy()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaDangKy", MaDangKy));
               paralist.Add(new SqlParameter("@HoTen", HoTen));
               paralist.Add(new SqlParameter("@Lop", Lop));
               paralist.Add(new SqlParameter("@QuanSo", QuanSo));
               paralist.Add(new SqlParameter("@HocKy", HocKy));
               paralist.Add(new SqlParameter("@NamHoc", NamHoc));
               return context.Database.ExecuteSqlCommand("spInsertBanDangKy @MaDangKy, @HoTen, @Lop, @QuanSo, @HocKy, @NamHoc", paralist.ToArray());
          }

          public int UpdateBanDangKy()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaDangKy", MaDangKy));
               paralist.Add(new SqlParameter("@HoTen", HoTen));
               paralist.Add(new SqlParameter("@Lop", Lop));
               paralist.Add(new SqlParameter("@QuanSo", QuanSo));
               paralist.Add(new SqlParameter("@HocKy", HocKy));
               paralist.Add(new SqlParameter("@NamHoc", NamHoc));
               return context.Database.ExecuteSqlCommand("spUpdateBanDangKy @MaDangKy, @HoTen, @Lop, @QuanSo, @HocKy, @NamHoc", paralist.ToArray());
          }

          public int DeleteBanDangKy()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaDangKy", MaDangKy));
               return context.Database.ExecuteSqlCommand("spDeleteBanDangKy @MaDangKy", paralist.ToArray());
          }

          public static List<NVBanDangKyMod> getBanDangKyByKey(string Key)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@Key", Key));
                    return (context.Database.SqlQuery<NVBanDangKyMod>("spGetBanDangKyByKey @Key", paralist.ToArray()).ToList<NVBanDangKyMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVBanDangKyMod>();
               }
          }
     }
}
