using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Models
{
     class NVLoaiTTBMod
     {
          static DBContext.DBPTNContext context = new DBContext.DBPTNContext();

          public string MaLTTB { get; set; }
          public string TenLoai { get; set; }
          public int SoLuong { get; set; }
          public string DonViTinh { get; set; }

          public NVLoaiTTBMod() { }

          public NVLoaiTTBMod(string _MaLTTB)
          {
               MaLTTB = _MaLTTB;
          }

          public NVLoaiTTBMod(string _MaLTTB, string _TenLoai, string _DonViTinh)
          {
               MaLTTB = _MaLTTB;
               TenLoai = _TenLoai;
               DonViTinh = _DonViTinh;
          }

          public static List<NVLoaiTTBMod> getLoaiTrangThietBi()
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    return (context.Database.SqlQuery<NVLoaiTTBMod>("spGetLoaiTrangThietBi", paralist.ToArray()).ToList<NVLoaiTTBMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVLoaiTTBMod>();
               }
          }

          public int InsertLoaiTrangThietBi()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaLTTB", MaLTTB));
               paralist.Add(new SqlParameter("@TenLoai", TenLoai));
               paralist.Add(new SqlParameter("@DonViTinh", DonViTinh));
               return context.Database.ExecuteSqlCommand("spInsertLoaiTrangThietBi @MaLTTB, @TenLoai, @DonViTinh", paralist.ToArray());
          }

          public int UpdateLoaiTrangThietBi()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaLTTB", MaLTTB));
               paralist.Add(new SqlParameter("@TenLoai", TenLoai));
               paralist.Add(new SqlParameter("@DonViTinh", DonViTinh));
               return context.Database.ExecuteSqlCommand("spUpdateLoaiTrangThietBi @MaLTTB, @TenLoai, @DonViTinh", paralist.ToArray());
          }

          public int DeleteLoaiTrangThietBi()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaLTTB", MaLTTB));
               return context.Database.ExecuteSqlCommand("spDeleteLoaiTrangThietBi @MaLTTB", paralist.ToArray());
          }

          public static List<NVLoaiTTBMod> getLoaiTrangThietBiByKey(string Key)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@Key", Key));
                    return (context.Database.SqlQuery<NVLoaiTTBMod>("spGetLoaiTrangThietBiByKey @Key", paralist.ToArray()).ToList<NVLoaiTTBMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVLoaiTTBMod>();
               }
          }
     }
}
