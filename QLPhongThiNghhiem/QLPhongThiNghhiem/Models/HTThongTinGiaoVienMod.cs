using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongThiNghhiem.Models
{
     class HTThongTinGiaoVienMod
     {
          public byte[] HinhAnh { get; set; }
          public string MaGV { get; set; }
          public string HoTen { get; set; }
          public string GioiTinh { get; set; }
          public string SDT { get; set; }
          public DateTime? NgaySinh { get; set; }
          public string Email { get; set; }
          public string DiaChi { get; set; }
          public string GioiThieu { get; set; }

          public static HTThongTinGiaoVienMod thongTinGiaoVien;

          public HTThongTinGiaoVienMod() { }

          public HTThongTinGiaoVienMod(string _MaGV)
          {
               MaGV = _MaGV;
          }


          public HTThongTinGiaoVienMod(string _MaGV, byte[] _HinhAnh, string _HoTen, string _GioiTinh, string _SDT, DateTime _NgaySinh, string _Email, string _DiaChi, string _GioiThieu)
          {
               MaGV = _MaGV;
               HinhAnh = _HinhAnh;
               HoTen = _HoTen;
               GioiTinh = _GioiTinh;
               SDT = _SDT;
               NgaySinh = _NgaySinh;
               Email = _Email;
               DiaChi = _DiaChi;
               GioiThieu = _GioiThieu;
          }

          public static int GetThongTinGiaoVien()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaTK", HTTaiKhoanGanDayMod.taiKhoanGanDay.MaTK));

               thongTinGiaoVien = DBContext.DBPTNContext.context.Database.SqlQuery<HTThongTinGiaoVienMod>("spGetGiaoVienByMaTK @MaTK", paralist.ToArray()).FirstOrDefault();
               return 1;
          }

          public int GetThongTinGiaoVien(string _MaGV)
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaGV", _MaGV));

               HTThongTinGiaoVienMod tmp = DBContext.DBPTNContext.context.Database.SqlQuery<HTThongTinGiaoVienMod>("spGetGiaoVienByMaGV @MaGV", paralist.ToArray()).FirstOrDefault();
               MaGV = _MaGV;
               HinhAnh = tmp.HinhAnh;
               HoTen = tmp.HoTen;
               GioiTinh = tmp.GioiTinh;
               SDT = tmp.SDT;
               NgaySinh = tmp.NgaySinh;
               Email = tmp.Email;
               DiaChi = tmp.DiaChi;
               GioiThieu = tmp.GioiThieu;
               return 1;
          }

          public int InsertGiaoVien()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaGV", MaGV));
               paralist.Add(new SqlParameter("@HinhAnh", HinhAnh));
               paralist.Add(new SqlParameter("@HoTen", HoTen));
               paralist.Add(new SqlParameter("@GioiTinh", GioiTinh));
               paralist.Add(new SqlParameter("@SDT", SDT));
               paralist.Add(new SqlParameter("@NgaySinh", NgaySinh));
               paralist.Add(new SqlParameter("@Email", Email));
               paralist.Add(new SqlParameter("@DiaChi", DiaChi));
               paralist.Add(new SqlParameter("@GioiThieu", GioiThieu));
               return DBContext.DBPTNContext.context.Database.ExecuteSqlCommand("spInsertGiaoVien @MaGV,@HinhAnh, @HoTen, @GioiTinh, @SDT, @NgaySinh, @Email, @DiaChi, @GioiThieu", paralist.ToArray());
          }

          public int UpdateGiaoVien()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaGV", MaGV));
               paralist.Add(new SqlParameter("@HinhAnh", HinhAnh));
               paralist.Add(new SqlParameter("@HoTen", HoTen));
               paralist.Add(new SqlParameter("@GioiTinh", GioiTinh));
               paralist.Add(new SqlParameter("@SDT", SDT));
               paralist.Add(new SqlParameter("@NgaySinh", NgaySinh));
               paralist.Add(new SqlParameter("@Email", Email));
               paralist.Add(new SqlParameter("@DiaChi", DiaChi));
               paralist.Add(new SqlParameter("@GioiThieu", GioiThieu));
               return DBContext.DBPTNContext.context.Database.ExecuteSqlCommand("spUpdateGiaoVien @MaGV, @HinhAnh, @HoTen, @GioiTinh, @SDT, @NgaySinh, @Email, @DiaChi, @GioiThieu", paralist.ToArray());
          }

          public int DeleteGiaoVien()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaGV", MaGV));
               return DBContext.DBPTNContext.context.Database.ExecuteSqlCommand("spDeleteGiaoVien @MaGV", paralist.ToArray());
          }
     }
}
