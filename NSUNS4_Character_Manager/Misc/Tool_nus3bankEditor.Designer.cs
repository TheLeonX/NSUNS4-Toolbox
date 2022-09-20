namespace NSUNS4_Character_Manager.Misc
{
    partial class Tool_nus3bankEditor
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Format = new System.Windows.Forms.Label();
            this.Quality = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.Volume = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.PositionOfSection = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.PositionOfSound = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.FileID_value01 = new System.Windows.Forms.NumericUpDown();
            this.FileID_value02 = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileID_value01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileID_value02)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 52);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(275, 439);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(521, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeFileToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.openToolStripMenuItem.Text = "Open file";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeFileToolStripMenuItem
            // 
            this.closeFileToolStripMenuItem.Name = "closeFileToolStripMenuItem";
            this.closeFileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.closeFileToolStripMenuItem.Text = "Close file";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sound list";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.button1.Location = new System.Drawing.Point(295, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 49);
            this.button1.TabIndex = 16;
            this.button1.Text = "Extract sound";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label7.Location = new System.Drawing.Point(299, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Sound info";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(303, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Format";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Setting";
            // 
            // Format
            // 
            this.Format.AutoSize = true;
            this.Format.Location = new System.Drawing.Point(348, 79);
            this.Format.Name = "Format";
            this.Format.Size = new System.Drawing.Size(0, 13);
            this.Format.TabIndex = 22;
            // 
            // Quality
            // 
            this.Quality.AutoSize = true;
            this.Quality.Location = new System.Drawing.Point(347, 102);
            this.Quality.Name = "Quality";
            this.Quality.Size = new System.Drawing.Size(0, 13);
            this.Quality.TabIndex = 23;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.button4.Location = new System.Drawing.Point(409, 473);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 49);
            this.button4.TabIndex = 24;
            this.button4.Text = "Extract all sounds";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.button6.Location = new System.Drawing.Point(295, 419);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(106, 48);
            this.button6.TabIndex = 26;
            this.button6.Text = "Replace sound with file";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button7.Location = new System.Drawing.Point(409, 418);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(106, 49);
            this.button7.TabIndex = 27;
            this.button7.Text = "Import sound to BSNF";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label11.Location = new System.Drawing.Point(293, 389);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 20);
            this.label11.TabIndex = 30;
            this.label11.Text = "Volume";
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.button8.Location = new System.Drawing.Point(431, 387);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(84, 25);
            this.button8.TabIndex = 32;
            this.button8.Text = "Save";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Volume
            // 
            this.Volume.DecimalPlaces = 2;
            this.Volume.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.Volume.Location = new System.Drawing.Point(356, 387);
            this.Volume.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.Volume.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.Volume.Name = "Volume";
            this.Volume.Size = new System.Drawing.Size(69, 24);
            this.Volume.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(302, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Position of section in file";
            this.label12.Visible = false;
            // 
            // PositionOfSection
            // 
            this.PositionOfSection.AutoSize = true;
            this.PositionOfSection.Location = new System.Drawing.Point(427, 123);
            this.PositionOfSection.Name = "PositionOfSection";
            this.PositionOfSection.Size = new System.Drawing.Size(0, 13);
            this.PositionOfSection.TabIndex = 35;
            this.PositionOfSection.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(303, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Position of sound in file";
            this.label13.Visible = false;
            // 
            // PositionOfSound
            // 
            this.PositionOfSound.AutoSize = true;
            this.PositionOfSound.Location = new System.Drawing.Point(425, 146);
            this.PositionOfSound.Name = "PositionOfSound";
            this.PositionOfSound.Size = new System.Drawing.Size(0, 13);
            this.PositionOfSound.TabIndex = 37;
            this.PositionOfSound.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label14.Location = new System.Drawing.Point(9, 501);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 17);
            this.label14.TabIndex = 40;
            this.label14.Text = "File ID";
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.button9.Location = new System.Drawing.Point(170, 497);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(117, 25);
            this.button9.TabIndex = 41;
            this.button9.Text = "Save";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // FileID_value01
            // 
            this.FileID_value01.Hexadecimal = true;
            this.FileID_value01.Location = new System.Drawing.Point(111, 499);
            this.FileID_value01.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.FileID_value01.Name = "FileID_value01";
            this.FileID_value01.Size = new System.Drawing.Size(53, 22);
            this.FileID_value01.TabIndex = 70;
            this.FileID_value01.ValueChanged += new System.EventHandler(this.FileID_value01_ValueChanged);
            // 
            // FileID_value02
            // 
            this.FileID_value02.Hexadecimal = true;
            this.FileID_value02.Location = new System.Drawing.Point(55, 499);
            this.FileID_value02.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.FileID_value02.Name = "FileID_value02";
            this.FileID_value02.Size = new System.Drawing.Size(53, 22);
            this.FileID_value02.TabIndex = 71;
            // 
            // Tool_nus3bankEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 533);
            this.Controls.Add(this.FileID_value02);
            this.Controls.Add(this.FileID_value01);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.PositionOfSound);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.PositionOfSection);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Volume);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Quality);
            this.Controls.Add(this.Format);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Tool_nus3bankEditor";
            this.Text = "NUS3BANK Editor";
            this.Load += new System.EventHandler(this.Tool_nus3bankEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileID_value01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileID_value02)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeFileToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Format;
        private System.Windows.Forms.Label Quality;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.NumericUpDown Volume;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label PositionOfSection;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label PositionOfSound;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.NumericUpDown FileID_value01;
        private System.Windows.Forms.NumericUpDown FileID_value02;
    }
}