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
using DevExpress.Utils.Extensions;
using DevExpress.XtraExport.Helpers;
using System.Data.SqlClient;

namespace QLPhongThiNghhiem.Views
{
     public partial class XUCQLNhanVien : DevExpress.XtraEditors.XtraUserControl
     {
          public XUCQLNhanVien()
          {
               InitializeComponent();
          }

          public static XUCQLNhanVien xUCQLNhanVien = new XUCQLNhanVien();
          private DBContext.DBPTNContext context = new DBContext.DBPTNContext();

          int flagThem = 0;

          public void getNhanVien()
          {
               dGVQLNhanVien.DataSource = Models.QLNhanVienMod.getNhanVien();
          }

          public void getThongTinNhanVien()
          {
               tEMaNV.DataBindings.Clear();
               tEMaNV.DataBindings.Add("Text", dGVQLNhanVien.DataSource, "MaNV");
               HTThongTinTaiKhoanMod tttk = new HTThongTinTaiKhoanMod(tEMaNV.Text);
               tttk.GetThongTinTaiKhoan(tttk.MaNV);
               tEChucVu.Image = Resources.Funtion.convertBytesToImage(tttk.HinhAnh);
               comboBoxEdit1.Text = tttk.ChucVu;
               tEHoTen.Text = tttk.HoTen;
               tEGioiTinh.Text = tttk.GioiTinh;
               tESDT.Text = tttk.SDT;
               dENgaySinh.EditValue = tttk.NgaySinh;
               tEEmail.Text = tttk.Email;
               tEDiaChi.Text = tttk.DiaChi;
               tEGioiThieu.Text = tttk.GioiThieu;
          }

          private void XUCQLNhanVien_Load(object sender, EventArgs e)
          {
               LoadData();    
          }

          public void LoadData()
          {
               phanQuyen();
               getNhanVien();
               tEMaNV.Text = dGVQLNhanVien.CurrentCell.Value.ToString();
               HTThongTinTaiKhoanMod tttk = new HTThongTinTaiKhoanMod(tEMaNV.Text);
               tttk.GetThongTinTaiKhoan(tttk.MaNV);
               tEChucVu.Image = Resources.Funtion.convertBytesToImage(tttk.HinhAnh);
               tEChucVu.Text = tttk.ChucVu;
               tEHoTen.Text = tttk.HoTen;
               tEGioiTinh.Text = tttk.GioiTinh;
               tESDT.Text = tttk.SDT;
               dENgaySinh.EditValue = tttk.NgaySinh;
               tEEmail.Text = tttk.Email;
               tEDiaChi.Text = tttk.DiaChi;
               tEGioiThieu.Text = tttk.GioiThieu;
               dis_enable(true);
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
               if (quyenAdmin) panelNV.Location = new Point(853, 61);
               else panelNV.Location = new Point(853, 85);
          }

          public void dis_enable(bool e) //e = true: ko them, sua. e = false = them, sua 
          {
               sBThem.Enabled = e;
               sBSua.Enabled = e;
               sBXoa.Enabled = e;
               sBReset.Enabled = !e;
               sBLuu.Enabled = !e;
               sBHuy.Enabled = !e;
               comboBoxEdit1.Enabled = !e;
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
                    tEChucVu.Image = null;
               }
               comboBoxEdit1.Text = "";
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
               if(flagThem == 1) reset();
               else getThongTinNhanVien();
          }

          private void sBThem_Click(object sender, EventArgs e)
          {
               tEMaNV.Text = context.Database.SqlQuery<string>("spGetMaNhanVien").FirstOrDefault();
               flagThem = 1;
               dis_enable(false);
               reset();
          }

          private void sBSua_Click(object sender, EventArgs e)
          {
               flagThem = 0;
               dis_enable(false);
               tEMaNV.Enabled = false;
          }

          private void sBHuy_Click(object sender, EventArgs e)
          {
               if(flagThem == 1) getNhanVien();
               getThongTinNhanVien();
               flagThem = 0;
               dis_enable(true);
          }

          private void dGVQLNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
          {
               getThongTinNhanVien();
               flagThem = 0;
               dis_enable(true);
          }

          private void sBXoa_Click(object sender, EventArgs e)
          {
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@MaNV", tEMaNV.Text));
               int QuanLyCSD = context.Database.SqlQuery<int>("spCountNVQuanLyCSD @MaNV", paralist.ToArray()).FirstOrDefault();
               if(QuanLyCSD > 0)
               {
                    MessageBox.Show("Nhân viên này đang quản lý ca sử dụng.\nKhông thể xóa!", "Thông báo", MessageBoxButtons.OK);
                    return;
               }     

               DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (dr == DialogResult.Yes)
               {
                    int i = Controllers.HTThongTinTaiKhoanCtrl.DeteleNhanVien(tEMaNV.Text);
                    if (i == 1)
                    {
                         MessageBox.Show("Xóa thành công!", "Thông báo");
                         getNhanVien();
                         getThongTinNhanVien();
                    }
                    else MessageBox.Show("Xóa không thành công.");
                        
               }
               else
                    return;

          }

          private void sBLuu_Click(object sender, EventArgs e)
          {
               Image _HinhAnh = null;
               try { _HinhAnh = tEChucVu.Image; }
               catch { }
               string _MaNV = "";
               try { _MaNV = tEMaNV.Text; }
               catch { }
               string _ChucVu = "";
               try { _ChucVu = comboBoxEdit1.Text; }
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
                    if(dENgaySinh.Text == "")
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
                    if (tEMaNV.Text == "" || comboBoxEdit1.Text == "" || tEHoTen.Text == "")
                    {
                         MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.HTThongTinTaiKhoanCtrl.InsertNhanVien(_MaNV, _ChucVu, _HinhAnh, _HoTen, _GioiTinh, _SDT, _NgaySinh, _Email, _DiaChi, _GioiThieu);
                         if (i == 1)
                         {
                              MessageBox.Show("Thêm nhân viên thành công", "Thông báo");
                              XUCQLNhanVien_Load(sender, e);
                         }     
                         else MessageBox.Show("Thêm nhân viên thất bại", "Thông báo");
                    }
               }
               else
               {
                    if (comboBoxEdit1.Text == "" || tEHoTen.Text == "")
                    {
                         MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                         return;
                    }
                    else
                    {
                         int i = Controllers.HTThongTinTaiKhoanCtrl.UpdateNhanVien(_MaNV, _ChucVu, _HinhAnh, _HoTen, _GioiTinh, _SDT, _NgaySinh, _Email, _DiaChi, _GioiThieu);
                         if (i == 1)
                         {
                              MessageBox.Show("Sửa thông tin nhân viên thành công", "Thông báo");
                              XUCQLNhanVien_Load(sender, e);
                         }
                         else MessageBox.Show("Sửa thông tin nhân viên thất bại", "Thông báo");
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
                    tEChucVu.ImageLocation = open.FileName;
               }
        }

     }
}
