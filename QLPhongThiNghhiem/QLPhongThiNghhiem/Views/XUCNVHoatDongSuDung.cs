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
using DevExpress.Xpo;
using QLPhongThiNghhiem.Models;
using System.Data.SqlClient;

namespace QLPhongThiNghhiem.Views
{
     public partial class XUCNVHoatDongSuDung : DevExpress.XtraEditors.XtraUserControl
     {
          public XUCNVHoatDongSuDung()
          {
               InitializeComponent();
          }

          public static XUCNVHoatDongSuDung xUCNVHoatDongSuDung = new XUCNVHoatDongSuDung();

          public void LoadData()
          {
               CaSuDung_Load();
               loadcbMaTTB();
               loadcbMaCTDK();
          }

          private DBContext.DBPTNContext context = new DBContext.DBPTNContext();
          bool chonCSD = true;

          public void loadcbMaTTB()
          {
               CBEMaTTB.Properties.Items.Clear();
               List<string> listMaTTB = context.Database.SqlQuery<string>("spLoadMaTTB").ToList<string>();
               foreach (string MaTTB in listMaTTB)
               {
                    CBEMaTTB.Properties.Items.Add(MaTTB);
               }
          }

          public void loadcbMaCTDK()
          {
               cBEMaCTDK.Properties.Items.Clear();
               string MaTK = HTTaiKhoanGanDayMod.taiKhoanGanDay.MaTK;
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaTK", HTTaiKhoanGanDayMod.taiKhoanGanDay.MaTK));

               List<string> listMaTTB = context.Database.SqlQuery<string>("spLoadMaCTDK @MaTK", paralist.ToArray()).ToList<string>();

               foreach (string MaTTB in listMaTTB)
               {
                    cBEMaCTDK.Properties.Items.Add(MaTTB);
               }
          }

          //
          // Panel Ca Sử Dụng
          //

          public void getCaSuDung()
          {
               dGVCaThiNghiem.DataSource = Models.NVCaSuDungMod.getCaSuDung();
               dGVCaThiNghiem.Dock = DockStyle.Fill;
          }

          public void getCaSuDungByKey(string Key)
          {
               dGVCaThiNghiem.DataSource = Models.NVCaSuDungMod.getCaSuDungByKey(Key);
               dGVCaThiNghiem.Dock = DockStyle.Fill;
          }

          public void getThongTinCaSuDung()
          {
               tBMaDK.DataBindings.Clear();
               tBMaDK.DataBindings.Add("Text", dGVCaThiNghiem.DataSource, "MaCTDK");
               tbPhong.DataBindings.Clear();
               tbPhong.DataBindings.Add("Text", dGVCaThiNghiem.DataSource, "TenPhong");
               tBLop.DataBindings.Clear();
               tBLop.DataBindings.Add("Text", dGVCaThiNghiem.DataSource, "Lop");
               tBGiaoVien.DataBindings.Clear();
               tBGiaoVien.DataBindings.Add("Text", dGVCaThiNghiem.DataSource, "HoTenGV");
               tbBaiThiNghiem.DataBindings.Clear();
               tbBaiThiNghiem.DataBindings.Add("Text", dGVCaThiNghiem.DataSource, "TenBTN");
               tbNhanVien.DataBindings.Clear();
               tbNhanVien.DataBindings.Add("Text", dGVCaThiNghiem.DataSource, "HoTenNV");
               deNgaySD.DataBindings.Clear();
               deNgaySD.DataBindings.Add("Text", dGVCaThiNghiem.DataSource, "NgaySD");
               tbCa.DataBindings.Clear();
               tbCa.DataBindings.Add("Text", dGVCaThiNghiem.DataSource, "CaTrongNgay");
               tbSoNhom.DataBindings.Clear();
               tbSoNhom.DataBindings.Add("Text", dGVCaThiNghiem.DataSource, "SoNhom");
               tbTTBDaDung.DataBindings.Clear();
               tbTTBDaDung.DataBindings.Add("Text", dGVCaThiNghiem.DataSource, "TTBDaDung");
          }

