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
using QLPhongThiNghhiem.Models;
using System.IO;
using DevExpress.Xpo;
using System.Data.SqlClient;

namespace QLPhongThiNghhiem.Views
{
     public partial class XUCQLGiaoVien : DevExpress.XtraEditors.XtraUserControl
     {
          public XUCQLGiaoVien()
          {
               InitializeComponent();
          }

          public static XUCQLGiaoVien xUCQLGiaoVien = new XUCQLGiaoVien();
          private DBContext.DBPTNContext context = new DBContext.DBPTNContext();
          int flagThem = 0;

          public void getGiaoVien()
          {
               dGVQLGiaoVien.DataSource = Models.QLGiaoVienMod.getGiaoVien();
          }

          private void XUCQLGiaoVien_Load(object sender, EventArgs e)
          {
               LoadData();
          }

          public void LoadData()
          {
               phanQuyen();
               getGiaoVien();
               tEMaGV.Text = dGVQLGiaoVien.CurrentCell.Value.ToString();
               HTThongTinGiaoVienMod tttk = new HTThongTinGiaoVienMod(tEMaGV.Text);
               tttk.GetThongTinGiaoVien(tttk.MaGV);
               pBHinhAnh.Image = Resources.Funtion.convertBytesToImage(tttk.HinhAnh);
               tEHoTen.Text = tttk.HoTen;
               tEGioiTinh.Text = tttk.GioiTinh;
               tESDT.Text = tttk.SDT;
               dENgaySinh.EditValue = tttk.NgaySinh;
               tEEmail.Text = tttk.Email;
               tEDiaChi.Text = tttk.DiaChi;
               tEGioiThieu.Text = tttk.GioiThieu;
               dis_enable(true);
          }

          public void getThongTinGiaoVien()
          {
               tEMaGV.DataBindings.Clear();
               tEMaGV.DataBindings.Add("Text", dGVQLGiaoVien.DataSource, "MaGV");
               HTThongTinGiaoVienMod tttk = new HTThongTinGiaoVienMod(tEMaGV.Text);
               tttk.GetThongTinGiaoVien(tttk.MaGV);
               pBHinhAnh.Image = Resources.Funtion.convertBytesToImage(tttk.HinhAnh);
               tEHoTen.Text = tttk.HoTen;
               tEGioiTinh.Text = tttk.GioiTinh;
               tESDT.Text = tttk.SDT;
               dENgaySinh.EditValue = tttk.NgaySinh;
               tEEmail.Text = tttk.Email;
               tEDiaChi.Text = tttk.DiaChi;
               tEGioiThieu.Text = tttk.GioiThieu;
          }

          public void phanQuyen()
          {
               bool quyenAdmin = false;
               if (HTTaiKhoanGanDayMod.taiKhoanGanDay.Quyen == "admin") quyenAdmin = true;
               sBThem.Visible = quyenAdmin;
               sBSua.Visible = quyenAdmin;
               sBXoa.Visible = quyenAdmin;
               sBLuu.Visible = quyenAdmin;
               sBHuy.Visible = quyenAdmin;
               sBReset.Visible = quyenAdmin;
               if (quyenAdmin) panelGV.Location = new Point(853, 61);
               else panelGV.Location = new Point(853, 85);
          }

          public void dis_enable(bool e) //e = true: ko them, sua. e = false = them, sua 
          {
               sBThem.Enabled = e;
               sBSua.Enabled = e;
               sBXoa.Enabled = e;
               sBReset.Enabled = !e;
               sBLuu.Enabled = !e;
               sBHuy.Enabled = !e;
               tEHoTen.Enabled = !e;
               tEGioiTinh.Enabled = !e;
               tESDT.Enabled = !e;
               dENgaySinh.Enabled = !e;
               tEEmail.Enabled = !e;
               tEDiaChi.Enabled = !e;
               tEGioiThieu.Enabled = !e;
               hlLCLoadAnh.Visible = !e;
          }

          public void reset()
          {
               if (flagThem == 1)
               {
                    pBHinhAnh.Image = null;
               }
               tEHoTen.Text = "";
               tEGioiTinh.EditValue = "Khác";
               tESDT.Text = "";
               dENgaySinh.EditValue = "";
               tEEmail.Text = "";
               tEDiaChi.Text = "";
               tEGioiThieu.Text = "";
          }

          private void sBReset_Click(object sender, EventArgs e)
          {
               if (flagThem == 1) reset();
               else getThongTinGiaoVien();
          }

