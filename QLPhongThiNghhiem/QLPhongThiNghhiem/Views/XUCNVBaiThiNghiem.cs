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
using System.Data.SqlClient;
using QLPhongThiNghhiem.Models;

namespace QLPhongThiNghhiem.Views
{
     public partial class XUCNVBaiThiNghiem : DevExpress.XtraEditors.XtraUserControl
     {
          public XUCNVBaiThiNghiem()
          {
               InitializeComponent();
          }
          public static XUCNVBaiThiNghiem xUCNVBaiThiNghiem = new XUCNVBaiThiNghiem();

          private DBContext.DBPTNContext context = new DBContext.DBPTNContext();
          bool chonBTN = true;

          public void loadcbTenBai()
          {
               List<string> listBTN = context.Database.SqlQuery<string>("SELECT TenBTN AS string FROM dbo.BaiThiNghiem", new List<SqlParameter>().ToArray()).ToList<string>();
               foreach (string BTN in listBTN)
               {
                    cBETenBTN.Properties.Items.Add(BTN);
               }
          }

          public void loadcbLoaiTTB()
          {
               List<string> listLTTB = context.Database.SqlQuery<string>("SELECT TenBTN AS string FROM dbo.BaiThiNghiem", new List<SqlParameter>().ToArray()).ToList<string>();
               foreach (string LTTB in listLTTB)
               {
                    cBETenBTN.Properties.Items.Add(LTTB);
               }
          }
           
          public void LoadData()
          {
               phanQuyen();
               BaiThiNghiem_Load();
               loadcbTenBai();
               loadcbLoaiTTB();
          }

          public void phanQuyen()
          {
               bool quyenGiaoVien = false;
               if (HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "Giáo viên" || HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "admin") quyenGiaoVien = true;
               bThemBTN.Visible = quyenGiaoVien;
               bSuaBTN.Visible = quyenGiaoVien;
               bXoaBTN.Visible = quyenGiaoVien;
               bLuuBTN.Visible = quyenGiaoVien;
               bHuyBTN.Visible = quyenGiaoVien;
               bThemChiTiet.Visible = quyenGiaoVien;
               bSuaChiTiet.Visible = quyenGiaoVien;
               bXoaChiTiet.Visible = quyenGiaoVien;
               bLuuChiTiet.Visible = quyenGiaoVien;
               bHuyChiTiet.Visible = quyenGiaoVien;
               if (!quyenGiaoVien)
               {
                    panel1.Size = new Size(489, 48 + 17);
                    panel2.Size = new Size(489, 173 - 17);
               }
               else
               {
                    panel1.Size = new Size(489, 48);
                    panel2.Size = new Size(489, 171);
               }
          }

          //
          // Panel Bài Thí Nghiệm
          //

          int flagThemBTN = 0;

          public void dis_enableBTN(bool e) //e = true: ko them, sua. e = false = them, sua 
          {
               bThemBTN.Enabled = e;
               bSuaBTN.Enabled = e;
               bXoaBTN.Enabled = e;
               bLuuBTN.Enabled = !e;
               bHuyBTN.Enabled = !e;
               tBTenBTn.Enabled = !e;
          }

          public void getBaiThiNghiem()
          {
               dGVBaiThiNghiem.DataSource = Models.NVBaiThiNghiemMod.getBaiThiNghiem();
               dGVBaiThiNghiem.Dock = DockStyle.Fill;
          }

          public void getBaiThiNghiemByKey(string Key)
          {
               dGVBaiThiNghiem.DataSource = Models.NVBaiThiNghiemMod.getBaiThiNghiemByKey(Key);
               dGVBaiThiNghiem.Dock = DockStyle.Fill;
          }

          public void getThongTinBaiThiNghiem()
          {
               tBMaBTN.DataBindings.Clear();
               tBMaBTN.DataBindings.Add("Text", dGVBaiThiNghiem.DataSource, "MaBTN");
               tBTenBTn.DataBindings.Clear();
               tBTenBTn.DataBindings.Add("Text", dGVBaiThiNghiem.DataSource, "TenBTN");
          }

          private void BaiThiNghiem_Load()
          {
               getBaiThiNghiem();
               getThongTinBaiThiNghiem();
               dis_enableBTN(true);
               TrangBiCanDung_Load();
          }

          private void dGVBaiThiNghiem_CellClick(object sender, DataGridViewCellEventArgs e)
          {
               getThongTinBaiThiNghiem();
               flagThemBTN = 0;
               dis_enableBTN(true);
               TrangBiCanDung_Load();
          }

