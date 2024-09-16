using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NSUNS4_Character_Manager
{
	public class Tool_CharacodeEditor : Form
	{
		public bool FileOpen = false;

		public string FilePath = "";

		public byte[] fileBytes = new byte[0];

		public List<string> CharacterList = new List<string>();

		public int CharacterCount = 0;

		private IContainer components = null;

		private ListBox ListBox1;

		private Button button2;

		private Button button1;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem fileToolStripMenuItem;

		private ToolStripMenuItem newCharacodeFileToolStripMenuItem;

		private ToolStripMenuItem openCharacodeToolStripMenuItem;

		private ToolStripMenuItem saveToolStripMenuItem;

		private ToolStripMenuItem saveAsToolStripMenuItem;

		private ToolStripMenuItem closeToolStripMenuItem;
        private TextBox Search_TB;
        private Button Search;
        private Button button3;
        private Button button4;
        private Button button5;
        private TextBox textBox1;

		public Tool_CharacodeEditor()
		{
			InitializeComponent();
		}

		public void NewFile()
		{
			fileBytes = new byte[0];
			FilePath = "";
			ListBox1.Items.Clear();
			CharacterList = new List<string>();
			CharacterCount = 0;
			FileOpen = true;
		}

		public void OpenFile(string path = "")
		{
			OpenFileDialog o = new OpenFileDialog();
			o.DefaultExt = "xfbin";

            if(path == "") o.ShowDialog();
            else o.FileName = path;

            if (!(o.FileName != "") || !File.Exists(o.FileName))
            {
                return;
            }

            ListBox1.Items.Clear();
            FilePath = o.FileName;
            fileBytes = File.ReadAllBytes(FilePath);

            // Check for NUCC in header
            if (!(fileBytes.Length > 0x44 && Main.b_ReadString(fileBytes, 0, 4) == "NUCC"))
            {
                MessageBox.Show("Not a valid .xfbin file.");
                return;
            }

			if (XfbinParser.GetNameList(fileBytes)[0] == "characode")
			{
                int fileStart = XfbinParser.GetFileSectionIndex(fileBytes);
                CharacterCount = Main.b_ReadInt(fileBytes, fileStart + 0x1C);

				CharacterList = new List<string>();
				for (int x = 0; x < CharacterCount; x++)
				{
                    string character = Main.b_ReadString(fileBytes, fileStart + 0x20 + (x * 8));
                    CharacterList.Add(character);
					ListBox1.Items.Add((x + 1).ToString("X2") + " = " + character);
				}

                FileOpen = true;
                //if (this.Visible) MessageBox.Show("Characode contains " + CharacterCount + " character IDs.");
			}
			else
			{
				MessageBox.Show("Please select a valid characode file.");
				FilePath = "";
				fileBytes = new byte[0];
				FileOpen = false;
			}
		}

		public void AddID(string ID)
		{
			CharacterList.Add(ID);
			ListBox1.Items.Add((CharacterCount + 1).ToString("X2") + " = " + ID);
			ListBox1.SelectedIndex = ListBox1.Items.Count - 1;
			CharacterCount++;
		}

		public void RemoveID(int Index)
		{
			CharacterList.RemoveAt(Index);
			if (ListBox1.SelectedIndex > 0)
			{
				ListBox1.SelectedIndex--;
			}
			else
			{
				ListBox1.ClearSelected();
			}
			ListBox1.Items.RemoveAt(Index);
			CharacterCount--;
			UpdateList();
		}

		public byte[] ConvertToFile()
		{
            byte[] actual = new byte[0];
            int startOfFile = XfbinParser.GetFileSectionIndex(fileBytes);
            for (int x = 0; x < startOfFile + 0x20; x++) actual = Main.b_AddBytes(actual, new byte[] { fileBytes[x] });

            actual = Main.b_ReplaceBytes(actual, BitConverter.GetBytes(CharacterCount), startOfFile + 0x20 - 0x4);
            actual = Main.b_ReplaceBytes(actual, BitConverter.GetBytes((CharacterCount * 8) + 0x4), startOfFile + 0x20 - 0x8, 1);
            actual = Main.b_ReplaceBytes(actual, BitConverter.GetBytes((CharacterCount * 8) + 0x8), startOfFile + 0x20 - 0x8 - 0xC, 1);

            for (int x = 0; x < CharacterCount; x++)
			{
                actual = Main.b_AddBytes(actual, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
                actual = Main.b_ReplaceString(actual, CharacterList[x], startOfFile + 0x20 + (0x8 * x));
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
				99,
				0,
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

            actual = Main.b_AddBytes(actual, finalBytes);
            return actual;
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
                if (this.Visible) MessageBox.Show("File saved to " + FilePath + ".");
			}
			else
			{
				SaveFileAs();
			}
		}

		public void SaveFileAs(string basepath = "") {
			SaveFileDialog s = new SaveFileDialog();
			{
				s.DefaultExt = ".xfbin";
				s.Filter = "*.xfbin|*.xfbin";
			}
			if (basepath != "")
				s.FileName = basepath;
			else
				s.ShowDialog();
			if (!(s.FileName != "")) {
				return;
			}
			if (s.FileName == FilePath) {
				if (File.Exists(FilePath + ".backup")) {
					File.Delete(FilePath + ".backup");
				}
				File.Copy(FilePath, FilePath + ".backup");
			} else {
				FilePath = s.FileName;
			}
			File.WriteAllBytes(FilePath, ConvertToFile());
			if (basepath == "")
				MessageBox.Show("File saved to " + FilePath + ".");
		}

		public void CloseFile()
		{
			CharacterList.Clear();
			ListBox1.Items.Clear();
			ListBox1.Items.Add("No file loaded...");
			CharacterCount = 0;
			FilePath = "";
			fileBytes = new byte[0];
			FileOpen = false;
		}

		public void UpdateList()
		{
			for (int x = 0; x < CharacterCount; x++)
			{
				string character = CharacterList[x];
				ListBox1.Items[x] = (x + 1).ToString("X2") + " = " + character;
			}
		}

		public void ExitTool()
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				if (textBox1.Text != "" && !CharacterList.Contains(textBox1.Text))
				{
					AddID(textBox1.Text);
					textBox1.Text = "";
				}
				else if (textBox1.Text == "")
				{
					MessageBox.Show("ID to add is empty!");
				}
				else
				{
					MessageBox.Show("ID already exists in characode.");
				}
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
					MessageBox.Show("No ID selected.");
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
					CloseFile();
					OpenFile();
				}
			}
			else
			{
				CloseFile();
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
				DialogResult msg = MessageBox.Show("Are you sure you want to discard this file?", "", MessageBoxButtons.OKCancel);
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
			ExitTool();
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
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCharacodeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCharacodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Search_TB = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Items.AddRange(new object[] {
            "No file loaded..."});
            this.ListBox1.Location = new System.Drawing.Point(10, 29);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(319, 277);
            this.ListBox1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(339, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove selected ID";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add new ID";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("CC2 RocknRoll Latin DB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(354, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCharacodeFileToolStripMenuItem,
            this.openCharacodeToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newCharacodeFileToolStripMenuItem
            // 
            this.newCharacodeFileToolStripMenuItem.Name = "newCharacodeFileToolStripMenuItem";
            this.newCharacodeFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.newCharacodeFileToolStripMenuItem.Text = "New";
            this.newCharacodeFileToolStripMenuItem.Click += new System.EventHandler(this.newCharacodeFileToolStripMenuItem_Click);
            // 
            // openCharacodeToolStripMenuItem
            // 
            this.openCharacodeToolStripMenuItem.Name = "openCharacodeToolStripMenuItem";
            this.openCharacodeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openCharacodeToolStripMenuItem.Text = "Open";
            this.openCharacodeToolStripMenuItem.Click += new System.EventHandler(this.openCharacodeToolStripMenuItem_Click);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 307);
            this.textBox1.MaxLength = 8;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 23);
            this.textBox1.TabIndex = 5;
            // 
            // Search_TB
            // 
            this.Search_TB.Location = new System.Drawing.Point(11, 374);
            this.Search_TB.MaxLength = 15;
            this.Search_TB.Name = "Search_TB";
            this.Search_TB.Size = new System.Drawing.Size(231, 23);
            this.Search_TB.TabIndex = 38;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(243, 374);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(106, 23);
            this.Search.TabIndex = 37;
            this.Search.Text = "Search ID";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(176, 331);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 23);
            this.button3.TabIndex = 39;
            this.button3.Text = "Save ID";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(328, 29);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(21, 143);
            this.button4.TabIndex = 40;
            this.button4.Text = "▲";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(328, 171);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(21, 136);
            this.button5.TabIndex = 41;
            this.button5.Text = "▼";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Tool_CharacodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 403);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Search_TB);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Tool_CharacodeEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Characode Editor";
            this.Load += new System.EventHandler(this.Tool_CharacodeEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Search_Click(object sender, EventArgs e)
        {
			if (FileOpen)
			{
				if (Search_TB.Text != "")
				{
					if (Main.SearchStringIndex(CharacterList, Search_TB.Text, CharacterCount, ListBox1.SelectedIndex) != -1)
					{
						ListBox1.SelectedIndex = Main.SearchStringIndex(CharacterList, Search_TB.Text, CharacterCount, ListBox1.SelectedIndex);
					}
					else
					{
						if (Main.SearchStringIndex(CharacterList, Search_TB.Text, CharacterCount, 0) != -1)
						{
							ListBox1.SelectedIndex = Main.SearchStringIndex(CharacterList, Search_TB.Text, CharacterCount, -1);
						}
						else
						{
							MessageBox.Show("Characode with that name doesn't exist in file");
						}
					}
				}
				else
				{
					MessageBox.Show("Write name of characode in textbox");
				}
			}
			else
			{
				MessageBox.Show("Open file before trying to search characode");
			}
		}

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Tool_CharacodeEditor_Load(object sender, EventArgs e)
        {
			if (File.Exists(Main.chaPath)) {
				OpenFile(Main.chaPath);
			}
        }

        void SwitchMoveUp() {
            int x = ListBox1.SelectedIndex;
			if (x != -1) {
				if (x > 0) {
                    string CharacodeID = CharacterList[x];
                    string CharacodeID_new = CharacterList[x-1];
                    CharacterList[x] = CharacodeID_new;
                    CharacterList[x - 1] = CharacodeID;


                    ListBox1.Items[x-1] = (x).ToString("X2") + " = " + CharacodeID;
                    ListBox1.Items[x] = (x+1).ToString("X2") + " = " + CharacodeID_new;
					ListBox1.SelectedIndex = ListBox1.SelectedIndex - 1;
                }
			} else
				MessageBox.Show("Select entry");
                
        }

        void SwitchMoveDown() {
            int x = ListBox1.SelectedIndex;
            if (x != -1) {
                if (x < ListBox1.Items.Count) {
                    string CharacodeID = CharacterList[x];
                    string CharacodeID_new = CharacterList[x + 1];
                    CharacterList[x] = CharacodeID_new;
                    CharacterList[x + 1] = CharacodeID;


                    ListBox1.Items[x + 1] = (x+2).ToString("X2") + " = " + CharacodeID;
                    ListBox1.Items[x] = (x + 1).ToString("X2") + " = " + CharacodeID_new;
                    ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1;
                }
            } else
                MessageBox.Show("Select entry");

        }

        private void button3_Click(object sender, EventArgs e) {
			int x = ListBox1.SelectedIndex;
			if (x != -1) {
				CharacterList[x] = textBox1.Text;
				ListBox1.Items[x] = (x+1).ToString("X2") + " = " + textBox1.Text;

            }
        }

        private void button4_Click(object sender, EventArgs e) {
			SwitchMoveUp();
        }

        private void button5_Click(object sender, EventArgs e) {
			SwitchMoveDown();
        }
    }
}
