using NAudio.Codecs;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NSUNS4_Character_Manager.Misc {
    public partial class Tool_nus3bankEditor_v2 : Form {
        private WaveOutEvent waveOut; // or WaveOutEvent()
        private WaveFileReader reader;
        public Tool_nus3bankEditor_v2() {
            InitializeComponent();
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);

            

        }
        public bool FileOpen = false;
        public string FilePath = "";
        public byte[] fileBytes = new byte[0];
        public bool XfbinHeader = false;
        public int NUS3_Position = 0;
        public int PROP_Position = 0;
        public int BINF_Position = 0;
        public int GRP_Position = 0;
        public int DTON_Position = 0;
        public int TONE_Position = 0;
        public int JUNK_Position = 0;
        public int PACK_Position = 0;
        public byte[] PROP_fileBytes = new byte[0];
        public byte[] BINF_fileBytes = new byte[0];
        public byte[] GRP_fileBytes = new byte[0];
        public byte[] DTON_fileBytes = new byte[0];
        public byte[] JUNK_fileBytes = new byte[0];

        public byte[] PlaySound_bytes = new byte[2] { 0xFF, 0xFF };
        public byte[] Randomizer_bytes = new byte[2] { 0x7F, 0x00 };
        public byte[] EmptySound_bytes = new byte[2] { 0x01, 0x00 };

        public List<int> TONE_SectionType_List = new List<int>();
        public List<byte[]> TONE_SectionTypeValues_List = new List<byte[]>();
        public List<string> TONE_SoundName_List = new List<string>();

        //PlaySound
        public List<int> TONE_SoundPos_List = new List<int>();
        public List<int> TONE_SoundSize_List = new List<int>();
        public List<float> TONE_MainVolume_List = new List<float>();
        public List<byte[]> TONE_SoundSettings_List = new List<byte[]>();

        public List<byte[]> TONE_SoundData_List = new List<byte[]>();
        //Randomizer
        public List<int> TONE_RandomizerType_List = new List<int>();
        public List<int> TONE_RandomizerLength_List = new List<int>();
        public List<int> TONE_RandomizerUnk1_List = new List<int>();
        public List<int> TONE_RandomizerSectionCount_List = new List<int>();
        public List<List<int>> TONE_RandomizerOneSection_ID_List = new List<List<int>>();
        public List<List<int>> TONE_RandomizerOneSection_unk_List = new List<List<int>>();
        public List<List<float>> TONE_RandomizerOneSection_PlayChance_List = new List<List<float>>();
        public List<List<int>> TONE_RandomizerOneSection_SoundID_List = new List<List<int>>();
        public List<float> TONE_RandomizerUnk2_List = new List<float>();
        public List<float> TONE_RandomizerUnk3_List = new List<float>();
        public List<float> TONE_RandomizerUnk4_List = new List<float>();
        public List<float> TONE_RandomizerUnk5_List = new List<float>();
        public List<float> TONE_RandomizerUnk6_List = new List<float>();

        public List<bool> TONE_OverlaySound_List = new List<bool>();

        public int IndexSelectedRow = 0;


        public int EntryCount = 0;

        public int FileID = 0;

        private void supportedFormatsToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("BNSF, BNSG, WAV, RIFF, IVAG, VAG, IPCM, AAC, IDSP, IS14, IS22, IMA4, XMA, XMA2, OGG, CAF, AIFF");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFile();
        }

        public void OpenFile(string basepath = "") {
            OpenFileDialog o = new OpenFileDialog();
            {
                o.DefaultExt = ".xfbin";
                o.Filter = "XFBIN Container(*.xfbin)|*.xfbin|NUS3BANK Container(*.nus3bank)|*.nus3bank";
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
            FilePath = o.FileName;
            fileBytes = File.ReadAllBytes(FilePath);
            if (Main.b_ReadString2(fileBytes, 0, 4) == "NUCC")
                XfbinHeader = true;
            else
                XfbinHeader = false;
            NUS3_Position = Main.b_FindBytes(fileBytes, new byte[4] { 0x4E, 0x55, 0x53, 0x33 });
            PROP_Position = Main.b_FindBytes(fileBytes, new byte[4] { 0x50, 0x52, 0x4F, 0x50 }, NUS3_Position+0x50);
            BINF_Position = Main.b_FindBytes(fileBytes, new byte[4] { 0x42, 0x49, 0x4E, 0x46 }, NUS3_Position + 0x50);
            GRP_Position = Main.b_FindBytes(fileBytes, new byte[4] { 0x47, 0x52, 0x50, 0x20 }, NUS3_Position + 0x50);
            DTON_Position = Main.b_FindBytes(fileBytes, new byte[4] { 0x44, 0x54, 0x4F, 0x4E }, NUS3_Position + 0x50);
            TONE_Position = Main.b_FindBytes(fileBytes, new byte[4] { 0x54, 0x4F, 0x4E, 0x45 }, NUS3_Position + 0x50);
            JUNK_Position = Main.b_FindBytes(fileBytes, new byte[4] { 0x4A, 0x55, 0x4E, 0x4B }, NUS3_Position + 0x50);
            PACK_Position = Main.b_FindBytes(fileBytes, new byte[4] { 0x50, 0x41, 0x43, 0x4B }, NUS3_Position + 0x50);

            PROP_fileBytes = Main.b_ReadByteArray(fileBytes, PROP_Position, Main.b_ReadInt(fileBytes, PROP_Position + 0x4)+0x8);
            BINF_fileBytes = Main.b_ReadByteArray(fileBytes, BINF_Position, Main.b_ReadInt(fileBytes, BINF_Position + 0x4) + 0x8);
            GRP_fileBytes = Main.b_ReadByteArray(fileBytes, GRP_Position, Main.b_ReadInt(fileBytes, GRP_Position + 0x4) + 0x8);
            DTON_fileBytes = Main.b_ReadByteArray(fileBytes, DTON_Position, Main.b_ReadInt(fileBytes, DTON_Position + 0x4) + 0x8);
            JUNK_fileBytes = Main.b_ReadByteArray(fileBytes, JUNK_Position, Main.b_ReadInt(fileBytes, JUNK_Position + 0x4) + 0x8);

            FileID = Main.b_ReadInt(BINF_fileBytes, BINF_fileBytes.Length - 0x04);
            FileID_v.Value = FileID;
            EntryCount = Main.b_ReadInt(fileBytes, TONE_Position + 0x08);
            
            for (int x = 0; x<EntryCount; x++) {
                long _ptr = TONE_Position + 0x0C + (0x08 * x);
                int TONE_Size = Main.b_ReadInt(fileBytes, (int)_ptr+4);
                int newPtr = TONE_Position + 0x08 + Main.b_ReadInt(fileBytes, (int)_ptr);
                byte[] SectionType = new byte[0];
                byte[] SectionTypeValues = new byte[0];
                byte[] SoundData = new byte[0];
                SectionType = Main.b_ReadByteArray(fileBytes, newPtr + 0x04, 0x02);
                SectionTypeValues = Main.b_ReadByteArray(fileBytes, newPtr + 0x06, 0x06);
                if (BitConverter.ToString(SectionType) == BitConverter.ToString(PlaySound_bytes))
                    TONE_SectionType_List.Add(0);
                else if (BitConverter.ToString(SectionType) == BitConverter.ToString(Randomizer_bytes))
                    TONE_SectionType_List.Add(1);
                else
                    TONE_SectionType_List.Add(2);
                TONE_SectionTypeValues_List.Add(SectionTypeValues);

                string SoundName = Main.b_ReadString2(fileBytes, TONE_Position + 0x08 + Main.b_ReadInt(fileBytes, (int)_ptr) + 0x0D);
                if (SoundName == "")
                    SoundName = "Empty slot";

                TONE_SoundName_List.Add(SoundName);
                //PlaySound
                int SoundSize = 0;
                int SoundPos = 0;
                float MainVolume = 0;
                byte[] SectionSettings = new byte[0];

                //Randomizer
                int RandomizerType = 0;
                int RandomizerLength = 0;
                int RandomizerUnk1 = 0;
                int RandomizerSectionCount = 0;
                List<int> Randomizer_OneSectionID = new List<int>();
                List<int> Randomizer_OneSection_unk = new List<int>();
                List<float> Randomizer_OneSection_PlayChance = new List<float>();
                List<int> Randomizer_OneSection_SoundID = new List<int>();

                float RandomizerUnk2 = 0;
                float RandomizerUnk3 = 0;
                float RandomizerUnk4 = 0;
                float RandomizerUnk5 = 0;
                float RandomizerUnk6 = 0;
                bool OverlaySound = false;

                if (TONE_SectionType_List[x] == 0) {
                    int newPos = 0;
                    do {
                        newPos++;
                    }
                    while (Main.b_ReadInt(fileBytes, newPtr + 0x0D + newPos) != 8);
                    newPos += 0xD;
                    newPtr += newPos;
                    SoundPos = Main.b_ReadInt(fileBytes, newPtr + 0x04);
                    SoundSize = Main.b_ReadInt(fileBytes, newPtr + 0x08);
                    MainVolume = Main.b_ReadFloat(fileBytes, newPtr + 0x0C);
                    int index = newPos + 0x10;
                    SectionSettings = Main.b_ReadByteArray(fileBytes, newPtr + 0x10, TONE_Size - index - 4);
                    OverlaySound = !Convert.ToBoolean(Main.b_ReadInt(fileBytes, newPtr + 0x10 + TONE_Size - index - 4));
                    SoundData = Main.b_ReadByteArray(fileBytes, PACK_Position + 8 + SoundPos, SoundSize);

                } else if (TONE_SectionType_List[x] == 1) {
                    int newPos = 0;
                    do {
                        newPos++;
                    }
                    while (Main.b_ReadInt(fileBytes, newPtr + 0x0D + newPos) != 1);
                    newPos += 0xD;
                    RandomizerType = Main.b_ReadInt(fileBytes, newPtr + newPos);
                    RandomizerLength = Main.b_ReadInt(fileBytes, newPtr + newPos+0x04);
                    RandomizerUnk1 = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x08);
                    RandomizerSectionCount = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x0C);
                    for (int c = 0; c<RandomizerSectionCount; c++) {
                        int SectionID = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x10 + (0x10*c));
                        int unk = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x10 + (0x10 * c)+0x04);
                        float PlayChance = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x10 + (0x10 * c) + 0x08);
                        int SoundID =  Main.b_ReadInt(fileBytes, newPtr + newPos + 0x10 + (0x10 * c) + 0x0C);
                        Randomizer_OneSectionID.Add(SectionID);
                        Randomizer_OneSection_unk.Add(unk);
                        Randomizer_OneSection_PlayChance.Add(PlayChance);
                        Randomizer_OneSection_SoundID.Add(SoundID);
                    }
                    RandomizerUnk2 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x10 + (0x10 * RandomizerSectionCount));
                    RandomizerUnk3 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x10 + (0x10 * RandomizerSectionCount)+0x04);
                    RandomizerUnk4 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x10 + (0x10 * RandomizerSectionCount) + 0x08);
                    RandomizerUnk5 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x10 + (0x10 * RandomizerSectionCount) + 0x0C);
                    RandomizerUnk6 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x10 + (0x10 * RandomizerSectionCount) + 0x10);
                    OverlaySound = !Convert.ToBoolean(Main.b_ReadInt(fileBytes, newPtr + newPos + 0x10 + (0x10 * RandomizerSectionCount) + 0x14));

                }
                TONE_SoundPos_List.Add(SoundPos);
                TONE_SoundSize_List.Add(SoundSize);
                TONE_OverlaySound_List.Add(OverlaySound);
                TONE_MainVolume_List.Add(MainVolume);
                TONE_SoundSettings_List.Add(SectionSettings);
                TONE_SoundData_List.Add(SoundData);

                TONE_RandomizerType_List.Add(RandomizerType);
                TONE_RandomizerLength_List.Add(RandomizerLength);
                TONE_RandomizerUnk1_List.Add(RandomizerUnk1);
                TONE_RandomizerSectionCount_List.Add(RandomizerSectionCount);
                TONE_RandomizerOneSection_ID_List.Add(Randomizer_OneSectionID);
                TONE_RandomizerOneSection_unk_List.Add(Randomizer_OneSection_unk);
                TONE_RandomizerOneSection_PlayChance_List.Add(Randomizer_OneSection_PlayChance);
                TONE_RandomizerOneSection_SoundID_List.Add(Randomizer_OneSection_SoundID);
                TONE_RandomizerUnk2_List.Add(RandomizerUnk2);
                TONE_RandomizerUnk3_List.Add(RandomizerUnk3);
                TONE_RandomizerUnk4_List.Add(RandomizerUnk4);
                TONE_RandomizerUnk5_List.Add(RandomizerUnk5);
                TONE_RandomizerUnk6_List.Add(RandomizerUnk6);
                dataGridView1.Rows.Add(x, SoundName);
                FileOpen = true;
            }
        }

        public void ClearFile() {
            NUS3_Position = 0;
            PROP_Position = 0;
            BINF_Position = 0;
            GRP_Position = 0;
            DTON_Position = 0;
            TONE_Position = 0;
            JUNK_Position = 0;
            PACK_Position = 0;
            PROP_fileBytes = new byte[0];
            BINF_fileBytes = new byte[0];
            GRP_fileBytes = new byte[0];
            DTON_fileBytes = new byte[0];
            JUNK_fileBytes = new byte[0];
            TONE_SectionType_List = new List<int>();
            TONE_SectionTypeValues_List = new List<byte[]>();
            TONE_SoundName_List = new List<string>();
            //PlaySound
            TONE_SoundPos_List = new List<int>();
            TONE_SoundSize_List = new List<int>();

            //Randomizer
            TONE_RandomizerType_List = new List<int>();
            TONE_RandomizerLength_List = new List<int>();
            TONE_RandomizerUnk1_List = new List<int>();
            TONE_RandomizerSectionCount_List = new List<int>();
            TONE_RandomizerOneSection_ID_List = new List<List<int>>();
            TONE_RandomizerOneSection_unk_List = new List<List<int>>();
            TONE_RandomizerOneSection_PlayChance_List = new List<List<float>>();
            TONE_RandomizerOneSection_SoundID_List = new List<List<int>>();
            TONE_RandomizerUnk2_List = new List<float>();
            TONE_RandomizerUnk3_List = new List<float>();
            TONE_RandomizerUnk4_List = new List<float>();
            TONE_RandomizerUnk5_List = new List<float>();
            TONE_RandomizerUnk6_List = new List<float>();
            dataGridView1.Rows.Clear();
            listBox2.Items.Clear();
        }

        public void CloseFile() {
            ClearFile();
            FileOpen = false;
            XfbinHeader = false;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox1.SelectedIndex == 0) {
                tabControl1.TabPages.Add(tabPage1);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
                
                
            }
            else if(comboBox1.SelectedIndex == 1) {
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
            }
            else {
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage3);
            }
            if (dataGridView1.CurrentCell.RowIndex != -1) {
                TONE_SectionType_List[dataGridView1.CurrentCell.RowIndex] = comboBox1.SelectedIndex;
            }
        }

        private void Tool_nus3bankEditor_v2_Load(object sender, EventArgs e) {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) {
            int x = dataGridView1.CurrentCell.RowIndex;
            int c = listBox2.SelectedIndex;
            if (x != -1 && c != -1) {
                SoundID_v.Value = TONE_RandomizerOneSection_SoundID_List[x][c];
                PlayChance_v.Value = (decimal)TONE_RandomizerOneSection_PlayChance_List[x][c];
                unk1_r_v.Value = TONE_RandomizerOneSection_unk_List[x][c];
            }
        }

        private readonly G722CodecState _state = new G722CodecState(48000, G722Flags.SampleRate8000);
        private readonly G722Codec _codec = new G722Codec();
        private readonly WaveFormat _waveFormat = new WaveFormat(48000, 1);
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            var senderGrid = (DataGridView)sender;
            string path = Directory.GetCurrentDirectory();
            if (!Directory.Exists(path + "\\temp")) {
                Directory.CreateDirectory(path + "\\temp");
            }
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0) {
                if (TONE_SoundData_List[e.RowIndex].Length > 4 && TONE_SectionType_List[e.RowIndex] == 0) {
                    Decode(TONE_SoundData_List[e.RowIndex], TONE_SoundName_List[e.RowIndex]);
                    if (waveOut == null) {

                        waveOut = new WaveOutEvent();
                        waveOut.PlaybackStopped += OnPlaybackStopped;

                    }
                    if (reader == null) {
                        reader = new WaveFileReader(path + "\\temp\\" + TONE_SoundName_List[e.RowIndex] + ".wav");
                        waveOut.Init(reader);

                    }
                    waveOut.Volume = (float)trackBar1.Value/100;
                    waveOut.Play();
                }
                else {
                    if (TONE_SectionType_List[e.RowIndex] == 0)
                        MessageBox.Show("No Sound Data");
                    else
                        MessageBox.Show("Can't play sound in that type of section");
                }
            }
            UpdateDataGrid();
        }
        void UpdateDataGrid() {
            int x = dataGridView1.CurrentCell.RowIndex;
            if (x != -1) {
                listBox2.Items.Clear();
                comboBox1.SelectedIndex = TONE_SectionType_List[x];
                if (TONE_SectionType_List[x] == 0) {
                    Volume_v.Value = (decimal)TONE_MainVolume_List[x];
                    Overlay_v.Checked = TONE_OverlaySound_List[x];
                } else if (TONE_SectionType_List[x] == 1) {
                    Overlay_v.Checked = TONE_OverlaySound_List[x];
                    for (int c = 0; c < TONE_RandomizerSectionCount_List[x]; c++) {
                        listBox2.Items.Add("Sound");
                        unk1_v.Value = (decimal)TONE_RandomizerUnk2_List[x];
                        unk2_v.Value = (decimal)TONE_RandomizerUnk3_List[x];
                        unk3_v.Value = (decimal)TONE_RandomizerUnk4_List[x];
                        unk4_v.Value = (decimal)TONE_RandomizerUnk5_List[x];
                        unk5_v.Value = (decimal)TONE_RandomizerUnk6_List[x];
                    }
                }
            }
        }
        private void Decode(byte[] data, string name) {
            string path = Directory.GetCurrentDirectory();
            if (!Directory.Exists(path + "\\temp")) {
                Directory.CreateDirectory(path + "\\temp");
            }
            string format = Main.b_ReadString(data, 0);
            if (format.Length > 4) {
                format = Main.b_ReadString(data, 0, 4);
            }
            if (format != "RIFF") {
                if (!File.Exists(path + "\\temp\\" + name + "." + format)) {
                    File.WriteAllBytes(path + "\\temp\\" + name + "." + format, data);
                    Process p = new Process();
                    // Redirect the output stream of the child process.
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = path + "\\vgmstream\\vgmstream.exe";
                    p.StartInfo.Arguments = "-o " + "\"" + path + "\\temp\\" + name + ".wav" + "\" " + "\"" + path + "\\temp\\" + name + "." + format + "\"";
                    p.Start();
                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                }
                
            }
            else {
                if (!File.Exists(path + "\\temp\\" + name + ".wav")) {
                    File.WriteAllBytes(path + "\\temp\\" + name + ".wav", data);
                }

            }
        }

        private void tabPage3_Click(object sender, EventArgs e) {

        }

        private void button5_Click(object sender, EventArgs e) {
            int x = dataGridView1.CurrentCell.RowIndex;
            if (x!=-1) {
                TONE_SoundData_List[x] = new byte[0];
                TONE_SoundSize_List[x] = 0;
                TONE_SoundPos_List[x] = 0;
                MessageBox.Show("Sound data was deleted.");
            }
            else {
                MessageBox.Show("Select sound.");
            }
        }

        private void button9_Click(object sender, EventArgs e) {
            int x = dataGridView1.CurrentCell.RowIndex;
            if (x != -1) {
                OpenFileDialog o = new OpenFileDialog();
                {
                    o.DefaultExt = "*.*";
                    o.Filter = "All formats(*.*)|*.*";
                }
                o.ShowDialog();
                if (!(o.FileName != "") || !File.Exists(o.FileName)) {
                    return;
                }
                TONE_SoundData_List[x] = File.ReadAllBytes(o.FileName);
                MessageBox.Show("Sound successfully imported.");
            } else {
                MessageBox.Show("Select sound slot.");
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) {
            TONE_SectionType_List.RemoveAt(IndexSelectedRow);
            TONE_SectionTypeValues_List.RemoveAt(IndexSelectedRow);
            TONE_SoundName_List.RemoveAt(IndexSelectedRow);
            TONE_SoundPos_List.RemoveAt(IndexSelectedRow);
            TONE_SoundSize_List.RemoveAt(IndexSelectedRow);
            TONE_MainVolume_List.RemoveAt(IndexSelectedRow);
            TONE_SoundSettings_List.RemoveAt(IndexSelectedRow);
            TONE_SoundData_List.RemoveAt(IndexSelectedRow);
            //Randomizer
            TONE_RandomizerType_List.RemoveAt(IndexSelectedRow);
            TONE_RandomizerLength_List.RemoveAt(IndexSelectedRow);
            TONE_RandomizerUnk1_List.RemoveAt(IndexSelectedRow);
            TONE_RandomizerSectionCount_List.RemoveAt(IndexSelectedRow);
            TONE_RandomizerOneSection_ID_List.RemoveAt(IndexSelectedRow);
            TONE_RandomizerOneSection_unk_List.RemoveAt(IndexSelectedRow);
            TONE_RandomizerOneSection_PlayChance_List.RemoveAt(IndexSelectedRow);
            TONE_RandomizerOneSection_SoundID_List.RemoveAt(IndexSelectedRow);
            TONE_RandomizerUnk2_List.RemoveAt(IndexSelectedRow);
            TONE_RandomizerUnk3_List.RemoveAt(IndexSelectedRow);
            TONE_RandomizerUnk4_List.RemoveAt(IndexSelectedRow);
            TONE_RandomizerUnk5_List.RemoveAt(IndexSelectedRow);
            TONE_RandomizerUnk6_List.RemoveAt(IndexSelectedRow);
            TONE_OverlaySound_List.RemoveAt(IndexSelectedRow);

            for (int c = IndexSelectedRow; c<dataGridView1.Rows.Count; c++) {
                dataGridView1.Rows[c].Cells[0].Value = c;
            }
            for (int c = 0; c< TONE_RandomizerOneSection_SoundID_List.Count; c++) {
                for (int k = 0; k< TONE_RandomizerOneSection_SoundID_List[c].Count; k++) {
                    if (TONE_RandomizerOneSection_SoundID_List[c][k] > IndexSelectedRow) {
                        TONE_RandomizerOneSection_SoundID_List[c][k] -= 1;
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
            IndexSelectedRow = dataGridView1.CurrentCell.RowIndex;

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (FileOpen) {
                TONE_SoundName_List[IndexSelectedRow] = dataGridView1.Rows[IndexSelectedRow].Cells[1].Value.ToString();
                MessageBox.Show(TONE_SoundName_List[IndexSelectedRow]);
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            for (int c = 0; c < dataGridView1.Rows.Count; c++) {
                if (dataGridView1.Rows[c].Cells[1].Value.ToString().Contains(textBox1.Text)) {
                    dataGridView1.Rows[c].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[c].Cells[1];
                    break;
                }

            }
            UpdateDataGrid();
        }

        private void button1_Click(object sender, EventArgs e) {
            int x = dataGridView1.CurrentCell.RowIndex;
            if (x!=-1) {
                if (TONE_SectionType_List[x] != 2) {
                    TONE_SectionType_List.Add(TONE_SectionType_List[x]);
                    TONE_SectionTypeValues_List.Add(TONE_SectionTypeValues_List[x]);
                    TONE_SoundName_List.Add(TONE_SoundName_List[x] + "_copy");
                    TONE_SoundPos_List.Add(TONE_SoundPos_List[x]);
                    TONE_SoundSize_List.Add(TONE_SoundSize_List[x]);
                    TONE_MainVolume_List.Add(TONE_MainVolume_List[x]);
                    TONE_SoundSettings_List.Add(TONE_SoundSettings_List[x]);
                    TONE_SoundData_List.Add(TONE_SoundData_List[x]);
                    TONE_RandomizerType_List.Add(TONE_RandomizerType_List[x]);
                    TONE_RandomizerLength_List.Add(TONE_RandomizerLength_List[x]);
                    TONE_RandomizerUnk1_List.Add(TONE_RandomizerUnk1_List[x]);
                    TONE_RandomizerSectionCount_List.Add(TONE_RandomizerSectionCount_List[x]);
                    TONE_RandomizerOneSection_ID_List.Add(TONE_RandomizerOneSection_ID_List[x]);
                    TONE_RandomizerOneSection_unk_List.Add(TONE_RandomizerOneSection_unk_List[x]);
                    TONE_RandomizerOneSection_PlayChance_List.Add(TONE_RandomizerOneSection_PlayChance_List[x]);
                    TONE_RandomizerOneSection_SoundID_List.Add(TONE_RandomizerOneSection_SoundID_List[x]);
                    TONE_RandomizerUnk2_List.Add(TONE_RandomizerUnk2_List[x]);
                    TONE_RandomizerUnk3_List.Add(TONE_RandomizerUnk3_List[x]);
                    TONE_RandomizerUnk4_List.Add(TONE_RandomizerUnk4_List[x]);
                    TONE_RandomizerUnk5_List.Add(TONE_RandomizerUnk5_List[x]);
                    TONE_RandomizerUnk6_List.Add(TONE_RandomizerUnk6_List[x]);
                    TONE_OverlaySound_List.Add(TONE_OverlaySound_List[x]);
                    dataGridView1.Rows.Add(dataGridView1.Rows.Count, TONE_SoundName_List[x] + "_copy");
                }
                else {
                    byte[] SoundData = new byte[0];
                    string SoundName = "Empty slot";
                    //PlaySound
                    int SoundSize = 0;
                    int SoundPos = 0;
                    float MainVolume = 0;
                    byte[] SectionSettings = new byte[0];

                    //Randomizer
                    int RandomizerType = 0;
                    int RandomizerLength = 0;
                    int RandomizerUnk1 = 0;
                    int RandomizerSectionCount = 0;
                    List<int> Randomizer_OneSectionID = new List<int>();
                    List<int> Randomizer_OneSection_unk = new List<int>();
                    List<float> Randomizer_OneSection_PlayChance = new List<float>();
                    List<int> Randomizer_OneSection_SoundID = new List<int>();

                    float RandomizerUnk2 = 0;
                    float RandomizerUnk3 = 0;
                    float RandomizerUnk4 = 0;
                    float RandomizerUnk5 = 0;
                    float RandomizerUnk6 = 0;
                    bool OverlaySound = false;
                    TONE_SectionType_List.Add(TONE_SectionType_List[x]);
                    TONE_SectionTypeValues_List.Add(TONE_SectionTypeValues_List[x]);
                    TONE_SoundName_List.Add(SoundName);
                    TONE_SoundPos_List.Add(SoundPos);
                    TONE_SoundSize_List.Add(SoundSize);
                    TONE_MainVolume_List.Add(MainVolume);
                    TONE_SoundSettings_List.Add(SectionSettings);
                    TONE_SoundData_List.Add(SoundData);
                    TONE_RandomizerType_List.Add(RandomizerType);
                    TONE_RandomizerLength_List.Add(RandomizerLength);
                    TONE_RandomizerUnk1_List.Add(RandomizerUnk1);
                    TONE_RandomizerSectionCount_List.Add(RandomizerSectionCount);
                    TONE_RandomizerOneSection_ID_List.Add(Randomizer_OneSectionID);
                    TONE_RandomizerOneSection_unk_List.Add(Randomizer_OneSection_unk);
                    TONE_RandomizerOneSection_PlayChance_List.Add(Randomizer_OneSection_PlayChance);
                    TONE_RandomizerOneSection_SoundID_List.Add(Randomizer_OneSection_SoundID);
                    TONE_RandomizerUnk2_List.Add(RandomizerUnk2);
                    TONE_RandomizerUnk3_List.Add(RandomizerUnk3);
                    TONE_RandomizerUnk4_List.Add(RandomizerUnk4);
                    TONE_RandomizerUnk5_List.Add(RandomizerUnk5);
                    TONE_RandomizerUnk6_List.Add(RandomizerUnk6);
                    TONE_OverlaySound_List.Add(OverlaySound);
                    dataGridView1.Rows.Add(dataGridView1.Rows.Count, SoundName);
                }
                dataGridView1.Rows[dataGridView1.Rows.Count].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count].Cells[1];

            }
        }

        private void button2_Click(object sender, EventArgs e) {

            if (comboBox1.SelectedIndex == 0) {

            }
        }

        private void FileID_v_ValueChanged(object sender, EventArgs e) {

        }

        private void button10_Click(object sender, EventArgs e) {
            int x = dataGridView1.CurrentCell.RowIndex;
            if (x != -1) {
                OpenFileDialog o = new OpenFileDialog();
                {
                    o.DefaultExt = "*.wav";
                    o.Filter = "Waveform Audio File (*.wav)|*.wav*";
                }
                o.ShowDialog();
                if (!(o.FileName != "") || !File.Exists(o.FileName)) {
                    return;
                }
                string path = Directory.GetCurrentDirectory();
                if (!Directory.Exists(path + "\\temp")) {
                    Directory.CreateDirectory(path + "\\temp");
                }
                string ImportSoundPath = o.FileName;

                using (var reader = new WaveFileReader(ImportSoundPath)) {
                    var newFormat = new WaveFormat(48000, 16, 1);
                    using (var conversionStream = new WaveFormatConversionStream(newFormat, reader)) {
                        WaveFileWriter.CreateWaveFile(path + "\\temp\\48000_output.wav", conversionStream);
                    }
                }
                byte[] ImportSoundFile = File.ReadAllBytes(path + "\\temp\\48000_output.wav");
                byte[] CleanedImportedSoundFile = new byte[0];
                byte[] ConvertedSoundFile = new byte[0];
                int PosOfPCM = 0;
                PosOfPCM = Main.b_FindBytes(ImportSoundFile, Encoding.ASCII.GetBytes("data"));
                if (PosOfPCM == -1) {
                    MessageBox.Show("Wrong format file");
                } else {
                    CleanedImportedSoundFile = Main.b_AddBytes(CleanedImportedSoundFile, ImportSoundFile, 0, PosOfPCM + 8, ImportSoundFile.Length - PosOfPCM - 8);

                    Process p = new Process();
                    // Redirect the output stream of the child process.
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = "encode.exe";
                    
                    File.WriteAllBytes(path + "\\temp\\cleaned_file.wav", CleanedImportedSoundFile);
                    p.StartInfo.Arguments = "0 " + "\"" + path + "\\temp\\cleaned_file.wav" + "\" " + "\"" + path + "\\temp\\converted_file.bnsf\"" + " 48000 14000";
                    //MessageBox.Show(p.StartInfo.Arguments);
                    p.Start();
                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                    string pathOfConvertedFile = path + "\\temp\\converted_file.bnsf";
                    ConvertedSoundFile = File.ReadAllBytes(pathOfConvertedFile);
                    byte[] BNSFHeader = new byte[48] { 0x42, 0x4E, 0x53, 0x46, 0x00, 0x00, 0x4C, 0x80, 0x49, 0x53, 0x31, 0x34, 0x73, 0x66, 0x6D, 0x74, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0xBB, 0x80, 0x00, 0x00, 0xED, 0x89, 0x00, 0x00, 0x00, 0x00, 0x00, 0x78, 0x02, 0x80, 0x73, 0x64, 0x61, 0x74, 0x00, 0x00, 0x4C, 0x58 };
                    byte[] BNSFSound = new byte[0];
                    BNSFSound = Main.b_AddBytes(BNSFSound, BNSFHeader);
                    BNSFSound = Main.b_AddBytes(BNSFSound, ConvertedSoundFile);
                    int ImportedSoundBitRate = Main.b_byteArrayToInt(Main.b_ReadByteArray(ImportSoundFile, 24, 4));
                    int ImportedSoundSoundLength = Main.b_byteArrayToInt(Main.b_ReadByteArray(ImportSoundFile, PosOfPCM + 4, 4)) / ImportSoundFile[32];

                    byte[] Size1OfBNSF = BitConverter.GetBytes(ConvertedSoundFile.Length);
                    byte[] InvertedSize1OfBNSF = new byte[4]
                    {
                    Size1OfBNSF[3],
                    Size1OfBNSF[2],
                    Size1OfBNSF[1],
                    Size1OfBNSF[0]
                    };

                    byte[] Size2OfBNSF = BitConverter.GetBytes(ConvertedSoundFile.Length + 0x28);
                    byte[] InvertedSize2OfBNSF = new byte[4]
                    {
                    Size2OfBNSF[3],
                    Size2OfBNSF[2],
                    Size2OfBNSF[1],
                    Size2OfBNSF[0]
                    };
                    byte[] BNSFBitrate = BitConverter.GetBytes(ImportedSoundBitRate);
                    byte[] InvertedBNSFBitrate = new byte[4]
                    {
                    BNSFBitrate[3],
                    BNSFBitrate[2],
                    BNSFBitrate[1],
                    BNSFBitrate[0]
                    };
                    byte[] BNSFSoundLength = BitConverter.GetBytes(ImportedSoundSoundLength);
                    byte[] InvertedBNSFSoundLength = new byte[4]
                    {
                    BNSFSoundLength[3],
                    BNSFSoundLength[2],
                    BNSFSoundLength[1],
                    BNSFSoundLength[0]
                    };
                    BNSFSound = Main.b_ReplaceBytes(BNSFSound, InvertedSize1OfBNSF, 44);
                    BNSFSound = Main.b_ReplaceBytes(BNSFSound, InvertedSize2OfBNSF, 4);
                    BNSFSound = Main.b_ReplaceBytes(BNSFSound, InvertedBNSFBitrate, 24);
                    BNSFSound = Main.b_ReplaceBytes(BNSFSound, InvertedBNSFSoundLength, 28);
                    TONE_SoundData_List[x] = BNSFSound;
                    TONE_SoundSize_List[x] = TONE_SoundData_List[x].Length;
                    MessageBox.Show("Sound was imported successfully to BNSF format");
                }

                MessageBox.Show("Sound successfully imported in BNSF format.");
            } else {
                MessageBox.Show("Select sound slot.");
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void Tool_nus3bankEditor_v2_FormClosed(object sender, FormClosedEventArgs e) {
            if (waveOut != null && reader != null)
                waveOut.Stop();
            string path = Directory.GetCurrentDirectory();
            Directory.Delete(path + "\\temp", true);
        }
        private void OnPlaybackStopped(object sender, StoppedEventArgs args) {
            waveOut.Dispose();
            waveOut = null;
            reader.Dispose();
            reader = null;
        }
        private void dataGridView1_Click(object sender, EventArgs e) {

            UpdateDataGrid();
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
        }
    }
}
