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
using DevExpress.XtraBars;
using DevExpress.Xpo;
using QLPhongThiNghhiem.Models;
using System.Data.SqlClient;

namespace QLPhongThiNghhiem.Views
{
     public partial class XUCNVDangKySuDung : DevExpress.XtraEditors.XtraUserControl
     {
          public XUCNVDangKySuDung()
          {
               InitializeComponent();
          }

          public static XUCNVDangKySuDung xUCNVDangKySuDung = new XUCNVDangKySuDung();

          private DBContext.DBPTNContext context = new DBContext.DBPTNContext();
          bool chonBDK = true;

          public void loadcbMaBDK(string Quyen)
          {
               cBEMaBDK.Properties.Items.Clear();
               if (Quyen == "Giáo viên")
               {
                    List<SqlParameter> paralist = new List<SqlParameter>();
                    paralist.Add(new SqlParameter("@HoTenGV", HTTaiKhoanGanDayMod.taiKhoanGanDay.HoTen));
                    List<string> listMaDangKy = context.Database.SqlQuery<string>("spLoadMaDangKyByMaGV @HoTenGV", paralist.ToArray()).ToList<string>();
                    foreach (string MaDangKy in listMaDangKy)
                    {
                         cBEMaBDK.Properties.Items.Add(MaDangKy);
                    }                    
               }
               else
               {
                    List<string> listMaDangKy = context.Database.SqlQuery<string>("spLoadMaDangKy").ToList<string>();
                    foreach (string MaDangKy in listMaDangKy)
                    {
                         cBEMaBDK.Properties.Items.Add(MaDangKy);
                    }
               }
               
          }

          public void loadbdNhanVien()
          {
               tbNhanVien2.Properties.Items.Clear();
               List<string> listNV = context.Database.SqlQuery<string>("SELECT HoTen From NhanVien").ToList<string>();
               foreach (string NV in listNV)
               {
                    tbNhanVien2.Properties.Items.Add(NV);
               }
          }
          public void loadcbTenPhong()
          {
               cBEPhong.Properties.Items.Clear();
               List<string> listTenPhong = context.Database.SqlQuery<string>("spLoadTenPhong").ToList<string>();
               foreach (string tenPhong in listTenPhong)
               {
                    cBEPhong.Properties.Items.Add(tenPhong);
               }
          }

          public void loadcbTenBTN()
          {
               cbTenBTN.Properties.Items.Clear();
               List<string> listTenBTN = context.Database.SqlQuery<string>("spLoadTenBTN").ToList<string>();
               foreach (string tenBTN in listTenBTN)
               {
                    cbTenBTN.Properties.Items.Add(tenBTN);
               }
          }

          public void phanQuyen()
          {
               bool quyenGiaoVien = false;
               if (HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "Giáo viên") quyenGiaoVien = true;
               bThemBDK.Visible = quyenGiaoVien;
               bSuaBDK.Visible = quyenGiaoVien;
               bXoaBDK.Visible = quyenGiaoVien;
               bLuuBDK.Visible = quyenGiaoVien;
               bHuyBDK.Visible = quyenGiaoVien;
               if (!quyenGiaoVien)
               {
                    panel1.Size = new Size(548, 48 + 17);
                    panel2.Size = new Size(548, 249 - 17);
               }
               else
               {
                    panel1.Size = new Size(548, 48);
                    panel2.Size = new Size(548, 249);
               }
          }

          public void LoadData()
          {
               phanQuyen();
               BanDangKy_Load();
               loadcbMaBDK(HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen);
               loadcbTenPhong();
               loadcbTenBTN();
               loadbdNhanVien();
          }

          //
          // Panel Bản Đăng Ký
          //

          int flagThemBDK = 0;

