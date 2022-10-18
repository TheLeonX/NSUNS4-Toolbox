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

namespace NSUNS4_Character_Manager.Misc
{
    public partial class Tool_StageInfoEditor : Form
    {
        public Tool_StageInfoEditor()
        {
            InitializeComponent();
            for (int x = 0; x < Program.lensFlareList.Length; x++) LensFlare_combobox.Items.Add(Program.lensFlareList[x]);
            for (int x = 0; x < Program.YesNoList.Length; x++) Camera_list_combobox.Items.Add(Program.YesNoList[x]);
            for (int x = 0; x < Program.TypeSectionList.Length; x++) TypeEntry_combobox.Items.Add(Program.TypeSectionList[x]);
        }
        public byte[] fileBytes = new byte[0];
        public byte[] header = new byte[0];
        public bool FileOpen = false;
        public string FilePath = "";
        public int EntryCount = 0;
        public List<byte[]> MainStageSection = new List<byte[]>();
        public int FilePos = 0;
        public List<string> StageNameList = new List<string>();
        public List<string> c_sta_List = new List<string>();
        public List<string> BTL_NSX_List = new List<string>();
        public List<int> CountOfFiles = new List<int>();
        public List<int> CountOfMeshes =new List<int>();
        public List<int> MainSection_WeatherSettings = new List<int>();
        public List<int> MainSection_lensFlareSettings = new List<int>();
        public List<int> MainSection_EnablelensFlareSettings = new List<int>();
        public List<float> MainSection_X_PositionLightPoint = new List<float>();
        public List<float> MainSection_Y_PositionLightPoint = new List<float>();
        public List<float> MainSection_Z_PositionLightPoint = new List<float>();
        public List<float> MainSection_X_PositionShadow = new List<float>();
        public List<float> MainSection_Y_PositionShadow = new List<float>();
        public List<float> MainSection_Z_PositionShadow = new List<float>();
        public List<float> MainSection_unk1 = new List<float>();
        public List<int> MainSection_ShadowSetting_value1 = new List<int>();
        public List<int> MainSection_ShadowSetting_value2 = new List<int>();
        public List<float> MainSection_PowerLight = new List<float>();
        public List<float> MainSection_PowerSkyColor = new List<float>();
        public List<float> MainSection_PowerGlare = new List<float>();
        public List<float> MainSection_blur = new List<float>();
        public List<float> MainSection_X_PositionGlarePoint = new List<float>();
        public List<float> MainSection_Y_PositionGlarePoint = new List<float>();
        public List<float> MainSection_Z_PositionGlarePoint = new List<float>();
        public List<float> MainSectionGlareVagueness = new List<float>();
        public List<byte[]> MainSection_ColorGlare = new List<byte[]>();
        public List<byte[]> MainSection_ColorSky = new List<byte[]>();
        public List<byte[]> MainSection_ColorRock = new List<byte[]>();
        public List<byte[]> MainSection_ColorGroundEffect = new List<byte[]>();
        public List<byte[]> MainSection_ColorPlayerLight = new List<byte[]>();
        public List<byte[]> MainSection_ColorLight = new List<byte[]>();
        public List<byte[]> MainSection_ColorShadow = new List<byte[]>();
        public List<byte[]> MainSection_ColorUnknown = new List<byte[]>();
        public List<byte[]> MainSection_ColorUnknown2 = new List<byte[]>();
        public List<int> MainSection_EnableGlareSettingValue1 = new List<int>();
        public List<int> MainSection_EnableGlareSettingValue2 = new List<int>();
        public List<int> MainSection_EnableGlareSettingValue3 = new List<int>();
        public List<bool> GlareEnabled = new List<bool>();
        public List<float> MainSection_X_MysteriousPosition = new List<float>();
        public List<float> MainSection_Y_MysteriousPosition = new List<float>();
        public List<float> MainSection_Z_MysteriousPosition = new List<float>();
        public List<float> MainSection_MysteriousGlareValue1 = new List<float>();
        public List<float> MainSection_MysteriousGlareValue2 = new List<float>();
        public List<float> MainSection_MysteriousGlareValue3 = new List<float>();
        public List<float> MainSection_UnknownValue1 = new List<float>();
        public List<float> MainSection_UnknownValue2 = new List<float>();
        public List<float> MainSection_UnknownValue3 = new List<float>();
        public List<List<byte[]>> SecondaryStageSection = new List<List<byte[]>>();
        public List<List<string>> SecondarySectionFilePath = new List<List<string>>();
        public List<int> One_SecondarySectionFilePath = new List<int>();
        public List<int> One_SecondarySectionLoadPath = new List<int>();
        public List<int> One_SecondarySectionCameraValue = new List<int>();
        public List<int> One_SecondarySectionMysteriousValue = new List<int>();
        public List<string> One_SecondarySectionFilePathString = new List<string>();
        public List<string> One_SecondarySectionLoadPathString = new List<string>();
        public List<string> One_SecondarySectionLoadMeshString = new List<string>();
        public List<string> One_SecondarySectionLoadPathDmyString = new List<string>();
        public List<string> One_SecondarySectionLoadDmyString = new List<string>();
        public List<string> One_SecondaryTypeBreakableWall_Effect01 = new List<string>();
        public List<string> One_SecondaryTypeBreakableWall_Effect02 = new List<string>();
        public List<string> One_SecondaryTypeBreakableWall_Effect03 = new List<string>();
        public List<string> One_SecondaryTypeBreakableWall_Sound = new List<string>();
        public List<string> One_SecondaryTypeBreakableObject_Effect01 = new List<string>();
        public List<string> One_SecondaryTypeBreakableObject_Effect02 = new List<string>();
        public List<string> One_SecondaryTypeBreakableObject_Effect03 = new List<string>();
        public List<string> One_SecondaryTypeBreakableObject_path = new List<string>();
        public List<int> One_SecondaryTypeSection = new List<int>();
        public List<int> One_SecondaryConst3C = new List<int>();
        public List<int> One_SecondaryConst78 = new List<int>();
        public List<int> One_SecondaryConstBreakableWallValue1 = new List<int>();
        public List<int> One_SecondaryConstBreakableWallValue2 = new List<int>();
        public List<float> One_SecondaryTypeAnimationSection_speed = new List<float>();
        public List<List<string>> SecondarySectionLoadPath = new List<List<string>>();
        public List<List<string>> SecondarySectionLoadMesh = new List<List<string>>();
        public List<List<string>> SecondarySectionPositionFilePath = new List<List<string>>();
        public List<List<string>> SecondarySectionPosition = new List<List<string>>();
        public List<List<int>> SecondaryTypeSection = new List<List<int>>();
        public List<List<float>> SecondaryTypeAnimationSection_speed = new List<List<float>>();
        public List<List<int>> SecondarySectionCameraValue = new List<List<int>>();
        public List<List<int>> SecondarySectionMysteriousValue = new List<List<int>>();
        public List<List<int>> SecondaryConst3C = new List<List<int>>();
        public List<List<int>> SecondaryConst78 = new List<List<int>>();
        public List<List<int>> SecondaryConstBreakableWallValue1 = new List<List<int>>();
        public List<List<int>> SecondaryConstBreakableWallValue2 = new List<List<int>>();
        public List<List<string>> SecondaryTypeBreakableWall_Effect01 = new List<List<string>>();
        public List<List<string>> SecondaryTypeBreakableWall_Effect02 = new List<List<string>>();
        public List<List<string>> SecondaryTypeBreakableWall_Effect03 = new List<List<string>>();
        public List<List<string>> SecondaryTypeBreakableWall_Sound = new List<List<string>>();
        public List<List<string>> SecondaryTypeBreakableObject_Effect01 = new List<List<string>>();
        public List<List<string>> SecondaryTypeBreakableObject_Effect02 = new List<List<string>>();
        public List<List<string>> SecondaryTypeBreakableObject_Effect03 = new List<List<string>>();
        public List<List<string>> SecondaryTypeBreakableObject_path = new List<List<string>>();
        public List<float> One_SecondaryTypeBreakableObject_Speed01 = new List<float>();
        public List<float> One_SecondaryTypeBreakableObject_Speed02 = new List<float>();
        public List<float> One_SecondaryTypeBreakableObject_Speed03 = new List<float>();
        public List<float> One_SecondaryTypeBreakableWall_volume = new List<float>();
        public List<List<float>> SecondaryTypeBreakableObject_Speed01 = new List<List<float>>();
        public List<List<float>> SecondaryTypeBreakableObject_Speed02 = new List<List<float>>();
        public List<List<float>> SecondaryTypeBreakableObject_Speed03 = new List<List<float>>();
        public List<List<float>> SecondaryTypeBreakableWall_volume = new List<List<float>>();

        public float copied_MainSection_X_MysteriousPosition = 0;
        public float copied_MainSection_Y_MysteriousPosition = 0;
        public float copied_MainSection_Z_MysteriousPosition = 0;
        public float copied_MainSection_X_PositionGlarePoint = 0;
        public float copied_MainSection_Y_PositionGlarePoint = 0;
        public float copied_MainSection_Z_PositionGlarePoint = 0;
        public float copied_MainSection_X_PositionLightPoint = 0;
        public float copied_MainSection_Y_PositionLightPoint = 0;
        public float copied_MainSection_Z_PositionLightPoint = 0;
        public float copied_MainSection_X_PositionShadow = 0;
        public float copied_MainSection_Y_PositionShadow = 0;
        public float copied_MainSection_Z_PositionShadow = 0;
        public float copied_MainSection_PowerGlare = 0;
        public float copied_MainSection_blur = 0;
        public float copied_MainSection_unk1 = 0;
        public float copied_MainSection_PowerLight = 0;
        public float copied_MainSectionGlareVagueness = 0;
        public float copied_MainSection_MysteriousGlareValue1 = 0;
        public float copied_MainSection_MysteriousGlareValue2 = 0;
        public float copied_MainSection_MysteriousGlareValue3 = 0;
        public float copied_MainSection_UnknownValue1 = 0;
        public float copied_MainSection_UnknownValue2 = 0;
        public float copied_MainSection_UnknownValue3 = 0;
        public float copied_MainSection_PowerSkyColor = 0;
        public byte[] copied_MainSection_ColorGlare = new byte[4] { 00, 00, 00, 00 };
        public byte[] copied_MainSection_ColorSky = new byte[4] { 00, 00, 00, 00 };
        public byte[] copied_MainSection_ColorRock = new byte[4] { 00, 00, 00, 00 };
        public byte[] copied_MainSection_ColorGroundEffect = new byte[4] { 00, 00, 00, 00 };
        public byte[] copied_MainSection_ColorPlayerLight = new byte[4] { 00, 00, 00, 00 };
        public byte[] copied_MainSection_ColorLight = new byte[4] { 00, 00, 00, 00 };
        public byte[] copied_MainSection_ColorShadow = new byte[4] { 00, 00, 00, 00 };
        public byte[] copied_MainSection_ColorUnknown = new byte[4] { 00, 00, 00, 00 };
        public byte[] copied_MainSection_ColorUnknown2 = new byte[4] { 00, 00, 00, 00 };
        public int copied_MainSection_WeatherSettings = 0;
        public int copied_MainSection_lensFlareSettings = 0;
        public int copied_MainSection_EnablelensFlareSettings = 0;
        public int copied_MainSection_EnableGlareSettingValue1 = 0;
        public int copied_MainSection_EnableGlareSettingValue2 = 0;
        public int copied_MainSection_EnableGlareSettingValue3 = 0;
        public int copied_MainSection_ShadowSetting_value1 = 0;
        public int copied_MainSection_ShadowSetting_value2 = 0;
        public bool copied_settings = false;