          private void CaSuDung_Load()
          {
               getCaSuDung();
               getThongTinCaSuDung();
               ChiTietSuDung_Load();
          }

          private void dGVCaThiNghiem_CellClick(object sender, DataGridViewCellEventArgs e)
          {
               getThongTinCaSuDung();
               ChiTietSuDung_Load();
          }

          private void searchCaThiNghiem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
          {
               getCaSuDungByKey(searchCaThiNghiem.Text);
               getThongTinCaSuDung();
               ChiTietSuDung_Load();
          }

          //
          // Panel Chi Tiết Sử Dụng
          //

          int flagThemCTSD = 0;

          private void bXemTatCa_Click(object sender, EventArgs e)
          {
               chonCSD = !chonCSD;
               if (chonCSD)
               {
                    Resources.Funtion.btKhongChon(bXemTatCa);
               }
               else Resources.Funtion.btChon(bXemTatCa);
               ChiTietSuDung_Load();
          }

          public void dis_enableCTSD(bool e) //e = true: ko them, sua. e = false = them, sua 
          {
               bThem.Enabled = e;
               bSua.Enabled = e;
               bXoa.Enabled = e;
               bLuu.Enabled = !e;
               bHuy.Enabled = !e;
               cBEMaCTDK.Enabled = !e;
               CBEMaTTB.Enabled = !e;
               if(tBMaDK.Text.CompareTo(cBEMaCTDK.Text) != 0)
               {
                    bSua.Enabled = false;
                    bXoa.Enabled = false;
               }
               else
               {
                    if (HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "Giáo viên")
                    {
                         if(tBGiaoVien.Text.CompareTo(HTTaiKhoanGanDayMod.taiKhoanGanDay.HoTen) != 0)
                         {
                              bSua.Enabled = false;
                              bXoa.Enabled = false;
                         }
                    }
                    else
                    {
                         if (tbNhanVien.Text.CompareTo(HTTaiKhoanGanDayMod.taiKhoanGanDay.HoTen) != 0)
                         {
                              bSua.Enabled = false;
                              bXoa.Enabled = false;
                         }
                    }
               }
               
          }

          public void getChiTietSuDung()
          {
               if (!chonCSD) dGVChiTietSDTTB.DataSource = Models.NVChiTietSuDungMod.getChiTietSuDung();
               else dGVChiTietSDTTB.DataSource = Models.NVChiTietSuDungMod.getChiTietSuDungByMaCTDK(tBMaDK.Text);
               dGVChiTietSDTTB.Dock = DockStyle.Fill;
          }

          public void getChiTietSuDungByKey(string Key)
          {
               string MaCTSD = "";
               if (chonCSD) MaCTSD = tBMaDK.Text;
               dGVChiTietSDTTB.DataSource = Models.NVChiTietSuDungMod.getChiTietSuDungByKey(MaCTSD, Key);
               dGVChiTietSDTTB.Dock = DockStyle.Fill;
          }

          public void getThongTinChiTietSuDung()
          {
               tbMaCTSD.DataBindings.Clear();
               tbMaCTSD.DataBindings.Add("Text", dGVChiTietSDTTB.DataSource, "MaChiTietSD");
               cBEMaCTDK.DataBindings.Clear();
               cBEMaCTDK.DataBindings.Add("Text", dGVChiTietSDTTB.DataSource, "MaCTDK");
               CBEMaTTB.DataBindings.Clear();
               CBEMaTTB.DataBindings.Add("Text", dGVChiTietSDTTB.DataSource, "MaTTB");
               tbTenTTB.DataBindings.Clear();
               tbTenTTB.DataBindings.Add("Text", dGVChiTietSDTTB.DataSource, "TenTTB");
          }

