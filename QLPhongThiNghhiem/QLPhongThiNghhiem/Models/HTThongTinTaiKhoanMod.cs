using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongThiNghhiem.Models
{
     class HTThongTinTaiKhoanMod
     {
          public byte[] HinhAnh { get; set; }
          public string MaNV { get; set; }
          public string HoTen { get; set; }
          public string ChucVu { get; set; }
          public string GioiTinh { get; set; }
          public string SDT { get; set; }
          public DateTime NgaySinh { get; set; }
          public string Email { get; set; }
          public string DiaChi { get; set; }
          public string GioiThieu { get; set; }

          public static HTThongTinTaiKhoanMod thongTinNhanVien;
          public HTThongTinTaiKhoanMod() { }

          public HTThongTinTaiKhoanMod(string _MaNV)
          {
               MaNV = _MaNV;
          }


          public HTThongTinTaiKhoanMod(string _MaNV, string _ChucVu, byte[] _HinhAnh, string _HoTen, string _GioiTinh, string _SDT, DateTime _NgaySinh, string _Email, string _DiaChi, string _GioiThieu)
          {
               MaNV = _MaNV;
               ChucVu = _ChucVu;
               HinhAnh = _HinhAnh;
               HoTen = _HoTen;
               GioiTinh = _GioiTinh;
               SDT = _SDT;
               NgaySinh = _NgaySinh;
               Email = _Email;
               DiaChi = _DiaChi;
               GioiThieu = _GioiThieu;
          }

          public static int GetThongTinNhanVien()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaTK", HTTaiKhoanGanDayMod.taiKhoanGanDay.MaTK));

               thongTinNhanVien = DBContext.DBPTNContext.context.Database.SqlQuery<HTThongTinTaiKhoanMod>("spGetNhanVienByMaTK @MaTK", paralist.ToArray()).FirstOrDefault();
               return 1;
          }

          public int GetThongTinTaiKhoan(string _MaNV)
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaNV", _MaNV));
               
               HTThongTinTaiKhoanMod tmp = DBContext.DBPTNContext.context.Database.SqlQuery<HTThongTinTaiKhoanMod>("spGetNhanVienByMaNV @MaNV", paralist.ToArray()).FirstOrDefault();
               MaNV = _MaNV;
               HinhAnh = tmp.HinhAnh;
               MaNV = tmp.MaNV;
               HoTen = tmp.HoTen;
               ChucVu = tmp.ChucVu;
               GioiTinh = tmp.GioiTinh;
               SDT = tmp.SDT;
               NgaySinh = tmp.NgaySinh;
               Email = tmp.Email;
               DiaChi = tmp.DiaChi;
               GioiThieu = tmp.GioiThieu;
               return 1;     
          }

          public int InsertNhanVien()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaNV", MaNV));
               paralist.Add(new SqlParameter("@ChucVu", ChucVu));
               paralist.Add(new SqlParameter("@HinhAnh", HinhAnh));
               paralist.Add(new SqlParameter("@HoTen", HoTen));
               paralist.Add(new SqlParameter("@GioiTinh", GioiTinh));
               paralist.Add(new SqlParameter("@SDT", SDT));
               paralist.Add(new SqlParameter("@NgaySinh", NgaySinh));
               paralist.Add(new SqlParameter("@Email", Email));
               paralist.Add(new SqlParameter("@DiaChi", DiaChi));
               paralist.Add(new SqlParameter("@GioiThieu", GioiThieu));
               return DBContext.DBPTNContext.context.Database.ExecuteSqlCommand("spInsertNhanVien @MaNV, @ChucVu, @HinhAnh, @HoTen, @GioiTinh, @SDT, @NgaySinh, @Email, @DiaChi, @GioiThieu", paralist.ToArray());
          }

          public int UpdateNhanVien()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaNV", MaNV));
               paralist.Add(new SqlParameter("@ChucVu", ChucVu));
               paralist.Add(new SqlParameter("@HinhAnh", HinhAnh));
               paralist.Add(new SqlParameter("@HoTen", HoTen));
               paralist.Add(new SqlParameter("@GioiTinh", GioiTinh));
               paralist.Add(new SqlParameter("@SDT", SDT));
               paralist.Add(new SqlParameter("@NgaySinh", NgaySinh));
               paralist.Add(new SqlParameter("@Email", Email));
               paralist.Add(new SqlParameter("@DiaChi", DiaChi));
               paralist.Add(new SqlParameter("@GioiThieu", GioiThieu));
               return DBContext.DBPTNContext.context.Database.ExecuteSqlCommand("spUpdateNhanVien @MaNV, @ChucVu, @HinhAnh, @HoTen, @GioiTinh, @SDT, @NgaySinh, @Email, @DiaChi, @GioiThieu", paralist.ToArray());
          }

          public int DeleteNhanVien()
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaNV", MaNV));
               return DBContext.DBPTNContext.context.Database.ExecuteSqlCommand("spDeleteNhanVien @MaNV", paralist.ToArray());
          }
     }
}
