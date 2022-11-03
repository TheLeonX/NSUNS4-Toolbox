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

namespace NSUNS4_Character_Manager.Tools
{
    public partial class Tool_MessageInfoEditor : Form
    {
        public Tool_MessageInfoEditor()
        {
            InitializeComponent();
            // ACBList
            for (int x = 0; x < Program.ACBList.Length; x++) comboBox1.Items.Add(Program.ACBList[x]);
        }
        //Добавить кнопки Add, Remove,Change 
        public List<string> FilePaths = new List<string>();
        public List<byte[]> FileBytesList = new List<byte[]>();
        public List<int> EntryCounts = new List<int>();
        public List<List<byte[]>> CRC32CodesList = new List<List<byte[]>>();
        public List<List<byte[]>> MainTextsList = new List<List<byte[]>>();
        public List<List<byte[]>> ExtraTextsList = new List<List<byte[]>>();
        public List<List<int>> ACBFilesList = new List<List<int>>();
        public List<List<int>> CueIDsList = new List<List<int>>();
        public List<List<int>> VoiceOnlysList = new List<List<int>>();
        public List<bool> OpenedFile = new List<bool>();
        //public int ListIndex = 0;
        private void openFilesselectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog c = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
            c.IsFolderPicker = true;

            if (c.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok) {
                if (Directory.Exists(c.FileName)) {
                    OpenFilesStart(c.FileName);
                }
            }
            
        }

        public void OpenFilesStart(string basepath = "") {
            ClearFiles();
            ARAE_Main_textbox.Enabled = false;
            ARAE_Extra_textbox.Enabled = false;
            CHI_Main_textbox.Enabled = false;
            CHI_Extra_textbox.Enabled = false;
            ENG_Main_textbox.Enabled = false;
            ENG_Extra_textbox.Enabled = false;
            ESMX_Main_textbox.Enabled = false;
            ESMX_Extra_textbox.Enabled = false;
            FRE_Main_textbox.Enabled = false;
            FRE_Extra_textbox.Enabled = false;
            GER_Main_textbox.Enabled = false;
            GER_Extra_textbox.Enabled = false;
            ITA_Main_textbox.Enabled = false;
            ITA_Extra_textbox.Enabled = false;
            KOKR_Main_textbox.Enabled = false;
            KOKR_Extra_textbox.Enabled = false;
            POL_Main_textbox.Enabled = false;
            POL_Extra_textbox.Enabled = false;
            POR_Main_textbox.Enabled = false;
            POR_Extra_textbox.Enabled = false;
            RUS_Main_textbox.Enabled = false;
            RUS_Extra_textbox.Enabled = false;
            SPA_Main_textbox.Enabled = false;
            SPA_Extra_textbox.Enabled = false;
            JPN_Main_textbox.Enabled = false;
            JPN_Extra_textbox.Enabled = false;

            

            if (basepath == "") {
                Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog c = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
                c.IsFolderPicker = true;
                if (c.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok) {
                    basepath = c.FileName;
                }
            }
            
            bool exist = false;
            for (int i = 0; i < Program.LANG.Length; i++) {
                string path = basepath + "\\WIN64\\" + Program.LANG[i] + "\\messageInfo.bin.xfbin";
                if (File.Exists(path)) {
                    exist = true;
                    OpenedFile.Add(true);
                    FilePaths.Add(path);
                } else {
                    OpenedFile.Add(false);
                    FilePaths.Add("");
                }
            }
            if (!exist) {
                MessageBox.Show("No files were found.");
                OpenedFile.Clear();
                FilePaths.Clear();
                return;
            }

            comboBox2.SelectedIndex = -1;
            OpenFiles(FilePaths);
            if (OpenedFile[0]) {
                ARAE_Main_textbox.Enabled = true;
                ARAE_Extra_textbox.Enabled = true;
            }
            if (OpenedFile[1]) {
                CHI_Main_textbox.Enabled = true;
                CHI_Extra_textbox.Enabled = true;
            }
            if (OpenedFile[2]) {
                comboBox2.SelectedIndex = 2;
                ENG_Main_textbox.Enabled = true;
                ENG_Extra_textbox.Enabled = true;
            }
            if (OpenedFile[3]) {
                ESMX_Main_textbox.Enabled = true;
                ESMX_Extra_textbox.Enabled = true;
            }
            if (OpenedFile[4]) {
                FRE_Main_textbox.Enabled = true;
                FRE_Extra_textbox.Enabled = true;
            }
            if (OpenedFile[5]) {
                GER_Main_textbox.Enabled = true;
                GER_Extra_textbox.Enabled = true;
            }
            if (OpenedFile[6]) {
                ITA_Main_textbox.Enabled = true;
                ITA_Extra_textbox.Enabled = true;
            }
            if (OpenedFile[7]) {
                KOKR_Main_textbox.Enabled = true;
                KOKR_Extra_textbox.Enabled = true;
            }
            if (OpenedFile[8]) {
                POL_Main_textbox.Enabled = true;
                POL_Extra_textbox.Enabled = true;
            }
            if (OpenedFile[9]) {
                POR_Main_textbox.Enabled = true;
                POR_Extra_textbox.Enabled = true;
            }
            if (OpenedFile[10]) {
                RUS_Main_textbox.Enabled = true;
                RUS_Extra_textbox.Enabled = true;
            }
            if (OpenedFile[11]) {
                SPA_Main_textbox.Enabled = true;
                SPA_Extra_textbox.Enabled = true;
            }
            if (OpenedFile[12]) {
                JPN_Main_textbox.Enabled = true;
                JPN_Extra_textbox.Enabled = true;
            }
            for (int i = 0; i < OpenedFile.Count; i++) {
                if (OpenedFile[i]) {
                    comboBox2.SelectedIndex = i;
                    break;
                }
            }
            listBox1.SelectedIndex = -1;
        }

