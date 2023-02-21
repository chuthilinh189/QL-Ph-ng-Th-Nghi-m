using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Models
{
     class NVCaSuDungMod
     {
          static DBContext.DBPTNContext context = new DBContext.DBPTNContext();

          public string MaCTDK { get; set; }
          public string TenPhong { get; set; }
          public string Lop { get; set; }
          public string TenBTN { get; set; }
          public string HoTenGV { get; set; }
          public string HoTenNV { get; set; }
          public DateTime NgaySD { get; set; }
          public int CaTrongNgay { get; set; }
          public int SoNhom { get; set; }
          public int TTBDaDung { get; set; }

          public NVCaSuDungMod() { }

          public NVCaSuDungMod(string _MaCTDK)
          {
               MaCTDK = _MaCTDK;
          }

          public NVCaSuDungMod(string _TenBTN, string _Lop)
          {
               TenBTN = _TenBTN;
               Lop = _Lop;
          }

          public NVCaSuDungMod(string _MaCTDK, string _TenPhong, string _Lop, string _TenBTN, string _HoTenGV, string _HoTenNV, DateTime _NgaySD, int _CaTrongNgay, int _SoNhom, int _TTBDaDung)
          {
               MaCTDK = _MaCTDK;
               TenPhong = _TenPhong;
               Lop = _Lop;
               HoTenGV = _HoTenGV;
               TenBTN = _TenBTN;
               HoTenNV = _HoTenNV;
               NgaySD = _NgaySD;
               CaTrongNgay = _CaTrongNgay;
               SoNhom = _SoNhom;
               TTBDaDung = _TTBDaDung;
          }

          public static 
               List<NVCaSuDungMod> getCaSuDung()
          {
               try
               {
                    return (context.Database.SqlQuery<NVCaSuDungMod>("spGetCaSuDung").ToList<NVCaSuDungMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVCaSuDungMod>();
               }
          }

          public static List<NVCaSuDungMod> getCaSuDungByKey( string Key)
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@Key", Key));
                    return (context.Database.SqlQuery<NVCaSuDungMod>("spGetCaSuDungByKey @Key", paralist.ToArray()).ToList<NVCaSuDungMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVCaSuDungMod>();
               }
          }
     }
}
