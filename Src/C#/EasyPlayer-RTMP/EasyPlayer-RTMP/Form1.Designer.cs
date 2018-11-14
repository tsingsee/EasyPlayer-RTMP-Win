namespace EasyPlayer_RTMP
{
    partial class PlayerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Snop_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Recode_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OSDShow_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddScreenFontTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FullWindos_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaySound_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DecodeType = new System.Windows.Forms.ComboBox();
            this.PlayerBtn = new System.Windows.Forms.Button();
            this.StreamURI = new System.Windows.Forms.TextBox();
            this.CacheFream = new System.Windows.Forms.TrackBar();
            this.Label = new System.Windows.Forms.Label();
            this.HardDecode = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CacheFream)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BackgroundImage = global::EasyPlayer_RTMP.Properties.Resources.Easylogo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 590);
            this.panel1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Snop_MenuItem,
            this.Recode_MenuItem,
            this.OSDShow_MenuItem,
            this.AddScreenFontTSMenuItem,
            this.FullWindos_MenuItem,
            this.PlaySound_MenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 136);
            // 
            // Snop_MenuItem
            // 
            this.Snop_MenuItem.Name = "Snop_MenuItem";
            this.Snop_MenuItem.Size = new System.Drawing.Size(126, 22);
            this.Snop_MenuItem.Text = "截图";
            this.Snop_MenuItem.Click += new System.EventHandler(this.Snop_MenuItem_Click);
            // 
            // Recode_MenuItem
            // 
            this.Recode_MenuItem.Name = "Recode_MenuItem";
            this.Recode_MenuItem.Size = new System.Drawing.Size(126, 22);
            this.Recode_MenuItem.Text = "视频录像";
            this.Recode_MenuItem.Click += new System.EventHandler(this.Recode_MenuItem_Click);
            // 
            // OSDShow_MenuItem
            // 
            this.OSDShow_MenuItem.Name = "OSDShow_MenuItem";
            this.OSDShow_MenuItem.Size = new System.Drawing.Size(126, 22);
            this.OSDShow_MenuItem.Text = "OSD显示";
            this.OSDShow_MenuItem.Click += new System.EventHandler(this.OSDShow_MenuItem_Click);
            // 
            // AddScreenFontTSMenuItem
            // 
            this.AddScreenFontTSMenuItem.Name = "AddScreenFontTSMenuItem";
            this.AddScreenFontTSMenuItem.Size = new System.Drawing.Size(126, 22);
            this.AddScreenFontTSMenuItem.Text = "附加文字";
            this.AddScreenFontTSMenuItem.Click += new System.EventHandler(this.AddScreenFontTSMenuItem_Click);
            // 
            // FullWindos_MenuItem
            // 
            this.FullWindos_MenuItem.Name = "FullWindos_MenuItem";
            this.FullWindos_MenuItem.Size = new System.Drawing.Size(126, 22);
            this.FullWindos_MenuItem.Text = "比例显示";
            this.FullWindos_MenuItem.Click += new System.EventHandler(this.FullWindos_MenuItem_Click);
            // 
            // PlaySound_MenuItem
            // 
            this.PlaySound_MenuItem.Name = "PlaySound_MenuItem";
            this.PlaySound_MenuItem.Size = new System.Drawing.Size(126, 22);
            this.PlaySound_MenuItem.Text = "播放音频";
            this.PlaySound_MenuItem.Click += new System.EventHandler(this.PlaySound_MenuItem_Click);
            // 
            // DecodeType
            // 
            this.DecodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DecodeType.FormattingEnabled = true;
            this.DecodeType.Items.AddRange(new object[] {
            "YUY2",
            "YV12",
            "RGB565",
            "GDI"});
            this.DecodeType.Location = new System.Drawing.Point(419, 594);
            this.DecodeType.Name = "DecodeType";
            this.DecodeType.Size = new System.Drawing.Size(92, 28);
            this.DecodeType.TabIndex = 17;
            this.DecodeType.SelectedIndexChanged += new System.EventHandler(this.DecodeType_SelectedIndexChanged);
            // 
            // PlayerBtn
            // 
            this.PlayerBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlayerBtn.Location = new System.Drawing.Point(851, 596);
            this.PlayerBtn.Name = "PlayerBtn";
            this.PlayerBtn.Size = new System.Drawing.Size(86, 26);
            this.PlayerBtn.TabIndex = 16;
            this.PlayerBtn.Text = "播放";
            this.PlayerBtn.UseVisualStyleBackColor = true;
            this.PlayerBtn.Click += new System.EventHandler(this.PlayerBtn_Click);
            // 
            // StreamURI
            // 
            this.StreamURI.Location = new System.Drawing.Point(83, 594);
            this.StreamURI.Name = "StreamURI";
            this.StreamURI.Size = new System.Drawing.Size(312, 26);
            this.StreamURI.TabIndex = 11;
            this.StreamURI.Text = "rtmp://202.69.69.180:443/webcast/bshdlive-pc";
            // 
            // CacheFream
            // 
            this.CacheFream.Location = new System.Drawing.Point(674, 593);
            this.CacheFream.Maximum = 30;
            this.CacheFream.Minimum = 6;
            this.CacheFream.Name = "CacheFream";
            this.CacheFream.Size = new System.Drawing.Size(125, 45);
            this.CacheFream.TabIndex = 15;
            this.CacheFream.Value = 10;
            this.CacheFream.ValueChanged += new System.EventHandler(this.CacheFream_ValueChanged);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(5, 596);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(91, 20);
            this.Label.TabIndex = 12;
            this.Label.Text = "RTMP地址：";
            // 
            // HardDecode
            // 
            this.HardDecode.AutoSize = true;
            this.HardDecode.Location = new System.Drawing.Point(539, 596);
            this.HardDecode.Name = "HardDecode";
            this.HardDecode.Size = new System.Drawing.Size(56, 24);
            this.HardDecode.TabIndex = 14;
            this.HardDecode.Text = "硬解";
            this.HardDecode.UseVisualStyleBackColor = true;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 624);
            this.Controls.Add(this.DecodeType);
            this.Controls.Add(this.PlayerBtn);
            this.Controls.Add(this.StreamURI);
            this.Controls.Add(this.CacheFream);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.HardDecode);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "PlayerForm";
            this.Text = "EasyPlayer RTMP播放器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerForm_FormClosing);
            this.Load += new System.EventHandler(this.PlayerForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CacheFream)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox DecodeType;
        private System.Windows.Forms.Button PlayerBtn;
        private System.Windows.Forms.TextBox StreamURI;
        private System.Windows.Forms.TrackBar CacheFream;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.CheckBox HardDecode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Snop_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Recode_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem OSDShow_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem FullWindos_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem PlaySound_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddScreenFontTSMenuItem;
    }
}

