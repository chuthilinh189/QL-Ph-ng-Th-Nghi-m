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
using DevExpress.XtraPrinting.Export.Pdf;
using DevExpress.XtraEditors.Filtering.Templates;
using System.Data.SqlClient;
using QLPhongThiNghhiem.Models;

namespace QLPhongThiNghhiem.Views
{
     public partial class XUCNVHeThongTrangBi : DevExpress.XtraEditors.XtraUserControl
     {
          public XUCNVHeThongTrangBi()
          {
               InitializeComponent();
          }

          public static XUCNVHeThongTrangBi xUCNVHeThongTrangBi = new XUCNVHeThongTrangBi();

          bool chonLTTB = true;
          bool chonPTN = false;

          private DBContext.DBPTNContext context = new DBContext.DBPTNContext();
          public void loadcbPhong()
          {
               cBEMaPTN.Properties.Items.Clear();
               cBEPhong.Properties.Items.Clear();
               List<string> listPhong = context.Database.SqlQuery<string>("SELECT TenPhong FROM dbo.PhongThiNghiem").ToList<string>();
               foreach (string Phong in listPhong)
               {
                    cBEPhong.Properties.Items.Add(Phong);
                    cBEMaPTN.Properties.Items.Add(Phong);
               }
          }

          public void loadcbLoai()
          {
               cBELoai.Properties.Items.Clear();
               List<string> listLoai = context.Database.SqlQuery<string>("SELECT TenLoai FROM dbo.LoaiTTB").ToList<string>();
               foreach (string Loai in listLoai)
               {
                    cBELoai.Properties.Items.Add(Loai);
               }
          }

          public void LoadData()
          {
               phanQuyen();
               loadcbPhong();
               loadcbLoai();
               LoaiTTB_Load();
               TrangThietBi_Load();
          }

          public void phanQuyen()
          {
               bool quyenGiaoVien = false;
               if (HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "Giáo viên") quyenGiaoVien = true;
               bThem.Visible = !quyenGiaoVien;
               bSua.Visible = !quyenGiaoVien;
               bXoa.Visible = !quyenGiaoVien;
               bLuu.Visible = !quyenGiaoVien;
               btHuy.Visible = !quyenGiaoVien;
               bThemTTB.Visible = !quyenGiaoVien;
               bSuaTTB.Visible = !quyenGiaoVien;
               bXoaTTB.Visible = !quyenGiaoVien;
               bLuuTTB.Visible = !quyenGiaoVien;
               bHuyTTB.Visible = !quyenGiaoVien;
               if (quyenGiaoVien)
               {
                    panel1.Size = new Size(364, 48 + 15);
                    panel2.Size = new Size(364, 173 - 15);
               }
               else
               {
                    panel1.Size = new Size(364,48);
                    panel2.Size = new Size(364, 173);
               }
          }


          //
          // Panel Loại Trang Thiết Bị
          //

          int flagThemLTTB = 0;

          public void dis_enableLTTB(bool e) //e = true: ko them, sua. e = false = them, sua 
          {
               bThemTTB.Enabled = e;
               bSuaTTB.Enabled = e;
               bXoaTTB.Enabled = e;
               bLuuTTB.Enabled = !e;
               bHuyTTB.Enabled = !e;
               tBTenLoaiTTB.Enabled = !e;
               tBDonViTinhTTB.Enabled = !e;
          }

          public void getLoaiTTB()
          {
               dGVLoaiTTB.DataSource = Models.NVLoaiTTBMod.getLoaiTrangThietBi();
               dGVLoaiTTB.Dock = DockStyle.Fill;
          }

          public void getLoaiTTBByKey(string Key)
          {
               dGVLoaiTTB.DataSource = Models.NVLoaiTTBMod.getLoaiTrangThietBiByKey(Key);
               dGVLoaiTTB.Dock = DockStyle.Fill;
          }

