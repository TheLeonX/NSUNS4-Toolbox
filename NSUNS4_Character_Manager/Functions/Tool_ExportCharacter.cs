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
        public bool prmLoadExist = false;
        public bool dppExist = false;
        public bool pspExist = false;
        public bool cspExist = false;
        public bool skillCustomizeExist = false;
        public bool spskillCustomizeExist = false;
        public bool iconExist = false;
        public bool awakeAuraExist = false;
        public bool appearanceAnmExist = false;
        public bool afterAttachObjectExist = false;
        private void Tool_ExportCharacter_Load(object sender, EventArgs e) {
            // Open Characode
            
            if (Main.chaPath == "[null]" || !File.Exists(Main.chaPath)) {
                Main.chaPath = Directory.GetCurrentDirectory() + "\\systemFiles\\characode.bin.xfbin";
            }
            if (Main.dppPath == "[null]" || !File.Exists(Main.dppPath)) {
                Main.dppPath = Directory.GetCurrentDirectory() + "\\systemFiles\\duelPlayerParam.xfbin";
            }
            if (Main.pspPath == "[null]" || !File.Exists(Main.pspPath)) {
                Main.pspPath = Directory.GetCurrentDirectory() + "\\systemFiles\\playerSettingParam.bin.xfbin";
            }
            Tool_CharacodeEditor CharacodeFile = new Tool_CharacodeEditor();
            CharacodeFile.OpenFile(Main.chaPath);

            for (int x = 0; x< CharacodeFile.CharacterCount; x++) {
                listBox1.Items.Add(CharacodeFile.CharacterList[x]);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x!=-1) {
                if (x>=0 && x<0xE7) {
                    SaveCharacode = listBox1.Items[x].ToString();
                    LiteExport(x + 1);
                }
                else {
                    SaveCharacode = listBox1.Items[x].ToString();
                    ExpertExport(x + 1);
                }
            }
        }

        public void LiteExport(int CharacodeID) {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog();
            SaveDirectory = f.SelectedPath+"\\"+ SaveCharacode + "\\data_win32";
            Directory.CreateDirectory(SaveDirectory);

            DirectoryInfo d = new DirectoryInfo(@Main.datawin32Path);

            FileInfo[] Files = d.GetFiles("*.xfbin", SearchOption.AllDirectories);
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
                        CopyFiles(SaveDirectory + "\\" + SpcloadFile.pathList[i], Main.datawin32Path + "\\" + SpcloadFile.pathList[i] + "\\" + name + ".xfbin", SaveDirectory + "\\" + SpcloadFile.pathList[i] + "\\" + name + ".xfbin");
                    }
                    else {
                        for (int x = 0; x< names.Count; x++) {
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
                if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\" + dppPath.Substring(dppPath.IndexOf("data_win32\\") + 11)))) {
                    Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\" + dppPath.Substring(dppPath.IndexOf("data_win32\\") + 11)));
                }
                DppFile.SaveFileAs(SaveDirectory + "\\" + dppPath.Substring(dppPath.IndexOf("data_win32\\") + 11));
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
                if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\" + pspPath.Substring(pspPath.IndexOf("data_win32\\") + 11)))) {
                    Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\" + pspPath.Substring(pspPath.IndexOf("data_win32\\") + 11)));
                }
                PspFile.SaveFileAs(SaveDirectory + "\\" + pspPath.Substring(pspPath.IndexOf("data_win32\\") + 11));
            }
            if (cspExist) {
                Tool_RosterEditor CspFile = new Tool_RosterEditor();
                Tool_PlayerSettingParamEditor PspFile = new Tool_PlayerSettingParamEditor();
                CspFile.OpenFile(cspPath);
                if (pspExist)
                    PspFile.OpenFile(SaveDirectory + "\\" + pspPath.Substring(pspPath.IndexOf("data_win32\\") + 11));
                else
                    PspFile.OpenFile(Main.pspPath);
                List<string> CharacterList = new List<string>();
                List<int> PageList = new List<int>();
                List<int> PositionList = new List<int>();
                List<int> CostumeList = new List<int>();
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
                            CostumeList.Add(CspFile.CostumeList[i]);
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
                CspFile.CostumeList = CostumeList;
                CspFile.ChaList = ChaList;
                CspFile.AccessoryList = AccessoryList;
                CspFile.NewIdList = NewIdList;
                CspFile.GibberishBytes = GibberishBytes;
                if (!Directory.Exists(Path.GetDirectoryName(SaveDirectory + "\\" + cspPath.Substring(cspPath.IndexOf("data_win32\\") + 11)))) {
                    Directory.CreateDirectory(Path.GetDirectoryName(SaveDirectory + "\\" + cspPath.Substring(cspPath.IndexOf("data_win32\\") + 11)));
                }
                CspFile.SaveFileAs(SaveDirectory + "\\" + cspPath.Substring(cspPath.IndexOf("data_win32\\") + 11));
            }
            foreach (FileInfo file in Files) {
                if (File.Exists(Main.datawin32Path + "\\" + file.FullName.Substring(file.FullName.IndexOf("data_win32\\") + 11))) {
                    if (file.Name.Contains(SaveCharacode))
                        CopyFiles(Path.GetDirectoryName(SaveDirectory + "\\" + file.FullName.Substring(file.FullName.IndexOf("data_win32\\") + 11)), Main.datawin32Path + "\\" + file.FullName.Substring(file.FullName.IndexOf("data_win32\\") + 11), SaveDirectory + "\\" + file.FullName.Substring(file.FullName.IndexOf("data_win32\\") + 11));
                }
            }



        }

        public void ExpertExport(int CharacodeID) {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog();
            SaveDirectory = f.SelectedPath + "\\" + SaveCharacode + "\\data_win32";
            DirectoryInfo di = Directory.CreateDirectory(SaveDirectory);
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
    }
}
