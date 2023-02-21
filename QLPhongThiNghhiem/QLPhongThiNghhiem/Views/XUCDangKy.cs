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

namespace QLPhongThiNghhiem.Views
{
     public partial class XUCDangKy : DevExpress.XtraEditors.XtraUserControl
     {
          public XUCDangKy()
          {
               InitializeComponent();
          }

          public static XUCDangKy xUCDangKy = new XUCDangKy();

          public event DevExpress.XtraBars.ItemClickEventHandler chuyenDangNhap;

          private void hlLCDangNhap_Click(object sender, EventArgs e)
          {
               this.chuyenDangNhap(sender, null);
          }
     }
}
