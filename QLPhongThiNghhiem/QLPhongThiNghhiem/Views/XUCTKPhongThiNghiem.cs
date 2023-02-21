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
     public partial class XUCTKPhongThiNghiem : DevExpress.XtraEditors.XtraUserControl
     {
          public XUCTKPhongThiNghiem()
          {
               InitializeComponent();
          }
          public static XUCTKPhongThiNghiem xUCTKPhongThiNghiem = new XUCTKPhongThiNghiem();
          Models.TKPhongThiNghiemMod PTNTB;
          private DBContext.DBPTNContext context = new DBContext.DBPTNContext();

          private void XUCTKPhongThiNghiem_Load(object sender, EventArgs e)
          {
               TKPhongThiNghiem_Load();
          }

          public void TKPhongThiNghiem_Load()
          {
               dGVTKPhongThiNghiem.DataSource = Models.TKPhongThiNghiemMod.getThongKePhongThiNghiem(dNgayBatDau.DateTime, dNgayKetThuc.DateTime);
               dGVTKPhongThiNghiem.RefreshEdit();
               PTNTB = Models.TKPhongThiNghiemMod.getThongKePhongThiNghiemTK(dNgayBatDau.DateTime, dNgayKetThuc.DateTime);
               lbTongTTB.Text = PTNTB.TongTTB.ToString();
               lbChatLuongTTBTB.Text = PTNTB.ChatLuongTTB.ToString();
               lbTongSoCaSDTB.Text = PTNTB.TongCaSuDung.ToString();
               lbTongTTBCacPhong.Text = context.Database.SqlQuery<int>("spCountTongTTB").FirstOrDefault().ToString();
               
               List<SqlParameter> paralist = new List<SqlParameter>();
               paralist.Add(new SqlParameter("@NgayBatDau", dNgayBatDau.DateTime));
               paralist.Add(new SqlParameter("@NgayKetThuc", dNgayKetThuc.DateTime));
               lbTongCSDCacPhong.Text = context.Database.SqlQuery<int>("spCountTongCSD @NgayBatDau, @NgayKetThuc", paralist.ToArray()).FirstOrDefault().ToString();

               BieuDo_Load();
          }
          public void BieuDo_Load()
          {
               lbTongTTBTB.DataSource = Models.TKPhongThiNghiemMod.getThongKePhongThiNghiem(dNgayBatDau.DateTime, dNgayKetThuc.DateTime);
               lbTongTTBTB.Series["Tổng Số TTB"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
               lbTongTTBTB.Series["Tổng Số TTB"].XValueMember = "TenPhong";
               lbTongTTBTB.Series["Tổng Số TTB"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
               lbTongTTBTB.Series["Tổng Số TTB"].YValueMembers = "TongTTB";
               lbTongTTBTB.Series["Chất Lượng TTB"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
               lbTongTTBTB.Series["Chất Lượng TTB"].YValueMembers = "ChatLuongTTB";
               lbTongTTBTB.Series["Tổng Số Ca SD"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
               lbTongTTBTB.Series["Tổng Số Ca SD"].YValueMembers = "TongCaSuDung";
               lbTongTTBTB.Series["Tổng Số TTB"].Enabled = checkBox1.Checked;
               lbTongTTBTB.Series["Chất Lượng TTB"].Enabled = checkBox2.Checked;
               lbTongTTBTB.Series["Tổng Số Ca SD"].Enabled = checkBox3.Checked;
          }


          private void dNgayBatDau_EditValueChanged(object sender, EventArgs e)
          {
               TKPhongThiNghiem_Load();
          }

          private void dNgayKetThuc_EditValueChanged(object sender, EventArgs e)
          {
               TKPhongThiNghiem_Load();
          }


          private void checkBox1_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false) checkBox1.Checked = true;
               BieuDo_Load();
          }

          private void checkBox2_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false) checkBox2.Checked = true;
               BieuDo_Load();
          }

          private void checkBox3_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false) checkBox3.Checked = true;
               BieuDo_Load();
          }


          private void dGVTKPhongThiNghiem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
          {
               if (PTNTB != null)
               for (int i = 0; i < dGVTKPhongThiNghiem.Rows.Count; i++)
               {
                    decimal val = decimal.Parse(dGVTKPhongThiNghiem.Rows[i].Cells[comboBox1.SelectedIndex+1].Value.ToString());
                    decimal valTrungBinh = 0;
                    if (comboBox1.SelectedIndex == 0) valTrungBinh = PTNTB.TongTTB;
                    else if (comboBox1.SelectedIndex == 1) valTrungBinh = PTNTB.ChatLuongTTB;
                    else if (comboBox1.SelectedIndex == 2) valTrungBinh = PTNTB.TongCaSuDung;
                    
                    if (val > ((decimal)4 / 3 * valTrungBinh)) dGVTKPhongThiNghiem.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    else if (val < (decimal)2 / 3 * valTrungBinh) dGVTKPhongThiNghiem.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    else dGVTKPhongThiNghiem.Rows[i].DefaultCellStyle.BackColor = Color.Bisque;
               }
          }

          private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
          {
               dGVTKPhongThiNghiem.RefreshEdit();
          }

          private void simpleButton1_Click(object sender, EventArgs e)
          {
               TKPhongThiNghiem_Load();
          }
    }
}
