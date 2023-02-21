using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Models
{
     class NVHeThongPhongMod
     {
          static DBContext.DBPTNContext context = new DBContext.DBPTNContext();

          public string MaPhong { get; set; }
          public string TenPhong { get; set; }
          public string ViTri { get; set; }
          public int TongTTB { get; set; }
          public int TongCSD { get; set; }

          public NVHeThongPhongMod() { }

          public NVHeThongPhongMod(string _MaPhong)
          {
               MaPhong = _MaPhong;
          }

          public NVHeThongPhongMod(string _MaPhong, string _TenPhong, string _ViTri, int _TongTTB, int _TongCSD)
          {
               MaPhong = _MaPhong;
               TenPhong = _TenPhong;
               ViTri = _ViTri;
               TongTTB = _TongTTB;
               TongCSD = _TongCSD;
          }

          public static List<NVHeThongPhongMod> getPhongThiNghiem()
          {
               try
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    return (context.Database.SqlQuery<NVHeThongPhongMod>("spGetPhongThiNghiem", paralist.ToArray()).ToList<NVHeThongPhongMod>());
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message, "Lỗi");
                    return new List<NVHeThongPhongMod>();
               }
          }

          public int InsertPhongThiNghiem()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaPhong", MaPhong));
               paralist.Add(new SqlParameter("@TenPhong", TenPhong));
               paralist.Add(new SqlParameter("@ViTri", ViTri));
               return context.Database.ExecuteSqlCommand("spInsertPhongThiNghiem @MaPhong,@TenPhong, @ViTri", paralist.ToArray());
          }

          public int UpdatePhongThiNghiem()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaPhong", MaPhong));
               paralist.Add(new SqlParameter("@TenPhong", TenPhong));
               paralist.Add(new SqlParameter("@ViTri", ViTri));
               return context.Database.ExecuteSqlCommand("spUpdatePhongThiNghiem @MaPhong,@TenPhong, @ViTri", paralist.ToArray());
          }

          public int DeletePhongThiNghiem()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaPhong", MaPhong));
               return context.Database.ExecuteSqlCommand("spDeletePhongThiNghiem @MaPhong", paralist.ToArray());
          }
     }
}
