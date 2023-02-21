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

namespace QLPhongThiNghhiem.Views
{
     public partial class XUCTKLoaiTrangThietBi : DevExpress.XtraEditors.XtraUserControl
     {
          public XUCTKLoaiTrangThietBi()
          {
               InitializeComponent();
          }
          public static XUCTKLoaiTrangThietBi xUCTKLoaiTrangThietBi = new XUCTKLoaiTrangThietBi();
          Models.TKLoaiTrangThietBiMod LTTBTB;
          private DBContext.DBPTNContext context = new DBContext.DBPTNContext();

          private void XUCTKLoaiTrangThietBi_Load(object sender, EventArgs e)
          {
               TKLoaiTrangThietBi_Load();
          }

          public void TKLoaiTrangThietBi_Load()
          {
               dGVTKLoaiTrangThietBi.DataSource = Models.TKLoaiTrangThietBiMod.getThongKeLoaiTrangThietBi(dNgayBatDau.DateTime, dNgayKetThuc.DateTime);
               dGVTKLoaiTrangThietBi.RefreshEdit();
               LTTBTB = Models.TKLoaiTrangThietBiMod.getThongKeLoaiTrangThietBiTB(dNgayBatDau.DateTime, dNgayKetThuc.DateTime);
               lbTongTTB.Text = LTTBTB.TongTTB.ToString();
               lbChatLuongTTBTB.Text = LTTBTB.ChatLuongTTB.ToString();
               lbTongSoCaSDTB.Text = LTTBTB.TongLuotSuDung.ToString();
               lbTTBHongTB.Text = LTTBTB.SoTTBHong.ToString();

               TongTTB.Text = context.Database.SqlQuery<int>("spCountTongTTB").FirstOrDefault().ToString();
               lbTongTTBHong.Text = context.Database.SqlQuery<int>("spCountTongTTBHong").FirstOrDefault().ToString();
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@NgayBatDau", dNgayBatDau.DateTime));
               paralist.Add(new SqlParameter("@NgayKetThuc", dNgayKetThuc.DateTime));
               TongLuotSD.Text = context.Database.SqlQuery<int>("spCountTongLuotSD @NgayBatDau, @NgayKetThuc", paralist.ToArray()).FirstOrDefault().ToString();

          }

          private void dNgayBatDau_EditValueChanged(object sender, EventArgs e)
          {
               TKLoaiTrangThietBi_Load();
          }

          private void dNgayKetThuc_EditValueChanged(object sender, EventArgs e)
          {
               TKLoaiTrangThietBi_Load();
          }

          private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
          {
               dGVTKLoaiTrangThietBi.Refresh();
          }

          private void dGVTKLoaiTrangThietBi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
          {
               if (LTTBTB != null)
                    for (int i = 0; i < dGVTKLoaiTrangThietBi.Rows.Count; i++)
                    {
                         decimal val = decimal.Parse(dGVTKLoaiTrangThietBi.Rows[i].Cells[comboBox1.SelectedIndex + 1].Value.ToString());
                         decimal valTrungBinh = 0;
                         if (comboBox1.SelectedIndex == 0) valTrungBinh = LTTBTB.TongTTB;
                         else if (comboBox1.SelectedIndex == 1) valTrungBinh = LTTBTB.SoTTBHong;
                         else if (comboBox1.SelectedIndex == 2) valTrungBinh = LTTBTB.ChatLuongTTB;
                         else if (comboBox1.SelectedIndex == 3) valTrungBinh = LTTBTB.TongLuotSuDung;

                         if (val > ((decimal)4 / 3 * valTrungBinh)) dGVTKLoaiTrangThietBi.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                         else if (val < (decimal)2 / 3 * valTrungBinh) dGVTKLoaiTrangThietBi.Rows[i].DefaultCellStyle.BackColor = Color.White;
                         else dGVTKLoaiTrangThietBi.Rows[i].DefaultCellStyle.BackColor = Color.Bisque;
                    }
          }

          private void simpleButton1_Click(object sender, EventArgs e)
          {
               TKLoaiTrangThietBi_Load();
          }
     }
}
