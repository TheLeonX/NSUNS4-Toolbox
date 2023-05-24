using Microsoft.WindowsAPICodePack.Shell;
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
    public partial class Tool_AwakeAuraEditor_v2 : Form {
        public Tool_AwakeAuraEditor_v2() {
            InitializeComponent();
        }
        public bool FileOpen = false;
        public string FilePath = "";
        public byte[] fileBytes = new byte[0];
        public int EntryCount = 0;
        public List<AwakeAuraParam> AwakeAura = new List<AwakeAuraParam>();

        public class AwakeAuraParam {
            public string Characode;
            public bool State;
            public string SkillFile;
            public string Effect;
            public bool PlayerModelFirstBone;
            public string FirstBone;
            public bool PlayerModelSecondBone;
            public string SecondBone;
            public int Condition;
            public bool UnknownSetting;
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
            fileBytes = File.ReadAllBytes(o.FileName);

            EntryCount = Main.b_ReadInt(fileBytes, 0x11C);
            for (int x = 0; x< EntryCount; x++) {
                int _ptr = 296 + 0x48 * x;
                AwakeAuraParam AwakeAuraEntry = new AwakeAuraParam();
                AwakeAuraEntry.Characode = Main.b_ReadString(fileBytes, _ptr + Main.b_ReadInt(fileBytes, _ptr));
                AwakeAuraEntry.State = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0x0C));
                AwakeAuraEntry.SkillFile = Main.b_ReadString(fileBytes, _ptr + 0x10 + Main.b_ReadInt(fileBytes, _ptr + 0x10));
                AwakeAuraEntry.Effect = Main.b_ReadString(fileBytes, _ptr + 0x18 + Main.b_ReadInt(fileBytes, _ptr + 0x18));
                AwakeAuraEntry.PlayerModelFirstBone = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0x20));
                AwakeAuraEntry.FirstBone = Main.b_ReadString(fileBytes, _ptr + 0x28 + Main.b_ReadInt(fileBytes, _ptr + 0x28));
                AwakeAuraEntry.PlayerModelSecondBone = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0x30));
                AwakeAuraEntry.SecondBone = Main.b_ReadString(fileBytes, _ptr + 0x38 + Main.b_ReadInt(fileBytes, _ptr + 0x38));
                AwakeAuraEntry.Condition = Main.b_ReadInt(fileBytes, _ptr + 0x40);
                AwakeAuraEntry.UnknownSetting = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0x44));

                AwakeAura.Add(AwakeAuraEntry);
                string state = "";
                if (Main.b_ReadInt(fileBytes, _ptr + 0x0C) == 1)
                    state = "Awake";
                else
                    state = "Normal";
                listBox1.Items.Add(Main.b_ReadString(fileBytes, _ptr + Main.b_ReadInt(fileBytes, _ptr)) +", State: " + state + ", First Bone: "+ Main.b_ReadString(fileBytes, _ptr + 0x28 + Main.b_ReadInt(fileBytes, _ptr + 0x28)));
            }
        }
        public void ClearFile() {
            AwakeAura = new List<AwakeAuraParam>();
            EntryCount = 0;
            FileOpen = false;
            FilePath = "";
            fileBytes = new byte[0];
            listBox1.Items.Clear();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFile();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count) {
                Characode_text.Text = AwakeAura[x].Characode;
                SkillFile_text.Text = AwakeAura[x].SkillFile;
                Effect_text.Text = AwakeAura[x].Effect;
                FirstBone_text.Text = AwakeAura[x].FirstBone;
                SecondBone_text.Text = AwakeAura[x].SecondBone;
                comboBox1.SelectedIndex = Convert.ToInt32(AwakeAura[x].State);
                comboBox2.SelectedIndex = AwakeAura[x].Condition;
                checkBox1.Checked = AwakeAura[x].PlayerModelFirstBone;
                checkBox2.Checked = AwakeAura[x].PlayerModelSecondBone;
                checkBox3.Checked = AwakeAura[x].UnknownSetting;
            }
        }

        public void AddEntry() {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                AwakeAuraParam AwakeAuraEntry = new AwakeAuraParam();
                AwakeAuraEntry.Characode = AwakeAura[x].Characode;
                AwakeAuraEntry.State = AwakeAura[x].State;
                AwakeAuraEntry.SkillFile = AwakeAura[x].SkillFile;
                AwakeAuraEntry.Effect = AwakeAura[x].Effect;
                AwakeAuraEntry.PlayerModelFirstBone = AwakeAura[x].PlayerModelFirstBone;
                AwakeAuraEntry.FirstBone = AwakeAura[x].FirstBone;
                AwakeAuraEntry.PlayerModelSecondBone = AwakeAura[x].PlayerModelSecondBone;
                AwakeAuraEntry.SecondBone = AwakeAura[x].SecondBone;
                AwakeAuraEntry.Condition = AwakeAura[x].Condition;
                AwakeAuraEntry.UnknownSetting = AwakeAura[x].UnknownSetting;

                AwakeAura.Add(AwakeAuraEntry);
                EntryCount++;
            } else {
                AwakeAuraParam AwakeAuraEntry = new AwakeAuraParam();
                AwakeAuraEntry.Characode = "";
                AwakeAuraEntry.State = true;
                AwakeAuraEntry.SkillFile = "";
                AwakeAuraEntry.Effect = "";
                AwakeAuraEntry.PlayerModelFirstBone = false;
                AwakeAuraEntry.FirstBone = "";
                AwakeAuraEntry.PlayerModelSecondBone = false;
                AwakeAuraEntry.SecondBone = "";
                AwakeAuraEntry.Condition = 0;
                AwakeAuraEntry.UnknownSetting = false;

                AwakeAura.Add(AwakeAuraEntry);
                EntryCount++;
            }
            
        }
        public void DeleteEntry() {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                AwakeAura.RemoveAt(x);
                EntryCount--;
            } else
                MessageBox.Show("Select entry which you want to delete.");

        }
        private void button1_Click(object sender, EventArgs e) {
            if (FileOpen)
                AddEntry();
            else
                MessageBox.Show("Open file first!");
        }

        private void button3_Click(object sender, EventArgs e) {
            if (FileOpen)
                DeleteEntry();
            else
                MessageBox.Show("Open file first!");
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
            byte[] header = new byte[296]
            {
                0x4E,
                0x55,
                0x43,
                0x43,
                0x00,
                0x00,
                0x00,
                0x79,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0xD4,
                0x00,
                0x00,
                0x00,
                0x03,
                0x00,
                0x79,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x04,
                0x00,
                0x00,
                0x00,
                0x3B,
                0x00,
                0x00,
                0x00,
                0x02,
                0x00,
                0x00,
                0x00,
                0x1A,
                0x00,
                0x00,
                0x00,
                0x04,
                0x00,
                0x00,
                0x00,
                0x17,
                0x00,
                0x00,
                0x00,
                0x04,
                0x00,
                0x00,
                0x00,
                0x30,
                0x00,
                0x00,
                0x00,
                0x04,
                0x00,
                0x00,
                0x00,
                0x00,
                0x6E,
                0x75,
                0x63,
                0x63,
                0x43,
                0x68,
                0x75,
                0x6E,
                0x6B,
                0x4E,
                0x75,
                0x6C,
                0x6C,
                0x00,
                0x6E,
                0x75,
                0x63,
                0x63,
                0x43,
                0x68,
                0x75,
                0x6E,
                0x6B,
                0x42,
                0x69,
                0x6E,
                0x61,
                0x72,
                0x79,
                0x00,
                0x6E,
                0x75,
                0x63,
                0x63,
                0x43,
                0x68,
                0x75,
                0x6E,
                0x6B,
                0x50,
                0x61,
                0x67,
                0x65,
                0x00,
                0x6E,
                0x75,
                0x63,
                0x63,
                0x43,
                0x68,
                0x75,
                0x6E,
                0x6B,
                0x49,
                0x6E,
                0x64,
                0x65,
                0x78,
                0x00,
                0x00,
                0x62,
                0x69,
                0x6E,
                0x5F,
                0x6C,
                0x65,
                0x2F,
                0x78,
                0x36,
                0x34,
                0x2F,
                0x61,
                0x77,
                0x61,
                0x6B,
                0x65,
                0x41,
                0x75,
                0x72,
                0x61,
                0x2E,
                0x62,
                0x69,
                0x6E,
                0x00,
                0x00,
                0x61,
                0x77,
                0x61,
                0x6B,
                0x65,
                0x41,
                0x75,
                0x72,
                0x61,
                0x00,
                0x50,
                0x61,
                0x67,
                0x65,
                0x30,
                0x00,
                0x69,
                0x6E,
                0x64,
                0x65,
                0x78,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x01,
                0x00,
                0x00,
                0x00,
                0x01,
                0x00,
                0x00,
                0x00,
                0x01,
                0x00,
                0x00,
                0x00,
                0x02,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x02,
                0x00,
                0x00,
                0x00,
                0x03,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x03,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x01,
                0x00,
                0x00,
                0x00,
                0x02,
                0x00,
                0x00,
                0x00,
                0x03,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x79,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x79,
                0x00,
                0x00,
                0x00,
                0x00,
                0xAC,
                0xD4,
                0x00,
                0x00,
                0x00,
                0x01,
                0x00,
                0x79,
                0x00,
                0x00,
                0x00,
                0x00,
                0xAC,
                0xD0,
                0xE9,
                0x03,
                0x00,
                0x00,
                0x4E,
                0x01,
                0x00,
                0x00,
                0x08,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            file = Main.b_AddBytes(file, header);
            file = Main.b_AddBytes(file, new byte[EntryCount * 72]);

            List<int> CharacodePointer = new List<int>();
            List<int> SkillFilePointer = new List<int>();
            List<int> EffectPointer = new List<int>();
            List<int> Bone1Pointer = new List<int>();
            List<int> Bone2Pointer = new List<int>();

            for (int x2 = 0; x2 < EntryCount; x2++) {
                CharacodePointer.Add(file.Length);
                if (AwakeAura[x2].Characode != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(AwakeAura[x2].Characode));
                    file = Main.b_AddBytes(file, new byte[1]);

                    int newPointer3 = CharacodePointer[x2] - 296 - 72 * x2;
                    byte[] ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 296 + 72 * x2);
                }
                SkillFilePointer.Add(file.Length);
                if (AwakeAura[x2].SkillFile != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(AwakeAura[x2].SkillFile));
                    file = Main.b_AddBytes(file, new byte[1]);

                    int newPointer3 = SkillFilePointer[x2] - 296 - 72 * x2 - 16;
                    byte[] ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 296 + 72 * x2 + 16);

                }
                EffectPointer.Add(file.Length);
                if (AwakeAura[x2].Effect != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(AwakeAura[x2].Effect));
                    file = Main.b_AddBytes(file, new byte[1]);

                    int newPointer3 = EffectPointer[x2] - 296 - 72 * x2 - 24;
                    byte[] ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 296 + 72 * x2 + 24);
                }
                Bone1Pointer.Add(file.Length);
                if (AwakeAura[x2].FirstBone != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(AwakeAura[x2].FirstBone));
                    file = Main.b_AddBytes(file, new byte[1]);

                    int newPointer3 = Bone1Pointer[x2] - 296 - 72 * x2 - 40;
                    byte[] ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 296 + 72 * x2 + 40);
                }
                Bone2Pointer.Add(file.Length);
                if (AwakeAura[x2].SecondBone != "") {
                    file = Main.b_AddBytes(file, Encoding.ASCII.GetBytes(AwakeAura[x2].SecondBone));
                    file = Main.b_AddBytes(file, new byte[1]);

                    int newPointer3 = Bone2Pointer[x2] - 296 - 72 * x2 - 56;
                    byte[] ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    file = Main.b_ReplaceBytes(file, ptrBytes3, 296 + 72 * x2 + 56);
                }


                // VALUES
                if (AwakeAura[x2].State) {
                    file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(AwakeAura[x2].State), 296 + 72 * x2 + 12);
                } else
                    file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(1), 296 + 72 * x2 + 8);


                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(AwakeAura[x2].PlayerModelFirstBone), 296 + 72 * x2 + 0x20);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(AwakeAura[x2].PlayerModelSecondBone), 296 + 72 * x2 + 0x30);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(AwakeAura[x2].Condition), 296 + 72 * x2 + 0x40);
                file = Main.b_ReplaceBytes(file, BitConverter.GetBytes(AwakeAura[x2].UnknownSetting), 296 + 72 * x2 + 0x44);


            }
            int FileSize = file.Length - 280;
            byte[] sizeBytes1 = BitConverter.GetBytes(FileSize);
            byte[] sizeBytes2 = BitConverter.GetBytes(FileSize + 4);
            byte[] countBytes = BitConverter.GetBytes(EntryCount);


            file = Main.b_ReplaceBytes(file, sizeBytes1, 276,1);
            file = Main.b_ReplaceBytes(file, sizeBytes2, 264, 1);
            file = Main.b_ReplaceBytes(file, countBytes, 284);

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


            file = Main.b_AddBytes(file, finalBytes);

            return file;
        }

        private void button2_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                if (comboBox2.SelectedIndex != 2) {
                    AwakeAura[x].Characode = Characode_text.Text;
                    AwakeAura[x].State = Convert.ToBoolean(comboBox1.SelectedIndex);
                    AwakeAura[x].SkillFile = SkillFile_text.Text;
                    AwakeAura[x].Effect = Effect_text.Text;
                    AwakeAura[x].PlayerModelFirstBone = checkBox1.Checked;
                    AwakeAura[x].FirstBone = FirstBone_text.Text;
                    AwakeAura[x].PlayerModelSecondBone = checkBox2.Checked;
                    AwakeAura[x].SecondBone = SecondBone_text.Text;
                    AwakeAura[x].Condition = comboBox2.SelectedIndex;
                    AwakeAura[x].UnknownSetting = checkBox3.Checked;
                } else {
                    if (SecondBone_text.Text != "") {
                        AwakeAura[x].Characode = Characode_text.Text;
                        AwakeAura[x].State = Convert.ToBoolean(comboBox1.SelectedIndex);
                        AwakeAura[x].SkillFile = SkillFile_text.Text;
                        AwakeAura[x].Effect = Effect_text.Text;
                        AwakeAura[x].PlayerModelFirstBone = checkBox1.Checked;
                        AwakeAura[x].FirstBone = FirstBone_text.Text;
                        AwakeAura[x].PlayerModelSecondBone = checkBox2.Checked;
                        AwakeAura[x].SecondBone = SecondBone_text.Text;
                        AwakeAura[x].Condition = comboBox2.SelectedIndex;
                        AwakeAura[x].UnknownSetting = checkBox3.Checked;
                    } else {
                        MessageBox.Show("You have to write second bone for that aura, otherwise game will crash!");
                    }
                }
                
            } else
                MessageBox.Show("Select aura entry.");
        }

        private void Search_Click(object sender, EventArgs e) {
            if (Search_TB.Text != "") {
                bool looped = false;
                int x = listBox1.SelectedIndex+1;
                if (listBox1.SelectedIndex == listBox1.Items.Count || listBox1.SelectedIndex == -1)
                    x = 0;
                for (int c = x; c < listBox1.Items.Count; c++) {
                    if (listBox1.Items[c].ToString().Contains(Search_TB.Text)) {
                        listBox1.SelectedIndex = c;
                        return;
                    }
                    if (c == listBox1.Items.Count-1 && looped == false) {
                        looped = true;
                        c = -1;
                    }
                        
                }
                MessageBox.Show("Couldn't find entry with that text");
            }
        }

        private void Tool_AwakeAuraEditor_v2_Load(object sender, EventArgs e) {
            if (File.Exists(Main.awakeAuraPath)) {
                OpenFile(Main.awakeAuraPath);
            }
        }

        private void Search_TB_TextChanged(object sender, EventArgs e) {

        }
    }
}
