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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using QLPhongThiNghhiem.Models;

namespace QLPhongThiNghhiem.Views
{
     public partial class XUCHTDoiMatKhau : DevExpress.XtraEditors.XtraUserControl
     {

          static DBContext.DBPTNContext context = new DBContext.DBPTNContext();
          public XUCHTDoiMatKhau()
          {
               InitializeComponent();
          }

          public static XUCHTDoiMatKhau xUCHTDoiMatKhau = new XUCHTDoiMatKhau();

          private void XUCHTDoiMatKhau_Load(object sender, EventArgs e)
          {
               LoadData();
          }

          public void LoadData()
          {
               xUCHTDoiMatKhau = new XUCHTDoiMatKhau();
               Resources.Funtion.chon(lbMatKhauHienTai);
               Resources.Funtion.chon(pnMatKhauHienTai);
               tEMatKhauHienTai.Focus();
          }

          private void pnMatKhauHienTai_Click(object sender, EventArgs e)
          {
               tEMatKhauHienTai.Focus();
          }

          private void pnMatKhauMoi_Click(object sender, EventArgs e)
          {
               tEMatKhauMoi.Focus();
          }

          private void tEMatKhauXacNhan_Click(object sender, EventArgs e)
          {
               tEMatKhauXacNhan.Focus();
          }

          private void pBHienMK_Click(object sender, EventArgs e)
          {
               tEMatKhauMoi.Properties.UseSystemPasswordChar = !tEMatKhauMoi.Properties.UseSystemPasswordChar;
               if (tEMatKhauMoi.Properties.UseSystemPasswordChar == true)
               {
                    pBHienMK.Image = QLPhongThiNghhiem.Properties.Resources.hide;
               }
               else
               {
                    pBHienMK.Image = QLPhongThiNghhiem.Properties.Resources.eye;
               }
          }

          private void pBHienMK2_Click(object sender, EventArgs e)
          {
               tEMatKhauXacNhan.Properties.UseSystemPasswordChar = !tEMatKhauXacNhan.Properties.UseSystemPasswordChar;
               if (tEMatKhauXacNhan.Properties.UseSystemPasswordChar == true)
               {
                    pBHienMK2.Image = QLPhongThiNghhiem.Properties.Resources.hide;
               }
               else
               {
                    pBHienMK2.Image = QLPhongThiNghhiem.Properties.Resources.eye;
               }
          }

          private void simpleButton1_Click(object sender, EventArgs e)
          {
               if (lbDoManh.Text == "Yếu" || lbKhongHopLe.Visible == true || lbMKKhongKhop.Visible == true) return;
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@TenDN", HTTaiKhoanGanDayMod.taiKhoanGanDay.TenDN));
               paralist.Add(new SqlParameter("@MatKhauCu", tEMatKhauHienTai.Text));
               paralist.Add(new SqlParameter("@MatKhauMoi", tEMatKhauMoi.Text));
               string maTk = context.Database.SqlQuery<string>("spDoiMatKhau @TenDN, @MatKhauCu, @MatKhauMoi", paralist.ToArray()).FirstOrDefault();
               if(maTk == HTTaiKhoanGanDayMod.taiKhoanGanDay.MaTK)
               {
                    MessageBox.Show("Đổi mật khẩu thành công", "Thành Công");
               }
               else
               {
                    lbMatKhauKoDung.Visible = true;
                    tEMatKhauHienTai.Focus();
               }
          }

          private void pBHienMK0_Click(object sender, EventArgs e)
          {
               tEMatKhauHienTai.Properties.UseSystemPasswordChar = !tEMatKhauHienTai.Properties.UseSystemPasswordChar;
               if (tEMatKhauHienTai.Properties.UseSystemPasswordChar == true)
               {
                    pBHienMK0.Image = QLPhongThiNghhiem.Properties.Resources.hide;
               }
               else
               {
                    pBHienMK0.Image = QLPhongThiNghhiem.Properties.Resources.eye;
               }
          }
                    

          public void tEMatKhauHienTai_GotFocus(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbMatKhauHienTai);
               Resources.Funtion.chon(pnMatKhauHienTai);
          }

          public void tEMatKhauXacNhan_GotFocus(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbXacNhanMK);
               Resources.Funtion.chon(pnXacNhanMK);
          }

          public void tEMatKhauMoi_GotFocus(object sender, EventArgs e)
          {
               Resources.Funtion.chon(lbMatKhauMoi);
               Resources.Funtion.chon(pnMatKhauMoi);
          }

          public void tEMatKhauHienTai_LostFocus(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbMatKhauHienTai);
               Resources.Funtion.khongChon(pnMatKhauHienTai);
          }

          public void tEMatKhauXacNhan_LostFocus(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbXacNhanMK);
               Resources.Funtion.khongChon(pnXacNhanMK);
          }

          public void tEMatKhauMoi_LostFocus(object sender, EventArgs e)
          {
               Resources.Funtion.khongChon(lbMatKhauMoi);
               Resources.Funtion.khongChon(pnMatKhauMoi);
          }

          private void tEMatKhauMoi_Validated(object sender, EventArgs e)
          {
               if (tEMatKhauMoi.Text.Length < 6)
               {
                    lbDoManh.Text = "Yếu";
                    lbDoManh.ForeColor = Color.Red;
                    tEMatKhauMoi.Focus();
                    return;
               }
               else if (tEMatKhauMoi.Text.Length < 12)
               {
                    lbDoManh.Text = "Trung bình";
                    lbDoManh.ForeColor = Color.DimGray;
               }
               else
               {
                    lbDoManh.Text = "Mạnh";
                    lbDoManh.ForeColor = Color.DimGray;
               }
               string regerString = @"\W";
               if (Regex.IsMatch(tEMatKhauMoi.Text, regerString))
               {
                    lbKhongHopLe.Visible = true;
                    tEMatKhauMoi.Focus();
               }
               else lbKhongHopLe.Visible = false;
          }

          private void tEMatKhauXacNhan_Validated(object sender, EventArgs e)
          {
               if (tEMatKhauXacNhan.Text == tEMatKhauMoi.Text)
                    lbMKKhongKhop.Visible = false;
               else
               {
                    lbMKKhongKhop.Visible = true;
                    tEMatKhauXacNhan.Focus();
               }
          }
     }
}
