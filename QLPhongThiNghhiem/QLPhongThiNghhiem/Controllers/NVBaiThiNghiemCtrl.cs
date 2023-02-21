using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Controllers
{
     class NVBaiThiNghiemCtrl
     {
          public static int InsertBaiThiNghiem(string _MaBTN, string _TenBTN)
          {
               try
               {
                    Models.NVBaiThiNghiemMod _BaiThiNghiem = new Models.NVBaiThiNghiemMod(_MaBTN, _TenBTN);
                    return _BaiThiNghiem.InsertBaiThiNghiem();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int UpdateBaiThiNghiem(string _MaBTN, string _TenBTN)
          {
               try
               {
                    Models.NVBaiThiNghiemMod _BaiThiNghiem = new Models.NVBaiThiNghiemMod(_MaBTN, _TenBTN);
                    return _BaiThiNghiem.UpdateBaiThiNghiem();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int DeteleBaiThiNghiem(string _MaBTN)
          {
               try
               {
                    Models.NVBaiThiNghiemMod _BaiThiNghiem = new Models.NVBaiThiNghiemMod(_MaBTN);
                    return _BaiThiNghiem.DeleteBaiThiNghiem();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }
     }
}
