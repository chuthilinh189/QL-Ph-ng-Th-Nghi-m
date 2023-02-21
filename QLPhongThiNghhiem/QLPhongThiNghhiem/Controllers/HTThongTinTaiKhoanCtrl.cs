using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Controllers
{
     class HTThongTinTaiKhoanCtrl
     {
          
          public static int InsertNhanVien(string _MaNV, string _ChucVu, Image _HinhAnh, string _HoTen, string _GioiTinh, string _SDT, DateTime _NgaySinh, string _Email, string _DiaChi, string _GioiThieu)
          {
               try 
               {
                    Models.HTThongTinTaiKhoanMod _NhanVien = new Models.HTThongTinTaiKhoanMod(_MaNV, _ChucVu, Resources.Funtion.convertImageToBytes(_HinhAnh), _HoTen, _GioiTinh, _SDT, _NgaySinh, _Email, _DiaChi, _GioiThieu);
                    return _NhanVien.InsertNhanVien();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int UpdateNhanVien(string _MaNV, string _ChucVu, Image _HinhAnh, string _HoTen, string _GioiTinh, string _SDT, DateTime _NgaySinh, string _Email, string _DiaChi, string _GioiThieu)
          {
               try
               {
                    Models.HTThongTinTaiKhoanMod _NhanVien = new Models.HTThongTinTaiKhoanMod(_MaNV, _ChucVu, Resources.Funtion.convertImageToBytes(_HinhAnh), _HoTen, _GioiTinh, _SDT, _NgaySinh, _Email, _DiaChi, _GioiThieu);
                    return _NhanVien.UpdateNhanVien();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int DeteleNhanVien(string _MaNV)
          {
               try
               {
                    Models.HTThongTinTaiKhoanMod _NhanVien = new Models.HTThongTinTaiKhoanMod(_MaNV);
                    return _NhanVien.DeleteNhanVien();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }
     }
}
