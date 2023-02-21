namespace QLPhongThiNghhiem.Views
{
     partial class FormDangXuat
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
               this.label3 = new System.Windows.Forms.Label();
               this.label2 = new System.Windows.Forms.Label();
               this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
               this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
               this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
               this.label1 = new System.Windows.Forms.Label();
               ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
               this.panelControl1.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
               this.SuspendLayout();
               // 
               // panelControl1
               // 
               this.panelControl1.Controls.Add(this.label3);
               this.panelControl1.Controls.Add(this.label2);
               this.panelControl1.Controls.Add(this.separatorControl1);
               this.panelControl1.Controls.Add(this.simpleButton2);
               this.panelControl1.Controls.Add(this.simpleButton1);
               this.panelControl1.Controls.Add(this.label1);
               this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
               this.panelControl1.Location = new System.Drawing.Point(0, 0);
               this.panelControl1.LookAndFeel.SkinName = "Glass Oceans";
               this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
               this.panelControl1.Name = "panelControl1";
               this.panelControl1.Size = new System.Drawing.Size(532, 209);
               this.panelControl1.TabIndex = 1;
               // 
               // label3
               // 
               this.label3.AutoSize = true;
               this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label3.ForeColor = System.Drawing.Color.DimGray;
               this.label3.Location = new System.Drawing.Point(133, 94);
               this.label3.Name = "label3";
               this.label3.Size = new System.Drawing.Size(164, 18);
               this.label3.TabIndex = 4;
               this.label3.Text = "Đóng các trang hiện tại.";
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label2.ForeColor = System.Drawing.Color.DimGray;
               this.label2.Location = new System.Drawing.Point(133, 74);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(261, 18);
               this.label2.TabIndex = 4;
               this.label2.Text = "Đăng xuất sẽ kết thúc phiên làm việc. ";
               // 
               // separatorControl1
               // 
               this.separatorControl1.Location = new System.Drawing.Point(98, 48);
               this.separatorControl1.LookAndFeel.SkinName = "Liquid Sky";
               this.separatorControl1.LookAndFeel.UseDefaultLookAndFeel = false;
               this.separatorControl1.Name = "separatorControl1";
               this.separatorControl1.Size = new System.Drawing.Size(307, 23);
               this.separatorControl1.TabIndex = 3;
               // 
               // simpleButton2
               // 
               this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
               this.simpleButton2.Appearance.Options.UseFont = true;
               this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.No;
               this.simpleButton2.Location = new System.Drawing.Point(327, 135);
               this.simpleButton2.Name = "simpleButton2";
               this.simpleButton2.Size = new System.Drawing.Size(99, 34);
               this.simpleButton2.TabIndex = 2;
               this.simpleButton2.Text = "Hủy";
               this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
               // 
               // simpleButton1
               // 
               this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
               this.simpleButton1.Appearance.Options.UseFont = true;
               this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Yes;
               this.simpleButton1.Location = new System.Drawing.Point(98, 135);
               this.simpleButton1.Name = "simpleButton1";
               this.simpleButton1.Size = new System.Drawing.Size(102, 34);
               this.simpleButton1.TabIndex = 1;
               this.simpleButton1.Text = "Xác nhận";
               this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
               this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(167)))), ((int)(((byte)(246)))));
               this.label1.Location = new System.Drawing.Point(156, 25);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(201, 22);
               this.label1.TabIndex = 0;
               this.label1.Text = "Xác nhận đăng xuất?";
               // 
               // FormDangXuat
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(532, 209);
               this.ControlBox = false;
               this.Controls.Add(this.panelControl1);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
               this.Name = "FormDangXuat";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "FormDangXuat";
               ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
               this.panelControl1.ResumeLayout(false);
               this.panelControl1.PerformLayout();
               ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
               this.ResumeLayout(false);

          }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label1;
    }
}