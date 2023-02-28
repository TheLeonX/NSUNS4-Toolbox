using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSUNS4_Character_Manager.Tools {
    public partial class Tool_AnmStreamConverter : Form {
        public Tool_AnmStreamConverter() {
            InitializeComponent();
        }
        public List<string> FileList = new List<string>();
        private void listBox1_DragDrop(object sender, DragEventArgs e) {
            
        }
        public List<List<int>> ClumpIndex_List = new List<List<int>>();
        public List<List<int>> EntryClumpIndex_List = new List<List<int>>();
        public List<List<int>> EntryType_List = new List<List<int>>();
        public List<List<int>> WeirdValue_List = new List<List<int>>();
        public List<List<float>> PosX_List = new List<List<float>>();
        public List<List<float>> PosY_List = new List<List<float>>();
        public List<List<float>> PosZ_List = new List<List<float>>();
        public List<List<float>> RotX_List = new List<List<float>>();
        public List<List<float>> RotY_List = new List<List<float>>();
        public List<List<float>> RotZ_List = new List<List<float>>();
        public List<List<float>> RotW_List = new List<List<float>>();
        public List<List<float>> ScaleX_List = new List<List<float>>();
        public List<List<float>> ScaleY_List = new List<List<float>>();
        public List<List<float>> ScaleZ_List = new List<List<float>>();
        public List<List<float>> Toggle_List = new List<List<float>>();

        public List<List<float>> CameraFOV_List = new List<List<float>>();

        public List<List<float>> ColorR_List = new List<List<float>>();
        public List<List<float>> ColorG_List = new List<List<float>>();
        public List<List<float>> ColorB_List = new List<List<float>>();
        public List<List<float>> LightStrength_List = new List<List<float>>();


        public List<List<float>> LightRadius_List = new List<List<float>>();
        public List<List<float>> LightVisibility_List = new List<List<float>>();

        public byte[] ConvertedAnmHeader = new byte[0];
        public byte[] ConvertedAnm = new byte[0];

        public List<List<float>> MaterialFloat0anim_List = new List<List<float>>();
        public List<List<float>> MaterialFloat1anim_List = new List<List<float>>();
        public List<List<float>> MaterialFloat2_List = new List<List<float>>();
        public List<List<float>> MaterialFloat3_List = new List<List<float>>();
        public List<List<float>> MaterialFloat4_List = new List<List<float>>();
        public List<List<float>> MaterialFloat5_List = new List<List<float>>();
        public List<List<float>> MaterialFloat6_List = new List<List<float>>();
        public List<List<float>> MaterialFloat7_List = new List<List<float>>();
        public List<List<float>> MaterialFloat8anim_List = new List<List<float>>();
        public List<List<float>> MaterialFloat9anim_List = new List<List<float>>();
        public List<List<float>> MaterialFloat10_List = new List<List<float>>();
        public List<List<float>> MaterialFloat11_List = new List<List<float>>();
        public List<List<float>> MaterialFloat12_List = new List<List<float>>();
        public List<List<float>> MaterialFloat13_List = new List<List<float>>();
        public List<List<float>> MaterialFloat14_List = new List<List<float>>();
        public List<List<float>> MaterialFloat15_List = new List<List<float>>();
        public List<List<float>> MaterialFloat16_List = new List<List<float>>();
        public List<List<float>> MaterialFloat17_List = new List<List<float>>();

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            OpenFileDialog g = new OpenFileDialog();
            g.ShowDialog();
            if (File.Exists(g.FileName)) {
                byte[] AnmHeader = new byte[0];
                List<int> ClumpIdList = new List<int>();
                AnmHeader = File.ReadAllBytes(g.FileName);
                int ClumpCount = Main.b_ReadIntRevFromTwoBytes(AnmHeader, 0x0C);
                int OtherEntryCount = Main.b_ReadIntRevFromTwoBytes(AnmHeader, 0x0E);
                int BoneParentCount = Main.b_ReadIntRevFromTwoBytes(AnmHeader, 0x12);
                ConvertedAnmHeader = Main.b_ReadByteArray(AnmHeader, 0, 0x14);
                int ptr = 0x14;
                for (int c = 0; c<ClumpCount; c++) {
                    byte[] AnmHeaderSection = new byte[0];
                    AnmHeaderSection = Main.b_ReadByteArray(AnmHeader,ptr, (Main.b_ReadIntRevFromTwoBytes(AnmHeader, ptr + 0x04) * 4) + (Main.b_ReadIntRevFromTwoBytes(AnmHeader, ptr + 0x06) * 4) + 0x08);
                    ConvertedAnmHeader = Main.b_AddBytes(ConvertedAnmHeader, AnmHeaderSection);
                    ptr += (Main.b_ReadIntRevFromTwoBytes(AnmHeader, ptr + 0x04) * 4) + (Main.b_ReadIntRevFromTwoBytes(AnmHeader, ptr + 0x06) * 8) + 0x08;
                }
                
                for (int c = 0; c < OtherEntryCount; c++) {
                    byte[] AnmHeaderSection = new byte[0];
                    if (comboBox1.SelectedIndex != 1) {
                        AnmHeaderSection = Main.b_ReadByteArray(AnmHeader, ptr, 4);
                        ConvertedAnmHeader = Main.b_AddBytes(ConvertedAnmHeader, AnmHeaderSection);
                    }
                    ptr += +0x04;
                }
                for (int c = 0; c < BoneParentCount; c++) {
                    byte[] AnmHeaderSection = new byte[0];
                    AnmHeaderSection = Main.b_ReadByteArray(AnmHeader, ptr, 8);
                    ClumpIdList.Add(Main.b_ReadIntRevFromTwoBytes(AnmHeader,ptr+0x04));
                    ConvertedAnmHeader = Main.b_AddBytes(ConvertedAnmHeader, AnmHeaderSection);
                    ptr += +0x08;
                }
                int boneCount = 0;
                //for (int c = 0; c < ClumpCount; c++) {
                //    if (!ClumpIdList.Contains(c)) {
                //        ConvertedAnmHeader = Main.b_AddBytes(ConvertedAnmHeader, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                //        byte[] Clump = BitConverter.GetBytes(c);
                //        byte[] revClump = new byte[2] {
                //            Clump[1],
                //            Clump[0]
                //        };
                //        ConvertedAnmHeader = Main.b_AddBytes(ConvertedAnmHeader, revClump);
                //        ConvertedAnmHeader = Main.b_AddBytes(ConvertedAnmHeader, new byte[2] { 0x00, 0x00 });
                //        boneCount++;
                //    }
                //}
                //BoneParentCount += boneCount;
                //byte[] byteBoneParentCount = BitConverter.GetBytes(BoneParentCount);
                //byte[] revbyteBoneParentCount = new byte[2] {
                //            byteBoneParentCount[1],
                //            byteBoneParentCount[0]
                //        };
                //ConvertedAnmHeader = Main.b_ReplaceBytes(ConvertedAnmHeader, revbyteBoneParentCount, 0x12);
                if (comboBox1.SelectedIndex == 1) {
                    ConvertedAnmHeader = Main.b_ReplaceBytes(ConvertedAnmHeader, new byte[2] { 0, 0 }, 0x0E);
                }
            }

            OpenFileDialog o = new OpenFileDialog();
            o.Multiselect = true;
            o.ShowDialog();
            FileList.Clear();
            string[] fileList = o.FileNames;
            for (int c = 0; c < fileList.Length; c++) {
                FileList.Add(fileList[c]);
            }
            ClumpIndex_List.Clear();
            EntryClumpIndex_List.Clear();
            EntryType_List.Clear();
            WeirdValue_List.Clear();
            PosX_List.Clear();
            PosY_List.Clear();
            PosZ_List.Clear();
            RotX_List.Clear();
            RotY_List.Clear();
            RotZ_List.Clear();
            RotW_List.Clear();
            ScaleX_List.Clear();
            ScaleY_List.Clear();
            ScaleZ_List.Clear();
            Toggle_List.Clear();
            CameraFOV_List.Clear();
            ColorR_List.Clear();
            ColorG_List.Clear();
            ColorB_List.Clear();
            LightStrength_List.Clear();
            LightRadius_List.Clear();
            LightVisibility_List.Clear();

            MaterialFloat0anim_List.Clear();
            MaterialFloat1anim_List.Clear();
            MaterialFloat2_List.Clear();
            MaterialFloat3_List.Clear();
            MaterialFloat4_List.Clear();
            MaterialFloat5_List.Clear();
            MaterialFloat6_List.Clear();
            MaterialFloat7_List.Clear();
            MaterialFloat8anim_List.Clear();
            MaterialFloat9anim_List.Clear();
            MaterialFloat10_List.Clear();
            MaterialFloat11_List.Clear();
            MaterialFloat12_List.Clear();
            MaterialFloat13_List.Clear();
            MaterialFloat14_List.Clear();
            MaterialFloat15_List.Clear();
            MaterialFloat16_List.Clear();
            MaterialFloat17_List.Clear();

            for (int c = 0; c< FileList.Count; c++) {
                byte[] EntryBytes = File.ReadAllBytes(FileList[c]);
                int EntryCount = Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x04);
                int ptr = 0;

                ClumpIndex_List.Add(new List<int>());
                EntryClumpIndex_List.Add(new List<int>());
                EntryType_List.Add(new List<int>());
                WeirdValue_List.Add(new List<int>());
                PosX_List.Add(new List<float>());
                PosY_List.Add(new List<float>());
                PosZ_List.Add(new List<float>());
                RotX_List.Add(new List<float>());
                RotY_List.Add(new List<float>());
                RotZ_List.Add(new List<float>());
                RotW_List.Add(new List<float>());
                ScaleX_List.Add(new List<float>());
                ScaleY_List.Add(new List<float>());
                ScaleZ_List.Add(new List<float>());
                Toggle_List.Add(new List<float>());
                CameraFOV_List.Add(new List<float>());
                ColorR_List.Add(new List<float>());
                ColorG_List.Add(new List<float>());
                ColorB_List.Add(new List<float>());
                LightStrength_List.Add(new List<float>());
                LightRadius_List.Add(new List<float>());
                LightVisibility_List.Add(new List<float>()); 
                MaterialFloat0anim_List.Add(new List<float>());
                MaterialFloat1anim_List.Add(new List<float>());
                MaterialFloat2_List.Add(new List<float>());
                MaterialFloat3_List.Add(new List<float>());
                MaterialFloat4_List.Add(new List<float>());
                MaterialFloat5_List.Add(new List<float>());
                MaterialFloat6_List.Add(new List<float>());
                MaterialFloat7_List.Add(new List<float>());
                MaterialFloat8anim_List.Add(new List<float>());
                MaterialFloat9anim_List.Add(new List<float>());
                MaterialFloat10_List.Add(new List<float>());
                MaterialFloat11_List.Add(new List<float>());
                MaterialFloat12_List.Add(new List<float>());
                MaterialFloat13_List.Add(new List<float>());
                MaterialFloat14_List.Add(new List<float>());
                MaterialFloat15_List.Add(new List<float>());
                MaterialFloat16_List.Add(new List<float>());
                MaterialFloat17_List.Add(new List<float>());
                for (int x = 0; x<EntryCount; x++) {
                    int type = Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr + 0x04);
                    int length = Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr + 0x06);
                    if (type == 1) {
                        ClumpIndex_List[c].Add(Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr));
                        EntryClumpIndex_List[c].Add(Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr + 0x02));
                        EntryType_List[c].Add(type);
                        WeirdValue_List[c].Add(Main.b_ReadIntRev(EntryBytes, 0x08 + ptr + 0x08));
                        PosX_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x0C));
                        PosY_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x10));
                        PosZ_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x14));
                        RotX_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x18));
                        RotY_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x1C));
                        RotZ_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x20));
                        RotW_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x24));
                        ScaleX_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x28));
                        ScaleY_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x2C));
                        ScaleZ_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x30));
                        Toggle_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x34));
                        CameraFOV_List[c].Add(0);
                        ColorR_List[c].Add(0);
                        ColorG_List[c].Add(0);
                        ColorB_List[c].Add(0);
                        LightStrength_List[c].Add(0);
                        LightVisibility_List[c].Add(0);
                        LightRadius_List[c].Add(0);

                        MaterialFloat0anim_List[c].Add(0);
                        MaterialFloat1anim_List[c].Add(0);
                        MaterialFloat2_List[c].Add(0);
                        MaterialFloat3_List[c].Add(0);
                        MaterialFloat4_List[c].Add(0);
                        MaterialFloat5_List[c].Add(0);
                        MaterialFloat6_List[c].Add(0);
                        MaterialFloat7_List[c].Add(0);
                        MaterialFloat8anim_List[c].Add(0);
                        MaterialFloat9anim_List[c].Add(0);
                        MaterialFloat10_List[c].Add(0);
                        MaterialFloat11_List[c].Add(0);
                        MaterialFloat12_List[c].Add(0);
                        MaterialFloat13_List[c].Add(0);
                        MaterialFloat14_List[c].Add(0);
                        MaterialFloat15_List[c].Add(0);
                        MaterialFloat16_List[c].Add(0);
                        MaterialFloat17_List[c].Add(0);
                    }
                    else if (type == 2) {
                        ClumpIndex_List[c].Add(Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr));
                        EntryClumpIndex_List[c].Add(Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr + 0x02));
                        EntryType_List[c].Add(type);
                        WeirdValue_List[c].Add(Main.b_ReadIntRev(EntryBytes, 0x08 + ptr + 0x08));
                        PosX_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x0C));
                        PosY_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x10));
                        PosZ_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x14));
                        RotX_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x18));
                        RotY_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x1C));
                        RotZ_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x20));
                        RotW_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x24));
                        CameraFOV_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x28));
                        ScaleX_List[c].Add(0);
                        ScaleY_List[c].Add(0);
                        ScaleZ_List[c].Add(0);
                        Toggle_List[c].Add(0);
                        ColorR_List[c].Add(0);
                        ColorG_List[c].Add(0);
                        ColorB_List[c].Add(0);
                        LightStrength_List[c].Add(0);
                        LightVisibility_List[c].Add(0);
                        LightRadius_List[c].Add(0);
                        MaterialFloat0anim_List[c].Add(0);
                        MaterialFloat1anim_List[c].Add(0);
                        MaterialFloat2_List[c].Add(0);
                        MaterialFloat3_List[c].Add(0);
                        MaterialFloat4_List[c].Add(0);
                        MaterialFloat5_List[c].Add(0);
                        MaterialFloat6_List[c].Add(0);
                        MaterialFloat7_List[c].Add(0);
                        MaterialFloat8anim_List[c].Add(0);
                        MaterialFloat9anim_List[c].Add(0);
                        MaterialFloat10_List[c].Add(0);
                        MaterialFloat11_List[c].Add(0);
                        MaterialFloat12_List[c].Add(0);
                        MaterialFloat13_List[c].Add(0);
                        MaterialFloat14_List[c].Add(0);
                        MaterialFloat15_List[c].Add(0);
                        MaterialFloat16_List[c].Add(0);
                        MaterialFloat17_List[c].Add(0);
                    }
                    if (type == 4) {
                        ClumpIndex_List[c].Add(Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr));
                        EntryClumpIndex_List[c].Add(Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr + 0x02));
                        EntryType_List[c].Add(type);
                        WeirdValue_List[c].Add(Main.b_ReadIntRev(EntryBytes, 0x08 + ptr + 0x08));
                        PosX_List[c].Add(0);
                        PosY_List[c].Add(0);
                        PosZ_List[c].Add(0);
                        RotX_List[c].Add(0);
                        RotY_List[c].Add(0);
                        RotZ_List[c].Add(0);
                        RotW_List[c].Add(0);
                        ScaleX_List[c].Add(0);
                        ScaleY_List[c].Add(0);
                        ScaleZ_List[c].Add(0);
                        Toggle_List[c].Add(1);
                        CameraFOV_List[c].Add(0);
                        ColorR_List[c].Add(0);
                        ColorG_List[c].Add(0);
                        ColorB_List[c].Add(0);
                        LightStrength_List[c].Add(0);
                        LightVisibility_List[c].Add(0);
                        LightRadius_List[c].Add(0);

                        MaterialFloat0anim_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x0C));
                        MaterialFloat1anim_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x10));
                        MaterialFloat2_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x14));
                        MaterialFloat3_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x18));
                        MaterialFloat4_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x1c));
                        MaterialFloat5_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x20));
                        MaterialFloat6_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x24));
                        MaterialFloat7_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x28));
                        MaterialFloat8anim_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x2C));
                        MaterialFloat9anim_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x30));
                        MaterialFloat10_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x34));
                        MaterialFloat11_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x38));
                        MaterialFloat12_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x3C));
                        MaterialFloat13_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x40));
                        MaterialFloat14_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x44));
                        MaterialFloat15_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x48));
                        MaterialFloat16_List[c].Add((float)0);
                        MaterialFloat17_List[c].Add((float)1);
                    } else if (type == 5) {
                        ClumpIndex_List[c].Add(Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr));
                        EntryClumpIndex_List[c].Add(Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr + 0x02));
                        EntryType_List[c].Add(type);
                        WeirdValue_List[c].Add(Main.b_ReadIntRev(EntryBytes, 0x08 + ptr + 0x08));
                        PosX_List[c].Add(0);
                        PosY_List[c].Add(0);
                        PosZ_List[c].Add(0);
                        RotX_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x1C));
                        RotY_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x20));
                        RotZ_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x24));
                        RotW_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x28));
                        CameraFOV_List[c].Add(0);
                        ScaleX_List[c].Add(0);
                        ScaleY_List[c].Add(0);
                        ScaleZ_List[c].Add(0);
                        Toggle_List[c].Add(0);
                        ColorR_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x0C));
                        ColorG_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x10));
                        ColorB_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x14));
                        LightStrength_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x18));
                        LightVisibility_List[c].Add(0);
                        LightRadius_List[c].Add(0);
                        MaterialFloat0anim_List[c].Add(0);
                        MaterialFloat1anim_List[c].Add(0);
                        MaterialFloat2_List[c].Add(0);
                        MaterialFloat3_List[c].Add(0);
                        MaterialFloat4_List[c].Add(0);
                        MaterialFloat5_List[c].Add(0);
                        MaterialFloat6_List[c].Add(0);
                        MaterialFloat7_List[c].Add(0);
                        MaterialFloat8anim_List[c].Add(0);
                        MaterialFloat9anim_List[c].Add(0);
                        MaterialFloat10_List[c].Add(0);
                        MaterialFloat11_List[c].Add(0);
                        MaterialFloat12_List[c].Add(0);
                        MaterialFloat13_List[c].Add(0);
                        MaterialFloat14_List[c].Add(0);
                        MaterialFloat15_List[c].Add(0);
                        MaterialFloat16_List[c].Add(0);
                        MaterialFloat17_List[c].Add(0);
                    } 
                    else if (type == 6) {
                        ClumpIndex_List[c].Add(Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr));
                        EntryClumpIndex_List[c].Add(Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr + 0x02));
                        EntryType_List[c].Add(type);
                        WeirdValue_List[c].Add(Main.b_ReadIntRev(EntryBytes, 0x08 + ptr + 0x08));
                        ColorR_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x0C));
                        ColorG_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x10));
                        ColorB_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x14));
                        LightStrength_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x24));
                        PosX_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x18));
                        PosY_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x1C));
                        PosZ_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x20));
                        LightVisibility_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x28));
                        LightRadius_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x30));
                        RotX_List[c].Add(0);
                        RotY_List[c].Add(0);
                        RotZ_List[c].Add(0);
                        RotW_List[c].Add(0);
                        ScaleX_List[c].Add(0);
                        ScaleY_List[c].Add(0);
                        ScaleZ_List[c].Add(0);
                        CameraFOV_List[c].Add(0);
                        Toggle_List[c].Add(0);
                        MaterialFloat0anim_List[c].Add(0);
                        MaterialFloat1anim_List[c].Add(0);
                        MaterialFloat2_List[c].Add(0);
                        MaterialFloat3_List[c].Add(0);
                        MaterialFloat4_List[c].Add(0);
                        MaterialFloat5_List[c].Add(0);
                        MaterialFloat6_List[c].Add(0);
                        MaterialFloat7_List[c].Add(0);
                        MaterialFloat8anim_List[c].Add(0);
                        MaterialFloat9anim_List[c].Add(0);
                        MaterialFloat10_List[c].Add(0);
                        MaterialFloat11_List[c].Add(0);
                        MaterialFloat12_List[c].Add(0);
                        MaterialFloat13_List[c].Add(0);
                        MaterialFloat14_List[c].Add(0);
                        MaterialFloat15_List[c].Add(0);
                        MaterialFloat16_List[c].Add(0);
                        MaterialFloat17_List[c].Add(0);
                    }
                    else if (type == 8) {
                        ClumpIndex_List[c].Add(Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr));
                        EntryClumpIndex_List[c].Add(Main.b_ReadIntRevFromTwoBytes(EntryBytes, 0x08 + ptr + 0x02));
                        EntryType_List[c].Add(type);
                        WeirdValue_List[c].Add(Main.b_ReadIntRev(EntryBytes, 0x08 + ptr + 0x08));
                        ColorR_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x0C));
                        ColorG_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x10));
                        ColorB_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x14));
                        LightStrength_List[c].Add(Main.b_ReadFloatRev(EntryBytes, 0x08 + ptr + 0x18));
                        LightVisibility_List[c].Add(0);
                        LightRadius_List[c].Add(0);
                        PosX_List[c].Add(0);
                        PosY_List[c].Add(0);
                        PosZ_List[c].Add(0);
                        RotX_List[c].Add(0);
                        RotY_List[c].Add(0);
                        RotZ_List[c].Add(0);
                        RotW_List[c].Add(0);
                        ScaleX_List[c].Add(0);
                        ScaleY_List[c].Add(0);
                        ScaleZ_List[c].Add(0);
                        CameraFOV_List[c].Add(0);
                        Toggle_List[c].Add(0);
                        MaterialFloat0anim_List[c].Add(0);
                        MaterialFloat1anim_List[c].Add(0);
                        MaterialFloat2_List[c].Add(0);
                        MaterialFloat3_List[c].Add(0);
                        MaterialFloat4_List[c].Add(0);
                        MaterialFloat5_List[c].Add(0);
                        MaterialFloat6_List[c].Add(0);
                        MaterialFloat7_List[c].Add(0);
                        MaterialFloat8anim_List[c].Add(0);
                        MaterialFloat9anim_List[c].Add(0);
                        MaterialFloat10_List[c].Add(0);
                        MaterialFloat11_List[c].Add(0);
                        MaterialFloat12_List[c].Add(0);
                        MaterialFloat13_List[c].Add(0);
                        MaterialFloat14_List[c].Add(0);
                        MaterialFloat15_List[c].Add(0);
                        MaterialFloat16_List[c].Add(0);
                        MaterialFloat17_List[c].Add(0);
                    }
                    ptr += length + 0x08;
                }

                
            }
            SaveFileDialog s = new SaveFileDialog();
            s.ShowDialog();
            if (s.FileName != "") {
                ConvertAnmStream(s.FileName);
                MessageBox.Show("Finished converting");
            }
        }
        public void ConvertAnmStream(string saveFilePath) {


            File.WriteAllBytes(saveFilePath+"_temp", new byte[0]);

            int fileCount = ClumpIndex_List.Count;
            byte[] byteFileCount = BitConverter.GetBytes(fileCount);
            byte[] revbyteFileCount = new byte[2]{
                byteFileCount[1],
                byteFileCount[0]
            };
            byte[] byteFileCount2 = BitConverter.GetBytes(1);
            byte[] revbyteFileCount2 = new byte[2]{
                byteFileCount2[1],
                byteFileCount2[0]
            };
            byte[] byteFileCount1 = BitConverter.GetBytes(fileCount + 1);
            byte[] revbyteFileCount1 = new byte[2]{
                byteFileCount1[1],
                byteFileCount1[0]
            };
            int EntryCount = ClumpIndex_List[0].Count;
            int EntryCount_new = 0;
            for (int y = 0; y < EntryCount; y++) {
                if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedIndex == 0 || (comboBox1.SelectedIndex == 1 && ClumpIndex_List[0][y] == numericUpDown1.Value) || (comboBox1.SelectedIndex == 2 && ClumpIndex_List[0][y] != numericUpDown1.Value)) {

                    EntryCount_new++;
                    byte[] fileBytes = new byte[0];
                    byte[] byteClumpIndex = BitConverter.GetBytes(ClumpIndex_List[0][y]);
                    byte[] revbyteClumpIndex = new byte[2]{
                        byteClumpIndex[1],
                        byteClumpIndex[0]
                    };
                    byte[] byteEntryClumpIndex = BitConverter.GetBytes(EntryClumpIndex_List[0][y]);
                    byte[] revbyteEntryClumpIndex = new byte[2]{
                        byteEntryClumpIndex[1],
                        byteEntryClumpIndex[0]
                    };
                    byte[] byteEntryType = BitConverter.GetBytes(EntryType_List[0][y]);
                    byte[] revbyteEntryType = new byte[2]{
                        byteEntryType[1],
                        byteEntryType[0]
                    };
                    fileBytes = Main.b_AddBytes(fileBytes, revbyteClumpIndex);
                    fileBytes = Main.b_AddBytes(fileBytes, revbyteEntryClumpIndex);
                    fileBytes = Main.b_AddBytes(fileBytes, revbyteEntryType);

                    byte[] Part1Value = new byte[0];
                    byte[] Part2Value = new byte[0];
                    byte[] Part3Value = new byte[0];
                    byte[] Part4Value = new byte[0];
                    byte[] Part5Value = new byte[0];
                    byte[] matPart1Value = new byte[0];
                    byte[] matPart2Value = new byte[0];
                    byte[] matPart3Value = new byte[0];
                    byte[] matPart4Value = new byte[0];
                    byte[] matPart5Value = new byte[0];
                    byte[] matPart6Value = new byte[0];
                    byte[] matPart7Value = new byte[0];
                    byte[] matPart8Value = new byte[0];
                    byte[] matPart9Value = new byte[0];
                    byte[] matPart10Value = new byte[0];
                    byte[] matPart11Value = new byte[0];
                    byte[] matPart12Value = new byte[0];
                    if (EntryType_List[0][y] == 1) {
                        //Only for bone entry
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x04 });

                        //Position with keyframe header
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x00, 0x00, 0x06 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount1);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        //Rotation Short Quaternion header
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x01, 0x00, 0x11 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        //Scale Short header
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x02, 0x00, 0x10 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        //Toggled header
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x03, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });



                        for (int x = 0; x < fileCount; x++) {
                            byte[] keyframe = BitConverter.GetBytes(x * 100);
                            byte[] PosX = BitConverter.GetBytes(PosX_List[x][y]);
                            byte[] PosY = BitConverter.GetBytes(PosY_List[x][y]);
                            byte[] PosZ = BitConverter.GetBytes(PosZ_List[x][y]);
                            byte[] revPos = new byte[0x10] {
                            keyframe[3],
                            keyframe[2],
                            keyframe[1],
                            keyframe[0],
                            PosX[3],
                            PosX[2],
                            PosX[1],
                            PosX[0],
                            PosY[3],
                            PosY[2],
                            PosY[1],
                            PosY[0],
                            PosZ[3],
                            PosZ[2],
                            PosZ[1],
                            PosZ[0],
                        };
                            Part1Value = Main.b_AddBytes(Part1Value, revPos);
                            byte[] RotX = BitConverter.GetBytes(Convert.ToInt32(RotX_List[x][y] * 0x4000));
                            byte[] RotY = BitConverter.GetBytes(Convert.ToInt32(RotY_List[x][y] * 0x4000));
                            byte[] RotZ = BitConverter.GetBytes(Convert.ToInt32(RotZ_List[x][y] * 0x4000));
                            byte[] RotW = BitConverter.GetBytes(Convert.ToInt32(RotW_List[x][y] * 0x4000));

                            byte[] revRot = new byte[8] {
                            RotX[1],
                            RotX[0],
                            RotY[1],
                            RotY[0],
                            RotZ[1],
                            RotZ[0],
                            RotW[1],
                            RotW[0]
                        };

                            Part2Value = Main.b_AddBytes(Part2Value, revRot);

                            byte[] byteScaleX = BitConverter.GetBytes(Convert.ToInt32(ScaleX_List[x][y] * 0x1000));
                            byte[] byteScaleY = BitConverter.GetBytes(Convert.ToInt32(ScaleY_List[x][y] * 0x1000));
                            byte[] byteScaleZ = BitConverter.GetBytes(Convert.ToInt32(ScaleZ_List[x][y] * 0x1000));
                            byte[] revScaleX = new byte[6]{
                            byteScaleX[1],
                            byteScaleX[0],
                            byteScaleY[1],
                            byteScaleY[0],
                            byteScaleZ[1],
                            byteScaleZ[0]
                        };

                            Part3Value = Main.b_AddBytes(Part3Value, revScaleX);

                            byte[] byteToggle = BitConverter.GetBytes(Toggle_List[x][y]);
                            byte[] revbyteToggle = new byte[4]{
                            byteToggle[3],
                            byteToggle[2],
                            byteToggle[1],
                            byteToggle[0]
                        };
                            Part4Value = Main.b_AddBytes(Part4Value, revbyteToggle);
                        }
                        byte[] keyframe2 = BitConverter.GetBytes(-1);
                        byte[] PosX2 = BitConverter.GetBytes(PosX_List[fileCount - 1][y]);
                        byte[] PosY2 = BitConverter.GetBytes(PosY_List[fileCount - 1][y]);
                        byte[] PosZ2 = BitConverter.GetBytes(PosZ_List[fileCount - 1][y]);
                        byte[] revPos2 = new byte[0x10] {
                            keyframe2[3],
                            keyframe2[2],
                            keyframe2[1],
                            keyframe2[0],
                            PosX2[3],
                            PosX2[2],
                            PosX2[1],
                            PosX2[0],
                            PosY2[3],
                            PosY2[2],
                            PosY2[1],
                            PosY2[0],
                            PosZ2[3],
                            PosZ2[2],
                            PosZ2[1],
                            PosZ2[0],
                        };
                        Part1Value = Main.b_AddBytes(Part1Value, revPos2);
                        if (fileCount % 2 != 0)
                            Part3Value = Main.b_AddBytes(Part3Value, new byte[] { 0x00, 0x00 });
                        //if (fileCount % 4 != 0)
                        //Part4Value = Main.b_AddBytes(Part4Value, new byte[] { 0x00, 0x00 });
                    } else if (EntryType_List[0][y] == 2) {
                        //Only for camera entry
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x03 });

                        //Position with keyframe header
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x00, 0x00, 0x06 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount1);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        //Rotation Short Quaternion header
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x01, 0x00, 0x11 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        //FOV 
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x02, 0x00, 0x0C });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount1);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        for (int x = 0; x < fileCount; x++) {
                            Part1Value = Main.b_AddBytes(Part1Value, BitConverter.GetBytes(x * 100), 1);
                            Part1Value = Main.b_AddBytes(Part1Value, BitConverter.GetBytes(PosX_List[x][y]), 1);
                            Part1Value = Main.b_AddBytes(Part1Value, BitConverter.GetBytes(PosY_List[x][y]), 1);
                            Part1Value = Main.b_AddBytes(Part1Value, BitConverter.GetBytes(PosZ_List[x][y]), 1);
                            byte[] byteRotX = BitConverter.GetBytes(Convert.ToInt32(Convert.ToInt32(RotX_List[x][y] * 0x4000)));
                            byte[] revbyteRotX = new byte[2]{
                            byteRotX[1],
                            byteRotX[0]
                        };
                            byte[] byteRotY = BitConverter.GetBytes(Convert.ToInt32(Convert.ToInt32(RotY_List[x][y] * 0x4000)));
                            byte[] revbyteRotY = new byte[2]{
                            byteRotY[1],
                            byteRotY[0]
                        };
                            byte[] byteRotZ = BitConverter.GetBytes(Convert.ToInt32(Convert.ToInt32(RotZ_List[x][y] * 0x4000)));
                            byte[] revbyteRotZ = new byte[2]{
                            byteRotZ[1],
                            byteRotZ[0]
                        };
                            byte[] byteRotW = BitConverter.GetBytes(Convert.ToInt32(Convert.ToInt32(RotW_List[x][y] * 0x4000)));
                            byte[] revbyteRotW = new byte[2]{
                            byteRotW[1],
                            byteRotW[0]
                        };
                            Part2Value = Main.b_AddBytes(Part2Value, revbyteRotX);
                            Part2Value = Main.b_AddBytes(Part2Value, revbyteRotY);
                            Part2Value = Main.b_AddBytes(Part2Value, revbyteRotZ);
                            Part2Value = Main.b_AddBytes(Part2Value, revbyteRotW);
                            Part3Value = Main.b_AddBytes(Part3Value, BitConverter.GetBytes(x * 100), 1);
                            Part3Value = Main.b_AddBytes(Part3Value, BitConverter.GetBytes(CameraFOV_List[x][y]), 1);
                        }
                        Part1Value = Main.b_AddBytes(Part1Value, BitConverter.GetBytes(-1), 1);
                        Part1Value = Main.b_AddBytes(Part1Value, BitConverter.GetBytes(PosX_List[fileCount - 1][y]), 1);
                        Part1Value = Main.b_AddBytes(Part1Value, BitConverter.GetBytes(PosY_List[fileCount - 1][y]), 1);
                        Part1Value = Main.b_AddBytes(Part1Value, BitConverter.GetBytes(PosZ_List[fileCount - 1][y]), 1);
                        Part3Value = Main.b_AddBytes(Part3Value, BitConverter.GetBytes(-1), 1);
                        Part3Value = Main.b_AddBytes(Part3Value, BitConverter.GetBytes(CameraFOV_List[fileCount - 1][y]), 1);
                    } else if (EntryType_List[0][y] == 4) {
                        //Only for material entry
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x12 });

                        //Material float value 0
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x00, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 1
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x01, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 2
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x02, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 3
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x03, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 4
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x04, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 5
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x05, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 6
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x06, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 7
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x07, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 8
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x08, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 9
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x09, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 10
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x0A, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 11
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x0B, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 12
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x0C, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 13
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x0D, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 14
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x0E, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 15
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x0F, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 16
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x10, 0x00, 0x0B });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount2);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });
                        //Material float value 17
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x11, 0x00, 0x0B });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount2);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        for (int x = 0; x < fileCount; x++) {
                            byte[] Mat0value = BitConverter.GetBytes(MaterialFloat0anim_List[x][y]);
                            byte[] Mat1value = BitConverter.GetBytes(MaterialFloat1anim_List[x][y]);
                            byte[] Mat2value = BitConverter.GetBytes(MaterialFloat2_List[x][y]);
                            byte[] Mat3value = BitConverter.GetBytes(MaterialFloat3_List[x][y]);
                            byte[] Mat4value = BitConverter.GetBytes(MaterialFloat4_List[x][y]);
                            byte[] Mat5value = BitConverter.GetBytes(MaterialFloat5_List[x][y]);
                            byte[] Mat6value = BitConverter.GetBytes(MaterialFloat6_List[x][y]);
                            byte[] Mat7value = BitConverter.GetBytes(MaterialFloat7_List[x][y]);
                            byte[] Mat8value = BitConverter.GetBytes(MaterialFloat8anim_List[x][y]);
                            byte[] Mat9value = BitConverter.GetBytes(MaterialFloat9anim_List[x][y]);
                            byte[] Mat10value = BitConverter.GetBytes(MaterialFloat10_List[x][y]);
                            byte[] Mat11value = BitConverter.GetBytes(MaterialFloat11_List[x][y]);
                            byte[] Mat12value = BitConverter.GetBytes(MaterialFloat12_List[x][y]);
                            byte[] Mat13value = BitConverter.GetBytes(MaterialFloat13_List[x][y]);
                            byte[] Mat14value = BitConverter.GetBytes(MaterialFloat14_List[x][y]);
                            byte[] Mat15value = BitConverter.GetBytes(MaterialFloat15_List[x][y]);

                            byte[] revMat0value = new byte[4] {
                                Mat0value[3],
                                Mat0value[2],
                                Mat0value[1],
                                Mat0value[0]
                            };
                            byte[] revMat1value = new byte[4] {
                                Mat1value[3],
                                Mat1value[2],
                                Mat1value[1],
                                Mat1value[0]
                            };
                            byte[] revMat2value = new byte[4] {
                                Mat2value[3],
                                Mat2value[2],
                                Mat2value[1],
                                Mat2value[0]
                            };
                            byte[] revMat3value = new byte[4] {
                                Mat3value[3],
                                Mat3value[2],
                                Mat3value[1],
                                Mat3value[0]
                            };
                            byte[] revMat4value = new byte[4] {
                                Mat4value[3],
                                Mat4value[2],
                                Mat4value[1],
                                Mat4value[0]
                            };
                            byte[] revMat5value = new byte[4] {
                                Mat5value[3],
                                Mat5value[2],
                                Mat5value[1],
                                Mat5value[0]
                            };
                            byte[] revMat6value = new byte[4] {
                                Mat6value[3],
                                Mat6value[2],
                                Mat6value[1],
                                Mat6value[0]
                            };
                            byte[] revMat7value = new byte[4] {
                                Mat7value[3],
                                Mat7value[2],
                                Mat7value[1],
                                Mat7value[0]
                            };
                            byte[] revMat8value = new byte[4] {
                                Mat8value[3],
                                Mat8value[2],
                                Mat8value[1],
                                Mat8value[0]
                            };
                            byte[] revMat9value = new byte[4] {
                                Mat9value[3],
                                Mat9value[2],
                                Mat9value[1],
                                Mat9value[0]
                            };
                            byte[] revMat10value = new byte[4] {
                                Mat10value[3],
                                Mat10value[2],
                                Mat10value[1],
                                Mat10value[0]
                            };
                            byte[] revMat11value = new byte[4] {
                                Mat11value[3],
                                Mat11value[2],
                                Mat11value[1],
                                Mat11value[0]
                            };
                            byte[] revMat12value = new byte[4] {
                                Mat12value[3],
                                Mat12value[2],
                                Mat12value[1],
                                Mat12value[0]
                            };
                            byte[] revMat13value = new byte[4] {
                                Mat13value[3],
                                Mat13value[2],
                                Mat13value[1],
                                Mat13value[0]
                            };
                            byte[] revMat14value = new byte[4] {
                                Mat14value[3],
                                Mat14value[2],
                                Mat14value[1],
                                Mat14value[0]
                            };
                            byte[] revMat15value = new byte[4] {
                                Mat15value[3],
                                Mat15value[2],
                                Mat15value[1],
                                Mat15value[0]
                            };
                            Part1Value = Main.b_AddBytes(Part1Value, revMat0value);
                            Part2Value = Main.b_AddBytes(Part2Value, revMat1value);
                            matPart1Value = Main.b_AddBytes(matPart1Value, revMat2value);
                            matPart2Value = Main.b_AddBytes(matPart2Value, revMat3value);
                            matPart3Value = Main.b_AddBytes(matPart3Value, revMat4value);
                            matPart4Value = Main.b_AddBytes(matPart4Value, revMat5value);
                            matPart5Value = Main.b_AddBytes(matPart5Value, revMat6value);
                            matPart6Value = Main.b_AddBytes(matPart6Value, revMat7value);
                            Part3Value = Main.b_AddBytes(Part3Value, revMat8value);
                            Part4Value = Main.b_AddBytes(Part4Value, revMat9value);
                            matPart7Value = Main.b_AddBytes(matPart7Value, revMat10value);
                            matPart8Value = Main.b_AddBytes(matPart8Value, revMat11value);
                            matPart9Value = Main.b_AddBytes(matPart9Value, revMat12value);
                            matPart10Value = Main.b_AddBytes(matPart10Value, revMat13value);
                            matPart11Value = Main.b_AddBytes(matPart11Value, revMat14value);
                            matPart12Value = Main.b_AddBytes(matPart12Value, revMat15value);

                        }
                    } else if (EntryType_List[0][y] == 5) {
                        //Only for light dirct
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x03 });

                        //RGB Hex color
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x00, 0x00, 0x14 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        //Light Strength
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x01, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        //Rotation Quaternion values
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x02, 0x00, 0x11 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        for (int x = 0; x < fileCount; x++) {
                            byte[] HexColor = new byte[3] {
                            Convert.ToByte(ColorR_List[x][y]* 255),
                            Convert.ToByte(ColorG_List[x][y]* 255),
                            Convert.ToByte(ColorB_List[x][y]* 255)
                        };

                            byte[] LightStrength = BitConverter.GetBytes(LightStrength_List[x][y]);
                            byte[] RevLightStrength = new byte[4] {
                            LightStrength[3],
                            LightStrength[2],
                            LightStrength[1],
                            LightStrength[0] };
                            byte[] RotX = BitConverter.GetBytes(Convert.ToInt32(RotX_List[x][y] * 0x4000));
                            byte[] RotY = BitConverter.GetBytes(Convert.ToInt32(RotY_List[x][y] * 0x4000));
                            byte[] RotZ = BitConverter.GetBytes(Convert.ToInt32(RotZ_List[x][y] * 0x4000));
                            byte[] RotW = BitConverter.GetBytes(Convert.ToInt32(RotW_List[x][y] * 0x4000));

                            byte[] revRot = new byte[8] {
                            RotX[1],
                            RotX[0],
                            RotY[1],
                            RotY[0],
                            RotZ[1],
                            RotZ[0],
                            RotW[1],
                            RotW[0]
                        };
                            Part1Value = Main.b_AddBytes(Part1Value, HexColor);
                            Part2Value = Main.b_AddBytes(Part2Value, RevLightStrength);
                            Part3Value = Main.b_AddBytes(Part3Value, revRot);
                        }
                        for (int h = 0; h < Part1Value.Length % 4; h++) {

                            Part1Value = Main.b_AddBytes(Part1Value, new byte[1] { 0x00 });
                        }
                    } else if (EntryType_List[0][y] == 6) {
                        //Only for light point
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x05 });

                        //RGB Hex color
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x00, 0x00, 0x14 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        //Light Strength
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x01, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        //Light Position
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x02, 0x00, 0x06 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount1);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        //Light Radius
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x03, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        //Light Visibility
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x04, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        for (int x = 0; x < fileCount; x++) {
                            byte[] HexColor = new byte[3] {
                            Convert.ToByte(ColorR_List[x][y]* 255),
                            Convert.ToByte(ColorG_List[x][y]* 255),
                            Convert.ToByte(ColorB_List[x][y]* 255)
                        };

                            byte[] LightStrength = BitConverter.GetBytes(LightStrength_List[x][y]);
                            byte[] RevLightStrength = new byte[4] {
                            LightStrength[3],
                            LightStrength[2],
                            LightStrength[1],
                            LightStrength[0] };

                            byte[] keyframe = BitConverter.GetBytes(x * 100);
                            byte[] PosX = BitConverter.GetBytes(PosX_List[x][y]);
                            byte[] PosY = BitConverter.GetBytes(PosY_List[x][y]);
                            byte[] PosZ = BitConverter.GetBytes(PosZ_List[x][y]);
                            byte[] revPos = new byte[0x10] {
                            keyframe[3],
                            keyframe[2],
                            keyframe[1],
                            keyframe[0],
                            PosX[3],
                            PosX[2],
                            PosX[1],
                            PosX[0],
                            PosY[3],
                            PosY[2],
                            PosY[1],
                            PosY[0],
                            PosZ[3],
                            PosZ[2],
                            PosZ[1],
                            PosZ[0],
                        };

                            byte[] byteLightRadius = BitConverter.GetBytes(LightRadius_List[x][y]);
                            byte[] revLightRadius = new byte[4] {
                            byteLightRadius[3],
                            byteLightRadius[2],
                            byteLightRadius[1],
                            byteLightRadius[0] };
                            byte[] byteLightVisibility = BitConverter.GetBytes(LightVisibility_List[x][y]);

                            byte[] revLightVisibility = new byte[4] {
                            byteLightVisibility[3],
                            byteLightVisibility[2],
                            byteLightVisibility[1],
                            byteLightVisibility[0] };

                            Part1Value = Main.b_AddBytes(Part1Value, HexColor);
                            Part2Value = Main.b_AddBytes(Part2Value, RevLightStrength);
                            Part3Value = Main.b_AddBytes(Part3Value, revPos);
                            Part4Value = Main.b_AddBytes(Part4Value, revLightRadius);
                            Part5Value = Main.b_AddBytes(Part5Value, revLightVisibility);
                        }
                        byte[] keyframe2 = BitConverter.GetBytes(-1);
                        byte[] PosX2 = BitConverter.GetBytes(PosX_List[fileCount - 1][y]);
                        byte[] PosY2 = BitConverter.GetBytes(PosY_List[fileCount - 1][y]);
                        byte[] PosZ2 = BitConverter.GetBytes(PosZ_List[fileCount - 1][y]);
                        byte[] revPos2 = new byte[0x10] {
                            keyframe2[3],
                            keyframe2[2],
                            keyframe2[1],
                            keyframe2[0],
                            PosX2[3],
                            PosX2[2],
                            PosX2[1],
                            PosX2[0],
                            PosY2[3],
                            PosY2[2],
                            PosY2[1],
                            PosY2[0],
                            PosZ2[3],
                            PosZ2[2],
                            PosZ2[1],
                            PosZ2[0],
                        };
                        Part3Value = Main.b_AddBytes(Part3Value, revPos2);
                        for (int h = 0; h < Part1Value.Length % 4; h++) {

                            Part1Value = Main.b_AddBytes(Part1Value, new byte[1] { 0x00 });
                        }
                    } else if (EntryType_List[0][y] == 8) {
                        //Only for ambient
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x02 });

                        //RGB Hex color
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x00, 0x00, 0x14 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        //Light Strength
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 0x01, 0x00, 0x16 });
                        fileBytes = Main.b_AddBytes(fileBytes, revbyteFileCount);
                        fileBytes = Main.b_AddBytes(fileBytes, new byte[] { 0x00, 12 });

                        for (int x = 0; x < fileCount; x++) {

                            byte[] HexColor = new byte[3] {
                            Convert.ToByte(ColorR_List[x][y]* 255),
                            Convert.ToByte(ColorG_List[x][y]* 255),
                            Convert.ToByte(ColorB_List[x][y]* 255)
                        };

                            byte[] LightStrength = BitConverter.GetBytes(LightStrength_List[x][y]);
                            byte[] RevLightStrength = new byte[4] {
                            LightStrength[3],
                            LightStrength[2],
                            LightStrength[1],
                            LightStrength[0] };

                            Part1Value = Main.b_AddBytes(Part1Value, HexColor);
                            Part2Value = Main.b_AddBytes(Part2Value, RevLightStrength);
                        }
                        for (int h = 0; h < Part1Value.Length % 4; h++) {

                            Part1Value = Main.b_AddBytes(Part1Value, new byte[1] { 0x00 });
                        }
                    }
                    fileBytes = Main.b_AddBytes(fileBytes, Part1Value);
                    fileBytes = Main.b_AddBytes(fileBytes, Part2Value);
                    fileBytes = Main.b_AddBytes(fileBytes, matPart1Value);
                    fileBytes = Main.b_AddBytes(fileBytes, matPart2Value);
                    fileBytes = Main.b_AddBytes(fileBytes, matPart3Value);
                    fileBytes = Main.b_AddBytes(fileBytes, matPart4Value);
                    fileBytes = Main.b_AddBytes(fileBytes, matPart5Value);
                    fileBytes = Main.b_AddBytes(fileBytes, matPart6Value);

                    fileBytes = Main.b_AddBytes(fileBytes, Part3Value);
                    fileBytes = Main.b_AddBytes(fileBytes, Part4Value);

                    fileBytes = Main.b_AddBytes(fileBytes, matPart7Value);
                    fileBytes = Main.b_AddBytes(fileBytes, matPart8Value);
                    fileBytes = Main.b_AddBytes(fileBytes, matPart9Value);
                    fileBytes = Main.b_AddBytes(fileBytes, matPart10Value);
                    fileBytes = Main.b_AddBytes(fileBytes, matPart11Value);
                    fileBytes = Main.b_AddBytes(fileBytes, matPart12Value);


                    if (EntryType_List[0][y] == 4) {
                        byte[] Mat16value = BitConverter.GetBytes(MaterialFloat16_List[0][y]);
                        byte[] Mat17value = BitConverter.GetBytes(MaterialFloat17_List[0][y]);
                        byte[] revMat16value = new byte[4] {
                            Mat16value[3],
                            Mat16value[2],
                            Mat16value[1],
                            Mat16value[0]
                        };
                        byte[] revMat17value = new byte[4] {
                            Mat17value[3],
                            Mat17value[2],
                            Mat17value[1],
                            Mat17value[0]
                        };
                        fileBytes = Main.b_AddBytes(fileBytes, revMat16value);
                        fileBytes = Main.b_AddBytes(fileBytes, revMat17value);
                    }
                    fileBytes = Main.b_AddBytes(fileBytes, Part5Value);
                    using (var stream = new FileStream(saveFilePath+"_temp", FileMode.Append)) {
                        stream.Write(fileBytes, 0, fileBytes.Length);
                    }
                }
                
            }
            byte[] byteEntryCount = BitConverter.GetBytes(EntryCount_new);
            byte[] revEntryCount = new byte[2] {
                byteEntryCount[1],
                byteEntryCount[0]
            };
            byte[] byteFrameCount = BitConverter.GetBytes((fileCount-1) * 0x64);
            byte[] revbyteFrameCount = new byte[4] {
                byteFrameCount[3],
                byteFrameCount[2],
                byteFrameCount[1],
                byteFrameCount[0]
            };
            ConvertedAnmHeader = Main.b_ReplaceBytes(ConvertedAnmHeader, revbyteFrameCount, 0);
            ConvertedAnmHeader = Main.b_ReplaceBytes(ConvertedAnmHeader, revEntryCount, 0x08);
            byte[] read_file = File.ReadAllBytes(saveFilePath + "_temp");
            if (File.Exists(saveFilePath + "_temp"))
                File.Delete(saveFilePath + "_temp");
            ConvertedAnmHeader = Main.b_AddBytes(ConvertedAnmHeader, read_file);
            File.WriteAllBytes(saveFilePath, ConvertedAnmHeader);
            //MessageBox.Show(EntryCount_new.ToString("X2"));


        }

        private void Tool_AnmStreamConverter_Load(object sender, EventArgs e) {

        }
    }
}
