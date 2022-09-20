using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace NSUNS4_Character_Manager.Tools
{
    public partial class Tool_AwakeAuraEditor : Form
    {
        private void Tool_AwakeAuraEditor_Load(object sender, EventArgs e)
        {
            if (File.Exists(Main.awakeAuraPath)) {
                OpenFile(Main.awakeAuraPath);
            }
        }
        public Tool_AwakeAuraEditor()
        {
            InitializeComponent();
        }

        public bool FileOpen = false;
        public string FilePath = "";
        public byte[] fileBytes = new byte[0];
        public int EntryCount = 0;

        public List<string> CharacodeList = new List<string>();
        public List<string> SkillFileList = new List<string>();
        public List<string> EffectList = new List<string>();
        public List<string> MainBoneList = new List<string>();
        public List<string> SecondBoneList = new List<string>();

        public List<int> AwakeModeValue_true_List = new List<int>();
        public List<int> AwakeModeValue_false_List = new List<int>();
        public List<int> ConstantValue_List = new List<int>();
        public List<int> SecondBoneValue_1_List = new List<int>();
        public List<int> SecondBoneValue_2_List = new List<int>();
        public List<int> SecondBoneValue_3_List = new List<int>();



        void OpenFile(string basepath = "") {
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
            ClearFile();
            FileOpen = true;
            FilePath = o.FileName;
            byte[] FileBytes = File.ReadAllBytes(FilePath);
            EntryCount = FileBytes[284] + FileBytes[285] * 256 + FileBytes[286] * 65536 + FileBytes[287] * 16777216;

			for (int x2 = 0; x2 < EntryCount; x2++)
			{
				long _ptr = 296 + 0x48 * x2;
				string Characode = "";
				long _ptrCharacter3 = FileBytes[_ptr] + FileBytes[_ptr + 1] * 0x100 + FileBytes[_ptr + 2] * 0x10000 + FileBytes[_ptr + 3] * 0x1000000;
				for (int a = 0; a < 12; a++)
				{
					if (FileBytes[_ptr + _ptrCharacter3 + a] != 0)
					{
						string str3 = Characode;
						char c = (char)FileBytes[_ptr + _ptrCharacter3 + a];
						Characode = str3 + c;
					}
					else
					{
						a = 12;
					}
				}
                string Skill = "";
                _ptrCharacter3 = FileBytes[_ptr + 16] + FileBytes[_ptr + 17] * 0x100 + FileBytes[_ptr + 18] * 0x10000 + FileBytes[_ptr + 19] * 0x1000000;
                for (int a = 0; a < 32; a++)
                {
                    if (FileBytes[_ptr + 16 + _ptrCharacter3 + a] != 0)
                    {
                        string str3 = Skill;
                        char c = (char)FileBytes[_ptr + 16 +_ptrCharacter3 + a];
                        Skill = str3 + c;
                    }
                    else
                    {
                        a = 32;
                    }
                }
                string Effect = "";
                _ptrCharacter3 = FileBytes[_ptr + 24] + FileBytes[_ptr + 25] * 0x100 + FileBytes[_ptr + 26] * 0x10000 + FileBytes[_ptr + 27] * 0x1000000;
                for (int a = 0; a < 32; a++)
                {
                    if (FileBytes[_ptr + 24 + _ptrCharacter3 + a] != 0)
                    {
                        string str3 = Effect;
                        char c = (char)FileBytes[_ptr + 24 + _ptrCharacter3 + a];
                        Effect = str3 + c;
                    }
                    else
                    {
                        a = 32;
                    }
                }
                string MainBone = "";
                _ptrCharacter3 = FileBytes[_ptr + 40] + FileBytes[_ptr + 41] * 0x100 + FileBytes[_ptr + 42] * 0x10000 + FileBytes[_ptr + 43] * 0x1000000;
                for (int a = 0; a < 32; a++)
                {
                    if (FileBytes[_ptr + 40 + _ptrCharacter3 + a] != 0)
                    {
                        string str3 = MainBone;
                        char c = (char)FileBytes[_ptr + 40 + _ptrCharacter3 + a];
                        MainBone = str3 + c;
                    }
                    else
                    {
                        a = 32;
                    }
                }
                string SecondBone = "";
                _ptrCharacter3 = FileBytes[_ptr + 56] + FileBytes[_ptr + 57] * 0x100 + FileBytes[_ptr + 58] * 0x10000 + FileBytes[_ptr + 59] * 0x1000000;
                for (int a = 0; a < 32; a++)
                {
                    if (FileBytes[_ptr + 56 + _ptrCharacter3 + a] != 0)
                    {
                        string str3 = SecondBone;
                        char c = (char)FileBytes[_ptr + 56 + _ptrCharacter3 + a];
                        SecondBone = str3 + c;
                    }
                    else
                    {
                        a = 32;
                    }
                }
                int AwakeModeValue_false = FileBytes[_ptr + 8] + FileBytes[_ptr + 9] * 0x100 + FileBytes[_ptr + 10] * 0x10000 + FileBytes[_ptr + 11] * 0x1000000;
                int AwakeModeValue_true = FileBytes[_ptr + 12] + FileBytes[_ptr + 13] * 0x100 + FileBytes[_ptr + 14] * 0x10000 + FileBytes[_ptr + 15] * 0x1000000;
                int ConstantValue = FileBytes[_ptr + 32] + FileBytes[_ptr + 33] * 0x100 + FileBytes[_ptr + 34] * 0x10000 + FileBytes[_ptr + 35] * 0x1000000;
                int SecondBoneValue_1 = FileBytes[_ptr + 48] + FileBytes[_ptr + 49] * 0x100 + FileBytes[_ptr + 50] * 0x10000 + FileBytes[_ptr + 51] * 0x1000000;
                int SecondBoneValue_2 = FileBytes[_ptr + 64] + FileBytes[_ptr + 65] * 0x100 + FileBytes[_ptr + 66] * 0x10000 + FileBytes[_ptr + 67] * 0x1000000;
                int SecondBoneValue_3 = FileBytes[_ptr + 68] + FileBytes[_ptr + 69] * 0x100 + FileBytes[_ptr + 70] * 0x10000 + FileBytes[_ptr + 71] * 0x1000000;
                CharacodeList.Add(Characode);
                SkillFileList.Add(Skill);
                EffectList.Add(Effect);
                MainBoneList.Add(MainBone);
                SecondBoneList.Add(SecondBone);

                AwakeModeValue_true_List.Add(AwakeModeValue_true);
                AwakeModeValue_false_List.Add(AwakeModeValue_false);
                ConstantValue_List.Add(ConstantValue);
                SecondBoneValue_1_List.Add(SecondBoneValue_1);
                SecondBoneValue_2_List.Add(SecondBoneValue_2);
                SecondBoneValue_3_List.Add(SecondBoneValue_3);
            }
			for (int x = 0; x < EntryCount; x++)
			{
				string NewItem = "Characode:" + CharacodeList[x];
				listBox1.Items.Add(NewItem);
			}
		}



        private void button1_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                AddID();
            }
            else
            {
                MessageBox.Show("No file loaded...");
            }
        }
        public void AddID()
        {
            // Generate new preset ID
            if (listBox1.SelectedIndex != -1)
            {
                string Characode = Characode_text.Text;
                string Skill = SkillFile_text.Text;
                string Effect = Effect_text.Text;
                string MainBone = MainBone_text.Text;
                string SecondBone = SecondBone_text.Text;
                int Constant = 1;
                int AwakeMode_true = AwakeModeValue_true_List[listBox1.SelectedIndex];
                int AwakeMode_false = AwakeModeValue_false_List[listBox1.SelectedIndex];
                int SecondValue_1 = SecondBoneValue_1_List[listBox1.SelectedIndex];
                int SecondValue_2 = SecondBoneValue_2_List[listBox1.SelectedIndex];
                int SecondValue_3 = SecondBoneValue_3_List[listBox1.SelectedIndex];

                CharacodeList.Add(Characode);
                SkillFileList.Add(Skill);
                EffectList.Add(Effect);
                MainBoneList.Add(MainBone);
                SecondBoneList.Add(SecondBone);

                ConstantValue_List.Add(Constant);
                AwakeModeValue_true_List.Add(AwakeMode_true);
                AwakeModeValue_false_List.Add(AwakeMode_false);
                SecondBoneValue_1_List.Add(SecondValue_1);
                SecondBoneValue_2_List.Add(SecondValue_2);
                SecondBoneValue_3_List.Add(SecondValue_3);

                int x = EntryCount;
                string NewItem = "Characode:" + CharacodeList[x];
                listBox1.Items.Add(NewItem);
                EntryCount++;
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                MessageBox.Show("New entry added.");
            }
            else
            {
                MessageBox.Show("Select entry");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                RemoveID(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("No file loaded...");
            }
        }
        public void RemoveID(int Index)
        {
            if (listBox1.Items.Count > Index)
            {
                if (listBox1.SelectedIndex > 0)
                {
                    listBox1.SelectedIndex--;
                }
                else
                {
                    listBox1.ClearSelected();
                }

                CharacodeList.RemoveAt(Index);
                SkillFileList.RemoveAt(Index);
                EffectList.RemoveAt(Index);
                MainBoneList.RemoveAt(Index);
                SecondBoneList.RemoveAt(Index);
                AwakeModeValue_false_List.RemoveAt(Index);
                AwakeModeValue_true_List.RemoveAt(Index);
                SecondBoneValue_1_List.RemoveAt(Index);
                SecondBoneValue_2_List.RemoveAt(Index);
                SecondBoneValue_3_List.RemoveAt(Index);
                ConstantValue_List.RemoveAt(Index);
                EntryCount--;
                listBox1.Items.RemoveAt(Index);
                MessageBox.Show("Entry deleted.");
            }
            else
            {
                MessageBox.Show("No item to delete...");
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        public void ClearFile()
        {
            CharacodeList = new List<string>();
            SkillFileList = new List<string>();
            EffectList = new List<string>();
            MainBoneList = new List<string>();
            SecondBoneList = new List<string>();
            AwakeModeValue_true_List = new List<int>();
            AwakeModeValue_false_List = new List<int>();
            ConstantValue_List = new List<int>();
            SecondBoneValue_1_List = new List<int>();
            SecondBoneValue_2_List = new List<int>();
            SecondBoneValue_3_List = new List<int>();
            EntryCount = 0;
            listBox1.Items.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count)
            {
                Characode_text.Text = CharacodeList[x];
                SkillFile_text.Text = SkillFileList[x];
                Effect_text.Text = EffectList[x];
                MainBone_text.Text = MainBoneList[x];
                SecondBone_text.Text = SecondBoneList[x];

                if (AwakeModeValue_false_List[x] == 1 && AwakeModeValue_true_List[x] == 0)
                {
                    comboBox1.SelectedIndex = 1;
                }
                else
                {
                    comboBox1.SelectedIndex = 0;
                }
                if (SecondBoneValue_1_List[x] == 1 && SecondBoneValue_2_List[x] == 2 && SecondBoneValue_3_List[x] == 1)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
        }

        private void SecondBone_mode_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                SaveID();
            }
            else
            {
                MessageBox.Show("No file loaded...");
            }
        }
        public void SaveID()
        {
            int x = listBox1.SelectedIndex;
            if (x > -1)
            {
                string Characode = Characode_text.Text;
                string Skill = SkillFile_text.Text;
                string Effect = Effect_text.Text;
                string MainBone = MainBone_text.Text;
                string SecondBone = SecondBone_text.Text;

                CharacodeList[x] = Characode;
                SkillFileList[x] = Skill;
                EffectList[x] = Effect;
                MainBoneList[x] = MainBone;
                SecondBoneList[x] = SecondBone;

                if (comboBox1.SelectedIndex == 0) {
                    AwakeModeValue_false_List[x] = 0;
                    AwakeModeValue_true_List[x] = 1;
                }
                else {
                    AwakeModeValue_false_List[x] = 1;
                    AwakeModeValue_true_List[x] = 0;
                }

                string NewItem = "Characode:" + CharacodeList[x];
                listBox1.Items[x] = NewItem;
                MessageBox.Show("Entry saved.");
            }
            else
            {
                MessageBox.Show("No entry selected.");
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

        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                DialogResult msg = MessageBox.Show("Are you sure you want to close this file?", "", MessageBoxButtons.OKCancel);
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
        public void CloseFile()
        {
            ClearFile();
            FileOpen = false;
            FilePath = "";
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

        public void SaveFileAs()
        {
            SaveFileDialog s = new SaveFileDialog();
            {
                s.DefaultExt = ".xfbin";
                s.Filter = "*.xfbin|*.xfbin";
            }
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
            MessageBox.Show("File saved to " + FilePath + ".");
        }

        public byte[] ConvertToFile()
        {
            List<byte> file = new List<byte>();
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
            for (int x4 = 0; x4 < header.Length; x4++)
            {
                file.Add(header[x4]);
            }
            for (int x3 = 0; x3 < EntryCount * 72; x3++)
            {
                file.Add(0);
            }
            List<int> CharacodePointer = new List<int>();
            List<int> SkillFilePointer = new List<int>();
            List<int> EffectPointer = new List<int>();
            List<int> Bone1Pointer = new List<int>();
            List<int> Bone2Pointer = new List<int>();

            for (int x2 = 0; x2 < EntryCount; x2++)
            {
                CharacodePointer.Add(file.Count);
                int nameLength3 = CharacodeList[x2].Length;
                if (CharacodeList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int a17 = 0; a17 < nameLength3; a17++)
                    {
                        file.Add((byte)CharacodeList[x2][a17]);
                    }
                    for (int a16 = nameLength3; a16 < 16; a16++)
                    {
                        file.Add(0);
                    }
                }
                SkillFilePointer.Add(file.Count);
                nameLength3 = SkillFileList[x2].Length;
                if (SkillFileList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int a15 = 0; a15 < nameLength3; a15++)
                    {
                        file.Add((byte)SkillFileList[x2][a15]);
                    }
                    for (int a14 = nameLength3; a14 < 32; a14++)
                    {
                        file.Add(0);
                    }
                }
                EffectPointer.Add(file.Count);
                nameLength3 = EffectList[x2].Length;
                if (EffectList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int b15 = 0; b15 < nameLength3; b15++)
                    {
                        file.Add((byte)EffectList[x2][b15]);
                    }
                    for (int b14 = nameLength3; b14 < 48; b14++)
                    {
                        file.Add(0);
                    }
                }
                Bone1Pointer.Add(file.Count);
                nameLength3 = MainBoneList[x2].Length;
                if (MainBoneList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int c15 = 0; c15 < nameLength3; c15++)
                    {
                        file.Add((byte)MainBoneList[x2][c15]);
                    }
                    for (int c14 = nameLength3; c14 < 48; c14++)
                    {
                        file.Add(0);
                    }
                }
                Bone2Pointer.Add(file.Count);
                nameLength3 = SecondBoneList[x2].Length;
                if (SecondBoneList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int d15 = 0; d15 < nameLength3; d15++)
                    {
                        file.Add((byte)SecondBoneList[x2][d15]);
                    }
                    for (int d14 = nameLength3; d14 < 16; d14++)
                    {
                        file.Add(0);
                    }
                }
                int newPointer3 = CharacodePointer[x2] - 296 - 72 * x2;
                byte[] ptrBytes3 = BitConverter.GetBytes(newPointer3);
                for (int a7 = 0; a7 < 4; a7++)
                {
                    file[296 + 72 * x2 + a7] = ptrBytes3[a7];
                }
                newPointer3 = SkillFilePointer[x2] - 296 - 72 * x2 - 16;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                for (int a7 = 0; a7 < 4; a7++)
                {
                    file[296 + 72 * x2 + 16 + a7] = ptrBytes3[a7];
                }
                newPointer3 = EffectPointer[x2] - 296 - 72 * x2 - 24;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                for (int a7 = 0; a7 < 4; a7++)
                {
                    file[296 + 72 * x2 + 24 + a7] = ptrBytes3[a7];
                }
                newPointer3 = Bone1Pointer[x2] - 296 - 72 * x2 - 40;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                for (int a7 = 0; a7 < 4; a7++)
                {
                    file[296 + 72 * x2 + 40 + a7] = ptrBytes3[a7];
                }
                
                if (SecondBoneValue_1_List[x2] == 1 || SecondBoneValue_2_List[x2] == 2 || SecondBoneValue_3_List[x2] == 1)
                {
                    newPointer3 = Bone2Pointer[x2] - 296 - 72 * x2 - 56;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[296 + 72 * x2 + 56 + a7] = ptrBytes3[a7];
                    }
                }
                else
                {
                    newPointer3 = Bone2Pointer[x2] - 296 - 72 * x2 - 56;
                    ptrBytes3 = BitConverter.GetBytes(0);
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[296 + 72 * x2 + 56 + a7] = ptrBytes3[a7];
                    }
                }
                
                // VALUES
                byte[] o_a = BitConverter.GetBytes(AwakeModeValue_false_List[x2]);
                for (int a8 = 0; a8 < 4; a8++)
                {
                    file[296 + 72 * x2 + 8 + a8] = o_a[a8];
                }
                byte[] o_b = BitConverter.GetBytes(AwakeModeValue_true_List[x2]);
                for (int a6 = 0; a6 < 4; a6++)
                {
                    file[296 + 72 * x2 + 12 + a6] = o_b[a6];
                }
                byte[] o_c = BitConverter.GetBytes(ConstantValue_List[x2]);
                for (int b8 = 0; b8 < 4; b8++)
                {
                    file[296 + 72 * x2 + 32 + b8] = o_c[b8];
                }
                byte[] o_c1 = BitConverter.GetBytes(SecondBoneValue_1_List[x2]);
                for (int c8 = 0; c8 < 4; c8++)
                {
                    file[296 + 72 * x2 + 48 + c8] = o_c1[c8];
                }
                byte[] o_c2 = BitConverter.GetBytes(SecondBoneValue_2_List[x2]);
                for (int d8 = 0; d8 < 4; d8++)
                {
                    file[296 + 72 * x2 + 64 + d8] = o_c2[d8];
                }
                byte[] o_c3 = BitConverter.GetBytes(SecondBoneValue_3_List[x2]);
                for (int e8 = 0; e8 < 4; e8++)
                {
                    file[296 + 72 * x2 + 68 + e8] = o_c3[e8];
                }
            }
            int FileSize3 = file.Count - 280;
            byte[] sizeBytes3 = BitConverter.GetBytes(FileSize3);
            int FileSize2 = file.Count - 268 + 4;
            byte[] sizeBytes2 = BitConverter.GetBytes(FileSize3 + 4);
            for (int a20 = 0; a20 < 4; a20++)
            {
                file[276 + a20] = sizeBytes3[3 - a20];
            }
            for (int a19 = 0; a19 < 4; a19++)
            {
                file[264 + a19] = sizeBytes2[3 - a19];
            }
            byte[] countBytes = BitConverter.GetBytes(EntryCount);
            for (int a18 = 0; a18 < 4; a18++)
            {
                file[284 + a18] = countBytes[a18];
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

        private void Search_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                if (Search_TB.Text != "")
                {
                    if (Main.SearchStringIndex(CharacodeList, Search_TB.Text, EntryCount, listBox1.SelectedIndex) != -1)
                    {
                        listBox1.SelectedIndex = Main.SearchStringIndex(CharacodeList, Search_TB.Text, EntryCount, listBox1.SelectedIndex);
                    }
                    else
                    {
                        if (Main.SearchStringIndex(CharacodeList, Search_TB.Text, EntryCount, 0) != -1)
                        {
                            listBox1.SelectedIndex = Main.SearchStringIndex(CharacodeList, Search_TB.Text, EntryCount, -1);
                        }
                        else
                        {
                            MessageBox.Show("Section with that name doesn't exist in file");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Write name of section in textbox");
                }
            }
            else
            {
                MessageBox.Show("Open file before trying to search section");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count) {
                if (checkBox1.Checked) {


                    SecondBoneValue_1_List[x] = 1;
                    SecondBoneValue_2_List[x] = 2;
                    SecondBoneValue_3_List[x] = 1;
                    SecondBone_text.Enabled = true;
                } else {
                    SecondBoneValue_1_List[x] = 0;
                    SecondBoneValue_2_List[x] = 0;
                    SecondBoneValue_3_List[x] = 0;
                    SecondBoneList[x] = "";
                    SecondBone_text.Text = "";
                    SecondBone_text.Enabled = false;
                }
            }
            
        }
    }
}
