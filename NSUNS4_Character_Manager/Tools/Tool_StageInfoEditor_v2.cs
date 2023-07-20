using NSUNS4_Character_Manager.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSUNS4_Character_Manager.Tools {
    
    public partial class Tool_StageInfoEditor_v2 : Form {

        public byte[] PlayerAmbientColor = new byte[4];
        public byte[] RayCutOffShadeColor = new byte[4];
        public byte[] EffectAmbientColor = new byte[4];
        public byte[] ParallelAmbientColor = new byte[4];
        public byte[] RayCutOffNormalColor = new byte[4];
        public byte[] ShadowColor = new byte[4];
        public byte[] FogColor = new byte[4];
        public byte[] SunShaftColor = new byte[4];
        public byte[] RockColor = new byte[4];
        public byte[] UnknownColor = new byte[4];

        [Serializable]
        public class StageInfoParam {
            public string StageName;
            public string Stage_c_sta_xx;
            public string Stage_BTL;
            public int PathCount;
            public int ObjectCount;

            public List<string> PathList;
            public List<StageInfo_ObjectEntry> ObjectList;

            public int Weather;
            public byte[] PlayerAmbientColor;
            public byte[] RayCutOffShadeColor;
            public byte[] EffectAmbientColor;
            public bool EnableLensFlare;
            public int LensFlareType;
            public float LensFlare_X_Direction;
            public float LensFlare_Y_Direction;
            public float LensFlare_Z_Direction;
            public float LensFlare_Alpha;
            public byte[] ParallelAmbientColor;
            public byte[] RayCutOffNormalColor;
            public float LightPoint_X_Direction;
            public float LightPoint_Y_Direction;
            public float LightPoint_Z_Direction;
            public bool EnableShadowColor;
            public byte[] ShadowColor;
            public bool EnableFog;
            public float FogStartDistance;
            public float FogEndDistance;
            public float FogStrength;
            public byte[] FogColor;
            public bool EnableMonoColorFilter;
            public float MonoColor_Blue;
            public float MonoColor_Red;
            public float MonoColor_Alpha;
            public bool EnableGlareEffects;
            public float GlareLuminanceThreshold;
            public float GlareSubtracted;
            public float GlareCompositionStrength;
            public bool EnableSoftFocus;
            public float SoftFocusStrength;
            public bool EnableDOF_Blur;
            public float DOF_FocalLength;
            public float DOF_ShortDistance;
            public float DOF_LongDistance;
            public float DOF_Alpha;
            public bool EnableDOF_EdgeBlur;
            public bool EnableSunShaft;
            public float SunShaft_StartDistance;
            public float SunShaft_EndDistance;
            public float SunShaft_Alpha;
            public byte[] SunShaftColor;
            public float SunShaft_Source_X_Direction;
            public float SunShaft_Source_Y_Direction;
            public float SunShaft_Source_Z_Direction;
            public float SunShaft_BlurWidth;
            public float SunShaft_AttenuationCoefficient;
            public byte[] RockColor;
            public byte[] UnknownColor;

            public static StageInfoParam Clone(StageInfoParam source) {
                return (StageInfoParam)source.MemberwiseClone();
            }

        }
        [Serializable]
        public class StageInfo_ObjectEntry {
            public string PathString;
            public string MeshString;
            public string PathDmyString;
            public string DmyString;
            public int TypeSection;
            public bool CameraValue;
            public int MysteriousValue;
            public float AnimationSpeed;
            public int Const3C;
            public int Const78;
            public int ConstBreakableWallValue1;
            public int ConstBreakableWallValue2;
            public string BreakableWall_Effect01;
            public string BreakableWall_Effect02;
            public string BreakableWall_Effect03;
            public string BreakableWall_Sound;
            public string BreakableObject_path;
            public string BreakableObject_Effect01;
            public string BreakableObject_Effect02;
            public string BreakableObject_Effect03;
            public float BreakableObject_Speed01;
            public float BreakableObject_Speed02;
            public float BreakableObject_Speed03;
            public float BreakableWall_volume;
        }

        public StageInfoParam CopiedProperties;

        public List<StageInfoParam> StageInfo = new List<StageInfoParam>();
        public byte[] fileBytes;
        public int EntryCount;
        public bool FileOpen;
        public int FilePos = 0;
        public string FilePath = "";
        public byte[] header;


        public Tool_StageInfoEditor_v2() {
            InitializeComponent();
        }

        public void Clean() {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            StageInfo = new List<StageInfoParam>();
            FileOpen = false;
            fileBytes = new byte[0];
            EntryCount = 0;
            FilePos = 0;
            header = new byte[0];
            PlayerAmbientColor = new byte[4];
            RayCutOffShadeColor = new byte[4];
            EffectAmbientColor = new byte[4];
            ParallelAmbientColor = new byte[4];
            RayCutOffNormalColor = new byte[4];
            ShadowColor = new byte[4];
            FogColor = new byte[4];
            SunShaftColor = new byte[4];
            RockColor = new byte[4];
            UnknownColor = new byte[4];
    }


        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFile();
        }
        public void OpenFile(string FileName = "") {
            if (FileName == "") {
                OpenFileDialog o = new OpenFileDialog();
                {
                    o.DefaultExt = ".xfbin";
                    o.Filter = "*.xfbin|*.xfbin";
                }
                o.ShowDialog();
                FileName = o.FileName;
            }
            Clean();
            if (FileName == "" || File.Exists(FileName) == false) return;
            fileBytes = File.ReadAllBytes(FileName);
            FileOpen = true;
            FilePath = FileName;
            FilePos = Main.b_FindBytes(fileBytes, new byte[4] { 0xF2, 0x03, 0x00, 0x00 }, 0);
            header = Main.b_ReadByteArray(fileBytes, 0, FilePos + 16);
            EntryCount = Main.b_ReadInt(fileBytes, FilePos + 0x04);
            for (int c = 0; c<EntryCount; c++) {
                int _ptr = FilePos + 0x10 + 0x130 * c;
                StageInfoParam StageInfoEntry = new StageInfoParam();
                StageInfoEntry.StageName = Main.b_ReadString(fileBytes, _ptr + Main.b_ReadInt(fileBytes,_ptr));
                StageInfoEntry.Stage_c_sta_xx = Main.b_ReadString(fileBytes, _ptr + 0x08 + Main.b_ReadInt(fileBytes, _ptr + 0x08));
                StageInfoEntry.Stage_BTL = Main.b_ReadString(fileBytes, _ptr + 0x10 + Main.b_ReadInt(fileBytes, _ptr + 0x10));
                StageInfoEntry.PathCount = Main.b_ReadInt(fileBytes, _ptr + 0x18);
                List<string> PathList = new List<string>();
                for (int path = 0; path< StageInfoEntry.PathCount; path++) {
                    int pathListPtr = Main.b_ReadInt(fileBytes, _ptr + 0x20);
                    int pathPtr = Main.b_ReadInt(fileBytes, _ptr + 0x20 + pathListPtr + (0x08*path));
                    int ptr = _ptr + 0x20 + pathListPtr + pathPtr + (0x08 * path);
                    PathList.Add(Main.b_ReadString(fileBytes, ptr));
                
                }
                StageInfoEntry.PathList = PathList;
                StageInfoEntry.ObjectCount = Main.b_ReadInt(fileBytes, _ptr + 0x28);
                List<StageInfo_ObjectEntry> ObjectList = new List<StageInfo_ObjectEntry>();
                for (int o = 0; o < StageInfoEntry.ObjectCount; o++) {
                    int objectListPtr = Main.b_ReadInt(fileBytes, _ptr + 0x30);
                    int object_ptr = _ptr + 0x30 + objectListPtr + (0xB0 * o);

                    StageInfo_ObjectEntry ObjectEntry = new StageInfo_ObjectEntry();

                    int PathString_ptr = object_ptr+ Main.b_ReadInt(fileBytes, object_ptr);
                    ObjectEntry.PathString = Main.b_ReadString(fileBytes, PathString_ptr);

                    int MeshString_ptr = 0x8 + object_ptr + Main.b_ReadInt(fileBytes, 0x8 + object_ptr);
                    ObjectEntry.MeshString = Main.b_ReadString(fileBytes, MeshString_ptr);

                    int PathDmyString_ptr = 0x10 + object_ptr + Main.b_ReadInt(fileBytes, 0x10 + object_ptr);
                    ObjectEntry.PathDmyString = Main.b_ReadString(fileBytes, PathDmyString_ptr);

                    int DmyString_ptr = 0x18 + object_ptr + Main.b_ReadInt(fileBytes, 0x18 + object_ptr);
                    ObjectEntry.DmyString = Main.b_ReadString(fileBytes, DmyString_ptr);

                    ObjectEntry.TypeSection = Main.b_ReadInt(fileBytes, object_ptr + 0x20);
                    ObjectEntry.AnimationSpeed = Main.b_ReadFloat(fileBytes, object_ptr + 0x24);
                    ObjectEntry.CameraValue = Convert.ToBoolean(Main.b_ReadInt(fileBytes, object_ptr + 0x28));
                    ObjectEntry.MysteriousValue = Main.b_ReadInt(fileBytes, object_ptr + 0x2C);

                    int BreakableObject_path_ptr = 0x38 + object_ptr + Main.b_ReadInt(fileBytes, 0x38 + object_ptr);
                    ObjectEntry.BreakableObject_path = Main.b_ReadString(fileBytes, BreakableObject_path_ptr);

                    int BreakableObject_Effect01_ptr = 0x40 + object_ptr + Main.b_ReadInt(fileBytes, 0x40 + object_ptr);
                    ObjectEntry.BreakableObject_Effect01 = Main.b_ReadString(fileBytes, BreakableObject_Effect01_ptr);
                    ObjectEntry.BreakableObject_Speed01 = Main.b_ReadFloat(fileBytes, object_ptr + 0x48);

                    int BreakableObject_Effect02_ptr = 0x50 + object_ptr + Main.b_ReadInt(fileBytes, 0x50 + object_ptr);
                    ObjectEntry.BreakableObject_Effect02 = Main.b_ReadString(fileBytes, BreakableObject_Effect02_ptr);
                    ObjectEntry.BreakableObject_Speed02 = Main.b_ReadFloat(fileBytes, object_ptr + 0x58);


                    int BreakableObject_Effect03_ptr = 0x60 + object_ptr + Main.b_ReadInt(fileBytes, 0x60 + object_ptr);
                    ObjectEntry.BreakableObject_Effect03 = Main.b_ReadString(fileBytes, BreakableObject_Effect03_ptr);
                    ObjectEntry.BreakableObject_Speed03 = Main.b_ReadFloat(fileBytes, object_ptr + 0x68);

                    ObjectEntry.Const3C = Main.b_ReadInt(fileBytes, object_ptr + 0x70);
                    ObjectEntry.Const78 = Main.b_ReadInt(fileBytes, object_ptr + 0x74);

                    int BreakableWall_Effect01_ptr = 0x78 + object_ptr + Main.b_ReadInt(fileBytes, 0x78 + object_ptr);
                    ObjectEntry.BreakableWall_Effect01 = Main.b_ReadString(fileBytes, BreakableWall_Effect01_ptr);

                    int BreakableWall_Effect02_ptr = 0x88 + object_ptr + Main.b_ReadInt(fileBytes, 0x88 + object_ptr);
                    ObjectEntry.BreakableWall_Effect02 = Main.b_ReadString(fileBytes, BreakableWall_Effect02_ptr);

                    int BreakableWall_Effect03_ptr = 0x90 + object_ptr + Main.b_ReadInt(fileBytes, 0x90 + object_ptr);
                    ObjectEntry.BreakableWall_Effect03 = Main.b_ReadString(fileBytes, BreakableWall_Effect03_ptr);

                    ObjectEntry.ConstBreakableWallValue1 = Main.b_ReadInt(fileBytes, object_ptr + 0x80);
                    ObjectEntry.ConstBreakableWallValue2 = Main.b_ReadInt(fileBytes, object_ptr + 0x84);
                    ObjectEntry.BreakableWall_volume = Main.b_ReadFloat(fileBytes, object_ptr + 0x98);

                    int BreakableWall_Sound_ptr = 0xA0 + object_ptr + Main.b_ReadInt(fileBytes, 0xA0 + object_ptr);
                    ObjectEntry.BreakableWall_Sound = Main.b_ReadString(fileBytes, BreakableWall_Sound_ptr);

                    ObjectList.Add(ObjectEntry);
                }
                StageInfoEntry.ObjectList = ObjectList;
                StageInfoEntry.Weather = Main.b_ReadInt(fileBytes, _ptr + 0x38);
                StageInfoEntry.PlayerAmbientColor = Main.b_ReadByteArray(fileBytes, _ptr + 0x3C,4);
                StageInfoEntry.RayCutOffShadeColor = Main.b_ReadByteArray(fileBytes, _ptr + 0x40, 4);
                StageInfoEntry.EffectAmbientColor = Main.b_ReadByteArray(fileBytes, _ptr + 0x44, 4);
                StageInfoEntry.UnknownColor = Main.b_ReadByteArray(fileBytes, _ptr + 0x48, 4);
                StageInfoEntry.EnableLensFlare = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0x58));
                StageInfoEntry.LensFlareType = Main.b_ReadInt(fileBytes, _ptr + 0x5C);
                StageInfoEntry.LensFlare_X_Direction = Main.b_ReadFloat(fileBytes, _ptr + 0x60);
                StageInfoEntry.LensFlare_Y_Direction = Main.b_ReadFloat(fileBytes, _ptr + 0x64);
                StageInfoEntry.LensFlare_Z_Direction = Main.b_ReadFloat(fileBytes, _ptr + 0x68);
                StageInfoEntry.LensFlare_Alpha = Main.b_ReadFloat(fileBytes, _ptr + 0x6C);
                StageInfoEntry.ParallelAmbientColor = Main.b_ReadByteArray(fileBytes, _ptr + 0x70, 4);
                StageInfoEntry.RayCutOffNormalColor = Main.b_ReadByteArray(fileBytes, _ptr + 0x74, 4);
                StageInfoEntry.LightPoint_X_Direction = Main.b_ReadFloat(fileBytes, _ptr + 0x78);
                StageInfoEntry.LightPoint_Y_Direction = Main.b_ReadFloat(fileBytes, _ptr + 0x7C);
                StageInfoEntry.LightPoint_Z_Direction = Main.b_ReadFloat(fileBytes, _ptr + 0x80);
                StageInfoEntry.EnableShadowColor = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0x84));
                StageInfoEntry.ShadowColor = Main.b_ReadByteArray(fileBytes, _ptr + 0x88, 4);
                StageInfoEntry.EnableFog = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0x8C));
                StageInfoEntry.FogStartDistance = Main.b_ReadFloat(fileBytes, _ptr + 0x90);
                StageInfoEntry.FogEndDistance = Main.b_ReadFloat(fileBytes, _ptr + 0x94);
                StageInfoEntry.FogStrength = Main.b_ReadFloat(fileBytes, _ptr + 0x98);
                StageInfoEntry.FogColor = Main.b_ReadByteArray(fileBytes, _ptr + 0x9C, 4);
                StageInfoEntry.EnableMonoColorFilter = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0xA0));
                StageInfoEntry.MonoColor_Blue = Main.b_ReadFloat(fileBytes, _ptr + 0xA4);
                StageInfoEntry.MonoColor_Red = Main.b_ReadFloat(fileBytes, _ptr + 0xA8);
                StageInfoEntry.MonoColor_Alpha = Main.b_ReadFloat(fileBytes, _ptr + 0xAC);
                StageInfoEntry.EnableGlareEffects = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0xB0));
                StageInfoEntry.GlareLuminanceThreshold = Main.b_ReadFloat(fileBytes, _ptr + 0xB4);
                StageInfoEntry.GlareSubtracted = Main.b_ReadFloat(fileBytes, _ptr + 0xB8);
                StageInfoEntry.GlareCompositionStrength = Main.b_ReadFloat(fileBytes, _ptr + 0xBC);
                StageInfoEntry.EnableSoftFocus = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0xC4));
                StageInfoEntry.SoftFocusStrength = Main.b_ReadFloat(fileBytes, _ptr + 0xC8);
                StageInfoEntry.EnableDOF_Blur = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0xCC));
                StageInfoEntry.DOF_FocalLength = Main.b_ReadFloat(fileBytes, _ptr + 0xD0);
                StageInfoEntry.DOF_ShortDistance = Main.b_ReadFloat(fileBytes, _ptr + 0xD4);
                StageInfoEntry.DOF_LongDistance = Main.b_ReadFloat(fileBytes, _ptr + 0xD8);
                StageInfoEntry.DOF_Alpha = Main.b_ReadFloat(fileBytes, _ptr + 0xDC);
                StageInfoEntry.EnableDOF_EdgeBlur = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0xE0));
                StageInfoEntry.EnableSunShaft = Convert.ToBoolean(Main.b_ReadInt(fileBytes, _ptr + 0xE4));
                StageInfoEntry.SunShaft_StartDistance = Main.b_ReadFloat(fileBytes, _ptr + 0xE8);
                StageInfoEntry.SunShaft_EndDistance = Main.b_ReadFloat(fileBytes, _ptr + 0xEC);
                StageInfoEntry.SunShaft_Alpha = Main.b_ReadFloat(fileBytes, _ptr + 0xF0);
                StageInfoEntry.SunShaftColor = Main.b_ReadByteArray(fileBytes, _ptr + 0xF4, 4);
                StageInfoEntry.SunShaft_Source_X_Direction = Main.b_ReadFloat(fileBytes, _ptr + 0xF8);
                StageInfoEntry.SunShaft_Source_Y_Direction = Main.b_ReadFloat(fileBytes, _ptr + 0xFC);
                StageInfoEntry.SunShaft_Source_Z_Direction = Main.b_ReadFloat(fileBytes, _ptr + 0x100);
                StageInfoEntry.SunShaft_BlurWidth = Main.b_ReadFloat(fileBytes, _ptr + 0x104);
                StageInfoEntry.SunShaft_AttenuationCoefficient = Main.b_ReadFloat(fileBytes, _ptr + 0x108);
                StageInfoEntry.RockColor = Main.b_ReadByteArray(fileBytes, _ptr + 0x10C, 4);

                listBox1.Items.Add(StageInfoEntry.StageName);
                StageInfo.Add(StageInfoEntry);
            }

        }


        private void fileToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                textBox1.Text = StageInfo[x].StageName;
                textBox2.Text = StageInfo[x].Stage_c_sta_xx;
                textBox3.Text = StageInfo[x].Stage_BTL;
                comboBox1.SelectedIndex = StageInfo[x].Weather;
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                for (int c = 0; c< StageInfo[x].PathList.Count; c++) {
                    listBox2.Items.Add(StageInfo[x].PathList[c]);
                }
                for (int c = 0; c < StageInfo[x].ObjectList.Count; c++) {
                    listBox3.Items.Add(StageInfo[x].ObjectList[c].MeshString);
                }
                if (StageInfo[x].EnableLensFlare)
                    comboBox2.SelectedIndex = StageInfo[x].LensFlareType+1;
                else
                    comboBox2.SelectedIndex = 0;


                PlayerAmbientColor = StageInfo[x].PlayerAmbientColor;
                RayCutOffShadeColor = StageInfo[x].RayCutOffShadeColor;
                EffectAmbientColor = StageInfo[x].EffectAmbientColor;
                ParallelAmbientColor = StageInfo[x].ParallelAmbientColor;
                RayCutOffNormalColor = StageInfo[x].RayCutOffNormalColor;
                ShadowColor = StageInfo[x].ShadowColor;
                checkBox2.Checked = StageInfo[x].EnableShadowColor;
                RockColor = StageInfo[x].RockColor;
                UnknownColor = StageInfo[x].UnknownColor;

                //Lensflare
                numericUpDown32.Value = (decimal)StageInfo[x].LensFlare_X_Direction;
                numericUpDown31.Value = (decimal)StageInfo[x].LensFlare_Y_Direction;
                numericUpDown30.Value = (decimal)StageInfo[x].LensFlare_Z_Direction;
                numericUpDown33.Value = (decimal)StageInfo[x].LensFlare_Alpha;

                //light point
                numericUpDown36.Value = (decimal)StageInfo[x].LightPoint_X_Direction;
                numericUpDown35.Value = (decimal)StageInfo[x].LightPoint_Y_Direction;
                numericUpDown34.Value = (decimal)StageInfo[x].LightPoint_Z_Direction;

                //Fog
                FogColor = StageInfo[x].FogColor;
                checkBox3.Checked = StageInfo[x].EnableFog;
                numericUpDown8.Value = (decimal)StageInfo[x].FogStartDistance;
                numericUpDown9.Value = (decimal)StageInfo[x].FogEndDistance;
                numericUpDown10.Value = (decimal)StageInfo[x].FogStrength;

                //MonoFilter
                checkBox4.Checked = StageInfo[x].EnableMonoColorFilter;
                numericUpDown13.Value = (decimal)StageInfo[x].MonoColor_Blue;
                numericUpDown12.Value = (decimal)StageInfo[x].MonoColor_Red;
                numericUpDown11.Value = (decimal)StageInfo[x].MonoColor_Alpha;

                //Glares
                checkBox5.Checked = StageInfo[x].EnableGlareEffects;
                numericUpDown16.Value = (decimal)StageInfo[x].GlareLuminanceThreshold;
                numericUpDown15.Value = (decimal)StageInfo[x].GlareSubtracted;
                numericUpDown14.Value = (decimal)StageInfo[x].GlareCompositionStrength;

                //SoftFocus
                checkBox6.Checked = StageInfo[x].EnableSoftFocus;
                numericUpDown17.Value = (decimal)StageInfo[x].SoftFocusStrength;

                //DOF
                checkBox7.Checked = StageInfo[x].EnableDOF_Blur;
                numericUpDown18.Value = (decimal)StageInfo[x].DOF_FocalLength;
                numericUpDown19.Value = (decimal)StageInfo[x].DOF_ShortDistance;
                numericUpDown20.Value = (decimal)StageInfo[x].DOF_LongDistance;
                numericUpDown21.Value = (decimal)StageInfo[x].DOF_Alpha;
                checkBox8.Checked = StageInfo[x].EnableDOF_EdgeBlur;

                //SunShaft
                checkBox9.Checked = StageInfo[x].EnableSunShaft;
                numericUpDown22.Value = (decimal)StageInfo[x].SunShaft_StartDistance;
                numericUpDown23.Value = (decimal)StageInfo[x].SunShaft_EndDistance;
                numericUpDown24.Value = (decimal)StageInfo[x].SunShaft_Alpha;
                SunShaftColor = StageInfo[x].SunShaftColor;
                numericUpDown25.Value = (decimal)StageInfo[x].SunShaft_Source_X_Direction;
                numericUpDown26.Value = (decimal)StageInfo[x].SunShaft_Source_Y_Direction;
                numericUpDown27.Value = (decimal)StageInfo[x].SunShaft_Source_Z_Direction;
                numericUpDown28.Value = (decimal)StageInfo[x].SunShaft_BlurWidth;
                numericUpDown29.Value = (decimal)StageInfo[x].SunShaft_AttenuationCoefficient;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            int y = listBox2.SelectedIndex;
            if (x!=-1 && y != -1) {
                textBox5.Text = StageInfo[x].PathList[y];
            }
        }

        private void button5_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                if (!StageInfo[x].PathList.Contains(textBox5.Text)) {
                    StageInfo[x].PathList.Add(textBox5.Text);
                    listBox2.Items.Add(textBox5.Text);
                } else {
                    MessageBox.Show("That file was already loaded for that stage!");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            int y = listBox2.SelectedIndex;
            if (x != -1 && y != -1) {
                if (!StageInfo[x].PathList.Contains(textBox5.Text)) {
                    StageInfo[x].PathList[y] = textBox5.Text;
                    listBox2.Items[y] = textBox5.Text;
                } else {
                    MessageBox.Show("That file was already loaded for that stage!");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            int y = listBox2.SelectedIndex;
            if (x != -1 && y != -1) {
                StageInfo[x].PathList.RemoveAt(y);
                listBox2.Items.RemoveAt(y);
                listBox2.SelectedIndex = y - 1;
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            int y = listBox3.SelectedIndex;
            if (x != -1 && y != -1) {
                comboBox3.SelectedIndex = StageInfo[x].ObjectList[y].TypeSection;
                textBox6.Text = StageInfo[x].ObjectList[y].PathString;
                textBox7.Text = StageInfo[x].ObjectList[y].MeshString;
                textBox9.Text = StageInfo[x].ObjectList[y].PathDmyString;
                textBox8.Text = StageInfo[x].ObjectList[y].DmyString;
                numericUpDown1.Value = (decimal)StageInfo[x].ObjectList[y].AnimationSpeed;
                checkBox1.Checked = StageInfo[x].ObjectList[y].CameraValue;
                textBox15.Text = StageInfo[x].ObjectList[y].BreakableObject_path;
                textBox14.Text = StageInfo[x].ObjectList[y].BreakableObject_Effect01;
                textBox16.Text = StageInfo[x].ObjectList[y].BreakableObject_Effect02;
                textBox17.Text = StageInfo[x].ObjectList[y].BreakableObject_Effect03;
                numericUpDown2.Value = (decimal)StageInfo[x].ObjectList[y].BreakableObject_Speed01;
                numericUpDown3.Value = (decimal)StageInfo[x].ObjectList[y].BreakableObject_Speed02;
                numericUpDown4.Value = (decimal)StageInfo[x].ObjectList[y].BreakableObject_Speed03;
                numericUpDown7.Value = (decimal)StageInfo[x].ObjectList[y].BreakableWall_volume;
                numericUpDown6.Value = StageInfo[x].ObjectList[y].ConstBreakableWallValue1;
                numericUpDown5.Value = StageInfo[x].ObjectList[y].ConstBreakableWallValue1;

                textBox10.Text = StageInfo[x].ObjectList[y].BreakableWall_Effect01;
                textBox11.Text = StageInfo[x].ObjectList[y].BreakableWall_Effect02;
                textBox12.Text = StageInfo[x].ObjectList[y].BreakableWall_Effect03;
                textBox13.Text = StageInfo[x].ObjectList[y].BreakableWall_Sound;

            }
        }

        private void button19_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            int y = listBox3.SelectedIndex;
            if (x != -1) {
                StageInfo_ObjectEntry new_entry = new StageInfo_ObjectEntry();
                if (y != -1) {
                    new_entry.TypeSection = StageInfo[x].ObjectList[y].TypeSection.DeepClone();
                    new_entry.PathString = StageInfo[x].ObjectList[y].PathString.DeepClone();
                    new_entry.MeshString = StageInfo[x].ObjectList[y].MeshString.DeepClone();
                    new_entry.PathDmyString = StageInfo[x].ObjectList[y].PathDmyString.DeepClone();
                    new_entry.DmyString = StageInfo[x].ObjectList[y].DmyString.DeepClone();
                    new_entry.AnimationSpeed = StageInfo[x].ObjectList[y].AnimationSpeed.DeepClone();
                    new_entry.CameraValue = StageInfo[x].ObjectList[y].CameraValue.DeepClone();
                    new_entry.BreakableObject_path = StageInfo[x].ObjectList[y].BreakableObject_path.DeepClone();
                    new_entry.BreakableObject_Effect01 = StageInfo[x].ObjectList[y].BreakableObject_Effect01.DeepClone();
                    new_entry.BreakableObject_Effect02 = StageInfo[x].ObjectList[y].BreakableObject_Effect02.DeepClone();
                    new_entry.BreakableObject_Effect03 = StageInfo[x].ObjectList[y].BreakableObject_Effect03.DeepClone();
                    new_entry.BreakableObject_Speed01 = StageInfo[x].ObjectList[y].BreakableObject_Speed01.DeepClone();
                    new_entry.BreakableObject_Speed02 = StageInfo[x].ObjectList[y].BreakableObject_Speed02.DeepClone();
                    new_entry.BreakableObject_Speed03 = StageInfo[x].ObjectList[y].BreakableObject_Speed03.DeepClone();
                    new_entry.BreakableWall_volume = StageInfo[x].ObjectList[y].BreakableWall_volume.DeepClone();
                    new_entry.ConstBreakableWallValue1 = StageInfo[x].ObjectList[y].ConstBreakableWallValue1.DeepClone();
                    new_entry.ConstBreakableWallValue1 = StageInfo[x].ObjectList[y].ConstBreakableWallValue1.DeepClone();
                    new_entry.BreakableWall_Effect01 = StageInfo[x].ObjectList[y].BreakableWall_Effect01.DeepClone();
                    new_entry.BreakableWall_Effect02 = StageInfo[x].ObjectList[y].BreakableWall_Effect02.DeepClone();
                    new_entry.BreakableWall_Effect03 = StageInfo[x].ObjectList[y].BreakableWall_Effect03.DeepClone();
                    new_entry.BreakableWall_Sound = StageInfo[x].ObjectList[y].BreakableWall_Sound.DeepClone();
                    StageInfo[x].ObjectList.Add(new_entry);
                    listBox3.Items.Add(new_entry.MeshString);
                } else {
                    new_entry.TypeSection = 0;
                    new_entry.MeshString = "new_object";
                    new_entry.PathString = "data\\stage\\path";
                    StageInfo[x].ObjectList.Add(new_entry);
                    listBox3.Items.Add(new_entry.MeshString);
                }
            } else
                MessageBox.Show("Select stage before adding new object!");
        }

        private void button20_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            int y = listBox3.SelectedIndex;
            if (x != -1) {
                if (y != -1) {
                    StageInfo[x].ObjectList[y].TypeSection = comboBox3.SelectedIndex;
                    StageInfo[x].ObjectList[y].PathString = textBox6.Text;
                    StageInfo[x].ObjectList[y].MeshString = textBox7.Text;
                    StageInfo[x].ObjectList[y].PathDmyString = textBox9.Text;
                    StageInfo[x].ObjectList[y].DmyString = textBox8.Text;
                    StageInfo[x].ObjectList[y].AnimationSpeed = (float)numericUpDown1.Value;
                    StageInfo[x].ObjectList[y].CameraValue = checkBox1.Checked;
                    StageInfo[x].ObjectList[y].BreakableObject_path = textBox15.Text;
                    StageInfo[x].ObjectList[y].BreakableObject_Effect01 = textBox14.Text;
                    StageInfo[x].ObjectList[y].BreakableObject_Effect02 = textBox16.Text;
                    StageInfo[x].ObjectList[y].BreakableObject_Effect03 = textBox17.Text;
                    StageInfo[x].ObjectList[y].BreakableObject_Speed01 = (float)numericUpDown2.Value;
                    StageInfo[x].ObjectList[y].BreakableObject_Speed02 = (float)numericUpDown3.Value;
                    StageInfo[x].ObjectList[y].BreakableObject_Speed03 = (float)numericUpDown4.Value;
                    StageInfo[x].ObjectList[y].BreakableWall_volume = (float)numericUpDown7.Value;
                    StageInfo[x].ObjectList[y].ConstBreakableWallValue1 = (int)numericUpDown6.Value;
                    StageInfo[x].ObjectList[y].ConstBreakableWallValue1 = (int)numericUpDown5.Value;
                    StageInfo[x].ObjectList[y].BreakableWall_Effect01 = textBox10.Text;
                    StageInfo[x].ObjectList[y].BreakableWall_Effect02 = textBox11.Text;
                    StageInfo[x].ObjectList[y].BreakableWall_Effect03 = textBox12.Text;
                    StageInfo[x].ObjectList[y].BreakableWall_Sound = textBox13.Text;
                    listBox3.Items[y] = textBox7.Text;
                } else
                    MessageBox.Show("Select stage object which you want to change!");
            } else
                MessageBox.Show("Select stage before adding new object!");
        }

        private void button21_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            int y = listBox3.SelectedIndex;
            if (x != -1) {
                if (y != -1) {
                    StageInfo[x].ObjectList.RemoveAt(y);
                    listBox3.Items.RemoveAt(y);
                } else
                    MessageBox.Show("Select stage object which you want to delete!");
            } else
                MessageBox.Show("Select stage before adding new object!");
        }

        private void button3_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                StageInfoParam stageEntry = new StageInfoParam();
                if (x != -1) {
                    stageEntry = StageInfo[x].DeepClone();
                    stageEntry.StageName = stageEntry.StageName + "_COPY";
                    StageInfo.Add(stageEntry);
                } else {
                    stageEntry.StageName = "NEW_STAGE";
                    StageInfo.Add(stageEntry);
                }
                listBox1.Items.Add(stageEntry.StageName);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                EntryCount++;
            } else {
                MessageBox.Show("Open StageInfo file first!");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x != -1) {
                    StageInfo[x].StageName = textBox1.Text;
                    StageInfo[x].Stage_c_sta_xx = textBox2.Text;
                    StageInfo[x].Stage_BTL = textBox3.Text;
                    StageInfo[x].Weather = comboBox1.SelectedIndex;
                    StageInfo[x].PlayerAmbientColor = PlayerAmbientColor;
                    StageInfo[x].RayCutOffShadeColor = RayCutOffShadeColor;
                    StageInfo[x].EffectAmbientColor = EffectAmbientColor;
                    StageInfo[x].ParallelAmbientColor = ParallelAmbientColor;
                    StageInfo[x].RayCutOffNormalColor = RayCutOffNormalColor;
                    StageInfo[x].ShadowColor = ShadowColor;
                    StageInfo[x].EnableShadowColor = checkBox2.Checked;
                    StageInfo[x].RockColor = RockColor;
                    StageInfo[x].UnknownColor = UnknownColor;

                    //Lensflare
                    if (comboBox2.SelectedIndex == 0) {
                        StageInfo[x].EnableLensFlare = false;
                        StageInfo[x].LensFlareType = 0;
                    }
                    else {
                        StageInfo[x].EnableLensFlare = true;
                        StageInfo[x].LensFlareType = comboBox2.SelectedIndex-1;
                    }
                    StageInfo[x].LensFlare_X_Direction = (float)numericUpDown32.Value;
                    StageInfo[x].LensFlare_Y_Direction = (float)numericUpDown31.Value;
                    StageInfo[x].LensFlare_Z_Direction = (float)numericUpDown30.Value;
                    StageInfo[x].LensFlare_Alpha = (float)numericUpDown33.Value;

                    //light point
                    StageInfo[x].LightPoint_X_Direction = (float)numericUpDown36.Value;
                    StageInfo[x].LightPoint_Y_Direction = (float)numericUpDown35.Value;
                    StageInfo[x].LightPoint_Z_Direction = (float)numericUpDown34.Value;

                    //Fog
                    StageInfo[x].FogColor = FogColor;
                    StageInfo[x].EnableFog = checkBox3.Checked;
                    StageInfo[x].FogStartDistance = (float)numericUpDown8.Value;
                    StageInfo[x].FogEndDistance = (float)numericUpDown9.Value;
                    StageInfo[x].FogStrength = (float)numericUpDown10.Value;

                    //MonoFilter
                    StageInfo[x].EnableMonoColorFilter = checkBox4.Checked;
                    StageInfo[x].MonoColor_Blue = (float)numericUpDown13.Value;
                    StageInfo[x].MonoColor_Red = (float)numericUpDown12.Value;
                    StageInfo[x].MonoColor_Alpha = (float)numericUpDown11.Value;

                    //Glares
                    StageInfo[x].EnableGlareEffects = checkBox5.Checked;
                    StageInfo[x].GlareLuminanceThreshold = (float)numericUpDown16.Value;
                    StageInfo[x].GlareSubtracted = (float)numericUpDown15.Value;
                    StageInfo[x].GlareCompositionStrength = (float)numericUpDown14.Value;

                    //SoftFocus
                    StageInfo[x].EnableSoftFocus = checkBox6.Checked;
                    StageInfo[x].SoftFocusStrength = (float)numericUpDown17.Value;

                    //DOF
                    StageInfo[x].EnableDOF_Blur = checkBox7.Checked;
                    StageInfo[x].DOF_FocalLength = (float)numericUpDown18.Value;
                    StageInfo[x].DOF_ShortDistance = (float)numericUpDown19.Value;
                    StageInfo[x].DOF_LongDistance = (float)numericUpDown20.Value;
                    StageInfo[x].DOF_Alpha = (float)numericUpDown21.Value;
                    StageInfo[x].EnableDOF_EdgeBlur = checkBox8.Checked;

                    //SunShaft
                    StageInfo[x].EnableSunShaft = checkBox9.Checked;
                    StageInfo[x].SunShaft_StartDistance = (float)numericUpDown22.Value;
                    StageInfo[x].SunShaft_EndDistance = (float)numericUpDown23.Value;
                    StageInfo[x].SunShaft_Alpha = (float)numericUpDown24.Value;
                    StageInfo[x].SunShaftColor = SunShaftColor;
                    StageInfo[x].SunShaft_Source_X_Direction = (float)numericUpDown25.Value;
                    StageInfo[x].SunShaft_Source_Y_Direction = (float)numericUpDown26.Value;
                    StageInfo[x].SunShaft_Source_Z_Direction = (float)numericUpDown27.Value;
                    StageInfo[x].SunShaft_BlurWidth = (float)numericUpDown28.Value;
                    StageInfo[x].SunShaft_AttenuationCoefficient = (float)numericUpDown29.Value;


                    for (int c = 0; c < StageInfo[x].PathList.Count; c++) {
                        if (StageInfo[x].PathList[c].Contains("lensFlare") || StageInfo[x].PathList[c].Contains("sae_snow") || StageInfo[x].PathList[c].Contains("sae_rain")) {
                            StageInfo[x].PathList.RemoveAt(c);
                            c--;
                        }
                    }
                    if (StageInfo[x].EnableLensFlare) {
                        StageInfo[x].PathList.Add("data/stage/lensFlare/" + comboBox2.Items[StageInfo[x].LensFlareType + 1].ToString() + ".xfbin");
                    }
                    if (StageInfo[x].Weather != 0) {
                        switch (StageInfo[x].Weather) {
                            case 1:
                                StageInfo[x].PathList.Add("data/stage/sae_snow.xfbin");
                                break;
                            case 2:
                                StageInfo[x].PathList.Add("data/stage/sae_rain.xfbin");
                                break;
                        }
                    }
                    listBox1.Items[x] = StageInfo[x].StageName;
                    MessageBox.Show("Settings were saved!");
                }


            } else {
                MessageBox.Show("Open StageInfo file first!");
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x != -1) {
                    StageInfo.RemoveAt(x);
                    listBox1.Items.RemoveAt(x);
                    listBox1.SelectedIndex = x - 1;
                    EntryCount--;
                }

            } else {
                MessageBox.Show("Open StageInfo file first!");
            }
        }

        private void button9_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                if (CopiedProperties != null) {
                    CopiedProperties.StageName = (string)StageInfo[x].StageName.DeepClone();
                    CopiedProperties.Stage_c_sta_xx = (string)StageInfo[x].Stage_c_sta_xx.DeepClone();
                    CopiedProperties.Stage_BTL = (string)StageInfo[x].Stage_BTL.DeepClone();



                    CopiedProperties.ObjectList = StageInfo[x].ObjectList.DeepClone();
                    CopiedProperties.PathList = StageInfo[x].PathList.DeepClone();
                    StageInfo[x] = CopiedProperties;
                    if (listBox1.Items.Count > 1) {
                        listBox1.SelectedIndex = 0;
                        listBox1.SelectedIndex = x;
                    }

                    for (int c = 0; c < StageInfo[x].PathList.Count; c++) {
                        if (StageInfo[x].PathList[c].Contains("lensFlare") || StageInfo[x].PathList[c].Contains("sae_snow") || StageInfo[x].PathList[c].Contains("sae_rain")) {
                            StageInfo[x].PathList.RemoveAt(c);
                            c--;
                        }
                    }
                    if (StageInfo[x].EnableLensFlare) {
                        StageInfo[x].PathList.Add("data/stage/lensFlare/" + comboBox2.Items[StageInfo[x].LensFlareType + 1].ToString() + ".xfbin");
                    }
                    if (StageInfo[x].Weather != 0) {
                        switch (StageInfo[x].Weather) {
                            case 1:
                                StageInfo[x].PathList.Add("data/stage/sae_snow.xfbin");
                                break;
                            case 2:
                                StageInfo[x].PathList.Add("data/stage/sae_rain.xfbin");
                                break;
                        }
                    }
                    MessageBox.Show("Properties were pasted!");
                }
            } else
                MessageBox.Show("Select Stage before that!");
        }

        private void button8_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                CopiedProperties = StageInfo[x].DeepClone();
                MessageBox.Show("Properties were copied!");
            } else
                MessageBox.Show("Select Stage before that!");
        }

        private void button17_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count) {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4] {SunShaftColor[3],SunShaftColor[2], SunShaftColor[1],0x00};
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK) {
                        byte[] ColorReverse = new byte[4] {MyDialog.Color.A,MyDialog.Color.B,MyDialog.Color.G,MyDialog.Color.R};
                        SunShaftColor = Main.b_ReplaceBytes(SunShaftColor, ColorReverse, 0, 0);
                    };
                } else {
                    MessageBox.Show("No stage selected...", "Warning");
                }

            } else {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button10_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count) {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4] { PlayerAmbientColor[3], PlayerAmbientColor[2], PlayerAmbientColor[1], 0x00 };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK) {
                        byte[] ColorReverse = new byte[4] { MyDialog.Color.A, MyDialog.Color.B, MyDialog.Color.G, MyDialog.Color.R };
                        PlayerAmbientColor = Main.b_ReplaceBytes(PlayerAmbientColor, ColorReverse, 0, 0);
                    };
                } else {
                    MessageBox.Show("No stage selected...", "Warning");
                }

            } else {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button11_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count) {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4] { RayCutOffShadeColor[3], RayCutOffShadeColor[2], RayCutOffShadeColor[1], 0x00 };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK) {
                        byte[] ColorReverse = new byte[4] { MyDialog.Color.A, MyDialog.Color.B, MyDialog.Color.G, MyDialog.Color.R };
                        RayCutOffShadeColor = Main.b_ReplaceBytes(RayCutOffShadeColor, ColorReverse, 0, 0);
                    };
                } else {
                    MessageBox.Show("No stage selected...", "Warning");
                }

            } else {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button12_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count) {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4] { EffectAmbientColor[3], EffectAmbientColor[2], EffectAmbientColor[1], 0x00 };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK) {
                        byte[] ColorReverse = new byte[4] { MyDialog.Color.A, MyDialog.Color.B, MyDialog.Color.G, MyDialog.Color.R };
                        EffectAmbientColor = Main.b_ReplaceBytes(EffectAmbientColor, ColorReverse, 0, 0);
                    };
                } else {
                    MessageBox.Show("No stage selected...", "Warning");
                }

            } else {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button13_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count) {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4] { ParallelAmbientColor[3], ParallelAmbientColor[2], ParallelAmbientColor[1], 0x00 };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK) {
                        byte[] ColorReverse = new byte[4] { MyDialog.Color.A, MyDialog.Color.B, MyDialog.Color.G, MyDialog.Color.R };
                        ParallelAmbientColor = Main.b_ReplaceBytes(ParallelAmbientColor, ColorReverse, 0, 0);
                    };
                } else {
                    MessageBox.Show("No stage selected...", "Warning");
                }

            } else {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button14_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count) {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4] { RayCutOffNormalColor[3], RayCutOffNormalColor[2], RayCutOffNormalColor[1], 0x00 };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK) {
                        byte[] ColorReverse = new byte[4] { MyDialog.Color.A, MyDialog.Color.B, MyDialog.Color.G, MyDialog.Color.R };
                        RayCutOffNormalColor = Main.b_ReplaceBytes(RayCutOffNormalColor, ColorReverse, 0, 0);
                    };
                } else {
                    MessageBox.Show("No stage selected...", "Warning");
                }

            } else {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button18_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count) {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4] { RockColor[3], RockColor[2], RockColor[1], 0x00 };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK) {
                        byte[] ColorReverse = new byte[4] { MyDialog.Color.A, MyDialog.Color.B, MyDialog.Color.G, MyDialog.Color.R };
                        RockColor = Main.b_ReplaceBytes(RockColor, ColorReverse, 0, 0);
                    };
                } else {
                    MessageBox.Show("No stage selected...", "Warning");
                }

            } else {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button16_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count) {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4] { FogColor[3], FogColor[2], FogColor[1], 0x00 };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK) {
                        byte[] ColorReverse = new byte[4] { MyDialog.Color.A, MyDialog.Color.B, MyDialog.Color.G, MyDialog.Color.R };
                        FogColor = Main.b_ReplaceBytes(FogColor, ColorReverse, 0, 0);
                    };
                } else {
                    MessageBox.Show("No stage selected...", "Warning");
                }

            } else {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button15_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count) {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4] { ShadowColor[3], ShadowColor[2], ShadowColor[1], 0x00 };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK) {
                        byte[] ColorReverse = new byte[4] { MyDialog.Color.A, MyDialog.Color.B, MyDialog.Color.G, MyDialog.Color.R };
                        ShadowColor = Main.b_ReplaceBytes(ShadowColor, ColorReverse, 0, 0);
                    };
                } else {
                    MessageBox.Show("No stage selected...", "Warning");
                }

            } else {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (textBox4.Text != "") {
                bool looped = false;
                int x = listBox1.SelectedIndex + 1;
                if (listBox1.SelectedIndex == listBox1.Items.Count || listBox1.SelectedIndex == -1)
                    x = 0;
                for (int c = x; c < listBox1.Items.Count; c++) {
                    if (listBox1.Items[c].ToString().Contains(textBox4.Text)) {
                        listBox1.SelectedIndex = c;
                        return;
                    }
                    if (c == listBox1.Items.Count - 1 && looped == false) {
                        looped = true;
                        c = -1;
                    }

                }
                MessageBox.Show("Couldn't find entry with that text");
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
            if (basepath == "")
                s.ShowDialog();
            else
                s.FileName = basepath;
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
            byte[] fileBytes36 = new byte[0];
            int SectionTotalLength = 0;
            fileBytes36 = header;
            int LengthOfStuff = 0;
            for (int y = 0; y < EntryCount; y++) {
                LengthOfStuff = LengthOfStuff + 0x130;
                for (int x2 = 0; x2 < StageInfo[y].PathList.Count; x2++) {
                    LengthOfStuff = 0x130 + LengthOfStuff + 8 + 8 + StageInfo[y].PathList[x2].Length;
                }
            }
            for (int x = 0; x < EntryCount; x++) {
                fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[0x130]);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].PathList.Count), fileBytes36.Length - 0x118);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].ObjectList.Count), fileBytes36.Length - 0x108);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].Weather), fileBytes36.Length - 0xF8);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, StageInfo[x].PlayerAmbientColor, fileBytes36.Length - 0xF4);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, StageInfo[x].RayCutOffShadeColor, fileBytes36.Length - 0xF0);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, StageInfo[x].EffectAmbientColor, fileBytes36.Length - 0xEC);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, StageInfo[x].UnknownColor, fileBytes36.Length - 0xE8);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].EnableLensFlare), fileBytes36.Length - 0xD8);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].LensFlareType), fileBytes36.Length - 0xD4);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].LensFlare_X_Direction), fileBytes36.Length - 0xD0);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].LensFlare_Y_Direction), fileBytes36.Length - 0xCC);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].LensFlare_Z_Direction), fileBytes36.Length - 0xC8);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].LensFlare_Alpha), fileBytes36.Length - 0xC4);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, StageInfo[x].ParallelAmbientColor, fileBytes36.Length - 0xC0);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, StageInfo[x].RayCutOffNormalColor, fileBytes36.Length - 0xBC);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].LightPoint_X_Direction), fileBytes36.Length - 0xB8);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].LightPoint_Y_Direction), fileBytes36.Length - 0xB4);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].LightPoint_Z_Direction), fileBytes36.Length - 0xB0);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].EnableShadowColor), fileBytes36.Length - 0xAC);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, StageInfo[x].ShadowColor, fileBytes36.Length - 0xA8);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].EnableFog), fileBytes36.Length - 0xA4);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].FogStartDistance), fileBytes36.Length - 0xA0);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].FogEndDistance), fileBytes36.Length - 0x9C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].FogStrength), fileBytes36.Length - 0x98);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, StageInfo[x].FogColor, fileBytes36.Length - 0x94);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].EnableMonoColorFilter), fileBytes36.Length - 0x90);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].MonoColor_Blue), fileBytes36.Length - 0x8C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].MonoColor_Red), fileBytes36.Length - 0x88);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].MonoColor_Alpha), fileBytes36.Length - 0x84);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].EnableGlareEffects), fileBytes36.Length - 0x80);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].GlareLuminanceThreshold), fileBytes36.Length - 0x7C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].GlareSubtracted), fileBytes36.Length - 0x78);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].GlareCompositionStrength), fileBytes36.Length - 0x74);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].EnableSoftFocus), fileBytes36.Length - 0x6C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].SoftFocusStrength), fileBytes36.Length - 0x68);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].EnableDOF_Blur), fileBytes36.Length - 0x64);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].DOF_FocalLength), fileBytes36.Length - 0x60);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].DOF_ShortDistance), fileBytes36.Length - 0x5C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].DOF_LongDistance), fileBytes36.Length - 0x58);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].DOF_Alpha), fileBytes36.Length - 0x54);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].EnableDOF_EdgeBlur), fileBytes36.Length - 0x50);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].EnableSunShaft), fileBytes36.Length - 0x4C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].SunShaft_StartDistance), fileBytes36.Length - 0x48);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].SunShaft_EndDistance), fileBytes36.Length - 0x44);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].SunShaft_Alpha), fileBytes36.Length - 0x40);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, StageInfo[x].SunShaftColor, fileBytes36.Length - 0x3C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].SunShaft_Source_X_Direction), fileBytes36.Length - 0x38);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].SunShaft_Source_Y_Direction), fileBytes36.Length - 0x34);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].SunShaft_Source_Z_Direction), fileBytes36.Length - 0x30);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].SunShaft_BlurWidth), fileBytes36.Length - 0x2C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].SunShaft_AttenuationCoefficient), fileBytes36.Length - 0x28);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, StageInfo[x].RockColor, fileBytes36.Length - 0x24);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(LengthOfStuff), fileBytes36.Length - 0x100);
                SectionTotalLength = SectionTotalLength + 0x130;
            };
            int LengthFromSection = 0;
            int extra = 0;
            int TotalLengthOfMeshes = 0;
            for (int x = 0; x < EntryCount; x++) {
                int LengthFromPath = 0;
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes((EntryCount * 0x130) - 0x20 - (x * 0x130) + LengthFromSection + extra), FilePos + 0x10 + 0x20 + (x * 0x130));
                extra = extra + 8 * StageInfo[x].PathList.Count;
                for (int x2 = 0; x2 < StageInfo[x].PathList.Count; x2++) {
                    LengthFromSection = LengthFromSection + StageInfo[x].PathList[x2].Length + 8;
                }
                for (int x2 = 0; x2 < StageInfo[x].PathList.Count; x2++) {
                    int _ptr = fileBytes36.Length;
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(LengthFromPath + 8 * StageInfo[x].PathList.Count), _ptr);
                    LengthFromPath = LengthFromPath + StageInfo[x].PathList[x2].Length;
                }
                for (int x2 = 0; x2 < StageInfo[x].PathList.Count; x2++) {
                    fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].PathList[x2]);
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
                }
            }
            int _ptrMeshes = fileBytes36.Length;
            for (int x = 0; x < EntryCount; x++) {
                for (int x2 = 0; x2 < StageInfo[x].ObjectList.Count; x2++) {
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[0xB0] { Convert.ToByte(x), Convert.ToByte(x2), 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
                    TotalLengthOfMeshes = TotalLengthOfMeshes + 0xB0;
                }
            }
            int _ptrLastSection = 0;
            for (int x = 0; x < EntryCount; x++) {

                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(_ptrMeshes - header.Length - 0x30 - (x * 0x130) + _ptrLastSection), header.Length + 0x30 + (x * 0x130));

                for (int x3 = 0; x3 < StageInfo[x].ObjectList.Count; x3++) {
                    _ptrLastSection = _ptrLastSection + 0xB0;
                }
            }
            int TotalLengthOfSection = 0;
            int TotalLengthOfLoadedPaths = 0;
            for (int x = 0; x < EntryCount; x++) {
                for (int x2 = 0; x2 < StageInfo[x].ObjectList.Count; x2++) {
                    //path
                    fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].ObjectList[x2].PathString);
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection), _ptrMeshes + TotalLengthOfSection);
                    TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + StageInfo[x].ObjectList[x2].PathString.Length + 4;
                    //mesh
                    fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].ObjectList[x2].MeshString);
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x08), _ptrMeshes + 0x08 + TotalLengthOfSection);
                    TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + StageInfo[x].ObjectList[x2].MeshString.Length + 4;
                    //dmypath
                    //if (SecondarySectionPositionFilePath[x][x2].Length > 1) //BIG BRAIN CC2 MADE IT BUG CAMERA VALUE IF YOU DONT USING IT ALL TIME
                    // {
                    fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].ObjectList[x2].PathDmyString);
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x10), _ptrMeshes + 0x10 + TotalLengthOfSection);
                    TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + StageInfo[x].ObjectList[x2].PathDmyString.Length + 4;
                    //}
                    //else
                    //{
                    //    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x10 + TotalLengthOfSection);
                    //}
                    //dmypos
                    //if (SecondarySectionPosition[x][x2].Length > 1 && SecondarySectionPositionFilePath[x][x2].Length > 1)
                    //{
                    fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].ObjectList[x2].DmyString);
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x18), _ptrMeshes + 0x18 + TotalLengthOfSection);
                    TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + StageInfo[x].ObjectList[x2].DmyString.Length + 4;
                    //}
                    //else
                    //{
                    //    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x18 + TotalLengthOfSection);
                    //}
                    //TypeSection
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].ObjectList[x2].TypeSection), _ptrMeshes + 0x20 + TotalLengthOfSection);
                    //Speed of animation
                    if (StageInfo[x].ObjectList[x2].TypeSection != 00 && StageInfo[x].ObjectList[x2].TypeSection != 04) {
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].ObjectList[x2].AnimationSpeed), _ptrMeshes + 0x24 + TotalLengthOfSection);
                    } else {
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x24 + TotalLengthOfSection);
                    }
                    //Camera value
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].ObjectList[x2].CameraValue), _ptrMeshes + 0x28 + TotalLengthOfSection);
                    //RigidBody value
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].ObjectList[x2].MysteriousValue), _ptrMeshes + 0x2C + TotalLengthOfSection);
                    //Breakable object
                    if (StageInfo[x].ObjectList[x2].TypeSection == 0x0B) {
                        //path
                        fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].ObjectList[x2].BreakableObject_path);
                        fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x38), _ptrMeshes + 0x38 + TotalLengthOfSection);
                        TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + StageInfo[x].ObjectList[x2].BreakableObject_path.Length + 4;

                        if (StageInfo[x].ObjectList[x2].BreakableObject_Effect01.Length > 1 && StageInfo[x].ObjectList[x2].BreakableObject_path.Length > 1) {
                            //effect1
                            fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].ObjectList[x2].BreakableObject_Effect01);
                            fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x40), _ptrMeshes + 0x40 + TotalLengthOfSection);
                            TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + StageInfo[x].ObjectList[x2].BreakableObject_Effect01.Length + 4;

                            //effect1_speed
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].ObjectList[x2].BreakableObject_Speed01), _ptrMeshes + 0x48 + TotalLengthOfSection);
                        } else {
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x40 + TotalLengthOfSection);
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x48 + TotalLengthOfSection);
                        }
                        if (StageInfo[x].ObjectList[x2].BreakableObject_Effect02.Length > 1 && StageInfo[x].ObjectList[x2].BreakableObject_path.Length > 1) {
                            //effect2
                            fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].ObjectList[x2].BreakableObject_Effect02);
                            fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x50), _ptrMeshes + 0x50 + TotalLengthOfSection);
                            TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + StageInfo[x].ObjectList[x2].BreakableObject_Effect02.Length + 4;

                            //effect2_speed
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].ObjectList[x2].BreakableObject_Speed02), _ptrMeshes + 0x58 + TotalLengthOfSection);
                        } else {
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x50 + TotalLengthOfSection);
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x58 + TotalLengthOfSection);
                        }
                        if (StageInfo[x].ObjectList[x2].BreakableObject_Effect03.Length > 1 && StageInfo[x].ObjectList[x2].BreakableObject_path.Length > 1) {
                            //effect3
                            fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].ObjectList[x2].BreakableObject_Effect03);
                            fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x60), _ptrMeshes + 0x60 + TotalLengthOfSection);
                            TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + StageInfo[x].ObjectList[x2].BreakableObject_Effect03.Length + 4;

                            //effect3_speed
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].ObjectList[x2].BreakableObject_Speed03), _ptrMeshes + 0x68 + TotalLengthOfSection);
                        } else {
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x60 + TotalLengthOfSection);
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x68 + TotalLengthOfSection);
                        }

                    } else {
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x38 + TotalLengthOfSection);
                    }
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0x3C), _ptrMeshes + 0x70 + TotalLengthOfSection);
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0x78), _ptrMeshes + 0x74 + TotalLengthOfSection);
                    //const_values
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].ObjectList[x2].ConstBreakableWallValue1), _ptrMeshes + 0x80 + TotalLengthOfSection);
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].ObjectList[x2].ConstBreakableWallValue2), _ptrMeshes + 0x84 + TotalLengthOfSection);

                    //breakable wall
                    if (StageInfo[x].ObjectList[x2].TypeSection == 7) {
                        //effect1
                        fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].ObjectList[x2].BreakableWall_Effect01);
                        fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x78), _ptrMeshes + 0x78 + TotalLengthOfSection);
                        TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + StageInfo[x].ObjectList[x2].BreakableWall_Effect01.Length + 4;

                        //const_values
                        //fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondaryConstBreakableWallValue1[x][x2]), _ptrMeshes + 0x80 + TotalLengthOfSection);
                        //fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondaryConstBreakableWallValue2[x][x2]), _ptrMeshes + 0x84 + TotalLengthOfSection);

                        //effect2
                        fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].ObjectList[x2].BreakableWall_Effect02);
                        fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x88), _ptrMeshes + 0x88 + TotalLengthOfSection);
                        TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + StageInfo[x].ObjectList[x2].BreakableWall_Effect02.Length + 4;

                        //effect3
                        fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].ObjectList[x2].BreakableWall_Effect03);
                        fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x90), _ptrMeshes + 0x90 + TotalLengthOfSection);
                        TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + StageInfo[x].ObjectList[x2].BreakableWall_Effect03.Length + 4;

                        //sound_volume
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(StageInfo[x].ObjectList[x2].BreakableWall_volume), _ptrMeshes + 0x98 + TotalLengthOfSection);

                        //sound
                        fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].ObjectList[x2].BreakableWall_Sound);
                        fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0xA0), _ptrMeshes + 0xA0 + TotalLengthOfSection);
                        TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + StageInfo[x].ObjectList[x2].BreakableWall_Sound.Length + 4;

                    }
                    TotalLengthOfSection = TotalLengthOfSection + 0xB0;
                }
            }

            int NamePos = fileBytes36.Length - header.Length - 0x10;
            int _ptrName = header.Length;
            for (int x = 0; x < EntryCount; x++) {
                //StageName
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(NamePos + 0x10), _ptrName + (x * 0x130));
                fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].StageName);
                fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                NamePos = (NamePos + StageInfo[x].StageName.Length + 4);
                if (StageInfo[x].Stage_c_sta_xx.Length > 1) {
                    //c_sta_x
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(NamePos + 0x08), _ptrName + 0x08 + (x * 0x130));
                    fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].Stage_c_sta_xx);
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                    NamePos = (NamePos + StageInfo[x].Stage_c_sta_xx.Length + 4);
                } else {
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrName + 0x08 + (x * 0x130));
                }
                if (StageInfo[x].Stage_BTL.Length > 1) {
                    //BTL_NSX_XXXXX
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(NamePos), _ptrName + 0x10 + (x * 0x130));
                    fileBytes36 = Main.b_AddString(fileBytes36, StageInfo[x].Stage_BTL);
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                    NamePos = (NamePos + StageInfo[x].Stage_BTL.Length + 4);
                } else if (StageInfo[x].Stage_BTL.Length == 0) {
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(NamePos), _ptrName + 0x10 + (x * 0x130));
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                    NamePos = (NamePos + 4);

                }
                NamePos = NamePos - 0x130;
            }
            fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[0x14] { 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x02, 0x00, 0x79, 0x18, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00 });

            byte[] Size1 = BitConverter.GetBytes(fileBytes36.Length - header.Length - 0x4);
            byte[] Size2 = BitConverter.GetBytes(fileBytes36.Length - header.Length);
            byte[] Size1Reverse = new byte[4]
            {
                Size1[3],
                Size1[2],
                Size1[1],
                Size1[0]
            };
            byte[] Size2Reverse = new byte[4]
            {
                Size2[3],
                Size2[2],
                Size2[1],
                Size2[0]
            };
            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, Size1Reverse, header.Length - 0x14);
            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, Size2Reverse, header.Length - 0x20);

            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(EntryCount), header.Length - 0xC);
            return fileBytes36;
        }

        private void button22_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count) {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4] { UnknownColor[3], UnknownColor[2], UnknownColor[1], 0x00 };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK) {
                        byte[] ColorReverse = new byte[4] { MyDialog.Color.A, MyDialog.Color.B, MyDialog.Color.G, MyDialog.Color.R };
                        UnknownColor = Main.b_ReplaceBytes(UnknownColor, ColorReverse, 0, 0);
                    };
                } else {
                    MessageBox.Show("No stage selected...", "Warning");
                }

            } else {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }
        public void CopyFiles(string originalDataWin32, string newDataWin32) {
            if (File.Exists(originalDataWin32)) {
                if (!Directory.Exists(Path.GetDirectoryName(newDataWin32))) {
                    Directory.CreateDirectory(Path.GetDirectoryName(newDataWin32));
                }
                File.Copy(originalDataWin32, newDataWin32, true);
            }
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                string data_win32path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(FilePath)));
                Tool_StageInfoEditor_v2 stageInfoEditor = new Tool_StageInfoEditor_v2();
                stageInfoEditor.OpenFile(Directory.GetCurrentDirectory() + "\\systemFiles\\stageInfo.bin.empty.xfbin");

                stageInfoEditor.StageInfo.Add(StageInfo[x]);
                stageInfoEditor.EntryCount++;
                Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog c = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
                c.IsFolderPicker = true;

                if (c.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok) {
                    string stageModPath = c.FileName + "\\" + StageInfo[x].StageName + " - mod\\" + StageInfo[x].StageName + "\\";
                    if (!Directory.Exists(stageModPath)) {
                        Directory.CreateDirectory(stageModPath);
                    }
                    if (data_win32path.Contains("data_win32")) {
                        for (int v = 0; v < StageInfo[x].PathList.Count; v++) {
                            if (File.Exists(data_win32path + StageInfo[x].PathList[v].Replace("data/", "\\").Replace("/", "\\"))) {
                                CopyFiles(data_win32path + StageInfo[x].PathList[v].Replace("data/", "\\").Replace("/", "\\"), stageModPath + StageInfo[x].PathList[v].Replace("data/", "data_win32\\").Replace("/", "\\"));
                            }
                        }
                    }
                    if (!Directory.Exists(stageModPath + "data_win32\\stage\\WIN64\\")) {
                        Directory.CreateDirectory(stageModPath + "data_win32\\stage\\WIN64\\");
                    }
                    Directory.CreateDirectory(stageModPath + "moddingapi\\mods\\" + StageInfo[x].StageName);
                    stageInfoEditor.SaveFileAs(stageModPath + "data_win32\\stage\\WIN64\\stageInfo.bin.xfbin");
                    byte[] image = File.ReadAllBytes(Directory.GetCurrentDirectory() + "\\systemFiles\\stage_tex.png");
                    byte[] image_mod = File.ReadAllBytes(Directory.GetCurrentDirectory() + "\\systemFiles\\template_icon.png");
                    File.WriteAllBytes(stageModPath + "stage_tex.png", image);
                    File.WriteAllText(stageModPath + "BGM_ID.txt", "69");
                    List<string> lang = new List<string> {
                        "arae=Stage without name",
                        "chi=Stage without name",
                        "eng=Stage without name",
                        "esmx=Stage without name",
                        "fre=Stage without name",
                        "ger=Stage without name",
                        "ita=Stage without name",
                        "kokr=Stage without name",
                        "pol=Stage without name",
                        "por=Stage without name",
                        "rus=Карта без названия",
                        "spa=Stage without name"
                    };
                    File.WriteAllLines(stageModPath + "stageMessage.txt", lang.ToArray());
                    File.WriteAllText(c.FileName + "\\" + StageInfo[x].StageName + " - mod\\" + "Author.txt", "Unknown");
                    File.WriteAllText(c.FileName + "\\" + StageInfo[x].StageName + " - mod\\" + "ModdingAPI.txt", "true");
                    File.WriteAllText(c.FileName + "\\" + StageInfo[x].StageName + " - mod\\" + "Description.txt", "");
                    File.WriteAllBytes(c.FileName + "\\" + StageInfo[x].StageName + " - mod\\" + "Icon.png", image_mod);
                    MessageBox.Show(StageInfo[x].StageName + " was exported successfully!");
                }
            } else {
                MessageBox.Show("Select stage which you want to export");
            }
        }

        private void Tool_StageInfoEditor_v2_Load(object sender, EventArgs e) {
            if (File.Exists(Main.stageInfoPath) == true) {
                OpenFile(Main.stageInfoPath);
            }
        }
    }

    
}
