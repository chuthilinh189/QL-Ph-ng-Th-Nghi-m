using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Models
{
     class TKLoaiTrangThietBiMod
     {
          static DBContext.DBPTNContext context = new DBContext.DBPTNContext();
          public string TenLoai { get; set; }
          public decimal TongTTB { get; set; }
          public decimal SoTTBHong { get; set; }
          public decimal ChatLuongTTB { get; set; }
          public decimal TongLuotSuDung { get; set; }

          public static List<TKLoaiTrangThietBiMod> getThongKeLoaiTrangThietBi(DateTime NgayBD, DateTime NgayKT)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@NgayBatDau", NgayBD));
                    paralist.Add(new SqlParameter("@NgayKetThuc", NgayKT));
                    return (context.Database.SqlQuery<TKLoaiTrangThietBiMod>("spThongKe_LoaiTrangThietBi @NgayBatDau, @NgayKetThuc", paralist.ToArray()).ToList<TKLoaiTrangThietBiMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<TKLoaiTrangThietBiMod>();
               }
          }

          public static TKLoaiTrangThietBiMod getThongKeLoaiTrangThietBiTB(DateTime NgayBD, DateTime NgayKT)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@NgayBatDau", NgayBD));
                    paralist.Add(new SqlParameter("@NgayKetThuc", NgayKT));
                    return (context.Database.SqlQuery<TKLoaiTrangThietBiMod>("spThongKe_LoaiTrangThietBiTB @NgayBatDau, @NgayKetThuc", paralist.ToArray()).FirstOrDefault());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new TKLoaiTrangThietBiMod();
               }
          }
     }
}