        public void OpenFiles(List<string> Paths)
        {
            for (int i = 0; i< Paths.Count; i++)
            {
                OpenFile(Paths[i]);
            }
        }
        public void OpenFile(string basepath)
        {

            List<byte[]> CRC32Codes = new List<byte[]>();
            List<byte[]> MainTexts = new List<byte[]>();
            List<byte[]> ExtraTexts = new List<byte[]>();
            List<int> ACBFiles = new List<int>();
            List<int> CueIDs = new List<int>();
            List<int> VoiceOnlys = new List<int>();
            if (basepath != "")
            {
                byte[] FileBytes = File.ReadAllBytes(basepath);
                FileBytesList.Add(FileBytes);
                int EntryCount = FileBytes[288] + FileBytes[289] * 256 + FileBytes[290] * 65536 + FileBytes[291] * 16777216;
                EntryCounts.Add(EntryCount);
                    for (int x2 = 0; x2 < EntryCount; x2++)
                    {
                        long _ptr = 300 + 40 * x2;
                        byte[] CRC32Code = Main.b_ReadByteArray(FileBytes, (int)_ptr, 4);
                        long _ptrIcon3 = FileBytes[_ptr + 8] + FileBytes[_ptr + 9] * 256 + FileBytes[_ptr + 10] * 65536 + FileBytes[_ptr + 11] * 16777216;
                        byte[] ExtraText = Main.b_ReadByteArrayOfString(FileBytes, (int)(_ptr + 8 + _ptrIcon3));
                        _ptrIcon3 = FileBytes[_ptr + 16] + FileBytes[_ptr + 17] * 256 + FileBytes[_ptr + 18] * 65536 + FileBytes[_ptr + 19] * 16777216;
                        byte[] MainText = Main.b_ReadByteArrayOfString(FileBytes, (int)(_ptr + 16 + _ptrIcon3));
                        int ACBFile = Main.b_ReadIntFromTwoBytes(FileBytes, (int)(_ptr + 30));
                        int CueID = Main.b_ReadIntFromTwoBytes(FileBytes, (int)(_ptr + 32));
                        int VoiceOnly = Main.b_ReadIntFromTwoBytes(FileBytes, (int)(_ptr + 34));
                        CRC32Codes.Add(CRC32Code);
                        ExtraTexts.Add(ExtraText);
                        MainTexts.Add(MainText);
                        ACBFiles.Add(ACBFile);
                        CueIDs.Add(CueID);
                        VoiceOnlys.Add(VoiceOnly);
                    }
                    CRC32CodesList.Add(CRC32Codes);
                    ExtraTextsList.Add(ExtraTexts);
                    MainTextsList.Add(MainTexts);
                    ACBFilesList.Add(ACBFiles);
                    CueIDsList.Add(CueIDs);
                    VoiceOnlysList.Add(VoiceOnlys);

            }
            else
            {
                List<byte[]> emptyList = new List<byte[]>();
                List<int> emptyIntList = new List<int>();
                EntryCounts.Add(0);
                FileBytesList.Add(new byte[0]);
                CRC32CodesList.Add(emptyList);
                ExtraTextsList.Add(emptyList);
                MainTextsList.Add(emptyList);
                ACBFilesList.Add(emptyIntList);
                CueIDsList.Add(emptyIntList);
                VoiceOnlysList.Add(emptyIntList);
            }
            
        }

