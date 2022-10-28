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
    public partial class Tool_spTypeSupportParamEditor : Form {
        public Tool_spTypeSupportParamEditor() {
            InitializeComponent();
        }

        public bool FileOpen = false;
        public string FilePath = "";
        public byte[] fileBytes = new byte[0];
        public int EntryCount = 0;

        public List<int> Characode_List = new List<int>();
        public List<int> Type_List = new List<int>();
        public List<int> Mode_List = new List<int>();
        public List<string> LeftSkillName_List = new List<string>();
        public List<string> RightSkillName_List = new List<string>();
        public List<string> UpSkillName_List = new List<string>();
        public List<string> DownSkillName_List = new List<string>();
        public List<int> LeftSkill_unk1_List = new List<int>();
        public List<int> LeftSkill_unk2_List = new List<int>();
        public List<int> LeftSkill_unk3_List = new List<int>();
        public List<bool> LeftSkill_EnableInAir_List = new List<bool>();
        public List<bool> LeftSkill_Unknown_List = new List<bool>();
        public List<int> RightSkill_unk1_List = new List<int>();
        public List<int> RightSkill_unk2_List = new List<int>();
        public List<int> RightSkill_unk3_List = new List<int>();
        public List<bool> RightSkill_EnableInAir_List = new List<bool>();
        public List<bool> RightSkill_Unknown_List = new List<bool>();
        public List<int> UpSkill_unk1_List = new List<int>();
        public List<int> UpSkill_unk2_List = new List<int>();
        public List<int> UpSkill_unk3_List = new List<int>();
        public List<bool> UpSkill_EnableInAir_List = new List<bool>();
        public List<bool> UpSkill_Unknown_List = new List<bool>();
        public List<int> DownSkill_unk1_List = new List<int>();
        public List<int> DownSkill_unk2_List = new List<int>();
        public List<int> DownSkill_unk3_List = new List<int>();
        public List<bool> DownSkill_EnableInAir_List = new List<bool>();
        public List<bool> DownSkill_Unknown_List = new List<bool>();
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
            fileBytes = File.ReadAllBytes(FilePath);
            EntryCount = Main.b_ReadInt(fileBytes,304);

            for (int x2 = 0; x2 < EntryCount; x2++) {
                long _ptr = 316 + 0xB0 * x2;
                int Characode = Main.b_ReadInt(fileBytes, (int)_ptr);
                int Mode = Main.b_ReadInt(fileBytes, (int)_ptr + 0x04);
                int Type = Main.b_ReadInt(fileBytes, (int)_ptr + 0x08);

                long _ptrUpSkillName = Main.b_ReadInt(fileBytes,(int)_ptr+0x10);
                string UpSkillName = Main.b_ReadString(fileBytes, (int)_ptr + 0x10 + (int)_ptrUpSkillName);
                bool UpSkillUnknownValue = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x18));
                bool UpSkillEnableInAir = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x1C));
                int UpSkill_unk1 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x24);
                int UpSkill_unk2 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x28);
                int UpSkill_unk3 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x2C);

                long _ptrDownSkillName = Main.b_ReadInt(fileBytes, (int)_ptr + 0x38);
                string DownSkillName = Main.b_ReadString(fileBytes, (int)_ptr + 0x38 + (int)_ptrDownSkillName);
                bool DownSkillUnknownValue = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x40));
                bool DownSkillEnableInAir = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x44));
                int DownSkill_unk1 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x4C);
                int DownSkill_unk2 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x50);
                int DownSkill_unk3 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x54);

                long _ptrLeftSkillName = Main.b_ReadInt(fileBytes, (int)_ptr + 0x60);
                string LeftSkillName = Main.b_ReadString(fileBytes, (int)_ptr + 0x60 + (int)_ptrLeftSkillName);
                bool LeftSkillUnknownValue = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x68));
                bool LeftSkillEnableInAir = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x6C));
                int LeftSkill_unk1 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x74);
                int LeftSkill_unk2 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x78);
                int LeftSkill_unk3 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x7C);

                long _ptrRightSkillName = Main.b_ReadInt(fileBytes, (int)_ptr + 0x88);
                string RightSkillName = Main.b_ReadString(fileBytes, (int)_ptr + 0x88 + (int)_ptrRightSkillName);
                bool RightSkillUnknownValue = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x90));
                bool RightSkillEnableInAir = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x94));
                int RightSkill_unk1 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x9C);
                int RightSkill_unk2 = Main.b_ReadInt(fileBytes, (int)_ptr + 0xA0);
                int RightSkill_unk3 = Main.b_ReadInt(fileBytes, (int)_ptr + 0xA4);



                Characode_List.Add(Characode);
                Type_List.Add(Type);
                Mode_List.Add(Mode);
                LeftSkillName_List.Add(LeftSkillName);
                RightSkillName_List.Add(RightSkillName);
                UpSkillName_List.Add(UpSkillName);
                DownSkillName_List.Add(DownSkillName);
                LeftSkill_unk1_List.Add(LeftSkill_unk1);
                LeftSkill_unk2_List.Add(LeftSkill_unk2);
                LeftSkill_unk3_List.Add(LeftSkill_unk3);
                LeftSkill_EnableInAir_List.Add(LeftSkillEnableInAir);
                LeftSkill_Unknown_List.Add(LeftSkillUnknownValue);
                RightSkill_unk1_List.Add(RightSkill_unk1);
                RightSkill_unk2_List.Add(RightSkill_unk2);
                RightSkill_unk3_List.Add(RightSkill_unk3);
                RightSkill_EnableInAir_List.Add(RightSkillEnableInAir);
                RightSkill_Unknown_List.Add(RightSkillUnknownValue);
                UpSkill_unk1_List.Add(UpSkill_unk1);
                UpSkill_unk2_List.Add(UpSkill_unk2);
                UpSkill_unk3_List.Add(UpSkill_unk3);
                UpSkill_EnableInAir_List.Add(UpSkillEnableInAir);
                UpSkill_Unknown_List.Add(UpSkillUnknownValue);
                DownSkill_unk1_List.Add(DownSkill_unk1);
                DownSkill_unk2_List.Add(DownSkill_unk2);
                DownSkill_unk3_List.Add(DownSkill_unk3);
                DownSkill_EnableInAir_List.Add(DownSkillEnableInAir);
                DownSkill_Unknown_List.Add(DownSkillUnknownValue);

            }
            for (int x = 0; x < EntryCount; x++) {
                string NewItem = "Characode: " + BitConverter.GetBytes(Characode_List[x])[0].ToString("X2") + " " + BitConverter.GetBytes(Characode_List[x])[1].ToString("X2");
                listBox1.Items.Add(NewItem);
            }
        }
        public void ClearFile() {
            FileOpen = false;
            FilePath = "";
            fileBytes = new byte[0];
            EntryCount = 0;
            Characode_List = new List<int>();
            Type_List = new List<int>();
            Mode_List = new List<int>();
            LeftSkillName_List = new List<string>();
            RightSkillName_List = new List<string>();
            UpSkillName_List = new List<string>();
            DownSkillName_List = new List<string>();
            LeftSkill_unk1_List = new List<int>();
            LeftSkill_unk2_List = new List<int>();
            LeftSkill_unk3_List = new List<int>();
            LeftSkill_EnableInAir_List = new List<bool>();
            LeftSkill_Unknown_List = new List<bool>();
            RightSkill_unk1_List = new List<int>();
            RightSkill_unk2_List = new List<int>();
            RightSkill_unk3_List = new List<int>();
            RightSkill_EnableInAir_List = new List<bool>();
            RightSkill_Unknown_List = new List<bool>();
            UpSkill_unk1_List = new List<int>();
            UpSkill_unk2_List = new List<int>();
            UpSkill_unk3_List = new List<int>();
            UpSkill_EnableInAir_List = new List<bool>();
            UpSkill_Unknown_List = new List<bool>();
            DownSkill_unk1_List = new List<int>();
            DownSkill_unk2_List = new List<int>();
            DownSkill_unk3_List = new List<int>();
            DownSkill_EnableInAir_List = new List<bool>();
            DownSkill_Unknown_List = new List<bool>();
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count) {
                numericUpDown13.Value = Characode_List[x];
                comboBox1.SelectedIndex = Type_List[x];
                comboBox2.SelectedIndex = Mode_List[x];

                textBox2.Text = LeftSkillName_List[x];
                numericUpDown1.Value = LeftSkill_unk1_List[x];
                numericUpDown2.Value = LeftSkill_unk2_List[x];
                numericUpDown3.Value = LeftSkill_unk3_List[x];
                checkBox2.Checked = LeftSkill_Unknown_List[x];
                checkBox1.Checked = LeftSkill_EnableInAir_List[x];

                textBox3.Text = RightSkillName_List[x];
                numericUpDown6.Value = RightSkill_unk1_List[x];
                numericUpDown5.Value = RightSkill_unk2_List[x];
                numericUpDown4.Value = RightSkill_unk3_List[x];
                checkBox3.Checked = RightSkill_Unknown_List[x];
                checkBox4.Checked = RightSkill_EnableInAir_List[x];

                textBox4.Text = UpSkillName_List[x];
                numericUpDown9.Value = UpSkill_unk1_List[x];
                numericUpDown8.Value = UpSkill_unk2_List[x];
                numericUpDown7.Value = UpSkill_unk3_List[x];
                checkBox5.Checked = UpSkill_Unknown_List[x];
                checkBox6.Checked = UpSkill_EnableInAir_List[x];

                textBox5.Text = DownSkillName_List[x];
                numericUpDown12.Value = DownSkill_unk1_List[x];
                numericUpDown11.Value = DownSkill_unk2_List[x];
                numericUpDown10.Value = DownSkill_unk3_List[x];
                checkBox7.Checked = DownSkill_Unknown_List[x];
                checkBox8.Checked = DownSkill_EnableInAir_List[x];
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            if (FileOpen) {
                if (numericUpDown14.Value != 0) {
                    int index = Characode_List.IndexOf((int)numericUpDown14.Value);
                    listBox1.SelectedIndex = index;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                Characode_List[x] = (int)numericUpDown13.Value;
                Type_List[x] = comboBox1.SelectedIndex;
                Mode_List[x] = comboBox2.SelectedIndex;

                LeftSkillName_List[x] = textBox2.Text;
                LeftSkill_unk1_List[x] = (int)numericUpDown1.Value;
                LeftSkill_unk2_List[x] = (int)numericUpDown2.Value;
                LeftSkill_unk3_List[x] = (int)numericUpDown3.Value;
                LeftSkill_Unknown_List[x] = checkBox2.Checked;
                LeftSkill_EnableInAir_List[x] = checkBox1.Checked;

                RightSkillName_List[x] = textBox3.Text;
                RightSkill_unk1_List[x] = (int)numericUpDown6.Value;
                RightSkill_unk2_List[x] = (int)numericUpDown5.Value;
                RightSkill_unk3_List[x] = (int)numericUpDown4.Value;
                RightSkill_Unknown_List[x] = checkBox3.Checked;
                RightSkill_EnableInAir_List[x] = checkBox4.Checked;

                UpSkillName_List[x] = textBox4.Text;
                UpSkill_unk1_List[x] = (int)numericUpDown9.Value;
                UpSkill_unk2_List[x] = (int)numericUpDown8.Value;
                UpSkill_unk3_List[x] = (int)numericUpDown7.Value;
                UpSkill_Unknown_List[x] = checkBox5.Checked;
                UpSkill_EnableInAir_List[x] = checkBox6.Checked;

                DownSkillName_List[x] = textBox5.Text;
                DownSkill_unk1_List[x] = (int)numericUpDown12.Value;
                DownSkill_unk2_List[x] = (int)numericUpDown11.Value;
                DownSkill_unk3_List[x] = (int)numericUpDown10.Value;
                DownSkill_Unknown_List[x] = checkBox7.Checked;
                DownSkill_EnableInAir_List[x] = checkBox8.Checked;

                listBox1.Items[x] = "Characode: " + BitConverter.GetBytes(Characode_List[x])[0].ToString("X2") + " " + BitConverter.GetBytes(Characode_List[x])[1].ToString("X2");
            }
            else {
                MessageBox.Show("Select section");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                Characode_List.Add((int)numericUpDown13.Value);
                Type_List.Add(comboBox1.SelectedIndex);
                Mode_List.Add(comboBox2.SelectedIndex);

                LeftSkillName_List.Add(textBox2.Text);
                LeftSkill_unk1_List.Add((int)numericUpDown1.Value);
                LeftSkill_unk2_List.Add((int)numericUpDown2.Value);
                LeftSkill_unk3_List.Add((int)numericUpDown3.Value);
                LeftSkill_Unknown_List.Add(checkBox2.Checked);
                LeftSkill_EnableInAir_List.Add(checkBox1.Checked);

                RightSkillName_List.Add(textBox3.Text);
                RightSkill_unk1_List.Add((int)numericUpDown6.Value);
                RightSkill_unk2_List.Add((int)numericUpDown5.Value);
                RightSkill_unk3_List.Add((int)numericUpDown4.Value);
                RightSkill_Unknown_List.Add(checkBox3.Checked);
                RightSkill_EnableInAir_List.Add(checkBox4.Checked);

                UpSkillName_List.Add(textBox4.Text);
                UpSkill_unk1_List.Add((int)numericUpDown9.Value);
                UpSkill_unk2_List.Add((int)numericUpDown8.Value);
                UpSkill_unk3_List.Add((int)numericUpDown7.Value);
                UpSkill_Unknown_List.Add(checkBox5.Checked);
                UpSkill_EnableInAir_List.Add(checkBox6.Checked);

                DownSkillName_List.Add(textBox5.Text);
                DownSkill_unk1_List.Add((int)numericUpDown12.Value);
                DownSkill_unk2_List.Add((int)numericUpDown11.Value);
                DownSkill_unk3_List.Add((int)numericUpDown10.Value);
                DownSkill_Unknown_List.Add(checkBox7.Checked);
                DownSkill_EnableInAir_List.Add(checkBox8.Checked);

                listBox1.Items.Add("Characode: " + BitConverter.GetBytes(Characode_List[x])[0].ToString("X2") + " " + BitConverter.GetBytes(Characode_List[x])[1].ToString("X2"));
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                EntryCount++;
            } else {
                MessageBox.Show("Select section");
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                Characode_List.RemoveAt(x);
                Type_List.RemoveAt(x);
                Mode_List.RemoveAt(x);

                LeftSkillName_List.RemoveAt(x);
                LeftSkill_unk1_List.RemoveAt(x);
                LeftSkill_unk2_List.RemoveAt(x);
                LeftSkill_unk3_List.RemoveAt(x);
                LeftSkill_Unknown_List.RemoveAt(x);
                LeftSkill_EnableInAir_List.RemoveAt(x);

                RightSkillName_List.RemoveAt(x);
                RightSkill_unk1_List.RemoveAt(x);
                RightSkill_unk2_List.RemoveAt(x);
                RightSkill_unk3_List.RemoveAt(x);
                RightSkill_Unknown_List.RemoveAt(x);
                RightSkill_EnableInAir_List.RemoveAt(x);

                UpSkillName_List.RemoveAt(x);
                UpSkill_unk1_List.RemoveAt(x);
                UpSkill_unk2_List.RemoveAt(x);
                UpSkill_unk3_List.RemoveAt(x);
                UpSkill_Unknown_List.RemoveAt(x);
                UpSkill_EnableInAir_List.RemoveAt(x);

                DownSkillName_List.RemoveAt(x);
                DownSkill_unk1_List.RemoveAt(x);
                DownSkill_unk2_List.RemoveAt(x);
                DownSkill_unk3_List.RemoveAt(x);
                DownSkill_Unknown_List.RemoveAt(x);
                DownSkill_EnableInAir_List.RemoveAt(x);
                listBox1.Items.RemoveAt(x);
                listBox1.SelectedIndex = x - 1;
                EntryCount--;
            } else {
                MessageBox.Show("Select section");
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
            byte[] file = new byte[0];
            byte[] header = new byte[316]
            {
                0x4E,0x55,0x43,0x43,0x00,0x00,0x00,0x79,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xE8,0x00,0x00,0x00,0x03,0x00,0x79,0x00,0x00,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x3B,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x23,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x20,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x4E,0x75,0x6C,0x6C,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x42,0x69,0x6E,0x61,0x72,0x79,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x50,0x61,0x67,0x65,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x49,0x6E,0x64,0x65,0x78,0x00,0x00,0x62,0x69,0x6E,0x5F,0x6C,0x65,0x2F,0x78,0x36,0x34,0x2F,0x73,0x70,0x54,0x79,0x70,0x65,0x53,0x75,0x70,0x70,0x6F,0x72,0x74,0x50,0x61,0x72,0x61,0x6D,0x2E,0x62,0x69,0x6E,0x00,0x00,0x73,0x70,0x54,0x79,0x70,0x65,0x53,0x75,0x70,0x70,0x6F,0x72,0x74,0x50,0x61,0x72,0x61,0x6D,0x00,0x50,0x61,0x67,0x65,0x30,0x00,0x69,0x6E,0x64,0x65,0x78,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x79,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x79,0x00,0x00,0x00,0x00,0x3F,0xC4,0x00,0x00,0x00,0x01,0x00,0x79,0x00,0x00,0x00,0x00,0x3F,0xC0,0xE9,0x03,0x00,0x00,0x4E,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x00,0x00,0x00,0x00
            };

            file = Main.b_AddBytes(file, header);
            file = Main.b_AddBytes(file, new byte[0xB0*EntryCount]);

            List<int> UpSkillNamePointer = new List<int>();
            List<int> DownSkillNamePointer = new List<int>();
            List<int> LeftSkillNamePointer = new List<int>();
            List<int> RightSkillNamePointer = new List<int>();

            for (int x2 = 0; x2 < EntryCount; x2++) {
                UpSkillNamePointer.Add(file.Length);
                if (UpSkillName_List[x2] != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(UpSkillName_List[x2]));
                    file = Main.b_AddBytes(file, new byte[1]);
                }
                DownSkillNamePointer.Add(file.Length);
                if (DownSkillName_List[x2] != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(DownSkillName_List[x2]));
                    file = Main.b_AddBytes(file, new byte[1]);
                }
                LeftSkillNamePointer.Add(file.Length);
                if (LeftSkillName_List[x2] != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(LeftSkillName_List[x2]));
                    file = Main.b_AddBytes(file, new byte[1]);
                }
                RightSkillNamePointer.Add(file.Length);
                if (RightSkillName_List[x2] != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(RightSkillName_List[x2]));
                    file = Main.b_AddBytes(file, new byte[1]);
                }


                
                int newPointer3 = UpSkillNamePointer[x2] - 316 - 0xB0 * x2 - 0x10;
                byte[] ptrBytes3 = BitConverter.GetBytes(newPointer3);
                if (UpSkillName_List[x2] != "") {
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 316 + 0xB0 * x2 + 0x10);
                }
                newPointer3 = DownSkillNamePointer[x2] - 316 - 0xB0 * x2 - 0x38;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                if (DownSkillName_List[x2] != "") {
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 316 + 0xB0 * x2 + 0x38);
                }
                newPointer3 = LeftSkillNamePointer[x2] - 316 - 0xB0 * x2 - 0x60;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                if (LeftSkillName_List[x2] != "") {
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 316 + 0xB0 * x2 + 0x60);
                }
                newPointer3 = RightSkillNamePointer[x2] - 316 - 0xB0 * x2 - 0x88;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                if (RightSkillName_List[x2] != "") {
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 316 + 0xB0 * x2 + 0x88);
                }
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(Characode_List[x2]), 316 + 0xB0 * x2 + 0x00);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(Mode_List[x2]), 316 + 0xB0 * x2 + 0x04);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(Type_List[x2]), 316 + 0xB0 * x2 + 0x08);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(UpSkill_Unknown_List[x2]), 316 + 0xB0 * x2 + 0x18);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(UpSkill_EnableInAir_List[x2]), 316 + 0xB0 * x2 + 0x1C);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(UpSkill_unk1_List[x2]), 316 + 0xB0 * x2 + 0x24);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(UpSkill_unk2_List[x2]), 316 + 0xB0 * x2 + 0x28);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(UpSkill_unk3_List[x2]), 316 + 0xB0 * x2 + 0x2C);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(DownSkill_Unknown_List[x2]), 316 + 0xB0 * x2 + 0x40);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(DownSkill_EnableInAir_List[x2]), 316 + 0xB0 * x2 + 0x44);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(DownSkill_unk1_List[x2]), 316 + 0xB0 * x2 + 0x4C);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(DownSkill_unk2_List[x2]), 316 + 0xB0 * x2 + 0x50);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(DownSkill_unk3_List[x2]), 316 + 0xB0 * x2 + 0x54);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(LeftSkill_Unknown_List[x2]), 316 + 0xB0 * x2 + 0x68);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(LeftSkill_EnableInAir_List[x2]), 316 + 0xB0 * x2 + 0x6C);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(LeftSkill_unk1_List[x2]), 316 + 0xB0 * x2 + 0x74);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(LeftSkill_unk2_List[x2]), 316 + 0xB0 * x2 + 0x78);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(LeftSkill_unk3_List[x2]), 316 + 0xB0 * x2 + 0x7C);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(RightSkill_Unknown_List[x2]), 316 + 0xB0 * x2 + 0x90);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(RightSkill_EnableInAir_List[x2]), 316 + 0xB0 * x2 + 0x94);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(RightSkill_unk1_List[x2]), 316 + 0xB0 * x2 + 0x9C);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(RightSkill_unk2_List[x2]), 316 + 0xB0 * x2 + 0xA0);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(RightSkill_unk3_List[x2]), 316 + 0xB0 * x2 + 0xA4);
                
            }
            int FileSize = file.Length - 300;
            file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(FileSize), 296, 1);
            file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(FileSize+4), 284, 1);
            file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(EntryCount), 304);
            byte[] finalBytes = new byte[20]
            {
                0,0,0,8,0,0,0,2,0,121,24,0,0,0,0,4,0,0,0,0
            };
            file = Main.b_AddBytes(file, finalBytes);
            return file;
        }

        private void Tool_spTypeSupportParamEditor_Load(object sender, EventArgs e) {
            if (File.Exists(Main.spTypeSupportParamPath)) {
                OpenFile(Main.spTypeSupportParamPath);
            }
        }
    }
}
