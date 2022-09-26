using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSUNS4_Character_Manager.Tools {
    public partial class Tool_effectprmEditor : Form {
        public Tool_effectprmEditor() {
            InitializeComponent();
        }
        public bool FileOpen = false;
        public string FilePath = "";
        public byte[] fileBytes = new byte[0];
        public int EntryCount = 0;

        public List<int> EffectPrmID_List = new List<int>();
        public List<int> EffectPrmType_List = new List<int>();
        public List<string> EffectPrmPath_List = new List<string>();
        public List<string> EffectPrmAnm_List = new List<string>();
        private void button1_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x!=-1) {
                EffectPrmID_List.Add((int)numericUpDown1.Value);
                EffectPrmType_List.Add((int)numericUpDown2.Value);
                EffectPrmPath_List.Add(textBox2.Text);
                EffectPrmAnm_List.Add(textBox3.Text);
                EntryCount++;
                listBox1.Items.Add("Effect ID: " + numericUpDown1.Value.ToString() + ", Anm: " + textBox3.Text);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            } else {
                MessageBox.Show("Select entry.");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                EffectPrmID_List[x] = (int)numericUpDown1.Value;
                EffectPrmType_List[x] = (int)numericUpDown2.Value;
                EffectPrmPath_List[x] = textBox2.Text;
                EffectPrmAnm_List[x] = textBox3.Text;
                listBox1.Items[x] = "Effect ID: " + numericUpDown1.Value.ToString() + ", Anm: " + textBox3.Text;

            } else {
                MessageBox.Show("Select entry.");
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                EffectPrmID_List.RemoveAt(x);
                EffectPrmType_List.RemoveAt(x);
                EffectPrmPath_List.RemoveAt(x);
                EffectPrmAnm_List.RemoveAt(x);
                EntryCount--;
                listBox1.Items.RemoveAt(x);
                listBox1.SelectedIndex = x - 1;
            } else {
                MessageBox.Show("Select entry.");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFile();
        }
        public void OpenFile(string basepath = "") {
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
            if (!(o.FileName != "") || !File.Exists(o.FileName)) {
                return;
            }
            ClearFile();
            FileOpen = true;
            FilePath = o.FileName;
            byte[] FileBytes = File.ReadAllBytes(FilePath);
            EntryCount = Main.b_ReadInt(FileBytes, 0x138);
            for (int x2 = 0; x2 < EntryCount; x2++) {
                long _ptr = 0x13C + 0x88 * x2;

                int EffectId = Main.b_ReadInt(FileBytes, (int)_ptr);
                int EffectType = Main.b_ReadInt(FileBytes, (int)_ptr + 0x04);
                string EffectPath = Main.b_ReadString(FileBytes, (int)_ptr + 0x08);
                string EffectAnm = Main.b_ReadString(FileBytes, (int)_ptr + 0x48);


                EffectPrmID_List.Add(EffectId);
                EffectPrmType_List.Add(EffectType);
                EffectPrmPath_List.Add(EffectPath);
                EffectPrmAnm_List.Add(EffectAnm);

            }

            for (int x = 0; x < EntryCount; x++) {
                string NewItem = "Effect ID: " + EffectPrmID_List[x].ToString() + ", Anm: " + EffectPrmAnm_List[x];
                listBox1.Items.Add(NewItem);
            }
        }
        public void ClearFile() {

            EntryCount = 0;
            EffectPrmID_List = new List<int>();
            EffectPrmType_List = new List<int>();
            EffectPrmPath_List = new List<string>();
            EffectPrmAnm_List = new List<string>();
            listBox1.Items.Clear();
        }
        public void CloseFile() {
            ClearFile();
            FileOpen = false;
            FilePath = "";
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            if (FileOpen) {
                DialogResult msg = MessageBox.Show("Are you sure you want to close this file?", "", MessageBoxButtons.OKCancel);
                if (msg == DialogResult.OK) {
                    CloseFile();
                }
            } else {
                MessageBox.Show("No file loaded...");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (FileOpen) {
                SaveFile();
            } else {
                MessageBox.Show("No file loaded...");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (FileOpen) {
                SaveFileAs();
            } else {
                MessageBox.Show("No file loaded...");
            }
        }

        public void SaveFile() {
            if (FilePath != "") {
                if (File.Exists(FilePath + ".backup")) {
                    File.Delete(FilePath + ".backup");
                }
                File.Copy(FilePath, FilePath + ".backup");
                File.WriteAllBytes(FilePath, ConvertToFile());
                if (this.Visible) MessageBox.Show("File saved to " + FilePath + ".");
            } else {
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
        public byte[] ConvertToFile() {
            List<byte> file = new List<byte>();
            byte[] header = new byte[316]
            {
               0x4E,0x55,0x43,0x43,0x00,0x00,0x00,0x63,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x00,0x03,0x00,0x63,0x40,0x00,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x3B,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x44,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x17,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x4E,0x75,0x6C,0x6C,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x42,0x69,0x6E,0x61,0x72,0x79,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x50,0x61,0x67,0x65,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x49,0x6E,0x64,0x65,0x78,0x00,0x00,0x44,0x3A,0x2F,0x75,0x73,0x65,0x72,0x2F,0x6E,0x61,0x72,0x75,0x74,0x6F,0x4E,0x65,0x78,0x74,0x34,0x5F,0x74,0x72,0x75,0x6E,0x6B,0x2F,0x70,0x61,0x72,0x61,0x6D,0x2F,0x70,0x6C,0x61,0x79,0x65,0x72,0x2F,0x43,0x6F,0x6E,0x76,0x65,0x72,0x74,0x65,0x72,0x2F,0x62,0x69,0x6E,0x2F,0x65,0x66,0x66,0x65,0x63,0x74,0x70,0x72,0x6D,0x2E,0x62,0x69,0x6E,0x00,0x00,0x65,0x66,0x66,0x65,0x63,0x74,0x70,0x72,0x6D,0x00,0x50,0x61,0x67,0x65,0x30,0x00,0x69,0x6E,0x64,0x65,0x78,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x63,0x42,0x00,0x00,0x00,0xF1,0x38,0x00,0x00,0x00,0x01,0x00,0x63,0x42,0x00,0x00,0x00,0xF1,0x34,0xC6,0x01,0x00,0x00
            };
            for (int x4 = 0; x4 < header.Length; x4++) {
                file.Add(header[x4]);
            }
            for (int x3 = 0; x3 < EntryCount * 0x88; x3++) {
                file.Add(0);
            }
            int Section_size = 4;
            for (int x2 = 0; x2 < EntryCount; x2++) {
                Section_size += 0x88;
                int _ptr = 0x13C + 0x88 * x2;
                byte[] o_a = BitConverter.GetBytes(EffectPrmID_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(EffectPrmType_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x04] = o_a[a8];
                }
                for (int a8 = 0; a8 < EffectPrmPath_List[x2].Length; a8++) {
                    file[_ptr + a8 + 0x08] = (byte)EffectPrmPath_List[x2][a8];
                }
                for (int a8 = 0; a8 < EffectPrmAnm_List[x2].Length; a8++) {
                    file[_ptr + a8 + 0x48] = (byte)EffectPrmAnm_List[x2][a8];
                }
                
            }


            byte[] TUJ_sizeBytes1 = BitConverter.GetBytes(Section_size);
            byte[] TUJ_sizeBytes2 = BitConverter.GetBytes(Section_size + 4);
            for (int a20 = 0; a20 < 4; a20++) {
                file[0x128 + a20] = TUJ_sizeBytes2[3 - a20];
            }
            for (int a19 = 0; a19 < 4; a19++) {
                file[0x134 + a19] = TUJ_sizeBytes1[3 - a19];
            }
            byte[] countBytes = BitConverter.GetBytes(EntryCount);
            for (int a18 = 0; a18 < 4; a18++) {
                file[0x138 + a18] = countBytes[a18];
            }



            byte[] finalBytes = new byte[20]
            {
              0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x02,0x00,0x63,0x19,0x00,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x00
            };
            for (int x = 0; x < finalBytes.Length; x++) {
                file.Add(finalBytes[x]);
            }
            return file.ToArray();
        }
        private void Tool_effectprmEditor_Load(object sender, EventArgs e) {
            if (File.Exists(Main.effectprmPath)) {
                OpenFile(Main.effectprmPath);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x!=-1) {
                numericUpDown1.Value = EffectPrmID_List[x];
                numericUpDown2.Value = EffectPrmType_List[x];
                textBox2.Text = EffectPrmPath_List[x];
                textBox3.Text = EffectPrmAnm_List[x];
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            if (textBox1.Text != "") {
                for (int x = 0; x<listBox1.Items.Count; x++) {
                    if (listBox1.Items[x].ToString().Contains(textBox1.Text)) {
                        listBox1.SelectedIndex = x;
                        break;
                    }
                }
            }
        }
    }
}
