using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Models
{
     class QLGiaoVienMod
     {
          public string MaGV { get; set; }
          public string HoTen { get; set; }
          public string GioiTinh { get; set; }
          public string SDT { get; set; }
          public DateTime? NgaySinh { get; set; }
          public string Email { get; set; }
          public string DiaChi { get; set; }

          public QLGiaoVienMod() { }

          public QLGiaoVienMod(string _MaGV)
          {
               MaGV = _MaGV;
          }

          public QLGiaoVienMod(string _MaGV, string _HoTen, string _GioiTinh, string _SDT, DateTime _NgaySinh, string _Email, string _DiaChi)
          {
               MaGV = _MaGV;
               HoTen = _HoTen;
               GioiTinh = _GioiTinh;
               SDT = _SDT;
               NgaySinh = _NgaySinh;
               Email = _Email;
               DiaChi = _DiaChi;
          }

          public static List<QLGiaoVienMod> getGiaoVien()
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    return (DBContext.DBPTNContext.context.Database.SqlQuery<QLGiaoVienMod>("spGetGiaoVien", paralist.ToArray()).ToList<QLGiaoVienMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<QLGiaoVienMod>();
               }
          }
     }
}
