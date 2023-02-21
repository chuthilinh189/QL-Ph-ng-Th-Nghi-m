using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Models
{
     class NVBaiThiNghiemMod
     {
          static DBContext.DBPTNContext context = new DBContext.DBPTNContext();

          public string MaBTN { get; set; }
          public string TenBTN { get; set; }

          public NVBaiThiNghiemMod() { }

          public NVBaiThiNghiemMod(string _MaBTN)
          {
               MaBTN = _MaBTN;
          }

          public NVBaiThiNghiemMod(string _MaBTN, string _TenBTN)
          {
               MaBTN = _MaBTN;
               TenBTN = _TenBTN;
          }

          public static List<NVBaiThiNghiemMod> getBaiThiNghiem()
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    return (context.Database.SqlQuery<NVBaiThiNghiemMod>("spGetBaiThiNghiem", paralist.ToArray()).ToList<NVBaiThiNghiemMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVBaiThiNghiemMod>();
               }
          }

          public int InsertBaiThiNghiem()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaBTN", MaBTN));
               paralist.Add(new SqlParameter("@TenBTN", TenBTN));
               return context.Database.ExecuteSqlCommand("spInsertBaiThiNghiem @MaBTN, @TenBTN", paralist.ToArray());
          }

          public int UpdateBaiThiNghiem()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaBTN", MaBTN));
               paralist.Add(new SqlParameter("@TenBTN", TenBTN));
               return context.Database.ExecuteSqlCommand("spUpdateBaiThiNghiem @MaBTN, @TenBTN", paralist.ToArray());
          }

          public int DeleteBaiThiNghiem()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaBTN", MaBTN));
               return context.Database.ExecuteSqlCommand("spDeleteBaiThiNghiem @MaBTN", paralist.ToArray());
          }

          public static List<NVBaiThiNghiemMod> getBaiThiNghiemByKey(string Key)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@Key", Key));
                    return (context.Database.SqlQuery<NVBaiThiNghiemMod>("spGetBaiThiNghiemByKey @Key", paralist.ToArray()).ToList<NVBaiThiNghiemMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVBaiThiNghiemMod>();
               }
          }
     }
}
