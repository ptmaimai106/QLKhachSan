namespace QLKhachSan
{
    partial class Thoat
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
            this.huy = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.huy);
            this.panel1.Controls.Add(this.ok);
            this.panel1.Controls.Add(this.button13);
            this.panel1.Location = new System.Drawing.Point(240, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 220);
            this.panel1.TabIndex = 0;
            // 
            // huy
            // 
            this.huy.Location = new System.Drawing.Point(63, 131);
            this.huy.Name = "huy";
            this.huy.Size = new System.Drawing.Size(103, 31);
            this.huy.TabIndex = 15;
            this.huy.Text = "Hủy";
            this.huy.UseVisualStyleBackColor = true;
            this.huy.Click += new System.EventHandler(this.huy_Click);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(221, 131);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(95, 31);
            this.ok.TabIndex = 14;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button13.Cursor = System.Windows.Forms.Cursors.No;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.Location = new System.Drawing.Point(21, 59);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(341, 33);
            this.button13.TabIndex = 13;
            this.button13.Text = "Bạn có muốn thoát khỏi ứng dụng ? ";
            this.button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button13.UseVisualStyleBackColor = false;
            // 
            // Thoat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Thoat";
            this.Size = new System.Drawing.Size(862, 518);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button huy;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button button13;
    }
}
