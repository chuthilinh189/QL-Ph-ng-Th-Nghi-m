using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Controllers
{
     class HTThongTinGiaoVienCtrl
     {
          public static int InsertGiaoVien(string _MaGV, Image _HinhAnh, string _HoTen, string _GioiTinh, string _SDT, DateTime _NgaySinh, string _Email, string _DiaChi, string _GioiThieu)
          {
               try
               {
                    Models.HTThongTinGiaoVienMod _GiaoVien = new Models.HTThongTinGiaoVienMod(_MaGV, Resources.Funtion.convertImageToBytes(_HinhAnh), _HoTen, _GioiTinh, _SDT, _NgaySinh, _Email, _DiaChi, _GioiThieu);
                    return _GiaoVien.InsertGiaoVien();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int UpdateGiaoVien(string _MaGV, Image _HinhAnh, string _HoTen, string _GioiTinh, string _SDT, DateTime _NgaySinh, string _Email, string _DiaChi, string _GioiThieu)
          {
               try
               {
                    Models.HTThongTinGiaoVienMod _GiaoVien = new Models.HTThongTinGiaoVienMod(_MaGV, Resources.Funtion.convertImageToBytes(_HinhAnh), _HoTen, _GioiTinh, _SDT, _NgaySinh, _Email, _DiaChi, _GioiThieu);
                    return _GiaoVien.UpdateGiaoVien();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int DeteleGiaoVien(string _MaGV)
          {
               try
               {
                    Models.HTThongTinGiaoVienMod _GiaoVien = new Models.HTThongTinGiaoVienMod(_MaGV);
                    return _GiaoVien.DeleteGiaoVien();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }
     }
}
