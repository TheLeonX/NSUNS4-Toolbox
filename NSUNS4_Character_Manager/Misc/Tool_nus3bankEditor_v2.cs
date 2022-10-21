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

namespace NSUNS4_Character_Manager.Misc {
    public partial class Tool_nus3bankEditor_v2 : Form {
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
        public List<float> TONE_unk1_List = new List<float>();
        public List<float> TONE_unk2_List = new List<float>();
        public List<float> TONE_unk3_List = new List<float>();
        public List<float> TONE_unk4_List = new List<float>();
        public List<float> TONE_unk5_List = new List<float>();
        public List<float> TONE_MainVolume_List = new List<float>();
        public List<float> TONE_unk6_List = new List<float>();
        public List<float> TONE_unk7_List = new List<float>();
        public List<int> TONE_unk8_List = new List<int>();
        public List<int> TONE_unk9_List = new List<int>();
        public List<int> TONE_unk10_List = new List<int>();
        public List<int> TONE_unk11_List = new List<int>();
        public List<int> TONE_unk12_List = new List<int>();
        public List<int> TONE_unk13_List = new List<int>();
        public List<int> TONE_unk14_List = new List<int>();
        public List<int> TONE_ChannelCheckBox_Count_List = new List<int>();
        public List<int> TONE_unk16_List = new List<int>();
        public List<int> TONE_ChannelCount_List = new List<int>();
        public List<int> TONE_unk17_List = new List<int>();
        public List<float> TONE_unk18_List = new List<float>();
        public List<int> TONE_unk19_List = new List<int>();
        public List<float> TONE_unk20_List = new List<float>();
        public List<float> TONE_unk21_List = new List<float>();
        public List<int> TONE_unk22_List = new List<int>();
        public List<int> TONE_unk23_List = new List<int>();
        public List<int> TONE_unk24_List = new List<int>();
        public List<int> TONE_unk25_List = new List<int>();
        public List<int> TONE_unk26_List = new List<int>();
        public List<int> TONE_unk27_List = new List<int>();
        public List<int> TONE_unk28_List = new List<int>();
        public List<List<int>> TONE_ChannelSection_unk_List = new List<List<int>>();
        public List<List<bool>> TONE_ChannelSection_checkbox_List = new List<List<bool>>();
        public List<List<float>> TONE_ChannelSection_Volume_List = new List<List<float>>();
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
            FileOpen = true;
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

            EntryCount = Main.b_ReadInt(fileBytes, TONE_Position + 0x08);
            
