using QLPhongThiNghhiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Controllers
{
     class NVChiTietSuDungCtrl
     {
          public static List<NVChiTietSuDungMod> getChiTietSuDung(string MaCTDK)
          {
               try
               {
                    if (MaCTDK == "") return Models.NVChiTietSuDungMod.getChiTietSuDung();
                    else return Models.NVChiTietSuDungMod.getChiTietSuDungByMaCTDK(MaCTDK);
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVChiTietSuDungMod>();
               }
          }

          public static List<NVChiTietSuDungMod> getChiTietSuDungByKey(string MaCTDK, string Key)
          {
               try
               {
                    return Models.NVChiTietSuDungMod.getChiTietSuDungByKey(MaCTDK, Key);
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVChiTietSuDungMod>();
               }
          }

          public static int InsertChiTietSuDung(string _MaChiTietSD, string _MaCTDK, string _MaTTB)
          {
               try
               {
                    Models.NVChiTietSuDungMod _ChiTietSuDung = new Models.NVChiTietSuDungMod(_MaChiTietSD, _MaCTDK, _MaTTB);
                    return _ChiTietSuDung.InsertChiTietSuDung();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int UpdateChiTietSuDung(string _MaChiTietSD, string _MaCTDK, string _MaTTB)
          {
               try
               {
                    Models.NVChiTietSuDungMod _ChiTietSuDung = new Models.NVChiTietSuDungMod(_MaChiTietSD, _MaCTDK, _MaTTB);
                    return _ChiTietSuDung.UpdateChiTietSuDung();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }

          public static int DeteleChiTietSuDung(string MaCTDK)
          {
               try
               {
                    Models.NVChiTietSuDungMod _ChiTietSuDung = new Models.NVChiTietSuDungMod(MaCTDK);
                    return _ChiTietSuDung.DeleteChiTietSuDung();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return 0;
               }
          }
     }
}
