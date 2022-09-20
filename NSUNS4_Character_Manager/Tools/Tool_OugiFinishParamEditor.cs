using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSUNS4_Character_Manager.Tools
{
    public partial class Tool_OugiFinishParamEditor : Form
    {
        public Tool_OugiFinishParamEditor()
        {
            InitializeComponent();
        }
        public bool FileOpen = false;

        public string FilePath = "";

        public byte[] fileBytes = new byte[0];

        public int EntryCount = 0;

        public List<byte[]> SectionList = new List<byte[]>();
        public List<byte[]> originalSectionList = new List<byte[]>();
        public List<byte[]> CharacodeList = new List<byte[]>();
        public List<string> CharacterNameList = new List<string>();
        public List<string> SectionNameList = new List<string>();
        public List<int> TypeList = new List<int>();
        public List<string> FileNameList = new List<string>();
        public List<string> FilePathList = new List<string>();
        public List<string> MessageIDList = new List<string>();
        public List<string> PreviewList = new List<string>();
        public List<string> Cost1List = new List<string>();
        public List<string> Cost2List = new List<string>();

        private void Tool_OugiFinishParamEditor_Load(object sender, EventArgs e)
        {
            if (File.Exists(Main.ougiFinishPath)) {
                OpenFile(Main.ougiFinishPath);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This file controls final cutIn scenes in collection, so you can choose them and play in-game, but this file don't add CutInScene for character, it just let you choose it");
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile(string basepath = "") {
            OpenFileDialog o = new OpenFileDialog();
            o.DefaultExt = "xfbin";
            if (basepath != "") {
                o.FileName = basepath;
            }
            else {
                o.ShowDialog();
            }
            
            if (!(o.FileName != "") || !File.Exists(o.FileName)) {
                return;
            }
            ClearFile();
            FileOpen = true;
            FilePath = o.FileName;
            byte[] FileBytes = File.ReadAllBytes(FilePath);
            EntryCount = FileBytes[296] + FileBytes[297] * 256 + FileBytes[298] * 65536 + FileBytes[299] * 16777216;
            for (int x2 = 0; x2 < EntryCount; x2++) {
                long _ptr = 308 + 144 * x2;
                byte[] Characode = new byte[4]
                {
                    FileBytes[_ptr + 76],
                    FileBytes[_ptr + 77],
                    0,
                    0
                };
                byte[] Section = new byte[4]
                {
                    FileBytes[_ptr + 60],
                    FileBytes[_ptr + 61],
                    0,
                    0
                };
                string CharacterName = "";
                long _ptrIcon3 = FileBytes[_ptr] + FileBytes[_ptr + 1] * 256 + FileBytes[_ptr + 2] * 65536 + FileBytes[_ptr + 3] * 16777216;
                for (int a2 = 0; a2 < 20; a2++) {
                    if (FileBytes[_ptr + _ptrIcon3 + a2] != 0) {
                        string str2 = CharacterName;
                        char c = (char)FileBytes[_ptr + _ptrIcon3 + a2];
                        CharacterName = str2 + c;
                    } else {
                        a2 = 20;
                    }
                }
                string SectionName = "";
                long _ptrAwaIcon3 = FileBytes[_ptr + 8] + FileBytes[_ptr + 9] * 256 + FileBytes[_ptr + 10] * 65536 + FileBytes[_ptr + 11] * 16777216;
                for (int a1 = 0; a1 < 30; a1++) {
                    if (FileBytes[_ptr + 8 + _ptrAwaIcon3 + a1] != 0) {
                        string str1 = SectionName;
                        char c = (char)FileBytes[_ptr + 8 + _ptrAwaIcon3 + a1];
                        SectionName = str1 + c;
                    } else {
                        a1 = 30;
                    }
                }
                string FileName = "";
                long _ptrFileName3 = FileBytes[_ptr + 24] + FileBytes[_ptr + 25] * 256 + FileBytes[_ptr + 26] * 65536 + FileBytes[_ptr + 27] * 16777216;
                for (int a1 = 0; a1 < 50; a1++) {
                    if (FileBytes[_ptr + 24 + _ptrFileName3 + a1] != 0) {
                        string str1 = FileName;
                        char c = (char)FileBytes[_ptr + 24 + _ptrFileName3 + a1];
                        FileName = str1 + c;
                    } else {
                        a1 = 50;
                    }
                }
                string FilePath = "";
                long _ptrFilePath3 = FileBytes[_ptr + 32] + FileBytes[_ptr + 33] * 256 + FileBytes[_ptr + 34] * 65536 + FileBytes[_ptr + 35] * 16777216;
                for (int a1 = 0; a1 < 70; a1++) {
                    if (FileBytes[_ptr + 32 + _ptrFilePath3 + a1] != 0) {
                        string str1 = FilePath;
                        char c = (char)FileBytes[_ptr + 32 + _ptrFilePath3 + a1];
                        FilePath = str1 + c;
                    } else {
                        a1 = 70;
                    }
                }
                string MessageID = "";
                long _ptrMessageID3 = FileBytes[_ptr + 40] + FileBytes[_ptr + 41] * 256 + FileBytes[_ptr + 42] * 65536 + FileBytes[_ptr + 43] * 16777216;
                for (int a1 = 0; a1 < 40; a1++) {
                    if (FileBytes[_ptr + 40 + _ptrMessageID3 + a1] != 0) {
                        string str1 = MessageID;
                        char c = (char)FileBytes[_ptr + 40 + _ptrMessageID3 + a1];
                        MessageID = str1 + c;
                    } else {
                        a1 = 40;
                    }
                }
                string Preview = "";
                long _ptrPreview3 = FileBytes[_ptr + 48] + FileBytes[_ptr + 49] * 256 + FileBytes[_ptr + 50] * 65536 + FileBytes[_ptr + 51] * 16777216;
                for (int a1 = 0; a1 < 48; a1++) {
                    if (FileBytes[_ptr + 48 + _ptrPreview3 + a1] != 0) {
                        string str1 = Preview;
                        char c = (char)FileBytes[_ptr + 48 + _ptrPreview3 + a1];
                        Preview = str1 + c;
                    } else {
                        a1 = 48;
                    }
                }
                string Cost1 = "";
                long _ptrCost1 = FileBytes[_ptr + 96] + FileBytes[_ptr + 97] * 256 + FileBytes[_ptr + 98] * 65536 + FileBytes[_ptr + 99] * 16777216;
                for (int a1 = 0; a1 < 60; a1++) {
                    if (FileBytes[_ptr + 96 + _ptrCost1 + a1] != 0) {
                        string str1 = Cost1;
                        char c = (char)FileBytes[_ptr + 96 + _ptrCost1 + a1];
                        Cost1 = str1 + c;
                    } else {
                        a1 = 60;
                    }
                }
                string Cost2 = "";
                long _ptrCost2 = FileBytes[_ptr + 112] + FileBytes[_ptr + 113] * 256 + FileBytes[_ptr + 114] * 65536 + FileBytes[_ptr + 115] * 16777216;
                for (int a1 = 0; a1 < 60; a1++) {
                    if (FileBytes[_ptr + 112 + _ptrCost2 + a1] != 0) {
                        string str1 = Cost2;
                        char c = (char)FileBytes[_ptr + 112 + _ptrCost2 + a1];
                        Cost2 = str1 + c;
                    } else {
                        a1 = 60;
                    }
                }
                byte[] originalSection = Main.b_ReadByteArray(FileBytes, (int)_ptr, 144);
                int Type = Main.b_ReadInt(FileBytes, (int)_ptr + 64);
                CharacodeList.Add(Characode);
                SectionList.Add(Section);
                CharacterNameList.Add(CharacterName);
                SectionNameList.Add(SectionName);
                FileNameList.Add(FileName);
                FilePathList.Add(FilePath);
                Cost1List.Add(Cost1);
                Cost2List.Add(Cost2);
                originalSectionList.Add(originalSection);
                TypeList.Add(Type);
                PreviewList.Add(Preview);

                MessageIDList.Add(MessageID);
            }
            for (int x = 0; x < EntryCount; x++) {
                string type_s = "";
                if (TypeList[x] == 1) {
                    type_s = "Main";
                } else {
                    type_s = "Secondary";
                }
                string NewItem = "Characode: " + CharacodeList[x][0].ToString("X2") + " " + CharacodeList[x][1].ToString("X2") + ", File name: " + FileNameList[x] + ", " + type_s;
                listBox1.Items.Add(NewItem);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count)
            {
                sect_v1.Value = SectionList[x][0];
                sect_v2.Value = SectionList[x][1];
                char_v1.Value = CharacodeList[x][0];
                char_v2.Value = CharacodeList[x][1];
                NameSec_tb.Text = SectionNameList[x];
                NameFile_tb.Text = FileNameList[x];
                PathFile_tb.Text = FilePathList[x];
                Preview_tb.Text = PreviewList[x];
                MessageId_tb.Text = MessageIDList[x];
                Cost1_tb.Text = Cost1List[x];
                Cost2_tb.Text = Cost2List[x];
                charName_tb.Text = CharacterNameList[x];
                if (TypeList[x]==1)
                {
                    type_cb.SelectedIndex = 0;
                }
                else
                {
                    type_cb.SelectedIndex = 1;
                }


            }
        }

        private void sect_v1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                if (Search_TB.Text != "")
                {
                    if (Main.SearchStringIndex(FileNameList, Search_TB.Text, EntryCount, listBox1.SelectedIndex) != -1)
                    {
                        listBox1.SelectedIndex = Main.SearchStringIndex(FileNameList, Search_TB.Text, EntryCount, listBox1.SelectedIndex);
                    }
                    else
                    {
                        if (Main.SearchStringIndex(FileNameList, Search_TB.Text, EntryCount, -1) != -1)
                        {
                            listBox1.SelectedIndex = Main.SearchStringIndex(FileNameList, Search_TB.Text, EntryCount, -1);
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

        private void button2_Click(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count)
            {
                SectionList[x][0] = (byte)sect_v1.Value;
                SectionList[x][1] = (byte)sect_v2.Value;
                CharacodeList[x][0] = (byte)char_v1.Value;
                CharacodeList[x][1] = (byte)char_v2.Value;
                SectionNameList[x] = NameSec_tb.Text;
                FileNameList[x] = NameFile_tb.Text;
                FilePathList[x] = PathFile_tb.Text;
                PreviewList[x] = Preview_tb.Text;
                MessageIDList[x] = MessageId_tb.Text;
                Cost1List[x] = Cost1_tb.Text;
                Cost2List[x] = Cost2_tb.Text;
                CharacterNameList[x] = charName_tb.Text;
                if (type_cb.SelectedIndex == 0)
                {
                    TypeList[x] = 1;
                }
                else
                {
                    TypeList[x] = 0;
                }
                string type_s = "";
                if (TypeList[x] == 1)
                {
                    type_s = "Main";
                }
                else
                {
                    type_s = "Secondary";
                }
                string NewItem = "Characode: " + CharacodeList[x][0].ToString("X2") + " " + CharacodeList[x][1].ToString("X2") + ", File name: " + FileNameList[x] + ", " + type_s;
                listBox1.Items[x] = NewItem;
                MessageBox.Show("Entry saved");
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
        public void ClearFile()
        {
            SectionList = new List<byte[]>();
            originalSectionList = new List<byte[]>();
            CharacodeList = new List<byte[]>();
            CharacterNameList = new List<string>();
            SectionNameList = new List<string>();
            TypeList = new List<int>();
            FileNameList = new List<string>();
            FilePathList = new List<string>();
            MessageIDList = new List<string>();
            PreviewList = new List<string>();
            Cost1List = new List<string>();
            Cost2List = new List<string>();

            EntryCount = 0;
            listBox1.Items.Clear();
        }
        public void AddID()
        {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count)
            {
                byte[] characode = new byte[4]
                {
                    (byte)char_v1.Value,
                    (byte)char_v2.Value,
                    0x00,
                    0x00
                };
                byte[] Section = new byte[4]
                {
                    (byte)sect_v1.Value,
                    (byte)sect_v2.Value,
                    0x00,
                    0x00
                };
                string CharacterName = charName_tb.Text;
                string SectionName = NameSec_tb.Text;
                string FileName = NameFile_tb.Text;
                string FilePath = PathFile_tb.Text;
                string Cost1 = Cost1_tb.Text;
                string Cost2 = Cost2_tb.Text;
                byte[] originalSection = originalSectionList[1];
                string Preview = Preview_tb.Text;
                string MessageID = MessageId_tb.Text;
                int Type = 0;
                if (type_cb.SelectedIndex == 0)
                    Type = 1;
                else
                    Type = 0;
                CharacodeList.Add(characode);
                SectionList.Add(Section);
                CharacterNameList.Add(CharacterName);
                SectionNameList.Add(SectionName);
                FileNameList.Add(FileName);
                FilePathList.Add(FilePath);
                Cost1List.Add(Cost1);
                Cost2List.Add(Cost2);
                originalSectionList.Add(originalSection);
                TypeList.Add(Type);
                PreviewList.Add(Preview);
                MessageIDList.Add(MessageID);

                int x2 = EntryCount;
                string type_s = "";
                if (TypeList[x] == 1)
                {
                    type_s = "Main";
                }
                else
                {
                    type_s = "Secondary";
                }
                string NewItem = "Characode: " + CharacodeList[x2][0].ToString("X2") + " " + CharacodeList[x2][1].ToString("X2") + ", File name: " + FileNameList[x2] + ", " + type_s;
                listBox1.Items.Add(NewItem);
                EntryCount++;
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                MessageBox.Show("Entry added");
            }
            else { MessageBox.Show("Select entry"); }
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
                SectionList.RemoveAt(Index);
                CharacterNameList.RemoveAt(Index);
                SectionNameList.RemoveAt(Index);
                FileNameList.RemoveAt(Index);
                FilePathList.RemoveAt(Index);
                Cost1List.RemoveAt(Index);
                Cost2List.RemoveAt(Index);
                originalSectionList.RemoveAt(Index);
                TypeList.RemoveAt(Index);
                PreviewList.RemoveAt(Index);
                MessageIDList.RemoveAt(Index);
                listBox1.Items.RemoveAt(Index);
                EntryCount--;
                MessageBox.Show("Entry deleted");
            }
            else
            {
                MessageBox.Show("No item to delete...");
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
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
            byte[] header = new byte[308]
            {
                0x4E,0x55,0x43,0x43,0x00,0x00,0x00,0x79,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xE0,0x00,0x00,0x00,0x03,0x00,0x79,0x00,0x00,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x3B,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x20,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x1D,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x4E,0x75,0x6C,0x6C,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x42,0x69,0x6E,0x61,0x72,0x79,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x50,0x61,0x67,0x65,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x49,0x6E,0x64,0x65,0x78,0x00,0x00,0x62,0x69,0x6E,0x5F,0x6C,0x65,0x2F,0x78,0x36,0x34,0x2F,0x4F,0x75,0x67,0x69,0x46,0x69,0x6E,0x69,0x73,0x68,0x50,0x61,0x72,0x61,0x6D,0x2E,0x62,0x69,0x6E,0x00,0x00,0x4F,0x75,0x67,0x69,0x46,0x69,0x6E,0x69,0x73,0x68,0x50,0x61,0x72,0x61,0x6D,0x00,0x50,0x61,0x67,0x65,0x30,0x00,0x69,0x6E,0x64,0x65,0x78,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x79,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x79,0x00,0x00,0x00,0x02,0x59,0x34,0x00,0x00,0x00,0x01,0x00,0x79,0x00,0x00,0x00,0x02,0x59,0x30,0xE8,0x03,0x00,0x00,0x28,0x02,0x00,0x00,0x08,0x00,0x00,0x00,0x00,0x00,0x00,0x00
            };
            for (int x4 = 0; x4 < header.Length; x4++)
            {
                file.Add(header[x4]);
            }
            for (int x3 = 0; x3 < EntryCount; x3++)
            {
                for (int x4=0;x4<0x90;x4++)
                {
                    file.Add(originalSectionList[x3][x4]);
                }    
            }
            /*
            public List<string> CharacterNameList = new List<string>();
            public List<string> SectionNameList = new List<string>();
            public List<int> TypeList = new List<int>();
            public List<string> FileNameList = new List<string>();
            public List<string> FilePathList = new List<string>();
            public List<string> MessageIDList = new List<string>();
            public List<string> PreviewList = new List<string>();
            public List<string> Cost1List = new List<string>();
            public List<string> Cost2List = new List<string>();*/

            List<int> CharacterNamePointer = new List<int>();
            List<int> SectionNamePointer = new List<int>();
            List<int> FileNamePointer = new List<int>();
            List<int> FilePathPointer = new List<int>();
            List<int> MessageIDPointer = new List<int>();
            List<int> PreviewPointer = new List<int>();
            List<int> Cost1Pointer = new List<int>();
            List<int> Cost2Pointer = new List<int>();

            for (int x2 = 0; x2 < EntryCount; x2++)
            {
                CharacterNamePointer.Add(file.Count);
                int nameLength3 = CharacterNameList[x2].Length;
                if (CharacterNameList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int a17 = 0; a17 < nameLength3; a17++)
                    {
                        file.Add((byte)CharacterNameList[x2][a17]);
                    }

                    for (int a16 = 0; a16 < 1; a16++)
                    {
                        file.Add(0);
                    }
                }
                int newPointer3 = CharacterNamePointer[x2] - 308 - 0x90 * x2 - 0;
                byte[] ptrBytes3 = BitConverter.GetBytes(newPointer3);
                if (CharacterNameList[x2] == "")
                {

                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 0 + a7] = 0;
                    }
                }
                else
                {
                    newPointer3 = CharacterNamePointer[x2] - 308 - 0x90 * x2 - 0;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 0 + a7] = ptrBytes3[a7];
                    }
                }

                SectionNamePointer.Add(file.Count);
                nameLength3 = SectionNameList[x2].Length;
                if (SectionNameList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int a17 = 0; a17 < nameLength3; a17++)
                    {
                        file.Add((byte)SectionNameList[x2][a17]);
                    }
                    for (int a16 = 0; a16 < 1; a16++)
                    {
                        file.Add(0);
                    }
                }
                if (SectionNameList[x2] == "")
                {

                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 8 + a7] = 0;
                    }
                }
                else
                {
                    newPointer3 = SectionNamePointer[x2] - 308 - 0x90 * x2 - 8;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 8 + a7] = ptrBytes3[a7];
                    }
                }

                FileNamePointer.Add(file.Count);
                nameLength3 = FileNameList[x2].Length;
                if (FilePathList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int a17 = 0; a17 < nameLength3; a17++)
                    {
                        file.Add((byte)FileNameList[x2][a17]);
                    }
                    for (int a16 = 0; a16 < 1; a16++)
                    {
                        file.Add(0);
                    }
                }
                if (FileNameList[x2] == "")
                {
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 24 + a7] = 0;
                    }
                }
                else
                {
                    newPointer3 = FileNamePointer[x2] - 308 - 0x90 * x2 - 24;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 24 + a7] = ptrBytes3[a7];
                    }
                }

                FilePathPointer.Add(file.Count);
                nameLength3 = FilePathList[x2].Length;
                if (FilePathList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int a17 = 0; a17 < nameLength3; a17++)
                    {
                        file.Add((byte)FilePathList[x2][a17]);
                    }
                    for (int a16 = 0; a16 < 1; a16++)
                    {
                        file.Add(0);
                    }
                }
                if (FilePathList[x2] == "")
                {
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 32 + a7] = 0;
                    }
                }
                else
                {
                    newPointer3 = FilePathPointer[x2] - 308 - 0x90 * x2 - 32;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 32 + a7] = ptrBytes3[a7];
                    }
                }

                MessageIDPointer.Add(file.Count);
                nameLength3 = MessageIDList[x2].Length;
                if (MessageIDList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int a17 = 0; a17 < nameLength3; a17++)
                    {
                        file.Add((byte)MessageIDList[x2][a17]);
                    }
                    for (int a16 = 0; a16 < 1; a16++)
                    {
                        file.Add(0);
                    }
                }
                if (MessageIDList[x2] == "")
                {
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 40 + a7] = 0;
                    }
                }
                else
                {
                    newPointer3 = MessageIDPointer[x2] - 308 - 0x90 * x2 - 40;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 40 + a7] = ptrBytes3[a7];
                    }
                }

                PreviewPointer.Add(file.Count);
                nameLength3 = PreviewList[x2].Length;
                if (PreviewList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int a17 = 0; a17 < nameLength3; a17++)
                    {
                        file.Add((byte)PreviewList[x2][a17]);
                    }
                    for (int a16 = 0; a16 < 1; a16++)
                    {
                        file.Add(0);
                    }
                }
                if (PreviewList[x2] == "")
                {
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 48 + a7] = 0;
                    }
                }
                else
                {
                    newPointer3 = PreviewPointer[x2] - 308 - 0x90 * x2 - 48;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 48 + a7] = ptrBytes3[a7];
                    }
                }

                Cost1Pointer.Add(file.Count);
                nameLength3 = Cost1List[x2].Length;
                if (PreviewList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int a17 = 0; a17 < nameLength3; a17++)
                    {
                        file.Add((byte)Cost1List[x2][a17]);
                    }
                    for (int a16 = 0; a16 < 1; a16++)
                    {
                        file.Add(0);
                    }
                }
                if (Cost1List[x2] == "")
                {
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 96 + a7] = 0;
                    }
                }
                else
                {
                    newPointer3 = Cost1Pointer[x2] - 308 - 0x90 * x2 - 96;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 96 + a7] = ptrBytes3[a7];
                    }
                }

                Cost2Pointer.Add(file.Count);
                nameLength3 = Cost2List[x2].Length;
                if (PreviewList[x2] == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int a17 = 0; a17 < nameLength3; a17++)
                    {
                        file.Add((byte)Cost2List[x2][a17]);
                    }
                    for (int a16 = 0; a16 < 1; a16++)
                    {
                        file.Add(0);
                    }
                }
                if (Cost2List[x2] == "")
                {
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 112 + a7] = 0;
                    }
                }
                else
                {
                    newPointer3 = Cost2Pointer[x2] - 308 - 0x90 * x2 - 112;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[308 + 0x90 * x2 + 112 + a7] = ptrBytes3[a7];
                    }
                }

                // VALUES
                byte[] o_a = new byte[4]
                {
                    Convert.ToByte(TypeList[x2]),
                    0x00,
                    0x00,
                    0x00
                };
                byte[] o_b = new byte[8]
                {
                    0x04,
                    0x00,
                    0x00,
                    0x00,
                    0x01,
                    0x00,
                    0x00,
                    0x00
                };
                byte[] o_c = new byte[4]
                {
                    0xDC,
                    0x05,
                    0x00,
                    0x00
                };
                byte[] o_d = new byte[4]
                {
                    0x01,
                    0x00,
                    0x00,
                    0x00
                };
                byte[] o_e = new byte[4]
                {
                    0x05,
                    0x00,
                    0x00,
                    0x00
                };
                byte[] o_f = new byte[4]
                {
                    0x0A,
                    0x00,
                    0x00,
                    0x00
                };
                byte[] o_h = new byte[4]
                {
                    0x00,
                    0x00,
                    0x00,
                    0x00
                };
                if (TypeList[x2]==0)
                {
                    for (int a8 = 0; a8 < 8; a8++)
                    {
                        file[308 + 0x90 * x2 + 68 + a8] = o_b[a8];
                    }
                    for (int a8 = 0; a8 < 4; a8++)
                    {
                        file[308 + 0x90 * x2 + 56 + a8] = o_c[a8];
                    }
                }
                else
                {
                    for (int a8 = 0; a8 < 4; a8++)
                    {
                        file[308 + 0x90 * x2 + 68 + a8] = o_h[a8];
                        file[308 + 0x90 * x2 + 72 + a8] = o_h[a8];
                        file[308 + 0x90 * x2 + 64 + a8] = o_d[a8];
                    }
                }
                for (int a8 = 0; a8 < 4; a8++)
                {
                    file[308 + 0x90 * x2 + 0x4C + a8] = CharacodeList[x2][a8];
                    file[308 + 0x90 * x2 + 0x3C + a8] = SectionList[x2][a8];
                }
                if (Cost1List[x2] != "" || Cost2List[x2] != "")
                {
                    for (int a8 = 0; a8 < 4; a8++)
                    {
                        file[308 + 0x90 * x2 + 88 + a8] = o_d[a8];
                    }
                    for (int a8 = 0; a8 < 4; a8++)
                    {
                        file[308 + 0x90 * x2 + 104 + a8] = o_e[a8];
                    }
                    for (int a8 = 0; a8 < 4; a8++)
                    {
                        file[308 + 0x90 * x2 + 120 + a8] = o_f[a8];
                    }
                }
                else
                {
                    for (int a8 = 0; a8 < 4; a8++)
                    {
                        file[308 + 0x90 * x2 + 88 + a8] = o_h[a8];
                        file[308 + 0x90 * x2 + 104 + a8] = o_h[a8];
                        file[308 + 0x90 * x2 + 120 + a8] = o_h[a8];
                    }
                }
            }
            int FileSize3 = file.Count - 292;
            byte[] sizeBytes3 = BitConverter.GetBytes(FileSize3);
            byte[] sizeBytes2 = BitConverter.GetBytes(FileSize3 + 4);
            for (int a20 = 0; a20 < 4; a20++)
            {
                file[288 + a20] = sizeBytes3[3 - a20];
            }
            for (int a19 = 0; a19 < 4; a19++)
            {
                file[276 + a19] = sizeBytes2[3 - a19];
            }
            byte[] countBytes = BitConverter.GetBytes(EntryCount);
            for (int a18 = 0; a18 < 4; a18++)
            {
                file[296 + a18] = countBytes[a18];
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
    }
}
