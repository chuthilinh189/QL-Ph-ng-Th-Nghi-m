using QLPhongThiNghhiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Controllers
{
     class NVChiTietDangKyCtrl
     {
          public static List<NVChiTietDangKyMod> getChiTietDangKy(string MaDangKy)
          {
               try
               {
                    if (MaDangKy == "") return Models.NVChiTietDangKyMod.getChiTietDangKy();
                    else return Models.NVChiTietDangKyMod.getChiTietDangKyByMaDangKy(MaDangKy);
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVChiTietDangKyMod>();
               }
          }

          public static List<NVChiTietDangKyMod> getChiTietDangKyByKey(string MaDangKy, string Key)
          {
               try
               {
                    return Models.NVChiTietDangKyMod.getChiTietDangKyByKey(MaDangKy, Key);
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVChiTietDangKyMod>();
               }
          }

          public static int InsertChiTietDangKy(string _MaCTDK, string _MaDangKy, string _HoTenNV, string _TenPhong, string _TenBTN, DateTime _NgaySD, int _CaTrongNgay, int _SoNhom, string _TinhTrang, string _GhiChu)
          {
               try
               {
                    Models.NVChiTietDangKyMod _ChiTietDangKy = new Models.NVChiTietDangKyMod(_MaCTDK, _MaDangKy, _HoTenNV, _TenPhong, _TenBTN, _NgaySD, _CaTrongNgay, _SoNhom, _TinhTrang, _GhiChu);
                    return _ChiTietDangKy.InsertChiTietDangKy();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int UpdateChiTietDangKy(string _MaCTDK, string _MaDangKy, string _HoTenNV, string _TenPhong, string _TenBTN, DateTime _NgaySD, int _CaTrongNgay, int _SoNhom, string _TinhTrang, string _GhiChu)
          {
               try
               {
                    Models.NVChiTietDangKyMod _ChiTietDangKy = new Models.NVChiTietDangKyMod(_MaCTDK, _MaDangKy, _HoTenNV, _TenPhong, _TenBTN, _NgaySD, _CaTrongNgay, _SoNhom, _TinhTrang, _GhiChu);
                    return _ChiTietDangKy.UpdateChiTietDangKy();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int DeteleChiTietDangKy(string MaCTDK)
          {
               try
               {
                    Models.NVChiTietDangKyMod _ChiTietDangKy = new Models.NVChiTietDangKyMod(MaCTDK);
                    return _ChiTietDangKy.DeleteChiTietDangKy();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }
     }
}
