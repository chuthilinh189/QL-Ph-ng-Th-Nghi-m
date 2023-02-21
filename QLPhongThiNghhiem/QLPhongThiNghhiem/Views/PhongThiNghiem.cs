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
     public delegate void PTNClickEventHandler(object sender, PTNClickEventArgs e);

     public partial class PhongThiNghiem : DevExpress.XtraEditors.XtraUserControl
     {
          public PhongThiNghiem()
          {
               InitializeComponent();
          }

          #region Myproperties

          private int _STT;

          [Category("PTN Props")]
          public int STT
          {
               get { return _STT; }
               set { _STT = value; }
          }


          private string _tenPhong;

          [Category("PTN Props")]
          public string TenPhong
          {
               get { return _tenPhong; }
               set { _tenPhong = value; lbTenPhong.Text = value; }
          }

          private string _maPhong;

          [Category("PTN Props")]
          public string MaPhong
          {
               get { return _maPhong; }
               set { _maPhong = value; lbMaPhong.Text = value; }
          }

          private string _viTri;

          [Category("PTN Props")]
          public string ViTri
          {
               get { return _viTri; }
               set { _viTri = value; lbViTri.Text = value; }
          }

          private int _tongTTB;

          [Category("PTN Props")]
          public int TongTTB
          {
               get { return _tongTTB; }
               set { _tongTTB = value; lbTongTTB.Text = value.ToString(); }
          }

          private int _tongCaSD;

          [Category("PTN Props")]
          public int TongCaSD
          {
               get { return _tongCaSD; }
               set { _tongCaSD = value; lbSoCaSD.Text = value.ToString(); }
          }

          private Image _AnhPTN;

          [Category("PTN Props")]
          public Image AnhPTN
          {
               get { return _AnhPTN; }
               set { _AnhPTN = value; pictureBox.Image = value; }
          }


          #endregion

          [Browsable(true)]
          public event PTNClickEventHandler PTN_Click;

          private void pictureBox_Click(object sender, EventArgs e)
          {
               PTNClickEventArgs arg = new PTNClickEventArgs(STT);
               this.PTN_Click(sender, arg);
          }
     }

     public class PTNClickEventArgs : EventArgs
     {
          private int STT;
          public PTNClickEventArgs(int _STT)
          {
               STT = _STT;
          }

          public int getSTT { get { return STT; } }
     }
}
