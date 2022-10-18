
namespace NSUNS4_Character_Manager.Functions {
    partial class Tool_ExportCharacter {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Search_TB = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.missingSoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToExportVIDEOTUTORIALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "This tool is experimental";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(236, 264);
            this.listBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select characode";
            // 
            // Search_TB
            // 
            this.Search_TB.Location = new System.Drawing.Point(7, 312);
            this.Search_TB.MaxLength = 15;
            this.Search_TB.Name = "Search_TB";
            this.Search_TB.Size = new System.Drawing.Size(135, 20);
            this.Search_TB.TabIndex = 40;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(148, 312);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(96, 23);
            this.Search.TabIndex = 39;
            this.Search.Text = "Search ID";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 357);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(202, 17);
            this.checkBox1.TabIndex = 41;
            this.checkBox1.Text = "Export damageprm duplicate sections";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(252, 24);
            this.menuStrip1.TabIndex = 42;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.missingSoundsToolStripMenuItem,
            this.howToExportVIDEOTUTORIALToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // missingSoundsToolStripMenuItem
            // 
            this.missingSoundsToolStripMenuItem.Name = "missingSoundsToolStripMenuItem";
            this.missingSoundsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.missingSoundsToolStripMenuItem.Text = "Missing sounds";
            this.missingSoundsToolStripMenuItem.Click += new System.EventHandler(this.missingSoundsToolStripMenuItem_Click);
            // 
            // howToExportVIDEOTUTORIALToolStripMenuItem
            // 
            this.howToExportVIDEOTUTORIALToolStripMenuItem.Name = "howToExportVIDEOTUTORIALToolStripMenuItem";
            this.howToExportVIDEOTUTORIALToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.howToExportVIDEOTUTORIALToolStripMenuItem.Text = "How to export [VIDEO TUTORIAL]";
            this.howToExportVIDEOTUTORIALToolStripMenuItem.Click += new System.EventHandler(this.howToExportVIDEOTUTORIALToolStripMenuItem_Click);
            // 
            // Tool_ExportCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 412);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Search_TB);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tool_ExportCharacter";
            this.Text = "Export Character";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tool_ExportCharacter_FormClosed);
            this.Load += new System.EventHandler(this.Tool_ExportCharacter_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Search_TB;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem missingSoundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToExportVIDEOTUTORIALToolStripMenuItem;
    }
}