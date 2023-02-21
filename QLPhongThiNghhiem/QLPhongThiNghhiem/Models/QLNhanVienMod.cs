using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Behaviors;
using QLPhongThiNghhiem.DBContext;

namespace QLPhongThiNghhiem.Models
{
     class QLNhanVienMod
     {
          public string MaNV { get; set; }
          public string HoTen { get; set; }
          public string ChucVu { get; set; }
          public string GioiTinh { get; set; }
          public string SDT { get; set; }
          public DateTime? NgaySinh { get; set; }
          public string Email { get; set; }
          public string DiaChi { get; set; }

          public QLNhanVienMod() {}

          public QLNhanVienMod(string _MaNV)
          {
               MaNV = _MaNV;
          }

          public QLNhanVienMod(string _MaNV, string _HoTen,string _ChucVu, string _GioiTinh, string _SDT, DateTime _NgaySinh, string _Email, string _DiaChi)
          {
               MaNV = _MaNV;
               HoTen = _HoTen;
               ChucVu = _ChucVu;
               GioiTinh = _GioiTinh;
               SDT = _SDT;
               NgaySinh = _NgaySinh;
               Email = _Email;
               DiaChi = _DiaChi;
          }

          public static List<QLNhanVienMod> getNhanVien()
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    return (DBContext.DBPTNContext.context.Database.SqlQuery<QLNhanVienMod>("spGetNhanVien", paralist.ToArray()).ToList<QLNhanVienMod>());
               }
               catch(Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<QLNhanVienMod>();
               }
          }
          
          
     }
    
}