          private void tBTenBTn_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbMaTTB, pnMaBTN);
          }

          private void tBTenBTn_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbMaTTB, pnMaBTN);
          }

          private void bThemBTN_Click(object sender, EventArgs e)
          {
               tBMaBTN.Text = context.Database.SqlQuery<string>("spGetMaBaiThiNghiem").FirstOrDefault();
               flagThemBTN = 1;
               dis_enableBTN(false);
               tBTenBTn.Text = "";
          }

          private void bSuaBTN_Click(object sender, EventArgs e)
          {
               flagThemBTN = 0;
               dis_enableBTN(false);
          }

          private void bXoaBTN_Click(object sender, EventArgs e)
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaBTN", tBMaBTN.Text));
               int LuotDK = context.Database.SqlQuery<int>("spCountLuotDangKyBTN @MaBTN", paralist.ToArray()).FirstOrDefault();
               if (LuotDK > 0)
               {
                    MessageBox.Show("Bài thí nghiệm này đã được đăng ký sử dụng.\nKhông thể xóa!", "Thông báo", MessageBoxButtons.OK);
                    return;
               }

               DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (dr == DialogResult.Yes)
               {
                    int i = Controllers.NVBaiThiNghiemCtrl.DeteleBaiThiNghiem(tBMaBTN.Text);
                    if (i == 1)
                    {
                         MessageBox.Show("Xóa thành công!", "Thông báo");
                         loadcbTenBai();
                         BaiThiNghiem_Load();
                    }
                    else MessageBox.Show("Xóa không thành công.");

               }
               else
                    return;
          }

          private void bLuuBTN_Click(object sender, EventArgs e)
          {
               string _MaBTN = "";
               try { _MaBTN = tBMaBTN.Text; }
               catch { }
               string _TenBTN = "";
               try { _TenBTN = tBTenBTn.Text; }
               catch { }
               if (flagThemBTN == 1)
               {
                    if (tBTenBTn.Text == "")
                    {
                         MessageBox.Show("Hãy nhập tên bài thí nghiệm", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVBaiThiNghiemCtrl.InsertBaiThiNghiem(_MaBTN, _TenBTN);
                         if (i == 1)
                         {
                              MessageBox.Show("Thêm bài thí nghiệm thành công", "Thông báo");
                              loadcbTenBai();
                              BaiThiNghiem_Load();
                         }
                         else MessageBox.Show("Thêm bài thí nghiệm thất bại", "Thông báo");
                    }
               }
               else
               {
                    if (tBTenBTn.Text == "")
                    {
                         MessageBox.Show("Hãy nhập tên loại bài thí nghiệm", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVBaiThiNghiemCtrl.UpdateBaiThiNghiem(_MaBTN, _TenBTN);
                         if (i == 1)
                         {
                              MessageBox.Show("Sửa thông tin bài thí nghiệm thành công", "Thông báo");
                              loadcbTenBai();
                              BaiThiNghiem_Load();
                         }
                         else MessageBox.Show("Sửa thông tin bài thí nghiệm thất bại", "Thông báo");
                    }
               }
          }

          private void bHuyBTN_Click(object sender, EventArgs e)
          {
               getThongTinBaiThiNghiem();
               flagThemBTN = 0;
               dis_enableBTN(true);
          }

          private void searchBaiThiNghiem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
          {
               getBaiThiNghiemByKey(searchBaiThiNghiem.Text);
               getThongTinBaiThiNghiem();
               dis_enableBTN(true);
               TrangBiCanDung_Load();
          }

          
          //
          // Panel Trang Bị Cần Dùng
          //

          int flagThemTBCD = 0;
          
          private void bXemTheoBai_Click(object sender, EventArgs e)
          {
               if (!chonBTN)
               {
                    chonBTN = true;
                    Resources.Funtion.btChon(bXemTheoBai);
                    Resources.Funtion.btKhongChon(bXemTatCa);
                    TrangBiCanDung_Load();
               } 
          }

          private void bXemTatCa_Click(object sender, EventArgs e)
          {
               if (chonBTN)
               {
                    chonBTN = false;
                    Resources.Funtion.btKhongChon(bXemTheoBai);
                    Resources.Funtion.btChon(bXemTatCa);
                    TrangBiCanDung_Load();
               }
          }

          public void dis_enableTBCD(bool e) //e = true: ko them, sua. e = false = them, sua 
          {
               bThemChiTiet.Enabled = e;
               bSuaChiTiet.Enabled = e;
               bXoaChiTiet.Enabled = e;
               bLuuChiTiet.Enabled = !e;
               bHuyChiTiet.Enabled = !e;
               cBELoaiTTB.Enabled = !e;
               cBETenBTN.Enabled = !e;
               tBSoLuong.Enabled = !e;
          }

          public void getTrangBiCanDung()
          {
               if(!chonBTN) dGVTTBCanDung.DataSource = Models.NVTrangBiCanDungMod.getTrangBiCanDung();
               else dGVTTBCanDung.DataSource = Models.NVTrangBiCanDungMod.getTrangBiCanDungByMaBTN(tBMaBTN.Text);
               dGVTTBCanDung.Dock = DockStyle.Fill;
          }

          public void getTrangThietBiCanDungByKey(string Key)
          {
               string MaBTN = "";
               if (chonBTN) MaBTN = tBMaBTN.Text;
               dGVTTBCanDung.DataSource = Models.NVTrangBiCanDungMod.getTrangBiCanDungByKey(MaBTN, Key);
               dGVTTBCanDung.Dock = DockStyle.Fill;
          }

          public void getThongTinTrangBiCanDung()
          {
               tBMaChiTiet.DataBindings.Clear();
               tBMaChiTiet.DataBindings.Add("Text", dGVTTBCanDung.DataSource, "MaChiTiet");
               cBETenBTN.DataBindings.Clear();
               cBETenBTN.DataBindings.Add("Text", dGVTTBCanDung.DataSource, "TenBTN");
               cBELoaiTTB.DataBindings.Clear();
               cBELoaiTTB.DataBindings.Add("Text", dGVTTBCanDung.DataSource, "TenLoai");
               tBSoLuong.DataBindings.Clear();
               tBSoLuong.DataBindings.Add("Text", dGVTTBCanDung.DataSource, "SoLuong");

          }

          private void searchTrangBiCanDung_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
          {
               getTrangThietBiCanDungByKey(searchTrangBiCanDung.Text);
               getThongTinTrangBiCanDung();
               dis_enableTBCD(true);
          }
          


          public void TrangBiCanDung_Load()
          {
               getTrangBiCanDung();
               getThongTinTrangBiCanDung();
               dis_enableTBCD(true);
          }

          private void dGVTTBCanDung_CellClick(object sender, DataGridViewCellEventArgs e)
          {
               getThongTinTrangBiCanDung();
               flagThemTBCD = 0;
               dis_enableTBCD(true);
          }

          private void cBETenBTN_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbTenBTN, pnTenBTN);
          }

          private void cBETenBTN_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbTenBTN, pnTenBTN);
          }

          private void cBELoaiTTB_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbLoaiTTB, pnLoaiTTB);
          }

          private void cBELoaiTTB_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbLoaiTTB, pnLoaiTTB);
          }

          private void tBSoLuong_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbSoLuong, pnSoLuong);
          }

          private void tBSoLuong_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbSoLuong, pnSoLuong);
          }

          private void bThemChiTiet_Click(object sender, EventArgs e)
          {
               flagThemTBCD = 1;
               dis_enableTBCD(false);
               tBMaChiTiet.Text = context.Database.SqlQuery<string>("spGetMaTrangBiCanDung").FirstOrDefault();
          }

          private void bSuaChiTiet_Click(object sender, EventArgs e)
          {
               flagThemTBCD = 0;
               dis_enableTBCD(false);
          }

          private void bXoaChiTiet_Click(object sender, EventArgs e)
          {
               DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (dr == DialogResult.Yes)
               {
                    int i = Controllers.NVTrangBiCanDungCtrl.DeteleTrangBiCanDung(tBMaChiTiet.Text);
                    if (i == 1)
                    {
                         MessageBox.Show("Xóa thành công!", "Thông báo");
                         TrangBiCanDung_Load();
                    }
                    else MessageBox.Show("Xóa không thành công.");

               }
               else
                    return;
          }

          private void bLuuChiTiet_Click(object sender, EventArgs e)
          {
               string _MaChiTiet = "";
               try { _MaChiTiet = tBMaChiTiet.Text; }
               catch { }
               string _TenBTN = "";
               try { _TenBTN = cBETenBTN.Text; }
               catch { }
               string _TenLoai = "";
               try { _TenLoai = cBELoaiTTB.Text; }
               catch { }
               int _SoLuong = 1;
               try { int.TryParse(tBSoLuong.Text, out _SoLuong); }
               catch { }

               if (flagThemTBCD == 1)
               {
                    if (tBSoLuong.Text == "")
                    {
                         MessageBox.Show("Hãy nhập số lượng TTB cần dùng", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVTrangBiCanDungCtrl.InsertTrangBiCanDung(_MaChiTiet, _TenBTN, _TenLoai, _SoLuong);
                         if (i == 1)
                         {
                              MessageBox.Show("Thêm trang bị cần dùng thành công", "Thông báo");
                              TrangBiCanDung_Load();
                         }
                         else MessageBox.Show("Thêm trang bị cần dùng thất bại", "Thông báo");
                    }
               }
               else
               {
                    if (tBSoLuong.Text == "")
                    {
                         MessageBox.Show("Hãy nhập số lượng TTB cần dùng", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVTrangBiCanDungCtrl.UpdateTrangBiCanDung(_MaChiTiet, _TenBTN, _TenLoai, _SoLuong);
                         if (i == 1)
                         {
                              MessageBox.Show("Sửa trang bị cần dùng thành công", "Thông báo");
                              TrangBiCanDung_Load();
                         }
                         else MessageBox.Show("Sửa trang bị cần dùng thất bại", "Thông báo");
                    }
               }
          }

          private void bHuyChiTiet_Click(object sender, EventArgs e)
          {
               getThongTinTrangBiCanDung();
               flagThemTBCD = 0;
               dis_enableTBCD(true);
          }

          private void simpleButton1_Click(object sender, EventArgs e)
          {
               LoadData();
          }
     }
}
