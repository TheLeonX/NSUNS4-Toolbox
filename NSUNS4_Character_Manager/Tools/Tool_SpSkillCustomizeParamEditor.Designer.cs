namespace NSUNS4_Character_Manager.Tools
{
    partial class Tool_SpSkillCustomizeParamEditor
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
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.char01 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Spl1_Name = new System.Windows.Forms.TextBox();
            this.Spl2_Name = new System.Windows.Forms.TextBox();
            this.Spl3_Name = new System.Windows.Forms.TextBox();
            this.RemoveEntry_button = new System.Windows.Forms.Button();
            this.SaveEntry_button = new System.Windows.Forms.Button();
            this.CreateEntry_button = new System.Windows.Forms.Button();
            this.ULT1_CUC_v = new System.Windows.Forms.NumericUpDown();
            this.ULT2_CUC_v = new System.Windows.Forms.NumericUpDown();
            this.ULT3_CUC_v = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.search_value = new System.Windows.Forms.NumericUpDown();
            this.v_ult1_prior = new System.Windows.Forms.NumericUpDown();
            this.v_ult2_prior = new System.Windows.Forms.NumericUpDown();
            this.v_ult3_prior = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.ULT4_CUC_v = new System.Windows.Forms.NumericUpDown();
            this.Spl4_Name = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.v_ult4_prior = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.char01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ULT1_CUC_v)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ULT2_CUC_v)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ULT3_CUC_v)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_ult1_prior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_ult2_prior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_ult3_prior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ULT4_CUC_v)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_ult4_prior)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 38);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(203, 186);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("CC2 RocknRoll Latin DB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(607, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeFileToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeFileToolStripMenuItem
            // 
            this.closeFileToolStripMenuItem.Name = "closeFileToolStripMenuItem";
            this.closeFileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.closeFileToolStripMenuItem.Text = "Close file";
            this.closeFileToolStripMenuItem.Click += new System.EventHandler(this.closeFileToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 95;
            this.label1.Text = "Characodes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label2.Location = new System.Drawing.Point(221, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 96;
            this.label2.Text = "Ult 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label3.Location = new System.Drawing.Point(221, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 97;
            this.label3.Text = "Ult 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label4.Location = new System.Drawing.Point(221, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 98;
            this.label4.Text = "Ult 3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label5.Location = new System.Drawing.Point(384, 71);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 15);
            this.label5.TabIndex = 99;
            this.label5.Text = "Chakra Usage Count";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // char01
            // 
            this.char01.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.char01.Hexadecimal = true;
            this.char01.Location = new System.Drawing.Point(288, 33);
            this.char01.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.char01.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.char01.Name = "char01";
            this.char01.Size = new System.Drawing.Size(311, 24);
            this.char01.TabIndex = 102;
            this.char01.ValueChanged += new System.EventHandler(this.char01_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label10.Location = new System.Drawing.Point(220, 38);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 15);
            this.label10.TabIndex = 100;
            this.label10.Text = "Characode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label6.Location = new System.Drawing.Point(298, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 103;
            this.label6.Text = "Names";
            // 
            // Spl1_Name
            // 
            this.Spl1_Name.Location = new System.Drawing.Point(256, 87);
            this.Spl1_Name.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Spl1_Name.MaxLength = 15;
            this.Spl1_Name.Name = "Spl1_Name";
            this.Spl1_Name.Size = new System.Drawing.Size(126, 23);
            this.Spl1_Name.TabIndex = 104;
            // 
            // Spl2_Name
            // 
            this.Spl2_Name.Location = new System.Drawing.Point(256, 109);
            this.Spl2_Name.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Spl2_Name.MaxLength = 15;
            this.Spl2_Name.Name = "Spl2_Name";
            this.Spl2_Name.Size = new System.Drawing.Size(126, 23);
            this.Spl2_Name.TabIndex = 105;
            // 
            // Spl3_Name
            // 
            this.Spl3_Name.Location = new System.Drawing.Point(256, 131);
            this.Spl3_Name.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Spl3_Name.MaxLength = 15;
            this.Spl3_Name.Name = "Spl3_Name";
            this.Spl3_Name.Size = new System.Drawing.Size(126, 23);
            this.Spl3_Name.TabIndex = 106;
            // 
            // RemoveEntry_button
            // 
            this.RemoveEntry_button.Location = new System.Drawing.Point(107, 226);
            this.RemoveEntry_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RemoveEntry_button.Name = "RemoveEntry_button";
            this.RemoveEntry_button.Size = new System.Drawing.Size(105, 28);
            this.RemoveEntry_button.TabIndex = 125;
            this.RemoveEntry_button.Text = "Delete";
            this.RemoveEntry_button.UseVisualStyleBackColor = true;
            this.RemoveEntry_button.Click += new System.EventHandler(this.RemoveEntry_button_Click);
            // 
            // SaveEntry_button
            // 
            this.SaveEntry_button.Location = new System.Drawing.Point(216, 255);
            this.SaveEntry_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SaveEntry_button.Name = "SaveEntry_button";
            this.SaveEntry_button.Size = new System.Drawing.Size(383, 23);
            this.SaveEntry_button.TabIndex = 124;
            this.SaveEntry_button.Text = "Save";
            this.SaveEntry_button.UseVisualStyleBackColor = true;
            this.SaveEntry_button.Click += new System.EventHandler(this.SaveEntry_button_Click);
            // 
            // CreateEntry_button
            // 
            this.CreateEntry_button.Location = new System.Drawing.Point(9, 226);
            this.CreateEntry_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CreateEntry_button.Name = "CreateEntry_button";
            this.CreateEntry_button.Size = new System.Drawing.Size(95, 28);
            this.CreateEntry_button.TabIndex = 123;
            this.CreateEntry_button.Text = "Copy";
            this.CreateEntry_button.UseVisualStyleBackColor = true;
            this.CreateEntry_button.Click += new System.EventHandler(this.CreateEntry_button_Click);
            // 
            // ULT1_CUC_v
            // 
            this.ULT1_CUC_v.DecimalPlaces = 3;
            this.ULT1_CUC_v.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ULT1_CUC_v.Location = new System.Drawing.Point(387, 87);
            this.ULT1_CUC_v.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ULT1_CUC_v.Name = "ULT1_CUC_v";
            this.ULT1_CUC_v.Size = new System.Drawing.Size(105, 24);
            this.ULT1_CUC_v.TabIndex = 149;
            // 
            // ULT2_CUC_v
            // 
            this.ULT2_CUC_v.DecimalPlaces = 3;
            this.ULT2_CUC_v.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ULT2_CUC_v.Location = new System.Drawing.Point(387, 109);
            this.ULT2_CUC_v.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ULT2_CUC_v.Name = "ULT2_CUC_v";
            this.ULT2_CUC_v.Size = new System.Drawing.Size(105, 24);
            this.ULT2_CUC_v.TabIndex = 150;
            this.ULT2_CUC_v.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // ULT3_CUC_v
            // 
            this.ULT3_CUC_v.DecimalPlaces = 3;
            this.ULT3_CUC_v.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ULT3_CUC_v.Location = new System.Drawing.Point(387, 131);
            this.ULT3_CUC_v.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ULT3_CUC_v.Name = "ULT3_CUC_v";
            this.ULT3_CUC_v.Size = new System.Drawing.Size(105, 24);
            this.ULT3_CUC_v.TabIndex = 151;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(107, 255);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 23);
            this.button4.TabIndex = 164;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // search_value
            // 
            this.search_value.Hexadecimal = true;
            this.search_value.Location = new System.Drawing.Point(9, 255);
            this.search_value.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.search_value.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.search_value.Name = "search_value";
            this.search_value.Size = new System.Drawing.Size(95, 23);
            this.search_value.TabIndex = 163;
            // 
            // v_ult1_prior
            // 
            this.v_ult1_prior.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.v_ult1_prior.Location = new System.Drawing.Point(494, 86);
            this.v_ult1_prior.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.v_ult1_prior.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.v_ult1_prior.Name = "v_ult1_prior";
            this.v_ult1_prior.Size = new System.Drawing.Size(105, 24);
            this.v_ult1_prior.TabIndex = 168;
            // 
            // v_ult2_prior
            // 
            this.v_ult2_prior.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.v_ult2_prior.Location = new System.Drawing.Point(494, 108);
            this.v_ult2_prior.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.v_ult2_prior.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.v_ult2_prior.Name = "v_ult2_prior";
            this.v_ult2_prior.Size = new System.Drawing.Size(105, 24);
            this.v_ult2_prior.TabIndex = 169;
            // 
            // v_ult3_prior
            // 
            this.v_ult3_prior.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.v_ult3_prior.Location = new System.Drawing.Point(494, 132);
            this.v_ult3_prior.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.v_ult3_prior.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.v_ult3_prior.Name = "v_ult3_prior";
            this.v_ult3_prior.Size = new System.Drawing.Size(105, 24);
            this.v_ult3_prior.TabIndex = 170;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label11.Location = new System.Drawing.Point(519, 70);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 15);
            this.label11.TabIndex = 174;
            this.label11.Text = "Priority";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ULT4_CUC_v
            // 
            this.ULT4_CUC_v.DecimalPlaces = 3;
            this.ULT4_CUC_v.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ULT4_CUC_v.Location = new System.Drawing.Point(387, 154);
            this.ULT4_CUC_v.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ULT4_CUC_v.Name = "ULT4_CUC_v";
            this.ULT4_CUC_v.Size = new System.Drawing.Size(105, 24);
            this.ULT4_CUC_v.TabIndex = 177;
            // 
            // Spl4_Name
            // 
            this.Spl4_Name.Location = new System.Drawing.Point(256, 152);
            this.Spl4_Name.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Spl4_Name.MaxLength = 15;
            this.Spl4_Name.Name = "Spl4_Name";
            this.Spl4_Name.Size = new System.Drawing.Size(126, 23);
            this.Spl4_Name.TabIndex = 176;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label12.Location = new System.Drawing.Point(221, 157);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 15);
            this.label12.TabIndex = 175;
            this.label12.Text = "Ult 4";
            // 
            // v_ult4_prior
            // 
            this.v_ult4_prior.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.v_ult4_prior.Location = new System.Drawing.Point(494, 154);
            this.v_ult4_prior.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.v_ult4_prior.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.v_ult4_prior.Name = "v_ult4_prior";
            this.v_ult4_prior.Size = new System.Drawing.Size(105, 24);
            this.v_ult4_prior.TabIndex = 178;
            // 
            // Tool_SpSkillCustomizeParamEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 282);
            this.Controls.Add(this.v_ult4_prior);
            this.Controls.Add(this.ULT4_CUC_v);
            this.Controls.Add(this.Spl4_Name);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.v_ult3_prior);
            this.Controls.Add(this.v_ult2_prior);
            this.Controls.Add(this.v_ult1_prior);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.search_value);
            this.Controls.Add(this.ULT3_CUC_v);
            this.Controls.Add(this.ULT2_CUC_v);
            this.Controls.Add(this.ULT1_CUC_v);
            this.Controls.Add(this.RemoveEntry_button);
            this.Controls.Add(this.SaveEntry_button);
            this.Controls.Add(this.CreateEntry_button);
            this.Controls.Add(this.Spl3_Name);
            this.Controls.Add(this.Spl2_Name);
            this.Controls.Add(this.Spl1_Name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.char01);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "Tool_SpSkillCustomizeParamEditor";
            this.Text = "SpSkillCustomizeParam Editor";
            this.Load += new System.EventHandler(this.Tool_SpSkillCustomizeParamEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.char01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ULT1_CUC_v)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ULT2_CUC_v)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ULT3_CUC_v)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_ult1_prior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_ult2_prior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_ult3_prior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ULT4_CUC_v)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_ult4_prior)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeFileToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown char01;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Spl1_Name;
        private System.Windows.Forms.TextBox Spl2_Name;
        private System.Windows.Forms.TextBox Spl3_Name;
        private System.Windows.Forms.Button RemoveEntry_button;
        private System.Windows.Forms.Button SaveEntry_button;
        private System.Windows.Forms.Button CreateEntry_button;
        private System.Windows.Forms.NumericUpDown ULT1_CUC_v;
        private System.Windows.Forms.NumericUpDown ULT2_CUC_v;
        private System.Windows.Forms.NumericUpDown ULT3_CUC_v;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown search_value;
        private System.Windows.Forms.NumericUpDown v_ult1_prior;
        private System.Windows.Forms.NumericUpDown v_ult2_prior;
        private System.Windows.Forms.NumericUpDown v_ult3_prior;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown ULT4_CUC_v;
        private System.Windows.Forms.TextBox Spl4_Name;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown v_ult4_prior;
    }
}