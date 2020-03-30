namespace TianLongBaBu
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.QiaoFengShow = new System.Windows.Forms.TextBox();
            this.XuZhuShow = new System.Windows.Forms.TextBox();
            this.DuanYuShow = new System.Windows.Forms.TextBox();
            this.VoiceoverShow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Begining = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // QiaoFengShow
            // 
            this.QiaoFengShow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.QiaoFengShow.Location = new System.Drawing.Point(12, 61);
            this.QiaoFengShow.Multiline = true;
            this.QiaoFengShow.Name = "QiaoFengShow";
            this.QiaoFengShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.QiaoFengShow.Size = new System.Drawing.Size(400, 236);
            this.QiaoFengShow.TabIndex = 0;
            // 
            // XuZhuShow
            // 
            this.XuZhuShow.Location = new System.Drawing.Point(418, 61);
            this.XuZhuShow.Multiline = true;
            this.XuZhuShow.Name = "XuZhuShow";
            this.XuZhuShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.XuZhuShow.Size = new System.Drawing.Size(400, 236);
            this.XuZhuShow.TabIndex = 1;
            // 
            // DuanYuShow
            // 
            this.DuanYuShow.Location = new System.Drawing.Point(824, 61);
            this.DuanYuShow.Multiline = true;
            this.DuanYuShow.Name = "DuanYuShow";
            this.DuanYuShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DuanYuShow.Size = new System.Drawing.Size(400, 236);
            this.DuanYuShow.TabIndex = 2;
            // 
            // VoiceoverShow
            // 
            this.VoiceoverShow.Location = new System.Drawing.Point(12, 324);
            this.VoiceoverShow.Multiline = true;
            this.VoiceoverShow.Name = "VoiceoverShow";
            this.VoiceoverShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.VoiceoverShow.Size = new System.Drawing.Size(1212, 236);
            this.VoiceoverShow.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "乔峰";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "虚竹";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(822, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "段誉";
            // 
            // Begining
            // 
            this.Begining.Location = new System.Drawing.Point(12, 590);
            this.Begining.Name = "Begining";
            this.Begining.Size = new System.Drawing.Size(75, 23);
            this.Begining.TabIndex = 7;
            this.Begining.Text = "开始";
            this.Begining.UseVisualStyleBackColor = true;
            this.Begining.Click += new System.EventHandler(this.Begining_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 648);
            this.Controls.Add(this.Begining);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VoiceoverShow);
            this.Controls.Add(this.DuanYuShow);
            this.Controls.Add(this.XuZhuShow);
            this.Controls.Add(this.QiaoFengShow);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox QiaoFengShow;
        private System.Windows.Forms.TextBox XuZhuShow;
        private System.Windows.Forms.TextBox DuanYuShow;
        private System.Windows.Forms.TextBox VoiceoverShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Begining;
    }
}