          public void dis_enableBDK(bool e) //e = true: ko them, sua. e = false = them, sua 
          {
               bThemBDK.Enabled = e;
               bSuaBDK.Enabled = e;
               bXoaBDK.Enabled = e;
               bLuuBDK.Enabled = !e;
               bHuyBDK.Enabled = !e;
               tBLop.Enabled = !e;
               tBQuanSo.Enabled = !e;
               tbNamHoc.Enabled = !e;
               cBEHocKy.Enabled = !e;
               if (HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "Giáo viên")
               {
                    if (HTTaiKhoanGanDayMod.taiKhoanGanDay.HoTen != tBTenGiaoVien.Text)
                    {
                         bSuaBDK.Enabled = false;
                         bXoaBDK.Enabled = false;
                    }
               }
          }

          public void getBanDangKy()
          {
               dGVBanDangKy.DataSource = Models.NVBanDangKyMod.getBanDangKy();
               dGVBanDangKy.Dock = DockStyle.Fill;
          }

          public void getBanDangKyByKey(string Key)
          {
               dGVBanDangKy.DataSource = Models.NVBanDangKyMod.getBanDangKyByKey(Key);
               dGVBanDangKy.Dock = DockStyle.Fill;
          }

          public void getThongTinBanDangKy()
          {
               tBMaDK.DataBindings.Clear();
               tBMaDK.DataBindings.Add("Text", dGVBanDangKy.DataSource, "MaDangKy");
               tBTenGiaoVien.DataBindings.Clear();
               tBTenGiaoVien.DataBindings.Add("Text", dGVBanDangKy.DataSource, "HoTen");
               tBLop.DataBindings.Clear();
               tBLop.DataBindings.Add("Text", dGVBanDangKy.DataSource, "Lop");
               tbNamHoc.DataBindings.Clear();
               tbNamHoc.DataBindings.Add("Text", dGVBanDangKy.DataSource, "NamHoc");
               cBEHocKy.DataBindings.Clear();
               cBEHocKy.DataBindings.Add("Text", dGVBanDangKy.DataSource, "HocKy");
               tBQuanSo.DataBindings.Clear();
               tBQuanSo.DataBindings.Add("Text", dGVBanDangKy.DataSource, "QuanSo");
          }

          private void BanDangKy_Load()
          {
               getBanDangKy();
               getThongTinBanDangKy();
               dis_enableBDK(true);
               ChiTietDangKy_Load();
          }

          private void dGVBanDangKy_CellClick(object sender, DataGridViewCellEventArgs e)
          {
               getThongTinBanDangKy();
               flagThemBDK = 0;
               dis_enableBDK(true);
               ChiTietDangKy_Load();
          }

