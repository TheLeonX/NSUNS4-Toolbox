﻿using NSUNS4_Character_Manager.Tools;
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


                    DirectoryInfo cha_d = new DirectoryInfo(CharacterPathList[i]);
                    FileInfo[] cha_Files = cha_d.GetFiles("*.txt", SearchOption.AllDirectories);

                    DirectoryInfo d = new DirectoryInfo(CharacterPathList[i]);
                    FileInfo[] Files = d.GetFiles("*.xfbin", SearchOption.AllDirectories);

                    DirectoryInfo d_or = new DirectoryInfo(Main.datawin32Path);

                    string dataWinFolder = d_or.Name + "\\";
                    int dataWinFolderLength = dataWinFolder.Length;
                    bool originalChaExist = false;
                    string originalPathCharacode = "";
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
                    string partnerSlotParamPath = "";
                    string specialCondParamPath = "";
                    bool dppExist = false;
                    bool pspExist = false;
                    bool cspExist = false;
                    bool skillCustomizeExist = false;
                    bool spskillCustomizeExist = false;
                    bool iconExist = false;
                    bool awakeAuraExist = false;
                    bool appearanceAnmExist = false;
                    bool afterAttachObjectExist = false;
                    bool partnerSlotParamExist = false;
                    bool specialCondParamExist = false;
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
                    foreach (FileInfo file in Files) {
                        if (file.FullName.Contains("partnerSlotParam.xfbin")) {
                            partnerSlotParamExist = true;
                            partnerSlotParamPath = file.FullName;
                            break;
                        } else {
                            partnerSlotParamExist = false;
                            partnerSlotParamPath = "";
                        }
                    }
                    foreach (FileInfo file in Files) {
                        if (file.FullName.Contains("specialCondParam.xfbin")) {
                            specialCondParamExist = true;
                            specialCondParamPath = file.FullName;
                            break;
                        } else {
                            specialCondParamExist = false;
                            specialCondParamPath = "";
                        }
                    }
                    foreach (FileInfo file in cha_Files) {
                        if (file.FullName.Contains("characode.txt")) {
                            originalChaExist = true;
                            originalPathCharacode = file.FullName;
                            break;
                        } else {
                            originalChaExist = false;
                            originalPathCharacode = "";
                        }
                    }
                    if (originalChaExist) {
                        int OldCharacode = Convert.ToInt32(File.ReadAllText(originalPathCharacode));
                        //characode
                        if (!ReplaceCharacterList[i]) {
                            Tool_CharacodeEditor CharacodeFile = new Tool_CharacodeEditor();
                            if (File.Exists(Main.datawin32Path + "\\spc\\characode.bin.xfbin"))
                                CharacodeFile.OpenFile(Main.datawin32Path + "\\spc\\characode.bin.xfbin");
                            else {
                                CharacodeFile.OpenFile(originalChaPath);
                            }
                            CharacodeFile.AddID(d.Name);
                            if (!Directory.Exists(Main.datawin32Path + "\\spc")) {
                                Directory.CreateDirectory(Main.datawin32Path + "\\spc");
                            }
                            CharacodeFile.SaveFileAs(Main.datawin32Path + "\\spc\\characode.bin.xfbin");
                            for (int z = 0; z < CharacodeFile.CharacterCount; z++) {
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
                                DppOriginalFile.OpenFile(originalDppPath);
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

                            } else {
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
                                PspOriginalFile.OpenFile(originalPspPath);
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
                                        for (int j = 0; j < PspOriginalFile.EntryCount; j++) {
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
                            } else {
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
                                CspOriginalFile.OpenFile(originalCspPath);
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
                                    CspOriginalFile.PageList.Add(PageList[i]);
                                    CspOriginalFile.PositionList.Add(SlotList[i]);
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
                        if (skillCustomizeExist) {
                            Tool_SkillCustomizeParamEditor_new skillCustomizeModFile = new Tool_SkillCustomizeParamEditor_new();
                            Tool_SkillCustomizeParamEditor_new skillCustomizeOriginalFile = new Tool_SkillCustomizeParamEditor_new();
                            skillCustomizeModFile.OpenFile(skillCustomizePath);
                            if (File.Exists(Main.skillCustomizePath))
                                skillCustomizeOriginalFile.OpenFile(Main.skillCustomizePath);
                            else {
                                skillCustomizeOriginalFile.OpenFile(originalskillCustomizeParamPath);
                            }
                            if (ReplaceCharacterList[i]) {
                                for (int c = 0; c < skillCustomizeOriginalFile.EntryCount; c++) {
                                    if (Main.b_byteArrayToInt(skillCustomizeOriginalFile.CharacodeList[c]) == Main.b_byteArrayToInt(skillCustomizeModFile.CharacodeList[0])) {
                                        skillCustomizeOriginalFile.Skill1List[c] = skillCustomizeModFile.Skill1List[0];
                                        skillCustomizeOriginalFile.Skill2List[c] = skillCustomizeModFile.Skill2List[0];
                                        skillCustomizeOriginalFile.Skill3List[c] = skillCustomizeModFile.Skill3List[0];
                                        skillCustomizeOriginalFile.Skill4List[c] = skillCustomizeModFile.Skill4List[0];
                                        skillCustomizeOriginalFile.Skill5List[c] = skillCustomizeModFile.Skill5List[0];
                                        skillCustomizeOriginalFile.Skill6List[c] = skillCustomizeModFile.Skill6List[0];
                                        skillCustomizeOriginalFile.SkillAwaList[c] = skillCustomizeModFile.SkillAwaList[0];
                                        skillCustomizeOriginalFile.Skill1_ex_List[c] = skillCustomizeModFile.Skill1_ex_List[0];
                                        skillCustomizeOriginalFile.Skill2_ex_List[c] = skillCustomizeModFile.Skill2_ex_List[0];
                                        skillCustomizeOriginalFile.Skill3_ex_List[c] = skillCustomizeModFile.Skill3_ex_List[0];
                                        skillCustomizeOriginalFile.Skill4_ex_List[c] = skillCustomizeModFile.Skill4_ex_List[0];
                                        skillCustomizeOriginalFile.Skill5_ex_List[c] = skillCustomizeModFile.Skill5_ex_List[0];
                                        skillCustomizeOriginalFile.Skill6_ex_List[c] = skillCustomizeModFile.Skill6_ex_List[0];
                                        skillCustomizeOriginalFile.SkillAwa_ex_List[c] = skillCustomizeModFile.SkillAwa_ex_List[0];
                                        skillCustomizeOriginalFile.Skill1_air_List[c] = skillCustomizeModFile.Skill1_air_List[0];
                                        skillCustomizeOriginalFile.Skill2_air_List[c] = skillCustomizeModFile.Skill2_air_List[0];
                                        skillCustomizeOriginalFile.Skill3_air_List[c] = skillCustomizeModFile.Skill3_air_List[0];
                                        skillCustomizeOriginalFile.Skill4_air_List[c] = skillCustomizeModFile.Skill4_air_List[0];
                                        skillCustomizeOriginalFile.Skill5_air_List[c] = skillCustomizeModFile.Skill5_air_List[0];
                                        skillCustomizeOriginalFile.Skill6_air_List[c] = skillCustomizeModFile.Skill6_air_List[0];
                                        skillCustomizeOriginalFile.SkillAwa_air_List[c] = skillCustomizeModFile.SkillAwa_air_List[0];
                                        skillCustomizeOriginalFile.Skill1_CUC_List[c] = skillCustomizeModFile.Skill1_CUC_List[0];
                                        skillCustomizeOriginalFile.Skill2_CUC_List[c] = skillCustomizeModFile.Skill2_CUC_List[0];
                                        skillCustomizeOriginalFile.Skill3_CUC_List[c] = skillCustomizeModFile.Skill3_CUC_List[0];
                                        skillCustomizeOriginalFile.Skill4_CUC_List[c] = skillCustomizeModFile.Skill4_CUC_List[0];
                                        skillCustomizeOriginalFile.Skill5_CUC_List[c] = skillCustomizeModFile.Skill5_CUC_List[0];
                                        skillCustomizeOriginalFile.Skill6_CUC_List[c] = skillCustomizeModFile.Skill6_CUC_List[0];
                                        skillCustomizeOriginalFile.SkillAwa_CUC_List[c] = skillCustomizeModFile.SkillAwa_CUC_List[0];
                                        skillCustomizeOriginalFile.Skill1_CUCC_List[c] = skillCustomizeModFile.Skill1_CUCC_List[0];
                                        skillCustomizeOriginalFile.Skill2_CUCC_List[c] = skillCustomizeModFile.Skill2_CUCC_List[0];
                                        skillCustomizeOriginalFile.Skill3_CUCC_List[c] = skillCustomizeModFile.Skill3_CUCC_List[0];
                                        skillCustomizeOriginalFile.Skill4_CUCC_List[c] = skillCustomizeModFile.Skill4_CUCC_List[0];
                                        skillCustomizeOriginalFile.Skill5_CUCC_List[c] = skillCustomizeModFile.Skill5_CUCC_List[0];
                                        skillCustomizeOriginalFile.Skill6_CUCC_List[c] = skillCustomizeModFile.Skill6_CUCC_List[0];
                                        skillCustomizeOriginalFile.SkillAwa_CUCC_List[c] = skillCustomizeModFile.SkillAwa_CUCC_List[0];
                                        skillCustomizeOriginalFile.Skill1_Priority_List[c] = skillCustomizeModFile.Skill1_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill2_Priority_List[c] = skillCustomizeModFile.Skill2_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill3_Priority_List[c] = skillCustomizeModFile.Skill3_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill4_Priority_List[c] = skillCustomizeModFile.Skill4_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill5_Priority_List[c] = skillCustomizeModFile.Skill5_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill6_Priority_List[c] = skillCustomizeModFile.Skill6_Priority_List[0];
                                        skillCustomizeOriginalFile.SkillAwa_Priority_List[c] = skillCustomizeModFile.SkillAwa_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill1ex_Priority_List[c] = skillCustomizeModFile.Skill1ex_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill2ex_Priority_List[c] = skillCustomizeModFile.Skill2ex_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill3ex_Priority_List[c] = skillCustomizeModFile.Skill3ex_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill4ex_Priority_List[c] = skillCustomizeModFile.Skill4ex_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill5ex_Priority_List[c] = skillCustomizeModFile.Skill5ex_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill6ex_Priority_List[c] = skillCustomizeModFile.Skill6ex_Priority_List[0];
                                        skillCustomizeOriginalFile.SkillAwaex_Priority_List[c] = skillCustomizeModFile.SkillAwaex_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill1air_Priority_List[c] = skillCustomizeModFile.Skill1air_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill2air_Priority_List[c] = skillCustomizeModFile.Skill2air_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill3air_Priority_List[c] = skillCustomizeModFile.Skill3air_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill4air_Priority_List[c] = skillCustomizeModFile.Skill4air_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill5air_Priority_List[c] = skillCustomizeModFile.Skill5air_Priority_List[0];
                                        skillCustomizeOriginalFile.Skill6air_Priority_List[c] = skillCustomizeModFile.Skill6air_Priority_List[0];
                                        skillCustomizeOriginalFile.SkillAwaair_Priority_List[c] = skillCustomizeModFile.SkillAwaair_Priority_List[0];

                                    }
                                }

                            } else {
                                skillCustomizeOriginalFile.CharacodeList.Add(BitConverter.GetBytes(CharacodeID));
                                skillCustomizeOriginalFile.Skill1List.Add(skillCustomizeModFile.Skill1List[0]);
                                skillCustomizeOriginalFile.Skill2List.Add(skillCustomizeModFile.Skill2List[0]);
                                skillCustomizeOriginalFile.Skill3List.Add(skillCustomizeModFile.Skill3List[0]);
                                skillCustomizeOriginalFile.Skill4List.Add(skillCustomizeModFile.Skill4List[0]);
                                skillCustomizeOriginalFile.Skill5List.Add(skillCustomizeModFile.Skill5List[0]);
                                skillCustomizeOriginalFile.Skill6List.Add(skillCustomizeModFile.Skill6List[0]);
                                skillCustomizeOriginalFile.SkillAwaList.Add(skillCustomizeModFile.SkillAwaList[0]);
                                skillCustomizeOriginalFile.Skill1_ex_List.Add(skillCustomizeModFile.Skill1_ex_List[0]);
                                skillCustomizeOriginalFile.Skill2_ex_List.Add(skillCustomizeModFile.Skill2_ex_List[0]);
                                skillCustomizeOriginalFile.Skill3_ex_List.Add(skillCustomizeModFile.Skill3_ex_List[0]);
                                skillCustomizeOriginalFile.Skill4_ex_List.Add(skillCustomizeModFile.Skill4_ex_List[0]);
                                skillCustomizeOriginalFile.Skill5_ex_List.Add(skillCustomizeModFile.Skill5_ex_List[0]);
                                skillCustomizeOriginalFile.Skill6_ex_List.Add(skillCustomizeModFile.Skill6_ex_List[0]);
                                skillCustomizeOriginalFile.SkillAwa_ex_List.Add(skillCustomizeModFile.SkillAwa_ex_List[0]);
                                skillCustomizeOriginalFile.Skill1_air_List.Add(skillCustomizeModFile.Skill1_air_List[0]);
                                skillCustomizeOriginalFile.Skill2_air_List.Add(skillCustomizeModFile.Skill2_air_List[0]);
                                skillCustomizeOriginalFile.Skill3_air_List.Add(skillCustomizeModFile.Skill3_air_List[0]);
                                skillCustomizeOriginalFile.Skill4_air_List.Add(skillCustomizeModFile.Skill4_air_List[0]);
                                skillCustomizeOriginalFile.Skill5_air_List.Add(skillCustomizeModFile.Skill5_air_List[0]);
                                skillCustomizeOriginalFile.Skill6_air_List.Add(skillCustomizeModFile.Skill6_air_List[0]);
                                skillCustomizeOriginalFile.SkillAwa_air_List.Add(skillCustomizeModFile.SkillAwa_air_List[0]);
                                skillCustomizeOriginalFile.Skill1_CUC_List.Add(skillCustomizeModFile.Skill1_CUC_List[0]);
                                skillCustomizeOriginalFile.Skill2_CUC_List.Add(skillCustomizeModFile.Skill2_CUC_List[0]);
                                skillCustomizeOriginalFile.Skill3_CUC_List.Add(skillCustomizeModFile.Skill3_CUC_List[0]);
                                skillCustomizeOriginalFile.Skill4_CUC_List.Add(skillCustomizeModFile.Skill4_CUC_List[0]);
                                skillCustomizeOriginalFile.Skill5_CUC_List.Add(skillCustomizeModFile.Skill5_CUC_List[0]);
                                skillCustomizeOriginalFile.Skill6_CUC_List.Add(skillCustomizeModFile.Skill6_CUC_List[0]);
                                skillCustomizeOriginalFile.SkillAwa_CUC_List.Add(skillCustomizeModFile.SkillAwa_CUC_List[0]);
                                skillCustomizeOriginalFile.Skill1_CUCC_List.Add(skillCustomizeModFile.Skill1_CUCC_List[0]);
                                skillCustomizeOriginalFile.Skill2_CUCC_List.Add(skillCustomizeModFile.Skill2_CUCC_List[0]);
                                skillCustomizeOriginalFile.Skill3_CUCC_List.Add(skillCustomizeModFile.Skill3_CUCC_List[0]);
                                skillCustomizeOriginalFile.Skill4_CUCC_List.Add(skillCustomizeModFile.Skill4_CUCC_List[0]);
                                skillCustomizeOriginalFile.Skill5_CUCC_List.Add(skillCustomizeModFile.Skill5_CUCC_List[0]);
                                skillCustomizeOriginalFile.Skill6_CUCC_List.Add(skillCustomizeModFile.Skill6_CUCC_List[0]);
                                skillCustomizeOriginalFile.SkillAwa_CUCC_List.Add(skillCustomizeModFile.SkillAwa_CUCC_List[0]);
                                skillCustomizeOriginalFile.Skill1_Priority_List.Add(skillCustomizeModFile.Skill1_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill2_Priority_List.Add(skillCustomizeModFile.Skill2_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill3_Priority_List.Add(skillCustomizeModFile.Skill3_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill4_Priority_List.Add(skillCustomizeModFile.Skill4_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill5_Priority_List.Add(skillCustomizeModFile.Skill5_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill6_Priority_List.Add(skillCustomizeModFile.Skill6_Priority_List[0]);
                                skillCustomizeOriginalFile.SkillAwa_Priority_List.Add(skillCustomizeModFile.SkillAwa_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill1ex_Priority_List.Add(skillCustomizeModFile.Skill1ex_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill2ex_Priority_List.Add(skillCustomizeModFile.Skill2ex_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill3ex_Priority_List.Add(skillCustomizeModFile.Skill3ex_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill4ex_Priority_List.Add(skillCustomizeModFile.Skill4ex_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill5ex_Priority_List.Add(skillCustomizeModFile.Skill5ex_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill6ex_Priority_List.Add(skillCustomizeModFile.Skill6ex_Priority_List[0]);
                                skillCustomizeOriginalFile.SkillAwaex_Priority_List.Add(skillCustomizeModFile.SkillAwaex_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill1air_Priority_List.Add(skillCustomizeModFile.Skill1air_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill2air_Priority_List.Add(skillCustomizeModFile.Skill2air_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill3air_Priority_List.Add(skillCustomizeModFile.Skill3air_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill4air_Priority_List.Add(skillCustomizeModFile.Skill4air_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill5air_Priority_List.Add(skillCustomizeModFile.Skill5air_Priority_List[0]);
                                skillCustomizeOriginalFile.Skill6air_Priority_List.Add(skillCustomizeModFile.Skill6air_Priority_List[0]);
                                skillCustomizeOriginalFile.SkillAwaair_Priority_List.Add(skillCustomizeModFile.SkillAwaair_Priority_List[0]);
                                skillCustomizeOriginalFile.EntryCount++;
                            }
                            if (!Directory.Exists(Main.datawin32Path + "\\spc\\WIN64")) {
                                Directory.CreateDirectory(Main.datawin32Path + "\\spc\\WIN64");
                            }
                            skillCustomizeOriginalFile.SaveFileAs(Main.datawin32Path + "\\spc\\WIN64\\skillCustomizeParam.xfbin");
                        }
                        if (spskillCustomizeExist) {
                            Tool_SpSkillCustomizeParamEditor spSkillCustomizeModFile = new Tool_SpSkillCustomizeParamEditor();
                            Tool_SpSkillCustomizeParamEditor spSkillCustomizeOriginalFile = new Tool_SpSkillCustomizeParamEditor();
                            spSkillCustomizeModFile.OpenFile(spskillCustomizePath);
                            if (File.Exists(Main.spSkillCustomizePath))
                                spSkillCustomizeOriginalFile.OpenFile(Main.spSkillCustomizePath);
                            else {
                                spSkillCustomizeOriginalFile.OpenFile(originalspSkillCustomizeParamPath);
                            }
                            if (ReplaceCharacterList[i]) {
                                for (int c = 0; c < spSkillCustomizeOriginalFile.EntryCount; c++) {
                                    if (Main.b_byteArrayToInt(spSkillCustomizeOriginalFile.CharacodeList[c]) == Main.b_byteArrayToInt(spSkillCustomizeModFile.CharacodeList[0])) {
                                        spSkillCustomizeOriginalFile.spl1_chUsageCountValueList[c] = spSkillCustomizeModFile.spl1_chUsageCountValueList[0];
                                        spSkillCustomizeOriginalFile.spl2_chUsageCountValueList[c] = spSkillCustomizeModFile.spl2_chUsageCountValueList[0];
                                        spSkillCustomizeOriginalFile.spl3_chUsageCountValueList[c] = spSkillCustomizeModFile.spl3_chUsageCountValueList[0];
                                        spSkillCustomizeOriginalFile.spl4_chUsageCountValueList[c] = spSkillCustomizeModFile.spl4_chUsageCountValueList[0];
                                        spSkillCustomizeOriginalFile.spl1_chUsageCountValueListFloat[c] = spSkillCustomizeModFile.spl1_chUsageCountValueListFloat[0];
                                        spSkillCustomizeOriginalFile.spl2_chUsageCountValueListFloat[c] = spSkillCustomizeModFile.spl2_chUsageCountValueListFloat[0];
                                        spSkillCustomizeOriginalFile.spl3_chUsageCountValueListFloat[c] = spSkillCustomizeModFile.spl3_chUsageCountValueListFloat[0];
                                        spSkillCustomizeOriginalFile.spl4_chUsageCountValueListFloat[c] = spSkillCustomizeModFile.spl4_chUsageCountValueListFloat[0];
                                        spSkillCustomizeOriginalFile.spl1_NameList[c] = spSkillCustomizeModFile.spl1_NameList[0];
                                        spSkillCustomizeOriginalFile.spl2_NameList[c] = spSkillCustomizeModFile.spl2_NameList[0];
                                        spSkillCustomizeOriginalFile.spl3_NameList[c] = spSkillCustomizeModFile.spl3_NameList[0];
                                        spSkillCustomizeOriginalFile.spl4_NameList[c] = spSkillCustomizeModFile.spl4_NameList[0];
                                        spSkillCustomizeOriginalFile.spl1_PriorList[c] = spSkillCustomizeModFile.spl1_PriorList[0];
                                        spSkillCustomizeOriginalFile.spl2_PriorList[c] = spSkillCustomizeModFile.spl2_PriorList[0];
                                        spSkillCustomizeOriginalFile.spl3_PriorList[c] = spSkillCustomizeModFile.spl3_PriorList[0];
                                        spSkillCustomizeOriginalFile.spl4_PriorList[c] = spSkillCustomizeModFile.spl4_PriorList[0];
                                        spSkillCustomizeOriginalFile.WeirdValuesList[c] = spSkillCustomizeModFile.WeirdValuesList[0];
                                    }
                                }
                            } else {
                                spSkillCustomizeOriginalFile.CharacodeList.Add(BitConverter.GetBytes(CharacodeID));
                                spSkillCustomizeOriginalFile.spl1_chUsageCountValueList.Add(spSkillCustomizeModFile.spl1_chUsageCountValueList[0]);
                                spSkillCustomizeOriginalFile.spl2_chUsageCountValueList.Add(spSkillCustomizeModFile.spl2_chUsageCountValueList[0]);
                                spSkillCustomizeOriginalFile.spl3_chUsageCountValueList.Add(spSkillCustomizeModFile.spl3_chUsageCountValueList[0]);
                                spSkillCustomizeOriginalFile.spl4_chUsageCountValueList.Add(spSkillCustomizeModFile.spl4_chUsageCountValueList[0]);
                                spSkillCustomizeOriginalFile.spl1_chUsageCountValueListFloat.Add(spSkillCustomizeModFile.spl1_chUsageCountValueListFloat[0]);
                                spSkillCustomizeOriginalFile.spl2_chUsageCountValueListFloat.Add(spSkillCustomizeModFile.spl2_chUsageCountValueListFloat[0]);
                                spSkillCustomizeOriginalFile.spl3_chUsageCountValueListFloat.Add(spSkillCustomizeModFile.spl3_chUsageCountValueListFloat[0]);
                                spSkillCustomizeOriginalFile.spl4_chUsageCountValueListFloat.Add(spSkillCustomizeModFile.spl4_chUsageCountValueListFloat[0]);
                                spSkillCustomizeOriginalFile.spl1_PriorList.Add(spSkillCustomizeModFile.spl1_PriorList[0]);
                                spSkillCustomizeOriginalFile.spl2_PriorList.Add(spSkillCustomizeModFile.spl2_PriorList[0]);
                                spSkillCustomizeOriginalFile.spl3_PriorList.Add(spSkillCustomizeModFile.spl3_PriorList[0]);
                                spSkillCustomizeOriginalFile.spl4_PriorList.Add(spSkillCustomizeModFile.spl4_PriorList[0]);
                                spSkillCustomizeOriginalFile.spl1_NameList.Add(spSkillCustomizeModFile.spl1_NameList[0]);
                                spSkillCustomizeOriginalFile.spl2_NameList.Add(spSkillCustomizeModFile.spl2_NameList[0]);
                                spSkillCustomizeOriginalFile.spl3_NameList.Add(spSkillCustomizeModFile.spl3_NameList[0]);
                                spSkillCustomizeOriginalFile.spl4_NameList.Add(spSkillCustomizeModFile.spl4_NameList[0]);
                                spSkillCustomizeOriginalFile.WeirdValuesList.Add(spSkillCustomizeModFile.WeirdValuesList[0]);
                                spSkillCustomizeOriginalFile.EntryCount++;
                            }
                            if (!Directory.Exists(Main.datawin32Path + "\\spc\\WIN64")) {
                                Directory.CreateDirectory(Main.datawin32Path + "\\spc\\WIN64");
                            }
                            spSkillCustomizeOriginalFile.SaveFileAs(Main.datawin32Path + "\\spc\\WIN64\\spSkillCustomizeParam.xfbin");
                        }
                        if (awakeAuraExist) {
                            Tool_AwakeAuraEditor awakeAuraModFile = new Tool_AwakeAuraEditor();
                            Tool_AwakeAuraEditor awakeAuraOriginalFile = new Tool_AwakeAuraEditor();
                            awakeAuraModFile.OpenFile(awakeAuraPath);
                            if (File.Exists(Main.awakeAuraPath))
                                awakeAuraOriginalFile.OpenFile(Main.awakeAuraPath);
                            else {
                                awakeAuraOriginalFile.OpenFile(originalawakeAuraPath);
                            }
                            for (int c = 0; c < awakeAuraOriginalFile.EntryCount; c++) {
                                if (awakeAuraOriginalFile.CharacodeList[c] == d.Name) {
                                    awakeAuraOriginalFile.CharacodeList.RemoveAt(c);
                                    awakeAuraOriginalFile.SkillFileList.RemoveAt(c);
                                    awakeAuraOriginalFile.EffectList.RemoveAt(c);
                                    awakeAuraOriginalFile.MainBoneList.RemoveAt(c);
                                    awakeAuraOriginalFile.SecondBoneList.RemoveAt(c);
                                    awakeAuraOriginalFile.AwakeModeValue_false_List.RemoveAt(c);
                                    awakeAuraOriginalFile.AwakeModeValue_true_List.RemoveAt(c);
                                    awakeAuraOriginalFile.SecondBoneValue_1_List.RemoveAt(c);
                                    awakeAuraOriginalFile.SecondBoneValue_2_List.RemoveAt(c);
                                    awakeAuraOriginalFile.SecondBoneValue_3_List.RemoveAt(c);
                                    awakeAuraOriginalFile.ConstantValue_List.RemoveAt(c);
                                    awakeAuraOriginalFile.EntryCount--;
                                    c--;
                                }
                            }
                            for (int c = 0; c < awakeAuraModFile.EntryCount; c++) {
                                if (awakeAuraModFile.CharacodeList[c] == d.Name) {
                                    awakeAuraOriginalFile.CharacodeList.Add(awakeAuraModFile.CharacodeList[c]);
                                    awakeAuraOriginalFile.SkillFileList.Add(awakeAuraModFile.SkillFileList[c]);
                                    awakeAuraOriginalFile.EffectList.Add(awakeAuraModFile.EffectList[c]);
                                    awakeAuraOriginalFile.MainBoneList.Add(awakeAuraModFile.MainBoneList[c]);
                                    awakeAuraOriginalFile.SecondBoneList.Add(awakeAuraModFile.SecondBoneList[c]);
                                    awakeAuraOriginalFile.AwakeModeValue_false_List.Add(awakeAuraModFile.AwakeModeValue_false_List[c]);
                                    awakeAuraOriginalFile.AwakeModeValue_true_List.Add(awakeAuraModFile.AwakeModeValue_true_List[c]);
                                    awakeAuraOriginalFile.SecondBoneValue_1_List.Add(awakeAuraModFile.SecondBoneValue_1_List[c]);
                                    awakeAuraOriginalFile.SecondBoneValue_2_List.Add(awakeAuraModFile.SecondBoneValue_2_List[c]);
                                    awakeAuraOriginalFile.SecondBoneValue_3_List.Add(awakeAuraModFile.SecondBoneValue_3_List[c]);
                                    awakeAuraOriginalFile.ConstantValue_List.Add(awakeAuraModFile.ConstantValue_List[c]);
                                    awakeAuraOriginalFile.EntryCount++;
                                }

                            }
                            if (!Directory.Exists(Main.datawin32Path + "\\spc\\WIN64")) {
                                Directory.CreateDirectory(Main.datawin32Path + "\\spc\\WIN64");
                            }
                            awakeAuraOriginalFile.SaveFileAs(Main.datawin32Path + "\\spc\\WIN64\\awakeAura.xfbin");
                        }
                        if (iconExist) {
                            Tool_IconEditor IconModFile = new Tool_IconEditor();
                            Tool_IconEditor IconOriginalFile = new Tool_IconEditor();
                            IconModFile.OpenFile(iconPath);
                            if (File.Exists(Main.iconPath))
                                IconOriginalFile.OpenFile(Main.iconPath);
                            else {
                                IconOriginalFile.OpenFile(originalIconPath);
                            }
                            for (int c = 0; c < IconOriginalFile.EntryCount; c++) {
                                if (Main.b_byteArrayToInt(IconOriginalFile.CharacodeList[c]) == CharacodeID) {
                                    IconOriginalFile.CharacodeList.RemoveAt(c);
                                    IconOriginalFile.CostumeList.RemoveAt(c);
                                    IconOriginalFile.IconList.RemoveAt(c);
                                    IconOriginalFile.AwaIconList.RemoveAt(c);
                                    IconOriginalFile.NameList.RemoveAt(c);
                                    IconOriginalFile.ExNinjutsuList.RemoveAt(c);
                                    IconOriginalFile.EntryCount--;
                                    c--;
                                }
                            }
                            for (int c = 0; c < IconModFile.EntryCount; c++) {
                                if (Main.b_byteArrayToInt(IconModFile.CharacodeList[c]) == OldCharacode) {
                                    IconOriginalFile.CharacodeList.Add(BitConverter.GetBytes(CharacodeID));
                                    IconOriginalFile.CostumeList.Add(IconModFile.CostumeList[c]);
                                    IconOriginalFile.IconList.Add(IconModFile.IconList[c]);
                                    IconOriginalFile.AwaIconList.Add(IconModFile.AwaIconList[c]);
                                    IconOriginalFile.NameList.Add(IconModFile.NameList[c]);
                                    IconOriginalFile.ExNinjutsuList.Add(IconModFile.ExNinjutsuList[c]);
                                    IconOriginalFile.EntryCount++;
                                }

                            }
                            if (!Directory.Exists(Main.datawin32Path + "\\spc\\WIN64")) {
                                Directory.CreateDirectory(Main.datawin32Path + "\\spc\\WIN64");
                            }
                            IconOriginalFile.SaveFileAs(Main.datawin32Path + "\\spc\\WIN64\\player_icon.xfbin");
                        }
                        if (appearanceAnmExist) {
                            Tool_appearenceAnmEditor AppearanceModFile = new Tool_appearenceAnmEditor();
                            Tool_appearenceAnmEditor AppearanceOriginalFile = new Tool_appearenceAnmEditor();
                            AppearanceModFile.OpenFile(appearanceAnmPath);
                            if (File.Exists(Main.appearanceAnmPath))
                                AppearanceOriginalFile.OpenFile(Main.appearanceAnmPath);
                            else {
                                AppearanceOriginalFile.OpenFile(originalappearanceAnmPath);
                            }
                            for (int c = 0; c < AppearanceOriginalFile.EntryCount; c++) {
                                if (Main.b_byteArrayToInt(AppearanceOriginalFile.CharacodeList[c]) == CharacodeID) {
                                    AppearanceOriginalFile.CharacodeList.RemoveAt(c);
                                    AppearanceOriginalFile.MeshList.RemoveAt(c);
                                    AppearanceOriginalFile.SlotList.RemoveAt(c);
                                    AppearanceOriginalFile.TypeSectionList.RemoveAt(c);
                                    AppearanceOriginalFile.EnableDisableList.RemoveAt(c);
                                    AppearanceOriginalFile.NormalStateList.RemoveAt(c);
                                    AppearanceOriginalFile.AwakeningStateList.RemoveAt(c);
                                    AppearanceOriginalFile.ReverseSectionList.RemoveAt(c);
                                    AppearanceOriginalFile.EnableDisableCutNCList.RemoveAt(c);
                                    AppearanceOriginalFile.EnableDisableUltList.RemoveAt(c);
                                    AppearanceOriginalFile.EnableDisableWinList.RemoveAt(c);
                                    AppearanceOriginalFile.EnableDisableArmorBreakList.RemoveAt(c);
                                    AppearanceOriginalFile.TimingAwakeList.RemoveAt(c);
                                    AppearanceOriginalFile.TransparenceList.RemoveAt(c);
                                    AppearanceOriginalFile.EntryCount--;
                                    c--;
                                }
                            }
                            for (int c = 0; c < AppearanceModFile.EntryCount; c++) {
                                if (Main.b_byteArrayToInt(AppearanceModFile.CharacodeList[c]) == OldCharacode) {
                                    AppearanceOriginalFile.CharacodeList.Add(BitConverter.GetBytes(CharacodeID));
                                    AppearanceOriginalFile.MeshList.Add(AppearanceModFile.MeshList[c]);
                                    AppearanceOriginalFile.SlotList.Add(AppearanceModFile.SlotList[c]);
                                    AppearanceOriginalFile.TypeSectionList.Add(AppearanceModFile.TypeSectionList[c]);
                                    AppearanceOriginalFile.EnableDisableList.Add(AppearanceModFile.EnableDisableList[c]);
                                    AppearanceOriginalFile.NormalStateList.Add(AppearanceModFile.NormalStateList[c]);
                                    AppearanceOriginalFile.AwakeningStateList.Add(AppearanceModFile.AwakeningStateList[c]);
                                    AppearanceOriginalFile.ReverseSectionList.Add(AppearanceModFile.ReverseSectionList[c]);
                                    AppearanceOriginalFile.EnableDisableCutNCList.Add(AppearanceModFile.EnableDisableCutNCList[c]);
                                    AppearanceOriginalFile.EnableDisableUltList.Add(AppearanceModFile.EnableDisableUltList[c]);
                                    AppearanceOriginalFile.EnableDisableWinList.Add(AppearanceModFile.EnableDisableWinList[c]);
                                    AppearanceOriginalFile.EnableDisableArmorBreakList.Add(AppearanceModFile.EnableDisableArmorBreakList[c]);
                                    AppearanceOriginalFile.TimingAwakeList.Add(AppearanceModFile.TimingAwakeList[c]);
                                    AppearanceOriginalFile.TransparenceList.Add(AppearanceModFile.TransparenceList[c]);
                                    AppearanceOriginalFile.EntryCount++;
                                }

                            }
                            if (!Directory.Exists(Main.datawin32Path + "\\spc\\WIN64")) {
                                Directory.CreateDirectory(Main.datawin32Path + "\\spc\\WIN64");
                            }
                            AppearanceOriginalFile.SaveFileAs(Main.datawin32Path + "\\spc\\WIN64\\appearanceAnm.xfbin");
                        }
                        if (afterAttachObjectExist) {
                            Tool_afterAttachObject afterAttachObjectModFile = new Tool_afterAttachObject();
                            Tool_afterAttachObject afterAttachObjectOriginalFile = new Tool_afterAttachObject();
                            afterAttachObjectModFile.OpenFile(afterAttachObjectPath);
                            if (File.Exists(Main.afterAttachObjectPath))
                                afterAttachObjectOriginalFile.OpenFile(Main.afterAttachObjectPath);
                            else {
                                afterAttachObjectOriginalFile.OpenFile(originalafterAttachObjectPath);
                            }
                            for (int c = 0; c < afterAttachObjectOriginalFile.EntryCount; c++) {
                                if (afterAttachObjectOriginalFile.characode1List[c] == d.Name) {
                                    afterAttachObjectOriginalFile.characode1List.RemoveAt(c);
                                    afterAttachObjectOriginalFile.characode2List.RemoveAt(c);
                                    afterAttachObjectOriginalFile.pathList.RemoveAt(c);
                                    afterAttachObjectOriginalFile.meshList.RemoveAt(c);
                                    afterAttachObjectOriginalFile.bone1List.RemoveAt(c);
                                    afterAttachObjectOriginalFile.bone2List.RemoveAt(c);
                                    afterAttachObjectOriginalFile.value1List.RemoveAt(c);
                                    afterAttachObjectOriginalFile.value2List.RemoveAt(c);
                                    afterAttachObjectOriginalFile.value3List.RemoveAt(c);
                                    afterAttachObjectOriginalFile.XPosList.RemoveAt(c);
                                    afterAttachObjectOriginalFile.YPosList.RemoveAt(c);
                                    afterAttachObjectOriginalFile.ZPosList.RemoveAt(c);
                                    afterAttachObjectOriginalFile.XRotList.RemoveAt(c);
                                    afterAttachObjectOriginalFile.YRotList.RemoveAt(c);
                                    afterAttachObjectOriginalFile.ZRotList.RemoveAt(c);
                                    afterAttachObjectOriginalFile.XScaleList.RemoveAt(c);
                                    afterAttachObjectOriginalFile.YScaleList.RemoveAt(c);
                                    afterAttachObjectOriginalFile.ZScaleList.RemoveAt(c);
                                    afterAttachObjectOriginalFile.EntryCount--;
                                    c--;
                                }
                            }
                            for (int c = 0; c < afterAttachObjectModFile.EntryCount; c++) {
                                if (afterAttachObjectModFile.characode1List[c] == d.Name) {
                                    afterAttachObjectOriginalFile.characode1List.Add(afterAttachObjectModFile.characode1List[c]);
                                    afterAttachObjectOriginalFile.characode2List.Add(afterAttachObjectModFile.characode2List[c]);
                                    afterAttachObjectOriginalFile.pathList.Add(afterAttachObjectModFile.pathList[c]);
                                    afterAttachObjectOriginalFile.meshList.Add(afterAttachObjectModFile.meshList[c]);
                                    afterAttachObjectOriginalFile.bone1List.Add(afterAttachObjectModFile.bone1List[c]);
                                    afterAttachObjectOriginalFile.bone2List.Add(afterAttachObjectModFile.bone2List[c]);
                                    afterAttachObjectOriginalFile.value1List.Add(afterAttachObjectModFile.value1List[c]);
                                    afterAttachObjectOriginalFile.value2List.Add(afterAttachObjectModFile.value2List[c]);
                                    afterAttachObjectOriginalFile.value3List.Add(afterAttachObjectModFile.value3List[c]);
                                    afterAttachObjectOriginalFile.XPosList.Add(afterAttachObjectModFile.XPosList[c]);
                                    afterAttachObjectOriginalFile.YPosList.Add(afterAttachObjectModFile.YPosList[c]);
                                    afterAttachObjectOriginalFile.ZPosList.Add(afterAttachObjectModFile.ZPosList[c]);
                                    afterAttachObjectOriginalFile.XRotList.Add(afterAttachObjectModFile.XRotList[c]);
                                    afterAttachObjectOriginalFile.YRotList.Add(afterAttachObjectModFile.YRotList[c]);
                                    afterAttachObjectOriginalFile.ZRotList.Add(afterAttachObjectModFile.ZRotList[c]);
                                    afterAttachObjectOriginalFile.XScaleList.Add(afterAttachObjectModFile.XScaleList[c]);
                                    afterAttachObjectOriginalFile.YScaleList.Add(afterAttachObjectModFile.YScaleList[c]);
                                    afterAttachObjectOriginalFile.ZScaleList.Add(afterAttachObjectModFile.ZScaleList[c]);
                                    afterAttachObjectOriginalFile.EntryCount++;
                                }

                            }
                            if (!Directory.Exists(Main.datawin32Path + "\\spc\\WIN64")) {
                                Directory.CreateDirectory(Main.datawin32Path + "\\spc\\WIN64");
                            }
                            afterAttachObjectOriginalFile.SaveFileAs(Main.datawin32Path + "\\spc\\WIN64\\afterAttachObject.xfbin");
                        }
                        string root_path = Main.datawin32Path.Replace(d_or.Name, "");
                        if (specialCondParamExist) {
                            CopyFiles(root_path + "\\moddingapi\\mods\\" + d.Name, specialCondParamPath, root_path + "\\moddingapi\\mods\\" + d.Name + "\\specialCondParam.xfbin");
                            byte[] specialCondParamFile = File.ReadAllBytes(root_path + "\\moddingapi\\mods\\" + d.Name + "\\specialCondParam.xfbin");
                            specialCondParamFile = Main.b_ReplaceBytes(specialCondParamFile, BitConverter.GetBytes(CharacodeID), 0x17);
                            File.WriteAllBytes(root_path + "\\moddingapi\\mods\\" + d.Name + "\\specialCondParam.xfbin", specialCondParamFile);

                        }
                        if (partnerSlotParamExist) {
                            CopyFiles(root_path + "\\moddingapi\\mods\\" + d.Name, partnerSlotParamPath, root_path + "\\moddingapi\\mods\\" + d.Name + "\\partnerSlotParam.xfbin");
                            byte[] partnerSlotParamFile = File.ReadAllBytes(root_path + "\\moddingapi\\mods\\" + d.Name + "\\partnerSlotParam.xfbin");
                            partnerSlotParamFile = Main.b_ReplaceBytes(partnerSlotParamFile, BitConverter.GetBytes(CharacodeID), 0x17);
                            File.WriteAllBytes(root_path + "\\moddingapi\\mods\\" + d.Name + "\\partnerSlotParam.xfbin", partnerSlotParamFile);
                        }
                        if (specialCondParamExist || specialCondParamExist) {
                            FileStream ffParameter = new FileStream(root_path + "\\moddingapi\\mods\\" + d.Name + "\\info.txt", FileMode.Create, FileAccess.Write);
                            StreamWriter mm_WriterParameter = new StreamWriter(ffParameter);
                            mm_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
                            mm_WriterParameter.Write("Exported character " + d.Name + "| |Unknown");
                            mm_WriterParameter.Flush();
                            mm_WriterParameter.Close();
                        }
                        foreach (FileInfo file in Files) {
                            if (!file.Name.Contains("duelPlayerParam") && !file.Name.Contains("awakeAura") && !file.Name.Contains("appearanceAnm") && !file.Name.Contains("afterAttachObject") && !file.Name.Contains("characterSelectParam") && !file.Name.Contains("playerSettingParam") && !file.Name.Contains("skillCustomizeParam") && !file.Name.Contains("spSkillCustomizeParam") && !file.Name.Contains("player_icon")) {
                                if (!file.FullName.Contains("moddingapi"))
                                    CopyFiles(Path.GetDirectoryName(Main.datawin32Path + "\\" + file.FullName.Substring(file.FullName.IndexOf(dataWinFolder) + dataWinFolderLength)), file.FullName, Main.datawin32Path + "\\" + file.FullName.Substring(file.FullName.IndexOf(dataWinFolder) + dataWinFolderLength));
                            }
                        }


                        DirectoryInfo backup_d = new DirectoryInfo(Main.datawin32Path);
                        FileInfo[] backup_Files = backup_d.GetFiles("*.backup", SearchOption.AllDirectories);
                        foreach (FileInfo file in backup_Files) {
                            file.Delete();
                        
                        }

                    } else {
                        MessageBox.Show(d.Name + " doesnt has characode file. Unable to import");
                    }
                    
                }
            }
            MessageBox.Show("Finished exporting.");
        }

        private void Tool_ImportCharacter_FormClosed(object sender, FormClosedEventArgs e) {
            Main.LoadConfig();
        }
    }
}