        public void ClearFiles()
        {
            FilePaths = new List<string>();
            FileBytesList = new List<byte[]>();
            EntryCounts = new List<int>();
            CRC32CodesList = new List<List<byte[]>>();
            MainTextsList = new List<List<byte[]>>();
            ExtraTextsList = new List<List<byte[]>>();
            ACBFilesList = new List<List<int>>();
            CueIDsList = new List<List<int>>();
            VoiceOnlysList = new List<List<int>>();
            OpenedFile = new List<bool>();
            listBox1.Items.Clear();
    }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(FilePaths.Count>0)
            {
                if (comboBox2.SelectedIndex != -1)
                {
                    if (OpenedFile[comboBox2.SelectedIndex])
                    {
                        listBox1.Items.Clear();
                        if (comboBox2.SelectedIndex != 0)
                        {
                            for (int i = 0; i < EntryCounts[comboBox2.SelectedIndex]; i++)
                            {
                                listBox1.Items.Add(Encoding.UTF8.GetString(MainTextsList[comboBox2.SelectedIndex][i]));
                                listBox1.RightToLeft = RightToLeft.No;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < EntryCounts[comboBox2.SelectedIndex]; i++)
                            {
                                listBox1.Items.Add(Encoding.UTF8.GetString(MainTextsList[comboBox2.SelectedIndex][i]));
                                listBox1.RightToLeft = RightToLeft.Yes;
                            }
                        };
                    }
                    else
                    {
                        MessageBox.Show("File isn't opened.");
                    }
                }
            }    
            else
            {
                MessageBox.Show("Open files");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index > -1 && index < listBox1.Items.Count)
            {
                if (OpenedFile[0])
                {
                    ARAE_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[0][index]);
                    ARAE_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[0][index]);
                }
                if (OpenedFile[1])
                {
                    CHI_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[1][index]);
                    CHI_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[1][index]);
                }
                if (OpenedFile[2])
                {
                    ENG_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[2][index]);
                    ENG_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[2][index]);
                }
                if (OpenedFile[3])
                {
                    ESMX_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[3][index]);
                    ESMX_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[3][index]);
                }
                if (OpenedFile[4])
                {
                    FRE_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[4][index]);
                    FRE_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[4][index]);
                }
                if (OpenedFile[5])
                {
                    GER_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[5][index]);
                    GER_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[5][index]);
                }
                if (OpenedFile[6])
                {
                    ITA_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[6][index]);
                    ITA_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[6][index]);
                }
                if (OpenedFile[7])
                {
                    KOKR_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[7][index]);
                    KOKR_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[7][index]);
                }
                if (OpenedFile[8])
                {
                    POL_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[8][index]);
                    POL_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[8][index]);
                }
                if (OpenedFile[9])
                {
                    POR_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[9][index]);
                    POR_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[9][index]);
                }
                if (OpenedFile[10])
                {
                    RUS_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[10][index]);
                    RUS_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[10][index]);
                }
                if (OpenedFile[11])
                {
                    SPA_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[11][index]);
                    SPA_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[11][index]);
                }
                if (OpenedFile[12])
                {
                    JPN_Main_textbox.Text = Encoding.UTF8.GetString(MainTextsList[12][index]);
                    JPN_Extra_textbox.Text = Encoding.UTF8.GetString(ExtraTextsList[12][index]);
                }
                textBox1.Text = BitConverter.ToString(CRC32CodesList[comboBox2.SelectedIndex][index]);
                int index2 = 0;
                for (int i = 0; i < OpenedFile.Count; i++)
                {
                    if (OpenedFile[i])
                    {
                        index2 = i;
                        continue;
                    }

                }
                if (CueIDsList[index2][index] == 0xFFFF)
                    numericUpDown1.Value = -1;
                else
                    numericUpDown1.Value = CueIDsList[index2][index];
                if (ACBFilesList[index2][index] == 0xFFFF)
                    comboBox1.SelectedIndex = 0;
                else
                    comboBox1.SelectedIndex = ACBFilesList[index2][index];
                if (VoiceOnlysList[index2][index] == 0)
                {
                    checkBox1.Checked = false;
                }
                else
                {
                    checkBox1.Checked = true;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OpenedFile.Count > 0)
            {
                if (OpenedFile[comboBox2.SelectedIndex])
                {
                    if (textBox2.Text != "")
                    {
                        bool found = false;
                        byte[] FindCRC32 = Main.crc32(textBox2.Text);
                        for (int i =0; i<CRC32CodesList[comboBox2.SelectedIndex].Count;i++)
                        {
                            if(BitConverter.ToString(CRC32CodesList[comboBox2.SelectedIndex][i]) == BitConverter.ToString(FindCRC32))
                            {
                                listBox1.SelectedIndex = i;
                                found = true;
                                continue;
                            }
                        }
                        if (!found)
                        {
                            MessageBox.Show("Couldn't find section with that message ID");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Write text");
                    }
                }
                else
                {
                    MessageBox.Show("Open file before trying to search text");
                }
            }
            else
            {
                MessageBox.Show("Open files before trying to search text");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(OpenedFile.Count>0)
            {
                if (OpenedFile[comboBox2.SelectedIndex])
                {
                    if (textBox4.Text != "")
                    {
                        List<string> NameList = new List<string>();
                        for (int i = 0; i < MainTextsList[comboBox2.SelectedIndex].Count; i++)
                        {
                            NameList.Add(Encoding.UTF8.GetString(MainTextsList[comboBox2.SelectedIndex][i]));
                        }
                        if (Main.SearchStringIndex(NameList, textBox4.Text, EntryCounts[comboBox2.SelectedIndex], listBox1.SelectedIndex) != -1)
                        {
                            listBox1.SelectedIndex = Main.SearchStringIndex(NameList, textBox4.Text, EntryCounts[comboBox2.SelectedIndex], listBox1.SelectedIndex);
                        }
                        else
                        {
                            if (Main.SearchStringIndex(NameList, textBox4.Text, EntryCounts[comboBox2.SelectedIndex], 0) != -1)
                            {
                                listBox1.SelectedIndex = Main.SearchStringIndex(NameList, textBox4.Text, EntryCounts[comboBox2.SelectedIndex], -1);
                            }
                            else
                            {
                                MessageBox.Show("Section with that text doesn't exist in file");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Write text");
                    }
                }
                else
                {
                    MessageBox.Show("Open file before trying to search text");
                }
            }    
            else
            {
                MessageBox.Show("Open files before trying to search text");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                numericUpDown1.Hexadecimal = true;
            else
                numericUpDown1.Hexadecimal = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                AddSection();
            }   
            else
            {
                AddNewSection();
            }
        }

        private void AddSection()
        {
            for (int i = 0; i < FilePaths.Count; i++)
            {
                if (OpenedFile[i])
                {
                    int index = listBox1.SelectedIndex;
                    CRC32CodesList[i].Add(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF });
                    MainTextsList[i].Add(MainTextsList[i][index]);
                    ExtraTextsList[i].Add(ExtraTextsList[i][index]);
                    ACBFilesList[i].Add(ACBFilesList[i][index]);
                    CueIDsList[i].Add(CueIDsList[i][index]);
                    VoiceOnlysList[i].Add(VoiceOnlysList[i][index]);
                    EntryCounts[i]++;
                }
                    
                    
            }
            listBox1.Items.Add(Encoding.UTF8.GetString(MainTextsList[comboBox2.SelectedIndex][MainTextsList[comboBox2.SelectedIndex].Count - 1]));
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        private void AddNewSection() {
            for (int i = 0; i < FilePaths.Count; i++) {
                if (OpenedFile[i]) {
                    CRC32CodesList[i].Add(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF });
                    MainTextsList[i].Add(new byte[0]);
                    ExtraTextsList[i].Add(new byte[0]);
                    ACBFilesList[i].Add(0);
                    CueIDsList[i].Add(0);
                    VoiceOnlysList[i].Add(0);
                    EntryCounts[i]++;
                }
            }
            listBox1.Items.Add(Encoding.UTF8.GetString(MainTextsList[comboBox2.SelectedIndex][MainTextsList[comboBox2.SelectedIndex].Count - 1]));
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                RemoveSection();
            }
            else
            {
                MessageBox.Show("Select any section so you could remove data of it");
            }
        }

        private void RemoveSection()
        {
            int index = listBox1.SelectedIndex;
            for (int i = 0; i < FilePaths.Count; i++)
            {
                if (OpenedFile[i])
                {
                    CRC32CodesList[i].RemoveAt(index);
                    MainTextsList[i].RemoveAt(index);
                    ExtraTextsList[i].RemoveAt(index);
                    ACBFilesList[i].RemoveAt(index);
                    CueIDsList[i].RemoveAt(index);
                    VoiceOnlysList[i].RemoveAt(index);
                    EntryCounts[i]--;
                }


            }
            if (listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex--;
            }
            else
            {
                listBox1.ClearSelected();
            }
            listBox1.Items.RemoveAt(index);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int index = listBox1.SelectedIndex;
                for (int j = 0; j < FilePaths.Count; j++)
                {
                    if (OpenedFile[j])
                    {
                        if (textBox3.Text != "")
                            CRC32CodesList[j][index] = Main.crc32(textBox3.Text);
                        if (comboBox1.SelectedIndex == 0)
                            ACBFilesList[j][index] = 65535;
                        else
                            ACBFilesList[j][index] = comboBox1.SelectedIndex;
                        CueIDsList[j][index] = (int)numericUpDown1.Value;
                        if (checkBox1.Checked)
                            VoiceOnlysList[j][index] = 1;
                        else
                            VoiceOnlysList[j][index] = 0;
                    }

                }
                if (OpenedFile[0])
                {
                    MainTextsList[0][index] = Encoding.UTF8.GetBytes(ARAE_Main_textbox.Text);
                    ExtraTextsList[0][index] = Encoding.UTF8.GetBytes(ARAE_Extra_textbox.Text);
                }
                if (OpenedFile[1])
                {
                    MainTextsList[1][index] = Encoding.UTF8.GetBytes(CHI_Main_textbox.Text);
                    ExtraTextsList[1][index] = Encoding.UTF8.GetBytes(CHI_Extra_textbox.Text);
                }
                if (OpenedFile[2])
                {
                    MainTextsList[2][index] = Encoding.UTF8.GetBytes(ENG_Main_textbox.Text);
                    ExtraTextsList[2][index] = Encoding.UTF8.GetBytes(ENG_Extra_textbox.Text);
                }
                if (OpenedFile[3])
                {
                    MainTextsList[3][index] = Encoding.UTF8.GetBytes(ESMX_Main_textbox.Text);
                    ExtraTextsList[3][index] = Encoding.UTF8.GetBytes(ESMX_Extra_textbox.Text);
                }
                if (OpenedFile[4])
                {
                    MainTextsList[4][index] = Encoding.UTF8.GetBytes(FRE_Main_textbox.Text);
                    ExtraTextsList[4][index] = Encoding.UTF8.GetBytes(FRE_Extra_textbox.Text);
                }
                if (OpenedFile[5])
                {
                    MainTextsList[5][index] = Encoding.UTF8.GetBytes(GER_Main_textbox.Text);
                    ExtraTextsList[5][index] = Encoding.UTF8.GetBytes(GER_Extra_textbox.Text);
                }
                if (OpenedFile[6])
                {
                    MainTextsList[6][index] = Encoding.UTF8.GetBytes(ITA_Main_textbox.Text);
                    ExtraTextsList[6][index] = Encoding.UTF8.GetBytes(ITA_Extra_textbox.Text);
                }
                if (OpenedFile[7])
                {
                    MainTextsList[7][index] = Encoding.UTF8.GetBytes(KOKR_Main_textbox.Text);
                    ExtraTextsList[7][index] = Encoding.UTF8.GetBytes(KOKR_Extra_textbox.Text);
                }
                if (OpenedFile[8])
                {
                    MainTextsList[8][index] = Encoding.UTF8.GetBytes(POL_Main_textbox.Text);
                    ExtraTextsList[8][index] = Encoding.UTF8.GetBytes(POL_Extra_textbox.Text);
                }
                if (OpenedFile[9])
                {
                    MainTextsList[9][index] = Encoding.UTF8.GetBytes(POR_Main_textbox.Text);
                    ExtraTextsList[9][index] = Encoding.UTF8.GetBytes(POR_Extra_textbox.Text);
                }
                if (OpenedFile[10])
                {
                    MainTextsList[10][index] = Encoding.UTF8.GetBytes(RUS_Main_textbox.Text);
                    ExtraTextsList[10][index] = Encoding.UTF8.GetBytes(RUS_Extra_textbox.Text);
                }
                if (OpenedFile[11])
                {
                    MainTextsList[11][index] = Encoding.UTF8.GetBytes(SPA_Main_textbox.Text);
                    ExtraTextsList[11][index] = Encoding.UTF8.GetBytes(SPA_Extra_textbox.Text);
                }
                if (OpenedFile[12])
                {
                    MainTextsList[12][index] = Encoding.UTF8.GetBytes(JPN_Main_textbox.Text);
                    ExtraTextsList[12][index] = Encoding.UTF8.GetBytes(JPN_Extra_textbox.Text);
                }
                if (comboBox2.SelectedIndex == 0)
                    listBox1.Items[index] = ARAE_Main_textbox.Text;    
                else if (comboBox2.SelectedIndex == 1)
                    listBox1.Items[index] = CHI_Main_textbox.Text;
                else if (comboBox2.SelectedIndex == 2)
                    listBox1.Items[index] = ENG_Main_textbox.Text;
                else if (comboBox2.SelectedIndex == 3)
                    listBox1.Items[index] = ESMX_Main_textbox.Text;
                else if (comboBox2.SelectedIndex == 4)
                    listBox1.Items[index] = FRE_Main_textbox.Text;
                else if (comboBox2.SelectedIndex == 5)
                    listBox1.Items[index] = GER_Main_textbox.Text;
                else if (comboBox2.SelectedIndex == 6)
                    listBox1.Items[index] = ITA_Main_textbox.Text;
                else if (comboBox2.SelectedIndex == 7)
                    listBox1.Items[index] = KOKR_Main_textbox.Text;
                else if (comboBox2.SelectedIndex == 8)
                    listBox1.Items[index] = POL_Main_textbox.Text;
                else if (comboBox2.SelectedIndex == 9)
                    listBox1.Items[index] = POR_Main_textbox.Text;
                else if (comboBox2.SelectedIndex == 10)
                    listBox1.Items[index] = RUS_Main_textbox.Text;
                else if (comboBox2.SelectedIndex == 11)
                    listBox1.Items[index] = SPA_Main_textbox.Text;
                else if (comboBox2.SelectedIndex == 12)
                    listBox1.Items[index] = JPN_Main_textbox.Text;
                //listBox1.SelectedIndex--;
                //listBox1.SelectedIndex++;
            }
            else
            {
                MessageBox.Show("Select section which you want to edit");
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void saveFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool foundFile = false;
            for (int i = 0; i < FilePaths.Count; i++)
            {
                if (OpenedFile[i])
                {
                    foundFile = true;
                    SaveFile(i, FilePaths);
                }
                
            }
            if (!foundFile)
            {
                MessageBox.Show("No file loaded...");
            }
            else
            {
                MessageBox.Show("Files succsesfully saved!");
            }
        }
        public void SaveFile(int index, List<string> filePath)
        {
            if (filePath[index] != "")
            {
                if (File.Exists(filePath[index]))
                {
                    if (File.Exists(filePath[index] + ".backup"))
                    {
                        File.Delete(filePath[index] + ".backup");
                    }
                    File.Copy(filePath[index], filePath[index] + ".backup");
                }
                File.WriteAllBytes(filePath[index], ConvertToFile(index));
            }
        }
        public void SaveFilesAs(string basepath = "")
        {
            bool foundFile = false;
            for (int i = 0; i < OpenedFile.Count; i++)
            {
                if (OpenedFile[i])
                {
                    foundFile = true;
                }
            }
            if (!foundFile)
            {
                MessageBox.Show("No file loaded...");
            }
            else
            {
                FolderBrowserDialog s = new FolderBrowserDialog();
                if (basepath == "")
                    s.ShowDialog();
                else
                    s.SelectedPath = basepath;
                List<string> newPaths = new List<string>();
                for (int i = 0; i < OpenedFile.Count; i++)
                {
                    string path = "";
                    if (OpenedFile[i])
                    {
                        path = s.SelectedPath + "\\WIN64\\" + Program.LANG[i] + "\\messageInfo.bin.xfbin";
                        Directory.CreateDirectory(s.SelectedPath + "\\WIN64\\" + Program.LANG[i]);
                        newPaths.Add(path);
                        SaveFile(i, newPaths);
                    }
                    else
                    {
                        newPaths.Add("");
                    }
                }
                if (basepath == "")
                    MessageBox.Show("Files succsesfully saved!");
            }
        }
        public byte[] ConvertToFile(int ListIndex)
        {
            List<byte> file = new List<byte>();
            byte[] header = new byte[0];
            header = Main.b_AddBytes(header, FileBytesList[ListIndex], 0, 0, 300);
            for (int x4 = 0; x4 < header.Length; x4++)
            {
                file.Add(header[x4]);
            }
            for (int x3 = 0; x3 < EntryCounts[ListIndex] * 40; x3++)
            {
                file.Add(0);
            }

            List<int> MainTextPointer = new List<int>();
            List<int> ExtraTextPointer = new List<int>();

            for (int x2 = 0; x2 < EntryCounts[ListIndex]; x2++)
            {
                MainTextPointer.Add(file.Count);
                int nameLength3 = MainTextsList[ListIndex][x2].Length;
                if (Encoding.UTF8.GetString(MainTextsList[ListIndex][x2]) == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int a17 = 0; a17 < nameLength3; a17++)
                    {
                        file.Add(MainTextsList[ListIndex][x2][a17]);
                    }

                    for (int a16 = 0; a16 < 1; a16++)
                    {
                        file.Add(0);
                    }
                }
                ExtraTextPointer.Add(file.Count);
                nameLength3 = ExtraTextsList[ListIndex][x2].Length;
                if (Encoding.UTF8.GetString(ExtraTextsList[ListIndex][x2]) == "")
                {
                    nameLength3 = 0;
                }
                else
                {
                    for (int a17 = 0; a17 < nameLength3; a17++)
                    {
                        file.Add(ExtraTextsList[ListIndex][x2][a17]);
                    }

                    for (int a16 = 0; a16 < 1; a16++)
                    {
                        file.Add(0);
                    }
                }
                int newPointer3 = MainTextPointer[x2] - 300 - 40 * x2 - 16;
                byte[] ptrBytes3 = BitConverter.GetBytes(newPointer3);
                if (Encoding.UTF8.GetString(MainTextsList[ListIndex][x2]) == "")
                {

                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[300 + 40 * x2 + 16 + a7] = 0;
                    }
                }
                else
                {
                    newPointer3 = MainTextPointer[x2] - 300 - 40 * x2 - 16;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[300 + 40 * x2 + 16 + a7] = ptrBytes3[a7];
                    }
                }

                //-----

                
                newPointer3 = ExtraTextPointer[x2] - 300 - 40 * x2 - 8;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                if (Encoding.UTF8.GetString(ExtraTextsList[ListIndex][x2]) == "")
                {

                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[300 + 40 * x2 + 8 + a7] = 0;
                    }
                }
                else
                {
                    newPointer3 = ExtraTextPointer[x2] - 300 - 40 * x2 - 8;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++)
                    {
                        file[300 + 40 * x2 + 8 + a7] = ptrBytes3[a7];
                    }
                }




                // VALUES
                byte[] o_a = CRC32CodesList[ListIndex][x2];
                for (int a8 = 0; a8 < 4; a8++)
                {
                    file[300 + 40 * x2 + 0 + a8] = o_a[a8];
                }
                o_a = new byte[2] { 0xFF, 0xFF };
                for (int a8 = 0; a8 < 2; a8++)
                {
                    file[300 + 40 * x2 + 28 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ACBFilesList[ListIndex][x2]);
                for (int a8 = 0; a8 < 2; a8++)
                {
                    file[300 + 40 * x2 + 30 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(CueIDsList[ListIndex][x2]);
                for (int a8 = 0; a8 < 2; a8++)
                {
                    file[300 + 40 * x2 + 32 + a8] = o_a[a8];
                }
                file[300 + 40 * x2 + 34] = (byte)VoiceOnlysList[ListIndex][x2];
            }
            int FileSize3 = file.Count - 284;
            byte[] sizeBytes3 = BitConverter.GetBytes(FileSize3);
            byte[] sizeBytes2 = BitConverter.GetBytes(FileSize3 + 4);
            for (int a20 = 0; a20 < 4; a20++)
            {
                file[280 + a20] = sizeBytes3[3 - a20];
            }
            for (int a19 = 0; a19 < 4; a19++)
            {
                file[268 + a19] = sizeBytes2[3 - a19];
            }
            byte[] countBytes = BitConverter.GetBytes(EntryCounts[ListIndex]);
            for (int a18 = 0; a18 < 4; a18++)
            {
                file[288 + a18] = countBytes[a18];
            }
            byte[] finalBytes = new byte[20]
            {
                0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x02,0x00,0x79,0x77,0x77,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x00
            };
            for (int x = 0; x < finalBytes.Length; x++)
            {
                file.Add(finalBytes[x]);
            }
            return file.ToArray();
        }

        private void saveFilesAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFilesAs();
        }

        private void closeFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearFiles();
        }

        private void Tool_MessageInfoEditor_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(Main.messageInfoPath)) {
                OpenFilesStart(Main.messageInfoPath);
            }
        }
    }
}
