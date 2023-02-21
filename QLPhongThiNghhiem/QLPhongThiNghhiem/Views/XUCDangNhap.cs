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
using QLPhongThiNghhiem.Controllers;
using QLPhongThiNghhiem.Models;

namespace QLPhongThiNghhiem.Views
{
     public partial class XUCDangNhap : DevExpress.XtraEditors.XtraUserControl
     {
          public XUCDangNhap()
          {
               InitializeComponent();
          }

          public static XUCDangNhap xUCDangNhap = new XUCDangNhap();
          
          public event DevExpress.XtraBars.ItemClickEventHandler DangNhapThanhCong;
          public event DevExpress.XtraBars.ItemClickEventHandler ChuyenDangKy;

          private void XUCDangNhap_Load(object sender, EventArgs e)
          {
               LoadData();
          }

          public void LoadData()
          {
               xUCDangNhap = new XUCDangNhap();
               HTTaiKhoanGanDayMod.GetThongTinTaiKhoan();
               if (HTTaiKhoanGanDayMod.taiKhoanGanDay == null)
               {
                    panel1.Visible = false;
                    panel2.Location = panel1.Location;
                    separatorControl3.Visible = false;
               }
               else
               {
                    lbHoTen.Text = HTTaiKhoanGanDayMod.taiKhoanGanDay.HoTen;
                    lbTenDN.Text = HTTaiKhoanGanDayMod.taiKhoanGanDay.TenDN;
                    lbHoTen3.Text = HTTaiKhoanGanDayMod.taiKhoanGanDay.HoTen;
                    lbTenDN3.Text = HTTaiKhoanGanDayMod.taiKhoanGanDay.TenDN;
                    pBHinhAnh.Image = Resources.Funtion.convertBytesToImage(HTTaiKhoanGanDayMod.taiKhoanGanDay.HinhAnh);
               }
          }

          private void panel1_Click(object sender, EventArgs e)
          {
               pnChonTaiKhoan.Visible = false;
               pnDangNhapVoi.Location = pnChonTaiKhoan.Location;
               pnDangNhapVoi.Visible = true;
          }

          private void panel2_Click(object sender, EventArgs e)
          {
               pnChonTaiKhoan.Visible = false;
               pnDangNhap.Location = pnChonTaiKhoan.Location;
               pnDangNhap.Visible = true;
          }

          private void hlLCDangKy_Click(object sender, EventArgs e)
          {
               this.ChuyenDangKy(sender, null);
          }

          private void lLBKhognPhaiBan_Click(object sender, EventArgs e)
          {
               pnChonTaiKhoan.Visible = true;
               pnDangNhapVoi.Visible = false;
          }

          private void panelControl4_Click(object sender, EventArgs e)
          {
               tEMatKhauHienTai_GotFocus(sender, e);
          }

          private void pnTenDN2_Click(object sender, EventArgs e)
          {
               this.tbTenDN2_GotFocus(sender, e);
          }

          private void pnNhapMk2_Click(object sender, EventArgs e)
          {
               tbNhapMK2_GotFocus(sender, e);
          }

          private void tbTenDN2_GotFocus(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbTenDN2);
               Resources.Funtion.chon(pnTenDN2);
          }

          private void tbTenDN2_LostFocus(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbTenDN2);
               Resources.Funtion.khongChon(pnTenDN2);
          }

          private void tbNhapMK2_GotFocus(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbNhapMk2);
               Resources.Funtion.chon(pnNhapMk2);
          }

          private void tbNhapMK2_LostFocus(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbNhapMk2);
               Resources.Funtion.khongChon(pnNhapMk2);
          }

          private void tEMatKhauHienTai_GotFocus(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbNhapMK3);
               Resources.Funtion.chon(pnNhapMK3);
          }

          private void tEMatKhauHienTai_LostFocus(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbNhapMK3);
               Resources.Funtion.khongChon(pnNhapMK3);
          }

     private void bDangNhap2_Click(object sender, EventArgs e)
          {
               int result  = HTTaiKhoanGanDayMod.KiemTraDangNhap(tbTenDN2.Text, tbNhapMK2.Text);
               if(result == 0)
               {
                    lbDangNhapThatBai.Visible = true;
                    tbTenDN2.Focus();
               }
               else
               {
                    if (HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "Giáo viên")
                    {
                         HTThongTinGiaoVienMod.GetThongTinGiaoVien();
                    }
                    else
                    {
                         HTThongTinTaiKhoanMod.GetThongTinNhanVien();
                    }
                    MessageBox.Show("Đăng nhập thành công");
                    this.DangNhapThanhCong(sender, null);
               }
          }

          private void bDangNhap3_Click(object sender, EventArgs e)
          {
               int result = HTTaiKhoanGanDayMod.KiemTraDangNhap(lbTenDN3.Text, tEMatKhauHienTai.Text);
               if (result == 0)
               {
                    lbMatKhauSai.Visible = true;
                    tbTenDN2.Focus();
               }
               else
               {
                    if (HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "Giáo viên")
                    {
                         HTThongTinGiaoVienMod.GetThongTinGiaoVien();
                    }
                    else
                    {
                         HTThongTinTaiKhoanMod.GetThongTinNhanVien();
                    }
                    MessageBox.Show("Đăng nhập thành công");
                    this.DangNhapThanhCong(sender, null);
               }
          }

        private void btBack_Click(object sender, EventArgs e)
        {
               pnDangNhap.Visible = false;
               pnChonTaiKhoan.Location = pnChonTaiKhoan.Location;
               pnChonTaiKhoan.Visible = true;
          }
    }
}