        public void ClearFile()
        {
            FileOpen = false;
            FilePath = "";
            EntryCount = 0;
            MainStageSection = new List<byte[]>();
            FilePos = 0;
            StageNameList = new List<string>();
            c_sta_List = new List<string>();
            BTL_NSX_List = new List<string>();
            CountOfFiles = new List<int>();
            CountOfMeshes =new List<int>();
            MainSection_ColorUnknown = new List<byte[]>();
            MainSection_unk1 = new List<float>();
            MainSection_ColorUnknown2 = new List<byte[]>();
            MainSection_ColorSky = new List<byte[]>();
            MainSection_WeatherSettings = new List<int>();
            MainSection_lensFlareSettings = new List<int>();
            copied_MainSection_ShadowSetting_value1 = 0;
            copied_MainSection_ShadowSetting_value2 = 0;
            MainSection_EnablelensFlareSettings = new List<int>();
            MainSection_ColorGroundEffect = new List<byte[]>();
            MainSection_ColorPlayerLight = new List<byte[]>();
            MainSection_X_PositionLightPoint = new List<float>();
            MainSection_Y_PositionLightPoint = new List<float>();
            MainSection_Z_PositionLightPoint = new List<float>();
            MainSection_ColorLight = new List<byte[]>();
            MainSection_X_PositionShadow = new List<float>();
            MainSection_Y_PositionShadow = new List<float>();
            MainSection_Z_PositionShadow = new List<float>();
            MainSection_ShadowSetting_value1 = new List<int>();
            MainSection_ColorShadow = new List<byte[]>();
            MainSection_ShadowSetting_value2 = new List<int>();
            MainSection_PowerLight = new List<float>();
            MainSection_PowerGlare = new List<float>();
            MainSection_blur = new List<float>();
            MainSection_X_PositionGlarePoint = new List<float>();
            MainSection_Y_PositionGlarePoint = new List<float>();
            MainSection_Z_PositionGlarePoint = new List<float>();
            MainSectionGlareVagueness = new List<float>();
            MainSection_ColorGlare = new List<byte[]>();
            MainSection_ColorRock = new List<byte[]>();
            MainSection_EnableGlareSettingValue1 = new List<int>();
            MainSection_EnableGlareSettingValue2 = new List<int>();
            MainSection_EnableGlareSettingValue3 = new List<int>();
            GlareEnabled = new List<bool>();
            MainSection_X_MysteriousPosition = new List<float>();
            MainSection_Y_MysteriousPosition = new List<float>();
            MainSection_Z_MysteriousPosition = new List<float>();
            MainSection_MysteriousGlareValue1 = new List<float>();
            MainSection_MysteriousGlareValue2 = new List<float>();
            MainSection_MysteriousGlareValue3 = new List<float>();
            MainSection_UnknownValue1 = new List<float>();
            MainSection_UnknownValue2 = new List<float>();
            MainSection_UnknownValue3 = new List<float>();
            SecondaryStageSection = new List<List<byte[]>>();
            SecondarySectionFilePath = new List<List<string>>();
            One_SecondarySectionFilePath = new List<int>();
            One_SecondarySectionLoadPath = new List<int>();
            One_SecondarySectionCameraValue = new List<int>();
            One_SecondarySectionMysteriousValue = new List<int>();
            One_SecondarySectionFilePathString = new List<string>();
            One_SecondarySectionLoadPathString = new List<string>();
            One_SecondarySectionLoadMeshString = new List<string>();
            One_SecondarySectionLoadPathDmyString = new List<string>();
            One_SecondarySectionLoadDmyString = new List<string>();
            One_SecondaryTypeBreakableWall_Effect01 = new List<string>();
            One_SecondaryTypeBreakableWall_Effect02 = new List<string>();
            One_SecondaryTypeBreakableWall_Effect03 = new List<string>();
            One_SecondaryTypeBreakableWall_Sound = new List<string>();
            One_SecondaryTypeBreakableObject_Effect01 = new List<string>();
            One_SecondaryTypeBreakableObject_Effect02 = new List<string>();
            One_SecondaryTypeBreakableObject_Effect03 = new List<string>();
            One_SecondaryTypeBreakableObject_path = new List<string>();
            MainSection_PowerSkyColor = new List<float>();
            One_SecondaryTypeSection = new List<int>();
            One_SecondaryConst3C = new List<int>();
            One_SecondaryConst78 = new List<int>();
            One_SecondaryConstBreakableWallValue1 = new List<int>();
            One_SecondaryConstBreakableWallValue2 = new List<int>();
            One_SecondaryTypeAnimationSection_speed = new List<float>();
            SecondarySectionLoadPath = new List<List<string>>();
            SecondarySectionLoadMesh = new List<List<string>>();
            SecondarySectionPositionFilePath = new List<List<string>>();
            SecondarySectionPosition = new List<List<string>>();
            SecondaryTypeSection = new List<List<int>>();
            SecondaryTypeAnimationSection_speed = new List<List<float>>();
            SecondarySectionCameraValue = new List<List<int>>();
            SecondarySectionMysteriousValue = new List<List<int>>();
            SecondaryConst3C = new List<List<int>>();
            SecondaryConst78 = new List<List<int>>();
            SecondaryConstBreakableWallValue1 = new List<List<int>>();
            SecondaryConstBreakableWallValue2 = new List<List<int>>();
            SecondaryTypeBreakableWall_Effect01 = new List<List<string>>();
            SecondaryTypeBreakableWall_Effect02 = new List<List<string>>();
            SecondaryTypeBreakableWall_Effect03 = new List<List<string>>();
            SecondaryTypeBreakableWall_Sound = new List<List<string>>();
            SecondaryTypeBreakableObject_Effect01 = new List<List<string>>();
            SecondaryTypeBreakableObject_Effect02 = new List<List<string>>();
            SecondaryTypeBreakableObject_Effect03 = new List<List<string>>();
            SecondaryTypeBreakableObject_path = new List<List<string>>();
            One_SecondaryTypeBreakableObject_Speed01 = new List<float>();
            One_SecondaryTypeBreakableObject_Speed02 = new List<float>();
            One_SecondaryTypeBreakableObject_Speed03 = new List<float>();
            One_SecondaryTypeBreakableWall_volume = new List<float>();
            SecondaryTypeBreakableObject_Speed01 = new List<List<float>>();
            SecondaryTypeBreakableObject_Speed02 = new List<List<float>>();
            SecondaryTypeBreakableObject_Speed03 = new List<List<float>>();
            SecondaryTypeBreakableWall_volume = new List<List<float>>();
            copied_MainSection_X_MysteriousPosition = 0;
            copied_MainSection_Y_MysteriousPosition = 0;
            copied_MainSection_Z_MysteriousPosition = 0;
            copied_MainSection_X_PositionGlarePoint = 0;
            copied_MainSection_Y_PositionGlarePoint = 0;
            copied_MainSection_Z_PositionGlarePoint = 0;
            copied_MainSection_X_PositionLightPoint = 0;
            copied_MainSection_Y_PositionLightPoint = 0;
            copied_MainSection_Z_PositionLightPoint = 0;
            copied_MainSection_X_PositionShadow = 0;
            copied_MainSection_Y_PositionShadow = 0;
            copied_MainSection_Z_PositionShadow = 0;
            copied_MainSection_PowerGlare = 0;
            copied_MainSection_blur = 0;
            copied_MainSection_PowerLight = 0;
            copied_MainSectionGlareVagueness = 0;
            copied_MainSection_MysteriousGlareValue1 = 0;
            copied_MainSection_MysteriousGlareValue2 = 0;
            copied_MainSection_PowerSkyColor = 0;
            copied_MainSection_ColorGlare = new byte[4] { 00, 00, 00, 00 };
            copied_MainSection_ColorSky = new byte[4] { 00, 00, 00, 00 };
            copied_MainSection_ColorRock = new byte[4] { 00, 00, 00, 00 };
            copied_MainSection_ColorGroundEffect = new byte[4] { 00, 00, 00, 00 };
            copied_MainSection_ColorPlayerLight = new byte[4] { 00, 00, 00, 00 };
            copied_MainSection_ColorLight = new byte[4] { 00, 00, 00, 00 };
            copied_MainSection_ColorShadow = new byte[4] { 00, 00, 00, 00 };
            copied_MainSection_ColorUnknown = new byte[4] { 00, 00, 00, 00 };
            copied_MainSection_WeatherSettings = 0;
            copied_MainSection_lensFlareSettings = 0;
            copied_MainSection_EnablelensFlareSettings = 0;
            copied_MainSection_EnableGlareSettingValue1 = 0;
            copied_MainSection_EnableGlareSettingValue2 = 0;
            copied_MainSection_EnableGlareSettingValue3 = 0;
            copied_MainSection_unk1 = 0;
            copied_settings = false;
            fileBytes = new byte[0];
            header = new byte[0];
            listBox1.Items.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void Tool_StageInfoEditor_Load(object sender, EventArgs e)
        {
            if (File.Exists(Main.stageInfoPath) == true) {
                OpenFile(Main.stageInfoPath);
            }
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
            ClearFile();
            if (FileName == "" || File.Exists(FileName) == false) return;
            fileBytes = File.ReadAllBytes(FileName);
            FileOpen = true;
            FilePath = FileName;
            FilePos = Main.b_FindBytes(fileBytes, new byte[4] { 0xF2, 0x03, 0x00, 0x00 }, 0);
            header = Main.b_ReadByteArray(fileBytes, 0, FilePos + 16);
            EntryCount = fileBytes[FilePos + 4] + fileBytes[FilePos + 5] * 256 + fileBytes[FilePos + 6] * 65536 + fileBytes[FilePos + 7] * 16777216;
            for (int x2 = 0; x2 < EntryCount; x2++) {
                long _ptr = FilePos + 0x10 + 0x130 * x2;
                string STAGE_NAME = "";
                MainStageSection.Add(Main.b_ReadByteArray(fileBytes, (int)_ptr, 0x130));
                long _ptrCharacter3 = fileBytes[_ptr] + fileBytes[_ptr + 1] * 0x100 + fileBytes[_ptr + 2] * 0x10000 + fileBytes[_ptr + 3] * 0x1000000;
                for (int a2 = 0; a2 < 40; a2++) {
                    if (fileBytes[_ptr + _ptrCharacter3 + a2] != 0) {
                        string str2 = STAGE_NAME;
                        char c = (char)fileBytes[_ptr + _ptrCharacter3 + a2];
                        STAGE_NAME = str2 + c;
                    } else {
                        a2 = 40;
                    }
                }
                string c_sta_x = "";
                _ptrCharacter3 = fileBytes[_ptr + 8] + fileBytes[_ptr + 9] * 0x100 + fileBytes[_ptr + 10] * 0x10000 + fileBytes[_ptr + 11] * 0x1000000;
                for (int a2 = 0; a2 < 16; a2++) {
                    if (fileBytes[_ptr + 8 + _ptrCharacter3 + a2] != 0) {
                        string str2 = c_sta_x;
                        char c = (char)fileBytes[_ptr + 8 + _ptrCharacter3 + a2];
                        c_sta_x = str2 + c;
                    } else {
                        a2 = 16;
                    }
                }
                string BTL_NSX_XXXXX = "";
                _ptrCharacter3 = fileBytes[_ptr + 16] + fileBytes[_ptr + 17] * 0x100 + fileBytes[_ptr + 18] * 0x10000 + fileBytes[_ptr + 19] * 0x1000000;
                for (int a2 = 0; a2 < 16; a2++) {
                    if (fileBytes[_ptr + 16 + _ptrCharacter3 + a2] != 0) {
                        string str2 = BTL_NSX_XXXXX;
                        char c = (char)fileBytes[_ptr + 16 + _ptrCharacter3 + a2];
                        BTL_NSX_XXXXX = str2 + c;
                    } else {
                        a2 = 40;
                    }
                }
                int CountFile = fileBytes[_ptr + 24] + fileBytes[_ptr + 25] * 0x100 + fileBytes[_ptr + 26] * 0x10000 + fileBytes[_ptr + 27] * 0x1000000;
                int CountEntries = fileBytes[_ptr + 40] + fileBytes[_ptr + 41] * 0x100 + fileBytes[_ptr + 42] * 0x10000 + fileBytes[_ptr + 43] * 0x1000000;
                int PosPaths = fileBytes[_ptr + 32] + fileBytes[_ptr + 33] * 0x100 + fileBytes[_ptr + 34] * 0x10000 + fileBytes[_ptr + 35] * 0x1000000;
                int PosMeshes = fileBytes[_ptr + 48] + fileBytes[_ptr + 49] * 0x100 + fileBytes[_ptr + 50] * 0x10000 + fileBytes[_ptr + 51] * 0x1000000;
                long _ptrPosPath = FilePos + 0x10 + 32 + (0x130 * x2);
                long _ptrPosMesh = FilePos + 0x10 + 48 + (0x130 * x2);
                CountOfFiles.Add(CountFile);
                CountOfMeshes.Add(CountEntries);
                MainSection_WeatherSettings.Add(fileBytes[_ptr + 56]);
                MainSection_EnablelensFlareSettings.Add(fileBytes[_ptr + 88]);
                MainSection_lensFlareSettings.Add(fileBytes[_ptr + 92]);
                MainSection_ShadowSetting_value1.Add(fileBytes[_ptr + 132]);
                MainSection_ShadowSetting_value2.Add(fileBytes[_ptr + 140]);
                MainSection_ColorGroundEffect.Add(Main.b_ReadByteArray(fileBytes, (int)_ptr + 60, 4));
                MainSection_ColorUnknown2.Add(Main.b_ReadByteArray(fileBytes, (int)_ptr + 64, 4));
                MainSection_ColorPlayerLight.Add(Main.b_ReadByteArray(fileBytes, (int)_ptr + 68, 4));
                MainSection_ColorLight.Add(Main.b_ReadByteArray(fileBytes, (int)_ptr + 112, 4));
                MainSection_ColorShadow.Add(Main.b_ReadByteArray(fileBytes, (int)_ptr + 136, 4));
                MainSection_ColorGlare.Add(Main.b_ReadByteArray(fileBytes, (int)_ptr + 244, 4));
                MainSection_ColorRock.Add(Main.b_ReadByteArray(fileBytes, (int)_ptr + 268, 4));
                MainSection_ColorSky.Add(Main.b_ReadByteArray(fileBytes, (int)_ptr + 156, 4));
                MainSection_ColorUnknown.Add(Main.b_ReadByteArray(fileBytes, (int)_ptr + 116, 4));
                MainSection_PowerSkyColor.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 152, 4), 0));
                MainSection_X_PositionLightPoint.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 100, 4), 0));
                MainSection_unk1.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 144, 4), 0));
                MainSection_Y_PositionLightPoint.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 104, 4), 0));
                MainSection_Z_PositionLightPoint.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 108, 4), 0));
                MainSection_X_PositionShadow.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 120, 4), 0));
                MainSection_Y_PositionShadow.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 124, 4), 0));
                MainSection_Z_PositionShadow.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 128, 4), 0));
                MainSection_X_PositionGlarePoint.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 248, 4), 0));
                MainSection_Y_PositionGlarePoint.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 252, 4), 0));
                MainSection_Z_PositionGlarePoint.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 256, 4), 0));
                MainSection_PowerLight.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 148, 4), 0));
                MainSection_PowerGlare.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 240, 4), 0));
                MainSection_blur.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 200, 4), 0));
                MainSection_EnableGlareSettingValue1.Add(fileBytes[_ptr + 204]);
                MainSection_EnableGlareSettingValue2.Add(fileBytes[_ptr + 224]);
                MainSection_EnableGlareSettingValue3.Add(fileBytes[_ptr + 228]);
                if (fileBytes[_ptr + 228] == 01) {
                    GlareEnabled.Add(true);
                } else {
                    GlareEnabled.Add(false);
                }
                MainSection_X_MysteriousPosition.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 212, 4), 0));
                MainSection_Y_MysteriousPosition.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 216, 4), 0));
                MainSection_Z_MysteriousPosition.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 220, 4), 0));
                MainSection_MysteriousGlareValue1.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 236, 4), 0));
                MainSection_MysteriousGlareValue2.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 264, 4), 0));
                MainSection_MysteriousGlareValue3.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 232, 4), 0));
                MainSection_UnknownValue1.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 164, 4), 0));
                MainSection_UnknownValue2.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 168, 4), 0));
                MainSection_UnknownValue3.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 172, 4), 0));
                MainSectionGlareVagueness.Add(Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptr + 260, 4), 0));

                for (int x3 = 0; x3 < CountFile; x3++) {
                    int _ptrPosPath_extra = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosPath + PosPaths, 4));
                    One_SecondarySectionFilePathString.Add(Main.b_ReadString(fileBytes, (int)_ptrPosPath + PosPaths + _ptrPosPath_extra, -1));
                    _ptrPosPath = _ptrPosPath + 8;
                }
                for (int x3 = 0; x3 < CountEntries; x3++) {
                    int _ptrPosLoadPath_extra = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes, 4));
                    int _ptrPosLoadMesh_extra = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 8, 4));
                    int _ptrPosLoadPathdmy_extra = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 16, 4));
                    int _ptrPosLoadDmy_extra = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 24, 4));
                    int _ptrPosType_extra = fileBytes[(int)_ptrPosMesh + PosMeshes + 32];
                    int _ptrPosCameraValue_extra = fileBytes[(int)_ptrPosMesh + PosMeshes + 40];
                    int _ptrPosMysteriousValue_extra = fileBytes[(int)_ptrPosMesh + PosMeshes + 44];
                    int _ptrPosConstValue3C = fileBytes[(int)_ptrPosMesh + PosMeshes + 112];
                    int _ptrPosConstValue78 = fileBytes[(int)_ptrPosMesh + PosMeshes + 116];
                    int _ptrPosConstBreakableWallValue1 = fileBytes[(int)_ptrPosMesh + PosMeshes + 128];
                    int _ptrPosConstBreakableWallValue2 = fileBytes[(int)_ptrPosMesh + PosMeshes + 132];
                    float _ptrPosAnimationSpeed_extra = Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 36, 4), 0);
                    int _ptrPosBreakableEffect01 = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 120, 4));
                    int _ptrPosBreakableEffect02 = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 136, 4));
                    int _ptrPosBreakableEffect03 = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 144, 4));
                    int _ptrPosBreakableWallSound = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 160, 4));
                    int _ptrPosBreakableObjectPath = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 56, 4));
                    int _ptrPosBreakableObjectEffect01 = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 64, 4));
                    int _ptrPosBreakableObjectEffect02 = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 80, 4));
                    int _ptrPosBreakableObjectEffect03 = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 96, 4));
                    float _ptrPosAnimationBreakableObject_Speed01_extra = Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 72, 4), 0);
                    float _ptrPosAnimationBreakableObject_Speed02_extra = Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 88, 4), 0);
                    float _ptrPosAnimationBreakableObject_Speed03_extra = Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 104, 4), 0);
                    float _ptrPosAnimationBreakableWall_volume_extra = Main.b_ReadFloat(Main.b_ReadByteArray(fileBytes, (int)_ptrPosMesh + PosMeshes + 152, 4), 0);
                    One_SecondarySectionLoadPathString.Add(Main.b_ReadString(fileBytes, (int)_ptrPosMesh + PosMeshes + _ptrPosLoadPath_extra, -1));
                    One_SecondarySectionLoadMeshString.Add(Main.b_ReadString(fileBytes, (int)_ptrPosMesh + PosMeshes + _ptrPosLoadMesh_extra + 8, -1));
                    One_SecondarySectionLoadPathDmyString.Add(Main.b_ReadString(fileBytes, (int)_ptrPosMesh + PosMeshes + _ptrPosLoadPathdmy_extra + 16, -1));
                    One_SecondarySectionLoadDmyString.Add(Main.b_ReadString(fileBytes, (int)_ptrPosMesh + PosMeshes + _ptrPosLoadDmy_extra + 24, -1));
                    One_SecondaryTypeSection.Add(_ptrPosType_extra);
                    One_SecondarySectionCameraValue.Add(_ptrPosCameraValue_extra);
                    One_SecondarySectionMysteriousValue.Add(_ptrPosMysteriousValue_extra);
                    One_SecondaryTypeAnimationSection_speed.Add(_ptrPosAnimationSpeed_extra);
                    One_SecondaryConst3C.Add(_ptrPosConstValue3C);
                    One_SecondaryConst78.Add(_ptrPosConstValue78);
                    One_SecondaryConstBreakableWallValue1.Add(_ptrPosConstBreakableWallValue1);
                    One_SecondaryConstBreakableWallValue2.Add(_ptrPosConstBreakableWallValue2);
                    One_SecondaryTypeBreakableWall_Effect01.Add(Main.b_ReadString(fileBytes, (int)_ptrPosMesh + PosMeshes + _ptrPosBreakableEffect01 + 120, -1));
                    One_SecondaryTypeBreakableWall_Effect02.Add(Main.b_ReadString(fileBytes, (int)_ptrPosMesh + PosMeshes + _ptrPosBreakableEffect02 + 136, -1));
                    One_SecondaryTypeBreakableWall_Effect03.Add(Main.b_ReadString(fileBytes, (int)_ptrPosMesh + PosMeshes + _ptrPosBreakableEffect03 + 144, -1));
                    One_SecondaryTypeBreakableWall_Sound.Add(Main.b_ReadString(fileBytes, (int)_ptrPosMesh + PosMeshes + _ptrPosBreakableWallSound + 160, -1));
                    One_SecondaryTypeBreakableObject_path.Add(Main.b_ReadString(fileBytes, (int)_ptrPosMesh + PosMeshes + _ptrPosBreakableObjectPath + 56, -1));
                    One_SecondaryTypeBreakableObject_Effect01.Add(Main.b_ReadString(fileBytes, (int)_ptrPosMesh + PosMeshes + _ptrPosBreakableObjectEffect01 + 64, -1));
                    One_SecondaryTypeBreakableObject_Effect02.Add(Main.b_ReadString(fileBytes, (int)_ptrPosMesh + PosMeshes + _ptrPosBreakableObjectEffect02 + 80, -1));
                    One_SecondaryTypeBreakableObject_Effect03.Add(Main.b_ReadString(fileBytes, (int)_ptrPosMesh + PosMeshes + _ptrPosBreakableObjectEffect03 + 96, -1));
                    One_SecondaryTypeBreakableObject_Speed01.Add(_ptrPosAnimationBreakableObject_Speed01_extra);
                    One_SecondaryTypeBreakableObject_Speed02.Add(_ptrPosAnimationBreakableObject_Speed02_extra);
                    One_SecondaryTypeBreakableObject_Speed03.Add(_ptrPosAnimationBreakableObject_Speed03_extra);
                    One_SecondaryTypeBreakableWall_volume.Add(_ptrPosAnimationBreakableWall_volume_extra);
                    _ptrPosMesh = _ptrPosMesh + 0xB0;
                }
                SecondarySectionFilePath.Add(One_SecondarySectionFilePathString);

                SecondarySectionLoadPath.Add(One_SecondarySectionLoadPathString);
                SecondarySectionLoadMesh.Add(One_SecondarySectionLoadMeshString);
                SecondarySectionPositionFilePath.Add(One_SecondarySectionLoadPathDmyString);
                SecondarySectionPosition.Add(One_SecondarySectionLoadDmyString);
                SecondaryTypeSection.Add(One_SecondaryTypeSection);
                SecondaryTypeAnimationSection_speed.Add(One_SecondaryTypeAnimationSection_speed);
                SecondarySectionCameraValue.Add(One_SecondarySectionCameraValue);
                SecondarySectionMysteriousValue.Add(One_SecondarySectionMysteriousValue);
                SecondaryConst3C.Add(One_SecondaryConst3C);
                SecondaryConst78.Add(One_SecondaryConst78);
                SecondaryConstBreakableWallValue1.Add(One_SecondaryConstBreakableWallValue1);
                SecondaryConstBreakableWallValue2.Add(One_SecondaryConstBreakableWallValue2);
                SecondaryTypeBreakableWall_Effect01.Add(One_SecondaryTypeBreakableWall_Effect01);
                SecondaryTypeBreakableWall_Effect02.Add(One_SecondaryTypeBreakableWall_Effect02);
                SecondaryTypeBreakableWall_Effect03.Add(One_SecondaryTypeBreakableWall_Effect03);
                SecondaryTypeBreakableWall_Sound.Add(One_SecondaryTypeBreakableWall_Sound);
                SecondaryTypeBreakableWall_volume.Add(One_SecondaryTypeBreakableWall_volume);
                SecondaryTypeBreakableObject_path.Add(One_SecondaryTypeBreakableObject_path);
                SecondaryTypeBreakableObject_Effect01.Add(One_SecondaryTypeBreakableObject_Effect01);
                SecondaryTypeBreakableObject_Effect02.Add(One_SecondaryTypeBreakableObject_Effect02);
                SecondaryTypeBreakableObject_Effect03.Add(One_SecondaryTypeBreakableObject_Effect03);
                SecondaryTypeBreakableObject_Speed01.Add(One_SecondaryTypeBreakableObject_Speed01);
                SecondaryTypeBreakableObject_Speed02.Add(One_SecondaryTypeBreakableObject_Speed02);
                SecondaryTypeBreakableObject_Speed03.Add(One_SecondaryTypeBreakableObject_Speed03);



                One_SecondarySectionFilePathString = new List<string>();
                One_SecondarySectionLoadPathString = new List<string>();
                One_SecondarySectionLoadMeshString = new List<string>();
                One_SecondarySectionLoadPathDmyString = new List<string>();
                One_SecondarySectionLoadDmyString = new List<string>();
                One_SecondaryTypeSection = new List<int>();
                One_SecondarySectionCameraValue = new List<int>();
                One_SecondarySectionMysteriousValue = new List<int>();
                One_SecondaryTypeAnimationSection_speed = new List<float>();
                One_SecondaryConst3C = new List<int>();
                One_SecondaryConst78 = new List<int>();
                One_SecondaryConstBreakableWallValue1 = new List<int>();
                One_SecondaryConstBreakableWallValue2 = new List<int>();
                One_SecondaryTypeBreakableWall_Effect01 = new List<string>();
                One_SecondaryTypeBreakableWall_Effect02 = new List<string>();
                One_SecondaryTypeBreakableWall_Effect03 = new List<string>();
                One_SecondaryTypeBreakableWall_Sound = new List<string>();
                One_SecondaryTypeBreakableWall_volume = new List<float>();
                One_SecondaryTypeBreakableObject_path = new List<string>();
                One_SecondaryTypeBreakableObject_Effect01 = new List<string>();
                One_SecondaryTypeBreakableObject_Effect02 = new List<string>();
                One_SecondaryTypeBreakableObject_Effect03 = new List<string>();
                One_SecondaryTypeBreakableObject_Speed01 = new List<float>();
                One_SecondaryTypeBreakableObject_Speed02 = new List<float>();
                One_SecondaryTypeBreakableObject_Speed03 = new List<float>();
                c_sta_List.Add(c_sta_x);
                StageNameList.Add(STAGE_NAME);
                BTL_NSX_List.Add(BTL_NSX_XXXXX);
                listBox1.Items.Add(StageNameList[x2]);
            }
            StageCount.Text = StageNameList.Count.ToString() + " or 0x" + StageNameList.Count.ToString("X2");
        }
        public void CloseFile()
        {
            ClearFile();
            FileOpen = false;
            FilePath = "";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4]
                        {
                    MainSection_ColorRock[x][3],
                    MainSection_ColorRock[x][2],
                    MainSection_ColorRock[x][1],
                    0x00
                        };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ColorReverse = new byte[4]
                        {
                    MyDialog.Color.A,
                    MyDialog.Color.B,
                    MyDialog.Color.G,
                    MyDialog.Color.R
                        };
                        MainSection_ColorRock[x] = Main.b_ReplaceBytes(MainSection_ColorRock[x], ColorReverse, 0, 0);
                        RockColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorRock[x]);
                    };
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_ColorRock[x] = Main.b_ReplaceBytes(MainSection_ColorRock[x], new byte[4] { 0xFF, 0x5F, 0x6B, 0x82 }, 0, 0);
                    RockColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorRock[x]);
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4]
                         {
                    MainSection_ColorGlare[x][3],
                    MainSection_ColorGlare[x][2],
                    MainSection_ColorGlare[x][1],
                    0x00
                         };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ColorReverse = new byte[4]
                        {
                    MyDialog.Color.A,
                    MyDialog.Color.B,
                    MyDialog.Color.G,
                    MyDialog.Color.R
                        };
                        MainSection_ColorGlare[x] = Main.b_ReplaceBytes(MainSection_ColorGlare[x], ColorReverse, 0, 0);
                        GlareColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorGlare[x]);
                    };
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
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
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (x > -1 && x < listBox1.Items.Count)
            {
                StageName_Textbox.Text = StageNameList[x];
                c_sta_xx_Textbox.Text = c_sta_List[x];
                BTL_NSX_Textbox.Text = BTL_NSX_List[x];
                Glare_power_value.Value = (decimal)MainSection_PowerGlare[x];
                Light_power_value.Value = (decimal)MainSection_PowerLight[x];
                unk1_v.Value = (decimal)MainSection_unk1[x];
                Vagueness_glare.Value = (decimal)MainSectionGlareVagueness[x];
                RockColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorRock[x]);
                PlayerLightColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorPlayerLight[x]);
                GroundEffectColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorGroundEffect[x]);
                LightColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorLight[x]);
                ShadowColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorShadow[x]);
                GlareColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorGlare[x]);
                SkyColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorSky[x]);
                UnknownColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorUnknown[x]);
                Unknown2ColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorUnknown2[x]);
                Shadow_X_Pos.Value = (decimal)MainSection_X_PositionShadow[x];
                Shadow_Y_Pos.Value = (decimal)MainSection_Y_PositionShadow[x];
                Shadow_Z_Pos.Value = (decimal)MainSection_Z_PositionShadow[x];
                BlurValue.Value = (decimal)MainSection_blur[x];
                Light_X_Pos.Value = (decimal)MainSection_X_PositionLightPoint[x];
                Light_Y_Pos.Value = (decimal)MainSection_Y_PositionLightPoint[x];
                Light_Z_Pos.Value = (decimal)MainSection_Z_PositionLightPoint[x];
                M_Glare_Value1.Value = (decimal)MainSection_MysteriousGlareValue1[x];
                M_Glare_Value2.Value = (decimal)MainSection_MysteriousGlareValue2[x];
                M_Glare_Value3.Value = (decimal)MainSection_MysteriousGlareValue3[x];
                unknown1_v.Value = (decimal)MainSection_UnknownValue1[x];
                unknown2_v.Value = (decimal)MainSection_UnknownValue2[x];
                unknown3_v.Value = (decimal)MainSection_UnknownValue3[x];
                Glare_X_Pos.Value = (decimal)MainSection_X_MysteriousPosition[x];
                Glare_Y_Pos.Value = (decimal)MainSection_Y_MysteriousPosition[x];
                Glare_Z_Pos.Value = (decimal)MainSection_Z_MysteriousPosition[x];
                Sky_light_strength.Value = (decimal)MainSection_PowerSkyColor[x];
                lensFlare_X_Pos.Value = (decimal)MainSection_X_PositionGlarePoint[x];
                lensFlare_Y_Pos.Value = (decimal)MainSection_Y_PositionGlarePoint[x];
                lensFlare_Z_Pos.Value = (decimal)MainSection_Z_PositionGlarePoint[x];
                if (MainSection_WeatherSettings[x]==0)
                {
                    weather.Text = "No weather settings";
                }
                else if (MainSection_WeatherSettings[x] == 2)
                {
                    weather.Text = "rain";
                }
                else if (MainSection_WeatherSettings[x] == 1)
                {
                    weather.Text = "snow";
                }
                else
                {
                    weather.Text = "unknown";
                }
                if (MainSection_EnableGlareSettingValue3[x]==1)
                {
                    glare3_cb.Checked = true;
                }
                else
                {
                    glare3_cb.Checked = false;
                }
                if (MainSection_ShadowSetting_value1[x] == 1)
                {
                    shadow1_cb.Checked = true;
                }
                else
                {
                    shadow1_cb.Checked = false;
                }
                if (MainSection_ShadowSetting_value2[x] == 1)
                {
                    shadow2_cb.Checked = true;
                }
                else
                {
                    shadow2_cb.Checked = false;
                }
                if (MainSection_EnableGlareSettingValue2[x] == 1)
                {
                    glare2_cb.Checked = true;
                }
                else
                {
                    glare2_cb.Checked = false;
                }
                if (MainSection_EnableGlareSettingValue1[x] == 1)
                {
                    glare1_cb.Checked = true;
                }
                else
                {
                    glare1_cb.Checked = false;
                }
                if (MainSection_lensFlareSettings[x]==0)
                {
                    LensFlare_combobox.SelectedIndex = 0;
                    lensFlareEnabledText.Text = "uviolet_lensFlare";
                }
                else if (MainSection_lensFlareSettings[x] == 1)
                {
                    LensFlare_combobox.SelectedIndex = 1;
                    lensFlareEnabledText.Text = "oprism_lensFlare";
                }
                else if (MainSection_lensFlareSettings[x] == 2)
                {
                    LensFlare_combobox.SelectedIndex = 2;
                    lensFlareEnabledText.Text = "phalo_lensFlare";
                }
                else if (MainSection_lensFlareSettings[x] == 3)
                {
                    LensFlare_combobox.SelectedIndex = 3;
                    lensFlareEnabledText.Text = "gpurpose_lensFlare";
                }
                else if (MainSection_lensFlareSettings[x] == 4)
                {
                    LensFlare_combobox.SelectedIndex = 4;
                    lensFlareEnabledText.Text = "mlight_lensFlare";
                }
                else if (MainSection_lensFlareSettings[x] == 5)
                {
                    LensFlare_combobox.SelectedIndex = 5;
                    lensFlareEnabledText.Text = "sunset_lensFlare";
                }
                else
                {
                    LensFlare_combobox.SelectedIndex = -1;
                }
                if (MainSection_EnablelensFlareSettings[x] == 1)
                {
                    
                }
                else
                {
                    lensFlareEnabledText.Text = "Disabled";
                }
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                for (int x2 = 0; x2 < CountOfFiles[x]; x2++)
                {
                    listBox2.Items.Add(SecondarySectionFilePath[x][x2]);
                };
                for (int x2 = 0; x2 < CountOfMeshes[x]; x2++)
                {
                    listBox3.Items.Add((x2+1).ToString() + " - " + SecondarySectionLoadMesh[x][x2]);
                };
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (FileOpen)
            {
                if (x > -1 && x < listBox1.Items.Count)
                {
                    StageNameList[x] = StageName_Textbox.Text;
                    c_sta_List[x] = c_sta_xx_Textbox.Text;
                    BTL_NSX_List[x] = BTL_NSX_Textbox.Text;
                    listBox1.Items[x] = StageName_Textbox.Text;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else 
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            int x2 = listBox2.SelectedIndex;
            if (x2 > -1 && x2 < listBox2.Items.Count)
            {
                S_Path_Textbox.Text = SecondarySectionFilePath[x][x2];

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            int x3 = listBox3.SelectedIndex;
            if (x3 > -1 && x3 < listBox3.Items.Count)
            {
                S_LoadPath_Textbox.Text = SecondarySectionLoadPath[x][x3];
                S_LoadMesh_Textbox.Text = SecondarySectionLoadMesh[x][x3];
                S_LoadPathPos_Textbox.Text = SecondarySectionPositionFilePath[x][x3];
                S_LoadPos_Textbox.Text = SecondarySectionPosition[x][x3];
                if (SecondarySectionCameraValue[x][x3]==1)
                {
                    Camera_list_combobox.SelectedIndex = 0;
                }
                else
                {
                    Camera_list_combobox.SelectedIndex = 1;
                }
                if (SecondaryTypeSection[x][x3] == 0)
                {
                    TypeEntry_combobox.SelectedIndex = SecondaryTypeSection[x][x3];
                    SpeedAnimationValue.Enabled = false;
                    S_BW_EFF01_Textbox.Enabled = false;
                    S_BW_EFF02_Textbox.Enabled = false;
                    S_BW_EFF03_Textbox.Enabled = false;
                    S_BW_Sound_Textbox.Enabled = false;
                    S_BO_EFF01_Textbox.Enabled = false;
                    S_BO_EFF02_Textbox.Enabled = false;
                    S_BO_EFF03_Textbox.Enabled = false;
                    S_BO_EFF01_spd.Enabled = false;
                    S_BO_EFF02_spd.Enabled = false;
                    S_BO_EFF03_spd.Enabled = false;
                    S_BO_Path_Textbox.Enabled = false;
                    S_BW_sound_volume.Enabled = false;
                }
                else if (SecondaryTypeSection[x][x3] == 1)
                {
                    TypeEntry_combobox.SelectedIndex = SecondaryTypeSection[x][x3];
                    SpeedAnimationValue.Enabled = true;
                    S_BW_EFF01_Textbox.Enabled = false;
                    S_BW_EFF02_Textbox.Enabled = false;
                    S_BW_EFF03_Textbox.Enabled = false;
                    S_BW_Sound_Textbox.Enabled = false;
                    S_BO_EFF01_Textbox.Enabled = false;
                    S_BO_EFF02_Textbox.Enabled = false;
                    S_BO_EFF03_Textbox.Enabled = false;
                    S_BO_EFF01_spd.Enabled = false;
                    S_BO_EFF02_spd.Enabled = false;
                    S_BO_EFF03_spd.Enabled = false;
                    S_BO_Path_Textbox.Enabled = false;
                    S_BW_sound_volume.Enabled = false;
                }
                else if (SecondaryTypeSection[x][x3] == 4)
                {
                    TypeEntry_combobox.SelectedIndex = SecondaryTypeSection[x][x3];
                    SpeedAnimationValue.Enabled = true;
                    S_BW_EFF01_Textbox.Enabled = false;
                    S_BW_EFF02_Textbox.Enabled = false;
                    S_BW_EFF03_Textbox.Enabled = false;
                    S_BW_Sound_Textbox.Enabled = false;
                    S_BO_EFF01_Textbox.Enabled = false;
                    S_BO_EFF02_Textbox.Enabled = false;
                    S_BO_EFF03_Textbox.Enabled = false;
                    S_BO_EFF01_spd.Enabled = false;
                    S_BO_EFF02_spd.Enabled = false;
                    S_BO_EFF03_spd.Enabled = false;
                    S_BO_Path_Textbox.Enabled = false;
                    S_BW_sound_volume.Enabled = false;
                    numericUpDown1.Enabled = false;
                    numericUpDown2.Enabled = false;
                }
                else if (SecondaryTypeSection[x][x3] == 7)
                {
                    TypeEntry_combobox.SelectedIndex = SecondaryTypeSection[x][x3];
                    SpeedAnimationValue.Enabled = true;
                    S_BW_EFF01_Textbox.Enabled = true;
                    S_BW_EFF02_Textbox.Enabled = true;
                    S_BW_EFF03_Textbox.Enabled = true;
                    S_BW_Sound_Textbox.Enabled = true;
                    S_BO_EFF01_Textbox.Enabled = true;
                    S_BO_EFF02_Textbox.Enabled = true;
                    S_BO_EFF03_Textbox.Enabled = true;
                    S_BO_EFF01_spd.Enabled = true;
                    S_BO_EFF02_spd.Enabled = true;
                    S_BO_EFF03_spd.Enabled = true;
                    S_BO_Path_Textbox.Enabled = true;
                    S_BW_sound_volume.Enabled = true;
                    numericUpDown1.Enabled = true;
                    numericUpDown2.Enabled = true;
                }
                else if (SecondaryTypeSection[x][x3] == 10)
                {
                    TypeEntry_combobox.SelectedIndex = SecondaryTypeSection[x][x3];
                    SpeedAnimationValue.Enabled = false;
                    S_BW_EFF01_Textbox.Enabled = false;
                    S_BW_EFF02_Textbox.Enabled = false;
                    S_BW_EFF03_Textbox.Enabled = false;
                    S_BW_Sound_Textbox.Enabled = false;
                    S_BO_EFF01_Textbox.Enabled = false;
                    S_BO_EFF02_Textbox.Enabled = false;
                    S_BO_EFF03_Textbox.Enabled = false;
                    S_BO_EFF01_spd.Enabled = false;
                    S_BO_EFF02_spd.Enabled = false;
                    S_BO_EFF03_spd.Enabled = false;
                    S_BO_Path_Textbox.Enabled = false;
                    S_BW_sound_volume.Enabled = false;
                    numericUpDown1.Enabled = false;
                    numericUpDown2.Enabled = false;
                }
                else if (SecondaryTypeSection[x][x3] == 11)
                {
                    TypeEntry_combobox.SelectedIndex = SecondaryTypeSection[x][x3];
                    SpeedAnimationValue.Enabled = true;
                    S_BW_EFF01_Textbox.Enabled = false;
                    S_BW_EFF02_Textbox.Enabled = false;
                    S_BW_EFF03_Textbox.Enabled = false;
                    S_BW_Sound_Textbox.Enabled = false;
                    S_BO_EFF01_Textbox.Enabled = true;
                    S_BO_EFF02_Textbox.Enabled = true;
                    S_BO_EFF03_Textbox.Enabled = true;
                    S_BO_EFF01_spd.Enabled = true;
                    S_BO_EFF02_spd.Enabled = true;
                    S_BO_EFF03_spd.Enabled = true;
                    S_BO_Path_Textbox.Enabled = true;
                    S_BW_sound_volume.Enabled = false;
                    numericUpDown1.Enabled = false;
                    numericUpDown2.Enabled = false;
                }
                else
                {
                    TypeEntry_combobox.SelectedIndex = SecondaryTypeSection[x][x3];
                    S_BW_EFF01_Textbox.Enabled = true;
                    S_BW_EFF02_Textbox.Enabled = true;
                    S_BW_EFF03_Textbox.Enabled = true;
                    S_BW_Sound_Textbox.Enabled = true;
                    S_BO_EFF01_Textbox.Enabled = true;
                    S_BO_EFF02_Textbox.Enabled = true;
                    S_BO_EFF03_Textbox.Enabled = true;
                    S_BO_EFF01_spd.Enabled = true;
                    S_BO_EFF02_spd.Enabled = true;
                    S_BO_EFF03_spd.Enabled = true;
                    S_BO_Path_Textbox.Enabled = true;
                    numericUpDown1.Enabled = true;
                    numericUpDown2.Enabled = true;
                }
                MysteriousValue.Value = SecondarySectionMysteriousValue[x][x3];
                SpeedAnimationValue.Value = (decimal)SecondaryTypeAnimationSection_speed[x][x3];
                S_BW_EFF01_Textbox.Text = SecondaryTypeBreakableWall_Effect01[x][x3];
                S_BW_EFF02_Textbox.Text = SecondaryTypeBreakableWall_Effect02[x][x3];
                S_BW_EFF03_Textbox.Text = SecondaryTypeBreakableWall_Effect03[x][x3];
                S_BW_Sound_Textbox.Text = SecondaryTypeBreakableWall_Sound[x][x3];
                S_BO_Path_Textbox.Text = SecondaryTypeBreakableObject_path[x][x3];
                S_BO_EFF01_Textbox.Text = SecondaryTypeBreakableObject_Effect01[x][x3];
                S_BO_EFF02_Textbox.Text = SecondaryTypeBreakableObject_Effect02[x][x3];
                S_BO_EFF03_Textbox.Text = SecondaryTypeBreakableObject_Effect03[x][x3];
                S_BO_EFF01_spd.Value = (decimal)SecondaryTypeBreakableObject_Speed01[x][x3];
                S_BO_EFF02_spd.Value = (decimal)SecondaryTypeBreakableObject_Speed02[x][x3];
                S_BO_EFF03_spd.Value = (decimal)SecondaryTypeBreakableObject_Speed03[x][x3];
                S_BW_sound_volume.Value = (decimal)SecondaryTypeBreakableWall_volume[x][x3];
                S_BO_EFF03_spd.Value = (decimal)SecondaryTypeBreakableObject_Speed03[x][x3];
                numericUpDown1.Value = (decimal)SecondaryConstBreakableWallValue1[x][x3];
                numericUpDown2.Value = (decimal)SecondaryConstBreakableWallValue2[x][x3];
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox3.Visible = true;
            linkLabel3.Enabled = true;
            linkLabel4.Enabled = false;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox3.Visible = false;
            linkLabel3.Enabled = false;
            linkLabel4.Enabled = true;
        }

        private void S_BO_EFF03_spd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4]
                         {
                    MainSection_ColorPlayerLight[x][3],
                    MainSection_ColorPlayerLight[x][2],
                    MainSection_ColorPlayerLight[x][1],
                    0x00
                         };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ColorReverse = new byte[4]
                        {
                    MyDialog.Color.A,
                    MyDialog.Color.B,
                    MyDialog.Color.G,
                    MyDialog.Color.R
                        };
                        MainSection_ColorPlayerLight[x] = Main.b_ReplaceBytes(MainSection_ColorPlayerLight[x], ColorReverse, 0, 0);

                        PlayerLightColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorPlayerLight[x]);

                    };
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4]
                        {
                    MainSection_ColorGroundEffect[x][3],
                    MainSection_ColorGroundEffect[x][2],
                    MainSection_ColorGroundEffect[x][1],
                    0x00
                        };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ColorReverse = new byte[4]
                        {
                    0xFF,
                    MyDialog.Color.B,
                    MyDialog.Color.G,
                    MyDialog.Color.R
                        };
                        MainSection_ColorGroundEffect[x] = Main.b_ReplaceBytes(MainSection_ColorGroundEffect[x], ColorReverse, 0, 0);
                        GroundEffectColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorGroundEffect[x]);
                    };
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4]
                         {
                    MainSection_ColorLight[x][3],
                    MainSection_ColorLight[x][2],
                    MainSection_ColorLight[x][1],
                    0x00
                         };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ColorReverse = new byte[4]
                        {
                    MyDialog.Color.A,
                    MyDialog.Color.B,
                    MyDialog.Color.G,
                    MyDialog.Color.R
                        };
                        MainSection_ColorLight[x] = Main.b_ReplaceBytes(MainSection_ColorLight[x], ColorReverse, 0, 0);
                        LightColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorLight[x]);
                    };
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4]
                         {
                    MainSection_ColorShadow[x][3],
                    MainSection_ColorShadow[x][2],
                    MainSection_ColorShadow[x][1],
                    0x00
                         };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ColorReverse = new byte[4]
                        {
                    MyDialog.Color.A,
                    MyDialog.Color.B,
                    MyDialog.Color.G,
                    MyDialog.Color.R
                        };
                        MainSection_ColorShadow[x] = Main.b_ReplaceBytes(MainSection_ColorShadow[x], ColorReverse, 0, 0);
                        ShadowColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorShadow[x]);
                        MainSection_ShadowSetting_value1[x] = 1;
                        MainSection_ShadowSetting_value2[x] = 1;
                    };
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_ColorPlayerLight[x] = Main.b_ReplaceBytes(MainSection_ColorPlayerLight[x], new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 0);
                    PlayerLightColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorPlayerLight[x]);
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_ColorGroundEffect[x] = Main.b_ReplaceBytes(MainSection_ColorGroundEffect[x], new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 0);
                    GroundEffectColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorGroundEffect[x]);
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                MainSection_ColorLight[x] = Main.b_ReplaceBytes(MainSection_ColorLight[x], new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 0);
                LightColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorLight[x]);
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_ColorShadow[x] = Main.b_ReplaceBytes(MainSection_ColorShadow[x], new byte[4] { 0x00, 0x00, 0x00, 0x0 }, 0, 0);
                    ShadowColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorShadow[x]);
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_ColorGlare[x] = Main.b_ReplaceBytes(MainSection_ColorGlare[x], new byte[4] { 0x00, 0x00, 0x00, 0x0 }, 0, 0);
                    GlareColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorGlare[x]);
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }

        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                int x2 = listBox2.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    if (x2>-1 && x2<listBox2.Items.Count)
                    {
                        SecondarySectionFilePath[x][x2] = S_Path_Textbox.Text;
                        listBox2.Items[x2] = S_Path_Textbox.Text;
                    }
                    else
                    {
                        MessageBox.Show("No path selected...", "Warning");
                    }
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    SecondarySectionFilePath[x].Add(S_Path_Textbox.Text);
                    CountOfFiles[x]++;
                    listBox2.Items.Add(S_Path_Textbox.Text);
                    listBox2.SelectedIndex = listBox2.Items.Count - 1;

                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }
        public void RemoveID(int Index)
        {
            int x = listBox1.SelectedIndex;
            if (listBox2.Items.Count > Index)
            {
                if (listBox2.SelectedIndex > 0)
                {
                    listBox2.SelectedIndex--;
                }
                else
                {
                    listBox2.ClearSelected();
                }

                SecondarySectionFilePath[x].RemoveAt(Index);
                CountOfFiles[x]--;
                listBox2.Items.RemoveAt(Index);

                MessageBox.Show("Entry deleted.");
            }
            else
            {
                MessageBox.Show("No item to delete...");
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                int x2 = listBox2.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    if (x2 > -1 && x2 < listBox2.Items.Count)
                    {
                        RemoveID(listBox2.SelectedIndex);
                    }
                    else
                    {
                        MessageBox.Show("No path selected...", "Warning");
                    }
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                int x3 = listBox3.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    if (x3 > -1 && x3 < listBox3.Items.Count)
                    {
                        SecondarySectionLoadPath[x][x3] = S_LoadPath_Textbox.Text;
                        SecondarySectionLoadMesh[x][x3] = S_LoadMesh_Textbox.Text;
                        SecondarySectionPositionFilePath[x][x3] = S_LoadPathPos_Textbox.Text;
                        SecondarySectionPosition[x][x3] = S_LoadPos_Textbox.Text;
                        SecondaryConstBreakableWallValue1[x][x3] = (int)numericUpDown1.Value;
                        SecondaryConstBreakableWallValue2[x][x3] = (int)numericUpDown2.Value;
                        SecondarySectionMysteriousValue[x][x3] = 0;
                        if (Camera_list_combobox.SelectedIndex == 0)
                        {
                            SecondarySectionCameraValue[x][x3] = 1;
                        }
                        else
                        {
                            SecondarySectionCameraValue[x][x3] = 0;
                        }
                        if (TypeEntry_combobox.SelectedIndex == 0)
                        {
                            SecondaryTypeSection[x][x3] = TypeEntry_combobox.SelectedIndex;
                            SecondaryConstBreakableWallValue1[x][x3] = 0;
                            SecondaryConstBreakableWallValue2[x][x3] = 0;
                            SecondaryConst3C[x][x3] = 0;
                            SecondaryConst78[x][x3] = 0;
                        }
                        else if(TypeEntry_combobox.SelectedIndex == 1)
                        {
                            SecondaryTypeSection[x][x3] = TypeEntry_combobox.SelectedIndex;
                            SecondaryConstBreakableWallValue1[x][x3] = 0;
                            SecondaryConstBreakableWallValue2[x][x3] = 0;
                            SecondaryConst3C[x][x3] = 0x3C;
                            SecondaryConst78[x][x3] = 0x78;
                        }
                        else if (TypeEntry_combobox.SelectedIndex == 4)
                        {
                            SecondaryTypeSection[x][x3] = TypeEntry_combobox.SelectedIndex;
                            SecondaryConstBreakableWallValue1[x][x3] = 0;
                            SecondaryConstBreakableWallValue2[x][x3] = 0;
                            SecondaryConst3C[x][x3] = 0;
                            SecondaryConst78[x][x3] = 0;
                        }
                        else if (TypeEntry_combobox.SelectedIndex == 7)
                        {
                            SecondaryTypeSection[x][x3] = TypeEntry_combobox.SelectedIndex;
                            SecondaryConst3C[x][x3] = 0x3C;
                            SecondaryConst78[x][x3] = 0x78;
                        }
                        else if (TypeEntry_combobox.SelectedIndex == 10)
                        {
                            SecondaryTypeSection[x][x3] = TypeEntry_combobox.SelectedIndex;
                            SecondarySectionMysteriousValue[x][x3] = 1;
                            SecondaryConstBreakableWallValue1[x][x3] = 0;
                            SecondaryConstBreakableWallValue2[x][x3] = 0;
                            SecondaryConst3C[x][x3] = 0x3C;
                            SecondaryConst78[x][x3] = 0x78;
                        }
                        else if (TypeEntry_combobox.SelectedIndex == 11)
                        {
                            SecondaryTypeSection[x][x3] = TypeEntry_combobox.SelectedIndex;
                            SecondaryConstBreakableWallValue1[x][x3] = 0;
                            SecondaryConstBreakableWallValue2[x][x3] = 0;
                            SecondaryConst3C[x][x3] = 0x3C;
                            SecondaryConst78[x][x3] = 0x78;
                        }
                        else
                        {
                            SecondaryTypeSection[x][x3] = TypeEntry_combobox.SelectedIndex;
                            SecondaryConstBreakableWallValue1[x][x3] = 0;
                            SecondaryConstBreakableWallValue2[x][x3] = 0;
                            SecondaryConst3C[x][x3] = 0;
                            SecondaryConst78[x][x3] = 0;
                        }
                        SecondaryTypeAnimationSection_speed[x][x3] = (float) SpeedAnimationValue.Value;
                        SecondaryTypeBreakableWall_Effect01[x][x3] = S_BW_EFF01_Textbox.Text;
                        SecondaryTypeBreakableWall_Effect02[x][x3] = S_BW_EFF02_Textbox.Text;
                        SecondaryTypeBreakableWall_Effect03[x][x3] = S_BW_EFF03_Textbox.Text;
                        SecondaryTypeBreakableWall_Sound[x][x3] = S_BW_Sound_Textbox.Text;
                        SecondaryTypeBreakableObject_path[x][x3] = S_BO_Path_Textbox.Text;
                        SecondaryTypeBreakableObject_Effect01[x][x3] = S_BO_EFF01_Textbox.Text;
                        SecondaryTypeBreakableObject_Effect02[x][x3] = S_BO_EFF02_Textbox.Text;
                        SecondaryTypeBreakableObject_Effect03[x][x3] = S_BO_EFF03_Textbox.Text;
                        SecondaryTypeBreakableObject_Speed01[x][x3] = (float)S_BO_EFF01_spd.Value;
                        SecondaryTypeBreakableObject_Speed02[x][x3] = (float)S_BO_EFF02_spd.Value;
                        SecondaryTypeBreakableObject_Speed03[x][x3] = (float)S_BO_EFF03_spd.Value;
                        SecondaryTypeBreakableWall_volume[x][x3] = (float)S_BW_sound_volume.Value;
                        listBox3.Items[x3] =(x3+1).ToString() + " - " + S_LoadMesh_Textbox.Text;
                    }
                    else
                    {
                        MessageBox.Show("No path selected...", "Warning");
                    }
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void TypeEntry_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (TypeEntry_combobox.SelectedIndex == 0)
            {
                SpeedAnimationValue.Enabled = false;
                S_BW_EFF01_Textbox.Enabled = false;
                S_BW_EFF02_Textbox.Enabled = false;
                S_BW_EFF03_Textbox.Enabled = false;
                S_BW_Sound_Textbox.Enabled = false;
                S_BO_EFF01_Textbox.Enabled = false;
                S_BO_EFF02_Textbox.Enabled = false;
                S_BO_EFF03_Textbox.Enabled = false;
                S_BO_EFF01_spd.Enabled = false;
                S_BO_EFF02_spd.Enabled = false;
                S_BO_EFF03_spd.Enabled = false;
                S_BO_Path_Textbox.Enabled = false;
                S_BW_sound_volume.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
            else if (TypeEntry_combobox.SelectedIndex == 1)
            {
                SpeedAnimationValue.Enabled = true;
                S_BW_EFF01_Textbox.Enabled = false;
                S_BW_EFF02_Textbox.Enabled = false;
                S_BW_EFF03_Textbox.Enabled = false;
                S_BW_Sound_Textbox.Enabled = false;
                S_BO_EFF01_Textbox.Enabled = false;
                S_BO_EFF02_Textbox.Enabled = false;
                S_BO_EFF03_Textbox.Enabled = false;
                S_BO_EFF01_spd.Enabled = false;
                S_BO_EFF02_spd.Enabled = false;
                S_BO_EFF03_spd.Enabled = false;
                S_BO_Path_Textbox.Enabled = false;
                S_BW_sound_volume.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
            else if (TypeEntry_combobox.SelectedIndex == 4)
            {
                SpeedAnimationValue.Enabled = true;
                S_BW_EFF01_Textbox.Enabled = false;
                S_BW_EFF02_Textbox.Enabled = false;
                S_BW_EFF03_Textbox.Enabled = false;
                S_BW_Sound_Textbox.Enabled = false;
                S_BO_EFF01_Textbox.Enabled = false;
                S_BO_EFF02_Textbox.Enabled = false;
                S_BO_EFF03_Textbox.Enabled = false;
                S_BO_EFF01_spd.Enabled = false;
                S_BO_EFF02_spd.Enabled = false;
                S_BO_EFF03_spd.Enabled = false;
                S_BO_Path_Textbox.Enabled = false;
                S_BW_sound_volume.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
            else if (TypeEntry_combobox.SelectedIndex == 7)
            {
                SpeedAnimationValue.Enabled = true;
                S_BW_EFF01_Textbox.Enabled = true;
                S_BW_EFF02_Textbox.Enabled = true;
                S_BW_EFF03_Textbox.Enabled = true;
                S_BW_Sound_Textbox.Enabled = true;
                S_BO_EFF01_Textbox.Enabled = false;
                S_BO_EFF02_Textbox.Enabled = false;
                S_BO_EFF03_Textbox.Enabled = false;
                S_BO_EFF01_spd.Enabled = false;
                S_BO_EFF02_spd.Enabled = false;
                S_BO_EFF03_spd.Enabled = false;
                S_BO_Path_Textbox.Enabled = false;
                S_BW_sound_volume.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
            else if (TypeEntry_combobox.SelectedIndex == 10)
            {
                SpeedAnimationValue.Enabled = false;
                S_BW_EFF01_Textbox.Enabled = false;
                S_BW_EFF02_Textbox.Enabled = false;
                S_BW_EFF03_Textbox.Enabled = false;
                S_BW_Sound_Textbox.Enabled = false;
                S_BO_EFF01_Textbox.Enabled = false;
                S_BO_EFF02_Textbox.Enabled = false;
                S_BO_EFF03_Textbox.Enabled = false;
                S_BO_EFF01_spd.Enabled = false;
                S_BO_EFF02_spd.Enabled = false;
                S_BO_EFF03_spd.Enabled = false;
                S_BO_Path_Textbox.Enabled = false;
                S_BW_sound_volume.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
            else if (TypeEntry_combobox.SelectedIndex == 11)
            {
                SpeedAnimationValue.Enabled = true;
                S_BW_EFF01_Textbox.Enabled = false;
                S_BW_EFF02_Textbox.Enabled = false;
                S_BW_EFF03_Textbox.Enabled = false;
                S_BW_Sound_Textbox.Enabled = false;
                S_BO_EFF01_Textbox.Enabled = true;
                S_BO_EFF02_Textbox.Enabled = true;
                S_BO_EFF03_Textbox.Enabled = true;
                S_BO_EFF01_spd.Enabled = true;
                S_BO_EFF02_spd.Enabled = true;
                S_BO_EFF03_spd.Enabled = true;
                S_BO_Path_Textbox.Enabled = true;
                S_BW_sound_volume.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
            else
            {
                S_BW_EFF01_Textbox.Enabled = true;
                S_BW_EFF02_Textbox.Enabled = true;
                S_BW_EFF03_Textbox.Enabled = true;
                S_BW_Sound_Textbox.Enabled = true;
                S_BO_EFF01_Textbox.Enabled = true;
                S_BO_EFF02_Textbox.Enabled = true;
                S_BO_EFF03_Textbox.Enabled = true;
                S_BO_EFF01_spd.Enabled = true;
                S_BO_EFF02_spd.Enabled = true;
                S_BO_EFF03_spd.Enabled = true;
                S_BO_Path_Textbox.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (FileOpen)
            {
                if (x > -1 && x < listBox1.Items.Count)
                {
                    SecondarySectionLoadPath[x].Add(S_LoadPath_Textbox.Text);
                    SecondarySectionLoadMesh[x].Add(S_LoadMesh_Textbox.Text);
                    SecondarySectionPositionFilePath[x].Add(S_LoadPathPos_Textbox.Text);
                    SecondarySectionPosition[x].Add(S_LoadPos_Textbox.Text);
                    if (Camera_list_combobox.SelectedIndex == 0)
                    {
                        SecondarySectionCameraValue[x].Add(1);
                    }
                    else
                    {
                        SecondarySectionCameraValue[x].Add(0);
                    }
                    if (TypeEntry_combobox.SelectedIndex == 0)
                    {
                        SecondaryTypeSection[x].Add(0);
                        SecondaryConstBreakableWallValue1[x].Add(0);
                        SecondaryConstBreakableWallValue2[x].Add(0);
                        SecondarySectionMysteriousValue[x].Add(0);
                        SecondaryConst3C[x].Add(0);
                        SecondaryConst78[x].Add(0);
                    }
                    else if (TypeEntry_combobox.SelectedIndex == 1)
                    {
                        SecondaryTypeSection[x].Add(1);
                        SecondaryConstBreakableWallValue1[x].Add(0);
                        SecondaryConstBreakableWallValue2[x].Add(0);
                        SecondarySectionMysteriousValue[x].Add(0);
                        SecondaryConst3C[x].Add(0x3C);
                        SecondaryConst78[x].Add(0x78);
                    }
                    else if (TypeEntry_combobox.SelectedIndex == 4)
                    {
                        SecondaryTypeSection[x].Add(4);
                        SecondaryConstBreakableWallValue1[x].Add(0);
                        SecondaryConstBreakableWallValue2[x].Add(0);
                        SecondarySectionMysteriousValue[x].Add(0);
                        SecondaryConst3C[x].Add(0);
                        SecondaryConst78[x].Add(0);
                    }
                    else if (TypeEntry_combobox.SelectedIndex == 7)
                    {
                        SecondaryTypeSection[x].Add(7);
                        SecondaryConstBreakableWallValue1[x].Add((int)numericUpDown1.Value);
                        SecondaryConstBreakableWallValue2[x].Add((int)numericUpDown2.Value);
                        SecondarySectionMysteriousValue[x].Add(0);
                        SecondaryConst3C[x].Add(0x3C);
                        SecondaryConst78[x].Add(0x78);
                    }
                    else if (TypeEntry_combobox.SelectedIndex == 10)
                    {
                        SecondaryTypeSection[x].Add(10);
                        SecondaryConstBreakableWallValue1[x].Add(0);
                        SecondaryConstBreakableWallValue2[x].Add(0);
                        SecondarySectionMysteriousValue[x].Add(1);
                        SecondaryConst3C[x].Add(0x3C);
                        SecondaryConst78[x].Add(0x78);
                    }
                    else if (TypeEntry_combobox.SelectedIndex == 11)
                    {
                        SecondaryTypeSection[x].Add(11);
                        SecondaryConstBreakableWallValue1[x].Add(0);
                        SecondaryConstBreakableWallValue2[x].Add(0);
                        SecondarySectionMysteriousValue[x].Add(0);
                        SecondaryConst3C[x].Add(0x3C);
                        SecondaryConst78[x].Add(0x78);
                    }
                    else
                    {
                        SecondaryTypeSection[x].Add(TypeEntry_combobox.SelectedIndex);
                        SecondaryConstBreakableWallValue1[x].Add(0);
                        SecondaryConstBreakableWallValue2[x].Add(0);
                        SecondarySectionMysteriousValue[x].Add(0);
                        SecondaryConst3C[x].Add(0);
                        SecondaryConst78[x].Add(0);
                    }

                    SecondaryTypeAnimationSection_speed[x].Add((float)SpeedAnimationValue.Value);
                    SecondaryTypeBreakableWall_Effect01[x].Add(S_BW_EFF01_Textbox.Text);
                    SecondaryTypeBreakableWall_Effect02[x].Add(S_BW_EFF02_Textbox.Text);
                    SecondaryTypeBreakableWall_Effect03[x].Add(S_BW_EFF03_Textbox.Text);
                    SecondaryTypeBreakableWall_Sound[x].Add(S_BW_Sound_Textbox.Text);
                    SecondaryTypeBreakableObject_path[x].Add(S_BO_Path_Textbox.Text);
                    SecondaryTypeBreakableObject_Effect01[x].Add(S_BO_EFF01_Textbox.Text);
                    SecondaryTypeBreakableObject_Effect02[x].Add(S_BO_EFF02_Textbox.Text);
                    SecondaryTypeBreakableObject_Effect03[x].Add(S_BO_EFF03_Textbox.Text);
                    SecondaryTypeBreakableObject_Speed01[x].Add((float)S_BO_EFF01_spd.Value);
                    SecondaryTypeBreakableObject_Speed02[x].Add((float)S_BO_EFF02_spd.Value);
                    SecondaryTypeBreakableObject_Speed03[x].Add((float)S_BO_EFF03_spd.Value);
                    SecondaryTypeBreakableWall_volume[x].Add((float)S_BW_sound_volume.Value);
                    listBox3.Items.Add((listBox3.Items.Count + 1).ToString() + " - " + S_LoadMesh_Textbox.Text);
                    listBox3.SelectedIndex = listBox3.Items.Count - 1;
                    CountOfMeshes[x]++;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }
        public void RemoveIDMesh(int Index)
        {
            int x = listBox1.SelectedIndex;
            if (listBox3.Items.Count > Index)
            {
                if (listBox3.SelectedIndex > 0)
                {
                    listBox3.SelectedIndex--;
                }
                else
                {
                    listBox3.ClearSelected();
                }

                SecondarySectionLoadPath[x].RemoveAt(Index);
                SecondarySectionLoadMesh[x].RemoveAt(Index);
                SecondarySectionPositionFilePath[x].RemoveAt(Index);
                SecondarySectionPosition[x].RemoveAt(Index);
                SecondarySectionCameraValue[x].RemoveAt(Index);
                SecondaryTypeSection[x].RemoveAt(Index);
                SecondaryTypeAnimationSection_speed[x].RemoveAt(Index);
                SecondarySectionMysteriousValue[x].RemoveAt(Index);
                SecondaryTypeBreakableWall_Effect01[x].RemoveAt(Index);
                SecondaryTypeBreakableWall_Effect02[x].RemoveAt(Index);
                SecondaryTypeBreakableWall_Effect03[x].RemoveAt(Index);
                SecondaryTypeBreakableWall_Sound[x].RemoveAt(Index);
                SecondaryTypeBreakableObject_path[x].RemoveAt(Index);
                SecondaryTypeBreakableObject_Effect01[x].RemoveAt(Index);
                SecondaryTypeBreakableObject_Effect02[x].RemoveAt(Index);
                SecondaryTypeBreakableObject_Effect03[x].RemoveAt(Index);
                SecondaryTypeBreakableObject_Speed01[x].RemoveAt(Index);
                SecondaryTypeBreakableObject_Speed02[x].RemoveAt(Index);
                SecondaryTypeBreakableObject_Speed03[x].RemoveAt(Index);
                SecondaryTypeBreakableWall_volume[x].RemoveAt(Index);
                SecondaryConstBreakableWallValue1[x].RemoveAt(Index);
                SecondaryConstBreakableWallValue2[x].RemoveAt(Index);
                CountOfMeshes[x]--;
                listBox3.Items.RemoveAt(Index);

                MessageBox.Show("Entry deleted.");
            }
            else
            {
                MessageBox.Show("No item to delete...");
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                int x3 = listBox3.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    if (x3 > -1 && x3 < listBox3.Items.Count)
                    {
                        RemoveIDMesh(listBox3.SelectedIndex);
                    }
                    else
                    {
                        MessageBox.Show("No mesh selected...", "Warning");
                    }
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_WeatherSettings[x] = 2;
                    weather.Text = "rain";
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_WeatherSettings[x] = 1;
                    weather.Text = "snow";
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_WeatherSettings[x] = 0;
                    weather.Text = "No weather settings";
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_EnablelensFlareSettings[x] = 1;
                    if (LensFlare_combobox.SelectedIndex == 0)
                    {
                        MainSection_lensFlareSettings[x] = 0;
                        lensFlareEnabledText.Text = "uviolet_lensFlare";
                    }
                    else if (LensFlare_combobox.SelectedIndex == 1)
                    {
                        MainSection_lensFlareSettings[x] = 1;
                        lensFlareEnabledText.Text = "oprism_lensFlare";
                    }
                    else if (LensFlare_combobox.SelectedIndex == 2)
                    {
                        MainSection_lensFlareSettings[x] = 2;
                        lensFlareEnabledText.Text = "phalo_lensFlare";
                    }
                    else if (LensFlare_combobox.SelectedIndex == 3)
                    {
                        MainSection_lensFlareSettings[x] = 3;
                        lensFlareEnabledText.Text = "gpurpose_lensFlare";
                    }
                    else if (LensFlare_combobox.SelectedIndex == 4)
                    {
                        MainSection_lensFlareSettings[x] = 4;
                        lensFlareEnabledText.Text = "mlight_lensFlare";
                    }
                    else if (LensFlare_combobox.SelectedIndex == 5)
                    {
                        MainSection_lensFlareSettings[x] = 5;
                        lensFlareEnabledText.Text = "sunset_lensFlare";
                    }
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_EnablelensFlareSettings[x] = 0;
                    lensFlareEnabledText.Text = "Disabled";
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_EnableGlareSettingValue1[x] = 1;
                    glare1_cb.Checked = true;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_EnableGlareSettingValue2[x] = 1;
                    glare2_cb.Checked = true;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_EnableGlareSettingValue3[x] = 1;
                    glare3_cb.Checked = true;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_EnableGlareSettingValue1[x] = 0;
                    glare1_cb.Checked = false;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_EnableGlareSettingValue2[x] = 0;
                    glare2_cb.Checked = false;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_EnableGlareSettingValue3[x] = 0;
                    glare3_cb.Checked = false;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_PowerGlare[x] = (float)Glare_power_value.Value;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSectionGlareVagueness[x] = (float)Vagueness_glare.Value;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_PowerLight[x] = (float)Light_power_value.Value;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_blur[x] = (float)BlurValue.Value;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_X_PositionShadow[x] = (float)Shadow_X_Pos.Value;
                    MainSection_Y_PositionShadow[x] = (float)Shadow_Y_Pos.Value;
                    MainSection_Z_PositionShadow[x] = (float)Shadow_Z_Pos.Value;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_X_PositionLightPoint[x] = (float)Light_X_Pos.Value;
                    MainSection_Y_PositionLightPoint[x] = (float)Light_Y_Pos.Value;
                    MainSection_Z_PositionLightPoint[x] = (float)Light_Z_Pos.Value;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_X_PositionGlarePoint[x] = (float)lensFlare_X_Pos.Value;
                    MainSection_Y_PositionGlarePoint[x] = (float)lensFlare_Y_Pos.Value;
                    MainSection_Z_PositionGlarePoint[x] = (float)lensFlare_Z_Pos.Value;

                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_X_MysteriousPosition[x] = (float)Glare_X_Pos.Value;
                    MainSection_Y_MysteriousPosition[x] = (float)Glare_Y_Pos.Value;
                    MainSection_Z_MysteriousPosition[x] = (float)Glare_Z_Pos.Value;

                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void BlurValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_X_MysteriousPosition[x] = (float)Glare_X_Pos.Value;
                    MainSection_Y_MysteriousPosition[x] = (float)Glare_Y_Pos.Value;
                    MainSection_Z_MysteriousPosition[x] = (float)Glare_Z_Pos.Value;
                    MainSection_X_PositionGlarePoint[x] = (float)lensFlare_X_Pos.Value;
                    MainSection_Y_PositionGlarePoint[x] = (float)lensFlare_Y_Pos.Value;
                    MainSection_Z_PositionGlarePoint[x] = (float)lensFlare_Z_Pos.Value;
                    MainSection_X_PositionLightPoint[x] = (float)Light_X_Pos.Value;
                    MainSection_Y_PositionLightPoint[x] = (float)Light_Y_Pos.Value;
                    MainSection_Z_PositionLightPoint[x] = (float)Light_Z_Pos.Value;
                    MainSection_X_PositionShadow[x] = (float)Shadow_X_Pos.Value;
                    MainSection_Y_PositionShadow[x] = (float)Shadow_Y_Pos.Value;
                    MainSection_Z_PositionShadow[x] = (float)Shadow_Z_Pos.Value;
                    MainSection_PowerGlare[x] = (float)Glare_power_value.Value;
                    MainSection_blur[x] = (float)BlurValue.Value;
                    MainSection_PowerLight[x] = (float)Light_power_value.Value;
                    MainSectionGlareVagueness[x] = (float)Vagueness_glare.Value;
                    MainSection_MysteriousGlareValue1[x] = (float)M_Glare_Value1.Value;
                    MainSection_MysteriousGlareValue2[x] = (float)M_Glare_Value2.Value;
                    MainSection_MysteriousGlareValue3[x] = (float)M_Glare_Value3.Value;
                    MainSection_UnknownValue1[x] = (float)unknown1_v.Value;
                    MainSection_UnknownValue2[x] = (float)unknown2_v.Value;
                    MainSection_UnknownValue3[x] = (float)unknown3_v.Value;
                    MainSection_PowerSkyColor[x] = (float)Sky_light_strength.Value;
                    MainSection_unk1[x] = (float)unk1_v.Value;
                    MessageBox.Show("Settings for " + StageNameList[x] + " were saved!");
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainStageSection.Add(MainStageSection[x]);
                    StageNameList.Add(StageNameList[x]+ "_DUB");
                    c_sta_List.Add(c_sta_List[x]);
                    BTL_NSX_List.Add(BTL_NSX_List[x]);

                    CountOfFiles.Add(CountOfFiles[x]);
                    CountOfMeshes.Add(CountOfMeshes[x]);

                    float new_copied_MainSection_unk1 = (float)unk1_v.Value;
                    float new_copied_MainSection_X_MysteriousPosition = (float)Glare_X_Pos.Value;
                    float new_copied_MainSection_Y_MysteriousPosition = (float)Glare_Y_Pos.Value;
                    float new_copied_MainSection_Z_MysteriousPosition = (float)Glare_Z_Pos.Value;
                    float new_copied_MainSection_X_PositionGlarePoint = (float)lensFlare_X_Pos.Value;
                    float new_copied_MainSection_Y_PositionGlarePoint = (float)lensFlare_Y_Pos.Value;
                    float new_copied_MainSection_Z_PositionGlarePoint = (float)lensFlare_Z_Pos.Value;
                    float new_copied_MainSection_X_PositionLightPoint = (float)Light_X_Pos.Value;
                    float new_copied_MainSection_Y_PositionLightPoint = (float)Light_Y_Pos.Value;
                    float new_copied_MainSection_Z_PositionLightPoint = (float)Light_Z_Pos.Value;
                    float new_copied_MainSection_X_PositionShadow = (float)Shadow_X_Pos.Value;
                    float new_copied_MainSection_Y_PositionShadow = (float)Shadow_Y_Pos.Value;
                    float new_copied_MainSection_Z_PositionShadow = (float)Shadow_Z_Pos.Value;
                    float new_copied_MainSection_PowerGlare = (float)Glare_power_value.Value;
                    float new_copied_MainSection_blur = (float)BlurValue.Value;
                    float new_copied_MainSection_PowerLight = (float)Light_power_value.Value;
                    float new_copied_MainSectionGlareVagueness = (float)Vagueness_glare.Value;
                    float new_copied_MainSection_MysteriousGlareValue1 = (float)M_Glare_Value1.Value;
                    float new_copied_MainSection_MysteriousGlareValue2 = (float)M_Glare_Value2.Value;
                    float new_copied_MainSection_MysteriousGlareValue3 = (float)M_Glare_Value3.Value;
                    float new_copied_MainSection_UnknownValue1 = (float)unknown1_v.Value;
                    float new_copied_MainSection_UnknownValue2 = (float)unknown2_v.Value;
                    float new_copied_MainSection_UnknownValue3 = (float)unknown3_v.Value;
                    float new_copied_MainSection_PowerSkyColor = (float)Sky_light_strength.Value;

                    int ColorGlare = Main.b_byteArrayToInt(MainSection_ColorGlare[x]);
                    byte[] new_copied_MainSection_ColorGlare = BitConverter.GetBytes(ColorGlare);

                    int ColorSky = Main.b_byteArrayToInt(MainSection_ColorSky[x]);
                    byte[] new_copied_MainSection_ColorSky = BitConverter.GetBytes(ColorSky);

                    int ColorRock = Main.b_byteArrayToInt(MainSection_ColorRock[x]);
                    byte[] new_copied_MainSection_ColorRock = BitConverter.GetBytes(ColorRock);

                    int ColorGroundEffect = Main.b_byteArrayToInt(MainSection_ColorGroundEffect[x]);
                    byte[] new_copied_MainSection_ColorGroundEffect = BitConverter.GetBytes(ColorGroundEffect);

                    int ColorPlayerLight = Main.b_byteArrayToInt(MainSection_ColorPlayerLight[x]);
                    byte[] new_copied_MainSection_ColorPlayerLight = BitConverter.GetBytes(ColorPlayerLight);

                    int ColorLight = Main.b_byteArrayToInt(MainSection_ColorLight[x]);
                    byte[] new_copied_MainSection_ColorLight = BitConverter.GetBytes(ColorLight);

                    int ColorShadow = Main.b_byteArrayToInt(MainSection_ColorShadow[x]);
                    byte[] new_copied_MainSection_ColorShadow = BitConverter.GetBytes(ColorShadow);

                    int ColorUnknown = Main.b_byteArrayToInt(MainSection_ColorUnknown[x]);
                    byte[] new_copied_MainSection_ColorUnknown = BitConverter.GetBytes(ColorUnknown);

                    int ColorUnknown2 = Main.b_byteArrayToInt(MainSection_ColorUnknown2[x]);
                    byte[] new_copied_MainSection_ColorUnknown2 = BitConverter.GetBytes(ColorUnknown2);
                    int new_copied_MainSection_WeatherSettings = 0;
                    if (weather.Text == "snow")
                        new_copied_MainSection_WeatherSettings = 1;
                    else if (weather.Text == "rain")
                        new_copied_MainSection_WeatherSettings = 2;
                    else
                        new_copied_MainSection_WeatherSettings = 0;
                    int new_copied_MainSection_lensFlareSettings = 0;
                    if (LensFlare_combobox.SelectedIndex == 0)
                        new_copied_MainSection_lensFlareSettings = 0;
                    else if (LensFlare_combobox.SelectedIndex == 1)
                        new_copied_MainSection_lensFlareSettings = 1;
                    else if (LensFlare_combobox.SelectedIndex == 2)
                        new_copied_MainSection_lensFlareSettings = 2;
                    else if (LensFlare_combobox.SelectedIndex == 3)
                        new_copied_MainSection_lensFlareSettings = 3;
                    else if (LensFlare_combobox.SelectedIndex == 4)
                        new_copied_MainSection_lensFlareSettings = 4;
                    else if (LensFlare_combobox.SelectedIndex == 5)
                        new_copied_MainSection_lensFlareSettings = 5;
                    int new_copied_MainSection_EnablelensFlareSettings = 0;
                    if (lensFlareEnabledText.Text == "Disabled")
                        new_copied_MainSection_EnablelensFlareSettings = 0;
                    else
                        new_copied_MainSection_EnablelensFlareSettings = 1;
                    int new_copied_MainSection_EnableGlareSettingValue1 = 0;
                    if (glare1_cb.Checked == false)
                        new_copied_MainSection_EnableGlareSettingValue1 = 0;
                    else
                        new_copied_MainSection_EnableGlareSettingValue1 = 1;
                    int new_copied_MainSection_EnableGlareSettingValue2 = 0;
                    if (glare2_cb.Checked == false)
                        new_copied_MainSection_EnableGlareSettingValue2 = 0;
                    else
                        new_copied_MainSection_EnableGlareSettingValue2 = 1;
                    int new_copied_MainSection_EnableGlareSettingValue3 = 0;
                    if (glare3_cb.Checked == false)
                        new_copied_MainSection_EnableGlareSettingValue3 = 0;
                    else
                        new_copied_MainSection_EnableGlareSettingValue3 = 1;
                    int new_copied_MainSection_ShadowSetting_value1 = 0;
                    int new_copied_MainSection_ShadowSetting_value2 = 0;
                    if (shadow1_cb.Checked == false)
                        new_copied_MainSection_ShadowSetting_value1 = 0;
                    else
                        new_copied_MainSection_ShadowSetting_value1 = 1;

                    if (shadow2_cb.Checked == false)
                        new_copied_MainSection_ShadowSetting_value2 = 0;
                    else
                        new_copied_MainSection_ShadowSetting_value2 = 1;

                    MainSection_unk1.Add(new_copied_MainSection_unk1);
                    MainSection_WeatherSettings.Add(new_copied_MainSection_WeatherSettings);
                    MainSection_EnablelensFlareSettings.Add(new_copied_MainSection_EnablelensFlareSettings);
                    MainSection_lensFlareSettings.Add(new_copied_MainSection_lensFlareSettings);
                    MainSection_ShadowSetting_value1.Add(new_copied_MainSection_ShadowSetting_value1);
                    MainSection_ShadowSetting_value2.Add(new_copied_MainSection_ShadowSetting_value2);
                    MainSection_ColorGroundEffect.Add(new_copied_MainSection_ColorGroundEffect);
                    MainSection_ColorPlayerLight.Add(new_copied_MainSection_ColorPlayerLight);
                    MainSection_ColorLight.Add(new_copied_MainSection_ColorLight);
                    MainSection_ColorShadow.Add(new_copied_MainSection_ColorShadow);
                    MainSection_ColorGlare.Add(new_copied_MainSection_ColorGlare);
                    MainSection_ColorRock.Add(new_copied_MainSection_ColorRock);
                    MainSection_ColorSky.Add(new_copied_MainSection_ColorSky);
                    MainSection_ColorUnknown.Add(new_copied_MainSection_ColorUnknown);
                    MainSection_ColorUnknown2.Add(new_copied_MainSection_ColorUnknown2);
                    MainSection_X_PositionLightPoint.Add(new_copied_MainSection_X_PositionLightPoint);
                    MainSection_Y_PositionLightPoint.Add(new_copied_MainSection_Y_PositionLightPoint);
                    MainSection_Z_PositionLightPoint.Add(new_copied_MainSection_Z_PositionLightPoint);
                    MainSection_X_PositionShadow.Add(new_copied_MainSection_X_PositionShadow);
                    MainSection_Y_PositionShadow.Add(new_copied_MainSection_Y_PositionShadow);
                    MainSection_Z_PositionShadow.Add(new_copied_MainSection_Z_PositionShadow);
                    MainSection_X_PositionGlarePoint.Add(new_copied_MainSection_X_PositionGlarePoint);
                    MainSection_Y_PositionGlarePoint.Add(new_copied_MainSection_Y_PositionGlarePoint);
                    MainSection_Z_PositionGlarePoint.Add(new_copied_MainSection_Z_PositionGlarePoint);
                    MainSection_PowerLight.Add(new_copied_MainSection_PowerLight);
                    MainSection_PowerGlare.Add(new_copied_MainSection_PowerGlare);
                    MainSection_blur.Add(new_copied_MainSection_blur);
                    MainSection_EnableGlareSettingValue1.Add(new_copied_MainSection_EnableGlareSettingValue1);
                    MainSection_EnableGlareSettingValue2.Add(new_copied_MainSection_EnableGlareSettingValue2);
                    MainSection_EnableGlareSettingValue3.Add(new_copied_MainSection_EnableGlareSettingValue3);
                    MainSection_X_MysteriousPosition.Add(new_copied_MainSection_X_MysteriousPosition);
                    MainSection_Y_MysteriousPosition.Add(new_copied_MainSection_Y_MysteriousPosition);
                    MainSection_Z_MysteriousPosition.Add(new_copied_MainSection_Z_MysteriousPosition);
                    MainSection_MysteriousGlareValue1.Add(new_copied_MainSection_MysteriousGlareValue1);
                    MainSection_MysteriousGlareValue2.Add(new_copied_MainSection_MysteriousGlareValue2);
                    MainSection_MysteriousGlareValue3.Add(new_copied_MainSection_MysteriousGlareValue3);
                    MainSection_UnknownValue1.Add(new_copied_MainSection_UnknownValue1);
                    MainSection_UnknownValue2.Add(new_copied_MainSection_UnknownValue2);
                    MainSection_UnknownValue3.Add(new_copied_MainSection_UnknownValue3);
                    MainSectionGlareVagueness.Add(new_copied_MainSectionGlareVagueness);
                    MainSection_PowerSkyColor.Add(new_copied_MainSection_PowerSkyColor);
                    GlareEnabled.Add(GlareEnabled[x]);

                    for (int x3 = 0; x3<CountOfFiles[x]; x3++)
                    {
                        One_SecondarySectionFilePathString.Add(SecondarySectionFilePath[x][x3]);
                        
                    }
                    SecondarySectionFilePath.Add(One_SecondarySectionFilePathString);

                    for (int x4 = 0; x4 < CountOfMeshes[x]; x4++)
                    {
                        One_SecondarySectionLoadPathString.Add(SecondarySectionLoadPath[x][x4]);
                        One_SecondarySectionLoadMeshString.Add(SecondarySectionLoadMesh[x][x4]);
                        One_SecondarySectionLoadPathDmyString.Add(SecondarySectionPositionFilePath[x][x4]);
                        One_SecondarySectionLoadDmyString.Add(SecondarySectionPosition[x][x4]);
                        One_SecondaryTypeSection.Add(SecondaryTypeSection[x][x4]);
                        One_SecondarySectionMysteriousValue.Add(SecondarySectionMysteriousValue[x][x4]);
                        One_SecondaryTypeAnimationSection_speed.Add(SecondaryTypeAnimationSection_speed[x][x4]);
                        One_SecondarySectionCameraValue.Add(SecondarySectionCameraValue[x][x4]);
                        One_SecondaryConstBreakableWallValue1.Add(SecondaryConstBreakableWallValue1[x][x4]);
                        One_SecondaryConstBreakableWallValue2.Add(SecondaryConstBreakableWallValue2[x][x4]);
                        One_SecondaryTypeBreakableWall_Effect01.Add(SecondaryTypeBreakableWall_Effect01[x][x4]);
                        One_SecondaryTypeBreakableWall_Effect02.Add(SecondaryTypeBreakableWall_Effect02[x][x4]);
                        One_SecondaryTypeBreakableWall_Effect03.Add(SecondaryTypeBreakableWall_Effect03[x][x4]);
                        One_SecondaryTypeBreakableWall_Sound.Add(SecondaryTypeBreakableWall_Sound[x][x4]);
                        One_SecondaryTypeBreakableObject_path.Add(SecondaryTypeBreakableObject_path[x][x4]);
                        One_SecondaryTypeBreakableObject_Effect01.Add(SecondaryTypeBreakableObject_Effect01[x][x4]);
                        One_SecondaryTypeBreakableObject_Effect02.Add(SecondaryTypeBreakableObject_Effect02[x][x4]);
                        One_SecondaryTypeBreakableObject_Effect03.Add(SecondaryTypeBreakableObject_Effect03[x][x4]);
                        One_SecondaryTypeBreakableObject_Speed01.Add(SecondaryTypeBreakableObject_Speed01[x][x4]);
                        One_SecondaryTypeBreakableObject_Speed02.Add(SecondaryTypeBreakableObject_Speed02[x][x4]);
                        One_SecondaryTypeBreakableObject_Speed03.Add(SecondaryTypeBreakableObject_Speed03[x][x4]);
                        One_SecondaryConst3C.Add(SecondaryConst3C[x][x4]);
                        One_SecondaryConst78.Add(SecondaryConst78[x][x4]);
                        One_SecondaryTypeBreakableWall_volume.Add(SecondaryTypeBreakableWall_volume[x][x4]);
                    }
                    SecondarySectionLoadPath.Add(One_SecondarySectionLoadPathString);
                    SecondarySectionLoadMesh.Add(One_SecondarySectionLoadMeshString);
                    SecondarySectionPositionFilePath.Add(One_SecondarySectionLoadPathDmyString);
                    SecondarySectionPosition.Add(One_SecondarySectionLoadDmyString);
                    SecondaryTypeSection.Add(One_SecondaryTypeSection);
                    SecondaryTypeAnimationSection_speed.Add(One_SecondaryTypeAnimationSection_speed);
                    SecondarySectionCameraValue.Add(One_SecondarySectionCameraValue);
                    SecondarySectionMysteriousValue.Add(One_SecondarySectionMysteriousValue);
                    SecondaryConst3C.Add(One_SecondaryConst3C);
                    SecondaryConst78.Add(One_SecondaryConst78);
                    SecondaryConstBreakableWallValue1.Add(One_SecondaryConstBreakableWallValue1);
                    SecondaryConstBreakableWallValue2.Add(One_SecondaryConstBreakableWallValue2);
                    SecondaryTypeBreakableWall_Effect01.Add(One_SecondaryTypeBreakableWall_Effect01);
                    SecondaryTypeBreakableWall_Effect02.Add(One_SecondaryTypeBreakableWall_Effect02);
                    SecondaryTypeBreakableWall_Effect03.Add(One_SecondaryTypeBreakableWall_Effect03);
                    SecondaryTypeBreakableWall_Sound.Add(One_SecondaryTypeBreakableWall_Sound);
                    SecondaryTypeBreakableWall_volume.Add(One_SecondaryTypeBreakableWall_volume);
                    SecondaryTypeBreakableObject_path.Add(One_SecondaryTypeBreakableObject_path);
                    SecondaryTypeBreakableObject_Effect01.Add(One_SecondaryTypeBreakableObject_Effect01);
                    SecondaryTypeBreakableObject_Effect02.Add(One_SecondaryTypeBreakableObject_Effect02);
                    SecondaryTypeBreakableObject_Effect03.Add(One_SecondaryTypeBreakableObject_Effect03);
                    SecondaryTypeBreakableObject_Speed01.Add(One_SecondaryTypeBreakableObject_Speed01);
                    SecondaryTypeBreakableObject_Speed02.Add(One_SecondaryTypeBreakableObject_Speed02);
                    SecondaryTypeBreakableObject_Speed03.Add(One_SecondaryTypeBreakableObject_Speed03);
                    One_SecondarySectionFilePathString = new List<string>();
                    One_SecondarySectionLoadPathString = new List<string>();
                    One_SecondarySectionLoadMeshString = new List<string>();
                    One_SecondarySectionLoadPathDmyString = new List<string>();
                    One_SecondarySectionLoadDmyString = new List<string>();
                    One_SecondaryTypeSection = new List<int>();
                    One_SecondarySectionCameraValue = new List<int>();
                    One_SecondarySectionMysteriousValue = new List<int>();
                    One_SecondaryTypeAnimationSection_speed = new List<float>();
                    One_SecondaryConst3C = new List<int>();
                    One_SecondaryConst78 = new List<int>();
                    One_SecondaryConstBreakableWallValue1 = new List<int>();
                    One_SecondaryConstBreakableWallValue2 = new List<int>();
                    One_SecondaryTypeBreakableWall_Effect01 = new List<string>();
                    One_SecondaryTypeBreakableWall_Effect02 = new List<string>();
                    One_SecondaryTypeBreakableWall_Effect03 = new List<string>();
                    One_SecondaryTypeBreakableWall_Sound = new List<string>();
                    One_SecondaryTypeBreakableWall_volume = new List<float>();
                    One_SecondaryTypeBreakableObject_path = new List<string>();
                    One_SecondaryTypeBreakableObject_Effect01 = new List<string>();
                    One_SecondaryTypeBreakableObject_Effect02 = new List<string>();
                    One_SecondaryTypeBreakableObject_Effect03 = new List<string>();
                    One_SecondaryTypeBreakableObject_Speed01 = new List<float>();
                    One_SecondaryTypeBreakableObject_Speed02 = new List<float>();
                    One_SecondaryTypeBreakableObject_Speed03 = new List<float>();

                    listBox1.Items.Add(StageNameList[x] + "_DUB");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    EntryCount++;
                    StageCount.Text = listBox1.Items.Count.ToString() + " or 0x" + listBox1.Items.Count.ToString("X2");
                    MessageBox.Show("Stage added!");
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }
        public void RemoveIDStage(int Index)
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

                MainStageSection.RemoveAt(Index);
                StageNameList.RemoveAt(Index);
                c_sta_List.RemoveAt(Index);
                BTL_NSX_List.RemoveAt(Index);

                CountOfFiles.RemoveAt(Index);
                CountOfMeshes.RemoveAt(Index);
                MainSection_unk1.RemoveAt(Index);
                MainSection_ColorUnknown.RemoveAt(Index);
                MainSection_ColorUnknown2.RemoveAt(Index);
                MainSection_WeatherSettings.RemoveAt(Index);
                MainSection_EnablelensFlareSettings.RemoveAt(Index);
                MainSection_lensFlareSettings.RemoveAt(Index);
                MainSection_ShadowSetting_value1.RemoveAt(Index);
                MainSection_ShadowSetting_value2.RemoveAt(Index);
                MainSection_ColorGroundEffect.RemoveAt(Index);
                MainSection_ColorPlayerLight.RemoveAt(Index);
                MainSection_ColorLight.RemoveAt(Index);
                MainSection_ColorShadow.RemoveAt(Index);
                MainSection_ColorGlare.RemoveAt(Index);
                MainSection_ColorRock.RemoveAt(Index);
                MainSection_X_PositionLightPoint.RemoveAt(Index);
                MainSection_Y_PositionLightPoint.RemoveAt(Index);
                MainSection_Z_PositionLightPoint.RemoveAt(Index);
                MainSection_X_PositionShadow.RemoveAt(Index);
                MainSection_Y_PositionShadow.RemoveAt(Index);
                MainSection_Z_PositionShadow.RemoveAt(Index);
                MainSection_X_PositionGlarePoint.RemoveAt(Index);
                MainSection_Y_PositionGlarePoint.RemoveAt(Index);
                MainSection_Z_PositionGlarePoint.RemoveAt(Index);
                MainSection_PowerLight.RemoveAt(Index);
                MainSection_PowerGlare.RemoveAt(Index);
                MainSection_blur.RemoveAt(Index);
                MainSection_EnableGlareSettingValue1.RemoveAt(Index);
                MainSection_EnableGlareSettingValue2.RemoveAt(Index);
                MainSection_EnableGlareSettingValue3.RemoveAt(Index);
                MainSection_X_MysteriousPosition.RemoveAt(Index);
                MainSection_Y_MysteriousPosition.RemoveAt(Index);
                MainSection_Z_MysteriousPosition.RemoveAt(Index);
                MainSection_MysteriousGlareValue1.RemoveAt(Index);
                MainSection_MysteriousGlareValue2.RemoveAt(Index);
                MainSection_MysteriousGlareValue3.RemoveAt(Index);
                MainSection_UnknownValue1.RemoveAt(Index);
                MainSection_UnknownValue2.RemoveAt(Index);
                MainSection_UnknownValue3.RemoveAt(Index);
                MainSectionGlareVagueness.RemoveAt(Index);
                GlareEnabled.RemoveAt(Index);
                SecondarySectionFilePath.RemoveAt(Index);
                SecondarySectionLoadPath.RemoveAt(Index);
                SecondarySectionLoadMesh.RemoveAt(Index);
                SecondarySectionPositionFilePath.RemoveAt(Index);
                SecondarySectionPosition.RemoveAt(Index);
                SecondaryTypeSection.RemoveAt(Index);
                SecondaryTypeAnimationSection_speed.RemoveAt(Index);
                SecondarySectionCameraValue.RemoveAt(Index);
                SecondarySectionMysteriousValue.RemoveAt(Index);
                SecondaryConst3C.RemoveAt(Index);
                SecondaryConst78.RemoveAt(Index);
                SecondaryConstBreakableWallValue1.RemoveAt(Index);
                SecondaryConstBreakableWallValue2.RemoveAt(Index);
                SecondaryTypeBreakableWall_Effect01.RemoveAt(Index);
                SecondaryTypeBreakableWall_Effect02.RemoveAt(Index);
                SecondaryTypeBreakableWall_Effect03.RemoveAt(Index);
                SecondaryTypeBreakableWall_Sound.RemoveAt(Index);
                SecondaryTypeBreakableWall_volume.RemoveAt(Index);
                SecondaryTypeBreakableObject_path.RemoveAt(Index);
                SecondaryTypeBreakableObject_Effect01.RemoveAt(Index);
                SecondaryTypeBreakableObject_Effect02.RemoveAt(Index);
                SecondaryTypeBreakableObject_Effect03.RemoveAt(Index);
                SecondaryTypeBreakableObject_Speed01.RemoveAt(Index);
                SecondaryTypeBreakableObject_Speed02.RemoveAt(Index);
                SecondaryTypeBreakableObject_Speed03.RemoveAt(Index);
                MainSection_PowerSkyColor.RemoveAt(Index);
                MainSection_ColorSky.RemoveAt(Index);
                listBox1.Items.RemoveAt(Index);
                EntryCount--;
                StageCount.Text = listBox1.Items.Count.ToString() + " or 0x" + listBox1.Items.Count.ToString("X2");
                MessageBox.Show("Entry deleted.");
            }
            else
            {
                MessageBox.Show("No item to delete...");
            }
        }
        private void button25_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    RemoveIDStage(listBox1.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_MysteriousGlareValue1[x] = (float)M_Glare_Value1.Value;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_MysteriousGlareValue2[x] = (float)M_Glare_Value2.Value;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void StageCount_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
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
            byte[] fileBytes36 = new byte[0];
            int SectionTotalLength = 0;
            fileBytes36 = header;
            int LengthOfStuff = 0;
            for (int y = 0; y < EntryCount; y++)
            {
                LengthOfStuff = LengthOfStuff + 0x130;
                for (int x2 = 0; x2 < CountOfFiles[y]; x2++)
                {
                    LengthOfStuff = 0x130+ LengthOfStuff + 8 + 8 + SecondarySectionFilePath[y][x2].Length;
                }
            }
            for (int x = 0; x < EntryCount; x++)
            {
                fileBytes36 = Main.b_AddBytes(fileBytes36, MainStageSection[x]);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(CountOfFiles[x]), fileBytes36.Length - 0x118);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(CountOfMeshes[x]), fileBytes36.Length - 0x108);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_WeatherSettings[x]), fileBytes36.Length - 0xF8);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, MainSection_ColorGroundEffect[x], fileBytes36.Length - 0xF4);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, MainSection_ColorUnknown2[x], fileBytes36.Length - 0xF0);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, MainSection_ColorPlayerLight[x], fileBytes36.Length - 0xEC);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_EnablelensFlareSettings[x]), fileBytes36.Length - 0xD8);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_lensFlareSettings[x]), fileBytes36.Length - 0xD4);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_X_PositionLightPoint[x]), fileBytes36.Length - 0xCC);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_Y_PositionLightPoint[x]), fileBytes36.Length - 0xC8);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_Z_PositionLightPoint[x]), fileBytes36.Length - 0xC4);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, MainSection_ColorLight[x], fileBytes36.Length - 0xC0);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, MainSection_ColorUnknown[x], fileBytes36.Length - 0xBC);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_X_PositionShadow[x]), fileBytes36.Length - 0xB8);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_Y_PositionShadow[x]), fileBytes36.Length - 0xB4);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_Z_PositionShadow[x]), fileBytes36.Length - 0xB0);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_ShadowSetting_value1[x]), fileBytes36.Length - 0xAC);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, MainSection_ColorShadow[x], fileBytes36.Length - 0xA8);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_ShadowSetting_value2[x]), fileBytes36.Length - 0xA4);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_unk1[x]), fileBytes36.Length - 0xA0);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_PowerLight[x]), fileBytes36.Length - 0x9C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_PowerSkyColor[x]), fileBytes36.Length - 0x98);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, MainSection_ColorSky[x], fileBytes36.Length - 0x94);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_blur[x]), fileBytes36.Length - 0x68);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_X_MysteriousPosition[x]), fileBytes36.Length - 0x5C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_Y_MysteriousPosition[x]), fileBytes36.Length - 0x58);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_Z_MysteriousPosition[x]), fileBytes36.Length - 0x54);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_EnableGlareSettingValue1[x]), fileBytes36.Length - 0x64);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_EnableGlareSettingValue2[x]), fileBytes36.Length - 0x50);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_EnableGlareSettingValue3[x]), fileBytes36.Length - 0x4C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_MysteriousGlareValue3[x]), fileBytes36.Length - 0x48);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_UnknownValue1[x]), fileBytes36.Length - 0x8C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_UnknownValue2[x]), fileBytes36.Length - 0x88);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_UnknownValue3[x]), fileBytes36.Length - 0x84);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_MysteriousGlareValue1[x]), fileBytes36.Length - 0x44);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_PowerGlare[x]), fileBytes36.Length - 0x40);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, MainSection_ColorGlare[x], fileBytes36.Length - 0x3C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_X_PositionGlarePoint[x]), fileBytes36.Length - 0x38);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_Y_PositionGlarePoint[x]), fileBytes36.Length - 0x34);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_Z_PositionGlarePoint[x]), fileBytes36.Length - 0x30);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSectionGlareVagueness[x]), fileBytes36.Length - 0x2C);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(MainSection_MysteriousGlareValue2[x]), fileBytes36.Length - 0x28);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, MainSection_ColorRock[x], fileBytes36.Length - 0x24);
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(LengthOfStuff), fileBytes36.Length - 0x100);
                SectionTotalLength = SectionTotalLength + 0x130;
            };
            int LengthFromSection = 0;
            int extra = 0;
            int TotalLengthOfMeshes = 0;
            for (int x = 0; x < EntryCount; x++)
            {
                int LengthFromPath = 0;
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes((EntryCount*0x130)-0x20-(x*0x130)+ LengthFromSection+ extra), FilePos+0x10+0x20+(x*0x130));
                extra = extra+ 8 * CountOfFiles[x];
                for (int x2 = 0; x2 < CountOfFiles[x]; x2++)
                {
                    LengthFromSection = LengthFromSection + SecondarySectionFilePath[x][x2].Length + 8;
                }
                for (int x2 = 0; x2 < CountOfFiles[x]; x2++)
                {
                    int _ptr = fileBytes36.Length;
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(LengthFromPath+ 8 * CountOfFiles[x]), _ptr);
                    LengthFromPath = LengthFromPath + SecondarySectionFilePath[x][x2].Length;
                }
                for (int x2 = 0; x2 < CountOfFiles[x]; x2++)
                {
                    fileBytes36 = Main.b_AddString(fileBytes36, SecondarySectionFilePath[x][x2]);
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
                }
            }
            int _ptrMeshes = fileBytes36.Length;
            for (int x = 0; x < EntryCount; x++)
            {
                for (int x2 = 0; x2 < CountOfMeshes[x]; x2++)
                {
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[0xB0] { Convert.ToByte(x), Convert.ToByte(x2), 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
                    TotalLengthOfMeshes = TotalLengthOfMeshes + 0xB0;
                }
            }
            int _ptrLastSection = 0;
            for (int x = 0; x<EntryCount; x++)
            {
                
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(_ptrMeshes - header.Length - 0x30 - (x*0x130) + _ptrLastSection), header.Length+0x30+(x*0x130));
                
                for (int x3 = 0; x3<CountOfMeshes[x]; x3++)
                {
                    _ptrLastSection = _ptrLastSection + 0xB0;
                }
            }
            int TotalLengthOfSection = 0;
            int TotalLengthOfLoadedPaths = 0;
            for (int x = 0; x < EntryCount; x++)
            {
                for (int x2 = 0; x2 < CountOfMeshes[x]; x2++)
                {
                    //path
                    fileBytes36 = Main.b_AddString(fileBytes36, SecondarySectionLoadPath[x][x2]);
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths- TotalLengthOfSection), _ptrMeshes + TotalLengthOfSection);
                    TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + SecondarySectionLoadPath[x][x2].Length + 4;
                    //mesh
                    fileBytes36 = Main.b_AddString(fileBytes36, SecondarySectionLoadMesh[x][x2]);
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection -0x08), _ptrMeshes + 0x08+ TotalLengthOfSection);
                    TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + SecondarySectionLoadMesh[x][x2].Length + 4;
                    //dmypath
                    //if (SecondarySectionPositionFilePath[x][x2].Length > 1) //BIG BRAIN CC2 MADE IT BUG CAMERA VALUE IF YOU DONT USING IT ALL TIME
                   // {
                        fileBytes36 = Main.b_AddString(fileBytes36, SecondarySectionPositionFilePath[x][x2]);
                        fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x10), _ptrMeshes + 0x10 + TotalLengthOfSection);
                        TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + SecondarySectionPositionFilePath[x][x2].Length + 4;
                    //}
                    //else
                    //{
                    //    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x10 + TotalLengthOfSection);
                    //}
                    //dmypos
                    //if (SecondarySectionPosition[x][x2].Length > 1 && SecondarySectionPositionFilePath[x][x2].Length > 1)
                    //{
                        fileBytes36 = Main.b_AddString(fileBytes36, SecondarySectionPosition[x][x2]);
                        fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x18), _ptrMeshes + 0x18 + TotalLengthOfSection);
                        TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + SecondarySectionPosition[x][x2].Length + 4;
                    //}
                    //else
                    //{
                    //    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x18 + TotalLengthOfSection);
                    //}
                    //TypeSection
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondaryTypeSection[x][x2]), _ptrMeshes + 0x20 + TotalLengthOfSection);
                    //Speed of animation
                    if (SecondaryTypeSection[x][x2]!=00 && SecondaryTypeSection[x][x2] != 04)
                    {
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondaryTypeAnimationSection_speed[x][x2]), _ptrMeshes + 0x24 + TotalLengthOfSection);
                    }
                    else
                    {
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x24 + TotalLengthOfSection);
                    }
                    //Camera value
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondarySectionCameraValue[x][x2]), _ptrMeshes + 0x28 + TotalLengthOfSection);
                    //RigidBody value
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondarySectionMysteriousValue[x][x2]), _ptrMeshes + 0x2C + TotalLengthOfSection);
                    //Breakable object
                    if (SecondaryTypeSection[x][x2] == 0x0B)
                    {
                        //path
                        fileBytes36 = Main.b_AddString(fileBytes36, SecondaryTypeBreakableObject_path[x][x2]);
                        fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x38), _ptrMeshes + 0x38 + TotalLengthOfSection);
                        TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + SecondaryTypeBreakableObject_path[x][x2].Length + 4;

                        if (SecondaryTypeBreakableObject_Effect01[x][x2].Length > 1 && SecondaryTypeBreakableObject_path[x][x2].Length > 1)
                        {
                            //effect1
                            fileBytes36 = Main.b_AddString(fileBytes36, SecondaryTypeBreakableObject_Effect01[x][x2]);
                            fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x40), _ptrMeshes + 0x40 + TotalLengthOfSection);
                            TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + SecondaryTypeBreakableObject_Effect01[x][x2].Length + 4;

                            //effect1_speed
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondaryTypeBreakableObject_Speed01[x][x2]), _ptrMeshes + 0x48 + TotalLengthOfSection);
                        }
                        else
                        {
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x40 + TotalLengthOfSection);
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x48 + TotalLengthOfSection);
                        }
                        if (SecondaryTypeBreakableObject_Effect02[x][x2].Length > 1 && SecondaryTypeBreakableObject_path[x][x2].Length > 1)
                        {
                            //effect2
                            fileBytes36 = Main.b_AddString(fileBytes36, SecondaryTypeBreakableObject_Effect02[x][x2]);
                            fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x50), _ptrMeshes + 0x50 + TotalLengthOfSection);
                            TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + SecondaryTypeBreakableObject_Effect02[x][x2].Length + 4;

                            //effect2_speed
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondaryTypeBreakableObject_Speed02[x][x2]), _ptrMeshes + 0x58 + TotalLengthOfSection);
                        }
                        else
                        {
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x50 + TotalLengthOfSection);
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x58 + TotalLengthOfSection);
                        }
                        if (SecondaryTypeBreakableObject_Effect03[x][x2].Length > 1 && SecondaryTypeBreakableObject_path[x][x2].Length > 1)
                        {
                            //effect3
                            fileBytes36 = Main.b_AddString(fileBytes36, SecondaryTypeBreakableObject_Effect03[x][x2]);
                            fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x60), _ptrMeshes + 0x60 + TotalLengthOfSection);
                            TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + SecondaryTypeBreakableObject_Effect03[x][x2].Length + 4;

                            //effect3_speed
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondaryTypeBreakableObject_Speed03[x][x2]), _ptrMeshes + 0x68 + TotalLengthOfSection);
                        }
                        else
                        {
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x60 + TotalLengthOfSection);
                            fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x68 + TotalLengthOfSection);
                        }
                        
                    }
                    else
                    {
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrMeshes + 0x38 + TotalLengthOfSection);
                    }
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0x3C), _ptrMeshes + 0x70 + TotalLengthOfSection);
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0x78), _ptrMeshes + 0x74 + TotalLengthOfSection);
                        //const_values
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondaryConstBreakableWallValue1[x][x2]), _ptrMeshes + 0x80 + TotalLengthOfSection);
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondaryConstBreakableWallValue2[x][x2]), _ptrMeshes + 0x84 + TotalLengthOfSection);

                    //breakable wall
                    if (SecondaryTypeSection[x][x2] == 7)
                    {
                        //effect1
                        fileBytes36 = Main.b_AddString(fileBytes36, SecondaryTypeBreakableWall_Effect01[x][x2]);
                        fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x78), _ptrMeshes + 0x78 + TotalLengthOfSection);
                        TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + SecondaryTypeBreakableWall_Effect01[x][x2].Length + 4;

                        //const_values
                        //fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondaryConstBreakableWallValue1[x][x2]), _ptrMeshes + 0x80 + TotalLengthOfSection);
                        //fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondaryConstBreakableWallValue2[x][x2]), _ptrMeshes + 0x84 + TotalLengthOfSection);

                        //effect2
                        fileBytes36 = Main.b_AddString(fileBytes36, SecondaryTypeBreakableWall_Effect02[x][x2]);
                        fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x88), _ptrMeshes + 0x88 + TotalLengthOfSection);
                        TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + SecondaryTypeBreakableWall_Effect02[x][x2].Length + 4;

                        //effect3
                        fileBytes36 = Main.b_AddString(fileBytes36, SecondaryTypeBreakableWall_Effect03[x][x2]);
                        fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0x90), _ptrMeshes + 0x90 + TotalLengthOfSection);
                        TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + SecondaryTypeBreakableWall_Effect03[x][x2].Length + 4;

                        //sound_volume
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(SecondaryTypeBreakableWall_volume[x][x2]), _ptrMeshes + 0x98 + TotalLengthOfSection);

                        //sound
                        fileBytes36 = Main.b_AddString(fileBytes36, SecondaryTypeBreakableWall_Sound[x][x2]);
                        fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                        fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(TotalLengthOfMeshes + TotalLengthOfLoadedPaths - TotalLengthOfSection - 0xA0), _ptrMeshes + 0xA0 + TotalLengthOfSection);
                        TotalLengthOfLoadedPaths = TotalLengthOfLoadedPaths + SecondaryTypeBreakableWall_Sound[x][x2].Length + 4;

                    }
                    TotalLengthOfSection = TotalLengthOfSection + 0xB0;
                }
            }

            int NamePos = fileBytes36.Length - header.Length-0x10;
            int _ptrName = header.Length;
            for (int x = 0; x < EntryCount; x++)
            {
                //StageName
                fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(NamePos+0x10), _ptrName + (x*0x130));
                fileBytes36 = Main.b_AddString(fileBytes36, StageNameList[x]);
                fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                NamePos = (NamePos + StageNameList[x].Length + 4);
                if (c_sta_List[x].Length>1)
                {
                    //c_sta_x
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(NamePos + 0x08), _ptrName + 0x08 + (x * 0x130));
                    fileBytes36 = Main.b_AddString(fileBytes36, c_sta_List[x]);
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                    NamePos = (NamePos + c_sta_List[x].Length + 4);
                }
                else
                {
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(0), _ptrName + 0x08 + (x * 0x130));
                }
                if (BTL_NSX_List[x].Length > 1)
                {
                    //BTL_NSX_XXXXX
                    fileBytes36 = Main.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(NamePos), _ptrName + 0x10 + (x * 0x130));
                    fileBytes36 = Main.b_AddString(fileBytes36, BTL_NSX_List[x]);
                    fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4] { 0x00, 0x00, 0x00, 0x00 });
                    NamePos = (NamePos + BTL_NSX_List[x].Length + 4);
                }
                else if (BTL_NSX_List[x].Length == 0)
                {
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

        private void SkyColor_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4]
                         {
                    MainSection_ColorSky[x][3],
                    MainSection_ColorSky[x][2],
                    MainSection_ColorSky[x][1],
                    0x00
                         };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ColorReverse = new byte[4]
                        {
                    MyDialog.Color.A,
                    MyDialog.Color.B,
                    MyDialog.Color.G,
                    MyDialog.Color.R
                        };
                        MainSection_ColorSky[x] = Main.b_ReplaceBytes(MainSection_ColorSky[x], ColorReverse, 0, 0);
                        SkyColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorSky[x]);
                    };
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {

        }

        private void button37_Click_1(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_ColorSky[x] = Main.b_ReplaceBytes(MainSection_ColorSky[x], new byte[4] { 0x00, 0x00, 0x00, 0x00 }, 0, 0);
                    SkyColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorSky[x]);
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                if (Search_TB.Text != "")
                {
                    if (Main.SearchStringIndex(StageNameList, Search_TB.Text, EntryCount, listBox1.SelectedIndex) != -1)
                    {
                        listBox1.SelectedIndex = Main.SearchStringIndex(StageNameList, Search_TB.Text, EntryCount, listBox1.SelectedIndex);
                    }
                    else
                    {
                        if (Main.SearchStringIndex(StageNameList, Search_TB.Text, EntryCount, -1) != -1)
                        {
                            listBox1.SelectedIndex = Main.SearchStringIndex(StageNameList, Search_TB.Text, EntryCount, -1);
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

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    copied_MainSection_unk1 = (float)unk1_v.Value;
                    copied_MainSection_X_MysteriousPosition = (float)Glare_X_Pos.Value;
                    copied_MainSection_Y_MysteriousPosition = (float)Glare_Y_Pos.Value;
                    copied_MainSection_Z_MysteriousPosition = (float)Glare_Z_Pos.Value;
                    copied_MainSection_X_PositionGlarePoint = (float)lensFlare_X_Pos.Value;
                    copied_MainSection_Y_PositionGlarePoint = (float)lensFlare_Y_Pos.Value;
                    copied_MainSection_Z_PositionGlarePoint = (float)lensFlare_Z_Pos.Value;
                    copied_MainSection_X_PositionLightPoint = (float)Light_X_Pos.Value;
                    copied_MainSection_Y_PositionLightPoint = (float)Light_Y_Pos.Value;
                    copied_MainSection_Z_PositionLightPoint = (float)Light_Z_Pos.Value;
                    copied_MainSection_X_PositionShadow = (float)Shadow_X_Pos.Value;
                    copied_MainSection_Y_PositionShadow = (float)Shadow_Y_Pos.Value;
                    copied_MainSection_Z_PositionShadow = (float)Shadow_Z_Pos.Value;
                    copied_MainSection_PowerGlare = (float)Glare_power_value.Value;
                    copied_MainSection_blur = (float)BlurValue.Value;
                    copied_MainSection_PowerLight = (float)Light_power_value.Value;
                    copied_MainSectionGlareVagueness = (float)Vagueness_glare.Value;
                    copied_MainSection_MysteriousGlareValue1 = (float)M_Glare_Value1.Value;
                    copied_MainSection_MysteriousGlareValue2 = (float)M_Glare_Value2.Value;
                    copied_MainSection_MysteriousGlareValue2 = (float)M_Glare_Value3.Value;
                    copied_MainSection_UnknownValue1 = (float)unknown1_v.Value;
                    copied_MainSection_UnknownValue2 = (float)unknown2_v.Value;
                    copied_MainSection_UnknownValue3 = (float)unknown3_v.Value;
                    copied_MainSection_PowerSkyColor = (float)Sky_light_strength.Value;

                    int ColorGlare = Main.b_byteArrayToInt(MainSection_ColorGlare[x]);
                    copied_MainSection_ColorGlare = BitConverter.GetBytes(ColorGlare);

                    int ColorSky = Main.b_byteArrayToInt(MainSection_ColorSky[x]);
                    copied_MainSection_ColorSky = BitConverter.GetBytes(ColorSky);

                    int ColorRock = Main.b_byteArrayToInt(MainSection_ColorRock[x]);
                    copied_MainSection_ColorRock = BitConverter.GetBytes(ColorRock);

                    int ColorGroundEffect = Main.b_byteArrayToInt(MainSection_ColorGroundEffect[x]);
                    copied_MainSection_ColorGroundEffect = BitConverter.GetBytes(ColorGroundEffect);

                    int ColorPlayerLight = Main.b_byteArrayToInt(MainSection_ColorPlayerLight[x]);
                    copied_MainSection_ColorPlayerLight = BitConverter.GetBytes(ColorPlayerLight);

                    int ColorLight = Main.b_byteArrayToInt(MainSection_ColorLight[x]);
                    copied_MainSection_ColorLight = BitConverter.GetBytes(ColorLight);

                    int ColorShadow = Main.b_byteArrayToInt(MainSection_ColorShadow[x]);
                    copied_MainSection_ColorShadow = BitConverter.GetBytes(ColorShadow);

                    int ColorUnknown = Main.b_byteArrayToInt(MainSection_ColorUnknown[x]);
                    copied_MainSection_ColorUnknown = BitConverter.GetBytes(ColorUnknown);

                    int ColorUnknown2 = Main.b_byteArrayToInt(MainSection_ColorUnknown2[x]);
                    copied_MainSection_ColorUnknown2 = BitConverter.GetBytes(ColorUnknown2);

                    if (weather.Text == "snow")
                        copied_MainSection_WeatherSettings = 1;
                    else if (weather.Text == "rain")
                        copied_MainSection_WeatherSettings = 2;
                    else
                        copied_MainSection_WeatherSettings = 0;

                    if (LensFlare_combobox.SelectedIndex == 0)
                        copied_MainSection_lensFlareSettings = 0;
                    else if (LensFlare_combobox.SelectedIndex == 1)
                        copied_MainSection_lensFlareSettings = 1;
                    else if (LensFlare_combobox.SelectedIndex == 2)
                        copied_MainSection_lensFlareSettings = 2;
                    else if (LensFlare_combobox.SelectedIndex == 3)
                        copied_MainSection_lensFlareSettings = 3;
                    else if (LensFlare_combobox.SelectedIndex == 4)
                        copied_MainSection_lensFlareSettings = 4;
                    else if (LensFlare_combobox.SelectedIndex == 5)
                        copied_MainSection_lensFlareSettings = 5;

                    if (lensFlareEnabledText.Text == "Disabled")
                        copied_MainSection_EnablelensFlareSettings = 0;
                    else
                        copied_MainSection_EnablelensFlareSettings = 1;

                    if (glare1_cb.Checked == false)
                        copied_MainSection_EnableGlareSettingValue1 = 0;
                    else
                        copied_MainSection_EnableGlareSettingValue1 = 1;

                    if (glare2_cb.Checked == false)
                        copied_MainSection_EnableGlareSettingValue2 = 0;
                    else
                        copied_MainSection_EnableGlareSettingValue2 = 1;

                    if (glare3_cb.Checked == false)
                        copied_MainSection_EnableGlareSettingValue3 = 0;
                    else
                        copied_MainSection_EnableGlareSettingValue3 = 1;

                    if (shadow1_cb.Checked == false)
                        copied_MainSection_ShadowSetting_value1 = 0;
                    else
                        copied_MainSection_ShadowSetting_value1 = 1;

                    if (shadow2_cb.Checked == false)
                        copied_MainSection_ShadowSetting_value2 = 0;
                    else
                        copied_MainSection_ShadowSetting_value2 = 1;

                    copied_settings = true;
                    MessageBox.Show("Settings of " + StageNameList[x] + " were copied!");
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {   
                    if (copied_settings==true)
                    {
                        float new_MainSection_unk1 = copied_MainSection_unk1;
                        float new_MainSection_X_MysteriousPosition = copied_MainSection_X_MysteriousPosition;
                        float new_MainSection_Y_MysteriousPosition = copied_MainSection_Y_MysteriousPosition;
                        float new_MainSection_Z_MysteriousPosition = copied_MainSection_Z_MysteriousPosition;
                        float new_MainSection_X_PositionGlarePoint = copied_MainSection_X_PositionGlarePoint;
                        float new_MainSection_Y_PositionGlarePoint = copied_MainSection_Y_PositionGlarePoint;
                        float new_MainSection_Z_PositionGlarePoint = copied_MainSection_Z_PositionGlarePoint;
                        float new_MainSection_X_PositionLightPoint = copied_MainSection_X_PositionLightPoint;
                        float new_MainSection_Y_PositionLightPoint = copied_MainSection_Y_PositionLightPoint;
                        float new_MainSection_Z_PositionLightPoint = copied_MainSection_Z_PositionLightPoint;
                        float new_MainSection_X_PositionShadow = copied_MainSection_X_PositionShadow;
                        float new_MainSection_Y_PositionShadow = copied_MainSection_Y_PositionShadow;
                        float new_MainSection_Z_PositionShadow = copied_MainSection_Z_PositionShadow;
                        float new_MainSection_PowerGlare = copied_MainSection_PowerGlare;
                        float new_MainSection_blur = copied_MainSection_blur;
                        float new_MainSection_PowerLight = copied_MainSection_PowerLight;
                        float new_MainSectionGlareVagueness = copied_MainSectionGlareVagueness;
                        float new_MainSection_MysteriousGlareValue1 = copied_MainSection_MysteriousGlareValue1;
                        float new_MainSection_MysteriousGlareValue2 = copied_MainSection_MysteriousGlareValue2;
                        float new_MainSection_MysteriousGlareValue3 = copied_MainSection_MysteriousGlareValue3;
                        float new_MainSection_UnknownValue1 = copied_MainSection_UnknownValue1;
                        float new_MainSection_UnknownValue2 = copied_MainSection_UnknownValue2;
                        float new_MainSection_UnknownValue3 = copied_MainSection_UnknownValue3;

                        float new_MainSection_PowerSkyColor = copied_MainSection_PowerSkyColor;
                        byte[] new_MainSection_ColorGlare = copied_MainSection_ColorGlare;
                        byte[] new_MainSection_ColorSky = copied_MainSection_ColorSky;
                        byte[] new_MainSection_ColorRock = copied_MainSection_ColorRock;
                        byte[] new_MainSection_ColorGroundEffect = copied_MainSection_ColorGroundEffect;
                        byte[] new_MainSection_ColorPlayerLight = copied_MainSection_ColorPlayerLight;
                        byte[] new_MainSection_ColorLight = copied_MainSection_ColorLight;
                        byte[] new_MainSection_ColorShadow = copied_MainSection_ColorShadow;
                        byte[] new_MainSection_ColorUnknown = copied_MainSection_ColorUnknown;
                        byte[] new_MainSection_ColorUnknown2 = copied_MainSection_ColorUnknown2;
                        int new_MainSection_WeatherSettings = copied_MainSection_WeatherSettings;
                        int new_MainSection_lensFlareSettings = copied_MainSection_lensFlareSettings;
                        int new_MainSection_EnablelensFlareSettings = copied_MainSection_EnablelensFlareSettings;
                        int new_MainSection_EnableGlareSettingValue1 = copied_MainSection_EnableGlareSettingValue1;
                        int new_MainSection_EnableGlareSettingValue2 = copied_MainSection_EnableGlareSettingValue2;
                        int new_MainSection_EnableGlareSettingValue3 = copied_MainSection_EnableGlareSettingValue3;
                        int new_MainSection_ShadowSetting_value1 = copied_MainSection_ShadowSetting_value1;
                        int new_MainSection_ShadowSetting_value2 = copied_MainSection_ShadowSetting_value2;

                        MainSection_unk1[x] = new_MainSection_unk1;
                        MainSection_X_MysteriousPosition[x] = new_MainSection_X_MysteriousPosition;
                        MainSection_Y_MysteriousPosition[x] = new_MainSection_Y_MysteriousPosition;
                        MainSection_Z_MysteriousPosition[x] = new_MainSection_Z_MysteriousPosition;
                        MainSection_X_PositionGlarePoint[x] = new_MainSection_X_PositionGlarePoint;
                        MainSection_Y_PositionGlarePoint[x] = new_MainSection_Y_PositionGlarePoint;
                        MainSection_Z_PositionGlarePoint[x] = new_MainSection_Z_PositionGlarePoint;
                        MainSection_X_PositionLightPoint[x] = new_MainSection_X_PositionLightPoint;
                        MainSection_Y_PositionLightPoint[x] = new_MainSection_Y_PositionLightPoint;
                        MainSection_Z_PositionLightPoint[x] = new_MainSection_Z_PositionLightPoint;
                        MainSection_X_PositionShadow[x] = new_MainSection_X_PositionShadow;
                        MainSection_Y_PositionShadow[x] = new_MainSection_Y_PositionShadow;
                        MainSection_Z_PositionShadow[x] = new_MainSection_Z_PositionShadow;
                        MainSection_PowerGlare[x] = new_MainSection_PowerGlare;
                        MainSection_blur[x] = new_MainSection_blur;
                        MainSection_PowerLight[x] = new_MainSection_PowerLight;
                        MainSectionGlareVagueness[x] = new_MainSectionGlareVagueness;
                        MainSection_MysteriousGlareValue1[x] = new_MainSection_MysteriousGlareValue1;
                        MainSection_MysteriousGlareValue2[x] = new_MainSection_MysteriousGlareValue2;
                        MainSection_MysteriousGlareValue3[x] = new_MainSection_MysteriousGlareValue3;
                        MainSection_UnknownValue1[x] = new_MainSection_UnknownValue1;
                        MainSection_UnknownValue2[x] = new_MainSection_UnknownValue2;
                        MainSection_UnknownValue3[x] = new_MainSection_UnknownValue3;
                        MainSection_PowerSkyColor[x] = new_MainSection_PowerSkyColor;
                        MainSection_ColorGlare[x] = new_MainSection_ColorGlare;
                        MainSection_ColorSky[x] = new_MainSection_ColorSky;
                        MainSection_ColorRock[x] = new_MainSection_ColorRock;
                        MainSection_ColorGroundEffect[x] = new_MainSection_ColorGroundEffect;
                        MainSection_ColorPlayerLight[x] = new_MainSection_ColorPlayerLight;
                        MainSection_ColorLight[x] = new_MainSection_ColorLight;
                        MainSection_ColorShadow[x] = new_MainSection_ColorShadow;
                        MainSection_ColorUnknown[x] = new_MainSection_ColorUnknown;
                        MainSection_ColorUnknown2[x] = new_MainSection_ColorUnknown2;
                        MainSection_WeatherSettings[x] = new_MainSection_WeatherSettings;
                        MainSection_lensFlareSettings[x] = new_MainSection_lensFlareSettings;
                        MainSection_EnablelensFlareSettings[x] = new_MainSection_EnablelensFlareSettings;
                        MainSection_EnableGlareSettingValue1[x] = new_MainSection_EnableGlareSettingValue1;
                        MainSection_EnableGlareSettingValue2[x] = new_MainSection_EnableGlareSettingValue2;
                        MainSection_EnableGlareSettingValue3[x] = new_MainSection_EnableGlareSettingValue3;
                        MainSection_ShadowSetting_value1[x] = new_MainSection_ShadowSetting_value1;
                        MainSection_ShadowSetting_value2[x] = new_MainSection_ShadowSetting_value2;

                        unk1_v.Value = (decimal)copied_MainSection_unk1;
                        Glare_X_Pos.Value = (decimal)copied_MainSection_X_MysteriousPosition;
                        Glare_Y_Pos.Value = (decimal)copied_MainSection_Y_MysteriousPosition;
                        Glare_Z_Pos.Value = (decimal)copied_MainSection_Z_MysteriousPosition;
                        lensFlare_X_Pos.Value = (decimal)copied_MainSection_X_PositionGlarePoint;
                        lensFlare_Y_Pos.Value = (decimal)copied_MainSection_Y_PositionGlarePoint;
                        lensFlare_Z_Pos.Value = (decimal)copied_MainSection_Z_PositionGlarePoint;
                        Light_X_Pos.Value = (decimal)copied_MainSection_X_PositionLightPoint;
                        Light_Y_Pos.Value = (decimal)copied_MainSection_Y_PositionLightPoint;
                        Light_Z_Pos.Value = (decimal)copied_MainSection_Z_PositionLightPoint;
                        Shadow_X_Pos.Value = (decimal)copied_MainSection_X_PositionShadow;
                        Shadow_Y_Pos.Value = (decimal)copied_MainSection_Y_PositionShadow;
                        Shadow_Z_Pos.Value = (decimal)copied_MainSection_Z_PositionShadow;
                        Glare_power_value.Value = (decimal)copied_MainSection_PowerGlare;
                        BlurValue.Value = (decimal)copied_MainSection_blur;
                        Light_power_value.Value = (decimal)copied_MainSection_PowerLight;
                        Vagueness_glare.Value = (decimal)copied_MainSectionGlareVagueness;
                        M_Glare_Value1.Value = (decimal)copied_MainSection_MysteriousGlareValue1;
                        M_Glare_Value2.Value = (decimal)copied_MainSection_MysteriousGlareValue2;
                        M_Glare_Value3.Value = (decimal)copied_MainSection_MysteriousGlareValue3;
                        unknown1_v.Value = (decimal)copied_MainSection_UnknownValue1;
                        unknown2_v.Value = (decimal)copied_MainSection_UnknownValue2;
                        unknown3_v.Value = (decimal)copied_MainSection_UnknownValue3;
                        Sky_light_strength.Value = (decimal)copied_MainSection_PowerSkyColor;
                        GlareColorInfo_tb.Text = BitConverter.ToString(copied_MainSection_ColorGlare);
                        SkyColorInfo_tb.Text = BitConverter.ToString(copied_MainSection_ColorSky);
                        RockColorInfo_tb.Text = BitConverter.ToString(copied_MainSection_ColorRock);
                        GroundEffectColorInfo_tb.Text = BitConverter.ToString(copied_MainSection_ColorGroundEffect);
                        PlayerLightColorInfo_tb.Text = BitConverter.ToString(copied_MainSection_ColorPlayerLight);
                        LightColorInfo_tb.Text = BitConverter.ToString(copied_MainSection_ColorLight);
                        ShadowColorInfo_tb.Text = BitConverter.ToString(copied_MainSection_ColorShadow);
                        UnknownColorInfo_tb.Text = BitConverter.ToString(copied_MainSection_ColorUnknown);
                        Unknown2ColorInfo_tb.Text = BitConverter.ToString(copied_MainSection_ColorUnknown2);

                        if (copied_MainSection_WeatherSettings == 1)
                            weather.Text = "snow";
                        else if (copied_MainSection_WeatherSettings == 2)
                            weather.Text = "rain";
                        else
                            weather.Text = "No weather settings";

                        if (copied_MainSection_lensFlareSettings == 0)
                        {
                            lensFlareEnabledText.Text = "uviolet_lensFlare";
                        }
                        else if (copied_MainSection_lensFlareSettings == 1)
                        {
                            lensFlareEnabledText.Text = "oprism_lensFlare";
                        }
                        else if (copied_MainSection_lensFlareSettings == 2)
                        {
                            lensFlareEnabledText.Text = "phalo_lensFlare";
                        }
                        else if (copied_MainSection_lensFlareSettings == 3)
                        {
                            lensFlareEnabledText.Text = "gpurpose_lensFlare";
                        }
                        else if (copied_MainSection_lensFlareSettings == 4)
                        {
                            lensFlareEnabledText.Text = "mlight_lensFlare";
                        }
                        else if (copied_MainSection_lensFlareSettings == 5)
                        {
                            lensFlareEnabledText.Text = "sunset_lensFlare";
                        }

                        if (copied_MainSection_EnablelensFlareSettings == 0)
                            lensFlareEnabledText.Text = "Disabled";

                        if (copied_MainSection_EnableGlareSettingValue1 == 0)
                            glare1_cb.Checked = false;
                        else
                            glare1_cb.Checked = true;

                        if (copied_MainSection_EnableGlareSettingValue2 == 0)
                            glare2_cb.Checked = false;
                        else
                            glare2_cb.Checked = true;

                        if (copied_MainSection_EnableGlareSettingValue3 == 0)
                            glare3_cb.Checked = false;
                        else
                            glare3_cb.Checked = true;
                        if (copied_MainSection_ShadowSetting_value1 == 0)
                            shadow1_cb.Checked = false;
                        else
                            shadow1_cb.Checked = true;
                        if (copied_MainSection_ShadowSetting_value2 == 0)
                            shadow2_cb.Checked = false;
                        else
                            shadow2_cb.Checked = true;
                        MessageBox.Show("Settings of " + StageNameList[x] + " were changed and saved!");
                    }
                    else
                    {
                        MessageBox.Show("Settings weren't copied!");
                    }
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void SkyColorInfo_Click(object sender, EventArgs e)
        {

        }

        private void GlareColorInfo_Click(object sender, EventArgs e)
        {

        }

        private void RockColorInfo_Click(object sender, EventArgs e)
        {

        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4]
                         {
                    MainSection_ColorUnknown[x][3],
                    MainSection_ColorUnknown[x][2],
                    MainSection_ColorUnknown[x][1],
                    0x00
                         };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ColorReverse = new byte[4]
                        {
                    MyDialog.Color.A,
                    MyDialog.Color.B,
                    MyDialog.Color.G,
                    MyDialog.Color.R
                        };
                        MainSection_ColorUnknown[x] = Main.b_ReplaceBytes(MainSection_ColorUnknown[x], ColorReverse, 0, 0);
                        UnknownColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorUnknown[x]);
                    };
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_ColorUnknown[x] = Main.b_ReplaceBytes(MainSection_ColorUnknown[x], new byte[4] { 0x00, 0x00, 0x00, 0x00 }, 0, 0);
                    UnknownColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorUnknown[x]);
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_unk1[x] = (float)unk1_v.Value;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4]
                         {
                    MainSection_ColorUnknown2[x][3],
                    MainSection_ColorUnknown2[x][2],
                    MainSection_ColorUnknown2[x][1],
                    0x00
                         };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ColorReverse = new byte[4]
                        {
                    MyDialog.Color.A,
                    MyDialog.Color.B,
                    MyDialog.Color.G,
                    MyDialog.Color.R
                        };
                        MainSection_ColorUnknown2[x] = Main.b_ReplaceBytes(MainSection_ColorUnknown2[x], ColorReverse, 0, 0);
                        Unknown2ColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorUnknown2[x]);
                    };
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    MainSection_ColorUnknown2[x] = Main.b_ReplaceBytes(MainSection_ColorUnknown2[x], new byte[4] { 0x00, 0x00, 0x00, 0x00 }, 0, 0);
                    Unknown2ColorInfo_tb.Text = BitConverter.ToString(MainSection_ColorUnknown2[x]);
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
                
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    if (shadow1_cb.Checked == true)
                        MainSection_ShadowSetting_value1[x] = 1;
                    else
                        MainSection_ShadowSetting_value1[x] = 0;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void glare1_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    if (glare1_cb.Checked == true)
                        MainSection_EnableGlareSettingValue1[x] = 1;
                    else
                        MainSection_EnableGlareSettingValue1[x] = 0;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void glare2_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    if (glare2_cb.Checked == true)
                        MainSection_EnableGlareSettingValue2[x] = 1;
                    else
                        MainSection_EnableGlareSettingValue2[x] = 0;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void glare3_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    if (glare3_cb.Checked == true)
                        MainSection_EnableGlareSettingValue3[x] = 1;
                    else
                        MainSection_EnableGlareSettingValue3[x] = 0;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void shadow2_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (FileOpen)
            {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count)
                {
                    if (shadow2_cb.Checked == true)
                        MainSection_ShadowSetting_value2[x] = 1;
                    else
                        MainSection_ShadowSetting_value2[x] = 0;
                }
                else
                {
                    MessageBox.Show("No stage selected...", "Warning");
                }
            }
            else
            {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void saveToolStripMenuItem2_Click(object sender, EventArgs e)
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

        private void unk1_v_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Light_power_value_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MysteriousValue_ValueChanged(object sender, EventArgs e) {

        }
    }
}
