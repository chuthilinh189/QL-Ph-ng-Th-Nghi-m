using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Controllers
{
     class NVBanDangKyCtrl
     {
          public static int InsertBanDangKy(string _MaDangKy, string _HoTen, string _Lop, int _QuanSo, int _HocKy, string _NamHoc)
          {
               try
               {
                    Models.NVBanDangKyMod _BanDangKy = new Models.NVBanDangKyMod( _MaDangKy,  _HoTen,  _Lop,  _QuanSo,  _HocKy,  _NamHoc);
                    return _BanDangKy.InsertBanDangKy();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int UpdateBanDangKy(string _MaDangKy, string _HoTen, string _Lop, int _QuanSo, int _HocKy, string _NamHoc)
          {
               try
               {
                    Models.NVBanDangKyMod _BanDangKy = new Models.NVBanDangKyMod(_MaDangKy, _HoTen, _Lop, _QuanSo, _HocKy, _NamHoc);
                    return _BanDangKy.UpdateBanDangKy();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int DeteleBanDangKy(string _MaDangKy)
          {
               try
               {
                    Models.NVBanDangKyMod _BanDangKy = new Models.NVBanDangKyMod(_MaDangKy);
                    return _BanDangKy.DeleteBanDangKy();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }
     }
}