          public void getThongTinLoaiTTB()
          {
               if (dGVLoaiTTB.CurrentRow == null) return;
               tbMaLoaiTTB.Text = dGVLoaiTTB.CurrentRow.Cells[1].FormattedValue.ToString();
               tBTenLoaiTTB.Text = dGVLoaiTTB.CurrentRow.Cells[2].FormattedValue.ToString();
               tbSoTTB.Text = dGVLoaiTTB.CurrentRow.Cells[3].FormattedValue.ToString();
               tBDonViTinhTTB.Text = dGVLoaiTTB.CurrentRow.Cells[4].FormattedValue.ToString();
          }

          private void LoaiTTB_Load()
          {
               getLoaiTTB();
               getThongTinLoaiTTB();
               dis_enableLTTB(true);
               TrangThietBi_Load();
          }

          private void dGVLoaiTTB_CellClick(object sender, DataGridViewCellEventArgs e)
          {
               getThongTinLoaiTTB();
               flagThemLTTB = 0;
               dis_enableLTTB(true);
               TrangThietBi_Load();
          }


          private void tBTenLoaiTTB_MouseClick(object sender, MouseEventArgs e)
          {
               Resources.Funtion.chon(lbTenLoai, panelTenLoai);
          }

          private void tBDonViTinhTTB_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbDonViTinh, pannelDonViTinh);
          }

          private void tBDonViTinhTTB_MouseClick(object sender, MouseEventArgs e)
          {
               Resources.Funtion.chon(lbDonViTinh, pannelDonViTinh);
          }
          private void tBTenLoaiTTB_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbTenLoai, panelTenLoai);
          }

          private void bThemTTB_Click(object sender, EventArgs e)
          {
               tbMaLoaiTTB.Text = context.Database.SqlQuery<string>("spGetMaLoaiTTB").FirstOrDefault();
               flagThemLTTB = 1;
               dis_enableLTTB(false);
               tBTenLoaiTTB.Text = "";
               tBDonViTinhTTB.Text = "";
               tbSoTTB.Text = "0";
          }

          private void bSuaTTB_Click(object sender, EventArgs e)
          {
               flagThemLTTB = 0;
               dis_enableLTTB(false);
          }


          private void bXoaTTB_Click(object sender, EventArgs e)
          {
               if (int.Parse(tbSoTTB.Text) > 0)
               {
                    MessageBox.Show("Loại TTB này đang có Trang thiết bị cần quản lý.\nKhông thể xóa!", "Thông báo", MessageBoxButtons.OK);
                    return;
               }

               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaLTTB", tbMaLoaiTTB.Text));
               int BTN = context.Database.SqlQuery<int>("spCountBTNCanDungLTTB @MaLTTB", paralist.ToArray()).FirstOrDefault();
               if (BTN > 0)
               {
                    MessageBox.Show("Có bài thí nghiệm cần dùng tới Loại TTB này.\nKhông thể xóa!", "Thông báo", MessageBoxButtons.OK);
                    return;
               }

               DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (dr == DialogResult.Yes)
               {
                    int i = Controllers.NVLoaiTTBCtrl.DeteleLoaiTrangThietBi(tbMaLoaiTTB.Text);
                    if (i == 1)
                    {
                         MessageBox.Show("Xóa thành công!", "Thông báo");
                         loadcbLoai();
                         LoaiTTB_Load();
                    }
                    else MessageBox.Show("Xóa không thành công.");

               }
               else
                    return;
          }

          private void bLuuTTB_Click(object sender, EventArgs e)
          {
               string _MaLTTB = "";
               try { _MaLTTB = tbMaLoaiTTB.Text; }
               catch { }
               string _TenLoai = "";
               try { _TenLoai = tBTenLoaiTTB.Text; }
               catch { }
               string _DonViTinh = "";
               try { _DonViTinh = tBDonViTinhTTB.Text; }
               catch { }
               if (flagThemLTTB == 1)
               {
                    if (tBTenLoaiTTB.Text == "")
                    {
                         MessageBox.Show("Hãy nhập tên loại Trang thiết bị", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVLoaiTTBCtrl.InsertLoaiTrangThietBi(_MaLTTB, _TenLoai, _DonViTinh);
                         if (i == 1)
                         {
                              MessageBox.Show("Thêm loại TTB thành công", "Thông báo");
                              loadcbLoai();
                              LoaiTTB_Load();
                         }
                         else MessageBox.Show("Thêm loại TTB thất bại", "Thông báo");
                    }
               }
               else
               {
                    if (tBTenLoaiTTB.Text == "")
                    {
                         MessageBox.Show("Hãy nhập tên loại Trang thiết bị", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVLoaiTTBCtrl.UpdateLoaiTrangThietBi(_MaLTTB, _TenLoai, _DonViTinh);
                         if (i == 1)
                         {
                              MessageBox.Show("Sửa thông tin loại TTB thành công", "Thông báo");
                              loadcbLoai();
                              LoaiTTB_Load();
                         }
                         else MessageBox.Show("Sửa thông tin loại TTB thất bại", "Thông báo");
                    }
               }
          }

          private void bHuyTTB_Click(object sender, EventArgs e)
          {
               getThongTinLoaiTTB();
               flagThemLTTB = 0;
               dis_enableLTTB(true);
          }

          private void searchLoaiTTB_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
          {
               getLoaiTTBByKey(searchLoaiTTB.Text);
               getThongTinLoaiTTB();
               dis_enableLTTB(true);
               TrangThietBi_Load();
          }


          //
          // Panel Trang Thiết Bị
          //

          int flagThemTTB = 0;
          private void bChonLoaiTTB_Click(object sender, EventArgs e)
          {
               panelLoaiTTB.Visible = !panelLoaiTTB.Visible;
               chonLTTB = !chonLTTB;
               if (chonLTTB) Resources.Funtion.btChon(bChonLoaiTTB); 
               else  Resources.Funtion.btKhongChon(bChonLoaiTTB);
               TrangThietBi_Load();
          }

          public void khongChonPTN()
          {
               chonPTN = false;
               Resources.Funtion.btKhongChon(bChonPTN);
          }

          private void bChonPTN_Click(object sender, EventArgs e)
          {
               cBEMaPTN.Visible = !cBEMaPTN.Visible;
               chonPTN = !chonPTN;
               if (chonPTN) Resources.Funtion.btChon(bChonPTN);
               else Resources.Funtion.btKhongChon(bChonPTN);
               TrangThietBi_Load();
          }

          public void dis_enableTTB(bool e) //e = true: ko them, sua. e = false = them, sua 
          {
               bThem.Enabled = e;
               bSua.Enabled = e;
               bXoa.Enabled = e;
               bLuu.Enabled = !e;
               btHuy.Enabled = !e;
               tBTenTTB.Enabled = !e;
               cBEPhong.Enabled = !e;
               cBELoai.Enabled = !e;
               comboBoxEdit1.Enabled = !e;
               dENgayNhap.Enabled = !e;
               tBGiaTien.Enabled = !e;
               cBETinhTrang.Enabled = !e;
               tBGhiChu.Enabled = !e;
               cBEXuatKho.Enabled = !e;
          }

          public void getTrangThietBi()
          {
               string LoaiTTB  = "";
               string PhongTN = "";
               if (chonLTTB) LoaiTTB = tBTenLoaiTTB.Text;
               if (chonPTN) PhongTN = cBEMaPTN.Text;
               dGVTrangThietBi.DataSource = Controllers.NVTrangThietBiCtrl.getTrangThietBiByLtttPtn(LoaiTTB, PhongTN);
               dGVTrangThietBi.Dock = DockStyle.Fill;
          }

          public void getTrangThietBiByKey(string Key)
          {
               string LoaiTTB = "";
               string PhongTN = "";
               if (chonLTTB) LoaiTTB = tBTenLoaiTTB.Text;
               if (chonPTN) PhongTN = cBEMaPTN.Text;
               dGVTrangThietBi.DataSource = Controllers.NVTrangThietBiCtrl.getTrangThietBiByKey(LoaiTTB, PhongTN, Key);
               dGVTrangThietBi.Dock = DockStyle.Fill;
          }

          public void getThongTinTrangThietBi()
          {
               if (dGVTrangThietBi.CurrentRow == null) return;
               tbMaTTB.Text = dGVTrangThietBi.CurrentRow.Cells[0].FormattedValue.ToString();
               tBTenTTB.Text = dGVTrangThietBi.CurrentRow.Cells[1].FormattedValue.ToString();
               cBEPhong.Text = dGVTrangThietBi.CurrentRow.Cells[2].FormattedValue.ToString();
               cBELoai.Text = dGVTrangThietBi.CurrentRow.Cells[3].FormattedValue.ToString();
               comboBoxEdit1.Text = dGVTrangThietBi.CurrentRow.Cells[4].FormattedValue.ToString();
               dENgayNhap.EditValue = dGVTrangThietBi.CurrentRow.Cells[5].FormattedValue;
               tBGiaTien.Text = dGVTrangThietBi.CurrentRow.Cells[6].FormattedValue.ToString();
               cBETinhTrang.Text = dGVTrangThietBi.CurrentRow.Cells[7].FormattedValue.ToString();
               tBGhiChu.Text = dGVTrangThietBi.CurrentRow.Cells[8].FormattedValue.ToString();
               cBEXuatKho.EditValue = dGVTrangThietBi.CurrentRow.Cells[9].FormattedValue;
          }
          private void searchTrangThietBi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
          {
               getTrangThietBiByKey(searchTrangThietBi.Text);
               getThongTinTrangThietBi();
               dis_enableTTB(true);
          }


          public void TrangThietBi_Load()
          {
               getTrangThietBi();
               getThongTinTrangThietBi();
               dis_enableTTB(true);
          }

          private void dGVTrangThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
          {
               getThongTinTrangThietBi();
               flagThemTTB = 0;
               dis_enableTTB(true);
          }

          private void tBTenTTB_MouseClick(object sender, MouseEventArgs e)
          {
               Resources.Funtion.chon( lbTenTTB , pnTenTTB );
          }

          private void tBTenTTB_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbTenTTB , pnTenTTB);
          }

          private void cBEPhong_MouseClick(object sender, MouseEventArgs e)
          {
               Resources.Funtion.chon( lbPhong,pnPhong  );
          }


          private void cBEPhong_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbPhong, pnPhong);
          }

          private void cBEPhong_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon( lbPhong, pnPhong);
          }

          private void cBELoai_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon( lbLoaiTTB , pnLoaiTTB );
          }

          private void cBELoai_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon( lbLoaiTTB, pnLoaiTTB );
          }

          private void comboBoxEdit1_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon( lbNSX , pnNSX );
          }

          private void comboBoxEdit1_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbNSX, pnNSX);
          }

          private void dENgayNhap_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon( lbNgayNhap , pnNgayNhap );
          }

          private void dENgayNhap_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon( lbNgayNhap, pnNgayNhap );
          }

          private void tBGiaTien_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon( lbGiaTien , pnGiaTien );
          }

          private void tBGiaTien_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon( lbGiaTien, pnGiaTien );
          }

          private void cBETinhTrang_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon( lbTinhTrang ,pnTinhTrang  );
          }

          private void cBETinhTrang_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbTinhTrang , pnTinhTrang );
          }

          private void tBGhiChu_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon( lbGhiChu , pnGhiChu );
          }

          private void tBGhiChu_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbGhiChu, pnGhiChu);
          }

          private void cBEXuatKho_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(  lbXuatKho,pnXuatKho  );
          }

          private void cBEXuatKho_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbXuatKho, pnXuatKho);
          }

          private void bThem_Click(object sender, EventArgs e)
          {
               flagThemTTB = 1;
               dis_enableTTB(false);
               tBTenTTB.Text = "";
               tBGiaTien.Text = "";
               tBGhiChu.Text = "";
               tbMaTTB.Text = context.Database.SqlQuery<string>("spGetMaTrangThietBi").FirstOrDefault();
          }

          private void bSua_Click(object sender, EventArgs e)
          {
               flagThemTTB = 0;
               dis_enableTTB(false);
          }

          private void bXoa_Click(object sender, EventArgs e)
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaTTB", tbMaTTB.Text));
               int LuotSD = context.Database.SqlQuery<int>("spCountSoLuotSDTTB @MaTTB", paralist.ToArray()).FirstOrDefault();
               if (LuotSD > 0)
               {
                    MessageBox.Show("Trang thiết bị này đã được sử dụng.\nKhông thể xóa!", "Thông báo", MessageBoxButtons.OK);
                    return;
               }

               DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (dr == DialogResult.Yes)
               {
                    int i = Controllers.NVTrangThietBiCtrl.DeteleTrangThietBi(tbMaTTB.Text);
                    if (i == 1)
                    {
                         MessageBox.Show("Xóa thành công!", "Thông báo");
                         TrangThietBi_Load();
                    }
                    else MessageBox.Show("Xóa không thành công.");

               }
               else
                    return;
          }

          private void bLuu_Click(object sender, EventArgs e)
          {
               string _MaTTB = "";
               try { _MaTTB = tbMaTTB.Text; }
               catch { }
               string _TenTTB = "";
               try { _TenTTB = tBTenTTB.Text; }
               catch { }
               string _TenPhong = "";
               try { _TenPhong = cBEPhong.Text; }
               catch { }
               string _TenNSX = "";
               try { _TenNSX = comboBoxEdit1.Text; }
               catch { }
               string _TenLoai = "";
               try { _TenLoai = cBELoai.Text; }
               catch { }
               DateTime _NgayNhap = DateTime.Today;
               try { _NgayNhap = dENgayNhap.DateTime; }
               catch { }
               int _GiaTien = 0;
               try { int.TryParse(tBGiaTien.Text, out _GiaTien); }
               catch { }
               string _TinhTrang = "";
               try { _TinhTrang = cBETinhTrang.Text; }
               catch { }
               string _GhiChu = "";
               try { _GhiChu = tBGhiChu.Text; }
               catch { }
               bool _XuatKho = false;
               if (cBEXuatKho.EditValue.ToString() == "True") _XuatKho = true;

               if (flagThemTTB == 1)
               {
                    if (cBELoai.Text == "" || comboBoxEdit1.Text == "" || cBEPhong.Text == "" || tBTenTTB.Text == "" || cBETinhTrang.Text == "" || cBEXuatKho.Text == "")
                    {
                         MessageBox.Show("Hãy nhập tên loại Trang thiết bị", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVTrangThietBiCtrl.InsertTrangThietBi(_MaTTB, _TenTTB, _TenPhong, _TenLoai, _TenNSX, _NgayNhap, _GiaTien, _TinhTrang, _GhiChu, _XuatKho);
                         if (i == 1)
                         {
                              MessageBox.Show("Thêm trang thiết bị thành công", "Thông báo");
                              TrangThietBi_Load();
                         }
                         else MessageBox.Show("Thêm trang thiết bị thất bại", "Thông báo");
                    }
               }
               else
               {
                    if (cBELoai.Text == "" || comboBoxEdit1.Text == "" || cBEPhong.Text == "" || tBTenTTB.Text == "" || cBETinhTrang.Text == "" || cBEXuatKho.Text == "")
                    {
                         MessageBox.Show("Hãy nhập tên loại Trang thiết bị", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVTrangThietBiCtrl.UpdateTrangThietBi(_MaTTB, _TenTTB, _TenPhong, _TenLoai, _TenNSX, _NgayNhap, _GiaTien, _TinhTrang, _GhiChu, _XuatKho);
                         if (i == 1)
                         {
                              MessageBox.Show("Thành công", "Thông báo");
                              TrangThietBi_Load();
                         }
                         else MessageBox.Show("Thất bại", "Thông báo");
                    }
               }
          }

          private void btHuy_Click(object sender, EventArgs e)
          {
               getThongTinTrangThietBi();
               flagThemTTB = 0;
               dis_enableTTB(true);
          }

          private void cBEMaPTN_SelectedIndexChanged(object sender, EventArgs e)
          {
               TrangThietBi_Load();
          }

          private void simpleButton1_Click(object sender, EventArgs e)
          {
               LoadData();
          }
     }
}
