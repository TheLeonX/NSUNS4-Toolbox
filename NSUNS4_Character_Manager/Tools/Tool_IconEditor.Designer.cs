namespace NSUNS4_Character_Manager.Tools
{
    partial class Tool_IconEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.opta = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.pid1 = new System.Windows.Forms.NumericUpDown();
            this.pid0 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.IconName = new System.Windows.Forms.TextBox();
            this.IconLabel = new System.Windows.Forms.Label();
            this.AwaIconLabel = new System.Windows.Forms.Label();
            this.AwaIconName = new System.Windows.Forms.TextBox();
            this.CharNameLabel = new System.Windows.Forms.Label();
            this.CharName = new System.Windows.Forms.TextBox();
            this.ExNinjutsuLabel = new System.Windows.Forms.Label();
            this.ExNinjutsuName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.costume_cb = new System.Windows.Forms.NumericUpDown();
            this.Characode1_cb = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.Characode2_cb = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pid0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costume_cb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Characode1_cb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Characode2_cb)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("CC2 RocknRoll Latin DB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close file";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click_1);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(14, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(256, 293);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // opta
            // 
            this.opta.Hexadecimal = true;
            this.opta.Location = new System.Drawing.Point(277, 82);
            this.opta.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.opta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.opta.Name = "opta";
            this.opta.Size = new System.Drawing.Size(199, 23);
            this.opta.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Costume Slot ID:";
            // 
            // pid1
            // 
            this.pid1.Hexadecimal = true;
            this.pid1.Location = new System.Drawing.Point(380, 43);
            this.pid1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.pid1.Name = "pid1";
            this.pid1.Size = new System.Drawing.Size(97, 23);
            this.pid1.TabIndex = 20;
            // 
            // pid0
            // 
            this.pid0.Hexadecimal = true;
            this.pid0.Location = new System.Drawing.Point(277, 43);
            this.pid0.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.pid0.Name = "pid0";
            this.pid0.Size = new System.Drawing.Size(97, 23);
            this.pid0.TabIndex = 21;
            this.pid0.ValueChanged += new System.EventHandler(this.pid0_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Characode";
            // 
            // IconName
            // 
            this.IconName.Location = new System.Drawing.Point(277, 125);
            this.IconName.MaxLength = 15;
            this.IconName.Name = "IconName";
            this.IconName.Size = new System.Drawing.Size(200, 23);
            this.IconName.TabIndex = 24;
            this.IconName.TextChanged += new System.EventHandler(this.IconName_TextChanged);
            // 
            // IconLabel
            // 
            this.IconLabel.AutoSize = true;
            this.IconLabel.Location = new System.Drawing.Point(274, 109);
            this.IconLabel.Name = "IconLabel";
            this.IconLabel.Size = new System.Drawing.Size(30, 15);
            this.IconLabel.TabIndex = 25;
            this.IconLabel.Text = "Icon";
            // 
            // AwaIconLabel
            // 
            this.AwaIconLabel.AutoSize = true;
            this.AwaIconLabel.Location = new System.Drawing.Point(274, 151);
            this.AwaIconLabel.Name = "AwaIconLabel";
            this.AwaIconLabel.Size = new System.Drawing.Size(68, 15);
            this.AwaIconLabel.TabIndex = 27;
            this.AwaIconLabel.Text = "Awake Icon";
            this.AwaIconLabel.UseMnemonic = false;
            // 
            // AwaIconName
            // 
            this.AwaIconName.Location = new System.Drawing.Point(277, 167);
            this.AwaIconName.MaxLength = 15;
            this.AwaIconName.Name = "AwaIconName";
            this.AwaIconName.Size = new System.Drawing.Size(200, 23);
            this.AwaIconName.TabIndex = 26;
            // 
            // CharNameLabel
            // 
            this.CharNameLabel.AutoSize = true;
            this.CharNameLabel.Location = new System.Drawing.Point(273, 193);
            this.CharNameLabel.Name = "CharNameLabel";
            this.CharNameLabel.Size = new System.Drawing.Size(39, 15);
            this.CharNameLabel.TabIndex = 29;
            this.CharNameLabel.Text = "Name";
            this.CharNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CharName
            // 
            this.CharName.Location = new System.Drawing.Point(277, 209);
            this.CharName.MaxLength = 15;
            this.CharName.Name = "CharName";
            this.CharName.Size = new System.Drawing.Size(200, 23);
            this.CharName.TabIndex = 28;
            // 
            // ExNinjutsuLabel
            // 
            this.ExNinjutsuLabel.AutoSize = true;
            this.ExNinjutsuLabel.Location = new System.Drawing.Point(274, 237);
            this.ExNinjutsuLabel.Name = "ExNinjutsuLabel";
            this.ExNinjutsuLabel.Size = new System.Drawing.Size(99, 15);
            this.ExNinjutsuLabel.TabIndex = 31;
            this.ExNinjutsuLabel.Text = "Sub ninjutsu icon";
            // 
            // ExNinjutsuName
            // 
            this.ExNinjutsuName.Location = new System.Drawing.Point(277, 253);
            this.ExNinjutsuName.MaxLength = 15;
            this.ExNinjutsuName.Name = "ExNinjutsuName";
            this.ExNinjutsuName.Size = new System.Drawing.Size(200, 23);
            this.ExNinjutsuName.TabIndex = 30;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 32);
            this.button1.TabIndex = 32;
            this.button1.Text = "Remove selected entry";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 33;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(277, 328);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(200, 32);
            this.SaveButton.TabIndex = 34;
            this.SaveButton.Text = "Save entry";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(277, 287);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(200, 35);
            this.CreateButton.TabIndex = 35;
            this.CreateButton.Text = "Create new entry with this data";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(164, 368);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 40;
            this.label12.Text = "Costume";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 368);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 15);
            this.label11.TabIndex = 39;
            this.label11.Text = "Characode";
            // 
            // costume_cb
            // 
            this.costume_cb.Location = new System.Drawing.Point(219, 366);
            this.costume_cb.Name = "costume_cb";
            this.costume_cb.Size = new System.Drawing.Size(52, 23);
            this.costume_cb.TabIndex = 38;
            // 
            // Characode1_cb
            // 
            this.Characode1_cb.Hexadecimal = true;
            this.Characode1_cb.Location = new System.Drawing.Point(76, 366);
            this.Characode1_cb.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Characode1_cb.Name = "Characode1_cb";
            this.Characode1_cb.Size = new System.Drawing.Size(41, 23);
            this.Characode1_cb.TabIndex = 37;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(277, 366);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(200, 23);
            this.button5.TabIndex = 36;
            this.button5.Text = "Search slot";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Characode2_cb
            // 
            this.Characode2_cb.Hexadecimal = true;
            this.Characode2_cb.Location = new System.Drawing.Point(123, 366);
            this.Characode2_cb.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Characode2_cb.Name = "Characode2_cb";
            this.Characode2_cb.Size = new System.Drawing.Size(41, 23);
            this.Characode2_cb.TabIndex = 41;
            // 
            // Tool_IconEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 398);
            this.Controls.Add(this.Characode2_cb);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.costume_cb);
            this.Controls.Add(this.Characode1_cb);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExNinjutsuLabel);
            this.Controls.Add(this.ExNinjutsuName);
            this.Controls.Add(this.CharNameLabel);
            this.Controls.Add(this.CharName);
            this.Controls.Add(this.AwaIconLabel);
            this.Controls.Add(this.AwaIconName);
            this.Controls.Add(this.IconLabel);
            this.Controls.Add(this.IconName);
            this.Controls.Add(this.opta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pid1);
            this.Controls.Add(this.pid0);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Tool_IconEditor";
            this.Text = "Player_icon Editor";
            this.Load += new System.EventHandler(this.Tool_IconEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pid0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costume_cb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Characode1_cb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Characode2_cb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.NumericUpDown opta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown pid1;
        private System.Windows.Forms.NumericUpDown pid0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IconName;
        private System.Windows.Forms.Label IconLabel;
        private System.Windows.Forms.Label AwaIconLabel;
        private System.Windows.Forms.TextBox AwaIconName;
        private System.Windows.Forms.Label CharNameLabel;
        private System.Windows.Forms.TextBox CharName;
        private System.Windows.Forms.Label ExNinjutsuLabel;
        private System.Windows.Forms.TextBox ExNinjutsuName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown costume_cb;
        private System.Windows.Forms.NumericUpDown Characode1_cb;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NumericUpDown Characode2_cb;
    }
}