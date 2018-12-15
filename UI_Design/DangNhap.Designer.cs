namespace QLKhachSan
{
    partial class DangNhap
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.hienThiMatKhau = new System.Windows.Forms.CheckBox();
            this.dn = new System.Windows.Forms.Button();
            this.thoat = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.matKhau = new System.Windows.Forms.TextBox();
            this.maNV = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.hienThiMatKhau);
            this.panel1.Controls.Add(this.dn);
            this.panel1.Controls.Add(this.thoat);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.matKhau);
            this.panel1.Controls.Add(this.maNV);
            this.panel1.Location = new System.Drawing.Point(229, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 245);
            this.panel1.TabIndex = 6;
            // 
            // hienThiMatKhau
            // 
            this.hienThiMatKhau.AutoSize = true;
            this.hienThiMatKhau.Location = new System.Drawing.Point(186, 157);
            this.hienThiMatKhau.Name = "hienThiMatKhau";
            this.hienThiMatKhau.Size = new System.Drawing.Size(102, 17);
            this.hienThiMatKhau.TabIndex = 16;
            this.hienThiMatKhau.Text = "show passWord";
            this.hienThiMatKhau.UseVisualStyleBackColor = true;
            // 
            // dn
            // 
            this.dn.Location = new System.Drawing.Point(185, 196);
            this.dn.Name = "dn";
            this.dn.Size = new System.Drawing.Size(103, 31);
            this.dn.TabIndex = 15;
            this.dn.Text = "Đăng Nhập";
            this.dn.UseVisualStyleBackColor = true;
            this.dn.Click += new System.EventHandler(this.dn_Click);
            // 
            // thoat
            // 
            this.thoat.Location = new System.Drawing.Point(76, 196);
            this.thoat.Name = "thoat";
            this.thoat.Size = new System.Drawing.Size(103, 31);
            this.thoat.TabIndex = 14;
            this.thoat.Text = "Thoát";
            this.thoat.UseVisualStyleBackColor = true;
            this.thoat.Click += new System.EventHandler(this.thoat_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Cursor = System.Windows.Forms.Cursors.No;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(114, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 33);
            this.button1.TabIndex = 13;
            this.button1.Text = "ĐĂNG NHẬP";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // matKhau
            // 
            this.matKhau.ForeColor = System.Drawing.Color.Gray;
            this.matKhau.Location = new System.Drawing.Point(76, 106);
            this.matKhau.Multiline = true;
            this.matKhau.Name = "matKhau";
            this.matKhau.Size = new System.Drawing.Size(199, 35);
            this.matKhau.TabIndex = 1;
            this.matKhau.Text = "Mật Khẩu";
            this.matKhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maNV
            // 
            this.maNV.ForeColor = System.Drawing.Color.Gray;
            this.maNV.Location = new System.Drawing.Point(76, 51);
            this.maNV.Multiline = true;
            this.maNV.Name = "maNV";
            this.maNV.Size = new System.Drawing.Size(199, 34);
            this.maNV.TabIndex = 0;
            this.maNV.Text = "MANV";
            this.maNV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "DangNhap";
            this.Size = new System.Drawing.Size(771, 538);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox matKhau;
        private System.Windows.Forms.TextBox maNV;
        private System.Windows.Forms.CheckBox hienThiMatKhau;
        private System.Windows.Forms.Button dn;
        private System.Windows.Forms.Button thoat;
        private System.Windows.Forms.Button button1;

        
    }
}
