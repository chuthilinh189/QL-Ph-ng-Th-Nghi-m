using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Controllers
{
     class NVTrangBiCanDungCtrl
     {
          public static int InsertTrangBiCanDung(string MaChiTiet, string TenBTN, string TenLoai, int SoLuong)
          {
               try
               {
                    Models.NVTrangBiCanDungMod _TrangBiCanDung = new Models.NVTrangBiCanDungMod(MaChiTiet, TenBTN, TenLoai, SoLuong);
                    return _TrangBiCanDung.InsertTrangBiCanDung();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int UpdateTrangBiCanDung(string MaChiTiet, string TenBTN, string TenLoai, int SoLuong)
          {
               try
               {
                    Models.NVTrangBiCanDungMod _TrangBiCanDung = new Models.NVTrangBiCanDungMod(MaChiTiet, TenBTN, TenLoai, SoLuong);
                    return _TrangBiCanDung.UpdateTrangBiCanDung();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int DeteleTrangBiCanDung(string MaChiTiet)
          {
               try
               {
                    Models.NVTrangBiCanDungMod _TrangBiCanDung = new Models.NVTrangBiCanDungMod(MaChiTiet);
                    return _TrangBiCanDung.DeleteTrangBiCanDung();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }
     }
}
