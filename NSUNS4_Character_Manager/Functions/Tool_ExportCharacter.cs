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
    public partial class Tool_ExportCharacter : Form {
        public Tool_ExportCharacter() {
            InitializeComponent();
        }
        public string SaveDirectory = "";
        public string SaveCharacode = "";
        
        private void Tool_ExportCharacter_Load(object sender, EventArgs e) {
            // Open Characode
            Tool_CharacodeEditor CharacodeFile = new Tool_CharacodeEditor();
            if (File.Exists(Main.chaPath))
                CharacodeFile.OpenFile(Main.chaPath);
            else
                CharacodeFile.OpenFile(Directory.GetCurrentDirectory() + "\\systemFiles\\characode.bin.xfbin");
            for (int x = 0; x< CharacodeFile.CharacterCount; x++) {
                listBox1.Items.Add(CharacodeFile.CharacterList[x]);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            Tool_CharacodeEditor CharacodeFile = new Tool_CharacodeEditor();
            CharacodeFile.OpenFile(Directory.GetCurrentDirectory() + "\\systemFiles\\characode.bin.xfbin");
            if (x!=-1) {
                bool contain = false;
                if (CharacodeFile.CharacterList.Contains(listBox1.Items[x].ToString())) {
                    contain = true;
                }
                if (!contain) {
                    if (File.Exists(Main.chaPath) && File.Exists(Main.dppPath) && File.Exists(Main.pspPath) && File.Exists(Main.skillCustomizePath) && File.Exists(Main.spSkillCustomizePath)) {
                        SaveCharacode = listBox1.Items[x].ToString();
                        ExportCharacter(x + 1);
                    } else {
                        MessageBox.Show("Unable to export, this character isnt exist in current game, it requires characode, playerSettingParam, characterSelectParam, duelPlayerParam, skillCustomizeParam and spSkillCustomizeParam files.");
                    }
                }
                else {
                    SaveCharacode = listBox1.Items[x].ToString();
                    ExportCharacter(x + 1);
                }
            }
        }

        public void ExportCharacter(int CharacodeID) {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog();
            SaveDirectory = f.SelectedPath+"\\"+ SaveCharacode + "\\data_win32";
            Directory.CreateDirectory(SaveDirectory);

            DirectoryInfo d = new DirectoryInfo(Main.datawin32Path);
            string dataWinFolder = d.Name + "\\";
            int dataWinFolderLength = dataWinFolder.Length;
            FileInfo[] Files = d.GetFiles("*.xfbin", SearchOption.AllDirectories);



            DirectoryInfo icon_d = new DirectoryInfo(Main.datawin32Path+"\\ui\\flash\\OTHER\\");
            FileInfo[] icon_Files = icon_d.GetFiles("*.xfbin", SearchOption.AllDirectories);
            bool prmExist = false;
            bool prmLoadExist = false;
            bool dppExist = false;
            bool pspExist = false;
            bool cspExist = false;
            bool skillCustomizeExist = false;
            bool spskillCustomizeExist = false;
            bool iconExist = false;
            bool awakeAuraExist = false;
            bool appearanceAnmExist = false;
            bool afterAttachObjectExist = false;
            bool cmnparamExist = false;
            bool damageeffExist = false;
            bool effectprmExist = false;
            string prmPath = "";
            string prmLoadPath = "";
            string dppPath = "";
            string cspPath = "";
            string pspPath = "";
            string skillCustomizePath = "";
            string spskillCustomizePath = "";
            string awakeAuraPath = "";
            string iconPath = "";
            string appearanceAnmPath = "";
            string afterAttachObjectPath = "";
            string cmnparamPath = "";
            string damageeffPath = "";
            string effectprmPath = "";
            string moddingAPIPath = Main.datawin32Path.Replace(d.Name, "moddingapi\\mods");

            

            foreach (FileInfo file in Files) {
                if (file.FullName.Contains("spcload\\" + SaveCharacode + "prm_load.bin.xfbin")) {
                    prmLoadExist = true;
                    prmLoadPath = file.FullName;
                    break;
                } 
                else {
                    prmLoadExist = false;
                    prmLoadPath = "";
                }
            }
            foreach (FileInfo file in Files) {
                if (file.FullName.Contains(SaveCharacode + "prm.bin.xfbin")) {
                    prmExist = true;
                    prmPath = file.FullName;
                    break;
                } else {
                    prmExist = false;
                    prmPath = "";
                }
            }
            foreach (FileInfo file in Files) {
                if (file.FullName.Contains("spcload\\" + SaveCharacode + "prm_load.bin.xfbin")) {
                    prmLoadExist = true;
                    prmLoadPath = file.FullName;
                    break;
                } else {
                    prmLoadExist = false;
                    prmLoadPath = "";
                }
            }
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
                if (file.FullName.Contains("spc\\damageeff.bin.xfbin")) {
                    damageeffExist = true;
                    damageeffPath = file.FullName;
                    break;
                } else {
                    damageeffExist = false;
                    damageeffPath = "";
                }
            }
            foreach (FileInfo file in Files) {
                if (file.FullName.Contains("spc\\effectprm.bin.xfbin")) {
                    effectprmExist = true;
                    effectprmPath = file.FullName;
                    break;
                } else {
                    effectprmExist = false;
                    effectprmPath = "";
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
                if (file.FullName.Contains("sound\\cmnparam.xfbin")) {
                    cmnparamExist = true;
                    cmnparamPath = file.FullName;
                    break;
                } else {
                    cmnparamExist = false;
                    cmnparamPath = "";
                }
            }
            if (prmExist) {
                Tool_MovesetCoder PrmFile = new Tool_MovesetCoder();
                PrmFile.OpenFile(prmPath);
                if (damageeffExist) {
                    Tool_damageeffEditor damageEffOriginalFile = new Tool_damageeffEditor();
                    damageEffOriginalFile.OpenFile(Directory.GetCurrentDirectory() + "\\systemFiles\\damageeff.bin.xfbin");
                    Tool_damageeffEditor damageEffModFile = new Tool_damageeffEditor();
                    damageEffModFile.OpenFile(damageeffPath);
                    List<int> HitId_List = new List<int>();
                    List<int> ExtraHitId_List = new List<int>();
                    List<int> ExtraSoundId_List = new List<int>();
                    List<int> EffectPrmId_List = new List<int>();
                    List<int> SoundId_List = new List<int>();
                    List<int> Unknown1_List = new List<int>();
                    List<int> Unknown2_List = new List<int>();
                    List<int> ExtraEffectPrmId_List = new List<int>();
                    for (int k1 = 0; k1 < PrmFile.movementList.Count; k1++) {
                        for (int k2 = 0; k2 < PrmFile.movementList[k1].Count; k2++) {
                            for (int k3 = 0; k3 < PrmFile.movementList[k1][k2].Count; k3++) {
                                if (PrmFile.movementList[k1][k2][k3].Length > 0x40) {
                                    int selectedhit = Main.b_ReadIntFromTwoBytes(PrmFile.movementList[k1][k2][k3], 0x82);
                                    if (!damageEffOriginalFile.HitId_List.Contains(selectedhit)) {
                                        for (int c = 0; c < damageEffModFile.EntryCount; c++) {
                                            if (damageEffModFile.HitId_List[c] == selectedhit && !HitId_List.Contains(selectedhit)) {
                                                HitId_List.Add(damageEffModFile.HitId_List[c]);
                                                ExtraHitId_List.Add(damageEffModFile.ExtraHitId_List[c]);
                                                ExtraSoundId_List.Add(damageEffModFile.ExtraSoundId_List[c]);
                                                EffectPrmId_List.Add(damageEffModFile.EffectPrmId_List[c]);
                                                SoundId_List.Add(damageEffModFile.SoundId_List[c]);
                                                Unknown1_List.Add(damageEffModFile.Unknown1_List[c]);
                                                Unknown2_List.Add(damageEffModFile.Unknown2_List[c]);
                                                ExtraEffectPrmId_List.Add(damageEffModFile.ExtraEffectPrmId_List[c]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    damageEffModFile.HitId_List = HitId_List;
                    damageEffModFile.ExtraHitId_List = ExtraHitId_List;
                    damageEffModFile.ExtraSoundId_List = ExtraSoundId_List;
                    damageEffModFile.EffectPrmId_List = EffectPrmId_List;
                    damageEffModFile.SoundId_List = SoundId_List;
                    damageEffModFile.Unknown1_List = Unknown1_List;
                    damageEffModFile.Unknown2_List = Unknown2_List;
                    damageEffModFile.ExtraEffectPrmId_List = ExtraEffectPrmId_List;
                    damageEffModFile.EntryCount = HitId_List.Count;
                    if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\spc\\"))) {
                        Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\spc\\"));
                    }
                    damageEffModFile.SaveFileAs(SaveDirectory + "\\spc\\damageeff.bin.xfbin");
                    if (effectprmExist) {
                        List<int> EffectPrmID_List = new List<int>();
                        List<int> EffectPrmType_List = new List<int>();
                        List<string> EffectPrmPath_List = new List<string>();
                        List<string> EffectPrmAnm_List = new List<string>();
                        Tool_effectprmEditor EffectPrmModFile = new Tool_effectprmEditor();
                        EffectPrmModFile.OpenFile(effectprmPath);

                        for (int c = 0; c < EffectPrmModFile.EntryCount; c++) {
                            for (int j = 0; j < damageEffModFile.EntryCount; j++) {
                                if (damageEffModFile.EffectPrmId_List[j] == EffectPrmModFile.EffectPrmID_List[c] && !EffectPrmID_List.Contains(damageEffModFile.EffectPrmId_List[j])) {
                                    EffectPrmID_List.Add(EffectPrmModFile.EffectPrmID_List[c]);
                                    EffectPrmType_List.Add(EffectPrmModFile.EffectPrmType_List[c]);
                                    EffectPrmPath_List.Add(EffectPrmModFile.EffectPrmPath_List[c]);
                                    EffectPrmAnm_List.Add(EffectPrmModFile.EffectPrmAnm_List[c]);
                                }
                            }

                        }
                        EffectPrmModFile.EffectPrmID_List = EffectPrmID_List;
                        EffectPrmModFile.EffectPrmType_List = EffectPrmType_List;
                        EffectPrmModFile.EffectPrmPath_List = EffectPrmPath_List;
                        EffectPrmModFile.EffectPrmAnm_List = EffectPrmAnm_List;
                        EffectPrmModFile.EntryCount = EffectPrmID_List.Count;
                        if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\spc\\"))) {
                            Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\spc\\"));
                        }
                        EffectPrmModFile.SaveFileAs(SaveDirectory + "\\spc\\effectprm.bin.xfbin");
                    }
                }

            }
            if (prmLoadExist) {
                Tool_SpcloadEditor SpcloadFile = new Tool_SpcloadEditor();
                SpcloadFile.OpenFile(prmLoadPath);
                for (int i = 0; i< SpcloadFile.entryCount; i++) {
                    string name = SpcloadFile.nameList[i];
                    List<string> names = new List<string>();
                    if (SpcloadFile.nameList[i].Contains("<code>"))
                        name = SpcloadFile.nameList[i].Replace("<code>", SaveCharacode);
                    else if (SpcloadFile.nameList[i].Contains("<codeMotion>"))
                        name = SpcloadFile.nameList[i].Replace("<codeMotion>", SaveCharacode);
                    else if (SpcloadFile.nameList[i].Contains("<codeAwakeModel>")) {
                        Tool_DuelPlayerParamEditor DppFile = new Tool_DuelPlayerParamEditor();
                        DppFile.OpenFile(Main.dppPath);
                        int dppIndex = 0;
                        for (int x = 0; x<DppFile.EntryCount; x++) {
                            if (DppFile.BinName[x].Contains(SaveCharacode)) {
                                dppIndex = x;
                                break;
                            }
                        }
                        for (int x =0; x< DppFile.AwkCostumeList[dppIndex].Length; x++) {
                            name = SpcloadFile.nameList[i].Replace("<codeAwakeModel>", DppFile.AwkCostumeList[dppIndex][x]);
                            names.Add(name);
                        }
                        
                    } 
                    else if (SpcloadFile.nameList[i].Contains("<codeAwake>")) {
                        Tool_DuelPlayerParamEditor DppFile = new Tool_DuelPlayerParamEditor();
                        DppFile.OpenFile(Main.dppPath);
                        int dppIndex = 0;
                        for (int x = 0; x < DppFile.EntryCount; x++) {
                            if (DppFile.BinName[x].Contains(SaveCharacode)) {
                                dppIndex = x;
                                break;
                            }
                        }
                        name = SpcloadFile.nameList[i].Replace("<codeAwake>", DppFile.AwkCostumeList[dppIndex][0]);

                    } 
                    else if (SpcloadFile.nameList[i].Contains("<codeAwake2>")) {
                        Tool_DuelPlayerParamEditor DppFile = new Tool_DuelPlayerParamEditor();
                        DppFile.OpenFile(Main.dppPath);
                        int dppIndex = 0;
                        for (int x = 0; x < DppFile.EntryCount; x++) {
                            if (DppFile.BinName[x].Contains(SaveCharacode)) {
                                dppIndex = x;
                                break;
                            }
                        }
                        name = SpcloadFile.nameList[i].Replace("<codeAwake2>", DppFile.AwkCostumeList[dppIndex][0]);

                    } 
                    else if (SpcloadFile.nameList[i].Contains("<codeAwake2Model>")) {
                        Tool_DuelPlayerParamEditor DppFile = new Tool_DuelPlayerParamEditor();
                        DppFile.OpenFile(Main.dppPath);
                        int dppIndex = 0;
                        for (int x = 0; x < DppFile.EntryCount; x++) {
                            if (DppFile.BinName[x].Contains(SaveCharacode)) {
                                dppIndex = x;
                                break;
                            }
                        }
                        for (int x = 0; x < DppFile.AwkCostumeList[dppIndex].Length; x++) {
                            name = SpcloadFile.nameList[i].Replace("<codeAwake2Model>", DppFile.AwkCostumeList[dppIndex][x]);
                            names.Add(name);
                        }

                    } 
                    else if (SpcloadFile.nameList[i].Contains("<codeModel>")) {
                        Tool_DuelPlayerParamEditor DppFile = new Tool_DuelPlayerParamEditor();
                        DppFile.OpenFile(Main.dppPath);
                        int dppIndex = 0;
                        for (int x = 0; x < DppFile.EntryCount; x++) {
                            if (DppFile.BinName[x].Contains(SaveCharacode)) {
                                dppIndex = x;
                                break;
                            }
                        }
                        for (int x = 0; x < DppFile.CostumeList[dppIndex].Length; x++) {
                            name = SpcloadFile.nameList[i].Replace("<codeModel>", DppFile.CostumeList[dppIndex][x]);
                            names.Add(name);
                        }

                    }
                    if (names.Count == 0) {
                        if (File.Exists(Main.datawin32Path + "\\" + SpcloadFile.pathList[i] + "\\" + name + ".xfbin"))
                            CopyFiles(SaveDirectory + "\\" + SpcloadFile.pathList[i], Main.datawin32Path + "\\" + SpcloadFile.pathList[i] + "\\" + name + ".xfbin", SaveDirectory + "\\" + SpcloadFile.pathList[i] + "\\" + name + ".xfbin");
                    }
                    else {
                        for (int x = 0; x< names.Count; x++) {
                            if (File.Exists(Main.datawin32Path + "\\" + SpcloadFile.pathList[i] + "\\" + names[x] + ".xfbin"))
                                CopyFiles(SaveDirectory + "\\" + SpcloadFile.pathList[i], Main.datawin32Path + "\\" + SpcloadFile.pathList[i] + "\\" + names[x] + ".xfbin", SaveDirectory + "\\" + SpcloadFile.pathList[i] + "\\" + names[x] + ".xfbin");
                        }
                    }

                }
            }
            if (dppExist) {
                Tool_DuelPlayerParamEditor DppFile = new Tool_DuelPlayerParamEditor();
                DppFile.OpenFile(dppPath);
                for (int i = 0; i < DppFile.EntryCount; i++) {
                    if (!DppFile.BinName[i].Contains(SaveCharacode)) {
                        DppFile.BinPath.RemoveAt(i);
                        DppFile.BinName.RemoveAt(i);
                        DppFile.Data.RemoveAt(i);
                        DppFile.CharaList.RemoveAt(i);
                        DppFile.CostumeList.RemoveAt(i);
                        DppFile.AwkCostumeList.RemoveAt(i);
                        DppFile.DefaultAssist1.RemoveAt(i);
                        DppFile.DefaultAssist2.RemoveAt(i);
                        DppFile.AwkAction.RemoveAt(i);
                        DppFile.ItemList.RemoveAt(i);
                        DppFile.ItemCount.RemoveAt(i);
                        DppFile.Partner.RemoveAt(i);
                        DppFile.SettingList.RemoveAt(i);
                        DppFile.Setting2List.RemoveAt(i);
                        DppFile.EnableAwaSkillList.RemoveAt(i);
                        DppFile.VictoryAngleList.RemoveAt(i);
                        DppFile.VictoryPosList.RemoveAt(i);
                        DppFile.VictoryUnknownList.RemoveAt(i);
                        DppFile.AwaSettingList.RemoveAt(i);
                        i--;
                        DppFile.EntryCount--;
                    }
                        
                }
                if (DppFile.EntryCount != 0) {
                    if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\spc\\"))) {
                        Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\spc\\"));
                    }
                    DppFile.SaveFileAs(SaveDirectory + "\\spc\\duelPlayerParam.xfbin");
                    
                }
            }
            if (pspExist) {
                Tool_PlayerSettingParamEditor PspFile = new Tool_PlayerSettingParamEditor();
                PspFile.OpenFile(pspPath);
                for (int i = 0; i < PspFile.EntryCount; i++) {
                    if (Main.b_byteArrayToInt(PspFile.CharacodeList[i]) != CharacodeID) {
                        PspFile.PresetList.RemoveAt(i);
                        PspFile.CharacodeList.RemoveAt(i);
                        PspFile.OptValueA.RemoveAt(i);
                        PspFile.CharacterList.RemoveAt(i);
                        PspFile.OptValueB.RemoveAt(i);
                        PspFile.OptValueC.RemoveAt(i);
                        PspFile.c_cha_a_List.RemoveAt(i);
                        PspFile.c_cha_b_List.RemoveAt(i);
                        PspFile.OptValueD.RemoveAt(i);
                        PspFile.OptValueE.RemoveAt(i);
                        i--;
                        PspFile.EntryCount--;
                    }

                }
                if (PspFile.EntryCount != 0) {
                    if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64\\"))) {
                        Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64\\"));
                    }
                    PspFile.SaveFileAs(SaveDirectory + "\\spc\\WIN64\\playerSettingParam.bin.xfbin");
                }
                
            }
            if (cspExist) {
                Tool_RosterEditor CspFile = new Tool_RosterEditor();
                Tool_PlayerSettingParamEditor PspFile = new Tool_PlayerSettingParamEditor();
                CspFile.OpenFile(cspPath);
                if (pspExist)
                    PspFile.OpenFile(SaveDirectory + "\\spc\\WIN64\\playerSettingParam.bin.xfbin");
                else
                    PspFile.OpenFile(Directory.GetCurrentDirectory() + "\\systemFiles\\playerSettingParam.bin.xfbin");
                List<string> CharacterList = new List<string>();
                List<int> PageList = new List<int>();
                List<int> PositionList = new List<int>();
                List<int> CostumeCspList = new List<int>();
                List<string> ChaList = new List<string>();
                List<string> AccessoryList = new List<string>();
                List<string> NewIdList = new List<string>();
                List<byte[]> GibberishBytes = new List<byte[]>();
                for (int x = 0; x < PspFile.EntryCount; x++) {
                    for (int i = 0; i < CspFile.EntryCount; i++) {
                        if (PspFile.CharacterList[x] == CspFile.CharacterList[i] && Main.b_byteArrayToInt(PspFile.CharacodeList[x]) == CharacodeID) {
                            CharacterList.Add(CspFile.CharacterList[i]);
                            PageList.Add(CspFile.PageList[i]);
                            PositionList.Add(CspFile.PositionList[i]);
                            CostumeCspList.Add(CspFile.CostumeList[i]);
                            ChaList.Add(CspFile.ChaList[i]);
                            AccessoryList.Add(CspFile.AccessoryList[i]);
                            NewIdList.Add(CspFile.NewIdList[i]);
                            GibberishBytes.Add(CspFile.GibberishBytes[i]);
                        }

                    }
                }
                CspFile.EntryCount = CharacterList.Count;
                CspFile.CharacterList = CharacterList;
                CspFile.PageList = PageList;
                CspFile.PositionList = PositionList;
                CspFile.CostumeList = CostumeCspList;
                CspFile.ChaList = ChaList;
                CspFile.AccessoryList = AccessoryList;
                CspFile.NewIdList = NewIdList;
                CspFile.GibberishBytes = GibberishBytes;
                if (CspFile.EntryCount != 0) {
                    if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\ui\\max\\select\\WIN64\\"))) {
                        Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\ui\\max\\select\\WIN64\\"));
                    }
                    CspFile.SaveFileAs(SaveDirectory + "\\ui\\max\\select\\WIN64\\characterSelectParam.xfbin");
                }
            }
            if (skillCustomizeExist) {
                Tool_SkillCustomizeParamEditor_new skillCustomizeFile = new Tool_SkillCustomizeParamEditor_new();
                skillCustomizeFile.OpenFile(skillCustomizePath);
                for (int x = 0; x< skillCustomizeFile.EntryCount; x++) {
                    if (Main.b_byteArrayToInt(skillCustomizeFile.CharacodeList[x]) != CharacodeID) {
                        skillCustomizeFile.CharacodeList.RemoveAt(x);
                        skillCustomizeFile.Skill1List.RemoveAt(x);
                        skillCustomizeFile.Skill1_ex_List.RemoveAt(x);
                        skillCustomizeFile.Skill1_air_List.RemoveAt(x);
                        skillCustomizeFile.Skill2List.RemoveAt(x);
                        skillCustomizeFile.Skill2_ex_List.RemoveAt(x);
                        skillCustomizeFile.Skill2_air_List.RemoveAt(x);
                        skillCustomizeFile.Skill3List.RemoveAt(x);
                        skillCustomizeFile.Skill3_ex_List.RemoveAt(x);
                        skillCustomizeFile.Skill3_air_List.RemoveAt(x);
                        skillCustomizeFile.Skill4List.RemoveAt(x);
                        skillCustomizeFile.Skill4_ex_List.RemoveAt(x);
                        skillCustomizeFile.Skill4_air_List.RemoveAt(x);
                        skillCustomizeFile.Skill5List.RemoveAt(x);
                        skillCustomizeFile.Skill5_ex_List.RemoveAt(x);
                        skillCustomizeFile.Skill5_air_List.RemoveAt(x);
                        skillCustomizeFile.Skill6List.RemoveAt(x);
                        skillCustomizeFile.Skill6_ex_List.RemoveAt(x);
                        skillCustomizeFile.Skill6_air_List.RemoveAt(x);
                        skillCustomizeFile.SkillAwaList.RemoveAt(x);
                        skillCustomizeFile.SkillAwa_ex_List.RemoveAt(x);
                        skillCustomizeFile.SkillAwa_air_List.RemoveAt(x);
                        skillCustomizeFile.Skill1_CUC_List.RemoveAt(x);
                        skillCustomizeFile.Skill1_CUCC_List.RemoveAt(x);
                        skillCustomizeFile.Skill2_CUC_List.RemoveAt(x);
                        skillCustomizeFile.Skill2_CUCC_List.RemoveAt(x);
                        skillCustomizeFile.Skill3_CUC_List.RemoveAt(x);
                        skillCustomizeFile.Skill3_CUCC_List.RemoveAt(x);
                        skillCustomizeFile.Skill4_CUC_List.RemoveAt(x);
                        skillCustomizeFile.Skill4_CUCC_List.RemoveAt(x);
                        skillCustomizeFile.Skill5_CUC_List.RemoveAt(x);
                        skillCustomizeFile.Skill5_CUCC_List.RemoveAt(x);
                        skillCustomizeFile.Skill6_CUC_List.RemoveAt(x);
                        skillCustomizeFile.Skill6_CUCC_List.RemoveAt(x);
                        skillCustomizeFile.SkillAwa_CUC_List.RemoveAt(x);
                        skillCustomizeFile.SkillAwa_CUCC_List.RemoveAt(x);
                        skillCustomizeFile.Skill1_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill2_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill3_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill4_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill5_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill6_Priority_List.RemoveAt(x);
                        skillCustomizeFile.SkillAwa_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill1ex_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill2ex_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill3ex_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill4ex_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill5ex_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill6ex_Priority_List.RemoveAt(x);
                        skillCustomizeFile.SkillAwaex_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill1air_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill2air_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill3air_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill4air_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill5air_Priority_List.RemoveAt(x);
                        skillCustomizeFile.Skill6air_Priority_List.RemoveAt(x);
                        skillCustomizeFile.SkillAwaair_Priority_List.RemoveAt(x);
                        x--;
                        skillCustomizeFile.EntryCount--;
                    }
                }
                if (skillCustomizeFile.EntryCount != 0) {
                    if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64"))) {
                        Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64\\"));
                    }
                    skillCustomizeFile.SaveFileAs(SaveDirectory + "\\spc\\WIN64\\skillCustomizeParam.xfbin");
                }
            }
            if (spskillCustomizeExist) {
                Tool_SpSkillCustomizeParamEditor spSkillCustomizeFile = new Tool_SpSkillCustomizeParamEditor();
                spSkillCustomizeFile.OpenFile(spskillCustomizePath);
                for (int x = 0; x< spSkillCustomizeFile.EntryCount; x++) {
                    if (Main.b_byteArrayToInt(spSkillCustomizeFile.CharacodeList[x]) != CharacodeID) {
                        spSkillCustomizeFile.CharacodeList.RemoveAt(x);
                        spSkillCustomizeFile.spl1_chUsageCountValueList.RemoveAt(x);
                        spSkillCustomizeFile.spl2_chUsageCountValueList.RemoveAt(x);
                        spSkillCustomizeFile.spl3_chUsageCountValueList.RemoveAt(x);
                        spSkillCustomizeFile.spl4_chUsageCountValueList.RemoveAt(x);
                        spSkillCustomizeFile.spl1_chUsageCountValueListFloat.RemoveAt(x);
                        spSkillCustomizeFile.spl2_chUsageCountValueListFloat.RemoveAt(x);
                        spSkillCustomizeFile.spl3_chUsageCountValueListFloat.RemoveAt(x);
                        spSkillCustomizeFile.spl4_chUsageCountValueListFloat.RemoveAt(x);
                        spSkillCustomizeFile.spl1_PriorList.RemoveAt(x);
                        spSkillCustomizeFile.spl2_PriorList.RemoveAt(x);
                        spSkillCustomizeFile.spl3_PriorList.RemoveAt(x);
                        spSkillCustomizeFile.spl4_PriorList.RemoveAt(x);
                        spSkillCustomizeFile.spl1_NameList.RemoveAt(x);
                        spSkillCustomizeFile.spl2_NameList.RemoveAt(x);
                        spSkillCustomizeFile.spl3_NameList.RemoveAt(x);
                        spSkillCustomizeFile.spl4_NameList.RemoveAt(x);
                        spSkillCustomizeFile.WeirdValuesList.RemoveAt(x);
                        spSkillCustomizeFile.EntryCount--;
                        x--;
                    }
                }
                if (spSkillCustomizeFile.EntryCount != 0) {
                    if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64"))) {
                        Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64\\"));
                    }
                    spSkillCustomizeFile.SaveFileAs(SaveDirectory + "\\spc\\WIN64\\spSkillCustomizeParam.xfbin");
                }  
            }
            if (cmnparamExist) {
                Tool_cmnparamEditor cmnparamFile = new Tool_cmnparamEditor();
                cmnparamFile.OpenFile(cmnparamPath);
                for (int x = 0; x < cmnparamFile.EntryCount_Player; x++) {
                    if (cmnparamFile.Player_Characode_List[x] != SaveCharacode) {
                        cmnparamFile.Player_Characode_List.RemoveAt(x);
                        cmnparamFile.Player_PlFileName_List.RemoveAt(x);
                        cmnparamFile.Player_PlAwaFileName_List.RemoveAt(x);
                        cmnparamFile.Player_PlAwa2FileName_List.RemoveAt(x);
                        cmnparamFile.Player_EvName_List.RemoveAt(x);
                        cmnparamFile.Player_UJEvName_List.RemoveAt(x);
                        cmnparamFile.Player_UJ_1_CutInName_List.RemoveAt(x);
                        cmnparamFile.Player_UJ_1_AtkName_List.RemoveAt(x);
                        cmnparamFile.Player_UJ_2_CutInName_List.RemoveAt(x);
                        cmnparamFile.Player_UJ_2_AtkName_List.RemoveAt(x);
                        cmnparamFile.Player_UJ_3_CutInName_List.RemoveAt(x);
                        cmnparamFile.Player_UJ_3_AtkName_List.RemoveAt(x);
                        cmnparamFile.Player_UJ_Alt_CutInName_List.RemoveAt(x);
                        cmnparamFile.Player_UJ_Alt_AtkName_List.RemoveAt(x);
                        cmnparamFile.Player_PartnerCharacode_List.RemoveAt(x);
                        cmnparamFile.Player_PartnerAwaCharacode_List.RemoveAt(x);
                        cmnparamFile.EntryCount_Player--;
                        x--;
                    }
                }
                if (cmnparamFile.EntryCount_Player != 0) {
                    if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\sound\\"))) {
                        Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\sound\\"));
                    }
                    cmnparamFile.SaveFileAs(SaveDirectory + "\\sound\\cmnparam.xfbin");
                }
            }
            Tool_AwakeAuraEditor awakeAuraFile = new Tool_AwakeAuraEditor();
            if (awakeAuraExist)
                awakeAuraFile.OpenFile(awakeAuraPath);
            else
                awakeAuraFile.OpenFile(Directory.GetCurrentDirectory() + "\\systemFiles\\awakeAura.xfbin");
            for (int x = 0; x < awakeAuraFile.EntryCount; x++) {
                if (SaveCharacode != awakeAuraFile.CharacodeList[x]) {
                    awakeAuraFile.CharacodeList.RemoveAt(x);
                    awakeAuraFile.SkillFileList.RemoveAt(x);
                    awakeAuraFile.EffectList.RemoveAt(x);
                    awakeAuraFile.MainBoneList.RemoveAt(x);
                    awakeAuraFile.SecondBoneList.RemoveAt(x);
                    awakeAuraFile.AwakeModeValue_false_List.RemoveAt(x);
                    awakeAuraFile.AwakeModeValue_true_List.RemoveAt(x);
                    awakeAuraFile.SecondBoneValue_1_List.RemoveAt(x);
                    awakeAuraFile.SecondBoneValue_2_List.RemoveAt(x);
                    awakeAuraFile.SecondBoneValue_3_List.RemoveAt(x);
                    awakeAuraFile.ConstantValue_List.RemoveAt(x);
                    awakeAuraFile.EntryCount--;
                    x--;
                }
            }
            if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64\\"))) {
                Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64\\"));
            }
            awakeAuraFile.SaveFileAs(SaveDirectory + "\\spc\\WIN64\\awakeAura.xfbin");

            //player_icon
            Tool_IconEditor iconFile = new Tool_IconEditor();
            Tool_PlayerSettingParamEditor PspIconFile = new Tool_PlayerSettingParamEditor();
            if (iconExist)
                iconFile.OpenFile(iconPath);
            else
                iconFile.OpenFile(Directory.GetCurrentDirectory() + "\\systemFiles\\player_icon.xfbin");
            if (pspExist)
                PspIconFile.OpenFile(SaveDirectory + "\\" + pspPath.Substring(pspPath.IndexOf(dataWinFolder) + dataWinFolderLength));
            else
                PspIconFile.OpenFile(Directory.GetCurrentDirectory() + "\\systemFiles\\playerSettingParam.bin.xfbin");
            List<byte[]> CharacodeList = new List<byte[]>();
            List<byte[]> CostumeList = new List<byte[]>();
            List<string> NameList = new List<string>();
            List<string> ExNinjutsuList = new List<string>();
            List<string> IconList = new List<string>();
            List<string> AwaIconList = new List<string>();
            for (int i = 0; i < PspIconFile.EntryCount; i++) {
                for (int x = 0; x < iconFile.EntryCount; x++) {
                    if (Main.b_byteArrayToInt(PspIconFile.CharacodeList[i]) == CharacodeID && Main.b_byteArrayToInt(iconFile.CharacodeList[x]) == CharacodeID && PspIconFile.OptValueA[i] == Main.b_byteArrayToInt(iconFile.CostumeList[x])) {
                        CharacodeList.Add(iconFile.CharacodeList[x]);
                        CostumeList.Add(iconFile.CostumeList[x]);
                        NameList.Add(iconFile.NameList[x]);
                        ExNinjutsuList.Add(iconFile.ExNinjutsuList[x]);
                        IconList.Add(iconFile.IconList[x]);
                        AwaIconList.Add(iconFile.AwaIconList[x]);
                    }
                }
            }
            iconFile.CharacodeList = CharacodeList;
            iconFile.CostumeList = CostumeList;
            iconFile.NameList = NameList;
            iconFile.ExNinjutsuList = ExNinjutsuList;
            iconFile.IconList = IconList;
            iconFile.AwaIconList = AwaIconList;
            iconFile.EntryCount = CharacodeList.Count;

            if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64\\"))) {
                Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64\\"));
            }
            iconFile.SaveFileAs(SaveDirectory + "\\spc\\WIN64\\player_icon.xfbin");
            List<string> iconPaths = new List<string>();
            List<string> iconNames = new List<string>();
            foreach (FileInfo file in icon_Files) {
                iconPaths.Add(file.FullName.ToString());
                iconNames.Add(file.Name.ToString());
                }
            for (int z =0; z<CharacodeList.Count; z++) {
                for (int h=0; h<iconPaths.Count; h++) {
                    if ((iconNames[h].Contains(NameList[z]) && NameList[z] != "") || (iconNames[h].Contains(ExNinjutsuList[z]) && ExNinjutsuList[z] != "") || (iconNames[h].Contains(IconList[z]) && IconList[z] != "") || (iconNames[h].Contains(AwaIconList[z]) && AwaIconList[z] != "")) {
                        CopyFiles(Path.GetDirectoryName(SaveDirectory + "\\" + iconPaths[h].Substring(iconPaths[h].IndexOf(dataWinFolder) + dataWinFolderLength)), iconPaths[h], SaveDirectory + "\\" + iconPaths[h].Substring(iconPaths[h].IndexOf(dataWinFolder) + dataWinFolderLength));
                    }
                }
                
            }
            //AppearanceANM
            Tool_appearenceAnmEditor appearanceAnmFile = new Tool_appearenceAnmEditor();
            if (appearanceAnmExist)
                appearanceAnmFile.OpenFile(appearanceAnmPath);
            else
                appearanceAnmFile.OpenFile(Directory.GetCurrentDirectory() + "\\systemFiles\\appearanceAnm.xfbin");
            for (int x = 0; x < appearanceAnmFile.EntryCount; x++) {
                if (Main.b_byteArrayToInt(appearanceAnmFile.CharacodeList[x]) != CharacodeID) {
                    appearanceAnmFile.CharacodeList.RemoveAt(x);
                    appearanceAnmFile.MeshList.RemoveAt(x);
                    appearanceAnmFile.SlotList.RemoveAt(x);
                    appearanceAnmFile.TypeSectionList.RemoveAt(x);
                    appearanceAnmFile.EnableDisableList.RemoveAt(x);
                    appearanceAnmFile.NormalStateList.RemoveAt(x);
                    appearanceAnmFile.AwakeningStateList.RemoveAt(x);
                    appearanceAnmFile.ReverseSectionList.RemoveAt(x);
                    appearanceAnmFile.EnableDisableCutNCList.RemoveAt(x);
                    appearanceAnmFile.EnableDisableUltList.RemoveAt(x);
                    appearanceAnmFile.EnableDisableWinList.RemoveAt(x);
                    appearanceAnmFile.EnableDisableArmorBreakList.RemoveAt(x);
                    appearanceAnmFile.TimingAwakeList.RemoveAt(x);
                    appearanceAnmFile.TransparenceList.RemoveAt(x);
                    appearanceAnmFile.EntryCount--;
                    x--;
                }
            }
            if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64\\"))) {
                Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64\\"));
            }
            appearanceAnmFile.SaveFileAs(SaveDirectory + "\\spc\\WIN64\\appearanceAnm.xfbin");

          
            //AfterAttachObject
            Tool_afterAttachObject afterAttachObjectFile = new Tool_afterAttachObject();
            if (afterAttachObjectExist)
                afterAttachObjectFile.OpenFile(afterAttachObjectPath);
            else
                afterAttachObjectFile.OpenFile(Directory.GetCurrentDirectory() + "\\systemFiles\\afterAttachObject.xfbin");
            for (int x = 0; x < afterAttachObjectFile.EntryCount; x++) {
                if (afterAttachObjectFile.characode1List[x] != SaveCharacode) {
                    afterAttachObjectFile.characode1List.RemoveAt(x);
                    afterAttachObjectFile.characode2List.RemoveAt(x);
                    afterAttachObjectFile.pathList.RemoveAt(x);
                    afterAttachObjectFile.meshList.RemoveAt(x);
                    afterAttachObjectFile.bone1List.RemoveAt(x);
                    afterAttachObjectFile.bone2List.RemoveAt(x);
                    afterAttachObjectFile.value1List.RemoveAt(x);
                    afterAttachObjectFile.value2List.RemoveAt(x);
                    afterAttachObjectFile.value3List.RemoveAt(x);
                    afterAttachObjectFile.XPosList.RemoveAt(x);
                    afterAttachObjectFile.YPosList.RemoveAt(x);
                    afterAttachObjectFile.ZPosList.RemoveAt(x);
                    afterAttachObjectFile.XRotList.RemoveAt(x);
                    afterAttachObjectFile.YRotList.RemoveAt(x);
                    afterAttachObjectFile.ZRotList.RemoveAt(x);
                    afterAttachObjectFile.XScaleList.RemoveAt(x);
                    afterAttachObjectFile.YScaleList.RemoveAt(x);
                    afterAttachObjectFile.ZScaleList.RemoveAt(x);
                    afterAttachObjectFile.EntryCount--;
                    x--;
                }
            }
            if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64\\"))) {
                Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\spc\\WIN64\\"));
            }
            afterAttachObjectFile.SaveFileAs(SaveDirectory + "\\spc\\WIN64\\afterAttachObject.xfbin");

            //Copy all files with characode
            foreach (FileInfo file in Files) {
                if (File.Exists(Main.datawin32Path + "\\" + file.FullName.Substring(file.FullName.IndexOf(dataWinFolder) + dataWinFolderLength))) {
                    if (file.Name.Contains(SaveCharacode))
                        CopyFiles(Path.GetDirectoryName(SaveDirectory + "\\" + file.FullName.Substring(file.FullName.IndexOf(dataWinFolder) + dataWinFolderLength)), Main.datawin32Path + "\\" + file.FullName.Substring(file.FullName.IndexOf(dataWinFolder) + dataWinFolderLength), SaveDirectory + "\\" + file.FullName.Substring(file.FullName.IndexOf(dataWinFolder) + dataWinFolderLength));
                }
            }

            //moddingAPI files
            if (Directory.Exists(moddingAPIPath)) {
                List<string> partnerSlotParamPaths = new List<string>();
                List<string> specialCondParamPaths = new List<string>();
                List<string> cpkPaths = new List<string>();
                List<string> cpkNames = new List<string>();
                DirectoryInfo moddingAPI_d = new DirectoryInfo(@moddingAPIPath);
                FileInfo[] moddingAPI_Files = moddingAPI_d.GetFiles("*.xfbin", SearchOption.AllDirectories);
                FileInfo[] cpk_Files = moddingAPI_d.GetFiles("*.cpk", SearchOption.AllDirectories);

                foreach (FileInfo file in moddingAPI_Files) {
                    if (file.FullName.Contains("partnerSlotParam.xfbin")) {
                        partnerSlotParamPaths.Add(file.FullName);
                    }
                    else if (file.FullName.Contains("specialCondParam.xfbin")) {
                        specialCondParamPaths.Add(file.FullName);
                    }
                }
                foreach (FileInfo file in cpk_Files) {
                    if (file.FullName.Contains(SaveCharacode)) {
                        cpkPaths.Add(file.FullName);
                        cpkNames.Add(file.Name);
                    } 
                }
                if (specialCondParamPaths.Count > 0) {
                    for (int x = 0; x < specialCondParamPaths.Count; x++) {
                        byte[] FileBytes = File.ReadAllBytes(specialCondParamPaths[x]);
                        int EntryCount = FileBytes.Length / 0x20;

                        for (int z = 0; z< EntryCount; z++) {
                            long _ptr = 0x20 * z;
                            string ConditionName = Main.b_ReadString2(FileBytes, (int)_ptr);
                            int CondCharacodeID = Main.b_ReadIntFromTwoBytes(FileBytes, (int)_ptr + 0x17);
                            if (CondCharacodeID == CharacodeID) {
                                byte[] Section = new byte[0x20];
                                Section = Main.b_ReplaceString(Section, ConditionName, 0);
                                Section = Main.b_ReplaceBytes(Section, BitConverter.GetBytes(CondCharacodeID), 0x17);
                                if (!Directory.Exists(f.SelectedPath + "\\" + SaveCharacode + "\\moddingapi\\mods\\" + SaveCharacode)) {
                                    Directory.CreateDirectory(f.SelectedPath + "\\" + SaveCharacode + "\\moddingapi\\mods\\" + SaveCharacode);
                                }
                                File.WriteAllBytes(f.SelectedPath + "\\" + SaveCharacode + "\\moddingapi\\mods\\" + SaveCharacode + "\\specialCondParam.xfbin", Section);
                                break;
                            }
                        }
                    }
                }
                if (partnerSlotParamPaths.Count > 0) {
                    for (int x = 0; x < partnerSlotParamPaths.Count; x++) {
                        byte[] FileBytes = File.ReadAllBytes(partnerSlotParamPaths[x]);
                        int EntryCount = FileBytes.Length / 0x20;

                        for (int z = 0; z < EntryCount; z++) {
                            long _ptr = 0x20 * z;
                            string ConditionName = Main.b_ReadString2(FileBytes, (int)_ptr);
                            int CondCharacodeID = Main.b_ReadIntFromTwoBytes(FileBytes, (int)_ptr + 0x17);
                            if (CondCharacodeID == CharacodeID) {
                                byte[] Section = new byte[0x20];
                                Section = Main.b_ReplaceString(Section, ConditionName, 0);
                                Section = Main.b_ReplaceBytes(Section, BitConverter.GetBytes(CondCharacodeID), 0x17);
                                if (!Directory.Exists(f.SelectedPath + "\\" + SaveCharacode + "\\moddingapi\\mods\\" + SaveCharacode)) {
                                    Directory.CreateDirectory(f.SelectedPath + "\\" + SaveCharacode + "\\moddingapi\\mods\\" + SaveCharacode);
                                }
                                File.WriteAllBytes(f.SelectedPath + "\\" + SaveCharacode + "\\moddingapi\\mods\\" + SaveCharacode + "\\partnerSlotParam.xfbin", Section);
                                break;
                            }
                        }
                    }
                }
                if (cpkPaths.Count >0) {
                    if (!Directory.Exists(f.SelectedPath + "\\" + SaveCharacode + "\\moddingapi\\mods\\" + SaveCharacode)) {
                        Directory.CreateDirectory(f.SelectedPath + "\\" + SaveCharacode + "\\moddingapi\\mods\\" + SaveCharacode);
                    }
                    for (int c = 0; c<cpkPaths.Count;c++) {
                        CopyFiles(f.SelectedPath + "\\" + SaveCharacode + "\\moddingapi\\mods\\" + SaveCharacode, cpkPaths[c], f.SelectedPath + "\\" + SaveCharacode + "\\moddingapi\\mods\\" + SaveCharacode +"\\"+cpkNames[c]);

                        if (File.Exists(cpkPaths[c]+".info")) {
                            CopyFiles(f.SelectedPath + "\\" + SaveCharacode + "\\moddingapi\\mods\\" + SaveCharacode, cpkPaths[c] + ".info", f.SelectedPath + "\\" + SaveCharacode + "\\moddingapi\\mods\\" + SaveCharacode + "\\" + cpkNames[c] + ".info");

                        }
                    }
                }

            }
            
            FileStream fParameter = new FileStream(f.SelectedPath + "\\" + SaveCharacode + "\\characode.txt", FileMode.Create, FileAccess.Write);
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
            m_WriterParameter.Write(CharacodeID);
            m_WriterParameter.Flush();
            m_WriterParameter.Close();
            MessageBox.Show(SaveCharacode + " exported successfuly!");
        }

        public void CopyFiles(string targetPath, string originalDataWin32, string newDataWin32) {
            if (File.Exists(originalDataWin32)) {
                if (!Directory.Exists(targetPath)) {
                    Directory.CreateDirectory(targetPath);
                }
                File.Copy(originalDataWin32, newDataWin32, true);
            }
        }

        private void Tool_ExportCharacter_FormClosed(object sender, FormClosedEventArgs e) {
            Main.LoadConfig();
        }

        private void Search_Click(object sender, EventArgs e) {
            for (int i = 0; i<listBox1.Items.Count; i++) {
                if (listBox1.Items[i].ToString().Contains(Search_TB.Text)) {
                    listBox1.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
