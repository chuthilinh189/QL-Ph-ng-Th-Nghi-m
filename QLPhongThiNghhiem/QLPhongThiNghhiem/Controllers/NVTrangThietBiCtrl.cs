using QLPhongThiNghhiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Controllers
{
     class NVTrangThietBiCtrl
     {

          public static List<NVTrangThietBiMod> getTrangThietBiByLtttPtn( string TenLoai, string TenPhong)
          {
               try
               {
                    Models.NVTrangThietBiMod _TrangThietBi = new Models.NVTrangThietBiMod(TenLoai,TenPhong);
                    return _TrangThietBi.getTrangThietBiByLtttPtn();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVTrangThietBiMod>();
               }
          }

          public static List<NVTrangThietBiMod> getTrangThietBiByKey(string TenLoai, string TenPhong, string Key)
          {
               try
               {
                    Models.NVTrangThietBiMod _TrangThietBi = new Models.NVTrangThietBiMod(TenLoai, TenPhong);
                    return _TrangThietBi.getTrangThietBiByKey(Key);
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVTrangThietBiMod>();
               }
          }

          public static int InsertTrangThietBi(string MaTTB, string TenTTB, string TenPhong, string TenLoai, string TenNSX, DateTime NgayNhap, int GiaTien, string TinhTrang, string GhiChu, bool XuatKho)
          {
               try
               {
                    Models.NVTrangThietBiMod _TrangThietBi = new Models.NVTrangThietBiMod(MaTTB, TenTTB, TenPhong, TenLoai, TenNSX, NgayNhap, GiaTien, TinhTrang, GhiChu, XuatKho);
                    return _TrangThietBi.InsertTrangThietBi();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int UpdateTrangThietBi(string MaTTB, string TenTTB, string TenPhong, string TenLoai, string TenNSX, DateTime NgayNhap, int GiaTien, string TinhTrang, string GhiChu, bool XuatKho)
          {
               try
               {
                    Models.NVTrangThietBiMod _TrangThietBi = new Models.NVTrangThietBiMod(MaTTB, TenTTB, TenPhong, TenLoai, TenNSX, NgayNhap, GiaTien, TinhTrang, GhiChu, XuatKho);
                    return _TrangThietBi.UpdateTrangThietBi();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int DeteleTrangThietBi(string MaTTB)
          {
               try
               {
                    Models.NVTrangThietBiMod _TrangThietBi = new Models.NVTrangThietBiMod(MaTTB);
                    return _TrangThietBi.DeleteTrangThietBi();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }
     }
}
