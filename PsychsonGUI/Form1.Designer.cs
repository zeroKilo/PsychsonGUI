namespace PsychsonGUI
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.driveOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterBootmodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flashBurnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flashFirmwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traceUSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.hb1 = new Be.Windows.Forms.HexBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rtb2 = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.getInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.info1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.info2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.info3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendCustomCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driveOpenToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(676, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // driveOpenToolStripMenuItem
            // 
            this.driveOpenToolStripMenuItem.Name = "driveOpenToolStripMenuItem";
            this.driveOpenToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.driveOpenToolStripMenuItem.Text = "Drive Open...";
            this.driveOpenToolStripMenuItem.Click += new System.EventHandler(this.driveOpenToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterBootmodeToolStripMenuItem,
            this.flashBurnerToolStripMenuItem,
            this.flashFirmwareToolStripMenuItem,
            this.traceUSBToolStripMenuItem});
            this.toolsToolStripMenuItem.Enabled = false;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // enterBootmodeToolStripMenuItem
            // 
            this.enterBootmodeToolStripMenuItem.Name = "enterBootmodeToolStripMenuItem";
            this.enterBootmodeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.enterBootmodeToolStripMenuItem.Text = "Enter Bootmode...";
            this.enterBootmodeToolStripMenuItem.Click += new System.EventHandler(this.enterBootmodeToolStripMenuItem_Click);
            // 
            // flashBurnerToolStripMenuItem
            // 
            this.flashBurnerToolStripMenuItem.Name = "flashBurnerToolStripMenuItem";
            this.flashBurnerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.flashBurnerToolStripMenuItem.Text = "Flash Burner...";
            this.flashBurnerToolStripMenuItem.Click += new System.EventHandler(this.flashBurnerToolStripMenuItem_Click);
            // 
            // flashFirmwareToolStripMenuItem
            // 
            this.flashFirmwareToolStripMenuItem.Name = "flashFirmwareToolStripMenuItem";
            this.flashFirmwareToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.flashFirmwareToolStripMenuItem.Text = "Flash Firmware...";
            this.flashFirmwareToolStripMenuItem.Click += new System.EventHandler(this.flashFirmwareToolStripMenuItem_Click);
            // 
            // traceUSBToolStripMenuItem
            // 
            this.traceUSBToolStripMenuItem.Name = "traceUSBToolStripMenuItem";
            this.traceUSBToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.traceUSBToolStripMenuItem.Text = "Trace USB";
            this.traceUSBToolStripMenuItem.Click += new System.EventHandler(this.traceUSBToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pb1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 406);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(676, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pb1
            // 
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(100, 16);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtb1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(668, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtb1
            // 
            this.rtb1.DetectUrls = false;
            this.rtb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rtb1.Location = new System.Drawing.Point(3, 26);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(662, 327);
            this.rtb1.TabIndex = 1;
            this.rtb1.Text = "";
            this.rtb1.WordWrap = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(662, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Information";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(676, 382);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.hb1);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.menuStrip2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(668, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vendor Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // hb1
            // 
            this.hb1.BoldFont = null;
            this.hb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hb1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hb1.LineInfoForeColor = System.Drawing.Color.Empty;
            this.hb1.LineInfoVisible = true;
            this.hb1.Location = new System.Drawing.Point(3, 27);
            this.hb1.Name = "hb1";
            this.hb1.ReadOnly = true;
            this.hb1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hb1.Size = new System.Drawing.Size(662, 303);
            this.hb1.StringViewVisible = true;
            this.hb1.TabIndex = 0;
            this.hb1.UseFixedBytesPerLine = true;
            this.hb1.VScrollBarVisible = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.Location = new System.Drawing.Point(3, 330);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(662, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Save Information...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rtb2);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(668, 356);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Trace";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rtb2
            // 
            this.rtb2.DetectUrls = false;
            this.rtb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb2.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rtb2.Location = new System.Drawing.Point(3, 26);
            this.rtb2.Name = "rtb2";
            this.rtb2.ReadOnly = true;
            this.rtb2.Size = new System.Drawing.Size(662, 327);
            this.rtb2.TabIndex = 2;
            this.rtb2.Text = "";
            this.rtb2.WordWrap = false;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Location = new System.Drawing.Point(3, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(662, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getInfoToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(662, 24);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // getInfoToolStripMenuItem
            // 
            this.getInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.info1ToolStripMenuItem,
            this.info2ToolStripMenuItem,
            this.info3ToolStripMenuItem,
            this.sendCustomCommandToolStripMenuItem});
            this.getInfoToolStripMenuItem.Name = "getInfoToolStripMenuItem";
            this.getInfoToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.getInfoToolStripMenuItem.Text = "Get Info";
            // 
            // info1ToolStripMenuItem
            // 
            this.info1ToolStripMenuItem.Name = "info1ToolStripMenuItem";
            this.info1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.info1ToolStripMenuItem.Text = "Info 1";
            this.info1ToolStripMenuItem.Click += new System.EventHandler(this.info1ToolStripMenuItem_Click);
            // 
            // info2ToolStripMenuItem
            // 
            this.info2ToolStripMenuItem.Name = "info2ToolStripMenuItem";
            this.info2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.info2ToolStripMenuItem.Text = "Info 2";
            this.info2ToolStripMenuItem.Click += new System.EventHandler(this.info2ToolStripMenuItem_Click);
            // 
            // info3ToolStripMenuItem
            // 
            this.info3ToolStripMenuItem.Name = "info3ToolStripMenuItem";
            this.info3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.info3ToolStripMenuItem.Text = "Info 3";
            this.info3ToolStripMenuItem.Click += new System.EventHandler(this.info3ToolStripMenuItem_Click);
            // 
            // sendCustomCommandToolStripMenuItem
            // 
            this.sendCustomCommandToolStripMenuItem.Name = "sendCustomCommandToolStripMenuItem";
            this.sendCustomCommandToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.sendCustomCommandToolStripMenuItem.Text = "Send Custom Command";
            this.sendCustomCommandToolStripMenuItem.Click += new System.EventHandler(this.sendCustomCommandToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 428);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PsychsonGUI by Warranty Voider";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem driveOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterBootmodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flashBurnerToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pb1;
        private System.Windows.Forms.ToolStripMenuItem flashFirmwareToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private Be.Windows.Forms.HexBox hb1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem traceUSBToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox rtb2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem getInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem info1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem info2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem info3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendCustomCommandToolStripMenuItem;
    }
}

