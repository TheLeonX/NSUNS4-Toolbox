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
    public partial class Tool_battleParamEditor : Form {
        public Tool_battleParamEditor() {
            InitializeComponent();
        }
        public byte[] fileBytes = new byte[0];
        public bool FileOpen = false;
        public string FilePath = "";
        public int EntryCount = 0;
        public List<string> BattleName_List = new List<string>();
        public List<string> Description_List = new List<string>();
        public List<int> Timer_List = new List<int>();
        public List<int> GameOverState_List = new List<int>();
        public List<string> StageName_List = new List<string>();

        //---------------Costume section----------------------

        public List<int> CostumeValue_List = new List<int>();
        public List<List<string>> CostumeMaterial_List = new List<List<string>>();
        public List<List<int>> CostumeMaterialValue_List = new List<List<int>>();

        //----------------Condition section-------------------------
        public List<List<string>> Condition_List = new List<List<string>>();

        //----------------Player section-------------------------
        public List<int> PlayerID_List = new List<int>();
        public List<int> PlayerSkillID_List = new List<int>();
        public List<int> PlayerUltID_List = new List<int>();
        public List<bool> PlayerDisableTrueAwakening_List = new List<bool>();
        public List<bool> PlayerEnableAltTexture_List = new List<bool>();
        public List<bool> PlayerUnknownValue1_List = new List<bool>();
        public List<bool> PlayerUnknownValue2_List = new List<bool>();
        public List<bool> PlayerActivateArmorBreakModel_List = new List<bool>();
        public List<bool> PlayerUnknownValue3_List = new List<bool>();
        public List<bool> PlayerEnableAwakeningFromStart_List = new List<bool>();

        //----------------Player support section-------------------------
        public List<List<int>> PlayerSupportID_List = new List<List<int>>();
        public List<List<int>> PlayerSupportSkillID_List = new List<List<int>>();
        public List<List<int>> PlayerSupportUltID_List = new List<List<int>>();
        public List<List<bool>> PlayerSupportDisableTrueAwakening_List = new List<List<bool>>();
        public List<List<bool>> PlayerSupportEnableAltTexture_List = new List<List<bool>>();
        public List<List<bool>> PlayerSupportUnknownValue1_List = new List<List<bool>>();
        public List<List<bool>> PlayerSupportDisableArmorBreak1_List = new List<List<bool>>();
        public List<List<bool>> PlayerSupportUnknownValue2_List = new List<List<bool>>();
        public List<List<bool>> PlayerSupportDisableArmorBreak2_List = new List<List<bool>>();
        public List<List<bool>> PlayerSupportEnableAwakeningFromStart_List = new List<List<bool>>();

        //----------------Enemy section-------------------------
        public List<int> EnemyID_List = new List<int>();
        public List<int> EnemySkillID_List = new List<int>();
        public List<int> EnemyUltID_List = new List<int>();
        public List<int> EnemyUnknownValue1_List = new List<int>();
        public List<bool> EnemyDisableTrueAwakening_List = new List<bool>();
        public List<bool> EnemyEnableAltTexture_List = new List<bool>();
        public List<bool> EnemyUnknownValue2_List = new List<bool>();
        public List<bool> EnemyActivateArmorBreakModel_List = new List<bool>();
        public List<bool> EnemyDisableSubstitution_List = new List<bool>();
        public List<bool> EnemyEnableAwakeningFromStart_List = new List<bool>();
        public List<int> EnemyLevel_List = new List<int>();

        //----------------Enemy support section-------------------------
        public List<List<int>> EnemySupportID_List = new List<List<int>>();
        public List<List<int>> EnemySupportSkillID_List = new List<List<int>>();
        public List<List<int>> EnemySupportUltID_List = new List<List<int>>();
        public List<List<bool>> EnemySupportDisableTrueAwakening_List = new List<List<bool>>();
        public List<List<bool>> EnemySupportEnableAltTexture_List = new List<List<bool>>();
        public List<List<bool>> EnemySupportUnknownValue1_List = new List<List<bool>>();
        public List<List<bool>> EnemySupportDisableArmorBreak1_List = new List<List<bool>>();
        public List<List<bool>> EnemySupportDisableSubstitution_List = new List<List<bool>>();
        public List<List<bool>> EnemySupportDisableArmorBreak2_List = new List<List<bool>>();
        public List<List<bool>> EnemySupportEnableAwakeningFromStart_List = new List<List<bool>>();

        //---------------------------------------------------------------------------------
        public List<bool> AltWinPlayer_List = new List<bool>();
        public List<bool> AltWinPlayerSupport1_List = new List<bool>();
        public List<bool> AltWinPlayerSupport2_List = new List<bool>();
        public List<string> AltWinPlayerQuote_List = new List<string>();
        public List<string> AltWinPlayerSupport1Quote_List = new List<string>();
        public List<string> AltWinPlayerSupport2Quote_List = new List<string>();
        public List<int> BGM_List = new List<int>();
        public List<int> BattleCondition_List = new List<int>();
        private void Tool_battleParamEditor_Load(object sender, EventArgs e) {
            if (File.Exists(Main.battleParamPath)) {
                OpenFile(Main.battleParamPath);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFile();
        }
        public void CloseFile() {
            ClearFile();
            FileOpen = false;
            FilePath = "";
        }
        private void ClearFile() {
            FileOpen = false;
            FilePath = "";
            EntryCount = 0;
            BattleName_List = new List<string>();
            Description_List = new List<string>();
            Timer_List = new List<int>();
            GameOverState_List = new List<int>();
            StageName_List = new List<string>();
            CostumeValue_List = new List<int>();
            CostumeMaterial_List = new List<List<string>>();
            CostumeMaterialValue_List = new List<List<int>>();
            Condition_List = new List<List<string>>();
            PlayerID_List = new List<int>();
            PlayerSkillID_List = new List<int>();
            PlayerUltID_List = new List<int>();
            PlayerDisableTrueAwakening_List = new List<bool>();
            PlayerEnableAltTexture_List = new List<bool>();
            PlayerUnknownValue1_List = new List<bool>();
            PlayerUnknownValue2_List = new List<bool>();
            PlayerActivateArmorBreakModel_List = new List<bool>();
            PlayerUnknownValue3_List = new List<bool>();
            PlayerEnableAwakeningFromStart_List = new List<bool>();
            PlayerSupportID_List = new List<List<int>>();
            PlayerSupportSkillID_List = new List<List<int>>();
            PlayerSupportUltID_List = new List<List<int>>();
            PlayerSupportDisableTrueAwakening_List = new List<List<bool>>();
            PlayerSupportEnableAltTexture_List = new List<List<bool>>();
            PlayerSupportUnknownValue1_List = new List<List<bool>>();
            PlayerSupportDisableArmorBreak1_List = new List<List<bool>>();
            PlayerSupportUnknownValue2_List = new List<List<bool>>();
            PlayerSupportDisableArmorBreak2_List = new List<List<bool>>();
            PlayerSupportEnableAwakeningFromStart_List = new List<List<bool>>();
            EnemyID_List = new List<int>();
            EnemySkillID_List = new List<int>();
            EnemyUltID_List = new List<int>();
            EnemyUnknownValue1_List = new List<int>();
            EnemyDisableTrueAwakening_List = new List<bool>();
            EnemyEnableAltTexture_List = new List<bool>();
            EnemyUnknownValue2_List = new List<bool>();
            EnemyActivateArmorBreakModel_List = new List<bool>();
            EnemyDisableSubstitution_List = new List<bool>();
            EnemyEnableAwakeningFromStart_List = new List<bool>();
            EnemyLevel_List = new List<int>();
            EnemySupportID_List = new List<List<int>>();
            EnemySupportSkillID_List = new List<List<int>>();
            EnemySupportUltID_List = new List<List<int>>();
            EnemySupportDisableTrueAwakening_List = new List<List<bool>>();
            EnemySupportEnableAltTexture_List = new List<List<bool>>();
            EnemySupportUnknownValue1_List = new List<List<bool>>();
            EnemySupportDisableArmorBreak1_List = new List<List<bool>>();
            EnemySupportDisableSubstitution_List = new List<List<bool>>();
            EnemySupportDisableArmorBreak2_List = new List<List<bool>>();
            EnemySupportEnableAwakeningFromStart_List = new List<List<bool>>();
            AltWinPlayer_List = new List<bool>();
            AltWinPlayerSupport1_List = new List<bool>();
            AltWinPlayerSupport2_List = new List<bool>();
            AltWinPlayerQuote_List = new List<string>();
            AltWinPlayerSupport1Quote_List = new List<string>();
            AltWinPlayerSupport2Quote_List = new List<string>();
            BGM_List = new List<int>();
            BattleCondition_List = new List<int>();
            listBox1.Items.Clear();
        }
        private void OpenFile(string basepath = "") {
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
            byte[] FileBytes = File.ReadAllBytes(FilePath);
            EntryCount = FileBytes[0x120] + FileBytes[0x121] * 256 + FileBytes[0x122] * 65536 + FileBytes[0x123] * 16777216;
            for (int x2 = 0; x2 < EntryCount; x2++) {
                long _ptr = 0x12C + 0x110 * x2;
                string BattleName = "";
                long _ptrIcon3 = FileBytes[_ptr] + FileBytes[_ptr + 1] * 256 + FileBytes[_ptr + 2] * 65536 + FileBytes[_ptr + 3] * 16777216;
                for (int a2 = 0; a2 < 120; a2++) {

                    if (FileBytes[_ptr + 0 + _ptrIcon3 + a2] != 0) {
                        string str2 = BattleName;
                        char c = (char)FileBytes[_ptr + 0 + _ptrIcon3 + a2];
                        BattleName = str2 + c;
                    } else {
                        a2 = 120;
                    }
                }
                string Description = "";
                _ptrIcon3 = FileBytes[_ptr + 8] + FileBytes[_ptr + 9] * 256 + FileBytes[_ptr + 10] * 65536 + FileBytes[_ptr + 11] * 16777216;
                for (int a2 = 0; a2 < 120; a2++) {

                    if (FileBytes[_ptr + 8 + _ptrIcon3 + a2] != 0) {
                        string str2 = Description;
                        char c = (char)FileBytes[_ptr + 8 + _ptrIcon3 + a2];
                        Description = str2 + c;
                    } else {
                        a2 = 120;
                    }
                }
                int Timer = FileBytes[_ptr + 0x14] + FileBytes[_ptr + 0x15] * 256 + FileBytes[_ptr + 0x16] * 65536 + FileBytes[_ptr + 0x17] * 16777216;
                int GameOverState = FileBytes[_ptr + 0x18];

                string StageName = "";
                _ptrIcon3 = FileBytes[_ptr + 0x20] + FileBytes[_ptr + 0x21] * 256 + FileBytes[_ptr + 0x22] * 65536 + FileBytes[_ptr + 0x23] * 16777216;
                for (int a2 = 0; a2 < 120; a2++) {

                    if (FileBytes[_ptr + 0x20 + _ptrIcon3 + a2] != 0) {
                        string str2 = StageName;
                        char c = (char)FileBytes[_ptr + 0x20 + _ptrIcon3 + a2];
                        StageName = str2 + c;
                    } else {
                        a2 = 120;
                    }
                }

                long CostumeSection_ptr = (FileBytes[_ptr + 0x30] + FileBytes[_ptr + 0x31] * 256 + FileBytes[_ptr + 0x32] * 65536 + FileBytes[_ptr + 0x33] * 16777216) + _ptr + 0x30;
                int CostumeValue = FileBytes[CostumeSection_ptr] + FileBytes[CostumeSection_ptr + 0x1] * 256 + FileBytes[CostumeSection_ptr + 0x2] * 65536 + FileBytes[CostumeSection_ptr + 0x3] * 16777216;
                List<string> CostumeMaterial = new List<string>();
                List<int> CostumeMaterialValue = new List<int>();
                for (int y = 0; y < 7; y++) {
                    string CostumeMaterial_str = "";
                    for (int a2 = 0; a2 < 200; a2++) {
                        _ptrIcon3 = FileBytes[CostumeSection_ptr + 0x8 + (y * 0x8)] + FileBytes[CostumeSection_ptr + 0x9 + (y * 0x8)] * 256 + FileBytes[CostumeSection_ptr + 0x0A + (y * 0x8)] * 65536 + FileBytes[CostumeSection_ptr + 0x0B + (y * 0x8)] * 16777216;

                        if (FileBytes[CostumeSection_ptr + 0x08 + _ptrIcon3 + a2 + (y * 0x8)] != 0) {
                            string str2 = CostumeMaterial_str;
                            char c = (char)FileBytes[CostumeSection_ptr + 0x08 + _ptrIcon3 + a2 + (y * 0x8)];
                            CostumeMaterial_str = str2 + c;
                        } else {
                            a2 = 200;
                        }
                    }
                    CostumeMaterial.Add(CostumeMaterial_str);
                    int CostumeMaterialValue_int = FileBytes[CostumeSection_ptr + 0x48 + (y * 0x4)];
                    CostumeMaterialValue.Add(CostumeMaterialValue_int);
                }
                List<string> Condition = new List<string>();
                for (int y = 0; y < 14; y++) {
                    string Condition_str = "";
                    _ptrIcon3 = FileBytes[_ptr + 0x38 + (y * 0x8)] + FileBytes[_ptr + 0x39 + (y * 0x8)] * 256 + FileBytes[_ptr + 0x3A + (y * 0x8)] * 65536 + FileBytes[_ptr + 0x3B + (y * 0x8)] * 16777216;
                    for (int a2 = 0; a2 < 200; a2++) {
                        if (FileBytes[_ptr + 0x38 + (y * 0x8) + _ptrIcon3 + a2] != 0) {
                            string str2 = Condition_str;
                            char c = (char)FileBytes[_ptr + 0x38 + (y * 0x8) + _ptrIcon3 + a2];
                            Condition_str = str2 + c;
                        } else {
                            a2 = 200;
                        }
                    }
                    Condition.Add(Condition_str);
                }

                long PlayerSection_ptr = FileBytes[_ptr + 0xA8] + FileBytes[_ptr + 0xA9] * 256 + FileBytes[_ptr + 0xAA] * 65536 + FileBytes[_ptr + 0xAB] * 16777216 + _ptr + 0xA8;
                int PlayerID = FileBytes[PlayerSection_ptr + 0x00] + FileBytes[PlayerSection_ptr + 0x01] * 256 + FileBytes[PlayerSection_ptr + 0x02] * 65536 + FileBytes[PlayerSection_ptr + 0x03] * 16777216;
                int PlayerSkillID = FileBytes[PlayerSection_ptr + 0x04] + FileBytes[PlayerSection_ptr + 0x05] + FileBytes[PlayerSection_ptr + 0x06] + FileBytes[PlayerSection_ptr + 0x07];
                int PlayerUltID = FileBytes[PlayerSection_ptr + 0x08] + FileBytes[PlayerSection_ptr + 0x09] + FileBytes[PlayerSection_ptr + 0x0A] + FileBytes[PlayerSection_ptr + 0x0B];
                bool PlayerDisableTrueAwakening = Convert.ToBoolean(FileBytes[PlayerSection_ptr + 0x0C]);
                bool PlayerEnableAltTexture = Convert.ToBoolean(FileBytes[PlayerSection_ptr + 0x10]);
                bool PlayerUnknownValue1 = Convert.ToBoolean(FileBytes[PlayerSection_ptr + 0x14]);
                bool PlayerUnknownValue2 = Convert.ToBoolean(FileBytes[PlayerSection_ptr + 0x18]);
                bool PlayerActivateArmorBreakModel = Convert.ToBoolean(FileBytes[PlayerSection_ptr + 0x1C]);
                bool PlayerUnknownValue3 = Convert.ToBoolean(FileBytes[PlayerSection_ptr + 0x20]);
                bool PlayerEnableAwakeningFromStart = Convert.ToBoolean(FileBytes[PlayerSection_ptr + 0x24]);

                List<int> PlayerSupportID_l = new List<int>();
                List<int> PlayerSupportSkillID_l = new List<int>();
                List<int> PlayerSupportUltID_l = new List<int>();
                List<bool> PlayerSupportDisableTrueAwakening_l = new List<bool>();
                List<bool> PlayerSupportEnableAltTexture_l = new List<bool>();
                List<bool> PlayerSupportUnknownValue1_l = new List<bool>();
                List<bool> PlayerSupportDisableArmorBreak1_l = new List<bool>();
                List<bool> PlayerSupportUnknownValue2_l = new List<bool>();
                List<bool> PlayerSupportDisableArmorBreak2_l = new List<bool>();
                List<bool> PlayerSupportEnableAwakeningFromStart_l = new List<bool>();
                for (int y = 0; y < 2; y++) {
                    long PlayerSupportSection_ptr = FileBytes[_ptr + 0xB0 + (y * 0x8)] + FileBytes[_ptr + 0xB1 + (y * 0x8)] * 256 + FileBytes[_ptr + 0xB2 + (y * 0x8)] * 65536 + FileBytes[_ptr + 0xB3 + (y * 0x8)] * 16777216 + _ptr + 0xB0 + (y * 0x8);
                    int PlayerSupportID = FileBytes[PlayerSupportSection_ptr + 0x00] + FileBytes[PlayerSupportSection_ptr + 0x01] * 256 + FileBytes[PlayerSupportSection_ptr + 0x02] * 65536 + FileBytes[PlayerSupportSection_ptr + 0x03] * 16777216;
                    int PlayerSupportSkillID = FileBytes[PlayerSupportSection_ptr + 0x04] + FileBytes[PlayerSupportSection_ptr + 0x05] * 256 + FileBytes[PlayerSupportSection_ptr + 0x06] * 65536 + FileBytes[PlayerSupportSection_ptr + 0x07] * 16777216;
                    int PlayerSupportUltID = FileBytes[PlayerSupportSection_ptr + 0x08] + FileBytes[PlayerSupportSection_ptr + 0x09] * 256 + FileBytes[PlayerSupportSection_ptr + 0x0A] * 65536 + FileBytes[PlayerSupportSection_ptr + 0x0B] * 16777216;
                    bool PlayerSupportDisableTrueAwakening = Convert.ToBoolean(FileBytes[PlayerSupportSection_ptr + 0x0C]);
                    bool PlayerSupportEnableAltTexture = Convert.ToBoolean(FileBytes[PlayerSupportSection_ptr + 0x10]);
                    bool PlayerSupportUnknownValue1 = Convert.ToBoolean(FileBytes[PlayerSupportSection_ptr + 0x14]);
                    bool PlayerSupportDisableArmorBreak1 = Convert.ToBoolean(FileBytes[PlayerSupportSection_ptr + 0x18]);
                    bool PlayerSupportUnknownValue2 = Convert.ToBoolean(FileBytes[PlayerSupportSection_ptr + 0x1C]);
                    bool PlayerSupportDisableArmorBreak2 = Convert.ToBoolean(FileBytes[PlayerSupportSection_ptr + 0x20]);
                    bool PlayerSupportEnableAwakeningFromStart = Convert.ToBoolean(FileBytes[PlayerSupportSection_ptr + 0x24]);
                    PlayerSupportID_l.Add(PlayerSupportID);
                    PlayerSupportSkillID_l.Add(PlayerSupportSkillID);
                    PlayerSupportUltID_l.Add(PlayerSupportUltID);
                    PlayerSupportDisableTrueAwakening_l.Add(PlayerSupportDisableTrueAwakening);
                    PlayerSupportEnableAltTexture_l.Add(PlayerSupportEnableAltTexture);
                    PlayerSupportUnknownValue1_l.Add(PlayerSupportUnknownValue1);
                    PlayerSupportDisableArmorBreak1_l.Add(PlayerSupportDisableArmorBreak1);
                    PlayerSupportUnknownValue2_l.Add(PlayerSupportUnknownValue2);
                    PlayerSupportDisableArmorBreak2_l.Add(PlayerSupportDisableArmorBreak2);
                    PlayerSupportEnableAwakeningFromStart_l.Add(PlayerSupportEnableAwakeningFromStart);
                }

                long EnemySection_ptr = FileBytes[_ptr + 0xC0] + FileBytes[_ptr + 0xC1] * 256 + FileBytes[_ptr + 0xC2] * 65536 + FileBytes[_ptr + 0xC3] * 16777216 + _ptr + 0xC0;
                int EnemyID = FileBytes[EnemySection_ptr + 0x00] + FileBytes[EnemySection_ptr + 0x01] * 256 + FileBytes[EnemySection_ptr + 0x02] * 65536 + FileBytes[EnemySection_ptr + 0x03] * 16777216;
                int EnemySkillID = FileBytes[EnemySection_ptr + 0x04] + FileBytes[EnemySection_ptr + 0x05] * 256 + FileBytes[EnemySection_ptr + 0x06] * 65536 + FileBytes[EnemySection_ptr + 0x07] * 16777216;
                int EnemyUltID = FileBytes[EnemySection_ptr + 0x08] + FileBytes[EnemySection_ptr + 0x09] * 256 + FileBytes[EnemySection_ptr + 0x0A] * 65536 + FileBytes[EnemySection_ptr + 0x0B] * 16777216;
                int EnemyUnknownValue1 = FileBytes[EnemySection_ptr + 0x0C] + FileBytes[EnemySection_ptr + 0x0D] * 256 + FileBytes[EnemySection_ptr + 0x0E] * 65536 + FileBytes[EnemySection_ptr + 0x0F] * 16777216;
                bool EnemyDisableTrueAwakening = Convert.ToBoolean(FileBytes[EnemySection_ptr + 0x10]);
                bool EnemyEnableAltTexture = Convert.ToBoolean(FileBytes[EnemySection_ptr + 0x14]);
                bool EnemyUnknownValue2 = Convert.ToBoolean(FileBytes[EnemySection_ptr + 0x1C]);
                bool EnemyActivateArmorBreakModel = Convert.ToBoolean(FileBytes[EnemySection_ptr + 0x20]);
                bool EnemyDisableSubstitution = Convert.ToBoolean(FileBytes[EnemySection_ptr + 0x24]);
                bool EnemyEnableAwakeningFromStart = Convert.ToBoolean(FileBytes[EnemySection_ptr + 0x28]);
                int EnemyLevel = FileBytes[EnemySection_ptr + 0x2C];

                List<int> EnemySupportID_l = new List<int>();
                List<int> EnemySupportSkillID_l = new List<int>();
                List<int> EnemySupportUltID_l = new List<int>();
                List<bool> EnemySupportDisableTrueAwakening_l = new List<bool>();
                List<bool> EnemySupportEnableAltTexture_l = new List<bool>();
                List<bool> EnemySupportUnknownValue1_l = new List<bool>();
                List<bool> EnemySupportDisableArmorBreak1_l = new List<bool>();
                List<bool> EnemySupportDisableSubstitution_l = new List<bool>();
                List<bool> EnemySupportDisableArmorBreak2_l = new List<bool>();
                List<bool> EnemySupportEnableAwakeningFromStart_l = new List<bool>();
                for (int y = 0; y < 2; y++) {
                    long EnemySupportSection_ptr = FileBytes[_ptr + 0xC8 + (y * 0x8)] + FileBytes[_ptr + 0xC9 + (y * 0x8)] * 256 + FileBytes[_ptr + 0xCA + (y * 0x8)] * 65536 + FileBytes[_ptr + 0xCB + (y * 0x8)] * 16777216 + _ptr + 0xC8 + (y * 0x8);
                    int EnemySupportID = FileBytes[EnemySupportSection_ptr + 0x00] + FileBytes[EnemySupportSection_ptr + 0x01] * 256 + FileBytes[EnemySupportSection_ptr + 0x02] * 65536 + FileBytes[EnemySupportSection_ptr + 0x03] * 16777216;
                    int EnemySupportSkillID = FileBytes[EnemySupportSection_ptr + 0x04] + FileBytes[EnemySupportSection_ptr + 0x05] * 256 + FileBytes[EnemySupportSection_ptr + 0x06] * 65536 + FileBytes[EnemySupportSection_ptr + 0x07] * 16777216;
                    int EnemySupportUltID = FileBytes[EnemySupportSection_ptr + 0x08] + FileBytes[EnemySupportSection_ptr + 0x09] * 256 + FileBytes[EnemySupportSection_ptr + 0x0A] * 65536 + FileBytes[EnemySupportSection_ptr + 0x0B] * 16777216;
                    bool EnemySupportDisableTrueAwakening = Convert.ToBoolean(FileBytes[EnemySupportSection_ptr + 0x0C]);
                    bool EnemySupportEnableAltTexture = Convert.ToBoolean(FileBytes[EnemySupportSection_ptr + 0x14]);
                    bool EnemySupportUnknownValue1 = Convert.ToBoolean(FileBytes[EnemySupportSection_ptr + 0x18]);
                    bool EnemySupportDisableArmorBreak1 = Convert.ToBoolean(FileBytes[EnemySupportSection_ptr + 0x1C]);
                    bool EnemySupportDisableSubstitution = Convert.ToBoolean(FileBytes[EnemySupportSection_ptr + 0x20]);
                    bool EnemySupportDisableArmorBreak2 = Convert.ToBoolean(FileBytes[EnemySupportSection_ptr + 0x24]);
                    bool EnemySupportEnableAwakeningFromStart = Convert.ToBoolean(FileBytes[EnemySupportSection_ptr + 0x28]);
                    EnemySupportID_l.Add(EnemySupportID);
                    EnemySupportSkillID_l.Add(EnemySupportSkillID);
                    EnemySupportUltID_l.Add(EnemySupportUltID);
                    EnemySupportDisableTrueAwakening_l.Add(EnemySupportDisableTrueAwakening);
                    EnemySupportEnableAltTexture_l.Add(EnemySupportEnableAltTexture);
                    EnemySupportUnknownValue1_l.Add(EnemySupportUnknownValue1);
                    EnemySupportDisableArmorBreak1_l.Add(EnemySupportDisableArmorBreak1);
                    EnemySupportDisableSubstitution_l.Add(EnemySupportDisableSubstitution);
                    EnemySupportDisableArmorBreak2_l.Add(EnemySupportDisableArmorBreak2);
                    EnemySupportEnableAwakeningFromStart_l.Add(EnemySupportEnableAwakeningFromStart);
                }
                bool AltWinPlayer = Convert.ToBoolean(FileBytes[_ptr + 0xD8]);
                bool AltWinPlayerSupport1 = Convert.ToBoolean(FileBytes[_ptr + 0xDC]);
                bool AltWinPlayerSupport2 = Convert.ToBoolean(FileBytes[_ptr + 0xE0]);

                string AltWinPlayerQuote = "";
                _ptrIcon3 = FileBytes[_ptr + 0xE8] + FileBytes[_ptr + 0xE9] * 256 + FileBytes[_ptr + 0xEA] * 65536 + FileBytes[_ptr + 0xEB] * 16777216;
                for (int a2 = 0; a2 < 200; a2++) {

                    if (FileBytes[_ptr + 0xE8 + _ptrIcon3 + a2] != 0) {
                        string str2 = AltWinPlayerQuote;
                        char c = (char)FileBytes[_ptr + 0xE8 + _ptrIcon3 + a2];
                        AltWinPlayerQuote = str2 + c;
                    } else {
                        a2 = 200;
                    }
                }
                string AltWinPlayerSupport1Quote = "";
                _ptrIcon3 = FileBytes[_ptr + 0xF0] + FileBytes[_ptr + 0xF1] * 256 + FileBytes[_ptr + 0xF2] * 65536 + FileBytes[_ptr + 0xF3] * 16777216;
                for (int a2 = 0; a2 < 200; a2++) {

                    if (FileBytes[_ptr + 0xF0 + _ptrIcon3 + a2] != 0) {
                        string str2 = AltWinPlayerSupport1Quote;
                        char c = (char)FileBytes[_ptr + 0xF0 + _ptrIcon3 + a2];
                        AltWinPlayerSupport1Quote = str2 + c;
                    } else {
                        a2 = 200;
                    }
                }
                string AltWinPlayerSupport2Quote = "";
                _ptrIcon3 = FileBytes[_ptr + 0xF8] + FileBytes[_ptr + 0xF9] * 256 + FileBytes[_ptr + 0xFA] * 65536 + FileBytes[_ptr + 0xFB] * 16777216;
                for (int a2 = 0; a2 < 200; a2++) {

                    if (FileBytes[_ptr + 0xF8 + _ptrIcon3 + a2] != 0) {
                        string str2 = AltWinPlayerSupport2Quote;
                        char c = (char)FileBytes[_ptr + 0xF8 + _ptrIcon3 + a2];
                        AltWinPlayerSupport2Quote = str2 + c;
                    } else {
                        a2 = 200;
                    }
                }
                int BGM_ID = FileBytes[_ptr + 0x100] + FileBytes[_ptr + 0x101] * 256 + FileBytes[_ptr + 0x102] * 65536 + FileBytes[_ptr + 0x103] * 16777216;
                int BattleCondition = FileBytes[_ptr + 0x104] + FileBytes[_ptr + 0x105] * 256 + FileBytes[_ptr + 0x106] * 65536 + FileBytes[_ptr + 0x107] * 16777216;

                BattleName_List.Add(BattleName);
                Description_List.Add(Description);
                Timer_List.Add(Timer);
                GameOverState_List.Add(GameOverState);
                StageName_List.Add(StageName);
                CostumeValue_List.Add(CostumeValue);
                CostumeMaterial_List.Add(CostumeMaterial);
                CostumeMaterialValue_List.Add(CostumeMaterialValue);
                Condition_List.Add(Condition);
                PlayerID_List.Add(PlayerID);
                PlayerSkillID_List.Add(PlayerSkillID);
                PlayerUltID_List.Add(PlayerUltID);
                PlayerDisableTrueAwakening_List.Add(PlayerDisableTrueAwakening);
                PlayerEnableAltTexture_List.Add(PlayerEnableAltTexture);
                PlayerUnknownValue1_List.Add(PlayerUnknownValue1);
                PlayerUnknownValue2_List.Add(PlayerUnknownValue2);
                PlayerActivateArmorBreakModel_List.Add(PlayerActivateArmorBreakModel);
                PlayerUnknownValue3_List.Add(PlayerUnknownValue3);
                PlayerEnableAwakeningFromStart_List.Add(PlayerEnableAwakeningFromStart);
                PlayerSupportID_List.Add(PlayerSupportID_l);
                PlayerSupportSkillID_List.Add(PlayerSupportSkillID_l);
                PlayerSupportUltID_List.Add(PlayerSupportUltID_l);
                PlayerSupportDisableTrueAwakening_List.Add(PlayerSupportDisableTrueAwakening_l);
                PlayerSupportEnableAltTexture_List.Add(PlayerSupportEnableAltTexture_l);
                PlayerSupportUnknownValue1_List.Add(PlayerSupportUnknownValue1_l);
                PlayerSupportDisableArmorBreak1_List.Add(PlayerSupportDisableArmorBreak1_l);
                PlayerSupportUnknownValue2_List.Add(PlayerSupportUnknownValue2_l);
                PlayerSupportDisableArmorBreak2_List.Add(PlayerSupportDisableArmorBreak2_l);
                PlayerSupportEnableAwakeningFromStart_List.Add(PlayerSupportEnableAwakeningFromStart_l);
                EnemyID_List.Add(EnemyID);
                EnemySkillID_List.Add(EnemySkillID);
                EnemyUltID_List.Add(EnemyUltID);
                EnemyUnknownValue1_List.Add(EnemyUnknownValue1);
                EnemyDisableTrueAwakening_List.Add(EnemyDisableTrueAwakening);
                EnemyEnableAltTexture_List.Add(EnemyEnableAltTexture);
                EnemyUnknownValue2_List.Add(EnemyUnknownValue2);
                EnemyActivateArmorBreakModel_List.Add(EnemyActivateArmorBreakModel);
                EnemyDisableSubstitution_List.Add(EnemyDisableSubstitution);
                EnemyEnableAwakeningFromStart_List.Add(EnemyEnableAwakeningFromStart);
                EnemyLevel_List.Add(EnemyLevel);
                EnemySupportID_List.Add(EnemySupportID_l);
                EnemySupportSkillID_List.Add(EnemySupportSkillID_l);
                EnemySupportUltID_List.Add(EnemySupportUltID_l);
                EnemySupportDisableTrueAwakening_List.Add(EnemySupportDisableTrueAwakening_l);
                EnemySupportEnableAltTexture_List.Add(EnemySupportEnableAltTexture_l);
                EnemySupportUnknownValue1_List.Add(EnemySupportUnknownValue1_l);
                EnemySupportDisableArmorBreak1_List.Add(EnemySupportDisableArmorBreak1_l);
                EnemySupportDisableSubstitution_List.Add(EnemySupportDisableSubstitution_l);
                EnemySupportDisableArmorBreak2_List.Add(EnemySupportDisableArmorBreak2_l);
                EnemySupportEnableAwakeningFromStart_List.Add(EnemySupportEnableAwakeningFromStart_l);
                AltWinPlayer_List.Add(AltWinPlayer);
                AltWinPlayerSupport1_List.Add(AltWinPlayerSupport1);
                AltWinPlayerSupport2_List.Add(AltWinPlayerSupport2);
                AltWinPlayerQuote_List.Add(AltWinPlayerQuote);
                AltWinPlayerSupport1Quote_List.Add(AltWinPlayerSupport1Quote);
                AltWinPlayerSupport2Quote_List.Add(AltWinPlayerSupport2Quote);
                BGM_List.Add(BGM_ID);
                BattleCondition_List.Add(BattleCondition);

                listBox1.Items.Add(BattleName);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                textBox2.Text = BattleName_List[x];
                numericUpDown1.Value = Timer_List[x];
                textBox3.Text = Description_List[x];
                textBox4.Text = StageName_List[x];
                numericUpDown37.Value = BGM_List[x];
                comboBox13.SelectedIndex = GameOverState_List[x];
                numericUpDown38.Value = BattleCondition_List[x];
                checkBox1.Checked = AltWinPlayer_List[x];
                checkBox2.Checked = AltWinPlayerSupport1_List[x];
                checkBox3.Checked = AltWinPlayerSupport2_List[x];
                //CONDITION SECTION
                textBox5.Text = Condition_List[x][0];
                textBox6.Text = Condition_List[x][1];
                textBox7.Text = Condition_List[x][2];
                textBox8.Text = Condition_List[x][3];
                textBox10.Text = Condition_List[x][4];
                textBox9.Text = Condition_List[x][5];
                textBox11.Text = Condition_List[x][6];
                textBox12.Text = Condition_List[x][7];
                textBox13.Text = Condition_List[x][8];
                textBox14.Text = Condition_List[x][9];
                textBox18.Text = Condition_List[x][10];
                textBox19.Text = Condition_List[x][11];
                textBox27.Text = Condition_List[x][12];
                textBox28.Text = Condition_List[x][13];
                //COSTUME MATERIAL SECTION
                textBox20.Text = CostumeMaterial_List[x][0];
                textBox21.Text = CostumeMaterial_List[x][1];
                textBox22.Text = CostumeMaterial_List[x][2];
                textBox23.Text = CostumeMaterial_List[x][3];
                textBox24.Text = CostumeMaterial_List[x][4];
                textBox25.Text = CostumeMaterial_List[x][5];
                textBox26.Text = CostumeMaterial_List[x][6];
                numericUpDown39.Value = CostumeMaterialValue_List[x][0];
                numericUpDown40.Value = CostumeMaterialValue_List[x][1];
                numericUpDown42.Value = CostumeMaterialValue_List[x][2];
                numericUpDown41.Value = CostumeMaterialValue_List[x][3];
                numericUpDown44.Value = CostumeMaterialValue_List[x][4];
                numericUpDown43.Value = CostumeMaterialValue_List[x][5];
                numericUpDown45.Value = CostumeMaterialValue_List[x][6];
                numericUpDown46.Value = CostumeValue_List[x];
                //PLAYER SECTION
                numericUpDown3.Value = PlayerID_List[x];
                comboBox6.SelectedIndex = Convert.ToInt32(PlayerEnableAwakeningFromStart_List[x]);
                if (PlayerSkillID_List[x] > -1 && PlayerSkillID_List[x] <= 5) {
                    comboBox7.SelectedIndex = Convert.ToInt32(PlayerSkillID_List[x]);
                } else {
                    comboBox7.SelectedIndex = 6;
                }
                if (PlayerUltID_List[x] > -1 && PlayerUltID_List[x] <= 3) {
                    comboBox8.SelectedIndex = Convert.ToInt32(PlayerUltID_List[x]);
                } else {
                    comboBox8.SelectedIndex = 4;
                }
                checkBox6.Checked = PlayerEnableAltTexture_List[x];
                checkBox4.Checked = PlayerDisableTrueAwakening_List[x];
                checkBox5.Checked = PlayerUnknownValue1_List[x];
                checkBox7.Checked = PlayerUnknownValue2_List[x];
                checkBox8.Checked = PlayerUnknownValue3_List[x];
                checkBox35.Checked = PlayerActivateArmorBreakModel_List[x];
                textBox15.Text = AltWinPlayerQuote_List[x];
                //PLAYER SUPPORT 1 SECTION
                numericUpDown6.Value = PlayerSupportID_List[x][0];
                comboBox10.SelectedIndex = Convert.ToInt32(PlayerSupportEnableAwakeningFromStart_List[x][0]);
                if (PlayerSupportSkillID_List[x][0] > -1 && PlayerSupportSkillID_List[x][0] <= 5) {
                    comboBox9.SelectedIndex = Convert.ToInt32(PlayerSupportSkillID_List[x][0]);
                } else {
                    comboBox9.SelectedIndex = 6;
                }
                if (PlayerSupportUltID_List[x][0] > -1 && PlayerSupportUltID_List[x][0] <= 3) {
                    comboBox2.SelectedIndex = Convert.ToInt32(PlayerSupportUltID_List[x][0]);
                } else {
                    comboBox2.SelectedIndex = 4;
                }
                checkBox11.Checked = PlayerSupportEnableAltTexture_List[x][0];
                checkBox13.Checked = PlayerSupportDisableTrueAwakening_List[x][0];
                if (PlayerSupportDisableArmorBreak1_List[x][0] == true || PlayerSupportDisableArmorBreak2_List[x][0] == true)
                    checkBox9.Checked = true;
                else
                    checkBox9.Checked = false;
                checkBox12.Checked = PlayerSupportUnknownValue1_List[x][0];
                checkBox10.Checked = PlayerSupportUnknownValue2_List[x][0];
                textBox16.Text = AltWinPlayerSupport1Quote_List[x];
                //PLAYER SUPPORT 2 SECTION
                numericUpDown4.Value = PlayerSupportID_List[x][1];
                comboBox12.SelectedIndex = Convert.ToInt32(PlayerSupportEnableAwakeningFromStart_List[x][1]);
                if (PlayerSupportSkillID_List[x][1] > -1 && PlayerSupportSkillID_List[x][1] <= 5) {
                    comboBox11.SelectedIndex = Convert.ToInt32(PlayerSupportSkillID_List[x][1]);
                } else {
                    comboBox11.SelectedIndex = 6;
                }
                if (PlayerSupportUltID_List[x][1] > -1 && PlayerSupportUltID_List[x][1] <= 3) {
                    comboBox3.SelectedIndex = Convert.ToInt32(PlayerSupportUltID_List[x][1]);
                } else {
                    comboBox3.SelectedIndex = 4;
                }
                checkBox16.Checked = PlayerSupportEnableAltTexture_List[x][1];
                checkBox18.Checked = PlayerSupportDisableTrueAwakening_List[x][1];
                if (PlayerSupportDisableArmorBreak1_List[x][1] == true || PlayerSupportDisableArmorBreak2_List[x][1] == true)
                    checkBox14.Checked = true;
                else
                    checkBox14.Checked = false;
                checkBox17.Checked = PlayerSupportUnknownValue1_List[x][1];
                checkBox15.Checked = PlayerSupportUnknownValue2_List[x][1];
                textBox17.Text = AltWinPlayerSupport2Quote_List[x];
                //ENEMY SECTION
                numericUpDown8.Value = EnemyID_List[x];
                comboBox1.SelectedIndex = Convert.ToInt32(EnemyEnableAwakeningFromStart_List[x]);
                if (EnemySkillID_List[x] > -1 && EnemySkillID_List[x] <= 5) {
                    comboBox15.SelectedIndex = Convert.ToInt32(EnemySkillID_List[x]);
                } else {
                    comboBox15.SelectedIndex = 6;
                }
                if (EnemyUltID_List[x] > -1 && EnemyUltID_List[x] <= 3) {
                    comboBox14.SelectedIndex = Convert.ToInt32(EnemyUltID_List[x]);
                } else {
                    comboBox14.SelectedIndex = 4;
                }
                numericUpDown2.Value = EnemyUnknownValue1_List[x];
                checkBox19.Checked = EnemyEnableAltTexture_List[x];
                checkBox20.Checked = EnemyDisableTrueAwakening_List[x];
                checkBox23.Checked = EnemyUnknownValue2_List[x];
                checkBox21.Checked = EnemyActivateArmorBreakModel_List[x];
                checkBox22.Checked = EnemyDisableSubstitution_List[x];
                numericUpDown9.Value = EnemyLevel_List[x];
                //ENEMY SUPPORT 1 SECTION
                numericUpDown7.Value = EnemySupportID_List[x][0];
                comboBox4.SelectedIndex = Convert.ToInt32(EnemySupportEnableAwakeningFromStart_List[x][0]);
                if (EnemySupportSkillID_List[x][0] > -1 && EnemySupportSkillID_List[x][0] <= 5) {
                    comboBox17.SelectedIndex = Convert.ToInt32(EnemySupportSkillID_List[x][0]);
                } else {
                    comboBox17.SelectedIndex = 6;
                }
                if (EnemySupportUltID_List[x][0] > -1 && EnemySupportUltID_List[x][0] <= 3) {
                    comboBox16.SelectedIndex = Convert.ToInt32(EnemySupportUltID_List[x][0]);
                } else {
                    comboBox16.SelectedIndex = 4;
                }
                checkBox24.Checked = EnemySupportEnableAltTexture_List[x][0];
                checkBox25.Checked = EnemySupportDisableTrueAwakening_List[x][0];
                if (EnemySupportDisableArmorBreak1_List[x][0] == true || EnemySupportDisableArmorBreak2_List[x][0] == true)
                    checkBox26.Checked = true;
                else
                    checkBox26.Checked = false;
                checkBox27.Checked = EnemySupportDisableSubstitution_List[x][0];
                checkBox28.Checked = EnemySupportUnknownValue1_List[x][0];
                //ENEMY SUPPORT 2 SECTION
                numericUpDown5.Value = EnemySupportID_List[x][1];
                comboBox19.SelectedIndex = Convert.ToInt32(EnemySupportEnableAwakeningFromStart_List[x][1]);
                if (EnemySupportSkillID_List[x][1] > -1 && EnemySupportSkillID_List[x][1] <= 5) {
                    comboBox18.SelectedIndex = Convert.ToInt32(EnemySupportSkillID_List[x][1]);
                } else {
                    comboBox18.SelectedIndex = 6;
                }
                if (EnemySupportUltID_List[x][1] > -1 && EnemySupportUltID_List[x][1] <= 3) {
                    comboBox5.SelectedIndex = Convert.ToInt32(EnemySupportUltID_List[x][1]);
                } else {
                    comboBox5.SelectedIndex = 4;
                }
                checkBox32.Checked = EnemySupportEnableAltTexture_List[x][1];
                checkBox33.Checked = EnemySupportDisableTrueAwakening_List[x][1];
                if (EnemySupportDisableArmorBreak1_List[x][1] == true || EnemySupportDisableArmorBreak2_List[x][1] == true)
                    checkBox31.Checked = true;
                else
                    checkBox31.Checked = false;
                checkBox30.Checked = EnemySupportDisableSubstitution_List[x][1];
                checkBox29.Checked = EnemySupportUnknownValue1_List[x][1];
            }
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e) {
            if (checkBox34.Checked == true) {
                numericUpDown37.Hexadecimal = true;
                numericUpDown38.Hexadecimal = true;
                numericUpDown1.Hexadecimal = true;
                numericUpDown2.Hexadecimal = true;
                numericUpDown3.Hexadecimal = true;
                numericUpDown6.Hexadecimal = true;
                numericUpDown4.Hexadecimal = true;
                numericUpDown8.Hexadecimal = true;
                numericUpDown7.Hexadecimal = true;
                numericUpDown5.Hexadecimal = true;
                numericUpDown39.Hexadecimal = true;
                numericUpDown40.Hexadecimal = true;
                numericUpDown42.Hexadecimal = true;
                numericUpDown41.Hexadecimal = true;
                numericUpDown44.Hexadecimal = true;
                numericUpDown43.Hexadecimal = true;
                numericUpDown45.Hexadecimal = true;
                numericUpDown46.Hexadecimal = true;
            } else {
                numericUpDown37.Hexadecimal = false;
                numericUpDown38.Hexadecimal = false;
                numericUpDown1.Hexadecimal = false;
                numericUpDown2.Hexadecimal = false;
                numericUpDown3.Hexadecimal = false;
                numericUpDown6.Hexadecimal = false;
                numericUpDown4.Hexadecimal = false;
                numericUpDown8.Hexadecimal = false;
                numericUpDown7.Hexadecimal = false;
                numericUpDown5.Hexadecimal = false;
                numericUpDown39.Hexadecimal = false;
                numericUpDown40.Hexadecimal = false;
                numericUpDown42.Hexadecimal = false;
                numericUpDown41.Hexadecimal = false;
                numericUpDown44.Hexadecimal = false;
                numericUpDown43.Hexadecimal = false;
                numericUpDown45.Hexadecimal = false;
                numericUpDown46.Hexadecimal = false;

            }
        }

        private void button4_Click(object sender, EventArgs e) {
            if (textBox1.Text != "") {
                bool found = false;
                for (int x = 0; x < listBox1.Items.Count; x++) {
                    if (listBox1.Items[x].ToString().Contains(textBox1.Text)) {
                        listBox1.SelectedIndex = x;
                        found = true;
                        break;
                    } else {
                        if (x == listBox1.Items.Count - 1 && found == false) {
                            MessageBox.Show("Battle section with that name doesn't exist");
                        }
                    }
                }
            } else {
                MessageBox.Show("Write battle name in search field");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                BattleName_List.Add(textBox2.Text + "_COPY");
                Description_List.Add(textBox3.Text);
                Timer_List.Add((int)numericUpDown1.Value);
                GameOverState_List.Add(comboBox13.SelectedIndex);
                StageName_List.Add(textBox4.Text);
                List<int> CreateCostumeValue = new List<int>();
                List<string> CreateCostume = new List<string>();
                CreateCostume.Add(textBox20.Text);
                CreateCostume.Add(textBox21.Text);
                CreateCostume.Add(textBox22.Text);
                CreateCostume.Add(textBox23.Text);
                CreateCostume.Add(textBox24.Text);
                CreateCostume.Add(textBox25.Text);
                CreateCostume.Add(textBox26.Text);
                CreateCostumeValue.Add((int)numericUpDown39.Value);
                CreateCostumeValue.Add((int)numericUpDown40.Value);
                CreateCostumeValue.Add((int)numericUpDown42.Value);
                CreateCostumeValue.Add((int)numericUpDown41.Value);
                CreateCostumeValue.Add((int)numericUpDown44.Value);
                CreateCostumeValue.Add((int)numericUpDown43.Value);
                CreateCostumeValue.Add((int)numericUpDown45.Value);
                CostumeValue_List.Add((int)numericUpDown46.Value);
                CostumeMaterial_List.Add(CreateCostume);
                CostumeMaterialValue_List.Add(CreateCostumeValue);
                List<string> Condition = new List<string>();
                Condition.Add(textBox5.Text);
                Condition.Add(textBox6.Text);
                Condition.Add(textBox7.Text);
                Condition.Add(textBox8.Text);
                Condition.Add(textBox10.Text);
                Condition.Add(textBox9.Text);
                Condition.Add(textBox11.Text);
                Condition.Add(textBox12.Text);
                Condition.Add(textBox13.Text);
                Condition.Add(textBox14.Text);
                Condition.Add(textBox18.Text);
                Condition.Add(textBox19.Text);
                Condition.Add(textBox27.Text);
                Condition.Add(textBox28.Text);
                Condition_List.Add(Condition);
                PlayerID_List.Add((int)numericUpDown3.Value);
                if (comboBox7.SelectedIndex >= 0 && comboBox7.SelectedIndex <= 5)
                    PlayerSkillID_List.Add(comboBox7.SelectedIndex);
                else
                    PlayerSkillID_List.Add(-1);
                if (comboBox8.SelectedIndex >= 0 && comboBox8.SelectedIndex <= 3)
                    PlayerUltID_List.Add(comboBox8.SelectedIndex);
                else
                    PlayerUltID_List.Add(-1);
                PlayerDisableTrueAwakening_List.Add(checkBox4.Checked);
                PlayerEnableAltTexture_List.Add(checkBox6.Checked);
                PlayerUnknownValue1_List.Add(checkBox5.Checked);
                PlayerUnknownValue2_List.Add(checkBox7.Checked);
                PlayerActivateArmorBreakModel_List.Add(checkBox35.Checked);
                PlayerUnknownValue3_List.Add(checkBox8.Checked);
                PlayerEnableAwakeningFromStart_List.Add(Convert.ToBoolean(comboBox6.SelectedIndex));
                List<int> PlayerSupportID = new List<int>();
                PlayerSupportID.Add((int)numericUpDown6.Value);
                PlayerSupportID.Add((int)numericUpDown4.Value);
                PlayerSupportID_List.Add(PlayerSupportID);
                List<int> PlayerSupportSkillID = new List<int>();
                if (comboBox9.SelectedIndex >= 0 && comboBox9.SelectedIndex <= 5)
                    PlayerSupportSkillID.Add(comboBox9.SelectedIndex);
                else
                    PlayerSupportSkillID.Add(-1);
                if (comboBox11.SelectedIndex >= 0 && comboBox11.SelectedIndex <= 5)
                    PlayerSupportSkillID.Add(comboBox11.SelectedIndex);
                else
                    PlayerSupportSkillID.Add(-1);
                List<int> PlayerSupportUltID = new List<int>();
                if (comboBox2.SelectedIndex >= 0 && comboBox2.SelectedIndex <= 3)
                    PlayerSupportUltID.Add(comboBox9.SelectedIndex);
                else
                    PlayerSupportUltID.Add(-1);
                if (comboBox3.SelectedIndex >= 0 && comboBox3.SelectedIndex <= 5)
                    PlayerSupportUltID.Add(comboBox3.SelectedIndex);
                else
                    PlayerSupportUltID.Add(-1);
                PlayerSupportSkillID_List.Add(PlayerSupportSkillID);
                PlayerSupportUltID_List.Add(PlayerSupportUltID);
                List<bool> PlayerSupportEnableAwakeningFromStart = new List<bool>();
                PlayerSupportEnableAwakeningFromStart.Add(Convert.ToBoolean(comboBox10.SelectedIndex));
                PlayerSupportEnableAwakeningFromStart.Add(Convert.ToBoolean(comboBox12.SelectedIndex));
                PlayerSupportEnableAwakeningFromStart_List.Add(PlayerSupportEnableAwakeningFromStart);
                List<bool> PlayerSupportEnableAltTexture = new List<bool>();
                PlayerSupportEnableAltTexture.Add(checkBox11.Checked);
                PlayerSupportEnableAltTexture.Add(checkBox16.Checked);
                PlayerSupportEnableAltTexture_List.Add(PlayerSupportEnableAltTexture);
                List<bool> PlayerSupportUnknownValue1 = new List<bool>();
                PlayerSupportUnknownValue1.Add(checkBox12.Checked);
                PlayerSupportUnknownValue1.Add(checkBox17.Checked);
                PlayerSupportUnknownValue1_List.Add(PlayerSupportUnknownValue1);
                List<bool> PlayerSupportUnknownValue2 = new List<bool>();
                PlayerSupportUnknownValue2.Add(checkBox10.Checked);
                PlayerSupportUnknownValue2.Add(checkBox15.Checked);
                PlayerSupportUnknownValue2_List.Add(PlayerSupportUnknownValue2);
                List<bool> PlayerSupportDisableArmorBreak = new List<bool>();
                PlayerSupportDisableArmorBreak.Add(checkBox9.Checked);
                PlayerSupportDisableArmorBreak.Add(checkBox14.Checked);
                PlayerSupportDisableArmorBreak1_List.Add(PlayerSupportDisableArmorBreak);
                PlayerSupportDisableArmorBreak2_List.Add(PlayerSupportDisableArmorBreak);
                List<bool> PlayerSupportDisableTrueAwakening = new List<bool>();
                PlayerSupportDisableTrueAwakening.Add(checkBox13.Checked);
                PlayerSupportDisableTrueAwakening.Add(checkBox18.Checked);
                PlayerSupportDisableTrueAwakening_List.Add(PlayerSupportDisableTrueAwakening);
                EnemyID_List.Add((int)numericUpDown8.Value);
                if (comboBox15.SelectedIndex >= 0 && comboBox15.SelectedIndex <= 5)
                    EnemySkillID_List.Add(comboBox15.SelectedIndex);
                else
                    EnemySkillID_List.Add(-1);
                if (comboBox13.SelectedIndex >= 0 && comboBox13.SelectedIndex <= 3)
                    EnemyUltID_List.Add(comboBox13.SelectedIndex);
                else
                    EnemyUltID_List.Add(-1);
                EnemyUnknownValue1_List.Add((int)numericUpDown2.Value);
                EnemyDisableTrueAwakening_List.Add(checkBox20.Checked);
                EnemyEnableAltTexture_List.Add(checkBox19.Checked);
                EnemyUnknownValue2_List.Add(checkBox23.Checked);
                EnemyActivateArmorBreakModel_List.Add(checkBox21.Checked);
                EnemyDisableSubstitution_List.Add(checkBox22.Checked);
                EnemyEnableAwakeningFromStart_List.Add(Convert.ToBoolean(comboBox1.SelectedIndex));
                EnemyLevel_List.Add((int)numericUpDown9.Value);

                List<int> EnemySupportID = new List<int>();
                EnemySupportID.Add((int)numericUpDown7.Value);
                EnemySupportID.Add((int)numericUpDown6.Value);
                EnemySupportID_List.Add(EnemySupportID);
                List<int> EnemySupportSkillID = new List<int>();
                if (comboBox17.SelectedIndex >= 0 && comboBox17.SelectedIndex <= 5)
                    EnemySupportSkillID.Add(comboBox17.SelectedIndex);
                else
                    EnemySupportSkillID.Add(-1);
                if (comboBox18.SelectedIndex >= 0 && comboBox18.SelectedIndex <= 5)
                    EnemySupportSkillID.Add(comboBox18.SelectedIndex);
                else
                    EnemySupportSkillID.Add(-1);
                EnemySupportSkillID_List.Add(EnemySupportSkillID);
                List<int> EnemySupportUltID = new List<int>();
                if (comboBox16.SelectedIndex >= 0 && comboBox16.SelectedIndex <= 3)
                    EnemySupportUltID.Add(comboBox16.SelectedIndex);
                else
                    EnemySupportUltID.Add(-1);
                if (comboBox5.SelectedIndex >= 0 && comboBox5.SelectedIndex <= 3)
                    EnemySupportUltID.Add(comboBox5.SelectedIndex);
                else
                    EnemySupportUltID.Add(-1);
                EnemySupportUltID_List.Add(EnemySupportUltID);
                List<bool> EnemySupportDisableTrueAwakening = new List<bool>();
                EnemySupportDisableTrueAwakening.Add(checkBox25.Checked);
                EnemySupportDisableTrueAwakening.Add(checkBox33.Checked);
                EnemySupportDisableTrueAwakening_List.Add(EnemySupportDisableTrueAwakening);
                List<bool> EnemySupportEnableAltTexture = new List<bool>();
                EnemySupportEnableAltTexture.Add(checkBox24.Checked);
                EnemySupportEnableAltTexture.Add(checkBox32.Checked);
                EnemySupportEnableAltTexture_List.Add(EnemySupportEnableAltTexture);
                List<bool> EnemySupportUnknownValue1 = new List<bool>();
                EnemySupportUnknownValue1.Add(checkBox28.Checked);
                EnemySupportUnknownValue1.Add(checkBox29.Checked);
                EnemySupportUnknownValue1_List.Add(EnemySupportUnknownValue1);
                List<bool> EnemySupportDisableArmorBreak = new List<bool>();
                EnemySupportDisableArmorBreak.Add(checkBox26.Checked);
                EnemySupportDisableArmorBreak.Add(checkBox31.Checked);
                EnemySupportDisableArmorBreak1_List.Add(EnemySupportDisableArmorBreak);
                EnemySupportDisableArmorBreak2_List.Add(EnemySupportDisableArmorBreak);
                List<bool> EnemySupportDisableSubstitution = new List<bool>();
                EnemySupportDisableSubstitution.Add(checkBox27.Checked);
                EnemySupportDisableSubstitution.Add(checkBox30.Checked);
                EnemySupportDisableSubstitution_List.Add(EnemySupportDisableSubstitution);
                List<bool> EnemySupportEnableAwakeningFromStart = new List<bool>();
                EnemySupportEnableAwakeningFromStart.Add(Convert.ToBoolean(comboBox4.SelectedIndex));
                EnemySupportEnableAwakeningFromStart.Add(Convert.ToBoolean(comboBox15.SelectedIndex));
                EnemySupportEnableAwakeningFromStart_List.Add(EnemySupportEnableAwakeningFromStart);
                AltWinPlayer_List.Add(checkBox1.Checked);
                AltWinPlayerSupport1_List.Add(checkBox2.Checked);
                AltWinPlayerSupport2_List.Add(checkBox3.Checked);
                AltWinPlayerQuote_List.Add(textBox15.Text);
                AltWinPlayerSupport1Quote_List.Add(textBox16.Text);
                AltWinPlayerSupport2Quote_List.Add(textBox17.Text);
                BGM_List.Add((int)numericUpDown37.Value);
                BattleCondition_List.Add((int)numericUpDown38.Value);
                listBox1.Items.Add(textBox2.Text + "_COPY");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                EntryCount++;
            } else {
                MessageBox.Show("Select battle entry");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                BattleName_List[x] = textBox2.Text;
                Description_List[x] = textBox3.Text;
                Timer_List[x] = (int)numericUpDown1.Value;
                GameOverState_List[x] = comboBox13.SelectedIndex;
                StageName_List[x] = textBox4.Text;
                CostumeValue_List[x] = (int)numericUpDown46.Value;
                CostumeMaterial_List[x][0] = textBox20.Text;
                CostumeMaterial_List[x][1] = textBox21.Text;
                CostumeMaterial_List[x][2] = textBox22.Text;
                CostumeMaterial_List[x][3] = textBox23.Text;
                CostumeMaterial_List[x][4] = textBox24.Text;
                CostumeMaterial_List[x][5] = textBox25.Text;
                CostumeMaterial_List[x][6] = textBox26.Text;
                CostumeMaterialValue_List[x][0] = (int)numericUpDown39.Value;
                CostumeMaterialValue_List[x][1] = (int)numericUpDown40.Value;
                CostumeMaterialValue_List[x][2] = (int)numericUpDown42.Value;
                CostumeMaterialValue_List[x][3] = (int)numericUpDown41.Value;
                CostumeMaterialValue_List[x][4] = (int)numericUpDown44.Value;
                CostumeMaterialValue_List[x][5] = (int)numericUpDown43.Value;
                CostumeMaterialValue_List[x][6] = (int)numericUpDown45.Value;
                Condition_List[x][0] = textBox5.Text;
                Condition_List[x][1] = textBox6.Text;
                Condition_List[x][2] = textBox7.Text;
                Condition_List[x][3] = textBox8.Text;
                Condition_List[x][4] = textBox10.Text;
                Condition_List[x][5] = textBox9.Text;
                Condition_List[x][6] = textBox11.Text;
                Condition_List[x][7] = textBox12.Text;
                Condition_List[x][8] = textBox13.Text;
                Condition_List[x][9] = textBox14.Text;
                Condition_List[x][10] = textBox18.Text;
                Condition_List[x][11] = textBox19.Text;
                Condition_List[x][12] = textBox27.Text;
                Condition_List[x][13] = textBox28.Text;
                PlayerID_List[x] = (int)numericUpDown3.Value;
                if (comboBox7.SelectedIndex >= 0 && comboBox7.SelectedIndex <= 5)
                    PlayerSkillID_List[x] = comboBox7.SelectedIndex;
                else
                    PlayerSkillID_List[x] = -1;
                if (comboBox8.SelectedIndex >= 0 && comboBox8.SelectedIndex <= 3)
                    PlayerUltID_List[x] = comboBox8.SelectedIndex;
                else
                    PlayerUltID_List[x] = -1;
                PlayerDisableTrueAwakening_List[x] = checkBox4.Checked;
                PlayerEnableAltTexture_List[x] = checkBox6.Checked;
                PlayerUnknownValue1_List[x] = checkBox5.Checked;
                PlayerUnknownValue2_List[x] = checkBox7.Checked;
                PlayerActivateArmorBreakModel_List[x] = checkBox35.Checked;
                PlayerUnknownValue3_List[x] = checkBox8.Checked;
                PlayerEnableAwakeningFromStart_List[x] = Convert.ToBoolean(comboBox6.SelectedIndex);
                PlayerSupportID_List[x][0] = (int)numericUpDown6.Value;
                PlayerSupportID_List[x][1] = (int)numericUpDown4.Value;
                if (comboBox9.SelectedIndex >= 0 && comboBox9.SelectedIndex <= 5)
                    PlayerSupportSkillID_List[x][0] = comboBox9.SelectedIndex;
                else
                    PlayerSupportSkillID_List[x][0] = -1;
                if (comboBox11.SelectedIndex >= 0 && comboBox11.SelectedIndex <= 5)
                    PlayerSupportSkillID_List[x][1] = comboBox11.SelectedIndex;
                else
                    PlayerSupportSkillID_List[x][1] = -1;
                if (comboBox2.SelectedIndex >= 0 && comboBox2.SelectedIndex <= 3)
                    PlayerSupportUltID_List[x][0] = comboBox2.SelectedIndex;
                else
                    PlayerSupportUltID_List[x][0] = -1;
                if (comboBox3.SelectedIndex >= 0 && comboBox3.SelectedIndex <= 3)
                    PlayerSupportUltID_List[x][1] = comboBox3.SelectedIndex;
                else
                    PlayerSupportUltID_List[x][1] = -1;
                PlayerSupportDisableTrueAwakening_List[x][0] = checkBox13.Checked;
                PlayerSupportDisableTrueAwakening_List[x][1] = checkBox18.Checked;
                PlayerSupportEnableAltTexture_List[x][0] = checkBox11.Checked;
                PlayerSupportEnableAltTexture_List[x][1] = checkBox16.Checked;
                PlayerSupportUnknownValue1_List[x][0] = checkBox12.Checked;
                PlayerSupportUnknownValue1_List[x][1] = checkBox17.Checked;
                PlayerSupportDisableArmorBreak1_List[x][0] = checkBox9.Checked;
                PlayerSupportDisableArmorBreak1_List[x][1] = checkBox14.Checked;
                PlayerSupportUnknownValue2_List[x][0] = checkBox10.Checked;
                PlayerSupportUnknownValue2_List[x][1] = checkBox15.Checked;
                PlayerSupportDisableArmorBreak2_List[x][0] = checkBox9.Checked;
                PlayerSupportDisableArmorBreak2_List[x][1] = checkBox14.Checked;
                PlayerSupportEnableAwakeningFromStart_List[x][0] = Convert.ToBoolean(comboBox10.SelectedIndex);
                PlayerSupportEnableAwakeningFromStart_List[x][1] = Convert.ToBoolean(comboBox12.SelectedIndex);
                EnemyID_List[x] = (int)numericUpDown8.Value;
                if (comboBox15.SelectedIndex >= 0 && comboBox15.SelectedIndex <= 5)
                    EnemySkillID_List[x] = comboBox15.SelectedIndex;
                else
                    EnemySkillID_List[x] = -1;
                if (comboBox14.SelectedIndex >= 0 && comboBox14.SelectedIndex <= 3)
                    EnemyUltID_List[x] = comboBox14.SelectedIndex;
                else
                    EnemyUltID_List[x] = -1;
                EnemyUnknownValue1_List[x] = (int)numericUpDown2.Value;
                EnemyDisableTrueAwakening_List[x] = checkBox20.Checked;
                EnemyEnableAltTexture_List[x] = checkBox19.Checked;
                EnemyUnknownValue2_List[x] = checkBox23.Checked;
                EnemyActivateArmorBreakModel_List[x] = checkBox21.Checked;
                EnemyDisableSubstitution_List[x] = checkBox22.Checked;
                EnemyEnableAwakeningFromStart_List[x] = Convert.ToBoolean(comboBox1.SelectedIndex);
                EnemyLevel_List[x] = (int)numericUpDown9.Value;
                EnemySupportID_List[x][0] = (int)numericUpDown7.Value;
                EnemySupportID_List[x][1] = (int)numericUpDown5.Value;
                if (comboBox17.SelectedIndex >= 0 && comboBox17.SelectedIndex <= 5)
                    EnemySupportSkillID_List[x][0] = comboBox17.SelectedIndex;
                else
                    EnemySupportSkillID_List[x][0] = -1;
                if (comboBox18.SelectedIndex >= 0 && comboBox18.SelectedIndex <= 5)
                    EnemySupportSkillID_List[x][1] = comboBox18.SelectedIndex;
                else
                    EnemySupportSkillID_List[x][1] = -1;
                if (comboBox16.SelectedIndex >= 0 && comboBox16.SelectedIndex <= 3)
                    EnemySupportUltID_List[x][0] = comboBox16.SelectedIndex;
                else
                    EnemySupportUltID_List[x][0] = -1;
                if (comboBox5.SelectedIndex >= 0 && comboBox5.SelectedIndex <= 3)
                    EnemySupportUltID_List[x][1] = comboBox5.SelectedIndex;
                else
                    EnemySupportUltID_List[x][1] = -1;
                EnemySupportDisableTrueAwakening_List[x][0] = checkBox25.Checked;
                EnemySupportDisableTrueAwakening_List[x][1] = checkBox33.Checked;
                EnemySupportEnableAltTexture_List[x][0] = checkBox24.Checked;
                EnemySupportEnableAltTexture_List[x][1] = checkBox32.Checked;
                EnemySupportUnknownValue1_List[x][0] = checkBox28.Checked;
                EnemySupportUnknownValue1_List[x][1] = checkBox29.Checked;
                EnemySupportDisableArmorBreak1_List[x][0] = checkBox26.Checked;
                EnemySupportDisableArmorBreak1_List[x][1] = checkBox31.Checked;
                EnemySupportDisableSubstitution_List[x][0] = checkBox27.Checked;
                EnemySupportDisableSubstitution_List[x][1] = checkBox30.Checked;
                EnemySupportDisableArmorBreak2_List[x][0] = checkBox26.Checked;
                EnemySupportDisableArmorBreak2_List[x][1] = checkBox31.Checked;
                EnemySupportEnableAwakeningFromStart_List[x][0] = Convert.ToBoolean(comboBox4.SelectedIndex);
                EnemySupportEnableAwakeningFromStart_List[x][1] = Convert.ToBoolean(comboBox19.SelectedIndex);
                AltWinPlayer_List[x] = checkBox1.Checked;
                AltWinPlayerSupport1_List[x] = checkBox2.Checked;
                AltWinPlayerSupport2_List[x] = checkBox3.Checked;
                AltWinPlayerQuote_List[x] = textBox15.Text;
                AltWinPlayerSupport1Quote_List[x] = textBox16.Text;
                AltWinPlayerSupport2Quote_List[x] = textBox17.Text;
                BGM_List[x] = (int)numericUpDown37.Value;
                BattleCondition_List[x] = (int)numericUpDown38.Value;
                listBox1.Items[x] = textBox2.Text;
            } else {
                MessageBox.Show("Select battle entry");
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                BattleName_List.RemoveAt(x);
                Description_List.RemoveAt(x);
                Timer_List.RemoveAt(x);
                GameOverState_List.RemoveAt(x);
                StageName_List.RemoveAt(x);
                CostumeValue_List.RemoveAt(x);
                CostumeMaterial_List.RemoveAt(x);
                CostumeMaterialValue_List.RemoveAt(x);
                Condition_List.RemoveAt(x);
                PlayerID_List.RemoveAt(x);
                PlayerSkillID_List.RemoveAt(x);
                PlayerUltID_List.RemoveAt(x);
                PlayerDisableTrueAwakening_List.RemoveAt(x);
                PlayerEnableAltTexture_List.RemoveAt(x);
                PlayerUnknownValue1_List.RemoveAt(x);
                PlayerUnknownValue2_List.RemoveAt(x);
                PlayerActivateArmorBreakModel_List.RemoveAt(x);
                PlayerUnknownValue3_List.RemoveAt(x);
                PlayerEnableAwakeningFromStart_List.RemoveAt(x);
                PlayerSupportID_List.RemoveAt(x);
                PlayerSupportSkillID_List.RemoveAt(x);
                PlayerSupportUltID_List.RemoveAt(x);
                PlayerSupportDisableTrueAwakening_List.RemoveAt(x);
                PlayerSupportEnableAltTexture_List.RemoveAt(x);
                PlayerSupportUnknownValue1_List.RemoveAt(x);
                PlayerSupportDisableArmorBreak1_List.RemoveAt(x);
                PlayerSupportUnknownValue2_List.RemoveAt(x);
                PlayerSupportDisableArmorBreak2_List.RemoveAt(x);
                PlayerSupportEnableAwakeningFromStart_List.RemoveAt(x);
                EnemyID_List.RemoveAt(x);
                EnemySkillID_List.RemoveAt(x);
                EnemyUltID_List.RemoveAt(x);
                EnemyUnknownValue1_List.RemoveAt(x);
                EnemyDisableTrueAwakening_List.RemoveAt(x);
                EnemyEnableAltTexture_List.RemoveAt(x);
                EnemyUnknownValue2_List.RemoveAt(x);
                EnemyActivateArmorBreakModel_List.RemoveAt(x);
                EnemyDisableSubstitution_List.RemoveAt(x);
                EnemyEnableAwakeningFromStart_List.RemoveAt(x);
                EnemyLevel_List.RemoveAt(x);
                EnemySupportID_List.RemoveAt(x);
                EnemySupportSkillID_List.RemoveAt(x);
                EnemySupportUltID_List.RemoveAt(x);
                EnemySupportDisableTrueAwakening_List.RemoveAt(x);
                EnemySupportEnableAltTexture_List.RemoveAt(x);
                EnemySupportUnknownValue1_List.RemoveAt(x);
                EnemySupportDisableArmorBreak1_List.RemoveAt(x);
                EnemySupportDisableSubstitution_List.RemoveAt(x);
                EnemySupportDisableArmorBreak2_List.RemoveAt(x);
                EnemySupportEnableAwakeningFromStart_List.RemoveAt(x);
                AltWinPlayer_List.RemoveAt(x);
                AltWinPlayerSupport1_List.RemoveAt(x);
                AltWinPlayerSupport2_List.RemoveAt(x);
                AltWinPlayerQuote_List.RemoveAt(x);
                AltWinPlayerSupport1Quote_List.RemoveAt(x);
                AltWinPlayerSupport2Quote_List.RemoveAt(x);
                BGM_List.RemoveAt(x);
                BattleCondition_List.RemoveAt(x);
                listBox1.Items.RemoveAt(x);
                listBox1.SelectedIndex = x - 1;
                EntryCount--;
            } else {
                MessageBox.Show("Select battle entry");
            }
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

        public void SaveFileAs() {
            SaveFileDialog s = new SaveFileDialog();
            {
                s.DefaultExt = ".xfbin";
                s.Filter = "*.xfbin|*.xfbin";
            }
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
            MessageBox.Show("File saved to " + FilePath + ".");
        }

        public byte[] ConvertToFile() {
            List<byte> file = new List<byte>();
            byte[] header = new byte[300]
            {
                0x4E,0x55,0x43,0x43,0x00,0x00,0x00,0x79,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xD8,0x00,0x00,0x00,0x03,0x00,0x79,0x00,0x00,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x3B,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x1C,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x19,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x4E,0x75,0x6C,0x6C,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x42,0x69,0x6E,0x61,0x72,0x79,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x50,0x61,0x67,0x65,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x49,0x6E,0x64,0x65,0x78,0x00,0x00,0x62,0x69,0x6E,0x5F,0x6C,0x65,0x2F,0x78,0x36,0x34,0x2F,0x62,0x61,0x74,0x74,0x6C,0x65,0x50,0x61,0x72,0x61,0x6D,0x2E,0x62,0x69,0x6E,0x00,0x00,0x62,0x61,0x74,0x74,0x6C,0x65,0x50,0x61,0x72,0x61,0x6D,0x00,0x50,0x61,0x67,0x65,0x30,0x00,0x69,0x6E,0x64,0x65,0x78,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x79,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x79,0x00,0x00,0x00,0x07,0x1F,0x54,0x00,0x00,0x00,0x01,0x00,0x79,0x00,0x00,0x00,0x07,0x1F,0x50,0xF0,0x03,0x00,0x00,0x02,0x02,0x00,0x00,0x08,0x00,0x00,0x00,0x00,0x00,0x00,0x00
            };
            for (int x4 = 0; x4 < header.Length; x4++) {
                file.Add(header[x4]);
            }
            for (int x3 = 0; x3 < EntryCount * 0x110; x3++) {
                file.Add(0);
            }
            List<int> CostumeMaterialSectionPointer = new List<int>();
            for (int x2 = 0; x2 < EntryCount; x2++) {
                CostumeMaterialSectionPointer.Add(300+(0x110*EntryCount)+(x2*0xA8));
                for (int z = 0; z < 0xA8; z++)
                    file.Add(0);
            }
            List<int> PlayerSectionPointer = new List<int>();
            for (int x2 = 0; x2 < EntryCount; x2++) {
                PlayerSectionPointer.Add(300 + (0x110 * EntryCount) + (x2 * 0x58) + (EntryCount * 0xA8));
                for (int z = 0; z < 0x58; z++)
                    file.Add(0);
            }
            List<List<int>> PlayerSupportSectionPointerList = new List<List<int>>();
            for (int x2 = 0; x2 < EntryCount; x2++) {
                List<int> PlayerSupportSectionPointer = new List<int>();
                PlayerSupportSectionPointer.Add(file.Count);
                for (int z = 0; z < 0x28; z++)
                    file.Add(0);
                PlayerSupportSectionPointer.Add(file.Count);
                for (int z = 0; z < 0x28; z++)
                    file.Add(0);
                PlayerSupportSectionPointerList.Add(PlayerSupportSectionPointer);
            }
            List<int> EnemySectionPointer = new List<int>();
            for (int x2 = 0; x2 < EntryCount; x2++) {
                EnemySectionPointer.Add(300 + (0x110 * EntryCount) + (x2 * 0x60) + (EntryCount * 0x28) + (EntryCount * 0x28) + (EntryCount * 0xA8) + (EntryCount * 0x58));
                for (int z = 0; z < 0x60; z++)
                    file.Add(0);
            }
            List<List<int>> EnemySupportSectionPointerList = new List<List<int>>();
            for (int x2 = 0; x2 < EntryCount; x2++) {
                List<int> EnemySupportSectionPointer = new List<int>();
                EnemySupportSectionPointer.Add(file.Count);
                for (int z = 0; z < 0x2C; z++)
                    file.Add(0); 
                EnemySupportSectionPointer.Add(file.Count);
                for (int z = 0; z < 0x2C; z++)
                    file.Add(0);
                EnemySupportSectionPointerList.Add(EnemySupportSectionPointer);
            }
            List<int> BattleNamePointer = new List<int>();
            List<int> DescriptionPointer = new List<int>();
            List<int> StageNamePointer = new List<int>();
            List<int> Condition1Pointer = new List<int>();
            List<int> Condition2Pointer = new List<int>();
            List<int> Condition3Pointer = new List<int>();
            List<int> Condition4Pointer = new List<int>();
            List<int> Condition5Pointer = new List<int>();
            List<int> Condition6Pointer = new List<int>();
            List<int> Condition7Pointer = new List<int>();
            List<int> Condition8Pointer = new List<int>();
            List<int> Condition9Pointer = new List<int>();
            List<int> Condition10Pointer = new List<int>();
            List<int> Condition11Pointer = new List<int>();
            List<int> Condition12Pointer = new List<int>();
            List<int> Condition13Pointer = new List<int>();
            List<int> Condition14Pointer = new List<int>();
            List<int> PlayerWinQuotePointer = new List<int>();
            List<int> PlayerSupport1WinQuotePointer = new List<int>();
            List<int> PlayerSupport2WinQuotePointer = new List<int>();
            for (int x2 = 0; x2 < EntryCount; x2++) {
                BattleNamePointer.Add(file.Count);
                int nameLength3 = BattleName_List[x2].Length;
                if (BattleName_List[x2] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)BattleName_List[x2][a17]);
                    }
                    file.Add(0);
                }
                DescriptionPointer.Add(file.Count);
                nameLength3 = Description_List[x2].Length;
                if (Description_List[x2] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Description_List[x2][a17]);
                    }
                    file.Add(0);
                }
                StageNamePointer.Add(file.Count);
                nameLength3 = StageName_List[x2].Length;
                if (StageName_List[x2] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)StageName_List[x2][a17]);
                    }
                    file.Add(0);
                }
                Condition1Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][0].Length;
                if (Condition_List[x2][0] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][0][a17]);
                    }
                    file.Add(0);
                }
                Condition2Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][1].Length;
                if (Condition_List[x2][1] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][1][a17]);
                    }
                    file.Add(0);
                }
                Condition3Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][2].Length;
                if (Condition_List[x2][2] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][2][a17]);
                    }
                    file.Add(0);
                }
                Condition4Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][3].Length;
                if (Condition_List[x2][3] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][3][a17]);
                    }
                    file.Add(0);
                }
                Condition5Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][4].Length;
                if (Condition_List[x2][4] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][4][a17]);
                    }
                    file.Add(0);
                }
                Condition6Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][5].Length;
                if (Condition_List[x2][5] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][5][a17]);
                    }
                    file.Add(0);
                }
                Condition7Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][6].Length;
                if (Condition_List[x2][6] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][6][a17]);
                    }
                    file.Add(0);
                }
                Condition8Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][7].Length;
                if (Condition_List[x2][7] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][7][a17]);
                    }
                    file.Add(0);
                }
                Condition9Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][8].Length;
                if (Condition_List[x2][8] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][8][a17]);
                    }
                    file.Add(0);
                }
                Condition10Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][9].Length;
                if (Condition_List[x2][9] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][9][a17]);
                    }
                    file.Add(0);
                }
                Condition11Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][10].Length;
                if (Condition_List[x2][10] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][10][a17]);
                    }
                    file.Add(0);
                }
                Condition12Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][11].Length;
                if (Condition_List[x2][11] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][11][a17]);
                    }
                    file.Add(0);
                }
                Condition13Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][12].Length;
                if (Condition_List[x2][12] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][12][a17]);
                    }
                    file.Add(0);
                }
                Condition14Pointer.Add(file.Count);
                nameLength3 = Condition_List[x2][13].Length;
                if (Condition_List[x2][13] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)Condition_List[x2][13][a17]);
                    }
                    file.Add(0);
                }
                PlayerWinQuotePointer.Add(file.Count);
                nameLength3 = AltWinPlayerQuote_List[x2].Length;
                if (AltWinPlayerQuote_List[x2] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)AltWinPlayerQuote_List[x2][a17]);
                    }
                    file.Add(0);
                }
                PlayerSupport1WinQuotePointer.Add(file.Count);
                nameLength3 = AltWinPlayerSupport1Quote_List[x2].Length;
                if (AltWinPlayerSupport1Quote_List[x2] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)AltWinPlayerSupport1Quote_List[x2][a17]);
                    }
                    file.Add(0);
                }
                PlayerSupport2WinQuotePointer.Add(file.Count);
                nameLength3 = AltWinPlayerSupport2Quote_List[x2].Length;
                if (AltWinPlayerSupport2Quote_List[x2] != "") {
                    for (int a17 = 0; a17 < nameLength3; a17++) {
                        file.Add((byte)AltWinPlayerSupport2Quote_List[x2][a17]);
                    }
                    file.Add(0);
                }
                int newPointer3 = 0;
                byte[] ptrBytes3 = new byte[0];
                if (BattleName_List[x2] != "") {

                    newPointer3 = BattleNamePointer[x2] - 300 - 0x110 * x2;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + a7] = ptrBytes3[a7];
                    }
                }
                if (Description_List[x2] != "") {

                    newPointer3 = DescriptionPointer[x2] - 300 - 0x110 * x2 - 0x08;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x08 + a7] = ptrBytes3[a7];
                    }
                }
                if (StageName_List[x2] != "") {

                    newPointer3 = StageNamePointer[x2] - 300 - 0x110 * x2 - 0x20;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x20 + a7] = ptrBytes3[a7];
                    }
                }
                newPointer3 = CostumeMaterialSectionPointer[x2] - 300 - 0x110 * x2 - 0x30;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                for (int a7 = 0; a7 < 4; a7++) {
                    file[300 + 0x110 * x2 + 0x30 + a7] = ptrBytes3[a7];
                }
                if (Condition_List[x2][0] != "") {

                    newPointer3 = Condition1Pointer[x2] - 300 - 0x110 * x2 - 0x38;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x38 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][1] != "") {

                    newPointer3 = Condition2Pointer[x2] - 300 - 0x110 * x2 - 0x40;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x40 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][2] != "") {

                    newPointer3 = Condition3Pointer[x2] - 300 - 0x110 * x2 - 0x48;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x48 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][3] != "") {

                    newPointer3 = Condition4Pointer[x2] - 300 - 0x110 * x2 - 0x50;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x50 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][4] != "") {

                    newPointer3 = Condition5Pointer[x2] - 300 - 0x110 * x2 - 0x58;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x58 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][5] != "") {

                    newPointer3 = Condition6Pointer[x2] - 300 - 0x110 * x2 - 0x60;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x60 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][6] != "") {

                    newPointer3 = Condition7Pointer[x2] - 300 - 0x110 * x2 - 0x68;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x68 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][7] != "") {

                    newPointer3 = Condition8Pointer[x2] - 300 - 0x110 * x2 - 0x70;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x70 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][8] != "") {

                    newPointer3 = Condition9Pointer[x2] - 300 - 0x110 * x2 - 0x78;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x78 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][9] != "") {

                    newPointer3 = Condition10Pointer[x2] - 300 - 0x110 * x2 - 0x80;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x80 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][10] != "") {

                    newPointer3 = Condition11Pointer[x2] - 300 - 0x110 * x2 - 0x88;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x88 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][11] != "") {

                    newPointer3 = Condition12Pointer[x2] - 300 - 0x110 * x2 - 0x90;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x90 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][12] != "") {

                    newPointer3 = Condition13Pointer[x2] - 300 - 0x110 * x2 - 0x98;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0x98 + a7] = ptrBytes3[a7];
                    }
                }
                if (Condition_List[x2][13] != "") {

                    newPointer3 = Condition14Pointer[x2] - 300 - 0x110 * x2 - 0xA0;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0xA0 + a7] = ptrBytes3[a7];
                    }
                }
                newPointer3 = PlayerSectionPointer[x2] - 300 - 0x110 * x2 - 0xA8;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                for (int a7 = 0; a7 < 4; a7++) {
                    file[300 + 0x110 * x2 + 0xA8 + a7] = ptrBytes3[a7];
                }
                newPointer3 = PlayerSupportSectionPointerList[x2][0] - 300 - 0x110 * x2 - 0xB0;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                for (int a7 = 0; a7 < 4; a7++) {
                    file[300 + 0x110 * x2 + 0xB0 + a7] = ptrBytes3[a7];
                }
                newPointer3 = PlayerSupportSectionPointerList[x2][1] - 300 - 0x110 * x2 - 0xB8;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                for (int a7 = 0; a7 < 4; a7++) {
                    file[300 + 0x110 * x2 + 0xB8 + a7] = ptrBytes3[a7];
                }
                newPointer3 = EnemySectionPointer[x2] - 300 - 0x110 * x2 - 0xC0;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                for (int a7 = 0; a7 < 4; a7++) {
                    file[300 + 0x110 * x2 + 0xC0 + a7] = ptrBytes3[a7];
                }
                newPointer3 = EnemySupportSectionPointerList[x2][0] - 300 - 0x110 * x2 - 0xC8;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                for (int a7 = 0; a7 < 4; a7++) {
                    file[300 + 0x110 * x2 + 0xC8 + a7] = ptrBytes3[a7];
                }
                newPointer3 = EnemySupportSectionPointerList[x2][1] - 300 - 0x110 * x2 - 0xD0;
                ptrBytes3 = BitConverter.GetBytes(newPointer3);
                for (int a7 = 0; a7 < 4; a7++) {
                    file[300 + 0x110 * x2 + 0xD0 + a7] = ptrBytes3[a7];
                }
                if (AltWinPlayerQuote_List[x2] != "") {

                    newPointer3 = PlayerWinQuotePointer[x2] - 300 - 0x110 * x2 - 0xE8;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0xE8 + a7] = ptrBytes3[a7];
                    }
                }
                if (AltWinPlayerSupport1Quote_List[x2] != "") {

                    newPointer3 = PlayerSupport1WinQuotePointer[x2] - 300 - 0x110 * x2 - 0xF0;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0xF0 + a7] = ptrBytes3[a7];
                    }
                }
                if (AltWinPlayerSupport2Quote_List[x2] != "") {

                    newPointer3 = PlayerSupport2WinQuotePointer[x2] - 300 - 0x110 * x2 - 0xF8;
                    ptrBytes3 = BitConverter.GetBytes(newPointer3);
                    for (int a7 = 0; a7 < 4; a7++) {
                        file[300 + 0x110 * x2 + 0xF8 + a7] = ptrBytes3[a7];
                    }
                }
                byte[] o_a = new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
                for (int a8 = 0; a8 < 4; a8++) {
                    file[300 + 0x110 * x2 + 0x10 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(Timer_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[300 + 0x110 * x2 + 0x14 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(GameOverState_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[300 + 0x110 * x2 + 0x18 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(AltWinPlayer_List[x2]);
                for (int a8 = 0; a8 < 1; a8++) {
                    file[300 + 0x110 * x2 + 0xD8 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(AltWinPlayerSupport1_List[x2]);
                for (int a8 = 0; a8 < 1; a8++) {
                    file[300 + 0x110 * x2 + 0xDC + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(AltWinPlayerSupport2_List[x2]);
                for (int a8 = 0; a8 < 1; a8++) {
                    file[300 + 0x110 * x2 + 0xE0 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(BGM_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[300 + 0x110 * x2 + 0x100 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(BattleCondition_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[300 + 0x110 * x2 + 0x104 + a8] = o_a[a8];
                }
                //Costume Material Section
                o_a = BitConverter.GetBytes(CostumeValue_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[CostumeMaterialSectionPointer[x2] + 0x00 + a8] = o_a[a8];
                }
                List<int> CostumeMaterialPointer = new List<int>();
                for (int j = 0; j < 7; j++) {
                    CostumeMaterialPointer.Add(file.Count);
                    nameLength3 = CostumeMaterial_List[x2][j].Length;
                    if (CostumeMaterial_List[x2][j] != "") {
                        o_a = BitConverter.GetBytes(CostumeMaterialValue_List[x2][j]);
                        for (int a8 = 0; a8 < 4; a8++) {
                            file[CostumeMaterialSectionPointer[x2] + 0x48 + (j * 0x4) + a8] = o_a[a8];
                        }
                        for (int a17 = 0; a17 < nameLength3; a17++) {
                            file.Add((byte)CostumeMaterial_List[x2][j][a17]);
                        }
                        file.Add(0);

                    }
                }
                for (int j = 0; j < 7; j++) {
                    if (CostumeMaterial_List[x2][j] != "") {

                        newPointer3 = CostumeMaterialPointer[j] - 300 - 0x110 * EntryCount - 0xA8 * x2 - 0x08 - (j * 0x08);
                        ptrBytes3 = BitConverter.GetBytes(newPointer3);
                        for (int a7 = 0; a7 < 4; a7++) {
                            file[300 + 0x110 * EntryCount + 0xA8 * x2 + 0x08 + (j * 0x08) + a7] = ptrBytes3[a7];
                        }
                    }

                }
                //Player section
                o_a = BitConverter.GetBytes(PlayerID_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[PlayerSectionPointer[x2] + 0x00 + a8] = o_a[a8];
                }
                if (PlayerSkillID_List[x2] < 0 || PlayerSkillID_List[x2] > 5)
                    o_a = new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
                else
                    o_a = BitConverter.GetBytes(PlayerSkillID_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[PlayerSectionPointer[x2] + 0x04 + a8] = o_a[a8];
                }
                if (PlayerUltID_List[x2] < 0 || PlayerUltID_List[x2] > 3)
                    o_a = new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
                else
                    o_a = BitConverter.GetBytes(PlayerUltID_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[PlayerSectionPointer[x2] + 0x08 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(PlayerDisableTrueAwakening_List[x2]);
                for (int a8 = 0; a8 < 1; a8++) {
                    file[PlayerSectionPointer[x2] + 0x0C + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(PlayerEnableAltTexture_List[x2]);
                for (int a8 = 0; a8 < 1; a8++) {
                    file[PlayerSectionPointer[x2] + 0x10 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(PlayerUnknownValue1_List[x2]);
                for (int a8 = 0; a8 < 1; a8++) {
                    file[PlayerSectionPointer[x2] + 0x14 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(PlayerUnknownValue2_List[x2]);
                for (int a8 = 0; a8 < 1; a8++) {
                    file[PlayerSectionPointer[x2] + 0x18 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(PlayerActivateArmorBreakModel_List[x2]);
                for (int a8 = 0; a8 < 1; a8++) {
                    file[PlayerSectionPointer[x2] + 0x1C + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(PlayerUnknownValue3_List[x2]);
                for (int a8 = 0; a8 < 1; a8++) {
                    file[PlayerSectionPointer[x2] + 0x20 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(PlayerEnableAwakeningFromStart_List[x2]);
                for (int a8 = 0; a8 < 1; a8++) {
                    file[PlayerSectionPointer[x2] + 0x24 + a8] = o_a[a8];
                }
                //Player support section
                for (int j = 0; j<2; j++) {
                    o_a = BitConverter.GetBytes(PlayerSupportID_List[x2][j]);
                    for (int a8 = 0; a8 < 4; a8++) {
                        file[PlayerSupportSectionPointerList[x2][j] + 0x00 + a8] = o_a[a8];
                    }
                    if (PlayerSupportSkillID_List[x2][j] < 0 || PlayerSupportSkillID_List[x2][j] > 5)
                        o_a = new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
                    else
                        o_a = BitConverter.GetBytes(PlayerSupportSkillID_List[x2][j]);
                    for (int a8 = 0; a8 < 4; a8++) {
                        file[PlayerSupportSectionPointerList[x2][j] + 0x04 + a8] = o_a[a8];
                    }
                    if (PlayerSupportUltID_List[x2][j] < 0 || PlayerSupportUltID_List[x2][j] > 5)
                        o_a = new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
                    else
                        o_a = BitConverter.GetBytes(PlayerSupportUltID_List[x2][j]);
                    for (int a8 = 0; a8 < 4; a8++) {
                        file[PlayerSupportSectionPointerList[x2][j] + 0x08 + a8] = o_a[a8];
                    }
                    o_a = BitConverter.GetBytes(PlayerSupportDisableTrueAwakening_List[x2][j]);
                    file[PlayerSupportSectionPointerList[x2][j] + 0x0C] = o_a[0];
                    o_a = BitConverter.GetBytes(PlayerSupportEnableAltTexture_List[x2][j]);
                    file[PlayerSupportSectionPointerList[x2][j] + 0x10] = o_a[0];
                    o_a = BitConverter.GetBytes(PlayerSupportUnknownValue1_List[x2][j]);
                    file[PlayerSupportSectionPointerList[x2][j] + 0x14] = o_a[0];
                    o_a = BitConverter.GetBytes(PlayerSupportDisableArmorBreak1_List[x2][j]);
                    file[PlayerSupportSectionPointerList[x2][j] + 0x18] = o_a[0];
                    o_a = BitConverter.GetBytes(PlayerSupportUnknownValue2_List[x2][j]);
                    file[PlayerSupportSectionPointerList[x2][j] + 0x1C] = o_a[0];
                    o_a = BitConverter.GetBytes(PlayerSupportDisableArmorBreak2_List[x2][j]);
                    file[PlayerSupportSectionPointerList[x2][j] + 0x20] = o_a[0];
                    o_a = BitConverter.GetBytes(PlayerSupportEnableAwakeningFromStart_List[x2][j]);
                    file[PlayerSupportSectionPointerList[x2][j] + 0x24] = o_a[0];
                }
                //Enemy section
                o_a = BitConverter.GetBytes(EnemyID_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[EnemySectionPointer[x2] + 0x00 + a8] = o_a[a8];
                }
                if (EnemySkillID_List[x2] < 0 || EnemySkillID_List[x2] > 5)
                    o_a = new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
                else
                    o_a = BitConverter.GetBytes(EnemySkillID_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[EnemySectionPointer[x2] + 0x04 + a8] = o_a[a8];
                }
                if (EnemyUltID_List[x2] < 0 || EnemyUltID_List[x2] > 3)
                    o_a = new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
                else
                    o_a = BitConverter.GetBytes(EnemyUltID_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[EnemySectionPointer[x2] + 0x08 + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(EnemyDisableTrueAwakening_List[x2]);
                file[EnemySectionPointer[x2] + 0x10] = o_a[0];
                o_a = BitConverter.GetBytes(EnemyUnknownValue1_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[EnemySectionPointer[x2] + 0x0C + a8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(EnemyEnableAltTexture_List[x2]);
                file[EnemySectionPointer[x2] + 0x14] = o_a[0];
                o_a = BitConverter.GetBytes(EnemyUnknownValue2_List[x2]);
                file[EnemySectionPointer[x2] + 0x1C] = o_a[0];
                o_a = BitConverter.GetBytes(EnemyActivateArmorBreakModel_List[x2]);
                file[EnemySectionPointer[x2] + 0x20] = o_a[0];
                o_a = BitConverter.GetBytes(EnemyDisableSubstitution_List[x2]);
                file[EnemySectionPointer[x2] + 0x24] = o_a[0];
                o_a = BitConverter.GetBytes(EnemyEnableAwakeningFromStart_List[x2]);
                file[EnemySectionPointer[x2] + 0x28] = o_a[0];
                o_a = BitConverter.GetBytes(EnemyLevel_List[x2]);
                file[EnemySectionPointer[x2] + 0x2C] = o_a[0];
                //Enemy support section
                for (int j = 0; j < 2; j++) {
                    o_a = BitConverter.GetBytes(EnemySupportID_List[x2][j]);
                    for (int a8 = 0; a8 < 4; a8++) {
                        file[EnemySupportSectionPointerList[x2][j] + 0x00 + a8] = o_a[a8];
                    }
                    if (EnemySupportSkillID_List[x2][j] < 0 || EnemySupportSkillID_List[x2][j] > 5)
                        o_a = new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
                    else
                        o_a = BitConverter.GetBytes(EnemySupportSkillID_List[x2][j]);
                    for (int a8 = 0; a8 < 4; a8++) {
                        file[EnemySupportSectionPointerList[x2][j] + 0x04 + a8] = o_a[a8];
                    }
                    if (EnemySupportUltID_List[x2][j] < 0 || EnemySupportUltID_List[x2][j] > 5)
                        o_a = new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
                    else
                        o_a = BitConverter.GetBytes(EnemySupportUltID_List[x2][j]);
                    for (int a8 = 0; a8 < 4; a8++) {
                        file[EnemySupportSectionPointerList[x2][j] + 0x08 + a8] = o_a[a8];
                    }
                    o_a = BitConverter.GetBytes(EnemySupportDisableTrueAwakening_List[x2][j]);
                    file[EnemySupportSectionPointerList[x2][j] + 0x0C] = o_a[0];
                    o_a = new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
                    for (int a8 = 0; a8 < 4; a8++) {
                        file[EnemySupportSectionPointerList[x2][j] + 0x10 + a8] = o_a[a8];
                    }
                    o_a = BitConverter.GetBytes(EnemySupportEnableAltTexture_List[x2][j]);
                    file[EnemySupportSectionPointerList[x2][j] + 0x14] = o_a[0];
                    o_a = BitConverter.GetBytes(EnemySupportUnknownValue1_List[x2][j]);
                    file[EnemySupportSectionPointerList[x2][j] + 0x18] = o_a[0];
                    o_a = BitConverter.GetBytes(EnemySupportDisableArmorBreak1_List[x2][j]);
                    file[EnemySupportSectionPointerList[x2][j] + 0x1C] = o_a[0];
                    o_a = BitConverter.GetBytes(EnemySupportDisableSubstitution_List[x2][j]);
                    file[EnemySupportSectionPointerList[x2][j] + 0x20] = o_a[0];
                    o_a = BitConverter.GetBytes(EnemySupportDisableArmorBreak2_List[x2][j]);
                    file[EnemySupportSectionPointerList[x2][j] + 0x24] = o_a[0];
                    o_a = BitConverter.GetBytes(EnemySupportEnableAwakeningFromStart_List[x2][j]);
                    file[EnemySupportSectionPointerList[x2][j] + 0x28] = o_a[0];
                }
            }
            int FileSize3 = file.Count - 284;
            byte[] sizeBytes3 = BitConverter.GetBytes(FileSize3);
            int FileSize2 = file.Count - 268 + 4;
            byte[] sizeBytes2 = BitConverter.GetBytes(FileSize3 + 4);
            for (int a20 = 0; a20 < 4; a20++) {
                file[280 + a20] = sizeBytes3[3 - a20];
            }
            for (int a19 = 0; a19 < 4; a19++) {
                file[268 + a19] = sizeBytes2[3 - a19];
            }
            byte[] countBytes = BitConverter.GetBytes(EntryCount);
            for (int a18 = 0; a18 < 4; a18++) {
                file[288 + a18] = countBytes[a18];
            }
            byte[] finalBytes = new byte[20]
            {
                0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x02,0x00,0x79,0x18,0x00,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x00
            };
            for (int x = 0; x < finalBytes.Length; x++) {
                file.Add(finalBytes[x]);
            }
            return file.ToArray();
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e) {

        }
    }
}
