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
using QLPhongThiNghhiem.Properties;
using DevExpress.Utils.Extensions;
using DevExpress.Utils;
using QLPhongThiNghhiem.Models;

namespace QLPhongThiNghhiem.Views
{
     public partial class XUCNVHeThongPhong : DevExpress.XtraEditors.XtraUserControl
     {
          public XUCNVHeThongPhong()
          {
               InitializeComponent();
          }

          public static XUCNVHeThongPhong xUCNVHeThongPhong = new XUCNVHeThongPhong();

          private DBContext.DBPTNContext context = new DBContext.DBPTNContext();

          PhongThiNghiem[] listPhong = new PhongThiNghiem[20];
          int phongChon = 0;
          int flagThem = 0;
          int soPhong = 0;

          //Chưa xong đâu
          public void getPhongThiNghiem()
          {
               List<Models.NVHeThongPhongMod> listPTN = Models.NVHeThongPhongMod.getPhongThiNghiem();
               soPhong = listPTN.Count;
               if (soPhong <= 0) phongChon = -1;
               fLP1.Controls.Clear();
               fLP2.Controls.Clear();
               fLP1.Height = (soPhong + 1) * 175;
               fLP2.Height = (soPhong + 1) * 175;
               for (int i = 0; i < soPhong; i++)
               {
                    listPhong[i] = new PhongThiNghiem();
                    listPhong[i].STT = i;
                    listPhong[i].MaPhong = listPTN[i].MaPhong;
                    listPhong[i].TenPhong = listPTN[i].TenPhong;
                    listPhong[i].ViTri = listPTN[i].ViTri;
                    listPhong[i].TongTTB = listPTN[i].TongTTB;
                    listPhong[i].TongCaSD = listPTN[i].TongCSD;
                    listPhong[i].MaPhong = listPTN[i].MaPhong;
                    listPhong[i].AnhPTN = QLPhongThiNghhiem.Properties.Resources.PTN1;
                    if (i % 2 == 0) fLP1.Controls.Add(listPhong[i]);
                    else fLP2.Controls.Add(listPhong[i]);
                    listPhong[i].PTN_Click += new PTNClickEventHandler(setSTTPhongClick);
               }
               getThongTinPTN();
          }

          public void setSTTPhongClick(object sender, PTNClickEventArgs e)
          {
               if(phongChon >= 0) listPhong[phongChon].AnhPTN = QLPhongThiNghhiem.Properties.Resources.PTN1;
               phongChon = e.getSTT;
               getThongTinPTN();
          }
          public void getThongTinPTN()
          {
               if (phongChon > -1)
               {
                    listPhong[phongChon].AnhPTN = QLPhongThiNghhiem.Properties.Resources.PTN2;
                    tbMaPhong.Text = listPhong[phongChon].MaPhong;
                    tbTenPhong.Text = listPhong[phongChon].TenPhong;
                    tbViTri.Text = listPhong[phongChon].ViTri;
                    tbTongTTB.Text = listPhong[phongChon].TongTTB.ToString();
                    tbTongCaSD.Text = listPhong[phongChon].TongCaSD.ToString();
               }
               else
               {
                    tbMaPhong.Text = "";
                    tbTenPhong.Text = "";
                    tbViTri.Text = "";
                    tbTongTTB.Text = "";
                    tbTongCaSD.Text = "";
               }
               dis_enable(true);
          }

          public void LoadData()
          {
               phanQuyen();
               getPhongThiNghiem();
          }

          private void XUCNVHeThongPhong_Load(object sender, EventArgs e)
          {
               LoadData();
          }

          public void phanQuyen()
          {
               bool quyenAdmin = false;
               if (HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "admin") quyenAdmin = true;
               bThem.Visible = quyenAdmin;
               bSua.Visible = quyenAdmin;
               bXoa.Visible = quyenAdmin;
               bLuu.Visible = quyenAdmin;
               bHuy.Visible = quyenAdmin;
               if(HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "Giáo viên")
               {
                    hlLCThêmTTB.Visible = false;
                    lLDangKySDPhong.Visible = true;
               }
               else
               {
                    hlLCThêmTTB.Visible = true;
                    lLDangKySDPhong.Visible = false;
               }                    
          }

