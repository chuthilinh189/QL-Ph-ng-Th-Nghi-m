using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Controllers
{
     class NVHeThongPhongCtrl
     {
          
          public static int InsertPhongThiNghiem(string MaPhong, string TenPhong, string ViTri)
          {
               try
               {
                    Models.NVHeThongPhongMod _PhongThiNghiem = new Models.NVHeThongPhongMod(MaPhong, TenPhong, ViTri, 0, 0);
                    return _PhongThiNghiem.InsertPhongThiNghiem();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int UpdatePhongThiNghiem(string MaPhong, string TenPhong, string ViTri)
          {
               try
               {
                    Models.NVHeThongPhongMod _PhongThiNghiem = new Models.NVHeThongPhongMod(MaPhong, TenPhong, ViTri, 0, 0);
                    return _PhongThiNghiem.UpdatePhongThiNghiem();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int DetelePhongThiNghiem(string MaPhong)
          {
               try
               {
                    Models.NVHeThongPhongMod _PhongThiNghiem = new Models.NVHeThongPhongMod(MaPhong);
                    return _PhongThiNghiem.DeletePhongThiNghiem();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }
     }
}