          private void tBTenGiaoVien_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbTenGiaoVien, pnTenGiaoVien);
          }

          private void tBTenGiaoVien_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbTenGiaoVien, pnTenGiaoVien);
          }

          private void tBLop_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbTenLop, pnTenLop);
          }

          private void tBLop_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbTenLop, pnTenLop);
          }

          private void tBQuanSo_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbQuanSo, pnQuanSo);
          }

          private void tBQuanSo_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbQuanSo, pnQuanSo);
          }

          private void cBEHocKy_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbHocKy, pnHocKy);
          }

          private void cBEHocKy_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbHocKy, pnHocKy);
          }

          private void tbNamHoc_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbNamHoc, pnNamHoc);
          }

          private void tbNamHoc_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbNamHoc, pnNamHoc);
          }

          private void bThemBDK_Click(object sender, EventArgs e)
          {
               tBMaDK.Text = context.Database.SqlQuery<string>("spGetMaBanDangKy").FirstOrDefault();
               tBTenGiaoVien.Text = HTTaiKhoanGanDayMod.taiKhoanGanDay.HoTen;
               flagThemBDK = 1;
               dis_enableBDK(false);
               tBLop.Text = "";
               tBQuanSo.Text = "";
               tbNamHoc.Text = "";
          }

          private void bSuaBDK_Click(object sender, EventArgs e)
          {
               flagThemBDK = 0;
               dis_enableBDK(false);

          }

          private void bXoaBDK_Click(object sender, EventArgs e)
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaDangKy", tBMaDK.Text));
               int LuotDK = context.Database.SqlQuery<int>("spCountChiTietCuaBDK @MaDangKy", paralist.ToArray()).FirstOrDefault();
               if (LuotDK > 0)
               {
                    MessageBox.Show("Bản đăng ký này đã có Chi tiết đăng ký.\nKhông thể xóa!", "Thông báo", MessageBoxButtons.OK);
                    return;
               }

               DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (dr == DialogResult.Yes)
               {
                    int i = Controllers.NVBanDangKyCtrl.DeteleBanDangKy(tBMaDK.Text);
                    if (i == 1)
                    {
                         MessageBox.Show("Xóa thành công!", "Thông báo");
                         loadcbMaBDK(HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen);
                         ChiTietDangKy_Load();
                    }
                    else MessageBox.Show("Xóa không thành công.");

               }
               else
                    return;
          }

          private void bLuuBDK_Click(object sender, EventArgs e)
          {
               string _MaDangKy = "";
               try { _MaDangKy = tBMaDK.Text; }
               catch { }
               string _HoTen = "";
               try { _HoTen = tBTenGiaoVien.Text; }
               catch { }
               string _Lop = "";
               try { _Lop = tBLop.Text; }
               catch { }
               int _QuanSo = 0;
               try { int.TryParse(tBQuanSo.Text, out _QuanSo); }
               catch { }
               int _HocKy = 1;
               try { int.TryParse(cBEHocKy.Text, out _HocKy); }
               catch { }
               string _NamHoc = "";
               try { _NamHoc = tbNamHoc.Text; }
               catch { }
               if (flagThemBDK == 1)
               {
                    if (tBTenGiaoVien.Text == "" || tBLop.Text == "" || tBQuanSo.Text == "" || tbNamHoc.Text == "" || cBEHocKy.Text == "")
                    {
                         MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVBanDangKyCtrl.InsertBanDangKy(_MaDangKy, _HoTen, _Lop, _QuanSo, _HocKy, _NamHoc);
                         if (i == 1)
                         {
                              MessageBox.Show("Thêm bản đăng ký thành công", "Thông báo");
                              loadcbMaBDK(HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen);
                              ChiTietDangKy_Load();
                         }
                         else MessageBox.Show("Thêm bản đăng ký thất bại", "Thông báo");
                    }
               }
               else
               {
                    if (tBTenGiaoVien.Text == "" || tBLop.Text == "" || tBQuanSo.Text == "" || tbNamHoc.Text == "" || cBEHocKy.Text == "")
                    {
                         MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVBanDangKyCtrl.UpdateBanDangKy(_MaDangKy, _HoTen, _Lop, _QuanSo, _HocKy, _NamHoc);
                         if (i == 1)
                         {
                              MessageBox.Show("Sửa bản đăng ký thành công", "Thông báo");
                              loadcbMaBDK(HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen);
                              ChiTietDangKy_Load();
                         }
                         else MessageBox.Show("Sửa bản đăng ký thất bại", "Thông báo");
                    }
               }
          }

          private void bHuyBDK_Click(object sender, EventArgs e)
          {
               getThongTinBanDangKy();
               flagThemBDK = 0;
               dis_enableBDK(true);
          }

          private void searchBanDangKy_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
          {
               getBanDangKyByKey(searchBanDangKy.Text);
               getThongTinBanDangKy();
               dis_enableBDK(true);
               ChiTietDangKy_Load();
          }

          //
          // Panel Chi Tiết Đăng Ký
          //

          int flagThemCTDK = 0;

          private void bXemTatCa_Click(object sender, EventArgs e)
          {
               chonBDK = !chonBDK;
               if (chonBDK)
               {
                    Resources.Funtion.btKhongChon(bXemTatCa);
               }
               else Resources.Funtion.btChon(bXemTatCa);
               ChiTietDangKy_Load();
          }

          public void dis_enableCTDK(bool e) //e = true: ko them, sua. e = false = them, sua 
          {
               bThemCTDK.Enabled = e;
               bSuaCTDK.Enabled = e;
               bXoaCTDK.Enabled = e;
               bLuuCTDK.Enabled = !e;
               bHuyCTDK.Enabled = !e;
               cBEMaBDK.Enabled = !e;
               tbNhanVien2.Enabled = !e;
               tbGiaoVien2.Enabled = !e;
               cBEPhong.Enabled = !e;
               cbTenBTN.Enabled = !e;
               dENgaySD.Enabled = !e;
               tbCa.Enabled = !e;
               tbSoNhom.Enabled = !e;
               cBETinhTrang.Enabled = !e;
               tbGhiChu.Enabled = !e;
               if (HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "Giáo viên")
               {
                    tbGiaoVien2.Enabled = false;
                    if (HTTaiKhoanGanDayMod.taiKhoanGanDay.HoTen != tbGiaoVien2.Text)
                    {
                         bSuaCTDK.Enabled = false;
                         bXoaCTDK.Enabled = false;
                    }
                    if (cBETinhTrang.Text.CompareTo("Chưa thực hiện") != 0)
                    {
                         bSuaCTDK.Enabled = false;
                    }
                    if (cBETinhTrang.Text.CompareTo("Đã hủy") != 0)
                    {
                         bXoaCTDK.Enabled = false;
                    }
               }
               else
               {
                    tbNhanVien2.Enabled = false;
                    if (HTTaiKhoanGanDayMod.taiKhoanGanDay.HoTen != tbNhanVien2.Text)
                    {
                         bSuaCTDK.Enabled = false;
                         bXoaCTDK.Enabled = false;
                    }
                    if (cBETinhTrang.Text.CompareTo("Chưa thực hiện") != 0)
                    {
                         bSuaCTDK.Enabled = false;
                    }
                    if (cBETinhTrang.Text.CompareTo("Đã hủy") != 0)
                    {
                         bXoaCTDK.Enabled = false;
                    }
               }
          }

          public void getChiTietDangKy()
          {
               if (!chonBDK) dGVChiTietDangKy.DataSource = Models.NVChiTietDangKyMod.getChiTietDangKy();
               else dGVChiTietDangKy.DataSource = Models.NVChiTietDangKyMod.getChiTietDangKyByMaDangKy(tBMaDK.Text);
               dGVChiTietDangKy.Dock = DockStyle.Fill;
          }

          public void getChiTietDangKyByKey(string Key)
          {
               string MaCTDK = "";
               if (chonBDK) MaCTDK = tbMaChiTietDK.Text;
               dGVChiTietDangKy.DataSource = Models.NVChiTietDangKyMod.getChiTietDangKyByKey(MaCTDK, Key);
               dGVChiTietDangKy.Dock = DockStyle.Fill;
          }

          public void getThongTinChiTietDangKy()
          {
               tbMaChiTietDK.DataBindings.Clear();
               tbMaChiTietDK.DataBindings.Add("Text", dGVChiTietDangKy.DataSource, "MaCTDK");
               cBEMaBDK.DataBindings.Clear();
               cBEMaBDK.DataBindings.Add("Text", dGVChiTietDangKy.DataSource, "MaDangKy");
               tbGiaoVien2.DataBindings.Clear();
               tbGiaoVien2.DataBindings.Add("Text", dGVChiTietDangKy.DataSource, "HoTenGV");
               tbNhanVien2.DataBindings.Clear();
               tbNhanVien2.DataBindings.Add("Text", dGVChiTietDangKy.DataSource, "HoTenNV");
               cBEPhong.DataBindings.Clear();
               cBEPhong.DataBindings.Add("Text", dGVChiTietDangKy.DataSource, "TenPhong");
               cbTenBTN.DataBindings.Clear();
               cbTenBTN.DataBindings.Add("Text", dGVChiTietDangKy.DataSource, "TenBTN");
               dENgaySD.DataBindings.Clear();
               dENgaySD.DataBindings.Add("Text", dGVChiTietDangKy.DataSource, "NgaySD");
               tbLop2.DataBindings.Clear();
               tbLop2.DataBindings.Add("Text", dGVChiTietDangKy.DataSource, "Lop");
               tbCa.DataBindings.Clear();
               tbCa.DataBindings.Add("Text", dGVChiTietDangKy.DataSource, "CaTrongNgay");
               tbSoNhom.DataBindings.Clear();
               tbSoNhom.DataBindings.Add("Text", dGVChiTietDangKy.DataSource, "SoNhom");
               cBETinhTrang.DataBindings.Clear();
               cBETinhTrang.DataBindings.Add("Text", dGVChiTietDangKy.DataSource, "TinhTrang");
               tbGhiChu.DataBindings.Clear();
               tbGhiChu.DataBindings.Add("Text", dGVChiTietDangKy.DataSource, "GhiChu");
               
          }

          private void searchCTDK_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
          {
               getChiTietDangKyByKey(searchCTDK.Text);
               getThongTinChiTietDangKy();
               dis_enableCTDK(true);
          }

          public void ChiTietDangKy_Load()
          {
               getChiTietDangKy();
               getThongTinChiTietDangKy();
               dis_enableCTDK(true);
          }

          private void dGVChiTietDangKy_CellClick(object sender, DataGridViewCellEventArgs e)
          {
               getThongTinChiTietDangKy();
               flagThemCTDK = 0;
               dis_enableCTDK(true);
          }

          private void cBEMaBDK_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbMaBDK2, pnMaBDK2);
          }

          private void cBEMaBDK_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbMaBDK2, pnMaBDK2);
          }

          private void cBEPhong_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbPhong2, pnPhong2);
          }

          private void cBEPhong_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbPhong2, pnPhong2);
          }

          private void cbTenBTN_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbBaiTN, pnbaiTN);
          }

          private void cbTenBTN_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbBaiTN, pnbaiTN);
          }

          private void dENgaySD_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbNgaySD, pnNgaySd);
          }

          private void dENgaySD_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbNgaySD, pnNgaySd);
          }

          private void tbCa_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbCa, pnCa);
          }

          private void tbCa_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbCa, pnCa);
          }

          private void tbSoNhom_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbSoNhom, pnSoNhom);
          }

          private void tbSoNhom_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbSoNhom, pnSoNhom);
          }

          private void cBETinhTrang_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbTinhTrang, pnTinhTrang);
          }

          private void cBETinhTrang_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbTinhTrang, pnTinhTrang);
          }

          private void tbGhiChu_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbGhiChu, pnGhiChu);
          }

          private void tbGhiChu_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbGhiChu, pnGhiChu);
          }

          private void bThemCTDK_Click(object sender, EventArgs e)
          {
               tbMaChiTietDK.Text = context.Database.SqlQuery<string>("spGetMaCTDK").FirstOrDefault();
               flagThemCTDK = 1;
               dis_enableCTDK(false);
               tbGiaoVien2.Text = "";
               tbNhanVien2.Text = "";
               cBEMaBDK.Text = "";
               cBEPhong.Text = "";
               cBETenBTN.Text = "";
               tbLop2.Text = "";
               tbCa.Text = "";
               tbSoNhom.Text = "";
               cBETinhTrang.Text = "";
               tbGhiChu.Text = "";
               if(HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "Giáo viên")
               {
                    tbGiaoVien2.Text = HTTaiKhoanGanDayMod.taiKhoanGanDay.HoTen;
               }    
               else
               {
                    tbNhanVien2.Text = HTTaiKhoanGanDayMod.taiKhoanGanDay.HoTen;
               }
          }

          private void bSuaCTDK_Click(object sender, EventArgs e)
          {
               flagThemCTDK = 0;
               dis_enableCTDK(false);
          }

          private void bXoaCTDK_Click(object sender, EventArgs e)
          {
               DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (dr == DialogResult.Yes)
               {
                    int i = Controllers.NVChiTietDangKyCtrl.DeteleChiTietDangKy(tbMaChiTietDK.Text);
                    if (i == 1)
                    {
                         MessageBox.Show("Xóa thành công!", "Thông báo");
                         ChiTietDangKy_Load();
                    }
                    else MessageBox.Show("Xóa không thành công.");

               }
               else
                    return;
          }

          private void bLuuCTDK_Click(object sender, EventArgs e)
          {
               string _MaCTDK = "";
               try { _MaCTDK = tbMaChiTietDK.Text; }
               catch { }
               string _MaDangKy = "";
               try { _MaDangKy = cBEMaBDK.Text; }
               catch { }
               string _HoTenGV = "";
               try { _HoTenGV = tbGiaoVien2.Text; }
               catch { }
               string _HoTenNV = "";
               try { _HoTenNV = tbNhanVien2.Text; }
               catch { }
               string _TenPhong = "";
               try { _TenPhong = cBEPhong.Text; }
               catch { }
               string _TenBTN = "";
               try { _TenBTN = cbTenBTN.Text; }
               catch { }
               DateTime _NgaySD = DateTime.Today;
               try { _NgaySD = dENgaySD.DateTime; }
               catch { }
               string _Lop = "";
               try { _Lop = tBLop.Text; }
               catch { }
               int _CaTrongNgay = 1;
               try { int.TryParse(tbCa.Text, out _CaTrongNgay); }
               catch { }
               int _SoNhom = 1;
               try { int.TryParse(tbSoNhom.Text, out _SoNhom); }
               catch { }
               string _TinhTrang = "";
               try { _TinhTrang = cBETinhTrang.Text; }
               catch { }
               string _GhiChu = "";
               try { _GhiChu = tbGhiChu.Text; }
               catch { }

               if (flagThemCTDK == 1)
               {
                    if (cBEMaBDK.Text == "" || cBEPhong.Text == "" || cbTenBTN.Text == "" || dENgaySD.Text == "" || tbCa.Text == "" || tbSoNhom.Text == "" || cBETinhTrang.Text == "")
                    {
                         MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVChiTietDangKyCtrl.InsertChiTietDangKy(_MaCTDK, _MaDangKy, _HoTenNV, _TenPhong, _TenBTN, _NgaySD, _CaTrongNgay, _SoNhom, _TinhTrang, _GhiChu);
                         if (i == 1)
                         {
                              MessageBox.Show("Thêm chi tiết đăng kí thành công", "Thông báo");
                              ChiTietDangKy_Load();
                         }
                         else MessageBox.Show("Thêm chi tiết đang ký thất bại", "Thông báo");
                    }
               }
               else
               {
                    if (cBEMaBDK.Text == "" || cBEPhong.Text == "" || cBETenBTN.Text == "" || dENgaySD.Text == "" || tbCa.Text == "" || tbSoNhom.Text == "" || cBETinhTrang.Text == "")
                    {
                         MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVChiTietDangKyCtrl.UpdateChiTietDangKy(_MaCTDK, _MaDangKy, _HoTenNV, _TenPhong, _TenBTN, _NgaySD, _CaTrongNgay, _SoNhom, _TinhTrang, _GhiChu);
                         if (i == 1)
                         {
                              MessageBox.Show("Sửa chi tiết đăng kí thành công", "Thông báo");
                              ChiTietDangKy_Load();
                         }
                         else MessageBox.Show("Sửa chi tiết đang ký thất bại", "Thông báo");
                    }
               }
          }

          private void bHuyCTDK_Click(object sender, EventArgs e)
          {
               getThongTinChiTietDangKy();
               flagThemCTDK = 0;
               dis_enableCTDK(true);
          }

          private void cBEMaBDK_SelectedIndexChanged(object sender, EventArgs e)
          {


          }

          private void simpleButton1_Click(object sender, EventArgs e)
          {
               LoadData();
          }
     }
}