          public void dis_enable(bool e) //e = true: ko them, sua. e = false = them, sua 
          {
               bThem.Enabled = e;
               bSua.Enabled = e;
               bXoa.Enabled = e;
               bLuu.Enabled = !e;
               bHuy.Enabled = !e;
               tbTenPhong.Enabled = !e;
               tbViTri.Enabled = !e;
          }

          private void tbTenPhong_GotFocus(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbTenPhong, pnTenPhong);
          }

          private void tbTenPhong_LostFocus(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbTenPhong, pnTenPhong);
          }

          private void tbViTri_GotFocus(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbViTri, pnViTri);
          }

          private void tbViTri_LostFocus(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbViTri, pnViTri);
          }

          private void bThem_Click(object sender, EventArgs e)
          {
               flagThem = 1;
               dis_enable(false);
               tbMaPhong.Text = context.Database.SqlQuery<string>("spGetMaPhongThiNghiem").FirstOrDefault();
               tbTenPhong.Text = "";
               tbViTri.Text = "";
               tbTongCaSD.Text = "0";
               tbTongTTB.Text = "0";
               tbTenPhong.Focus();
          }

          private void bSua_Click(object sender, EventArgs e)
          {
               flagThem = 0;
               dis_enable(false);
               tbTenPhong.Focus();
          }

          private void bXoa_Click(object sender, EventArgs e)
          {
               if(int.Parse(tbTongTTB.Text) > 0)
               {
                    MessageBox.Show("Phòng thí nghiệm đang có Trang thiết bị cần quản lý.\nKhông thể xóa!", "Thông báo", MessageBoxButtons.OK);
                    return;
               }

               DialogResult dr = MessageBox.Show("Xóa phòng thí nghiệm sẽ xóa các Ca sử dụng thuộc phòng này.\nBạn có chắc chắn xóa?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (dr == DialogResult.Yes)
               {
                    int i = Controllers.NVHeThongPhongCtrl.DetelePhongThiNghiem(tbMaPhong.Text);
                    if (i == 1)
                    {
                         MessageBox.Show("Xóa thành công!", "Thông báo");
                         getPhongThiNghiem();
                    }
                    else MessageBox.Show("Xóa không thành công.");

               }
               else
                    return;
          }

          private void bLuu_Click(object sender, EventArgs e)
          {
               string _MaPhong = "";
               try { _MaPhong = tbMaPhong.Text; }
               catch { }
               string _TenPhong = "";
               try { _TenPhong = tbTenPhong.Text; }
               catch { }
               string _ViTri = "";
               try { _ViTri = tbViTri.Text; }
               catch { }

               if (flagThem == 1)
               {
                    if (tbTenPhong.Text == "" || tbViTri.Text == "")
                    {
                         MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                         tbTenPhong.Focus();
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVHeThongPhongCtrl.InsertPhongThiNghiem(_MaPhong, _TenPhong, _ViTri);
                         if (i == 1)
                         {
                              MessageBox.Show("Thêm phòng thí nghiệm thành công", "Thông báo");
                              phongChon = soPhong;
                              getPhongThiNghiem();
                         }
                         else MessageBox.Show("Thêm phòng thí nghiệm thất bại", "Thông báo");
                    }
               }
               else
               {
                    if (tbTenPhong.Text == "" || tbViTri.Text == "")
                    {
                         MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                         tbTenPhong.Focus();
                         return;
                    }
                    else
                    {
                         int i = Controllers.NVHeThongPhongCtrl.UpdatePhongThiNghiem(_MaPhong, _TenPhong, _ViTri);
                         if (i == 1)
                         {
                              MessageBox.Show("sửa phòng thí nghiệm thành công", "Thông báo");
                              getPhongThiNghiem();
                         }
                         else MessageBox.Show("sửa phòng thí nghiệm thất bại", "Thông báo");
                    }
               }
          }

          private void bHuy_Click(object sender, EventArgs e)
          {
               getThongTinPTN();
               flagThem = 0;
               dis_enable(true);
          }
     }
}
