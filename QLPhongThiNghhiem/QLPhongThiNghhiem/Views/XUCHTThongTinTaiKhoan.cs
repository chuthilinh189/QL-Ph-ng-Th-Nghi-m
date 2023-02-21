using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Policy;
using QLPhongThiNghhiem.Models;

namespace QLPhongThiNghhiem.Views
{
     public partial class XUCHTThongTinTaiKhoan : DevExpress.XtraEditors.XtraUserControl
     {
          public XUCHTThongTinTaiKhoan()
          {
               InitializeComponent();
          }

          public static XUCHTThongTinTaiKhoan xUCHTThongTinTaiKhoan = new XUCHTThongTinTaiKhoan();

          private void XUCHTThongTinTaiKhoan_Load(object sender, EventArgs e)
          {
               LoadThongTin();
          }

          public void LoadThongTin()
          {
               if (HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "Giáo viên")
               {
                    lbChucVu.Text = "Giáo viên";
                    lbID.Text = "Mã giáo viên";
                    tBMaNhanVien.Text = HTThongTinGiaoVienMod.thongTinGiaoVien.MaGV;
                    tBHoTen.Text = HTThongTinGiaoVienMod.thongTinGiaoVien.HoTen;
                    cbGioiTinh.Text = HTThongTinGiaoVienMod.thongTinGiaoVien.GioiTinh;
                    tBSoDienThoai.Text = HTThongTinGiaoVienMod.thongTinGiaoVien.SDT;
                    dtNgaySinh.Value = (DateTime)HTThongTinGiaoVienMod.thongTinGiaoVien.NgaySinh;
                    tBEmail.Text = HTThongTinGiaoVienMod.thongTinGiaoVien.Email;
                    tBDiaChi.Text = HTThongTinGiaoVienMod.thongTinGiaoVien.DiaChi;
                    tBGioiThieu.Text = HTThongTinGiaoVienMod.thongTinGiaoVien.GioiThieu;
                    pBHinhAnh.Image = Resources.Funtion.convertBytesToImage(HTThongTinGiaoVienMod.thongTinGiaoVien.HinhAnh);
               }
               else
               {
                    lbChucVu.Text = HTThongTinTaiKhoanMod.thongTinNhanVien.ChucVu;
                    lbID.Text = "Mã nhân viên";
                    tBMaNhanVien.Text = HTThongTinTaiKhoanMod.thongTinNhanVien.MaNV;
                    tBHoTen.Text = HTThongTinTaiKhoanMod.thongTinNhanVien.HoTen;
                    cbGioiTinh.Text = HTThongTinTaiKhoanMod.thongTinNhanVien.GioiTinh;
                    tBSoDienThoai.Text = HTThongTinTaiKhoanMod.thongTinNhanVien.SDT;
                    dtNgaySinh.Value = (DateTime)HTThongTinTaiKhoanMod.thongTinNhanVien.NgaySinh;
                    tBEmail.Text = HTThongTinTaiKhoanMod.thongTinNhanVien.Email;
                    tBDiaChi.Text = HTThongTinTaiKhoanMod.thongTinNhanVien.DiaChi;
                    tBGioiThieu.Text = HTThongTinTaiKhoanMod.thongTinNhanVien.GioiThieu;
                    pBHinhAnh.Image = Resources.Funtion.convertBytesToImage(HTThongTinTaiKhoanMod.thongTinNhanVien.HinhAnh);
               }
          }

          private void lLAnhDaiDien_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               OpenFileDialog open = new OpenFileDialog();
               open.Filter = "JPG files (*.ipg) |*.jpg|All files (*.*)|*.*";
               open.FilterIndex = 1;
               open.RestoreDirectory = true;
               if (open.ShowDialog() == DialogResult.OK)
               {
                    pBHinhAnh.ImageLocation = open.FileName;
               }
               Luu();
          }

