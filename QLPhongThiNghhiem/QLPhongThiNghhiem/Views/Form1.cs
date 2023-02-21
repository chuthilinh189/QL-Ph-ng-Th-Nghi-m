using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using QLPhongThiNghhiem.Models;
using QLPhongThiNghhiem.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QLPhongThiNghhiem
{
     public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
     {
          public FormMain()
          {
               InitializeComponent();
          }

          public void DongTabHienTai()
          {
               xtraTCHienThi.TabPages.Remove(xtraTCHienThi.SelectedTabPage);
          }

          public void DongTatCaTap()
          {
               while (xtraTCHienThi.TabPages.Count > 0)
                    DongTabHienTai();
          }


          private void đongTrangHiênTaiToolStripMenuItem_Click(object sender, EventArgs e)
          {
               DongTabHienTai();
          }

          private void đongTâtCaTrangToolStripMenuItem_Click(object sender, EventArgs e)
          {
               DongTatCaTap();
          }

          public void DangNhapThanhCong(bool e)
          {
               rbPQuanLy.Visible = e;
               rbPNghiepVu.Visible = e;
               rbPThongKe.Visible = e;
               bBIHTThongTinTaiKhoan.Enabled = e;
               bBItDoiMatKhau.Enabled = e;
               bBIHTXemQuyen.Enabled = e;
               bBIDangXuat.Enabled = e;
               bBItDangKy.Enabled = !e;
               bBItDangNhap.Enabled = !e;
               if (e == true) TenTaiKhoan.Caption = HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen + ": " + HTTaiKhoanGanDayMod.taiKhoanGanDay.HoTen;
               else TenTaiKhoan.Caption = "";
          }


          private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(XUCQLNhanVien.xUCQLNhanVien) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               XtraTabPage tab = new XtraTabPage();
               tab.Name = XUCQLNhanVien.xUCQLNhanVien.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Quản Lý Nhân Viên";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               XUCQLNhanVien.xUCQLNhanVien.Dock = DockStyle.Fill;
               tab.Controls.Add(XUCQLNhanVien.xUCQLNhanVien);
               XUCQLNhanVien.xUCQLNhanVien.Focus();
               XUCQLNhanVien.xUCQLNhanVien.LoadData();
          }

          private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(XUCQLGiaoVien.xUCQLGiaoVien) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               XtraTabPage tab = new XtraTabPage();
               tab.Name = XUCQLGiaoVien.xUCQLGiaoVien.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Quản Lý Giáo Viên";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               XUCQLGiaoVien.xUCQLGiaoVien.Dock = DockStyle.Fill;
               tab.Controls.Add(XUCQLGiaoVien.xUCQLGiaoVien);
               XUCQLGiaoVien.xUCQLGiaoVien.Focus();
               XUCQLGiaoVien.xUCQLGiaoVien.LoadData();
          }

          private void bBItDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(XUCHTDoiMatKhau.xUCHTDoiMatKhau) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               XtraTabPage tab = new XtraTabPage();
               tab.Name = XUCHTDoiMatKhau.xUCHTDoiMatKhau.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Đổi Mật Khẩu";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               XUCHTDoiMatKhau.xUCHTDoiMatKhau.Dock = DockStyle.Fill;
               tab.Controls.Add(XUCHTDoiMatKhau.xUCHTDoiMatKhau);
               XUCHTDoiMatKhau.xUCHTDoiMatKhau.Focus();
               XUCHTDoiMatKhau.xUCHTDoiMatKhau.LoadData();
          }

          private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               FormDangXuat frm = new FormDangXuat();
               DialogResult dangXuat = frm.ShowDialog();
               if(dangXuat == DialogResult.Yes)
               {
                    this.DongTatCaTap();
                    this.DangNhapThanhCong(false);
               }
               this.Enabled = true;
          }

          private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(XUCHTThongTinTaiKhoan.xUCHTThongTinTaiKhoan) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               XtraTabPage tab = new XtraTabPage();
               tab.Name = XUCHTThongTinTaiKhoan.xUCHTThongTinTaiKhoan.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Thông Tin Tài Khoản";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               XUCHTThongTinTaiKhoan.xUCHTThongTinTaiKhoan.Dock = DockStyle.Fill;
               tab.Controls.Add(XUCHTThongTinTaiKhoan.xUCHTThongTinTaiKhoan);
               XUCHTThongTinTaiKhoan.xUCHTThongTinTaiKhoan.Focus();
               XUCHTThongTinTaiKhoan.xUCHTThongTinTaiKhoan.LoadThongTin();
          }


          private void bBItHeThongPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(Views.XUCNVHeThongPhong.xUCNVHeThongPhong) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               Views.XUCNVHeThongPhong.xUCNVHeThongPhong = new XUCNVHeThongPhong();
               XtraTabPage tab = new XtraTabPage();
               tab.Name = Views.XUCNVHeThongPhong.xUCNVHeThongPhong.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Hệ Thống Phòng Thí Nghiệm";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               Views.XUCNVHeThongPhong.xUCNVHeThongPhong.Dock = DockStyle.Fill;
               tab.Controls.Add(Views.XUCNVHeThongPhong.xUCNVHeThongPhong);
               Views.XUCNVHeThongPhong.xUCNVHeThongPhong.Focus();
               Views.XUCNVHeThongPhong.xUCNVHeThongPhong.LoadData();
          }

          private void bBItHeThongTrangBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               //ThemTapPages(Views.XUCNVHeThongTrangBi.xUCNVHeThongTrangBi, 0, "Hệ Thống Trang Thiết Bị");
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(XUCNVHeThongTrangBi.xUCNVHeThongTrangBi) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               XtraTabPage tab = new XtraTabPage();
               tab.Name = XUCNVHeThongTrangBi.xUCNVHeThongTrangBi.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Hệ Thống Trang Thiết Bị";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               XUCNVHeThongTrangBi.xUCNVHeThongTrangBi.Dock = DockStyle.Fill;
               tab.Controls.Add(XUCNVHeThongTrangBi.xUCNVHeThongTrangBi);
               XUCNVHeThongTrangBi.xUCNVHeThongTrangBi.Focus();
               XUCNVHeThongTrangBi.xUCNVHeThongTrangBi.LoadData();
          }

          private void bBItBaiThiNghiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               //ThemTapPages(Views.XUCNVBaiThiNghiem.xUCNVBaiThiNghiem, 0, "Bài Thí Nghiệm");
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(XUCNVBaiThiNghiem.xUCNVBaiThiNghiem) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               XtraTabPage tab = new XtraTabPage();
               tab.Name = XUCNVBaiThiNghiem.xUCNVBaiThiNghiem.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Bài Thí Nghiệm";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               XUCNVBaiThiNghiem.xUCNVBaiThiNghiem.Dock = DockStyle.Fill;
               tab.Controls.Add(XUCNVBaiThiNghiem.xUCNVBaiThiNghiem);
               XUCNVBaiThiNghiem.xUCNVBaiThiNghiem.Focus();
               XUCNVBaiThiNghiem.xUCNVBaiThiNghiem.LoadData();
          }

          private void bBItDangKySuDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               //ThemTapPages(Views.XUCNVDangKySuDung.xUCNVDangKySuDung, 0, "Đăng Ký Sử Dụng");
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(XUCNVDangKySuDung.xUCNVDangKySuDung) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               XtraTabPage tab = new XtraTabPage();
               tab.Name = XUCNVDangKySuDung.xUCNVDangKySuDung.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Đăng Ký Sử Dụng";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               XUCNVDangKySuDung.xUCNVDangKySuDung.Dock = DockStyle.Fill;
               tab.Controls.Add(XUCNVDangKySuDung.xUCNVDangKySuDung);
               XUCNVDangKySuDung.xUCNVDangKySuDung.Focus();
               XUCNVDangKySuDung.xUCNVDangKySuDung.LoadData();
          }

          private void bBItHoatDongSuDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               //ThemTapPages(Views.XUCNVHoatDongSuDung.xUCNVHoatDongSuDung, 0, "Ca Thí Nghiệm");
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(XUCNVHoatDongSuDung.xUCNVHoatDongSuDung) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               XtraTabPage tab = new XtraTabPage();
               tab.Name = XUCNVHoatDongSuDung.xUCNVHoatDongSuDung.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Ca Thí Nghiệm";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               XUCNVHoatDongSuDung.xUCNVHoatDongSuDung.Dock = DockStyle.Fill;
               tab.Controls.Add(XUCNVHoatDongSuDung.xUCNVHoatDongSuDung);
               XUCNVHoatDongSuDung.xUCNVHoatDongSuDung.Focus();
               XUCNVHoatDongSuDung.xUCNVHoatDongSuDung.LoadData();
          }

          private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               bBItDangNhap.Enabled = false;
               //ThemTapPages(Views.XUCDangKy.xUCDangKy, 0, "Đăng Ký");
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(Views.XUCDangKy.xUCDangKy) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               XtraTabPage tab = new XtraTabPage();
               tab.Name = Views.XUCDangKy.xUCDangKy.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Đăng Ký";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               Views.XUCDangKy.xUCDangKy.Dock = DockStyle.Fill;
               Views.XUCDangKy.xUCDangKy.chuyenDangNhap += new DevExpress.XtraBars.ItemClickEventHandler(chuyenDangNhap);
               tab.Controls.Add(Views.XUCDangKy.xUCDangKy);
               Views.XUCDangKy.xUCDangKy.Focus();
          }

          public void chuyenDangNhap(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               DongTatCaTap();
               bBItDangNhap.Enabled = true;
               this.barButtonItem1_ItemClick(sender, e);
          }

          private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               bBItDangKy.Enabled = false;
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(XUCDangNhap.xUCDangNhap) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               XtraTabPage tab = new XtraTabPage();
               tab.Name = XUCDangNhap.xUCDangNhap.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Đăng Nhập";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               XUCDangNhap.xUCDangNhap.Dock = DockStyle.Fill;
               XUCDangNhap.xUCDangNhap.ChuyenDangKy += new DevExpress.XtraBars.ItemClickEventHandler(chuyenDangKy);
               XUCDangNhap.xUCDangNhap.DangNhapThanhCong += new DevExpress.XtraBars.ItemClickEventHandler(dangNhapThanhCong);
               tab.Controls.Add(XUCDangNhap.xUCDangNhap);
               XUCDangNhap.xUCDangNhap.Focus();
               XUCDangNhap.xUCDangNhap.LoadData();
          } 

          public void dangNhapThanhCong(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               DongTatCaTap();
               DangNhapThanhCong(true);
               this.barButtonItem9_ItemClick(sender, e);
          }

          public void chuyenDangKy(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               DongTatCaTap();
               bBItDangKy.Enabled = true;
               this.barButtonItem2_ItemClick(sender, e);
          }
          private void bBItPhongThiNghiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               //ThemTapPages(Views.XUCTKPhongThiNghiem.xUCTKPhongThiNghiem, 0, "Thống Kê Theo Phòng");
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(XUCTKPhongThiNghiem.xUCTKPhongThiNghiem) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               XtraTabPage tab = new XtraTabPage();
               tab.Name = XUCTKPhongThiNghiem.xUCTKPhongThiNghiem.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Thống Kê Theo Phòng";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               XUCTKPhongThiNghiem.xUCTKPhongThiNghiem.Dock = DockStyle.Fill;
               tab.Controls.Add(XUCTKPhongThiNghiem.xUCTKPhongThiNghiem);
               XUCTKPhongThiNghiem.xUCTKPhongThiNghiem.Focus();
          }

          private void bBItTKLoatTrangBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               //ThemTapPages(Views.XUCTKLoaiTrangThietBi.xUCTKLoaiTrangThietBi, 0, "Thống Kê Theo Loại TTB");
               for (int i = 0; i < xtraTCHienThi.TabPages.Count; i++)
               {
                    if (xtraTCHienThi.TabPages[i].Contains(XUCTKLoaiTrangThietBi.xUCTKLoaiTrangThietBi) == true)
                    {
                         xtraTCHienThi.SelectedTabPage = xtraTCHienThi.TabPages[i];
                         return;
                    }
               }
               XtraTabPage tab = new XtraTabPage();
               tab.Name = XUCTKLoaiTrangThietBi.xUCTKLoaiTrangThietBi.Name;
               tab.Size = xtraTCHienThi.Size;
               tab.Text = "Thống Kê Theo Loại TTB";
               xtraTCHienThi.TabPages.Add(tab);
               xtraTCHienThi.SelectedTabPage = tab;
               XUCTKLoaiTrangThietBi.xUCTKLoaiTrangThietBi.Dock = DockStyle.Fill;
               tab.Controls.Add(XUCTKLoaiTrangThietBi.xUCTKLoaiTrangThietBi);
               XUCTKLoaiTrangThietBi.xUCTKLoaiTrangThietBi.Focus();
          }

          private void FormMain_Load(object sender, EventArgs e)
          {
               DangNhapThanhCong(false);
          }
     }
}