          private void sBThem_Click(object sender, EventArgs e)
          {
               tEMaGV.Text = context.Database.SqlQuery<string>("spGetMaGiaoVien").FirstOrDefault();
               flagThem = 1;
               dis_enable(false);
               reset();
          }

          private void sBSua_Click(object sender, EventArgs e)
          {
               flagThem = 0;
               dis_enable(false);
               tEMaGV.Enabled = false;
          }

          private void sBHuy_Click(object sender, EventArgs e)
          {
               if (flagThem == 1) getGiaoVien();
               getThongTinGiaoVien();
               flagThem = 0;
               dis_enable(true);
          }

          private void dGVQLGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
          {
               getThongTinGiaoVien();
               flagThem = 0;
               dis_enable(true);
          }

          private void sBXoa_Click(object sender, EventArgs e)
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaGV", tEMaGV.Text));
               int QuanLyCSD = context.Database.SqlQuery<int>("spCountGVDangKySD @MaGV", paralist.ToArray()).FirstOrDefault();
               if (QuanLyCSD > 0)
               {
                    MessageBox.Show("Giáo viên này đã có bản đăng ký.\nKhông thể xóa!", "Thông báo", MessageBoxButtons.OK);
                    return;
               }

               DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (dr == DialogResult.Yes)
               {
                    int i = Controllers.HTThongTinGiaoVienCtrl.DeteleGiaoVien(tEMaGV.Text);
                    if (i == 1)
                    {
                         MessageBox.Show("Xóa thành công!", "Thông báo");
                         getGiaoVien();
                         getThongTinGiaoVien();
                    }
                    else MessageBox.Show("Xóa không thành công.");

               }
               else
                    return;

          }

          private void sBLuu_Click(object sender, EventArgs e)
          {
               Image _HinhAnh = null;
               try { _HinhAnh = pBHinhAnh.Image; }
               catch { }
               string _MaGV = "";
               try { _MaGV = tEMaGV.Text; }
               catch { }
               string _HoTen = "";
               try { _HoTen = tEHoTen.Text; }
               catch { }
               string _GioiTinh = "";
               try { _GioiTinh = tEGioiTinh.Text; }
               catch { }
               string _SDT = "";
               try { _SDT = tESDT.Text; }
               catch { }
               DateTime _NgaySinh = DateTime.Today;
               try
               {
                    if (dENgaySinh.Text == "")
                    {
                         MessageBox.Show("Nhập đúng ngày!", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    _NgaySinh = dENgaySinh.DateTime;
               }
               catch
               {

               }
               string _Email = "";
               try { _Email = tEEmail.Text; }
               catch { }
               string _DiaChi = "";
               try { _DiaChi = tEDiaChi.Text; }
               catch { }
               string _GioiThieu = "";
               try { _GioiThieu = tEGioiThieu.Text; }
               catch { }
               if (flagThem == 1)
               {
                    if (tEMaGV.Text == "" || tEHoTen.Text == "")
                    {
                         MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.HTThongTinGiaoVienCtrl.InsertGiaoVien(_MaGV, _HinhAnh, _HoTen, _GioiTinh, _SDT, _NgaySinh, _Email, _DiaChi, _GioiThieu);
                         if (i == 1)
                         {
                              MessageBox.Show("Thêm giáo viên thành công", "Thông báo");
                              XUCQLGiaoVien_Load(sender, e);
                         }
                         else MessageBox.Show("Thêm giáo viên thất bại", "Thông báo");
                    }
               }
               else
               {
                    if (tEHoTen.Text == "")
                    {
                         MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.HTThongTinGiaoVienCtrl.UpdateGiaoVien(_MaGV, _HinhAnh, _HoTen, _GioiTinh, _SDT, _NgaySinh, _Email, _DiaChi, _GioiThieu);
                         if (i == 1)
                         {
                              MessageBox.Show("Sửa thông tin giáo viên thành công", "Thông báo");
                              XUCQLGiaoVien_Load(sender, e);
                         }
                         else MessageBox.Show("Sửa thông tin giáo viên thất bại", "Thông báo");
                    }
               }
          }

          private void hlLCLoadAnh_Click(object sender, EventArgs e)
          {
               OpenFileDialog open = new OpenFileDialog();
               open.Filter = "JPG files (*.ipg) |*.jpg|All files (*.*)|*.*";
               open.FilterIndex = 1;
               open.RestoreDirectory = true;
               if (open.ShowDialog() == DialogResult.OK)
               {
                    pBHinhAnh.ImageLocation = open.FileName;
               }
          }
     }
}
