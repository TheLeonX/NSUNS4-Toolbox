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

namespace NSUNS4_Character_Manager.Functions {
    public partial class Tool_ImportCharacter : Form {
        public Tool_ImportCharacter() {
            InitializeComponent();
        }
        public List<string> CharacterPathList = new List<string>();
        public List<bool> ReplaceCharacterList = new List<bool>();
        public List<int> CharacodeList = new List<int>();
        public List<int> PageList = new List<int>();
        public List<int> SlotList = new List<int>();
        string originalChaPath = Directory.GetCurrentDirectory() + "\\systemFiles\\characode.bin.xfbin";
        string originalDppPath = Directory.GetCurrentDirectory() + "\\systemFiles\\duelPlayerParam.xfbin";
        string originalafterAttachObjectPath = Directory.GetCurrentDirectory() + "\\systemFiles\\afterAttachObject.xfbin";
        string originalappearanceAnmPath = Directory.GetCurrentDirectory() + "\\systemFiles\\appearanceAnm.xfbin";
        string originalawakeAuraPath = Directory.GetCurrentDirectory() + "\\systemFiles\\awakeAura.xfbin";
        string originalskillCustomizeParamPath = Directory.GetCurrentDirectory() + "\\systemFiles\\skillCustomizeParam.xfbin";
        string originalspSkillCustomizeParamPath = Directory.GetCurrentDirectory() + "\\systemFiles\\spSkillCustomizeParam.xfbin";
        string originalIconPath = Directory.GetCurrentDirectory() + "\\systemFiles\\player_icon.xfbin";
        string originalCspPath = Directory.GetCurrentDirectory() + "\\systemFiles\\characterSelectParam.xfbin";
        string originalPspPath = Directory.GetCurrentDirectory() + "\\systemFiles\\playerSettingParam.bin.xfbin";
        private void importToolStripMenuItem_Click(object sender, EventArgs e) {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog();
            if (Directory.Exists(f.SelectedPath)) {
                DirectoryInfo d = new DirectoryInfo(@f.SelectedPath);
                if (listBox1.Items.Contains(d.Name)) {
                    MessageBox.Show("This character can't be imported, cuz this characode was already used");
                    return;
                }
                if (File.Exists(f.SelectedPath + "\\characode.txt")) {
                    int CharacodeID = Convert.ToInt32(File.ReadAllText(f.SelectedPath + "\\characode.txt"));
                    listBox1.Items.Add(d.Name);
                    CharacterPathList.Add(f.SelectedPath);
                    if (!File.Exists(Main.chaPath)) {
                        Main.chaPath = originalChaPath;
                    }
                    Tool_CharacodeEditor CharacodeFile = new Tool_CharacodeEditor();
                    CharacodeFile.OpenFile(Main.chaPath);
                    bool replace = false;
                    for (int x = 0; x < CharacodeFile.CharacterCount; x++) {
                        if (CharacodeFile.CharacterList[x].Contains(d.Name)) {
                            MessageBox.Show("This character will replace exist character");
                            replace = true;
                        }
                    }
                    ReplaceCharacterList.Add(replace);
                    CharacodeList.Add(CharacodeID);
                    PageList.Add(0);
                    SlotList.Add(0);
                }
                else {
                    MessageBox.Show("Invalid character");
                    return;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x!=-1) {
                CharacterPathList.RemoveAt(x);
                ReplaceCharacterList.RemoveAt(x);
                CharacodeList.RemoveAt(x);
                PageList.RemoveAt(x);
                SlotList.RemoveAt(x);
                listBox1.Items.RemoveAt(x);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                if (ReplaceCharacterList[x]) {
                    numericUpDown1.Enabled = false;
                    numericUpDown2.Enabled = false;
                    button2.Enabled = false;
                }
                else {
                    numericUpDown1.Enabled = true;
                    numericUpDown2.Enabled = true;
                    button2.Enabled = true;
                }
                numericUpDown1.Value = PageList[x];
                numericUpDown2.Value = SlotList[x];
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                PageList[x] = (int)numericUpDown1.Value;
                SlotList[x] = (int)numericUpDown2.Value;
            }
        }
        public void CopyFiles(string targetPath, string originalDataWin32, string newDataWin32) {
            if (File.Exists(originalDataWin32)) {
                if (!Directory.Exists(targetPath)) {
                    Directory.CreateDirectory(targetPath);
                }
                File.Copy(originalDataWin32, newDataWin32, true);
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            if (CharacterPathList.Count > 0) {
                for (int i = 0; i< CharacterPathList.Count; i++) {
                    DirectoryInfo d = new DirectoryInfo(CharacterPathList[i]);
                    FileInfo[] Files = d.GetFiles("*.xfbin", SearchOption.AllDirectories);

                    DirectoryInfo d_or = new DirectoryInfo(Main.datawin32Path);

                    string dataWinFolder = d_or.Name + "\\";
                    int dataWinFolderLength = dataWinFolder.Length;

                    int CharacodeID = 0;

                    string dppPath = "";
                    string cspPath = "";
                    string pspPath = "";
                    string skillCustomizePath = "";
                    string spskillCustomizePath = "";
                    string awakeAuraPath = "";
                    string iconPath = "";
                    string appearanceAnmPath = "";
                    string afterAttachObjectPath = "";
                    bool dppExist = false;
                    bool pspExist = false;
                    bool cspExist = false;
                    bool skillCustomizeExist = false;
                    bool spskillCustomizeExist = false;
                    bool iconExist = false;
                    bool awakeAuraExist = false;
                    bool appearanceAnmExist = false;
                    bool afterAttachObjectExist = false;
                    foreach (FileInfo file in Files) {
                        if (file.FullName.Contains("spc\\duelPlayerParam.xfbin")) {
                            dppExist = true;
                            dppPath = file.FullName;
                            break;
                        } else {
                            dppExist = false;
                            dppPath = "";
                        }
                    }
                    foreach (FileInfo file in Files) {
                        if (file.FullName.Contains("ui\\max\\select\\WIN64\\characterSelectParam.xfbin")) {
                            cspExist = true;
                            cspPath = file.FullName;
                            break;
                        } else {
                            cspExist = false;
                            cspPath = "";
                        }
                    }
                    foreach (FileInfo file in Files) {
                        if (file.FullName.Contains("spc\\WIN64\\playerSettingParam.bin.xfbin")) {
                            pspExist = true;
                            pspPath = file.FullName;
                            break;
                        } else {
                            pspExist = false;
                            pspPath = "";
                        }
                    }
                    foreach (FileInfo file in Files) {
                        if (file.FullName.Contains("spc\\WIN64\\skillCustomizeParam.xfbin")) {
                            skillCustomizeExist = true;
                            skillCustomizePath = file.FullName;
                            break;
                        } else {
                            skillCustomizeExist = false;
                            skillCustomizePath = "";
                        }
                    }
                    foreach (FileInfo file in Files) {
                        if (file.FullName.Contains("spc\\WIN64\\spSkillCustomizeParam.xfbin")) {
                            spskillCustomizeExist = true;
                            spskillCustomizePath = file.FullName;
                            break;
                        } else {
                            spskillCustomizeExist = false;
                            spskillCustomizePath = "";
                        }
                    }
                    foreach (FileInfo file in Files) {
                        if (file.FullName.Contains("spc\\WIN64\\player_icon.xfbin")) {
                            iconExist = true;
                            iconPath = file.FullName;
                            break;
                        } else {
                            iconExist = false;
                            iconPath = "";
                        }
                    }
                    foreach (FileInfo file in Files) {
                        if (file.FullName.Contains("spc\\WIN64\\awakeAura.xfbin")) {
                            awakeAuraExist = true;
                            awakeAuraPath = file.FullName;
                            break;
                        } else {
                            awakeAuraExist = false;
                            awakeAuraPath = "";
                        }
                    }
                    foreach (FileInfo file in Files) {
                        if (file.FullName.Contains("spc\\WIN64\\appearanceAnm.xfbin")) {
                            appearanceAnmExist = true;
                            appearanceAnmPath = file.FullName;
                            break;
                        } else {
                            appearanceAnmExist = false;
                            appearanceAnmPath = "";
                        }
                    }
                    foreach (FileInfo file in Files) {
                        if (file.FullName.Contains("spc\\WIN64\\afterAttachObject.xfbin")) {
                            afterAttachObjectExist = true;
                            afterAttachObjectPath = file.FullName;
                            break;
                        } else {
                            afterAttachObjectExist = false;
                            afterAttachObjectPath = "";
                        }
                    }
                    if (!ReplaceCharacterList[i]) {
                        if (!File.Exists(Main.datawin32Path + "\\spc\\characode.bin.xfbin")) {
                            Main.chaPath = originalChaPath;
                        }
                        Tool_CharacodeEditor CharacodeFile = new Tool_CharacodeEditor();
                        CharacodeFile.OpenFile(Main.chaPath);
                        CharacodeFile.AddID(d.Name);
                        if (!Directory.Exists(Main.datawin32Path + "\\spc")) {
                            Directory.CreateDirectory(Main.datawin32Path + "\\spc");
                        }
                        CharacodeFile.SaveFileAs(Main.datawin32Path + "\\spc\\characode.bin.xfbin");
                        for (int z = 0; z<CharacodeFile.CharacterCount; z++) {
                            if (CharacodeFile.CharacterList[z].Contains(d.Name)) {
                                CharacodeID = z + 1;
                                break;
                            }
                        }
                    }

                    if (dppExist) {
                        Tool_DuelPlayerParamEditor DppModFile = new Tool_DuelPlayerParamEditor();
                        Tool_DuelPlayerParamEditor DppOriginalFile = new Tool_DuelPlayerParamEditor();
                        DppModFile.OpenFile(dppPath);
                        if (File.Exists(Main.dppPath))
                            DppOriginalFile.OpenFile(Main.dppPath);
                        else {
                            Main.dppPath = originalDppPath;
                            DppOriginalFile.OpenFile(Main.dppPath);
                        }
                        if (ReplaceCharacterList[i]) {
                            for (int c = 0; c < DppOriginalFile.EntryCount; c++) {
                                if (DppOriginalFile.BinName[i].Contains(d.Name)) {
                                    DppOriginalFile.BinPath[i] = DppModFile.BinPath[0];
                                    DppOriginalFile.BinName[i] = DppModFile.BinName[0];
                                    DppOriginalFile.Data[i] = DppModFile.Data[0];
                                    DppOriginalFile.CharaList[i] = DppModFile.CharaList[0];
                                    DppOriginalFile.CostumeList[i] = DppModFile.CostumeList[0];
                                    DppOriginalFile.AwkCostumeList[i] = DppModFile.AwkCostumeList[0];
                                    DppOriginalFile.DefaultAssist1[i] = DppModFile.DefaultAssist1[0];
                                    DppOriginalFile.DefaultAssist2[i] = DppModFile.DefaultAssist2[0];
                                    DppOriginalFile.AwkAction[i] = DppModFile.AwkAction[0];
                                    DppOriginalFile.ItemList[i] = DppModFile.ItemList[0];
                                    DppOriginalFile.ItemCount[i] = DppModFile.ItemCount[0];
                                    DppOriginalFile.Partner[i] = DppModFile.Partner[0];
                                    DppOriginalFile.SettingList[i] = DppModFile.SettingList[0];
                                    DppOriginalFile.Setting2List[i] = DppModFile.Setting2List[0];
                                    DppOriginalFile.EnableAwaSkillList[i] = DppModFile.EnableAwaSkillList[0];
                                    DppOriginalFile.VictoryAngleList[i] = DppModFile.VictoryAngleList[0];
                                    DppOriginalFile.VictoryPosList[i] = DppModFile.VictoryPosList[0];
                                    DppOriginalFile.VictoryUnknownList[i] = DppModFile.VictoryUnknownList[0];
                                    DppOriginalFile.AwaSettingList[i] = DppModFile.AwaSettingList[0];
                                }

                            }
                            
                        }
                        else {
                            DppOriginalFile.BinPath.Add(DppModFile.BinPath[0]);
                            DppOriginalFile.BinName.Add(DppModFile.BinName[0]);
                            DppOriginalFile.Data.Add(DppModFile.Data[0]);
                            DppOriginalFile.CharaList.Add(DppModFile.CharaList[0]);
                            DppOriginalFile.CostumeList.Add(DppModFile.CostumeList[0]);
                            DppOriginalFile.AwkCostumeList.Add(DppModFile.AwkCostumeList[0]);
                            DppOriginalFile.DefaultAssist1.Add(DppModFile.DefaultAssist1[0]);
                            DppOriginalFile.DefaultAssist2.Add(DppModFile.DefaultAssist2[0]);
                            DppOriginalFile.AwkAction.Add(DppModFile.AwkAction[0]);
                            DppOriginalFile.ItemList.Add(DppModFile.ItemList[0]);
                            DppOriginalFile.ItemCount.Add(DppModFile.ItemCount[0]);
                            DppOriginalFile.Partner.Add(DppModFile.Partner[0]);
                            DppOriginalFile.SettingList.Add(DppModFile.SettingList[0]);
                            DppOriginalFile.Setting2List.Add(DppModFile.Setting2List[0]);
                            DppOriginalFile.EnableAwaSkillList.Add(DppModFile.EnableAwaSkillList[0]);
                            DppOriginalFile.VictoryAngleList.Add(DppModFile.VictoryAngleList[0]);
                            DppOriginalFile.VictoryPosList.Add(DppModFile.VictoryPosList[0]);
                            DppOriginalFile.VictoryUnknownList.Add(DppModFile.VictoryUnknownList[0]);
                            DppOriginalFile.AwaSettingList.Add(DppModFile.AwaSettingList[0]);
                            DppOriginalFile.EntryCount++;
                        }
                        if (!Directory.Exists(Main.datawin32Path + "\\spc")) {
                            Directory.CreateDirectory(Main.datawin32Path + "\\spc");
                        }
                        DppOriginalFile.SaveFileAs(Main.datawin32Path + "\\spc\\duelPlayerParam.xfbin");
                    }
                    if (pspExist) {
                        Tool_PlayerSettingParamEditor PspModFile = new Tool_PlayerSettingParamEditor();
                        Tool_PlayerSettingParamEditor PspOriginalFile = new Tool_PlayerSettingParamEditor();
                        PspModFile.OpenFile(pspPath);
                        if (File.Exists(Main.pspPath))
                            PspOriginalFile.OpenFile(Main.pspPath);
                        else {
                            Main.pspPath = originalPspPath;
                            PspOriginalFile.OpenFile(Main.pspPath);
                        }
                        if (ReplaceCharacterList[i]) {
                            for (int y = 0; y < PspModFile.EntryCount; y++) {
                                bool found = false;
                                for (int z = 0; z < PspOriginalFile.EntryCount; z++) {
                                    if (PspOriginalFile.CharacterList[z] == PspModFile.CharacterList[y]) {
                                        PspOriginalFile.CharacodeList[z] = PspOriginalFile.CharacodeList[y];
                                        PspOriginalFile.OptValueA[z] = PspOriginalFile.OptValueA[y];
                                        PspOriginalFile.OptValueB[z] = PspOriginalFile.OptValueB[y];
                                        PspOriginalFile.OptValueC[z] = PspOriginalFile.OptValueC[y];
                                        PspOriginalFile.c_cha_a_List[z] = PspOriginalFile.c_cha_a_List[y];
                                        PspOriginalFile.c_cha_b_List[z] = PspOriginalFile.c_cha_b_List[y];
                                        PspOriginalFile.OptValueD[z] = PspOriginalFile.OptValueD[y];
                                        PspOriginalFile.OptValueE[z] = PspOriginalFile.OptValueE[y];
                                        found = true;
                                        break;
                                    }
                                }
                                if (!found) {
                                    List<int> PresetID_List = new List<int>();
                                    for (int j = 0; j< PspOriginalFile.EntryCount; j++) {
                                        PresetID_List.Add(Main.b_byteArrayToInt(PspOriginalFile.PresetList[j]));
                                    }
                                    int maxValue = PresetID_List.Max();
                                    int new_presetID = 0;
                                    do {
                                        new_presetID++;
                                    }
                                    while (PresetID_List.Contains(new_presetID));
                                    int old_PresetID = Main.b_byteArrayToInt(PspModFile.PresetList[y]);
                                    PspModFile.PresetList[y] = BitConverter.GetBytes(new_presetID);
                                    for (int h = 0; h < PspModFile.EntryCount; h++) {
                                        if (PspModFile.OptValueE[h] == old_PresetID)
                                            PspModFile.OptValueE[h] = new_presetID;
                                    }
                                    PspOriginalFile.PresetList.Add(PspModFile.PresetList[y]);
                                    PspOriginalFile.CharacodeList.Add(PspModFile.CharacodeList[y]);
                                    PspOriginalFile.OptValueA.Add(PspModFile.OptValueA[y]);
                                    PspOriginalFile.CharacterList.Add(PspModFile.CharacterList[y]);
                                    PspOriginalFile.OptValueB.Add(PspModFile.OptValueB[y]);
                                    PspOriginalFile.OptValueC.Add(PspModFile.OptValueC[y]);
                                    PspOriginalFile.c_cha_a_List.Add(PspModFile.c_cha_a_List[y]);
                                    PspOriginalFile.c_cha_b_List.Add(PspModFile.c_cha_b_List[y]);
                                    PspOriginalFile.OptValueD.Add(PspModFile.OptValueD[y]);
                                    PspOriginalFile.OptValueE.Add(PspModFile.OptValueE[y]);
                                    PspOriginalFile.EntryCount++;
                                }
                            }
                        }
                        else {
                            for (int y = 0; y < PspModFile.EntryCount; y++) {
                                List<int> PresetID_List = new List<int>();
                                for (int j = 0; j < PspOriginalFile.EntryCount; j++) {
                                    PresetID_List.Add(Main.b_byteArrayToInt(PspOriginalFile.PresetList[j]));
                                }
                                int new_presetID = 0;
                                do {
                                    new_presetID++;
                                }
                                while (PresetID_List.Contains(new_presetID));
                                int old_PresetID = Main.b_byteArrayToInt(PspModFile.PresetList[y]);
                                PspModFile.PresetList[y] = BitConverter.GetBytes(new_presetID);
                                for (int h = 0; h < PspModFile.EntryCount; h++) {
                                    if (PspModFile.OptValueE[h] == old_PresetID)
                                        PspModFile.OptValueE[h] = new_presetID;
                                }
                                PspOriginalFile.PresetList.Add(PspModFile.PresetList[y]);
                                PspOriginalFile.CharacodeList.Add(BitConverter.GetBytes(CharacodeID));
                                PspOriginalFile.OptValueA.Add(PspModFile.OptValueA[y]);
                                PspOriginalFile.CharacterList.Add(PspModFile.CharacterList[y]);
                                PspOriginalFile.OptValueB.Add(PspModFile.OptValueB[y]);
                                PspOriginalFile.OptValueC.Add(PspModFile.OptValueC[y]);
                                PspOriginalFile.c_cha_a_List.Add(PspModFile.c_cha_a_List[y]);
                                PspOriginalFile.c_cha_b_List.Add(PspModFile.c_cha_b_List[y]);
                                PspOriginalFile.OptValueD.Add(PspModFile.OptValueD[y]);
                                PspOriginalFile.OptValueE.Add(PspModFile.OptValueE[y]);
                                PspOriginalFile.EntryCount++;
                            }
                        }
                        if (!Directory.Exists(Main.datawin32Path + "\\spc\\WIN64")) {
                            Directory.CreateDirectory(Main.datawin32Path + "\\spc\\WIN64");
                        }
                        PspOriginalFile.SaveFileAs(Main.datawin32Path + "\\spc\\WIN64\\playerSettingParam.bin.xfbin");
                    }
                    if (cspExist) {
                        Tool_RosterEditor CspModFile = new Tool_RosterEditor();
                        Tool_RosterEditor CspOriginalFile = new Tool_RosterEditor();
                        CspModFile.OpenFile(cspPath);
                        if (File.Exists(Main.cspPath))
                            CspOriginalFile.OpenFile(Main.cspPath);
                        else {
                            Main.cspPath = originalCspPath;
                            CspOriginalFile.OpenFile(Main.cspPath);
                        }
                        if (ReplaceCharacterList[i]) {
                            for (int v = 0; v < CspModFile.EntryCount; v++) {
                                bool found = false;
                                for (int c = 0; c < CspOriginalFile.EntryCount; c++) {
                                    if (CspOriginalFile.CharacterList[c] == CspModFile.CharacterList[v]) {
                                        CspOriginalFile.PageList[c] = CspModFile.PageList[v];
                                        CspOriginalFile.PositionList[c] = CspModFile.PositionList[v];
                                        CspOriginalFile.CostumeList[c] = CspModFile.CostumeList[v];
                                        CspOriginalFile.ChaList[c] = CspModFile.ChaList[v];
                                        CspOriginalFile.AccessoryList[c] = CspModFile.AccessoryList[v];
                                        CspOriginalFile.NewIdList[c] = CspModFile.NewIdList[v];
                                        CspOriginalFile.GibberishBytes[c] = CspModFile.GibberishBytes[v];
                                        found = true;
                                    }

                                }
                                if (!found) {
                                    CspOriginalFile.CharacterList.Add(CspModFile.CharacterList[v]);
                                    CspOriginalFile.PageList.Add(CspModFile.PageList[v]);
                                    CspOriginalFile.PositionList.Add(CspModFile.PositionList[v]);
                                    CspOriginalFile.CostumeList.Add(CspModFile.CostumeList[v]);
                                    CspOriginalFile.ChaList.Add(CspModFile.ChaList[v]);
                                    CspOriginalFile.AccessoryList.Add(CspModFile.AccessoryList[v]);
                                    CspOriginalFile.NewIdList.Add(CspModFile.NewIdList[v]);
                                    CspOriginalFile.GibberishBytes.Add(CspModFile.GibberishBytes[v]);
                                    CspOriginalFile.EntryCount++;
                                }
                            }
                        } else {
                            for (int v = 0; v < CspModFile.EntryCount; v++) {
                                CspOriginalFile.CharacterList.Add(CspModFile.CharacterList[v]);
                                CspOriginalFile.PageList.Add(PageList[listBox1.SelectedIndex]);
                                CspOriginalFile.PositionList.Add(SlotList[listBox1.SelectedIndex]);
                                CspOriginalFile.CostumeList.Add(CspModFile.CostumeList[v]);
                                CspOriginalFile.ChaList.Add(CspModFile.ChaList[v]);
                                CspOriginalFile.AccessoryList.Add(CspModFile.AccessoryList[v]);
                                CspOriginalFile.NewIdList.Add(CspModFile.NewIdList[v]);
                                CspOriginalFile.GibberishBytes.Add(CspModFile.GibberishBytes[v]);
                                CspOriginalFile.EntryCount++;
                            }
                        }
                        if (!Directory.Exists(Main.datawin32Path + "\\ui\\max\\select\\WIN64")) {
                            Directory.CreateDirectory(Main.datawin32Path + "\\ui\\max\\select\\WIN64");
                        }
                        CspOriginalFile.SaveFileAs(Main.datawin32Path + "\\ui\\max\\select\\WIN64\\characterSelectParam.xfbin");
                    }
                    foreach (FileInfo file in Files) {
                        if (!file.Name.Contains("duelPlayerParam") && !file.Name.Contains("awakeAura") && !file.Name.Contains("appearanceAnm") && !file.Name.Contains("afterAttachObject") && !file.Name.Contains("characterSelectParam") && !file.Name.Contains("playerSettingParam") && !file.Name.Contains("skillCustomizeParam") && !file.Name.Contains("spSkillCustomizeParam") && !file.Name.Contains("player_icon")) {
                            if (file.Name.Contains(d.Name))
                                CopyFiles(Path.GetDirectoryName(Main.datawin32Path + "\\" + file.FullName.Substring(file.FullName.IndexOf(dataWinFolder) + dataWinFolderLength)), file.FullName, Main.datawin32Path + "\\" + file.FullName.Substring(file.FullName.IndexOf(dataWinFolder) + dataWinFolderLength));
                        }
                    }
                }
            }
        }

        private void Tool_ImportCharacter_FormClosed(object sender, FormClosedEventArgs e) {
            Main.LoadConfig();
        }
    }
}
