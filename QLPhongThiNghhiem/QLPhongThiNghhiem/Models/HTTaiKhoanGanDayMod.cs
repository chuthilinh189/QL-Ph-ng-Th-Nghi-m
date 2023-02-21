using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongThiNghhiem.Models
{
     public class HTTaiKhoanGanDayMod
     {
          public string MaTK { get; set; }
          public string HoTen { get; set; }
          public byte[] HinhAnh { get; set; }
          public string TenDN { get; set; }

          public string Quyen { get; set; }

          public static HTTaiKhoanGanDayMod taiKhoanGanDay;

          public static HTTaiKhoanGanDayMod GetThongTinTaiKhoan()
          {
               try
               {
                    taiKhoanGanDay = DBContext.DBPTNContext.context.Database.SqlQuery<HTTaiKhoanGanDayMod>("spGetTaiKhoanGanDay").FirstOrDefault();
                    return taiKhoanGanDay;
               }
               catch (Exception)
               {
                    return null;
               }
          }

          public static int KiemTraDangNhap(string _TenDN, string _MatKhau)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@TenDN", _TenDN));
                    paralist.Add(new SqlParameter("@MatKhau", _MatKhau));
                    HTTaiKhoanGanDayMod tmp = DBContext.DBPTNContext.context.Database.SqlQuery<HTTaiKhoanGanDayMod>("spKiemTraDangNhap @TenDN, @MatKhau", paralist.ToArray()).FirstOrDefault();
                    if (tmp != null)
                    {
                         taiKhoanGanDay = tmp;
                         return 1;
                    }
                    else return 0;
               }
               catch (Exception)
               {
                    return 0;
               }
          }



     }
}