          private void lLXoaAnh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               DialogResult dr = MessageBox.Show("Có chắc chắn xóa ảnh?", "Xóa ảnh", MessageBoxButtons.YesNo);
               if(dr == DialogResult.Yes)
               {
                    pBHinhAnh.Image = null;
               }
               Luu();
          }

          private void lLChinhSuaHoTen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaHoTen.Visible = false;
               tBHoTen.Enabled = true;
               tBHoTen.Focus();
               lLLuuHoTen.Visible = true;
          }

          private void lLChinhSuaGioiTinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaGioiTinh.Visible = false;
               cbGioiTinh.Enabled = true;
               cbGioiTinh.Focus();
               lLLuuGioiTinh.Visible = true;
          }

          private void lLChinhSuaSoDienThoai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaSoDienThoai.Visible = false;
               tBSoDienThoai.Enabled = true;
               tBSoDienThoai.Focus();
               lLLuuSDT.Visible = true;
          }

          private void lLChinhSuaNgaySinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaNgaySinh.Visible = false;
               dtNgaySinh.Enabled = true;
               dtNgaySinh.Focus();
               lLLuuNgaySinh.Visible = true;
          }

          private void lLChinhSuaEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaEmail.Visible = false;
               tBEmail.Enabled = true;
               tBEmail.Focus();
               lLLuuEmail.Visible = true;
          }

          private void lLChinhSuaDiaChi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaDiaChi.Visible = false;
               tBDiaChi.Enabled = true;
               tBDiaChi.Focus();
               lLLuuDiaChi.Visible = true;
          }

          private void lLChinhSuaGioiThieu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaGioiThieu.Visible = false;
               tBGioiThieu.Enabled = true;
               tBGioiThieu.Focus();
               lLLuuGioiThieu.Visible = true;
          }

          public int Luu()
          {
               Image _HinhAnh = null;
               try { _HinhAnh = pBHinhAnh.Image; }
               catch { }
               string _MaNV = "";
               try { _MaNV = tBMaNhanVien.Text; }
               catch { }
               string _ChucVu = "";
               try { _ChucVu = lbChucVu.Text; }
               catch { }
               string _HoTen = "";
               try { _HoTen = tBHoTen.Text; }
               catch { }
               string _GioiTinh = "";
               try { _GioiTinh = cbGioiTinh.Text; }
               catch { }
               string _SDT = "";
               try { _SDT = tBSoDienThoai.Text; }
               catch { }
               DateTime _NgaySinh = DateTime.Today;
               try
               {
                    if (dtNgaySinh.Text == "")
                    {
                         MessageBox.Show("Nhập đúng ngày!", "Thông báo", MessageBoxButtons.OK);
                         return 0;
                    }
                    _NgaySinh = dtNgaySinh.Value;
               }
               catch
               {

               }
               string _Email = "";
               try { _Email = tBEmail.Text; }
               catch { }
               string _DiaChi = "";
               try { _DiaChi = tBDiaChi.Text; }
               catch { }
               string _GioiThieu = "";
               try { _GioiThieu = tBGioiThieu.Text; }
               catch { }
               
               if (tBHoTen.Text == "")
               {
                    MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                    return 0;
               }
               else if(HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "Giáo viên")
               {
                    int i = Controllers.HTThongTinGiaoVienCtrl.UpdateGiaoVien(_MaNV, _HinhAnh, _HoTen, _GioiTinh, _SDT, _NgaySinh, _Email, _DiaChi, _GioiThieu);
                    if (i == 1)
                    {
                         MessageBox.Show("Chỉnh sửa thành công", "Thông báo");
                         HTThongTinGiaoVienMod.GetThongTinGiaoVien();
                         return 1;
                    }
                    else
                    {
                         MessageBox.Show("Chỉnh sửa thất bại", "Thông báo");
                         LoadThongTin();
                         return 0;
                    }
               }
               else
               {
                    int i = Controllers.HTThongTinTaiKhoanCtrl.UpdateNhanVien(_MaNV, _ChucVu, _HinhAnh, _HoTen, _GioiTinh, _SDT, _NgaySinh, _Email, _DiaChi, _GioiThieu);
                    if (i == 1)
                    {
                         MessageBox.Show("Chỉnh sửa thành công", "Thông báo");
                         HTThongTinTaiKhoanMod.GetThongTinNhanVien();
                         return 1;
                    }
                    else
                    {
                         MessageBox.Show("Chỉnh sửa thất bại", "Thông báo");
                         LoadThongTin();
                         return 0;
                    }
               }
          }

          private void lLLuuHoTen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaHoTen.Visible = true;
               tBHoTen.Enabled = false;
               lLLuuHoTen.Visible = false;
               Luu();
          }

          private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaGioiTinh.Visible = true;
               cbGioiTinh.Enabled = false;
               lLLuuGioiTinh.Visible = false;
               Luu();
          }

          private void lBLuuSDT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaSoDienThoai.Visible = true;
               tBSoDienThoai.Enabled = false;
               lLLuuSDT.Visible = false;
               Luu();
          }

          private void lLLuuNgaySinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaNgaySinh.Visible = true;
               dtNgaySinh.Enabled = false;
               lLLuuNgaySinh.Visible = false;
               Luu();
          }

          private void lLLuuEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaEmail.Visible = true;
               tBEmail.Enabled = false;
               lLLuuEmail.Visible = false;
               Luu();
          }

          private void lLLuuDiaChi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               lLChinhSuaDiaChi.Visible = true;
               tBDiaChi.Enabled = false;
               lLLuuDiaChi.Visible = false;
               Luu();
          }

          private void lLLuuGioiThieu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {

               lLChinhSuaGioiThieu.Visible = true;
               tBGioiThieu.Enabled = false;
               lLLuuGioiThieu.Visible = false;
               Luu();
          }
     }
}
