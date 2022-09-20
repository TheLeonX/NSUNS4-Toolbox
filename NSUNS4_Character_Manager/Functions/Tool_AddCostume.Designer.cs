namespace NSUNS4_Character_Manager
{
    partial class Tool_AddCostume
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
            this.label1 = new System.Windows.Forms.Label();
            this.w_base = new System.Windows.Forms.TextBox();
            this.w_model = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.awaModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base character (Example: 2nrt)";
            // 
            // w_base
            // 
            this.w_base.Location = new System.Drawing.Point(10, 31);
            this.w_base.Name = "w_base";
            this.w_base.Size = new System.Drawing.Size(232, 23);
            this.w_base.TabIndex = 1;
            // 
            // w_model
            // 
            this.w_model.Location = new System.Drawing.Point(10, 75);
            this.w_model.MaxLength = 7;
            this.w_model.Name = "w_model";
            this.w_model.Size = new System.Drawing.Size(232, 23);
            this.w_model.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Model to use:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add costume";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // awaModel
            // 
            this.awaModel.Location = new System.Drawing.Point(10, 119);
            this.awaModel.MaxLength = 7;
            this.awaModel.Name = "awaModel";
            this.awaModel.Size = new System.Drawing.Size(232, 23);
            this.awaModel.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Awakening model to use:";
            // 
            // Tool_AddCostume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 192);
            this.Controls.Add(this.awaModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.w_model);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.w_base);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Tool_AddCostume";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add costume";
            this.Load += new System.EventHandler(this.Tool_AddCostume_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox w_base;
        public System.Windows.Forms.TextBox w_model;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox awaModel;
        public System.Windows.Forms.Label label3;
    }
}