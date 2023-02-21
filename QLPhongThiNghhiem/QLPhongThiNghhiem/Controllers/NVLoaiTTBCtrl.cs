using DevExpress.XtraEditors.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Controllers
{
     class NVLoaiTTBCtrl
     {
          public static int InsertLoaiTrangThietBi(string MaLTTB, string TenLoai, string DonViTinh)
          {
               try
               {
                    Models.NVLoaiTTBMod _LoaiTTB = new Models.NVLoaiTTBMod(MaLTTB, TenLoai, DonViTinh);
                    return _LoaiTTB.InsertLoaiTrangThietBi();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int UpdateLoaiTrangThietBi(string MaLTTB, string TenLoai, string DonViTinh)
          {
               try
               {
                    Models.NVLoaiTTBMod _LoaiTTB = new Models.NVLoaiTTBMod(MaLTTB, TenLoai, DonViTinh);
                    return _LoaiTTB.UpdateLoaiTrangThietBi();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int DeteleLoaiTrangThietBi(string MaLTTB)
          {
               try
               {
                    Models.NVLoaiTTBMod _LoaiTTB = new Models.NVLoaiTTBMod(MaLTTB);
                    return _LoaiTTB.DeleteLoaiTrangThietBi();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }
     }
}
