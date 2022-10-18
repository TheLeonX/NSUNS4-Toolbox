using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NSUNS4_Character_Manager
{
	public class Tool_UnlockCharaTotalEditor : Form
	{
		public bool FileOpen = false;

		public string FilePath = "";

		public byte[] FileBytes = new byte[0];

		public List<List<byte>> EntryList = new List<List<byte>>();

		public int EntryCount = 0;

		private IContainer components = null;

		private ListBox ListBox1;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem fileToolStripMenuItem;

		private ToolStripMenuItem newToolStripMenuItem;

		private ToolStripMenuItem openToolStripMenuItem;

		private ToolStripMenuItem saveToolStripMenuItem;

		private ToolStripMenuItem saveAsToolStripMenuItem;

		private ToolStripMenuItem closeToolStripMenuItem;

		private Button button1;

		private Button button2;

		private Label label1;

		private NumericUpDown numericUpDown1;
        private Button button3;
        private NumericUpDown numericUpDown3;
        private Label label2;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown5;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDown6;
        private Button button4;
        private NumericUpDown numericUpDown2;

		public Tool_UnlockCharaTotalEditor()
		{
			InitializeComponent();
		}

		public void NewFile()
		{
			FileBytes = new byte[0];
			FilePath = "";
			EntryList = new List<List<byte>>();
			EntryCount = 0;
			ListBox1.Items.Clear();
			FileOpen = true;
		}

		public void OpenFile(string basepath = "")
		{
			if (FileOpen)
			{
				CloseFile();
			}
			OpenFileDialog o = new OpenFileDialog();
			{
				o.DefaultExt = ".xfbin";
				o.Filter = "*.xfbin|*.xfbin";
			}
			if (basepath != "") {
				o.FileName = basepath;
			} else {
				o.ShowDialog();
			}
			if (!(o.FileName != "") || !File.Exists(o.FileName))
			{
				return;
			}
			FileOpen = true;
			ListBox1.Items.Clear();
			FilePath = o.FileName;
			FileBytes = File.ReadAllBytes(FilePath);
			EntryCount = FileBytes[300] + FileBytes[301] * 256 + FileBytes[302] * 65536 + FileBytes[303] * 16777216;
			EntryList = new List<List<byte>>();
			for (int x = 0; x < EntryCount; x++)
			{
				List<byte> character = new List<byte>();
				for (int a = 0; a < 12; a++)
				{
					byte b = FileBytes[312 + x * 12 + a];
					character.Add(b);
				}
				EntryList.Add(character);
				string toAdd = "";
				for (int c = 0; c < 12; c++)
				{
					toAdd = toAdd + character[c].ToString("X2") + " ";
				}
				ListBox1.Items.Add(toAdd);
			}
			//MessageBox.Show("UnlockCharaTotal contains " + EntryCount + " unlock sections.");
		}

		public void AddID()
		{
			byte[] presetID = new byte[2]
			{
				(byte)numericUpDown1.Value,
				(byte)numericUpDown2.Value
			};
			byte[] sectionBytes = new byte[12]
			{
				presetID[0],
				presetID[1],
				0,
				0,
				1,
				0,
				0,
				0,
				(byte)numericUpDown6.Value,
				0,
				0,
				0
			};
			EntryList.Add(sectionBytes.ToList());
			string toAdd = "";
			for (int c = 0; c < 12; c++)
			{
				toAdd = toAdd + sectionBytes[c].ToString("X2") + " ";
			}
			ListBox1.Items.Add(toAdd);
			ListBox1.SelectedIndex = ListBox1.Items.Count - 1;
			EntryCount++;
		}
		public void AddID_Importer(int PresetID, int type) {
			byte[] presetID = BitConverter.GetBytes(PresetID);
			byte[] sectionBytes = new byte[12]
			{
				presetID[0],
				presetID[1],
				0,
				0,
				1,
				0,
				0,
				0,
				(byte)type,
				0,
				0,
				0
			};
			EntryList.Add(sectionBytes.ToList());
			EntryCount++;
		}
		public void AddID2(bool skip = true)
		{
			
			for (int x = -1; x < numericUpDown3.Value; x++)
			{
				if (numericUpDown5.Value<255)
					numericUpDown5.Value = numericUpDown5.Value + 1;
				else if (numericUpDown5.Value > 254)
                {
					numericUpDown5.Value = 0;
					numericUpDown4.Value = numericUpDown4.Value + 1;
				}
				byte[] presetID = new byte[2]
				{
					(byte)numericUpDown5.Value,
					(byte)numericUpDown4.Value
				};
				byte[] sectionBytes = new byte[12]
				{
				presetID[0],
				presetID[1],
				0,
				0,
				0x01,
				0,
				0,
				0,
				(byte)numericUpDown6.Value,
				0,
				0,
				0
				};
				EntryList.Add(sectionBytes.ToList());
				string toAdd = "";
				for (int c = 0; c < 12; c++)
				{
					toAdd = toAdd + sectionBytes[c].ToString("X2") + " ";
				}
				if (skip) {
					ListBox1.Items.Add(toAdd);
					ListBox1.SelectedIndex = ListBox1.Items.Count - 1;
				}
				
				EntryCount++;
			}
			MessageBox.Show("Finished");
		}
		public void RemoveID(int Index)
		{
			EntryList.RemoveAt(Index);
			if (ListBox1.SelectedIndex > 0)
			{
				ListBox1.SelectedIndex--;
			}
			else
			{
				ListBox1.ClearSelected();
			}
			ListBox1.Items.RemoveAt(Index);
			EntryCount--;
		}

		public byte[] ConvertToFile()
		{
			List<byte> file = new List<byte>();
			byte[] header = new byte[312]
			{
				78,
				85,
				67,
				67,
				0,
				0,
				0,
				121,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				228,
				0,
				0,
				0,
				3,
				0,
				121,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				59,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				33,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				30,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				48,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0,
				110,
				117,
				99,
				99,
				67,
				104,
				117,
				110,
				107,
				78,
				117,
				108,
				108,
				0,
				110,
				117,
				99,
				99,
				67,
				104,
				117,
				110,
				107,
				66,
				105,
				110,
				97,
				114,
				121,
				0,
				110,
				117,
				99,
				99,
				67,
				104,
				117,
				110,
				107,
				80,
				97,
				103,
				101,
				0,
				110,
				117,
				99,
				99,
				67,
				104,
				117,
				110,
				107,
				73,
				110,
				100,
				101,
				120,
				0,
				0,
				98,
				105,
				110,
				95,
				108,
				101,
				47,
				120,
				54,
				52,
				47,
				117,
				110,
				108,
				111,
				99,
				107,
				67,
				104,
				97,
				114,
				97,
				84,
				111,
				116,
				97,
				108,
				46,
				98,
				105,
				110,
				0,
				0,
				117,
				110,
				108,
				111,
				99,
				107,
				67,
				104,
				97,
				114,
				97,
				84,
				111,
				116,
				97,
				108,
				0,
				80,
				97,
				103,
				101,
				48,
				0,
				105,
				110,
				100,
				101,
				120,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				121,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				121,
				0,
				0,
				0,
				0,
				5,
				252,
				0,
				0,
				0,
				1,
				0,
				121,
				0,
				0,
				0,
				0,
				5,
				248,
				233,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				8,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			for (int x3 = 0; x3 < header.Length; x3++)
			{
				file.Add(header[x3]);
			}
			byte[] Size3 = BitConverter.GetBytes(EntryCount * 12 + 20);
			Array.Reverse(Size3);
			file[280] = Size3[0];
			file[281] = Size3[1];
			file[282] = Size3[2];
			file[283] = Size3[3];
			Size3 = BitConverter.GetBytes(EntryCount * 12 + 16);
			Array.Reverse(Size3);
			file[292] = Size3[0];
			file[293] = Size3[1];
			file[294] = Size3[2];
			file[295] = Size3[3];
			Size3 = BitConverter.GetBytes(EntryCount);
			for (int a18 = 0; a18 < 4; a18++)
			{
				file[300 + a18] = Size3[a18];
			}

			for (int x2 = 0; x2 < EntryCount; x2++)
			{
				for (int a = 0; a < 12; a++)
				{
					file.Add(EntryList[x2][a]);
				}
			}
			byte[] finalBytes = new byte[20]
			{
				0,
				0,
				0,
				8,
				0,
				0,
				0,
				2,
				0,
				121,
				24,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0
			};
			for (int x = 0; x < finalBytes.Length; x++)
			{
				file.Add(finalBytes[x]);
			}
			return file.ToArray();
		}

		public void SaveFile()
		{
			if (FilePath != "")
			{
				if (File.Exists(FilePath + ".backup"))
				{
					File.Delete(FilePath + ".backup");
				}
				File.Copy(FilePath, FilePath + ".backup");
				File.WriteAllBytes(FilePath, ConvertToFile());
				MessageBox.Show("File saved to " + FilePath + ".");
			}
			else
			{
				SaveFileAs();
			}
		}

		public void SaveFileAs(string basepath = "")
		{
			SaveFileDialog s = new SaveFileDialog();
			{
				s.DefaultExt = ".xfbin";
				s.Filter = "*.xfbin|*.xfbin";
			}
			if (basepath != "")
				s.FileName = basepath;
			else
				s.ShowDialog();
			if (!(s.FileName != ""))
			{
				return;
			}
			if (s.FileName == FilePath)
			{
				if (File.Exists(FilePath + ".backup"))
				{
					File.Delete(FilePath + ".backup");
				}
				File.Copy(FilePath, FilePath + ".backup");
			}
			else
			{
				FilePath = s.FileName;
			}
			File.WriteAllBytes(FilePath, ConvertToFile());
			if (basepath == "")
				MessageBox.Show("File saved to " + FilePath + ".");
		}

		public void CloseFile()
		{
			EntryList.Clear();
			ListBox1.Items.Clear();
			ListBox1.Items.Add("No file loaded...");
			EntryCount = 0;
			FilePath = "";
			FileBytes = new byte[0];
			FileOpen = false;
		}

		public void ExitTool()
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				AddID();
				numericUpDown1.Value = numericUpDown1.Value + 1;
			}
			else
			{
				MessageBox.Show("No file loaded...");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				if (ListBox1.SelectedIndex != -1 && ListBox1.Items.Count > 0)
				{
					RemoveID(ListBox1.SelectedIndex);
				}
				else
				{
					MessageBox.Show("No section selected.");
				}
			}
			else
			{
				MessageBox.Show("No file loaded...");
			}
		}

		private void newCharacodeFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				DialogResult msg = MessageBox.Show("Are you sure you want to create a new file?", "", MessageBoxButtons.OKCancel);
				if (msg == DialogResult.OK)
				{
					NewFile();
				}
			}
			else
			{
				NewFile();
			}
		}

		private void openCharacodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				DialogResult msg = MessageBox.Show("Are you sure you want to open another file?", "", MessageBoxButtons.OKCancel);
				if (msg == DialogResult.OK)
				{
					OpenFile();
				}
			}
			else
			{
				OpenFile();
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				SaveFile();
			}
			else
			{
				MessageBox.Show("No file loaded...");
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				SaveFileAs();
			}
			else
			{
				MessageBox.Show("No file loaded...");
			}
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				DialogResult msg = MessageBox.Show("Are you sure you want to close the actual file?", "", MessageBoxButtons.OKCancel);
				if (msg == DialogResult.OK)
				{
					CloseFile();
				}
			}
			else
			{
				MessageBox.Show("No file loaded...");
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				DialogResult msg = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.OKCancel);
				if (msg == DialogResult.OK)
				{
					ExitTool();
				}
			}
			else
			{
				ExitTool();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tool_UnlockCharaTotalEditor));
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Items.AddRange(new object[] {
            "No file loaded..."});
            this.ListBox1.Location = new System.Drawing.Point(12, 34);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(343, 342);
            this.ListBox1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("CC2 RocknRoll Latin DB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(731, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newCharacodeFileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openCharacodeToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.closeToolStripMenuItem.Text = "Close File";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(357, 22);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add unlock section";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(359, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(351, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Remove selected unlock section";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Preset ID for new unlock: (Example: 7B01)";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Hexadecimal = true;
            this.numericUpDown1.Location = new System.Drawing.Point(579, 53);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 23);
            this.numericUpDown1.TabIndex = 6;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Hexadecimal = true;
            this.numericUpDown2.Location = new System.Drawing.Point(648, 53);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(66, 23);
            this.numericUpDown2.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(359, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(355, 29);
            this.button3.TabIndex = 11;
            this.button3.Text = "Add unlock  sections for specific range";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(648, 108);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(66, 23);
            this.numericUpDown3.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(602, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Count";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Hexadecimal = true;
            this.numericUpDown4.Location = new System.Drawing.Point(518, 106);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(66, 23);
            this.numericUpDown4.TabIndex = 16;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Hexadecimal = true;
            this.numericUpDown5.Location = new System.Drawing.Point(449, 106);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(63, 23);
            this.numericUpDown5.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Preset ID start: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(609, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Value";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Hexadecimal = true;
            this.numericUpDown6.Location = new System.Drawing.Point(648, 170);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(66, 23);
            this.numericUpDown6.TabIndex = 17;
            this.numericUpDown6.Value = new decimal(new int[] {
            27,
            0,
            0,
            0});
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(639, 199);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 19;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Tool_UnlockCharaTotalEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 390);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown6);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Tool_UnlockCharaTotalEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unlock Chara Total Editor";
            this.Load += new System.EventHandler(this.Tool_UnlockCharaTotalEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void button3_Click(object sender, EventArgs e)
        {
			if (FileOpen)
			{
				AddID2();
			}
			else
			{
				MessageBox.Show("No file loaded...");
			}
		}

        private void Tool_UnlockCharaTotalEditor_Load(object sender, EventArgs e) {
			if (File.Exists(Main.unlPath)) {
				OpenFile(Main.unlPath);
			}
		}

        private void button4_Click(object sender, EventArgs e) {
			if (FileOpen) {
				AddID2(false);
			} else {
				MessageBox.Show("No file loaded...");
			}
		}
    }
}