            for (int x = 0; x<EntryCount; x++) {
                long _ptr = TONE_Position + 0x0C + (0x08 * x);
                int newPtr = TONE_Position + 0x08 + Main.b_ReadInt(fileBytes, (int)_ptr);
                byte[] SectionType = new byte[0];
                byte[] SectionTypeValues = new byte[0];
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
                    SoundName = "Empty Sound";

                TONE_SoundName_List.Add(SoundName);
                //PlaySound
                int SoundSize = 0;
                int SoundPos = 0;
                float unk1 = 0;
                float unk2 = 0;
                float unk3 = 0;
                float unk4 = 0;
                float unk5 = 0;
                float MainVolume = 0;
                float unk6 = 0;
                float unk7 = 0;
                int unk8 = 0;
                int unk9 = 0;
                int unk10 = 0;
                int unk11 = 0;
                int unk12 = 0;
                int unk13 = 0;
                int unk14 = 0;
                int CheckBoxCount = 0;
                int unk16 = 0;
                int ChannelCount = 0;
                int unk17 = 0;
                float unk18 = 0;
                int unk19 = 0;
                float unk20 = 0;
                float unk21 = 0;
                int unk22 = 0;
                int unk23 = 0;
                int unk24 = 0;
                int unk25 = 0;
                int unk26 = 0;
                int unk27 = 0;
                int unk28 = 0;
                List<float> ChannelVolume_List = new List<float>();
                List<int> ChannelUnk_List = new List<int>();
                List<bool> ChannelCheckBox_List = new List<bool>();
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
                    SoundPos = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x04);
                    SoundSize = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x08);
                    unk1 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x0C);
                    unk2 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x10);
                    unk3 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x14);
                    unk4 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x18);
                    unk5 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x1C);
                    MainVolume = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x20);
                    unk6 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x24);
                    unk7 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x28);
                    unk8 = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x2C);
                    unk9 = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x30);
                    unk10 = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x34);
                    unk11 = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x38);
                    unk12 = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x3C);
                    unk13 = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x40);
                    unk14 = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x44);
                    CheckBoxCount = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x48);
                    unk16 = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x4C);
                    ChannelCount = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x50);
                    MessageBox.Show(TONE_SoundName_List[x] + " " + ChannelCount.ToString("X2") + " " + CheckBoxCount.ToString("X2"));
                    //unk17 = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x54 + (4* CheckBoxCount));
                    //unk18 = Main.b_ReadFloat(fileBytes, newPtr + newPos + 0x58 + (4 * CheckBoxCount));
                    //unk19 = Main.b_ReadInt(fileBytes, newPtr + newPos + 0x5C + (4 * CheckBoxCount));
                    newPtr += newPos + 0x54;
                    for (int c = 0; c < CheckBoxCount; c++) {
                        bool CheckBox = Convert.ToBoolean(Main.b_ReadInt(fileBytes, newPtr + newPos + 0x54 + (0x04 * c)));
                        ChannelCheckBox_List.Add(CheckBox);
                    }
                    newPtr += 4 * CheckBoxCount;
                    for (int c = 0; c< ChannelCount-1; c++) {
                        float Volume = Main.b_ReadFloat(fileBytes, newPtr +(0x08*c));
                        int unk = Main.b_ReadInt(fileBytes, newPtr + (0x08 * c));
                        ChannelVolume_List.Add(Volume);
                        ChannelUnk_List.Add(unk);
                    }
                    newPtr += 0x08 * (ChannelCount - 1);
                    unk20 = Main.b_ReadFloat(fileBytes, newPtr + 0x00);
                    unk21 = Main.b_ReadFloat(fileBytes, newPtr + 0x04);
                    unk22 = Main.b_ReadInt(fileBytes, newPtr + 0x08);
                    unk23 = Main.b_ReadInt(fileBytes, newPtr + 0x0C);
                    int BitRate = Main.b_ReadInt(fileBytes, newPtr + 0x10);
                    //FIX POSITIONS
                    //MessageBox.Show(BitRate.ToString("X2"));
                    if (BitRate != 0) {
                        unk24 = Main.b_ReadInt(fileBytes, newPtr + 0x1C);
                        unk25 = Main.b_ReadInt(fileBytes, newPtr + 0x20);
                        unk26 = Main.b_ReadInt(fileBytes, newPtr + 0x24);
                        unk27 = Main.b_ReadInt(fileBytes, newPtr + 0x28);
                        unk28 = Main.b_ReadInt(fileBytes, newPtr + 0x2C);
                        OverlaySound = Convert.ToBoolean(Main.b_ReadInt(fileBytes, newPtr + 0x30));
                    }
                }
                else if (TONE_SectionType_List[x] == 1) {
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
                    OverlaySound = Convert.ToBoolean(Main.b_ReadInt(fileBytes, newPtr + newPos + 0x10 + (0x10 * RandomizerSectionCount) + 0x14));

                }
                TONE_SoundPos_List.Add(SoundPos);
                TONE_SoundSize_List.Add(SoundSize);
                TONE_unk1_List.Add(unk1);
                TONE_unk2_List.Add(unk2);
                TONE_unk3_List.Add(unk3);
                TONE_unk4_List.Add(unk4);
                TONE_unk5_List.Add(unk5);
                TONE_unk6_List.Add(unk6);
                TONE_unk7_List.Add(unk7);
                TONE_unk8_List.Add(unk8);
                TONE_unk9_List.Add(unk9);
                TONE_unk10_List.Add(unk10);
                TONE_unk11_List.Add(unk11);
                TONE_unk12_List.Add(unk12);
                TONE_unk13_List.Add(unk13);
                TONE_unk14_List.Add(unk14);
                TONE_ChannelCheckBox_Count_List.Add(CheckBoxCount);
                TONE_unk16_List.Add(unk16);
                TONE_unk17_List.Add(unk17);
                TONE_unk18_List.Add(unk18);
                TONE_unk19_List.Add(unk19);
                TONE_unk20_List.Add(unk20);
                TONE_unk21_List.Add(unk21);
                TONE_unk22_List.Add(unk22);
                TONE_unk23_List.Add(unk23);
                TONE_unk24_List.Add(unk24);
                TONE_unk25_List.Add(unk25);
                TONE_unk26_List.Add(unk26);
                TONE_unk27_List.Add(unk27);
                TONE_unk28_List.Add(unk28);
                TONE_ChannelCount_List.Add(ChannelCount);
                TONE_OverlaySound_List.Add(OverlaySound);
                TONE_MainVolume_List.Add(MainVolume);
                TONE_ChannelSection_Volume_List.Add(ChannelVolume_List);
                TONE_ChannelSection_unk_List.Add(ChannelUnk_List);
                TONE_ChannelSection_checkbox_List.Add(ChannelCheckBox_List);

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
                listBox1.Items.Add(SoundName);
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
            TONE_unk1_List = new List<float>();
            TONE_unk2_List = new List<float>();
            TONE_unk3_List = new List<float>();
            TONE_unk4_List = new List<float>();
            TONE_unk5_List = new List<float>();
            TONE_MainVolume_List = new List<float>();
            TONE_unk6_List = new List<float>();
            TONE_unk7_List = new List<float>();
            TONE_unk8_List = new List<int>();
            TONE_unk9_List = new List<int>();
            TONE_unk10_List = new List<int>();
            TONE_unk11_List = new List<int>();
            TONE_unk12_List = new List<int>();
            TONE_unk13_List = new List<int>();
            TONE_unk14_List = new List<int>();
            TONE_ChannelCheckBox_Count_List = new List<int>();
            TONE_unk16_List = new List<int>();
            TONE_ChannelCount_List = new List<int>();
            TONE_unk17_List = new List<int>();
            TONE_unk18_List = new List<float>();
            TONE_unk19_List = new List<int>();
            TONE_unk20_List = new List<float>();
            TONE_unk21_List = new List<float>();
            TONE_unk22_List = new List<int>();
            TONE_unk23_List = new List<int>();
            TONE_unk24_List = new List<int>();
            TONE_unk25_List = new List<int>();
            TONE_unk26_List = new List<int>();
            TONE_unk27_List = new List<int>();
            TONE_unk28_List = new List<int>();
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
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
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
        }

        private void Tool_nus3bankEditor_v2_Load(object sender, EventArgs e) {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x!=-1) {
                unk1_v.Value = (decimal)TONE_unk1_List[x];
                unk2_v.Value = (decimal)TONE_unk2_List[x];
                unk3_v.Value = (decimal)TONE_unk3_List[x];
                unk4_v.Value = (decimal)TONE_unk4_List[x];
                unk5_v.Value = (decimal)TONE_unk5_List[x];
                unk6_v.Value = (decimal)TONE_unk6_List[x];
                unk7_v.Value = (decimal)TONE_unk7_List[x];
                unk8_v.Value = TONE_unk8_List[x];
                unk9_v.Value = TONE_unk9_List[x];
                unk10_v.Value = TONE_unk10_List[x];
                unk11_v.Value = TONE_unk11_List[x];
                unk12_v.Value = TONE_unk12_List[x];
                unk13_v.Value = TONE_unk13_List[x];
                unk14_v.Value = TONE_unk14_List[x];
                unk16_v.Value = TONE_unk16_List[x];
                unk17_v.Value = TONE_unk17_List[x];
                unk18_v.Value = (decimal)TONE_unk18_List[x];
                unk19_v.Value = TONE_unk19_List[x];
                unk20_v.Value = (decimal)TONE_unk20_List[x];
                unk21_v.Value = (decimal)TONE_unk21_List[x];
                unk22_v.Value = (decimal)TONE_unk22_List[x];
                unk23_v.Value = TONE_unk23_List[x];
                unk24_v.Value = TONE_unk24_List[x];
                unk25_v.Value = TONE_unk25_List[x];
                unk26_v.Value = TONE_unk26_List[x];
                unk27_v.Value = TONE_unk27_List[x];
                unk28_v.Value = TONE_unk28_List[x];
                MainVolume_v.Value = (decimal)TONE_MainVolume_List[x];
                Overlay_v.Checked = TONE_OverlaySound_List[x];
                textBox2.Text = TONE_SoundName_List[x];
                comboBox1.SelectedIndex = TONE_SectionType_List[x];
                listBox3.Items.Clear();
                for (int c = 0; c<TONE_ChannelSection_Volume_List[x].Count;c++) {
                    listBox3.Items.Add("Channel");
                }
                checkedListBox1.Items.Clear();
                for (int c = 0; c < TONE_ChannelSection_checkbox_List[x].Count; c++) {
                    checkedListBox1.Items.Add("Channel");
                    checkedListBox1.SetItemChecked(c, TONE_ChannelSection_checkbox_List[x][c]);
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e) {
            int x = listBox3.SelectedIndex;
            int c = listBox1.SelectedIndex;
            if (c != -1 && x !=-1) {
                ChannelVolume_v.Value = (decimal)TONE_ChannelSection_Volume_List[c][x];
                ChannelUnk_v.Value = TONE_ChannelSection_unk_List[c][x];
            }
        }
    }
}