          private void searchChiTietSDTTB_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
          {
               getChiTietSuDungByKey(searchChiTietSDTTB.Text);
               getThongTinChiTietSuDung();
               dis_enableCTSD(true);
          }

          public void ChiTietSuDung_Load()
          {
               getChiTietSuDung();
               getThongTinChiTietSuDung();
               dis_enableCTSD(true);
          }

          private void dGVChiTietSDTTB_CellClick(object sender, DataGridViewCellEventArgs e)
          {
               getThongTinChiTietSuDung();
               flagThemCTSD = 0;
               dis_enableCTSD(true);
          }

          private void bThem_Click(object sender, EventArgs e)
          {
               flagThemCTSD = 1;
               dis_enableCTSD(false);
               tbMaCTSD.Text = context.Database.SqlQuery<string>("spGetMaChiTietSD").FirstOrDefault();
               cBEMaCTDK.Text = tBMaDK.Text;
               CBEMaTTB.Text = "";
               tbTenTTB.Text = "";
          }

          private void bSua_Click(object sender, EventArgs e)
          {
               flagThemCTSD = 0;
               dis_enableCTSD(false);
          }

          private void bXoa_Click(object sender, EventArgs e)
          {
               DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (dr == DialogResult.Yes)
               {
                    int i = Controllers.NVChiTietSuDungCtrl.DeteleChiTietSuDung(tbMaCTSD.Text);
                    if (i == 1)
                    {
                         MessageBox.Show("Xóa thành công!", "Thông báo");
                         ChiTietSuDung_Load();
                    }
                    else MessageBox.Show("Xóa không thành công.");

               }
               else
                    return;
          }

          private void bLuu_Click(object sender, EventArgs e)
          {
               string _MaChiTietSD = "";
               try { _MaChiTietSD = tbMaCTSD.Text; }
               catch { }
               string _MaCTDK = "";
               try { _MaCTDK = cBEMaCTDK.Text; }
               catch { }
               string _MaTTB = "";
               try { _MaTTB = CBEMaTTB.Text; }
               catch { }

               if (flagThemCTSD == 1)
               {
                    if (cBEMaCTDK.Text == "" || CBEMaTTB.Text == "" )
                    {
                         MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVChiTietSuDungCtrl.InsertChiTietSuDung(_MaChiTietSD, _MaCTDK, _MaTTB);
                         if (i != 0)
                         {
                              MessageBox.Show("Thêm chi tiết sử dụng thành công", "Thông báo");
                              ChiTietSuDung_Load();
                         }
                         else MessageBox.Show("Thêm chi tiết sử dụng thất bại", "Thông báo");
                    }
               }
               else
               {
                    if (cBEMaCTDK.Text == "" || CBEMaTTB.Text == "")
                    {
                         MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVChiTietSuDungCtrl.UpdateChiTietSuDung(_MaChiTietSD, _MaCTDK, _MaTTB);
                         if (i == 1)
                         {
                              MessageBox.Show("Sửa chi tiết sử dụng thành công", "Thông báo");
                              ChiTietSuDung_Load();
                         }
                         else MessageBox.Show("Sửa chi tiết sử dụng thất bại", "Thông báo");
                    }
               }
          }

          private void bHuy_Click(object sender, EventArgs e)
          {
               getThongTinChiTietSuDung();
               flagThemCTSD = 0;
               dis_enableCTSD(true);
          }


          private void CBEMaTTB_Click(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbMaTTB, pnMaTTB);
          }

          private void CBEMaTTB_Validated(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbMaTTB, pnMaTTB);
          }

          private void simpleButton1_Click(object sender, EventArgs e)
          {
               LoadData();
          }

          private void CBEMaTTB_SelectedIndexChanged(object sender, EventArgs e)
          {
               textBox1.Text = context.Database.SqlQuery<string>("SELECT TenTTB FROM dbo.TrangThietBi WHERE MaTTB = '" + CBEMaTTB.Text + "'").FirstOrDefault();
          }
     }
}
