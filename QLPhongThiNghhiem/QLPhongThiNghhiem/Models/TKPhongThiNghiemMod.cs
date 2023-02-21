using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Models
{
     class TKPhongThiNghiemMod
     {
          static DBContext.DBPTNContext context = new DBContext.DBPTNContext();
          public string TenPhong { get; set; }
          public decimal TongTTB { get; set; }
          public decimal ChatLuongTTB { get; set; }
          public decimal TongCaSuDung { get; set; }

          public static List<TKPhongThiNghiemMod> getThongKePhongThiNghiem(DateTime NgayBD, DateTime NgayKT)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@NgayBatDau", NgayBD));
                    paralist.Add(new SqlParameter("@NgayKetThuc", NgayKT));
                    return (context.Database.SqlQuery<TKPhongThiNghiemMod>("spThongKe_PhongThiNghiem @NgayBatDau, @NgayKetThuc", paralist.ToArray()).ToList<TKPhongThiNghiemMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<TKPhongThiNghiemMod>();
               }
          }

          public static TKPhongThiNghiemMod getThongKePhongThiNghiemTK (DateTime NgayBD, DateTime NgayKT)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@NgayBatDau", NgayBD));
                    paralist.Add(new SqlParameter("@NgayKetThuc", NgayKT));
                    return (context.Database.SqlQuery<TKPhongThiNghiemMod>("spThongKe_PhongThiNghiemTB @NgayBatDau, @NgayKetThuc", paralist.ToArray()).FirstOrDefault());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new TKPhongThiNghiemMod();
               }
          }
     }
}
