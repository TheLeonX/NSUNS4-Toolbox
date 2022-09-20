using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace NSUNS4_Character_Manager.Misc
{
    public partial class Tool_nus3bankEditor : Form
    {
        public Tool_nus3bankEditor()
        {
            InitializeComponent();
        }

        public bool FileOpen = false;
        public string FilePath = "";
        public byte[] fileBytes = new byte[0];
        public int EntryCount = 0;
        public int NUS3_Pos = 0;
        public string FileFormat = "";
        public List<int> PROP_PosList = new List<int>();  
        public List<int> GRP_PosList = new List<int>();
        public List<int> DTON_PosList = new List<int>();
        public List<int> TONE_PosList = new List<int>();
        public List<int> JUNK_PosList = new List<int>();
        public List<int> PACK_PosList = new List<int>();
        public byte[] header = new byte[0];
        public byte[] RestOfheader = new byte[0];
        public byte[] FileID = new byte[0];
        public byte[] FileID_replacer = new byte[0];
        //TONE section

        public List<byte[]> TONESectionList = new List<byte[]>();
        public List<int> TONESectionList_Pos = new List<int>();
        public List<int> TONESectionList_Size = new List<int>();
        public List<int> TONESectionDataList_Pos = new List<int>();
        public List<byte[]> TONESectionDataList = new List<byte[]>();
        public List<string> TONESectionNameList = new List<string>();
        public List<int> TONESectionStartData_Pos = new List<int>();

        //TONE DATA
        public List<float> TONESectionData_Volume = new List<float>();
        public List<int> TONESectionData_BitRate = new List<int>();
        public List<int> TONESectionData_SoundLength = new List<int>();
        public List<int> Randomizer = new List<int>();

        //Randomizer DATA
        public List<byte[]> TONESectionDataRandomize_Sound1 = new List<byte[]>();
        public List<byte[]> TONESectionDataRandomize_Sound2 = new List<byte[]>();
        public List<byte[]> TONESectionDataRandomize_Sound3 = new List<byte[]>();
        public List<byte[]> TONESectionDataRandomize_Sound4 = new List<byte[]>();
        public List<int> TONESectionDataRandomize_Count = new List<int>();

        //PACK section
        public List<byte[]> PACKSectionDataList = new List<byte[]>();
        public List<int> PACKSectionList_Pos = new List<int>();
        public List<int> PACKSectionList_Size = new List<int>();
        public List<string> PACKFormat = new List<string>();

        //Sound setting
        public List<string> MonoStereoList = new List<string>();
        public List<string> SoundLoopList = new List<string>();

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        void ClearFile()
        {
            FileOpen = false;
            FilePath = "";
            fileBytes = new byte[0];
            EntryCount = 0;
            NUS3_Pos = 0;
            FileFormat = "";
            PROP_PosList = new List<int>();
            GRP_PosList = new List<int>();
            DTON_PosList = new List<int>();
            TONE_PosList = new List<int>();
            JUNK_PosList = new List<int>();
            PACK_PosList = new List<int>();
            header = new byte[0];
            RestOfheader = new byte[0];
            FileID = new byte[0];
            FileID_replacer = new byte[0];
            //TONE section

            TONESectionList = new List<byte[]>();
            TONESectionList_Pos = new List<int>();
            TONESectionList_Size = new List<int>();
            TONESectionDataList_Pos = new List<int>();
            TONESectionDataList = new List<byte[]>();
            TONESectionNameList = new List<string>();
            TONESectionStartData_Pos = new List<int>();

            //TONE DATA
            TONESectionData_Volume = new List<float>();
            TONESectionData_BitRate = new List<int>();
            TONESectionData_SoundLength = new List<int>();
            Randomizer = new List<int>();

            //Randomizer DATA
            TONESectionDataRandomize_Sound1 = new List<byte[]>();
            TONESectionDataRandomize_Sound2 = new List<byte[]>();
            TONESectionDataRandomize_Sound3 = new List<byte[]>();
            TONESectionDataRandomize_Sound4 = new List<byte[]>();
            TONESectionDataRandomize_Count = new List<int>();

            //PACK section
            PACKSectionDataList = new List<byte[]>();
            PACKSectionList_Pos = new List<int>();
            PACKSectionList_Size = new List<int>();
            PACKFormat = new List<string>();

            //Sound setting
            MonoStereoList = new List<string>();
            SoundLoopList = new List<string>();
            listBox1.Items.Clear();
    }

        void OpenFile()
        {
            OpenFileDialog o = new OpenFileDialog();
            {
                o.DefaultExt = ".xfbin";
                o.Filter = "XFBIN files|*.xfbin|NUS3BANK files|*.NUS3BANK";
            }
            o.ShowDialog();
            if (!(o.FileName != "") || !File.Exists(o.FileName))
            {
                return;
            }
            ClearFile();
            FilePath = o.FileName;
            fileBytes = File.ReadAllBytes(FilePath);
            NUS3_Pos = Main.b_FindBytes(fileBytes, Encoding.ASCII.GetBytes("NUS3"));
            if (Main.b_ReadString2(fileBytes, 0, 4) == "NUCC")
            {
                FileFormat = "XFBIN";
                header = Main.b_ReadByteArray(fileBytes, 0, NUS3_Pos);
            }
            else if (Main.b_ReadString2(fileBytes, 0, 4) == "NUS3")
            {
                FileFormat = "NUS3BANK";
                header = new byte[0];
            }
            else
            {
                MessageBox.Show("File has wrong format", "Wrong format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            PROP_PosList = Main.b_FindBytesList(fileBytes, Encoding.ASCII.GetBytes("PROP"), 0);
            GRP_PosList = Main.b_FindBytesList(fileBytes, Encoding.ASCII.GetBytes("GRP "), 0);
            DTON_PosList = Main.b_FindBytesList(fileBytes, Encoding.ASCII.GetBytes("DTON"), 0);
            TONE_PosList = Main.b_FindBytesList(fileBytes, Encoding.ASCII.GetBytes("TONE"), 0);
            JUNK_PosList = Main.b_FindBytesList(fileBytes, Encoding.ASCII.GetBytes("JUNK"), 0);
            PACK_PosList = Main.b_FindBytesList(fileBytes, Encoding.ASCII.GetBytes("PACK"), 0);
            FileOpen = true;
            RestOfheader = Main.b_ReadByteArray(fileBytes, NUS3_Pos, TONE_PosList[1]- NUS3_Pos+12);

            FileID = new byte[2]
            {
                fileBytes[GRP_PosList[1]-4],
                fileBytes[GRP_PosList[1]-3]
            };
            FileID_value01.Value = fileBytes[GRP_PosList[1] - 4];
            FileID_value02.Value = fileBytes[GRP_PosList[1] - 3];
            EntryCount = fileBytes[TONE_PosList[1]+8] + fileBytes[TONE_PosList[1] + 9] * 256 + fileBytes[TONE_PosList[1] + 10] * 65536 + fileBytes[TONE_PosList[1] + 11] * 16777216;
            for (int x2 = 0; x2 < EntryCount; x2++)
            {
                long _ptr = (TONE_PosList[1] +12) + 8 * x2;
                byte[] _ptrCharacter3 = new byte[8]
                {
                    fileBytes[_ptr],
                    fileBytes[_ptr+1],
                    fileBytes[_ptr+2],
                    fileBytes[_ptr+3],
                    fileBytes[_ptr+4],
                    fileBytes[_ptr+5],
                    fileBytes[_ptr+6],
                    fileBytes[_ptr+7],
                };
                TONESectionList.Add(_ptrCharacter3);
                TONESectionList_Size.Add(fileBytes[_ptr+4] + fileBytes[_ptr + 5] * 256 + fileBytes[_ptr + 6] * 65536 + fileBytes[_ptr + 7] * 16777216);
                TONESectionList_Pos.Add(fileBytes[_ptr] + fileBytes[_ptr + 1] * 256 + fileBytes[_ptr + 2] * 65536 + fileBytes[_ptr + 3] * 16777216);
            }
            for (int x2 = 0; x2 < TONESectionList.Count; x2++)
            {
                int _ptr = TONE_PosList[1] + 12;
                int ToneSectionPos = _ptr + TONESectionList_Pos[x2];
                TONESectionDataList_Pos.Add(ToneSectionPos);
            }
            for (int x2 = 0; x2 < TONESectionList.Count; x2++)
            {
                byte[] ZeroInfo = new byte[0];
                ZeroInfo = Main.b_AddBytes(ZeroInfo, new byte[TONESectionList_Size[x2]]);

                TONESectionDataList.Add(ZeroInfo);
                for (int x3 = 0; x3 < TONESectionList_Size[x2]; x3 = x3 + 4)
                {
                    byte[] SectionChar = new byte[4]
                    {
                        fileBytes[TONESectionDataList_Pos[x2]+x3],
                        fileBytes[TONESectionDataList_Pos[x2]+1+x3],
                        fileBytes[TONESectionDataList_Pos[x2]+2+x3],
                        fileBytes[TONESectionDataList_Pos[x2]+3+x3]
                    };
                    TONESectionDataList[x2]=Main.b_ReplaceBytes(TONESectionDataList[x2], SectionChar, x3);
                   
                }
               
                if (TONESectionList_Size[x2]>0xC)
                {
                    TONESectionNameList.Add(Main.b_ReadString2(TONESectionDataList[x2], 9, TONESectionDataList[x2][8]-1));
                    listBox1.Items.Add(x2.ToString("X2") + " - " + TONESectionNameList[x2]);
                }
                if (TONESectionList_Size[x2] == 12)
                {
                    TONESectionNameList.Add("Empty section");
                    listBox1.Items.Add(x2.ToString("X2") + " - " + TONESectionNameList[x2]);
                }
                TONESectionStartData_Pos.Add(Main.b_FindBytes(TONESectionDataList[x2], new byte[4] { 0x00, 0x00, 0x00, 0x08 }, 0));
                if (TONESectionStartData_Pos[x2]==-1)
                {
                    TONESectionStartData_Pos[x2] = Main.b_FindBytes(TONESectionDataList[x2], new byte[4] { 0x00, 0x00, 0x00, 0x48 }, 0);
                    Randomizer.Add(1);
                    if (TONESectionStartData_Pos[x2] == -1)
                    {
                        TONESectionStartData_Pos[x2] = Main.b_FindBytes(TONESectionDataList[x2], new byte[4] { 0x00, 0x00, 0x00, 0x38 }, 0);
                        if (TONESectionStartData_Pos[x2] == -1)
                        {
                            TONESectionStartData_Pos[x2] = Main.b_FindBytes(TONESectionDataList[x2], new byte[4] { 0x00, 0x00, 0x00, 0x28 }, 0);
                        }
                    }
                }
                else
                {
                    Randomizer.Add(0);
                }
                int BitRateRemovedPos = 0;
                BitRateRemovedPos = Main.b_FindBytes(TONESectionDataList[x2], new byte[8] { 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00,}, 0);
                if (BitRateRemovedPos != -1)
                {
                    TONESectionDataList[x2] = Main.b_AddBytes(TONESectionDataList[x2], new byte[24], BitRateRemovedPos);
                    TONESectionDataList[x2] = Main.b_ReplaceBytes(TONESectionDataList[x2], new byte[44] { 0xFF, 0xFF, 0xFF, 0xFF, 0x80, 0xBB, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, BitRateRemovedPos);
                    TONESectionList_Size[x2] = TONESectionList_Size[x2] + 24;
                }
                byte[] SoundPosition_byte = new byte[4]
                {
                    TONESectionDataList[x2][TONESectionStartData_Pos[x2]+10],
                    TONESectionDataList[x2][TONESectionStartData_Pos[x2]+9],
                    TONESectionDataList[x2][TONESectionStartData_Pos[x2]+8],
                    TONESectionDataList[x2][TONESectionStartData_Pos[x2]+7],
                };
                int SoundPosition = Main.b_ReadIntRev(SoundPosition_byte,0);
                if (TONESectionList_Size[x2]>12)
                {
                    byte[] SoundSize_byte = new byte[4]
                    {
                        TONESectionDataList[x2][TONESectionStartData_Pos[x2]+14],
                        TONESectionDataList[x2][TONESectionStartData_Pos[x2]+13],
                        TONESectionDataList[x2][TONESectionStartData_Pos[x2]+12],
                        TONESectionDataList[x2][TONESectionStartData_Pos[x2]+11],
                    };
                    int SoundSize = Main.b_ReadIntRev(SoundSize_byte, 0);
                    PACKSectionList_Pos.Add(SoundPosition);
                    PACKSectionList_Size.Add(SoundSize);
                    
                    //MessageBox.Show(PACKSectionList_Size[x2].ToString("X2"));
                    if (Randomizer[x2] == 0 && TONESectionDataList[x2].Length>0x9C)
                    {
                        byte[] Volume_byte = new byte[4]
                        {
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2]+15],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2]+16],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2]+17],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2]+18]
                        };
                        float Volume_float = Main.b_ReadFloat(Volume_byte, 0);
                        TONESectionData_Volume.Add(Volume_float);
                        byte[] Bitrate = new byte[4]
                        {
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2]+126],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2]+125],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2]+124],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2]+123]
                        };
                        TONESectionData_BitRate.Add(Main.b_byteArrayToIntRev(Bitrate));
                        byte[] SoundLength = new byte[4]
                        {
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2]+134],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2]+133],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2]+132],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2]+131]
                        };
                        TONESectionData_SoundLength.Add(Main.b_byteArrayToIntRev(SoundLength));
                    }
                    else
                    {
                        byte[] Zero = new byte[4];
                        TONESectionData_Volume.Add(0f);
                        TONESectionData_BitRate.Add(0);
                        TONESectionData_SoundLength.Add(0);
                    };
                }
                else 
                {
                    byte[] Zero_byte = new byte[4];
                    PACKSectionList_Pos.Add(0);
                    PACKSectionList_Size.Add(0);
                    TONESectionData_Volume.Add(0f);
                    TONESectionData_BitRate.Add(0);
                    TONESectionData_SoundLength.Add(0);
                    //PACKSectionDataList.Add(new byte[0]);
                }
            }

            /*for (int x2 = 0; x2 < TONESectionList.Count; x2++)
            {
                if (Randomizer[x2]==1)
                {
                    MessageBox.Show(x2.ToString("X2"));
                    byte[] Count = new byte[4]
                    {
                        TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 11],
                        TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 12],
                        TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 13],
                        TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 14]
                    };
                    TONESectionDataRandomize_Count.Add(Main.b_ReadInt(Count, 0));
                    if (TONESectionDataRandomize_Count[x2]==2)
                    {
                        byte[] Sound_1 = new byte[4]
                        {
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 27],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 28],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 29],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 30]

                        };
                        byte[] Sound_2 = new byte[4]
                        {
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 43],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 44],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 45],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 46]

                        };
                        TONESectionDataRandomize_Sound1.Add(Sound_1);
                        TONESectionDataRandomize_Sound2.Add(Sound_2);
                        TONESectionDataRandomize_Sound3.Add(new byte[4]);
                        TONESectionDataRandomize_Sound4.Add(new byte[4]);
                    }
                    if (TONESectionDataRandomize_Count[x2] == 3)
                    {
                        byte[] Sound_1 = new byte[4]
                        {
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 27],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 28],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 29],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 30]

                        };
                        byte[] Sound_2 = new byte[4]
                        {
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 43],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 44],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 45],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 46]

                        };
                        byte[] Sound_3 = new byte[4]
                        {
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 59],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 60],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 61],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 62]

                        };
                        TONESectionDataRandomize_Sound1.Add(Sound_1);
                        TONESectionDataRandomize_Sound2.Add(Sound_2);
                        TONESectionDataRandomize_Sound3.Add(Sound_3);
                        TONESectionDataRandomize_Sound4.Add(new byte[4]);
                    }
                    if (TONESectionDataRandomize_Count[x2] == 4)
                    {
                        byte[] Sound_1 = new byte[4]
                        {
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 27],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 28],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 29],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 30]

                        };
                        byte[] Sound_2 = new byte[4]
                        {
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 43],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 44],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 45],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 46]

                        };
                        byte[] Sound_3 = new byte[4]
                        {
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 59],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 60],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 61],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 62]

                        };
                        byte[] Sound_4 = new byte[4]
                        {
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 75],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 76],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 77],
                            TONESectionDataList[x2][TONESectionStartData_Pos[x2] + 78]

                        };
                        TONESectionDataRandomize_Sound1.Add(Sound_1);
                        TONESectionDataRandomize_Sound2.Add(Sound_2);
                        TONESectionDataRandomize_Sound3.Add(Sound_3);
                        TONESectionDataRandomize_Sound4.Add(Sound_4);
                    }
                }
                else
                {
                    TONESectionDataRandomize_Count.Add(0);
                    TONESectionDataRandomize_Sound1.Add(new byte[4]);
                    TONESectionDataRandomize_Sound2.Add(new byte[4]);
                    TONESectionDataRandomize_Sound3.Add(new byte[4]);
                    TONESectionDataRandomize_Sound4.Add(new byte[4]);
                }
            } 
            MessageBox.Show(BitConverter.ToString(TONESectionDataRandomize_Sound1[0]));*/
            for (int x2 = 0; x2<EntryCount; x2++)
            {
                if (PACKSectionList_Size[x2] > 4)
                {
                    byte[] PACKSection = Main.b_ReadByteArray(fileBytes, PACK_PosList[1] + 8 + PACKSectionList_Pos[x2], PACKSectionList_Size[x2]);
                    PACKSectionDataList.Add(PACKSection);
                }
                else
                {
                    byte[] PACKSection = new byte[0];
                    PACKSectionDataList.Add(PACKSection);
                };

                if (PACKSectionList_Size[x2] >= 8)
                {
                    string Format = Main.b_ReadString2(fileBytes, PACK_PosList[1] + 8 + PACKSectionList_Pos[x2], 4);


                    //MessageBox.Show((PACK_PosList[1] + 8 + PACKSectionList_Pos[x2]).ToString("X2"));
                    if (Format == "RIFF")
                    {
                        Format = "WAV";
                    }
                    PACKFormat.Add(Format);
                }
                else
                {
                    PACKFormat.Add("No sound");
                };
            }
            for (int x2 = 0; x2 < PACKFormat.Count; x2++)
            {
                if (PACKFormat[x2]=="IDSP")
                {
                    if(fileBytes[PACK_PosList[1] + 8 + 11 + PACKSectionList_Pos[x2]]==1)
                    {
                        string MonoStereo = "mono";
                        MonoStereoList.Add(MonoStereo);
                    }
                    else if (fileBytes[PACK_PosList[1] + 8 +11 + PACKSectionList_Pos[x2]] == 2)
                    {
                        string MonoStereo = "stereo";
                        MonoStereoList.Add(MonoStereo);
                    };
                }
                else if (PACKFormat[x2] == "WAV")
                {
                    if (fileBytes[PACK_PosList[1] + 8 + 22 + PACKSectionList_Pos[x2]] == 1)
                    {
                        string MonoStereo = "mono";
                        MonoStereoList.Add(MonoStereo);
                    }
                    else if (fileBytes[PACK_PosList[1] + 8 + 22 + PACKSectionList_Pos[x2]] == 2)
                    {
                        string MonoStereo = "stereo";
                        MonoStereoList.Add(MonoStereo);
                    };
                }
                else if (PACKFormat[x2] == "BNSF")
                {
                    if (fileBytes[PACK_PosList[1] + 8 + 23 + PACKSectionList_Pos[x2]] == 1)
                    {
                        string MonoStereo = "mono";
                        MonoStereoList.Add(MonoStereo);
                    }
                    else if (fileBytes[PACK_PosList[1] + 8 + 23 + PACKSectionList_Pos[x2]] == 2)
                    {
                        string MonoStereo = "stereo";
                        MonoStereoList.Add(MonoStereo);
                    };
                }
                else
                {
                    MonoStereoList.Add(" ");
                }
            }
            for (int x2 = 0; x2 < PACKFormat.Count; x2++)
            {
                if (PACKFormat[x2] == "IDSP")
                {
                    if (fileBytes[PACK_PosList[1] + 8 + 11 + PACKSectionList_Pos[x2]] == 1)
                    {
                        string MonoStereo = "mono";
                        MonoStereoList.Add(MonoStereo);
                    }
                    else if (fileBytes[PACK_PosList[1] + 8 + 11 + PACKSectionList_Pos[x2]] == 2)
                    {
                        string MonoStereo = "stereo";
                        MonoStereoList.Add(MonoStereo);
                    };
                }
                else if (PACKFormat[x2] == "WAV")
                {
                    if (fileBytes[PACK_PosList[1] + 8 + 22 + PACKSectionList_Pos[x2]] == 1)
                    {
                        string MonoStereo = "mono";
                        MonoStereoList.Add(MonoStereo);
                    }
                    else if (fileBytes[PACK_PosList[1] + 8 + 22 + PACKSectionList_Pos[x2]] == 2)
                    {
                        string MonoStereo = "stereo";
                        MonoStereoList.Add(MonoStereo);
                    };
                }
                else if (PACKFormat[x2] == "BNSF")
                {
                    if (fileBytes[PACK_PosList[1] + 8 + 23 + PACKSectionList_Pos[x2]] == 1)
                    {
                        string MonoStereo = "mono";
                        MonoStereoList.Add(MonoStereo);
                    }
                    else if (fileBytes[PACK_PosList[1] + 8 + 23 + PACKSectionList_Pos[x2]] == 2)
                    {
                        string MonoStereo = "stereo";
                        MonoStereoList.Add(MonoStereo);
                    };
                }
                else
                {
                    MonoStereoList.Add(" ");
                }
            }
            for (int x2 = 0; x2 < PACKFormat.Count; x2++)
            {
                if (PACKFormat[x2] == "IDSP")
                {
                    if (fileBytes[PACK_PosList[1] + 8 + 77 + PACKSectionList_Pos[x2]] == 1)
                    {
                        string Loop = "looped";
                        SoundLoopList.Add(Loop);
                    }
                    else if (fileBytes[PACK_PosList[1] + 8 + 77 + PACKSectionList_Pos[x2]] == 0)
                    {
                        string Loop = " ";
                        SoundLoopList.Add(Loop);
                    };
                }
                else if (PACKFormat[x2] == "BNSF")
                {
                    if (Main.b_ReadString2(fileBytes, PACK_PosList[1] + 8 + 40 + PACKSectionList_Pos[x2], 4) == "loop")
                    {
                        string Loop = "looped";
                        SoundLoopList.Add(Loop);
                    }
                    else
                    {
                        SoundLoopList.Add(" ");
                    }
                }
                else
                {
                    SoundLoopList.Add(" ");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count)
            {
                Format.Text = PACKFormat[x];
                Quality.Text = TONESectionData_BitRate[x].ToString() + "hz" + " " + MonoStereoList[x] + " " + SoundLoopList[x];
                Volume.Value = (decimal)TONESectionData_Volume[x];
                PositionOfSection.Text = "0x" + TONESectionDataList_Pos[x].ToString("X2");
                PositionOfSound.Text = "0x" + (PACK_PosList[1] + 8 + PACKSectionList_Pos[x]).ToString("X2");
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
                s.Filter = "XFBIN files|*.xfbin|NUS3BANK files|*.NUS3BANK";
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
            byte[] JUNK_SectionSize = Main.b_ReadByteArray(fileBytes, JUNK_PosList[1] + 4, 4);
            byte[] JUNK_Section = Main.b_ReadByteArray(fileBytes, JUNK_PosList[1] + 8, Main.b_byteArrayToInt(JUNK_SectionSize));
            byte[] fileBytes36 = new byte[0];
            int NUS3BANK_SIZE = 0;
            if (FileFormat== "XFBIN")
            {  
                fileBytes36 = Main.b_AddBytes(fileBytes36, header);
            }
            fileBytes36 = Main.b_AddBytes(fileBytes36, RestOfheader);
            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(JUNK_Section.Length), JUNK_PosList[0] + 4);
            int ToneSectionPointer = 4+(8*EntryCount);
            int ToneDataSectionPointer = ToneSectionPointer;
            for (int x2 = 0; x2 < EntryCount; x2++)
            {
                
                fileBytes36 = Main.b_AddBytes(fileBytes36, BitConverter.GetBytes(ToneSectionPointer));
                fileBytes36 = Main.b_AddBytes(fileBytes36, BitConverter.GetBytes(TONESectionList_Size[x2]));
                ToneSectionPointer = ToneSectionPointer + TONESectionList_Size[x2];
                //ToneDataSectionPointer = ToneDataSectionPointer + TONESectionList_Size[x2];
            }
            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(ToneSectionPointer), TONE_PosList[0] + 4);
            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(ToneSectionPointer), TONE_PosList[1] + 4);
            fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4]);
            int PACKPositions = 0;
            int ToneSectionSize = 0;
            for (int x2 = 0; x2 < EntryCount; x2++)
            {
                fileBytes36 = Main.b_AddBytes(fileBytes36, TONESectionDataList[x2]);
                //int FirstSoundPos = ToneSectionPointer;

                if (TONESectionList_Size[x2] > 0x9c && PACKSectionList_Size[x2] > 0)
                {
                    //MessageBox.Show((ToneSectionSize + header.Length + RestOfheader.Length + ToneDataSectionPointer + TONESectionStartData_Pos[x2] + 7).ToString("X2"));
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(PACKPositions), ToneSectionSize + header.Length + RestOfheader.Length + ToneDataSectionPointer + TONESectionStartData_Pos[x2] + 7);
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(PACKSectionDataList[x2].Length), ToneSectionSize + header.Length + RestOfheader.Length + ToneDataSectionPointer + TONESectionStartData_Pos[x2] + 11);
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TONESectionData_Volume[x2]), ToneSectionSize + header.Length + RestOfheader.Length + ToneDataSectionPointer + TONESectionStartData_Pos[x2] + 15);
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TONESectionData_BitRate[x2]), ToneSectionSize + header.Length + RestOfheader.Length + ToneDataSectionPointer + TONESectionStartData_Pos[x2] + 0x7B);
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TONESectionData_SoundLength[x2]), ToneSectionSize + header.Length + RestOfheader.Length + ToneDataSectionPointer + TONESectionStartData_Pos[x2] + 0x83);

                }
                ToneSectionSize = ToneSectionSize + TONESectionList_Size[x2];
                PACKPositions = PACKPositions + PACKSectionDataList[x2].Length;
            }
            fileBytes36 = Main.b_AddBytes(fileBytes36, BitConverter.GetBytes(JUNK_Section.Length));
            fileBytes36 = Main.b_AddBytes(fileBytes36, JUNK_Section);
            fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x50, 0x41, 0x43, 0x4B });
            int PACKSectionSize = 0;
            for (int x2 = 0; x2 < EntryCount; x2++)
            {
                PACKSectionSize = PACKSectionSize+ PACKSectionDataList[x2].Length;
            }
            fileBytes36 = Main.b_AddBytes(fileBytes36, BitConverter.GetBytes(PACKSectionSize));
            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(PACKSectionSize), PACK_PosList[0]+4);
            for (int x2 = 0; x2 < EntryCount; x2++)
            {
                fileBytes36 = Main.b_AddBytes(fileBytes36, PACKSectionDataList[x2]);
            }
            if (FileFormat=="XFBIN")
            {
                NUS3BANK_SIZE = fileBytes36.Length - header.Length - 8;
            }
            else if (FileFormat=="NUS3BANK")
            {
                NUS3BANK_SIZE = fileBytes36.Length - 8;
            };
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
            
            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(NUS3BANK_SIZE), NUS3_Pos + 4);
            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, FileID_replacer, GRP_PosList[1] - 4);

            if (FileFormat == "XFBIN")
            {
                fileBytes36 = Main.b_AddBytes(fileBytes36, finalBytes);
                byte[] XFBIN_SIZE1 = new byte[4]
                {
                    BitConverter.GetBytes(NUS3BANK_SIZE+8)[3],
                    BitConverter.GetBytes(NUS3BANK_SIZE+8)[2],
                    BitConverter.GetBytes(NUS3BANK_SIZE+8)[1],
                    BitConverter.GetBytes(NUS3BANK_SIZE+8)[0]
                };
                byte[] XFBIN_SIZE2 = new byte[4]
                {
                    BitConverter.GetBytes(NUS3BANK_SIZE+12)[3],
                    BitConverter.GetBytes(NUS3BANK_SIZE+12)[2],
                    BitConverter.GetBytes(NUS3BANK_SIZE+12)[1],
                    BitConverter.GetBytes(NUS3BANK_SIZE+12)[0]
                };
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, XFBIN_SIZE1, NUS3_Pos - 4);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, XFBIN_SIZE2, NUS3_Pos - 16);
            }
            return fileBytes36;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count)
            {
                TONESectionData_Volume[x] = (float)Volume.Value;
                MessageBox.Show("Volume saved");
            }
        }

        private void FileID_value01_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FileID_replacer = new byte[4]
            {
                (byte)FileID_value01.Value,
                (byte)FileID_value02.Value,
                0x00,
                0x00
            };

            fileBytes = Main.b_ReplaceBytes(fileBytes, FileID_replacer, GRP_PosList[1] - 4);
            MessageBox.Show("File ID saved");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count)
            {
                SaveFileDialog saveFile1 = new SaveFileDialog();
                saveFile1.DefaultExt = PACKFormat[x];
                saveFile1.Filter = PACKFormat[x] + "|*" + PACKFormat[x];
                saveFile1.FileName = TONESectionNameList[x];

                if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                   saveFile1.FileName.Length > 0)
                {
                    File.WriteAllBytes(saveFile1.FileName, PACKSectionDataList[x]);
                    MessageBox.Show("File saved " + saveFile1.FileName);
                };
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowDialog();
            for (int x=0; x < TONESectionList.Count;x++)
            {

                if (PACKFormat[x]!="No sound" && PACKFormat[x]!="Unknown" && PACKSectionDataList[x].Length>4)
                {
                    string name = TONESectionNameList[x];
                    string format = "unknown";
                    if (PACKFormat[x]=="BNSF")
                    {
                        format = "bnsf";
                    }
                    else if (PACKFormat[x]=="IDSP")
                    {
                        format = "idsp";
                    }
                    else if (PACKFormat[x]=="WAV")
                    {
                        format = "wav";
                    }
                    else
                    {
                        format = "unknown";
                    }
                    File.WriteAllBytes(FBD.SelectedPath + "\\" + x.ToString()+ "-" + name + "." + format, PACKSectionDataList[x]);
                };
            }
            MessageBox.Show("Files saved to " + FBD.SelectedPath);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                ReplaceSound();
            }
            else
            {
                MessageBox.Show("No file loaded...");
            }
        }
        private void ReplaceSound()
        {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count)
            {
                OpenFileDialog ReplaceSound = new OpenFileDialog();
                ReplaceSound.ShowDialog();
                if (!(ReplaceSound.FileName != "") || !File.Exists(ReplaceSound.FileName))
                {
                    return;
                }
                string ReplaceSoundPath = ReplaceSound.FileName;
                byte[] ReplaceSoundFile = File.ReadAllBytes(ReplaceSoundPath);

            
                PACKSectionDataList[x] = ReplaceSoundFile;
                PACKSectionList_Size[x] = ReplaceSoundFile.Length;
                if (Main.b_ReadString2(ReplaceSoundFile,0,4)=="BNSF")
                {
                    PACKFormat[x] = "BNSF";
                    TONESectionData_BitRate[x] = Main.b_byteArrayToIntRev(Main.b_ReadByteArray(ReplaceSoundFile, 24, 4));
                    TONESectionData_SoundLength[x] = Main.b_byteArrayToIntRev(Main.b_ReadByteArray(ReplaceSoundFile, 28, 4));
                    MessageBox.Show("Sound replaced");
                    if (ReplaceSoundFile[23] == 1)
                    {
                        MonoStereoList[x] = "mono";
                    }
                    else if (fileBytes[23] == 2)
                    {
                        MonoStereoList[x] = "stereo";
                    }
                    else
                    {
                        MonoStereoList[x] = " ";
                    };
                    if (Main.b_ReadString2(ReplaceSoundFile, 40, 4) == "loop")
                    {
                        SoundLoopList[x] = "looped";
                    }
                    else
                    {
                        SoundLoopList[x] = " ";
                    }
                }
                else if (Main.b_ReadString2(ReplaceSoundFile, 0, 4) == "RIFF")
                {
                    PACKFormat[x] = "WAV";
                    TONESectionData_BitRate[x] = Main.b_byteArrayToInt(Main.b_ReadByteArray(ReplaceSoundFile, 24, 4));
                    int PosOfPCM = Main.b_FindBytes(ReplaceSoundFile, Encoding.ASCII.GetBytes("data"));
                    TONESectionData_SoundLength[x] = Main.b_byteArrayToInt(Main.b_ReadByteArray(ReplaceSoundFile, PosOfPCM+4, 4)) / ReplaceSoundFile[32];
                    MessageBox.Show("Sound replaced");
                    if (ReplaceSoundFile[22] == 1)
                    {
                        MonoStereoList[x] = "mono";
                    }
                    else if (fileBytes[22] == 2)
                    {
                        MonoStereoList[x] = "stereo";
                    }
                    else
                    {
                        MonoStereoList[x] = " ";
                    };
                    SoundLoopList[x] = " ";

                }
                else if (Main.b_ReadString2(ReplaceSoundFile, 0, 4) == "IDSP")
                {
                    PACKFormat[x] = "IDSP";
                    TONESectionData_BitRate[x] = Main.b_byteArrayToIntRev(Main.b_ReadByteArray(ReplaceSoundFile, 12, 4));
                    TONESectionData_SoundLength[x] = Main.b_byteArrayToIntRev(Main.b_ReadByteArray(ReplaceSoundFile, 16, 4));
                    MessageBox.Show("Sound replaced");
                    if (ReplaceSoundFile[11] == 1)
                    {
                        MonoStereoList[x] = "mono";
                    }
                    else if (ReplaceSoundFile[11] == 2)
                    {
                        MonoStereoList[x] = "stereo";
                    }
                    else
                    {
                        MonoStereoList[x] = " ";
                    };

                    if (ReplaceSoundFile[77] == 1)
                    {
                        SoundLoopList[x] = "looped";
                    }
                    else if (ReplaceSoundFile[77] == 0)
                    {
                        SoundLoopList[x] = " ";
                    }
                    else
                    {
                        SoundLoopList[x] = " ";
                    }
                }
                else
                {
                    MessageBox.Show("This format not supported.\nTry use WAV, IDSP or BNSF or you have to fix all values manually");
                    MonoStereoList[x]=" ";
                    TONESectionData_BitRate[x] = 0;
                    TONESectionData_SoundLength[x] = 0;
                    PACKFormat[x] = "Unknown format";
                }
            }
            else
            {
                MessageBox.Show("No sound selected");
            };
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count)
            {
                OpenFileDialog ImportSound = new OpenFileDialog();
                {
                    ImportSound.DefaultExt = ".wav";
                    ImportSound.Filter = "WAV files|*.wav";
                }
                ImportSound.ShowDialog();
                if (!(ImportSound.FileName != "") || !File.Exists(ImportSound.FileName))
                {
                    return;
                }
                string ImportSoundPath = ImportSound.FileName;
                byte[] ImportSoundFile = File.ReadAllBytes(ImportSoundPath);
                byte[] CleanedImportedSoundFile = new byte[0];
                byte[] ConvertedSoundFile = new byte[0];
                int PosOfPCM = 0;
                PosOfPCM = Main.b_FindBytes(ImportSoundFile, Encoding.ASCII.GetBytes("data"));
                if (PosOfPCM == -1)
                {
                    MessageBox.Show("Wrong format file");
                }
                else
                {
                    CleanedImportedSoundFile = Main.b_AddBytes(CleanedImportedSoundFile, ImportSoundFile, 0, PosOfPCM + 8, ImportSoundFile.Length - PosOfPCM - 8);
                    //System.Diagnostics.Process.Start("cmd.exe");
                    //SendKeys.SendWait("encode ImportSound.FileName ConvertedSoundFile 48000 14000" + "{Enter}");

                    Process p = new Process();
                    // Redirect the output stream of the child process.
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = "encode.exe";
                    string path = Directory.GetCurrentDirectory();
                    if (!Directory.Exists(path + "\\temp"))
                    {
                        Directory.CreateDirectory(path + "\\temp");
                    }
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
                    int ImportedSoundSoundLength = Main.b_byteArrayToInt(Main.b_ReadByteArray(ImportSoundFile, PosOfPCM+4, 4)) / ImportSoundFile[32];

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
                    //MessageBox.Show(ImportedSoundSoundLength.ToString("X2"));
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
                    //File.WriteAllBytes(path + "\\temp\\new_file.bnsf", BNSFSound);
                    Directory.Delete(path + "\\temp", true);
                    PACKSectionDataList[x] = BNSFSound;
                    PACKFormat[x] = "BNSF";
                    PACKSectionList_Size[x] = PACKSectionDataList[x].Length;
                    TONESectionData_BitRate[x] = Main.b_byteArrayToIntRev(Main.b_ReadByteArray(BNSFSound, 24, 4));
                    TONESectionData_SoundLength[x] = Main.b_byteArrayToIntRev(Main.b_ReadByteArray(BNSFSound, 28, 4));
                    MessageBox.Show("Sound was imported successfully to BNSF format");
                }

            }
        }

        private void Tool_nus3bankEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
