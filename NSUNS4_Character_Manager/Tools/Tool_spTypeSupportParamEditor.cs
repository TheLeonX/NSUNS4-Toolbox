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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace NSUNS4_Character_Manager.Tools {
    public partial class Tool_spTypeSupportParamEditor : Form {
        public Tool_spTypeSupportParamEditor() {
            InitializeComponent();
        }

        public bool FileOpen = false;
        public string FilePath = "";
        public byte[] fileBytes = new byte[0];
        public int EntryCount = 0;

        public class spTypeSupportParamEntry {
            public int characode;
            public int type;
            public int mode;
            public string leftSkillName;
            public string rightSkillName;
            public string upSkillName;
            public string downSkillName;
            public int leftSkill_unk1;
            public int leftSkill_unk2;
            public int leftSkill_unk3;
            public bool leftSkill_EnableInAir;
            public bool leftSkill_EnableInGround;
            public bool leftSkill_unk4;
            public int rightSkill_unk1;
            public int rightSkill_unk2;
            public int rightSkill_unk3;
            public bool rightSkill_EnableInAir;
            public bool rightSkill_EnableInGround;
            public bool rightSkill_unk4;
            public int upSkill_unk1;
            public int upSkill_unk2;
            public int upSkill_unk3;
            public bool upSkill_EnableInAir;
            public bool upSkill_EnableInGround;
            public bool upSkill_unk4;
            public int downSkill_unk1;
            public int downSkill_unk2;
            public int downSkill_unk3;
            public bool downSkill_EnableInAir;
            public bool downSkill_EnableInGround;
            public bool downSkill_unk4;
        }

        public List<spTypeSupportParamEntry> spTypeSupportParam = new List<spTypeSupportParamEntry>();


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
            EntryCount = Main.b_ReadInt(fileBytes, 304);

            for (int x2 = 0; x2 < EntryCount; x2++) {
                spTypeSupportParamEntry entry = new spTypeSupportParamEntry();
                long _ptr = 316 + 0xB0 * x2;
                entry.characode = Main.b_ReadInt(fileBytes, (int)_ptr);
                entry.mode = Main.b_ReadInt(fileBytes, (int)_ptr + 0x04);
                entry.type = Main.b_ReadInt(fileBytes, (int)_ptr + 0x08);

                long _ptrUpSkillName = Main.b_ReadInt(fileBytes, (int)_ptr + 0x10);
                entry.upSkillName = Main.b_ReadString(fileBytes, (int)_ptr + 0x10 + (int)_ptrUpSkillName);
                entry.upSkill_EnableInGround = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x18));
                entry.upSkill_EnableInAir = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x1C));
                entry.upSkill_unk4 = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x20));
                entry.upSkill_unk1 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x24);
                entry.upSkill_unk2 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x28);
                entry.upSkill_unk3 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x2C);

                long _ptrDownSkillName = Main.b_ReadInt(fileBytes, (int)_ptr + 0x38);
                entry.downSkillName = Main.b_ReadString(fileBytes, (int)_ptr + 0x38 + (int)_ptrDownSkillName);
                entry.downSkill_EnableInGround = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x40));
                entry.downSkill_EnableInAir = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x44));
                entry.downSkill_unk4 = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x48));
                entry.downSkill_unk1 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x4C);
                entry.downSkill_unk2 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x50);
                entry.downSkill_unk3 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x54);

                long _ptrLeftSkillName = Main.b_ReadInt(fileBytes, (int)_ptr + 0x60);
                entry.leftSkillName = Main.b_ReadString(fileBytes, (int)_ptr + 0x60 + (int)_ptrLeftSkillName);
                entry.leftSkill_EnableInGround = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x68));
                entry.leftSkill_EnableInAir = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x6C));
                entry.leftSkill_unk4 = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x70));
                entry.leftSkill_unk1 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x74);
                entry.leftSkill_unk2 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x78);
                entry.leftSkill_unk3 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x7C);

                long _ptrRightSkillName = Main.b_ReadInt(fileBytes, (int)_ptr + 0x88);
                entry.rightSkillName = Main.b_ReadString(fileBytes, (int)_ptr + 0x88 + (int)_ptrRightSkillName);
                entry.rightSkill_EnableInGround = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x90));
                entry.rightSkill_EnableInAir = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x94));
                entry.rightSkill_unk4 = Convert.ToBoolean(Main.b_ReadInt(fileBytes, (int)_ptr + 0x98));
                entry.rightSkill_unk1 = Main.b_ReadInt(fileBytes, (int)_ptr + 0x9C);
                entry.rightSkill_unk2 = Main.b_ReadInt(fileBytes, (int)_ptr + 0xA0);
                entry.rightSkill_unk3 = Main.b_ReadInt(fileBytes, (int)_ptr + 0xA4);



                spTypeSupportParam.Add(entry);


            }
            for (int x = 0; x < EntryCount; x++) {
                string NewItem = "Characode: " + BitConverter.GetBytes(spTypeSupportParam[x].characode)[0].ToString("X2") + " " + BitConverter.GetBytes(spTypeSupportParam[x].characode)[1].ToString("X2");
                listBox1.Items.Add(NewItem);
            }
        }
        public void ClearFile() {
            FileOpen = false;
            FilePath = "";
            fileBytes = new byte[0];
            EntryCount = 0;
            spTypeSupportParam.Clear();
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
                numericUpDown13.Value = spTypeSupportParam[x].characode;
                comboBox1.SelectedIndex = spTypeSupportParam[x].type;
                comboBox2.SelectedIndex = spTypeSupportParam[x].mode;

                textBox2.Text = spTypeSupportParam[x].leftSkillName;
                numericUpDown1.Value = spTypeSupportParam[x].leftSkill_unk1;
                numericUpDown2.Value = spTypeSupportParam[x].leftSkill_unk2;
                numericUpDown3.Value = spTypeSupportParam[x].leftSkill_unk3;
                checkBox2.Checked = spTypeSupportParam[x].leftSkill_EnableInGround;
                checkBox1.Checked = spTypeSupportParam[x].leftSkill_EnableInAir;
                checkBox12.Checked = spTypeSupportParam[x].leftSkill_unk4;

                textBox3.Text = spTypeSupportParam[x].rightSkillName;
                numericUpDown6.Value = spTypeSupportParam[x].rightSkill_unk1;
                numericUpDown5.Value = spTypeSupportParam[x].rightSkill_unk2;
                numericUpDown4.Value = spTypeSupportParam[x].rightSkill_unk3;
                checkBox3.Checked = spTypeSupportParam[x].rightSkill_EnableInGround;
                checkBox4.Checked = spTypeSupportParam[x].rightSkill_EnableInAir;
                checkBox11.Checked = spTypeSupportParam[x].rightSkill_unk4;

                textBox4.Text = spTypeSupportParam[x].upSkillName;
                numericUpDown9.Value = spTypeSupportParam[x].upSkill_unk1;
                numericUpDown8.Value = spTypeSupportParam[x].upSkill_unk2;
                numericUpDown7.Value = spTypeSupportParam[x].upSkill_unk3;
                checkBox5.Checked = spTypeSupportParam[x].upSkill_EnableInGround;
                checkBox6.Checked = spTypeSupportParam[x].upSkill_EnableInAir;
                checkBox10.Checked = spTypeSupportParam[x].upSkill_unk4;

                textBox5.Text = spTypeSupportParam[x].downSkillName;
                numericUpDown12.Value = spTypeSupportParam[x].downSkill_unk1;
                numericUpDown11.Value = spTypeSupportParam[x].downSkill_unk2;
                numericUpDown10.Value = spTypeSupportParam[x].downSkill_unk3;
                checkBox7.Checked = spTypeSupportParam[x].downSkill_EnableInGround;
                checkBox8.Checked = spTypeSupportParam[x].downSkill_EnableInAir;
                checkBox9.Checked = spTypeSupportParam[x].downSkill_unk4;
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            if (FileOpen) {
                if (numericUpDown14.Value != 0) {
                    for (int c = 0; c < spTypeSupportParam.Count; c++) {
                        if (spTypeSupportParam[c].characode == (int)numericUpDown14.Value) {
                            listBox1.SelectedIndex = c;
                            break;
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                spTypeSupportParam[x].characode = (int)numericUpDown13.Value;
                spTypeSupportParam[x].type = comboBox1.SelectedIndex;
                spTypeSupportParam[x].mode = comboBox2.SelectedIndex;

                spTypeSupportParam[x].leftSkillName = textBox2.Text;
                spTypeSupportParam[x].leftSkill_unk1 = (int)numericUpDown1.Value;
                spTypeSupportParam[x].leftSkill_unk2 = (int)numericUpDown2.Value;
                spTypeSupportParam[x].leftSkill_unk3 = (int)numericUpDown3.Value;
                spTypeSupportParam[x].leftSkill_EnableInGround = checkBox2.Checked;
                spTypeSupportParam[x].leftSkill_EnableInAir = checkBox1.Checked;
                spTypeSupportParam[x].leftSkill_unk4 = checkBox12.Checked;

                spTypeSupportParam[x].rightSkillName = textBox3.Text;
                spTypeSupportParam[x].rightSkill_unk1 = (int)numericUpDown6.Value;
                spTypeSupportParam[x].rightSkill_unk2 = (int)numericUpDown5.Value;
                spTypeSupportParam[x].rightSkill_unk3 = (int)numericUpDown4.Value;
                spTypeSupportParam[x].rightSkill_EnableInGround = checkBox3.Checked;
                spTypeSupportParam[x].rightSkill_EnableInAir = checkBox4.Checked;
                spTypeSupportParam[x].rightSkill_unk4 = checkBox11.Checked;

                spTypeSupportParam[x].upSkillName = textBox4.Text;
                spTypeSupportParam[x].upSkill_unk1 = (int)numericUpDown9.Value;
                spTypeSupportParam[x].upSkill_unk2 = (int)numericUpDown8.Value;
                spTypeSupportParam[x].upSkill_unk3 = (int)numericUpDown7.Value;
                spTypeSupportParam[x].upSkill_EnableInGround = checkBox5.Checked;
                spTypeSupportParam[x].upSkill_EnableInAir = checkBox6.Checked;
                spTypeSupportParam[x].upSkill_unk4 = checkBox10.Checked;

                spTypeSupportParam[x].downSkillName = textBox5.Text;
                spTypeSupportParam[x].downSkill_unk1 = (int)numericUpDown12.Value;
                spTypeSupportParam[x].downSkill_unk2 = (int)numericUpDown11.Value;
                spTypeSupportParam[x].downSkill_unk3 = (int)numericUpDown10.Value;
                spTypeSupportParam[x].downSkill_EnableInGround = checkBox7.Checked;
                spTypeSupportParam[x].downSkill_EnableInAir = checkBox8.Checked;
                spTypeSupportParam[x].downSkill_unk4 = checkBox9.Checked;

                listBox1.Items[x] = "Characode: " + BitConverter.GetBytes(spTypeSupportParam[x].characode)[0].ToString("X2") + " " + BitConverter.GetBytes(spTypeSupportParam[x].characode)[1].ToString("X2");
            } else {
                MessageBox.Show("Select section");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                spTypeSupportParamEntry entry = new spTypeSupportParamEntry();
                entry.characode = (int)numericUpDown13.Value;
                entry.type = comboBox1.SelectedIndex;
                entry.mode = comboBox2.SelectedIndex;

                entry.leftSkillName = textBox2.Text;
                entry.leftSkill_unk1 = (int)numericUpDown1.Value;
                entry.leftSkill_unk2 = (int)numericUpDown2.Value;
                entry.leftSkill_unk3 = (int)numericUpDown3.Value;
                entry.leftSkill_unk4 = checkBox12.Checked;
                entry.leftSkill_EnableInGround = checkBox2.Checked;
                entry.leftSkill_EnableInAir = checkBox1.Checked;

                entry.rightSkillName = textBox3.Text;
                entry.rightSkill_unk1 = (int)numericUpDown6.Value;
                entry.rightSkill_unk2 = (int)numericUpDown5.Value;
                entry.rightSkill_unk3 = (int)numericUpDown4.Value;
                entry.rightSkill_unk4 = checkBox11.Checked;
                entry.rightSkill_EnableInGround = checkBox3.Checked;
                entry.rightSkill_EnableInAir = checkBox4.Checked;

                entry.upSkillName = textBox4.Text;
                entry.upSkill_unk1 = (int)numericUpDown9.Value;
                entry.upSkill_unk2 = (int)numericUpDown8.Value;
                entry.upSkill_unk3 = (int)numericUpDown7.Value;
                entry.upSkill_unk4 = checkBox10.Checked;
                entry.upSkill_EnableInGround = checkBox5.Checked;
                entry.upSkill_EnableInAir = checkBox6.Checked;

                entry.downSkillName = textBox5.Text;
                entry.downSkill_unk1 = (int)numericUpDown12.Value;
                entry.downSkill_unk2 = (int)numericUpDown11.Value;
                entry.downSkill_unk3 = (int)numericUpDown10.Value;
                entry.downSkill_unk4 = checkBox9.Checked;
                entry.downSkill_EnableInGround = checkBox3.Checked;
                entry.downSkill_EnableInAir = checkBox4.Checked;

                spTypeSupportParam.Add(entry);
                listBox1.Items.Add("Characode: " + BitConverter.GetBytes(entry.characode)[0].ToString("X2") + " " + BitConverter.GetBytes(entry.characode)[1].ToString("X2"));
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                EntryCount++;
            } else {
                MessageBox.Show("Select section");
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                spTypeSupportParam.RemoveAt(x);
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
            file = Main.b_AddBytes(file, new byte[0xB0 * EntryCount]);

            List<int> UpSkillNamePointer = new List<int>();
            List<int> DownSkillNamePointer = new List<int>();
            List<int> LeftSkillNamePointer = new List<int>();
            List<int> RightSkillNamePointer = new List<int>();

            for (int x2 = 0; x2 < EntryCount; x2++) {
                UpSkillNamePointer.Add(file.Length);
                if (spTypeSupportParam[x2].upSkillName != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(spTypeSupportParam[x2].upSkillName));
                    file = Main.b_AddBytes(file, new byte[1]);
                }
                DownSkillNamePointer.Add(file.Length);
                if (spTypeSupportParam[x2].downSkillName != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(spTypeSupportParam[x2].downSkillName));
                    file = Main.b_AddBytes(file, new byte[1]);
                }
                LeftSkillNamePointer.Add(file.Length);
                if (spTypeSupportParam[x2].leftSkillName != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(spTypeSupportParam[x2].leftSkillName));
                    file = Main.b_AddBytes(file, new byte[1]);
                }
                RightSkillNamePointer.Add(file.Length);
                if (spTypeSupportParam[x2].rightSkillName != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(spTypeSupportParam[x2].rightSkillName));
                    file = Main.b_AddBytes(file, new byte[1]);
                }



                int newPointer3 = UpSkillNamePointer[x2] - 316 - 0xB0 * x2 - 0x10;
                byte[] ptrBytes3 = BitConverter.GetBytes(newPointer3);
                if (spTypeSupportParam[x2].upSkillName != "") {
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 316 + 0xB0 * x2 + 0x10);
                }
                newPointer3 = DownSkillNamePointer[x2] - 316 - 0xB0 * x2 - 0x38;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                if (spTypeSupportParam[x2].downSkillName != "") {
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 316 + 0xB0 * x2 + 0x38);
                }
                newPointer3 = LeftSkillNamePointer[x2] - 316 - 0xB0 * x2 - 0x60;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                if (spTypeSupportParam[x2].leftSkillName != "") {
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 316 + 0xB0 * x2 + 0x60);
                }
                newPointer3 = RightSkillNamePointer[x2] - 316 - 0xB0 * x2 - 0x88;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                if (spTypeSupportParam[x2].rightSkillName != "") {
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 316 + 0xB0 * x2 + 0x88);
                }
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].characode), 316 + 0xB0 * x2 + 0x00);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].mode), 316 + 0xB0 * x2 + 0x04);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].type), 316 + 0xB0 * x2 + 0x08);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].upSkill_EnableInGround), 316 + 0xB0 * x2 + 0x18);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].upSkill_EnableInAir), 316 + 0xB0 * x2 + 0x1C);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].upSkill_unk4), 316 + 0xB0 * x2 + 0x20);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].upSkill_unk1), 316 + 0xB0 * x2 + 0x24);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].upSkill_unk2), 316 + 0xB0 * x2 + 0x28);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].upSkill_unk3), 316 + 0xB0 * x2 + 0x2C);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].downSkill_EnableInGround), 316 + 0xB0 * x2 + 0x40);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].downSkill_EnableInAir), 316 + 0xB0 * x2 + 0x44);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].downSkill_unk4), 316 + 0xB0 * x2 + 0x48);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].downSkill_unk1), 316 + 0xB0 * x2 + 0x4C);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].downSkill_unk2), 316 + 0xB0 * x2 + 0x50);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].downSkill_unk3), 316 + 0xB0 * x2 + 0x54);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].leftSkill_EnableInGround), 316 + 0xB0 * x2 + 0x68);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].leftSkill_EnableInAir), 316 + 0xB0 * x2 + 0x6C);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].leftSkill_unk4), 316 + 0xB0 * x2 + 0x70);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].leftSkill_unk1), 316 + 0xB0 * x2 + 0x74);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].leftSkill_unk2), 316 + 0xB0 * x2 + 0x78);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].leftSkill_unk3), 316 + 0xB0 * x2 + 0x7C);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].rightSkill_EnableInGround), 316 + 0xB0 * x2 + 0x90);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].rightSkill_EnableInAir), 316 + 0xB0 * x2 + 0x94);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].rightSkill_unk4), 316 + 0xB0 * x2 + 0x98);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].rightSkill_unk1), 316 + 0xB0 * x2 + 0x9C);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].rightSkill_unk2), 316 + 0xB0 * x2 + 0xA0);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(spTypeSupportParam[x2].rightSkill_unk3), 316 + 0xB0 * x2 + 0xA4);

            }
            int FileSize = file.Length - 300;
            file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(FileSize), 296, 1);
            file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(FileSize + 4), 284, 1);
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
