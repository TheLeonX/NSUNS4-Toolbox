using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSUNS4_Character_Manager.Tools
{
    public partial class Tool_PortPRM : Form
    {
        public Tool_MovesetCoder tool;
        public bool PRMFileOpened = false;
        public Tool_PortPRM(Tool_MovesetCoder t, bool fileOpen, string[] sectionnames)
        {
            InitializeComponent();
            PRMFileOpened = fileOpen;
            comboBox3.Items.Clear();
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;
            tool = t;
            for (int i =0; i<tool.verList.Count; i++)
            {
                comboBox3.Items.Add(sectionnames[i]);
            }
        }
        public bool changeSettings;
        private void Tool_PortPRM_Load(object sender, EventArgs e)
        {

        }
        public List<string> ListPL_ANM_Names = new List<string>();
        public string PL_ANM_Name = "";
        public string PL_ANM_NEXT_Name = "";
        public string PL_ANM_PREV_Name = "";
        public string PL_ANM_DMG_Name = "";
        public string animationName = "";
        public bool removeSoundSection = false;
        public int ID_PRMFile = 0;
        public int frameSkip = 0;
        public int sectionCount = 0;
        public int startTime = 0;
        public int endTime = 0;
        public int directionCombo = 0;
        public int playCondition = 0;
        public int linkCondition = 0;
        public int enableCubeMan = 0;
        public int enableFaceAnimation = 0;
        public int reverseEnemy = 0;
        public int noFrameSkip = 0;
        public int animationPositionFix = 0;
        public int triggerState = 0;
        public int countOfSection = 0;
        public int countOfAllMovementSections = 0;
        //public List<byte[]> FunctionData = new List<byte[]>();
        public List<int> FunctionTimingList = new List<int>();
        public List<int> FunctionIDList = new List<int>();
        public List<string> FunctionHitboxList = new List<string>();
        public List<int> FunctionParam1List = new List<int>();
        public List<int> FunctionParam2List = new List<int>();
        public List<int> FunctionParam3List = new List<int>();
        public List<float> FunctionParam4List = new List<float>();
        public List<int> FunctionParam5List = new List<int>();
        public List<int> FunctionParam6List = new List<int>();
        public List<string> FunctionDamageNameList = new List<string>();
        public List<int> DamageHitEffectList = new List<int>();
        public List<float> DamageValueList = new List<float>();
        public List<float> DamageHorizontalPushList = new List<float>();
        public List<float> DamageVerticalPushList = new List<float>();
        public List<float> DamageGuardValueList = new List<float>();
        public List<int> DamageHitCountList = new List<int>();
        public List<int> DamageHitFrequencyList = new List<int>();
        public List<int> DamageFreezeValueList = new List<int>();
        public List<int> DamageConditionList = new List<int>();
        public List<byte[]> DamageListEOH = new List<byte[]>();
        public byte[] ConvertedSection;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            FunctionTimingList = new List<int>();
            FunctionIDList = new List<int>();
            FunctionHitboxList = new List<string>();
            FunctionParam1List = new List<int>(); 
            FunctionParam2List = new List<int>(); 
            FunctionParam3List = new List<int>();
            FunctionParam4List = new List<float>();
            FunctionParam5List = new List<int>();
            FunctionParam6List = new List<int>();
            FunctionDamageNameList = new List<string>(); 
            DamageHitEffectList = new List<int>();
            DamageHorizontalPushList = new List<float>();
            DamageVerticalPushList = new List<float>();
            DamageGuardValueList = new List<float>();
            DamageValueList = new List<float>(); 
            DamageHitCountList = new List<int>();
            DamageHitFrequencyList = new List<int>();
            DamageFreezeValueList = new List<int>();
            DamageConditionList = new List<int>();
            DamageListEOH = new List<byte[]>();
            ListPL_ANM_Names = new List<string>();
            ID_PRMFile = 0;
            frameSkip = 0;
            sectionCount = 0;
            startTime = 0;
            endTime = 0;
            directionCombo = 0;
            playCondition = 0;
            linkCondition = 0;
            enableCubeMan = 0;
            enableFaceAnimation = 0;
            reverseEnemy = 0;
            noFrameSkip = 0;
            animationPositionFix = 0;
            triggerState = 0;
            button4.Enabled = false;
            textBox6.Text = "";
            countOfAllMovementSections = 0;
            countOfSection = 0;
            PL_ANM_Name = "";
            PL_ANM_NEXT_Name = "";
            PL_ANM_PREV_Name = "";
            PL_ANM_DMG_Name = "";
            animationName = "";
            int secCountForGen = 0;
            if (textBox5.Text != "")
            {
                if (comboBox1.Text == "Naruto Storm 1")
                {
                    byte[] PL_ANM_Section = Main.b_StringToBytes(textBox5.Text);
                    do
                    {
                        sectionCount = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x30);
                        if (PL_ANM_Section.Length >= 0x58 + 0x40 * sectionCount)
                        {
                            int totalsize = 0x58;
                            for (int i = 0; i < sectionCount; i++)
                            {
                                int seclength = 0x40;
                                int function = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x02);
                                if (function == 0x09 || function == 0x30 || function == 0x32 || function == 0x34 || function == 0x36 || function == 0x3B)
                                    seclength = 0x60;
                                FunctionTimingList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x00));
                                FunctionIDList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x02));
                                FunctionHitboxList.Add(Main.b_ReadString2(PL_ANM_Section, totalsize + 0x04));
                                FunctionParam1List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x24));
                                FunctionParam2List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x26));
                                FunctionParam3List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x28));
                                FunctionParam4List.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x2C));
                                FunctionParam5List.Add(0);
                                FunctionParam6List.Add(0);
                                if (totalsize + 0x90 <= PL_ANM_Section.Length && seclength == 0x40 && i != sectionCount - 1)
                                {
                                    if (Main.b_ReadString2(PL_ANM_Section, totalsize + 0x90, 0x10) == "PTRR012345678901")
                                    {
                                        seclength = 0x60;
                                    }
                                }
                                //else if (seclength == 0x40 && i == sectionCount - 1)
                                //{
                                //    if (PL_ANM_Section.Length > totalsize + 0x40)
                                //    {
                                //        seclength = 0x60;
                                //    }
                                //}
                                if (seclength == 0x60)
                                {
                                    FunctionDamageNameList.Add(Program.S1_DAMAGE_NAMES[Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x40)]);
                                    DamageHitEffectList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x42));
                                    DamageConditionList.Add(0);
                                    DamageHorizontalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x4C));
                                    DamageVerticalPushList.Add(0);
                                    DamageGuardValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                    DamageHitFrequencyList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x56));
                                    DamageValueList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x50));
                                    DamageHitCountList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x54));
                                    DamageFreezeValueList.Add(0);
                                }
                                else
                                {
                                    FunctionDamageNameList.Add("");
                                    DamageHitEffectList.Add(0);
                                    DamageConditionList.Add(0);
                                    DamageHorizontalPushList.Add(0);
                                    DamageVerticalPushList.Add(0);
                                    DamageGuardValueList.Add(0);
                                    DamageValueList.Add(0);
                                    DamageHitCountList.Add(0);
                                    DamageHitFrequencyList.Add(0);
                                    DamageFreezeValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                }
                                totalsize = totalsize + seclength;
                                secCountForGen++;
                            }
                            animationName = Main.b_ReadString2(PL_ANM_Section, 0, 0x10);
                            PL_ANM_Name = Main.b_ReadString2(PL_ANM_Section, 0x10, 0x20);
                            int pos = Main.b_FindString(PL_ANM_Name, "CMB");
                            if (pos > 0)
                                PL_ANM_Name = Main.b_ReplaceRealString(PL_ANM_Name, "ATK", pos);
                            int prev_index = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x36);
                            PL_ANM_PREV_Name = "PL_ANM_";
                            if (prev_index == 0xFFFF)
                                PL_ANM_PREV_Name = PL_ANM_PREV_Name + "ANY";
                            else if (prev_index == 0xFFFE)
                                PL_ANM_PREV_Name = "";
                            else
                            {
                                if (prev_index == 0x33)
                                    PL_ANM_PREV_Name = "PL_ANM_PRJ_LAND";
                                if (prev_index >= 0x34 && prev_index <= 0x3C)
                                {
                                    PL_ANM_PREV_Name = PL_ANM_PREV_Name + "PRJ_LAND" + (prev_index - 0x33).ToString();
                                }
                                if (prev_index == 0x3D)
                                    PL_ANM_PREV_Name = "PL_ANM_PRJ_AIR";
                                if (prev_index >= 0x3E && prev_index <= 0x46)
                                {
                                    PL_ANM_PREV_Name = PL_ANM_PREV_Name + "PRJ_AIR" + (prev_index - 0x33).ToString();
                                }
                                if (prev_index >= 0x4F && prev_index <= 0x6F)
                                {
                                    if (prev_index - 0x4F < 10)
                                    {
                                        PL_ANM_PREV_Name = PL_ANM_PREV_Name + "ATK0" + (prev_index - 0x4F).ToString();
                                    }
                                    else
                                    {
                                        PL_ANM_PREV_Name = PL_ANM_PREV_Name + "ATK" + (prev_index - 0x4F).ToString();
                                    }
                                }
                                if (prev_index >= 0x72 && prev_index <= 0x77)
                                {
                                    PL_ANM_PREV_Name = PL_ANM_PREV_Name + "ATK_FAR0" + (prev_index - 0x72).ToString();
                                }

                                if (prev_index >= 0x78 && prev_index <= 0x82)
                                {
                                    if (prev_index - 0x78 < 10)
                                    {
                                        PL_ANM_PREV_Name = PL_ANM_PREV_Name + "ATK_AIR0" + (prev_index - 0x78).ToString();
                                    }
                                    else
                                    {
                                        PL_ANM_PREV_Name = PL_ANM_PREV_Name + "ATK_AIR" + (prev_index - 0x78).ToString();
                                    }
                                }
                                if (prev_index >= 0x12F && prev_index <= 0x139)
                                {
                                    if (prev_index - 0x12F < 10)
                                    {
                                        PL_ANM_PREV_Name = PL_ANM_PREV_Name + "S_ATK0" + (prev_index - 0x12F).ToString();
                                    }
                                    else
                                    {
                                        PL_ANM_PREV_Name = PL_ANM_PREV_Name + "S_ATK" + (prev_index - 0x12F).ToString();
                                    }
                                }
                            }
                            ListPL_ANM_Names.Add(PL_ANM_Name);
                            startTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x38);
                            endTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x3A);
                            directionCombo = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x3C);
                            linkCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x3E);
                            playCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x40); //05 s1 = 02 s4, 03 s1 = 04 s4
                            enableCubeMan = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x44);
                            enableFaceAnimation = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x46);
                            noFrameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4C);
                            animationPositionFix = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4E);
                            reverseEnemy = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x50);
                            triggerState = 0;
                            //button4.Enabled = true;
                            textBox1.Text = PL_ANM_Name;
                            textBox3.Text = PL_ANM_NEXT_Name;
                            textBox2.Text = PL_ANM_PREV_Name;
                            textBox4.Text = PL_ANM_DMG_Name;
                            textBox7.Text = animationName;
                            ID_PRMFile = (int)numericUpDown1.Value;
                            if (comboBox2.Text== "Naruto Storm 4")
                                GenerateStorm4Code();
                            if (comboBox2.Text== "JoJo ASBR")
                                GenerateJoJoASBRCode();
                            countOfAllMovementSections = secCountForGen;
                            countOfSection++;
                            if (PL_ANM_Section.Length - totalsize >= 0x58)
                            {

                                byte[] Analysed_PL_ANM_Section = new byte[0];
                                Analysed_PL_ANM_Section = Main.b_AddBytes(Analysed_PL_ANM_Section, PL_ANM_Section, 0, totalsize);
                                PL_ANM_Section = Analysed_PL_ANM_Section;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Wrong format/length of PL_ANM section");
                            break;
                        }
                    }
                    while (PL_ANM_Section.Length >= 0x58);
                    if (countOfSection == 1)
                    {
                        countOfAllMovementSections = 0;
                        button4.Enabled = true;
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        textBox4.Enabled = true;
                        textBox7.Enabled = true;
                    }
                    else
                    {
                        button4.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        textBox7.Enabled = false;
                    }
                }
                if (comboBox1.Text == "Naruto Storm 2/Gen")
                {
                    byte[] PL_ANM_Section = Main.b_StringToBytes(textBox5.Text);

                    do
                    {
                        sectionCount = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x30);
                        if (PL_ANM_Section.Length >= 0xB4 + 0x40 * sectionCount)
                        {
                            int totalsize = 0xB4;
                            for (int i = 0; i < sectionCount; i++)
                            {
                                int seclength = 0x40;
                                int function = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x22);

                                FunctionTimingList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x20));
                                FunctionIDList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x22));
                                FunctionHitboxList.Add(Main.b_ReadString2(PL_ANM_Section, totalsize + 0x00));
                                FunctionParam1List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x24));
                                FunctionParam2List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x26));
                                FunctionParam3List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x28));
                                FunctionParam4List.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x2C));
                                FunctionParam5List.Add(0);
                                FunctionParam6List.Add(0);
                                
                                

                                switch (function)
                                {
                                    case 0x7B:
                                        if (totalsize + 0x40 < PL_ANM_Section.Length)
                                        {
                                            string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                            if (str == "SPSKILL_END") seclength = 0xA0;
                                        }
                                        break;
                                    case 0x17:
                                    case 0x19:
                                    case 0x1F:
                                    case 0x2D:
                                    case 0x74:
                                        seclength = 0xA0;
                                        break;
                                    case 0x2A:
                                    case 0x2B:
                                    case 0x2C:
                                    case 0x32:
                                    case 0x33:
                                    case 0x7F:
                                    case 0x80:
                                        if (totalsize + 0x40 < PL_ANM_Section.Length)
                                        {
                                            string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                            if (str.Length >= 7 && str.Substring(0, 7) == "SKL_ATK") seclength = 0xA0;
                                        }
                                        break;
                                }
                                if (totalsize + 0x40 < PL_ANM_Section.Length)
                                {
                                    string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                    if (str.Length > 3 && (str.Substring(0, 3) == "DMG" || str.Substring(0, 3) == "DAM" || str.Substring(0, 3) == "SPS"))
                                    {
                                        seclength = 0xA0;
                                    }
                                }
                                if (seclength == 0xA0)
                                {
                                    FunctionDamageNameList.Add(Main.b_ReadString(PL_ANM_Section, totalsize + 0x40));
                                    DamageConditionList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x84));
                                    DamageHitEffectList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x82));
                                    DamageHorizontalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x8C));
                                    DamageVerticalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x9C));
                                    DamageGuardValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                    DamageValueList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x90));
                                    DamageHitCountList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x94));
                                    DamageFreezeValueList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x96));
                                    DamageHitFrequencyList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x98));
                                }
                                else
                                {
                                    FunctionDamageNameList.Add("");
                                    DamageConditionList.Add(0);
                                    DamageHitEffectList.Add(0);
                                    DamageHorizontalPushList.Add(0);
                                    DamageGuardValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                    DamageVerticalPushList.Add(0);
                                    DamageValueList.Add(0);
                                    DamageHitCountList.Add(0);
                                    DamageHitFrequencyList.Add(0);
                                    DamageFreezeValueList.Add(0);
                                }
                                totalsize = totalsize + seclength;
                                secCountForGen++;
                            }
                            animationName = Main.b_ReadString2(PL_ANM_Section, 0x20, 0x10);
                            PL_ANM_Name = Main.b_ReadString2(PL_ANM_Section, 0x00, 0x20);
                            PL_ANM_PREV_Name = Main.b_ReadString2(PL_ANM_Section, 0x54, 0x20);
                            PL_ANM_NEXT_Name = Main.b_ReadString2(PL_ANM_Section, 0x74, 0x20);
                            PL_ANM_DMG_Name = Main.b_ReadString2(PL_ANM_Section, 0x94, 0x20);
                            int pos = Main.b_FindString(PL_ANM_Name, "CMB");
                            if (pos > 0)
                                PL_ANM_Name = Main.b_ReplaceRealString(PL_ANM_Name, "ATK", pos);
                            pos = Main.b_FindString(PL_ANM_PREV_Name, "CMB");
                            if (pos > 0)
                                PL_ANM_PREV_Name = Main.b_ReplaceRealString(PL_ANM_PREV_Name, "ATK", pos);
                            pos = Main.b_FindString(PL_ANM_NEXT_Name, "CMB");
                            if (pos > 0)
                                PL_ANM_NEXT_Name = Main.b_ReplaceRealString(PL_ANM_NEXT_Name, "ATK", pos);
                            pos = Main.b_FindString(PL_ANM_DMG_Name, "CMB");
                            if (pos > 0)
                                PL_ANM_DMG_Name = Main.b_ReplaceRealString(PL_ANM_DMG_Name, "ATK", pos);
                            ListPL_ANM_Names.Add(PL_ANM_Name);

                            frameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x34);
                            ID_PRMFile = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x36);
                            enableCubeMan = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x38);
                            enableFaceAnimation = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x3A);
                            reverseEnemy = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x3C);
                            noFrameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x3E);
                            animationPositionFix = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x40);
                            directionCombo = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x48);
                            linkCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4A);
                            playCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4C);
                            startTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4E);
                            endTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x50);
                            triggerState = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x52);
                            //button4.Enabled = true;
                            textBox1.Text = PL_ANM_Name;
                            textBox3.Text = PL_ANM_NEXT_Name;
                            textBox2.Text = PL_ANM_PREV_Name;
                            textBox4.Text = PL_ANM_DMG_Name;
                            textBox7.Text = animationName;
                            numericUpDown1.Value = ID_PRMFile;
                            if (comboBox2.Text== "Naruto Storm 4")
                                GenerateStorm4Code();
                            if (comboBox2.Text== "JoJo ASBR")
                                GenerateJoJoASBRCode();
                            countOfAllMovementSections = secCountForGen;
                            countOfSection++;
                            if (PL_ANM_Section.Length- totalsize >= 0xB4)
                            {

                                byte[] Analysed_PL_ANM_Section = new byte[0];
                                Analysed_PL_ANM_Section = Main.b_AddBytes(Analysed_PL_ANM_Section, PL_ANM_Section, 0, totalsize);
                                PL_ANM_Section = Analysed_PL_ANM_Section;
                            }
                            else
                            {
                                break;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Wrong format/length of PL_ANM section " + (0xB4 + 0x40 * sectionCount).ToString("X2") +" " + PL_ANM_Section.Length.ToString("X2"));
                            break;
                        }
                    }
                    while (PL_ANM_Section.Length >= 0xB4);
                    if (countOfSection == 1)
                    {
                        countOfAllMovementSections = 0;
                        button4.Enabled = true;
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        textBox4.Enabled = true;
                        textBox7.Enabled = true;
                    }
                    else
                    {
                        button4.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        textBox7.Enabled = false;
                    }
                }
                if (comboBox1.Text == "Hack Versus")
                {
                    byte[] PL_ANM_Section = Main.b_StringToBytes(textBox5.Text);
                    do
                    {
                        sectionCount = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x30);
                        if (PL_ANM_Section.Length >= 0xB4 + 0x40 * sectionCount)
                        {
                            int totalsize = 0xB4;
                            for (int i = 0; i < sectionCount; i++)
                            {
                                int seclength = 0x40;
                                int function = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x22);

                                FunctionTimingList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x20));
                                FunctionIDList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x22));
                                FunctionHitboxList.Add(Main.b_ReadString2(PL_ANM_Section, totalsize + 0x00));
                                FunctionParam1List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x24));
                                FunctionParam2List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x26));
                                FunctionParam3List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x28));
                                FunctionParam4List.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x2C));
                                FunctionParam5List.Add(0);
                                FunctionParam6List.Add(0);

                                switch (function)
                                {
                                    case 0x20:
                                        if (totalsize + 0x40 < PL_ANM_Section.Length)
                                        {
                                            string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                            if (str == "SPSKILL_END") seclength = 0xA4;
                                        }
                                        break;
                                    case 0x12:
                                    case 0x14:
                                    case 0x16:
                                    case 0x18:
                                    case 0x1A:
                                    case 0x1E:
                                        seclength = 0xA4;
                                        break;
                                    case 0x2C:
                                    case 0x2D:
                                        if (totalsize + 0x40 < PL_ANM_Section.Length)
                                        {
                                            string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                            if (str.Length >= 7 && str.Substring(0, 7) == "SKL_ATK") seclength = 0xA4;
                                        }
                                        break;
                                }
                                if (totalsize + 0x40 < PL_ANM_Section.Length)
                                {
                                    string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                    if (str.Length > 3 && (str.Substring(0, 3) == "DMG" || str.Substring(0, 3) == "DAM" || str.Substring(0, 3) == "SKL" || str.Substring(0, 3) == "SPS"))
                                    {
                                        seclength = 0xA4;
                                    }
                                }
                                if (seclength == 0xA4)
                                {
                                    FunctionDamageNameList.Add(Main.b_ReadString(PL_ANM_Section, totalsize + 0x40));
                                    DamageConditionList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x84));
                                    DamageHitEffectList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x82));
                                    DamageHorizontalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x8C));
                                    DamageVerticalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x9C));
                                    DamageValueList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x90));
                                    DamageHitCountList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x94));
                                    DamageFreezeValueList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x96));
                                    DamageHitFrequencyList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x98));
                                    DamageGuardValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                }
                                else
                                {
                                    FunctionDamageNameList.Add("");
                                    DamageConditionList.Add(0);
                                    DamageHitEffectList.Add(0);
                                    DamageHorizontalPushList.Add(0);
                                    DamageVerticalPushList.Add(0);
                                    DamageGuardValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                    DamageValueList.Add(0);
                                    DamageHitCountList.Add(0);
                                    DamageHitFrequencyList.Add(0);
                                    DamageFreezeValueList.Add(0);
                                }
                                totalsize = totalsize + seclength;
                                secCountForGen++;
                            }
                                animationName = Main.b_ReadString2(PL_ANM_Section, 0x20, 0x10);
                                PL_ANM_Name = Main.b_ReadString2(PL_ANM_Section, 0x00, 0x20);
                                PL_ANM_PREV_Name = Main.b_ReadString2(PL_ANM_Section, 0x54, 0x20);
                                PL_ANM_NEXT_Name = Main.b_ReadString2(PL_ANM_Section, 0x74, 0x20);
                                PL_ANM_DMG_Name = Main.b_ReadString2(PL_ANM_Section, 0x94, 0x20);
                            ListPL_ANM_Names.Add(PL_ANM_Name);

                            frameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x34);
                                ID_PRMFile = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x36);
                                enableCubeMan = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x38);
                                enableFaceAnimation = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x3A);
                                reverseEnemy = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x3C);
                                noFrameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x3E);
                                animationPositionFix = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x40);
                                directionCombo = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x48);
                                linkCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4A);
                                playCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4C);
                                startTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4E);
                                endTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x50);
                                triggerState = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x52);
                                button4.Enabled = true;
                                textBox1.Text = PL_ANM_Name;
                                textBox3.Text = PL_ANM_NEXT_Name;
                                textBox2.Text = PL_ANM_PREV_Name;
                                textBox4.Text = PL_ANM_DMG_Name;
                                textBox7.Text = animationName;
                                numericUpDown1.Value = ID_PRMFile;
                                if (comboBox2.Text== "Naruto Storm 4")
                                    GenerateStorm4Code();
                                if (comboBox2.Text== "JoJo ASBR")
                                    GenerateJoJoASBRCode();
                                countOfAllMovementSections = secCountForGen;
                                countOfSection++;
                                if (PL_ANM_Section.Length - totalsize >= 0xB4)
                                {

                                    byte[] Analysed_PL_ANM_Section = new byte[0];
                                    Analysed_PL_ANM_Section = Main.b_AddBytes(Analysed_PL_ANM_Section, PL_ANM_Section, 0, totalsize);
                                    PL_ANM_Section = Analysed_PL_ANM_Section;
                                }
                                else
                                {
                                    break;
                                }
                        }
                    }
                    while (PL_ANM_Section.Length >= 0xB4);
                    if (countOfSection == 1)
                    {
                        countOfAllMovementSections = 0;
                        button4.Enabled = true;
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        textBox4.Enabled = true;
                        textBox7.Enabled = true;
                    }
                    else
                    {
                        button4.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        textBox7.Enabled = false;
                    }
                    
                }
                if (comboBox1.Text == "Naruto Storm 3 old")
                {
                    byte[] PL_ANM_Section = Main.b_StringToBytes(textBox5.Text);
                    do
                    {
                        sectionCount = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x40);
                        if (PL_ANM_Section.Length >= 0xC4 + 0x40 * sectionCount)
                        {
                            int totalsize = 0xC4;
                            for (int i = 0; i < sectionCount; i++)
                            {
                                int seclength = 0x40;
                                int function = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x22);

                                FunctionTimingList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x20));
                                FunctionIDList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x22));
                                FunctionHitboxList.Add(Main.b_ReadString2(PL_ANM_Section, totalsize + 0x00));
                                FunctionParam1List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x24));
                                FunctionParam2List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x26));
                                FunctionParam3List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x28));
                                FunctionParam4List.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x2C));
                                FunctionParam5List.Add(0);
                                FunctionParam6List.Add(0);
                                
                                

                                switch (function)
                                {
                                    case 0x2D:
                                        if (totalsize + 0x40 < PL_ANM_Section.Length)
                                        {
                                            string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                            if (str == "SPSKILL_END") seclength = 0xA0;
                                        }
                                        break;
                                    case 0x20:
                                    case 0x22:
                                    case 0x24:
                                    case 0x26:
                                    case 0x28:
                                    case 0x34:
                                    case 0x95:
                                    case 0xB3:
                                    case 0xB5:
                                        seclength = 0xA0;
                                        break;
                                    case 0x37:
                                    case 0x38:
                                    case 0x39:
                                    case 0x3A:
                                    case 0x3B:
                                    case 0x3C:
                                    case 0x3D:
                                        if (totalsize + 0x40 < PL_ANM_Section.Length)
                                        {
                                            string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                            if (str.Length >= 7 && str.Substring(0, 7) == "SKL_ATK") seclength = 0xA0;
                                        }
                                        break;
                                }
                                if (totalsize + 0x40 < PL_ANM_Section.Length)
                                {
                                    string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                    if (str.Length > 3 && (str.Substring(0, 3) == "DMG" || str.Substring(0, 3) == "DAM" || str.Substring(0, 3) == "SKL" || str.Substring(0, 3) == "SPS"))
                                    {
                                        seclength = 0xA0;
                                    }
                                }
                                if (seclength == 0xA0)
                                {
                                    FunctionDamageNameList.Add(Main.b_ReadString(PL_ANM_Section, totalsize + 0x40));
                                    DamageConditionList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x84));
                                    DamageHitEffectList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x82));
                                    DamageHorizontalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x8C));
                                    DamageVerticalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x9C));
                                    DamageValueList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x90));
                                    DamageHitCountList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x94));
                                    DamageFreezeValueList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x96));
                                    DamageHitFrequencyList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x98));
                                    DamageGuardValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                }
                                else
                                {
                                    FunctionDamageNameList.Add("");
                                    DamageConditionList.Add(0);
                                    DamageHitEffectList.Add(0);
                                    DamageHorizontalPushList.Add(0);
                                    DamageVerticalPushList.Add(0);
                                    DamageValueList.Add(0);
                                    DamageHitCountList.Add(0);
                                    DamageHitFrequencyList.Add(0);
                                    DamageFreezeValueList.Add(0);
                                    DamageGuardValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                }
                                totalsize = totalsize + seclength;
                                secCountForGen++;
                            }
                            animationName = Main.b_ReadString2(PL_ANM_Section, 0x20, 0x20);
                            PL_ANM_Name = Main.b_ReadString2(PL_ANM_Section, 0x00, 0x20);
                            PL_ANM_PREV_Name = Main.b_ReadString2(PL_ANM_Section, 0x64, 0x20);
                            PL_ANM_NEXT_Name = Main.b_ReadString2(PL_ANM_Section, 0x84, 0x20);
                            PL_ANM_DMG_Name = Main.b_ReadString2(PL_ANM_Section, 0xA4, 0x20);
                            ListPL_ANM_Names.Add(PL_ANM_Name);

                            frameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x44);
                            ID_PRMFile = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x46);
                            enableCubeMan = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x48);
                            enableFaceAnimation = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4A);
                            reverseEnemy = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4C);
                            noFrameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4E);
                            animationPositionFix = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x50);
                            directionCombo = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x58);
                            linkCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x5A);
                            playCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x5C);
                            startTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x5E);
                            endTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x60);
                            triggerState = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x62);
                            button4.Enabled = true;
                            textBox1.Text = PL_ANM_Name;
                            textBox3.Text = PL_ANM_NEXT_Name;
                            textBox2.Text = PL_ANM_PREV_Name;
                            textBox4.Text = PL_ANM_DMG_Name;
                            textBox7.Text = animationName;
                            numericUpDown1.Value = ID_PRMFile;
                            if (comboBox2.Text== "Naruto Storm 4")
                                GenerateStorm4Code();
                            if (comboBox2.Text== "JoJo ASBR")
                                GenerateJoJoASBRCode();
                            countOfAllMovementSections = secCountForGen;
                            countOfSection++;
                            if (PL_ANM_Section.Length - totalsize >= 0xC4)
                            {

                                byte[] Analysed_PL_ANM_Section = new byte[0];
                                Analysed_PL_ANM_Section = Main.b_AddBytes(Analysed_PL_ANM_Section, PL_ANM_Section, 0, totalsize);
                                PL_ANM_Section = Analysed_PL_ANM_Section;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    while (PL_ANM_Section.Length >= 0xC4);
                    if (countOfSection == 1)
                    {
                        countOfAllMovementSections = 0;
                        button4.Enabled = true;
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        textBox4.Enabled = true;
                        textBox7.Enabled = true;
                    }
                    else
                    {
                        button4.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        textBox7.Enabled = false;
                    }
                    
                }
                if (comboBox1.Text == "Naruto Storm 3 HD")
                {
                    byte[] PL_ANM_Section = Main.b_StringToBytes(textBox5.Text);
                    do
                    {
                        sectionCount = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x40);
                        if (PL_ANM_Section.Length >= 0xC4 + 0x48 * sectionCount)
                        {
                            int totalsize = 0xC4;
                            for (int i = 0; i < sectionCount; i++)
                            {
                                int seclength = 0x48;
                                int function = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x22);

                                FunctionTimingList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x20));
                                FunctionIDList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x22));
                                FunctionHitboxList.Add(Main.b_ReadString2(PL_ANM_Section, totalsize + 0x00));
                                FunctionParam1List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x24));
                                FunctionParam2List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x26));
                                FunctionParam3List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x28));
                                FunctionParam4List.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x2C));
                                FunctionParam5List.Add(0);
                                FunctionParam6List.Add(0);
                                
                                

                                switch (function)
                                {
                                    case 0x2D:
                                        if (totalsize + 0x48 < PL_ANM_Section.Length)
                                        {
                                            string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x48);
                                            if (str == "SPSKILL_END") seclength = 0xA8;
                                        }
                                        break;
                                    case 0x20:
                                    case 0x22:
                                    case 0x24:
                                    case 0x26:
                                    case 0x28:
                                    case 0x34:
                                    case 0x95:
                                    case 0xB3:
                                    case 0xB5:
                                        seclength = 0xA8;
                                        break;
                                    case 0x37:
                                    case 0x38:
                                    case 0x39:
                                    case 0x3A:
                                    case 0x3B:
                                    case 0x3C:
                                    case 0x3D:
                                        if (totalsize + 0x48 < PL_ANM_Section.Length)
                                        {
                                            string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x48);
                                            if (str.Length >= 7 && str.Substring(0, 7) == "SKL_ATK") seclength = 0xA8;
                                        }
                                        break;
                                }
                                if (totalsize + 0x40 < PL_ANM_Section.Length)
                                {
                                    string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x48);
                                    if (str.Length > 3 && (str.Substring(0, 3) == "DMG" || str.Substring(0, 3) == "DAM" || str.Substring(0, 3) == "SKL" || str.Substring(0, 3) == "SPS"))
                                    {
                                        seclength = 0xA8;
                                    }
                                }
                                if (seclength == 0xA8)
                                {
                                    FunctionDamageNameList.Add(Main.b_ReadString(PL_ANM_Section, totalsize + 0x48));
                                    DamageConditionList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x8C));
                                    DamageHitEffectList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x8A));
                                    DamageHorizontalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x94));
                                    DamageVerticalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0xA4));
                                    DamageValueList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x98));
                                    DamageHitCountList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x9C));
                                    DamageFreezeValueList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x9E));
                                    DamageHitFrequencyList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0xA0));
                                    DamageGuardValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                }
                                else
                                {
                                    FunctionDamageNameList.Add("");
                                    DamageConditionList.Add(0);
                                    DamageHitEffectList.Add(0);
                                    DamageHorizontalPushList.Add(0);
                                    DamageVerticalPushList.Add(0);
                                    DamageValueList.Add(0);
                                    DamageHitCountList.Add(0);
                                    DamageHitFrequencyList.Add(0);
                                    DamageFreezeValueList.Add(0);
                                    DamageGuardValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                }
                                totalsize = totalsize + seclength;
                                secCountForGen++;
                            }
                            animationName = Main.b_ReadString2(PL_ANM_Section, 0x20, 0x20);
                            PL_ANM_Name = Main.b_ReadString2(PL_ANM_Section, 0x00, 0x20);
                            PL_ANM_PREV_Name = Main.b_ReadString2(PL_ANM_Section, 0x64, 0x20);
                            PL_ANM_NEXT_Name = Main.b_ReadString2(PL_ANM_Section, 0x84, 0x20);
                            PL_ANM_DMG_Name = Main.b_ReadString2(PL_ANM_Section, 0xA4, 0x20);
                            ListPL_ANM_Names.Add(PL_ANM_Name);

                            frameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x44);
                            ID_PRMFile = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x46);
                            enableCubeMan = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x48);
                            enableFaceAnimation = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4A);
                            reverseEnemy = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4C);
                            noFrameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4E);
                            animationPositionFix = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x50);
                            directionCombo = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x58);
                            linkCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x5A);
                            playCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x5C);
                            startTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x5E);
                            endTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x60);
                            triggerState = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x62);
                            button4.Enabled = true;
                            textBox1.Text = PL_ANM_Name;
                            textBox3.Text = PL_ANM_NEXT_Name;
                            textBox2.Text = PL_ANM_PREV_Name;
                            textBox4.Text = PL_ANM_DMG_Name;
                            textBox7.Text = animationName;
                            numericUpDown1.Value = ID_PRMFile;
                            if (comboBox2.Text== "Naruto Storm 4")
                                GenerateStorm4Code();
                            if (comboBox2.Text== "JoJo ASBR")
                                GenerateJoJoASBRCode();
                            countOfAllMovementSections = secCountForGen;
                            countOfSection++;
                            if (PL_ANM_Section.Length - totalsize >= 0xC4)
                            {

                                byte[] Analysed_PL_ANM_Section = new byte[0];
                                Analysed_PL_ANM_Section = Main.b_AddBytes(Analysed_PL_ANM_Section, PL_ANM_Section, 0, totalsize);
                                PL_ANM_Section = Analysed_PL_ANM_Section;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    while (PL_ANM_Section.Length >= 0xC4);
                    if (countOfSection == 1)
                    {
                        countOfAllMovementSections = 0;
                        button4.Enabled = true;
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        textBox4.Enabled = true;
                        textBox7.Enabled = true;
                    }
                    else
                    {
                        button4.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        textBox7.Enabled = false;
                    }
                    
                }
                if (comboBox1.Text == "Naruto Storm Rev")
                {
                    byte[] PL_ANM_Section = Main.b_StringToBytes(textBox5.Text);
                    do
                    {
                        sectionCount = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x50);
                        if (PL_ANM_Section.Length >= 0xD4 + 0x40 * sectionCount)
                        {
                            int totalsize = 0xD4;
                            for (int i = 0; i < sectionCount; i++)
                            {
                                int seclength = 0x40;
                                int function = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x22);

                                FunctionTimingList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x20));
                                FunctionIDList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x22));
                                FunctionHitboxList.Add(Main.b_ReadString2(PL_ANM_Section, totalsize + 0x00));
                                FunctionParam1List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x24));
                                FunctionParam2List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x26));
                                FunctionParam3List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x28));
                                FunctionParam4List.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x2C));
                                FunctionParam5List.Add(0);
                                FunctionParam6List.Add(0);
                                
                                

                                switch (function)
                                {
                                    case 0x2D:
                                        if (totalsize + 0x40 < PL_ANM_Section.Length)
                                        {
                                            string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                            if (str == "SPSKILL_END") seclength = 0xA4;
                                        }
                                        break;
                                    case 0x20:
                                    case 0x22:
                                    case 0x24:
                                    case 0x26:
                                    case 0x28:
                                    case 0x34:
                                    case 0x95:
                                    case 0xB3:
                                    case 0xB5:
                                    case 0xD4:
                                    case 0xD6:
                                    case 0xD8:
                                        seclength = 0xA4;
                                        break;
                                    case 0x37:
                                    case 0x38:
                                    case 0x39:
                                    case 0x3A:
                                    case 0x3B:
                                    case 0x3C:
                                    case 0x3D:
                                    case 0xE4:
                                    case 0xE5:
                                        if (totalsize + 0x40 < PL_ANM_Section.Length)
                                        {
                                            string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                            if (str.Length >= 7 && str.Substring(0, 7) == "SKL_ATK") seclength = 0xA4;
                                        }
                                        break;
                                }
                                if (totalsize + 0x40 < PL_ANM_Section.Length)
                                {
                                    string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                    if (str.Length > 3 && (str.Substring(0, 3) == "DMG" || str.Substring(0, 3) == "DAM" || str.Substring(0, 3) == "SKL" || str.Substring(0, 3) == "SPS"))
                                    {
                                        seclength = 0xA4;
                                    }
                                }
                                if (seclength == 0xA4)
                                {
                                    FunctionDamageNameList.Add(Main.b_ReadString(PL_ANM_Section, totalsize + 0x40));
                                    DamageConditionList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x84));
                                    DamageHitEffectList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x82));
                                    DamageHorizontalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x8C));
                                    DamageVerticalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0xA0));
                                    DamageValueList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x90));
                                    DamageGuardValueList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x94));
                                    DamageHitCountList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x98));
                                    DamageFreezeValueList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x9A));
                                    DamageHitFrequencyList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x9C));
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                }
                                else
                                {
                                    FunctionDamageNameList.Add("");
                                    DamageGuardValueList.Add(0);
                                    DamageConditionList.Add(0);
                                    DamageHitEffectList.Add(0);
                                    DamageHorizontalPushList.Add(0);
                                    DamageVerticalPushList.Add(0);
                                    DamageValueList.Add(0);
                                    DamageHitCountList.Add(0);
                                    DamageHitFrequencyList.Add(0);
                                    DamageFreezeValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                }
                                totalsize = totalsize + seclength;
                                secCountForGen++;
                            }
                            animationName = Main.b_ReadString2(PL_ANM_Section, 0x20, 0x20);
                            PL_ANM_Name = Main.b_ReadString2(PL_ANM_Section, 0x00, 0x20);
                            PL_ANM_PREV_Name = Main.b_ReadString2(PL_ANM_Section, 0x74, 0x20);
                            PL_ANM_NEXT_Name = Main.b_ReadString2(PL_ANM_Section, 0x94, 0x20);
                            PL_ANM_DMG_Name = Main.b_ReadString2(PL_ANM_Section, 0xB4, 0x20);
                            ListPL_ANM_Names.Add(PL_ANM_Name);

                            frameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x54);
                            ID_PRMFile = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x56);
                            enableCubeMan = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x58);
                            enableFaceAnimation = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x5A);
                            reverseEnemy = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x5C);
                            noFrameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x5E);
                            animationPositionFix = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x60);
                            directionCombo = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x68);
                            linkCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x6A);
                            playCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x6C);
                            startTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x6E);
                            endTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x70);
                            triggerState = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x72);
                            button4.Enabled = true;
                            textBox1.Text = PL_ANM_Name;
                            textBox3.Text = PL_ANM_NEXT_Name;
                            textBox2.Text = PL_ANM_PREV_Name;
                            textBox4.Text = PL_ANM_DMG_Name;
                            textBox7.Text = animationName;
                            numericUpDown1.Value = ID_PRMFile;
                            if (comboBox2.Text== "Naruto Storm 4")
                                GenerateStorm4Code();
                            if (comboBox2.Text== "JoJo ASBR")
                                GenerateJoJoASBRCode();
                            countOfAllMovementSections = secCountForGen;
                            countOfSection++;
                            if (PL_ANM_Section.Length - totalsize >= 0xD4)
                            {

                                byte[] Analysed_PL_ANM_Section = new byte[0];
                                Analysed_PL_ANM_Section = Main.b_AddBytes(Analysed_PL_ANM_Section, PL_ANM_Section, 0, totalsize);
                                PL_ANM_Section = Analysed_PL_ANM_Section;
                            }
                            else
                            {
                                break;
                            }

                        }
                    }
                    while (PL_ANM_Section.Length >= 0xD4);
                    if (countOfSection == 1)
                    {
                        countOfAllMovementSections = 0;
                        button4.Enabled = true;
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        textBox4.Enabled = true;
                        textBox7.Enabled = true;
                    }
                    else
                    {
                        button4.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        textBox7.Enabled = false;
                    }
                    
                }
                if (comboBox1.Text == "JoJo EOH" || comboBox1.Text=="JoJo ASB")
                {
                    byte[] PL_ANM_Section = Main.b_StringToBytes(textBox5.Text);
                    do
                    {
                        sectionCount = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x6C);
                        if (PL_ANM_Section.Length >= 0x9C + 0xC0 * sectionCount)
                        {
                            int totalsize = 0x9C;
                            for (int i = 0; i < sectionCount; i++)
                            {
                                int seclength = 0xC0;
                                int function = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x34);

                                FunctionTimingList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x30));
                                FunctionIDList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x34));
                                FunctionHitboxList.Add(Main.b_ReadString2(PL_ANM_Section, totalsize + 0x08));
                                FunctionParam1List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x38));
                                FunctionParam2List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x3C));
                                FunctionParam3List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x40));
                                FunctionParam5List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x44));
                                FunctionParam6List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x48));
                                FunctionParam4List.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x4C));
                                if (comboBox1.Text == "JoJo EOH")
                                {
                                    
                                    switch (function)
                                    {
                                        case 0x1D:
                                        case 0x1F:
                                        case 0x21:
                                        case 0x23:
                                        case 0x25:
                                        case 0x95:
                                        case 0x12A:
                                            seclength = 0x298;
                                            break;
                                        case 0x33:
                                        case 0x35:
                                        case 0x36:
                                        case 0x38:
                                            if (totalsize + 0xC0 < PL_ANM_Section.Length)
                                            {
                                                string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0xC0);
                                                if (str.Length >= 7 && str.Substring(0, 7) == "SKL_ATK") seclength = 0x298;
                                            }
                                            break;
                                    }
                                }
                                if (comboBox1.Text == "JoJo ASB")
                                {
                                    switch (function)
                                    {
                                        case 0x20:
                                        case 0x22:
                                        case 0x24:
                                        case 0x26:
                                        case 0x28:
                                        case 0x30:
                                            seclength = 0x298;
                                            break;
                                        case 0x35:
                                        case 0x36:
                                        case 0x37:
                                        case 0x38:
                                            if (totalsize + 0xC0 < PL_ANM_Section.Length)
                                            {
                                                string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0xC0);
                                                if (str.Length >= 7 && str.Substring(0, 7) == "SKL_ATK") seclength = 0x298;
                                            }
                                            break;
                                    }
                                }
                                if (totalsize + 0xC0 < PL_ANM_Section.Length)
                                {
                                    string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0xC0);
                                    if (str.Length > 3 && (str.Substring(0, 3) == "DMG" || str.Substring(0, 3) == "DAM" || str.Substring(0, 3) == "SKL" || str.Substring(0, 3) == "SPS"))
                                    {
                                        seclength = 0x298;
                                    }
                                }
                                if (seclength == 0x298)
                                {
                                    FunctionDamageNameList.Add(Main.b_ReadString(PL_ANM_Section, totalsize + 0xD0));
                                    DamageConditionList.Add(0);
                                    DamageHitEffectList.Add(1);
                                    DamageHorizontalPushList.Add(1);
                                    DamageVerticalPushList.Add(1);
                                    DamageValueList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x11C));
                                    DamageHitCountList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x140));
                                    DamageFreezeValueList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x148));
                                    DamageHitFrequencyList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x144));
                                    DamageGuardValueList.Add(0);
                                    DamageListEOH.Add(Main.b_ReadByteArray(PL_ANM_Section, totalsize + 0xC0, 0x1D8));
                                }
                                else
                                {
                                    FunctionDamageNameList.Add("");
                                    DamageConditionList.Add(0);
                                    DamageHitEffectList.Add(0);
                                    DamageHorizontalPushList.Add(0);
                                    DamageVerticalPushList.Add(0);
                                    DamageValueList.Add(0);
                                    DamageHitCountList.Add(0);
                                    DamageHitFrequencyList.Add(0);
                                    DamageFreezeValueList.Add(0);
                                    DamageGuardValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                }
                                totalsize = totalsize + seclength;
                                secCountForGen++;
                            }
                            animationName = Main.b_ReadString2(PL_ANM_Section, 0x20, 0x20);
                            PL_ANM_Name = Main.b_ReadString2(PL_ANM_Section, 0x00, 0x20);
                            PL_ANM_PREV_Name = "";
                            PL_ANM_NEXT_Name = "";
                            PL_ANM_DMG_Name = "";
                            ListPL_ANM_Names.Add(PL_ANM_Name);

                            frameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x58);
                            ID_PRMFile = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x70);
                            enableCubeMan = 0;
                            enableFaceAnimation = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x40);
                            reverseEnemy = 0;
                            noFrameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x48);
                            animationPositionFix = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x4C);
                            directionCombo = 1;
                            linkCondition = 0;
                            playCondition = 0;
                            startTime = 0;
                            endTime = 0;
                            triggerState = 0;
                            button4.Enabled = true;
                            textBox1.Text = PL_ANM_Name;
                            textBox3.Text = PL_ANM_NEXT_Name;
                            textBox2.Text = PL_ANM_PREV_Name;
                            textBox4.Text = PL_ANM_DMG_Name;
                            textBox7.Text = animationName;
                            numericUpDown1.Value = ID_PRMFile;
                            if (comboBox2.Text== "Naruto Storm 4")
                                GenerateStorm4Code();
                            if (comboBox2.Text== "JoJo ASBR")
                                GenerateJoJoASBRCode();
                            countOfAllMovementSections = secCountForGen;
                            countOfSection++;
                            if (PL_ANM_Section.Length - totalsize >= 0x9C)
                            {

                                byte[] Analysed_PL_ANM_Section = new byte[0];
                                Analysed_PL_ANM_Section = Main.b_AddBytes(Analysed_PL_ANM_Section, PL_ANM_Section, 0, totalsize);
                                PL_ANM_Section = Analysed_PL_ANM_Section;
                            }
                            else
                            {
                                break;
                            }

                        }
                    }
                    while (PL_ANM_Section.Length >= 0x9C);
                    if (countOfSection == 1)
                    {
                        countOfAllMovementSections = 0;
                        button4.Enabled = true;
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        textBox4.Enabled = true;
                        textBox7.Enabled = true;
                    }
                    else
                    {
                        button4.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        textBox7.Enabled = false;
                    }
                    
                }
                if (comboBox1.Text == "Naruto Storm 4") {
                    byte[] PL_ANM_Section = Main.b_StringToBytes(textBox5.Text);
                    do {
                        sectionCount = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x50);
                        if (PL_ANM_Section.Length >= 0xD4 + 0x40 * sectionCount) {
                            int totalsize = 0xD4;
                            for (int i = 0; i < sectionCount; i++) {
                                int seclength = 0x40;
                                int function = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x22);

                                FunctionTimingList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x20));
                                FunctionIDList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x22));
                                FunctionHitboxList.Add(Main.b_ReadString2(PL_ANM_Section, totalsize + 0x00));
                                FunctionParam1List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x24));
                                FunctionParam2List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x26));
                                FunctionParam3List.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x28));
                                FunctionParam4List.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x2C));
                                FunctionParam5List.Add(0);
                                FunctionParam6List.Add(0);
                                switch (function) {
                                    case 0x83:
                                        if (totalsize + 0x40 < PL_ANM_Section.Length) {
                                            string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                            if (str == "SPSKILL_END") seclength = 0xA0;
                                        }
                                        break;
                                    case 0x8A:
                                    case 0xC1:
                                    case 0xC3:
                                    case 0xC6:
                                    case 0xC8:
                                    case 0xCA:
                                    case 0xD1:
                                    case 0xD3:
                                    case 0xD5:
                                    case 0xD7:
                                    case 0xD9:
                                        seclength = 0xA0;
                                        break;
                                    case 0xA0:
                                    case 0xA1:
                                    case 0xA2:
                                    case 0xA3:
                                    case 0xA4:
                                    case 0xA5:
                                    case 0xA6:
                                        if (totalsize + 0x40 < PL_ANM_Section.Length) {
                                            string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                            if (str.Length >= 7 && str.Substring(0, 7) == "SKL_ATK") seclength = 0xA0;
                                        }
                                        break;
                                }
                                
                                if (totalsize + 0x40 < PL_ANM_Section.Length) {
                                    string str = Main.b_ReadString(PL_ANM_Section, totalsize + 0x40);
                                    if (str.Length > 3 && (str.Substring(0, 3) == "DMG" || str.Substring(0, 3) == "DAM" || str.Substring(0, 3) == "SKL" || str.Substring(0, 3) == "SPS")) {
                                        seclength = 0xA0;
                                    }
                                }
                                if (seclength == 0xA0) {
                                    FunctionDamageNameList.Add(Main.b_ReadString(PL_ANM_Section, totalsize + 0x40));
                                    DamageConditionList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x86));
                                    DamageHitEffectList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x82));
                                    DamageHorizontalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x90));
                                    DamageVerticalPushList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x94));
                                    DamageValueList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x88));
                                    DamageGuardValueList.Add(Main.b_ReadFloat(PL_ANM_Section, totalsize + 0x8C));
                                    DamageHitCountList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x98));
                                    DamageFreezeValueList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x9A));
                                    DamageHitFrequencyList.Add(Main.b_ReadIntFromTwoBytes(PL_ANM_Section, totalsize + 0x9C));
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                } else {
                                    FunctionDamageNameList.Add("");
                                    DamageGuardValueList.Add(0);
                                    DamageConditionList.Add(0);
                                    DamageHitEffectList.Add(0);
                                    DamageHorizontalPushList.Add(0);
                                    DamageVerticalPushList.Add(0);
                                    DamageValueList.Add(0);
                                    DamageHitCountList.Add(0);
                                    DamageHitFrequencyList.Add(0);
                                    DamageFreezeValueList.Add(0);
                                    DamageListEOH.Add(BitConverter.GetBytes(0));
                                }
                                totalsize = totalsize + seclength;
                                secCountForGen++;
                            }
                            animationName = Main.b_ReadString2(PL_ANM_Section, 0x20, 0x20);
                            PL_ANM_Name = Main.b_ReadString2(PL_ANM_Section, 0x00, 0x20);
                            PL_ANM_PREV_Name = Main.b_ReadString2(PL_ANM_Section, 0x74, 0x20);
                            PL_ANM_NEXT_Name = Main.b_ReadString2(PL_ANM_Section, 0x94, 0x20);
                            PL_ANM_DMG_Name = Main.b_ReadString2(PL_ANM_Section, 0xB4, 0x20);
                            ListPL_ANM_Names.Add(PL_ANM_Name);

                            frameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x54);
                            ID_PRMFile = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x56);
                            enableCubeMan = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x58);
                            enableFaceAnimation = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x5A);
                            reverseEnemy = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x5C);
                            noFrameSkip = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x5E);
                            animationPositionFix = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x60);
                            directionCombo = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x68);
                            linkCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x6A);
                            playCondition = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x6C);
                            startTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x6E);
                            endTime = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x70);
                            triggerState = Main.b_ReadIntFromTwoBytes(PL_ANM_Section, 0x72);
                            button4.Enabled = true;
                            textBox1.Text = PL_ANM_Name;
                            textBox3.Text = PL_ANM_NEXT_Name;
                            textBox2.Text = PL_ANM_PREV_Name;
                            textBox4.Text = PL_ANM_DMG_Name;
                            textBox7.Text = animationName;
                            numericUpDown1.Value = ID_PRMFile;
                            if (comboBox2.Text == "Naruto Storm 4")
                                GenerateStorm4Code();
                            if (comboBox2.Text == "JoJo ASBR")
                                GenerateJoJoASBRCode();
                            countOfAllMovementSections = secCountForGen;
                            countOfSection++;
                            if (PL_ANM_Section.Length - totalsize >= 0xD4) {

                                byte[] Analysed_PL_ANM_Section = new byte[0];
                                Analysed_PL_ANM_Section = Main.b_AddBytes(Analysed_PL_ANM_Section, PL_ANM_Section, 0, totalsize);
                                PL_ANM_Section = Analysed_PL_ANM_Section;
                            } else {
                                break;
                            }

                        }
                    }
                    while (PL_ANM_Section.Length >= 0xD4);
                    if (countOfSection == 1) {
                        countOfAllMovementSections = 0;
                        button4.Enabled = true;
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        textBox4.Enabled = true;
                        textBox7.Enabled = true;
                    } else {
                        button4.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        textBox7.Enabled = false;
                    }

                }

                
            }
            else
            {
                MessageBox.Show("Put code into textbox");
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PRMEditorInfo t = new PRMEditorInfo();
            t.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                Clipboard.SetText(textBox6.Text);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Naruto Storm 1" || comboBox1.Text == "JoJo EOH" || comboBox1.Text == "JoJo ASB")
            {
                MessageBox.Show("This porting tool is experimental! Some link conditions will not ported. This tool will work perfectly with regular combo. For jutsus you have to link everything yourself!");
            }
        }

        private void GenerateStorm4Code()
        {
            List<string> SkippedFunctions = new List<string>();
            byte[] S4_GeneratedCode = new byte[0xD4];
            //names
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, Encoding.ASCII.GetBytes(PL_ANM_Name),0x00);
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, Encoding.ASCII.GetBytes(animationName), 0x20);
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, Encoding.ASCII.GetBytes(PL_ANM_PREV_Name), 0x74);
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, Encoding.ASCII.GetBytes(PL_ANM_NEXT_Name), 0x94);
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, Encoding.ASCII.GetBytes(PL_ANM_DMG_Name), 0xB4);
            int newSectionCount = sectionCount;
            bool codeWasRemoved = false;
            //skip frame
            byte[] sectionBytes = BitConverter.GetBytes(frameSkip);
            byte[] usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x54);
            //version/load bit
            sectionBytes = BitConverter.GetBytes(ID_PRMFile);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x56);
            //cube man
            sectionBytes = BitConverter.GetBytes(enableCubeMan);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x58);
            //face anims
            sectionBytes = BitConverter.GetBytes(enableFaceAnimation);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x5A);
            //turn around
            sectionBytes = BitConverter.GetBytes(reverseEnemy);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x5C);
            //no Frame Skip
            sectionBytes = BitConverter.GetBytes(noFrameSkip);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x5E);
            //animation position fix
            sectionBytes = BitConverter.GetBytes(animationPositionFix);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x60);

            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, new byte[6] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, 0x62);

            //Direction of combo
            sectionBytes = BitConverter.GetBytes(directionCombo);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x68);
            //Link condition
            sectionBytes = BitConverter.GetBytes(linkCondition);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x6A);
            //play condition
            int trigger = 0;
            if (comboBox1.Text == "Naruto Storm 1" || comboBox1.Text == "Naruto Storm 2/Gen" || comboBox1.Text == "Hack Versus")
            {
                
                switch (playCondition)
                {
                    case 0x03:
                        trigger = 0x04;
                        break;
                    case 0x06:
                        trigger = 0x03;
                        break;
                    case 0x05:
                        trigger = 0x02;
                        break;
                }
            }
            else
            {
                trigger = playCondition;
            }
            sectionBytes = BitConverter.GetBytes(trigger);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x6C);
            //start time
            if (checkBox4.Checked == true) {
                if (startTime == 0 && endTime == 0) {
                    startTime = 0xFFFF;
                    endTime = 0xFFFF;
                }
            }
            sectionBytes = BitConverter.GetBytes(startTime);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x6E);
            //end time
            sectionBytes = BitConverter.GetBytes(endTime);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x70);
            //trigger
            sectionBytes = BitConverter.GetBytes(triggerState);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x72);
            for (int i=0; i< sectionCount;i++)
            {
                byte[] FunctionSection = new byte[0x40];
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, Encoding.ASCII.GetBytes(FunctionHitboxList[countOfAllMovementSections + i]), 0x00);
                //Timing
                sectionBytes = BitConverter.GetBytes(FunctionTimingList[countOfAllMovementSections+i]);
                usedBytes = new byte[2]
                {
                    sectionBytes[0],
                    sectionBytes[1]
                };
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, usedBytes, 0x20);
                //Function
                int portedFunction = -1;
                string nameOfFunction = "";
                if (comboBox1.Text == "Naruto Storm 1")
                    nameOfFunction = Program.ME_S1_LIST[FunctionIDList[countOfAllMovementSections + i]];
                else if (comboBox1.Text == "Naruto Storm 2/Gen")
                    nameOfFunction = Program.ME_S2_SG_LIST[FunctionIDList[countOfAllMovementSections + i]];
                else if (comboBox1.Text == "Hack Versus")
                    nameOfFunction = Program.ME_HACK_VERSUS_LIST[FunctionIDList[countOfAllMovementSections + i]];
                else if (comboBox1.Text == "Naruto Storm 3 old" || comboBox1.Text == "Naruto Storm 3 HD" || comboBox1.Text == "Naruto Storm Rev")
                    nameOfFunction = Program.ME_REV_S3_LIST[FunctionIDList[countOfAllMovementSections + i]];
                else if (comboBox1.Text == "JoJo EOH")
                    nameOfFunction = Program.ME_JOJO_EOH_LIST[FunctionIDList[countOfAllMovementSections + i]];
                else if (comboBox1.Text == "JoJo ASB")
                    nameOfFunction = Program.ME_JOJO_ASB_LIST[FunctionIDList[countOfAllMovementSections + i]];

                for (int j=0; j<Program.ME_LIST.Length;j++)
                {
                    if (Program.ME_LIST[j] == nameOfFunction)
                        portedFunction = j;
                }
//--------------------------------------------SOUND REMOVER---------------------------------------------------------------------
                if (removeSoundSection)
                {
                    int functionSound = FunctionIDList[countOfAllMovementSections + i];
                    if (comboBox1.Text == "Naruto Storm 1")
                    {
                        if (functionSound == 0x26 || functionSound == 0x4F || functionSound == 0x67)
                            portedFunction = -1;
                    }
                    else if (comboBox1.Text == "Naruto Storm 2/Gen")
                    {
                        if (functionSound == 0x65 || functionSound == 0x66 || functionSound == 0x67 || functionSound == 0x68 || functionSound == 0x97)
                            portedFunction = -1;
                    }
                    else if (comboBox1.Text == "Hack Versus")
                    {
                        
                    }
                    else if (comboBox1.Text == "Naruto Storm 3 old" || comboBox1.Text == "Naruto Storm 3 HD" || comboBox1.Text == "Naruto Storm Rev")
                    {
                        if (functionSound == 0x7C || functionSound == 0x7D || functionSound == 0x7E || functionSound == 0x7F || functionSound == 0x80 || functionSound == 0x81 || functionSound == 0x82)
                            portedFunction = -1;
                    }
                    else if (comboBox1.Text == "JoJo EOH")
                    {
                        if (functionSound == 0xF1 || functionSound == 0x128)
                            portedFunction = -1;
                    }
                    else if (comboBox1.Text == "JoJo ASB")
                    {
                        if (functionSound == 0x7D || functionSound == 0x7E || functionSound == 0x7F || functionSound == 0x80 || functionSound == 0x81 || functionSound == 0xD5)
                            portedFunction = -1;
                    }
                }
//--------------------------------------------BG REMOVER---------------------------------------------------------------------
                if (checkBox3.Checked) {
                    int functionSound = FunctionIDList[countOfAllMovementSections + i];
                    if (comboBox1.Text == "Naruto Storm 2/Gen") {
                        if (functionSound == 0x57 || functionSound == 0x56)
                            portedFunction = -1;
                    } else if (comboBox1.Text == "Hack Versus") {
                        if (functionSound == 0x7B || functionSound == 0x7C)
                            portedFunction = -1;
                    } else if (comboBox1.Text == "Naruto Storm 3 old" || comboBox1.Text == "Naruto Storm 3 HD" || comboBox1.Text == "Naruto Storm Rev") {
                        if (functionSound == 0x6D || functionSound == 0x6E)
                            portedFunction = -1;
                    } else if (comboBox1.Text == "JoJo EOH") {
                        if (functionSound == 0xE3 || functionSound == 0xE4)
                            portedFunction = -1;
                    } else if (comboBox1.Text == "JoJo ASB") {
                        if (functionSound == 0x6F || functionSound == 0x70 )
                            portedFunction = -1;
                    }
                }
//--------------------------------------------------------------------------------------------------------------------------------
                sectionBytes = BitConverter.GetBytes(portedFunction);
                usedBytes = new byte[2]
                {
                    sectionBytes[0],
                    sectionBytes[1]
                };
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, usedBytes, 0x22);
                //Param 1
                sectionBytes = BitConverter.GetBytes(FunctionParam1List[countOfAllMovementSections + i]);
                usedBytes = new byte[2]
                {
                    sectionBytes[0],
                    sectionBytes[1]
                };
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, usedBytes, 0x24);
                //Param 2
                sectionBytes = BitConverter.GetBytes(FunctionParam2List[countOfAllMovementSections + i]);
                usedBytes = new byte[2]
                {
                    sectionBytes[0],
                    sectionBytes[1]
                };
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, usedBytes, 0x26);
                //Param 3
                sectionBytes = BitConverter.GetBytes(FunctionParam3List[countOfAllMovementSections + i]);
                usedBytes = new byte[2]
                {
                    sectionBytes[0],
                    sectionBytes[1]
                };
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, usedBytes, 0x28);
                //Param 4
                sectionBytes = BitConverter.GetBytes(FunctionParam4List[countOfAllMovementSections + i]);
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, sectionBytes, 0x2C);
                int function = FunctionIDList[countOfAllMovementSections + i];
                if (comboBox1.Text == "Naruto Storm 1")
                {
                    if (function == 0x09 || function == 0x30 || function == 0x32 || function == 0x34 || function == 0x36 || function == 0x3B || FunctionDamageNameList[countOfAllMovementSections + i] !="")
                    {
                        byte[] DamagePart = new byte[0x60];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x00);
                        //Hit effect
                        sectionBytes = BitConverter.GetBytes(DamageHitEffectList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x42);
                        //skipped (sound effect)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0xFF, 0xFF }, 0x44);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x48);
                        //skipped (damage to guard)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[4] { 0x00, 0x00, 0x80, 0xBF }, 0x4C);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x50);
                        //skipped (Vertical push)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[4] { 0x00, 0x00, 0x80, 0x3F }, 0x54);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x58);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5A);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }
                    
                    
                }
                else if (comboBox1.Text == "Naruto Storm 2/Gen")
                {
                    if (function == 0x17 || function == 0x19 || function == 0x1F || function == 0x2D || function == 0x74 || FunctionDamageNameList[countOfAllMovementSections + i] != "")
                    {
                        byte[] DamagePart = new byte[0x60];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x00);
                        //Hit effect
                        sectionBytes = BitConverter.GetBytes(DamageHitEffectList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x42);
                        //skipped (sound effect)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0xFF, 0xFF }, 0x44);
                        //Damage condition
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageConditionList[countOfAllMovementSections + i]), 0x46);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x48);
                        //skipped (damage to guard)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[4] { 0x00, 0x00, 0x80, 0xBF }, 0x4C);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x50);
                        //skipped (Vertical push)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageVerticalPushList[countOfAllMovementSections + i]), 0x54);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x58);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5A);
                        //Freeze
                        sectionBytes = BitConverter.GetBytes(DamageFreezeValueList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5C);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }
                }
                else if (comboBox1.Text == "Hack Versus")
                {
                    if (function == 0x12 || function == 0x14 || function == 0x16 || function == 0x18 || function == 0x1A || function == 0x1E || FunctionDamageNameList[countOfAllMovementSections + i] != "")
                    {
                        byte[] DamagePart = new byte[0x60];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x00);
                        //Hit effect
                        sectionBytes = BitConverter.GetBytes(DamageHitEffectList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x42);
                        //skipped (sound effect)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0xFF, 0xFF }, 0x44);
                        //Damage condition
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageConditionList[countOfAllMovementSections + i]), 0x46);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x48);
                        //skipped (damage to guard)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[4] { 0x00, 0x00, 0x80, 0xBF }, 0x4C);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x50);
                        //skipped (Vertical push)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageVerticalPushList[countOfAllMovementSections + i]), 0x54);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x58);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5A);
                        //Freeze
                        sectionBytes = BitConverter.GetBytes(DamageFreezeValueList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5C);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }
                }
                else if (comboBox1.Text == "Naruto Storm 3 old" || comboBox1.Text == "Naruto Storm 3 HD")
                {
                    
                    if (function == 0x20 || function == 0x22 || function == 0x24 || function == 0x26 || function == 0x28 || function == 0x34 || function == 0xB3 || function == 0xB5 || function == 0x95 || FunctionDamageNameList[countOfAllMovementSections + i] != "")
                    {
                        byte[] DamagePart = new byte[0x60];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x00);
                        //Hit effect
                        sectionBytes = BitConverter.GetBytes(DamageHitEffectList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x42);
                        //skipped (sound effect)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0xFF, 0xFF }, 0x44);
                        //Damage condition
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageConditionList[countOfAllMovementSections + i]), 0x46);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x48);
                        //skipped (damage to guard)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[4] { 0x00, 0x00, 0x80, 0xBF }, 0x4C);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x50);
                        //Vertical push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageVerticalPushList[countOfAllMovementSections + i]), 0x54);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x58);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5A);
                        //Freeze
                        sectionBytes = BitConverter.GetBytes(DamageFreezeValueList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5C);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }
                }
                else if (comboBox1.Text == "Naruto Storm Rev")
                {

                    if (function == 0x20 || function == 0x22 || function == 0x24 || function == 0x26 || function == 0x28 || function == 0x34 || function == 0xB3 || function == 0xB5 || function == 0x95 || function == 0xD4 || function == 0xD6 || function == 0xD8 || FunctionDamageNameList[countOfAllMovementSections + i] != "")
                    {
                        byte[] DamagePart = new byte[0x60];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x00);
                        //Hit effect
                        sectionBytes = BitConverter.GetBytes(DamageHitEffectList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x42);
                        //skipped (sound effect)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0xFF, 0xFF }, 0x44);
                        //Damage condition
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageConditionList[countOfAllMovementSections + i]), 0x46);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x48);
                        //damage to guard
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageGuardValueList[countOfAllMovementSections + i]), 0x4C);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x50);
                        //Vertical push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageVerticalPushList[countOfAllMovementSections + i]), 0x54);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x58);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5A);
                        //Freeze
                        sectionBytes = BitConverter.GetBytes(DamageFreezeValueList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5C);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }
                    
                }
                else if (comboBox1.Text == "JoJo EOH")
                {

                    if (function == 0x1D || function == 0x1F || function == 0x21 || function == 0x23 || function == 0x25 || function == 0x95 || function == 0x12A || FunctionDamageNameList[countOfAllMovementSections + i] != "")
                    {
                        byte[] DamagePart = new byte[0x60];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x00);
                        //Hit effect
                        sectionBytes = BitConverter.GetBytes(DamageHitEffectList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x42);
                        //skipped (sound effect)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0xFF, 0xFF }, 0x44);
                        //Damage condition
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageConditionList[countOfAllMovementSections + i]), 0x46);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x48);
                        //skipped (damage to guard)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[4] { 0x00, 0x00, 0x80, 0xBF }, 0x4C);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x50);
                        //Vertical push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageVerticalPushList[countOfAllMovementSections + i]), 0x54);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x58);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5A);
                        //Freeze
                        sectionBytes = BitConverter.GetBytes(DamageFreezeValueList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5C);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }
                }
                else if (comboBox1.Text == "JoJo ASB")
                {
                    if (function == 0x20 || function == 0x22 || function == 0x24 || function == 0x26 || function == 0x28 || function == 0x30 || FunctionDamageNameList[countOfAllMovementSections + i] != "")
                    {
                        byte[] DamagePart = new byte[0x60];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x00);
                        //Hit effect
                        sectionBytes = BitConverter.GetBytes(DamageHitEffectList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x42);
                        //skipped (sound effect)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0xFF, 0xFF }, 0x44);
                        //Damage condition
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageConditionList[countOfAllMovementSections + i]), 0x46);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x48);
                        //skipped (damage to guard)
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[4] { 0x00, 0x00, 0x80, 0xBF }, 0x4C);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x50);
                        //Vertical push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageVerticalPushList[countOfAllMovementSections + i]), 0x54);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x58);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5A);
                        //Freeze
                        sectionBytes = BitConverter.GetBytes(DamageFreezeValueList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x5C);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }
                }
                if (portedFunction != -1)
                {
                    S4_GeneratedCode = Main.b_AddBytes(S4_GeneratedCode, FunctionSection);
                }
                else
                {
                    newSectionCount--;
                    bool skip = false;
                    if (SkippedFunctions.Count>=1)
                    {
                        for (int c = 0; c < SkippedFunctions.Count; c++)
                        {
                            if (SkippedFunctions[c] == function.ToString("X2"))
                            {
                                skip = true;
                            }
                        }
                    }
                    if (!skip)
                    {
                        SkippedFunctions.Add(function.ToString("X2"));
                    }
                    
                    if (codeWasRemoved == false)
                    {
                        if (comboBox1.Text == "Naruto Storm 1")
                        {
                            if (function == 0x26 || function == 0x4F || function == 0x67)
                                codeWasRemoved = false;
                            else
                                codeWasRemoved = true;
                        }
                        else if (comboBox1.Text == "Naruto Storm 2/Gen")
                        {
                            if (function == 0x65 || function == 0x66 || function == 0x67 || function == 0x68 || function == 0x97)
                                codeWasRemoved = false;
                            else
                                codeWasRemoved = true;
                        }
                        else if (comboBox1.Text == "Naruto Storm 3 old" || comboBox1.Text == "Naruto Storm 3 HD" || comboBox1.Text == "Naruto Storm Rev")
                        {
                            if (function == 0x7C || function == 0x7D || function == 0x7E || function == 0x7F || function == 0x80 || function == 0x81 || function == 0x82)
                                codeWasRemoved = false;
                            else
                                codeWasRemoved = true;
                        }
                        else if (comboBox1.Text == "JoJo EOH")
                        {
                            if (function == 0xF1 || function == 0x128)
                                codeWasRemoved = false;
                            else
                                codeWasRemoved = true;
                        }
                        else if (comboBox1.Text == "JoJo ASB")
                        {
                            if (function == 0x7D || function == 0x7E || function == 0x7F || function == 0x80 || function == 0x81 || function == 0xD5)
                                codeWasRemoved = false;
                            else
                                codeWasRemoved = true;
                        }
                        else if (comboBox1.Text == "Hack Versus")
                        {
                            codeWasRemoved = true;
                        }
                    }    
                }
                    
            }
            //section count
            sectionBytes = BitConverter.GetBytes(newSectionCount);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            S4_GeneratedCode = Main.b_ReplaceBytes(S4_GeneratedCode, usedBytes, 0x50);
            ConvertedSection = S4_GeneratedCode;
            string code = "";
            for (int i=0; i< S4_GeneratedCode.Length; i++)
            {
                code = code + S4_GeneratedCode[i].ToString("X2") + " ";
            }
            textBox6.Text = textBox6.Text+code;
            string listFunc = "";
            for (int i=0;i< SkippedFunctions.Count; i++)
            {
                listFunc = listFunc + SkippedFunctions[i] + ", ";
            }
            if (codeWasRemoved && checkBox2.Checked==true)
            {
                string test = "Some sections were removed cuz they had unknown functions:\n\n" + listFunc + "\n\nIf you know what values can be used on place of skipped, share info in modding group!";
                MessageBox.Show(test);
            }
                
            if(ConvertedSection.Length != 0 && PRMFileOpened == true)
            {
                button2.Enabled = true;
            }
            MessageBox.Show("Code was generated!");
        }

        private void GenerateJoJoASBRCode() {
            List<string> SkippedFunctions = new List<string>();
            byte[] JoJoASBR_GeneratedCode = new byte[0x9C];
            //names
            JoJoASBR_GeneratedCode = Main.b_ReplaceBytes(JoJoASBR_GeneratedCode, Encoding.ASCII.GetBytes(PL_ANM_Name), 0x00);
            JoJoASBR_GeneratedCode = Main.b_ReplaceBytes(JoJoASBR_GeneratedCode, Encoding.ASCII.GetBytes(animationName), 0x20);
            int newSectionCount = sectionCount;
            bool codeWasRemoved = false;
            //skip frame
            byte[] sectionBytes = BitConverter.GetBytes(frameSkip);
            byte[] usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            JoJoASBR_GeneratedCode = Main.b_ReplaceBytes(JoJoASBR_GeneratedCode, usedBytes, 0x44);
            //cube man
            sectionBytes = BitConverter.GetBytes(enableCubeMan);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            JoJoASBR_GeneratedCode = Main.b_ReplaceBytes(JoJoASBR_GeneratedCode, usedBytes, 0x4C);
            //face anims
            sectionBytes = BitConverter.GetBytes(enableFaceAnimation);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            JoJoASBR_GeneratedCode = Main.b_ReplaceBytes(JoJoASBR_GeneratedCode, usedBytes, 0x70);

            JoJoASBR_GeneratedCode = Main.b_ReplaceBytes(JoJoASBR_GeneratedCode, new byte[8] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, 0x5C);

            for (int i = 0; i < sectionCount; i++) {
                byte[] FunctionSection = new byte[0xC8];
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, Encoding.ASCII.GetBytes(FunctionHitboxList[countOfAllMovementSections + i]), 0x08);
                //Timing
                sectionBytes = BitConverter.GetBytes(FunctionTimingList[countOfAllMovementSections + i]);
                usedBytes = new byte[2]
                {
                    sectionBytes[0],
                    sectionBytes[1]
                };
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, usedBytes, 0x30);
                //Function
                int portedFunction = -1;
                string nameOfFunction = "";
                if (comboBox1.Text == "Naruto Storm 1")
                    nameOfFunction = Program.ME_S1_LIST[FunctionIDList[countOfAllMovementSections + i]];
                else if (comboBox1.Text == "Naruto Storm 2/Gen")
                    nameOfFunction = Program.ME_S2_SG_LIST[FunctionIDList[countOfAllMovementSections + i]];
                else if (comboBox1.Text == "Hack Versus")
                    nameOfFunction = Program.ME_HACK_VERSUS_LIST[FunctionIDList[countOfAllMovementSections + i]];
                else if (comboBox1.Text == "Naruto Storm 3 old" || comboBox1.Text == "Naruto Storm 3 HD" || comboBox1.Text == "Naruto Storm Rev")
                    nameOfFunction = Program.ME_REV_S3_LIST[FunctionIDList[countOfAllMovementSections + i]];
                else if (comboBox1.Text == "JoJo EOH")
                    nameOfFunction = Program.ME_JOJO_EOH_LIST[FunctionIDList[countOfAllMovementSections + i]];
                else if (comboBox1.Text == "Naruto Storm 4")
                    nameOfFunction = Program.ME_LIST[FunctionIDList[countOfAllMovementSections + i]];
                for (int j = 0; j < Program.ME_JOJO_ASBR_LIST.Length; j++) {
                    if (Program.ME_JOJO_ASBR_LIST[j] == nameOfFunction)
                        portedFunction = j;
                }
                //--------------------------------------------SOUND REMOVER---------------------------------------------------------------------
                if (removeSoundSection) {
                    int functionSound = FunctionIDList[countOfAllMovementSections + i];
                    if (comboBox1.Text == "Naruto Storm 1") {
                        if (functionSound == 0x26 || functionSound == 0x4F || functionSound == 0x67)
                            portedFunction = -1;
                    } else if (comboBox1.Text == "Naruto Storm 2/Gen") {
                        if (functionSound == 0x65 || functionSound == 0x66 || functionSound == 0x67 || functionSound == 0x68 || functionSound == 0x97)
                            portedFunction = -1;
                    } else if (comboBox1.Text == "Hack Versus") {

                    } else if (comboBox1.Text == "Naruto Storm 3 old" || comboBox1.Text == "Naruto Storm 3 HD" || comboBox1.Text == "Naruto Storm Rev") {
                        if (functionSound == 0x7C || functionSound == 0x7D || functionSound == 0x7E || functionSound == 0x7F || functionSound == 0x80 || functionSound == 0x81 || functionSound == 0x82)
                            portedFunction = -1;
                    } else if (comboBox1.Text == "JoJo EOH") {
                        if (functionSound == 0xF1 || functionSound == 0x128)
                            portedFunction = -1;
                    } else if (comboBox1.Text == "Naruto Storm 4") {
                        if (functionSound == 0x8D || functionSound == 0x8E || functionSound == 0x8F || functionSound == 0x90 || functionSound == 0x91 || functionSound == 0x92 || functionSound == 0x93)
                            portedFunction = -1;
                    }
                }
                //--------------------------------------------BG REMOVER---------------------------------------------------------------------
                if (checkBox3.Checked) {
                    int functionSound = FunctionIDList[countOfAllMovementSections + i];
                    if (comboBox1.Text == "Naruto Storm 2/Gen") {
                        if (functionSound == 0x57 || functionSound == 0x56)
                            portedFunction = -1;
                    } else if (comboBox1.Text == "Hack Versus") {
                        if (functionSound == 0x7B || functionSound == 0x7C)
                            portedFunction = -1;
                    } else if (comboBox1.Text == "Naruto Storm 3 old" || comboBox1.Text == "Naruto Storm 3 HD" || comboBox1.Text == "Naruto Storm Rev") {
                        if (functionSound == 0x6D || functionSound == 0x6E)
                            portedFunction = -1;
                    } else if (comboBox1.Text == "JoJo EOH") {
                        if (functionSound == 0xE3 || functionSound == 0xE4)
                            portedFunction = -1;
                    } else if (comboBox1.Text == "Naruto Storm 4") {
                        if (functionSound == 0xB0 || functionSound == 0xB1)
                            portedFunction = -1;
                    }
                }
                //--------------------------------------------------------------------------------------------------------------------------------
                sectionBytes = BitConverter.GetBytes(portedFunction);
                usedBytes = new byte[2]
                {
                    sectionBytes[0],
                    sectionBytes[1]
                };
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, usedBytes, 0x34);
                //Param 1
                sectionBytes = BitConverter.GetBytes(FunctionParam1List[countOfAllMovementSections + i]);
                usedBytes = new byte[2]
                {
                    sectionBytes[0],
                    sectionBytes[1]
                };
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, usedBytes, 0x38);
                //Param 2
                sectionBytes = BitConverter.GetBytes(FunctionParam2List[countOfAllMovementSections + i]);
                usedBytes = new byte[2]
                {
                    sectionBytes[0],
                    sectionBytes[1]
                };
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, usedBytes, 0x3C);
                //Param 3
                sectionBytes = BitConverter.GetBytes(FunctionParam3List[countOfAllMovementSections + i]);
                usedBytes = new byte[2]
                {
                    sectionBytes[0],
                    sectionBytes[1]
                };
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, usedBytes, 0x40);
                //Param 4
                sectionBytes = BitConverter.GetBytes(FunctionParam5List[countOfAllMovementSections + i]);
                usedBytes = new byte[2]
                {
                    sectionBytes[0],
                    sectionBytes[1]
                };
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, usedBytes, 0x44);
                //Param 5
                sectionBytes = BitConverter.GetBytes(FunctionParam6List[countOfAllMovementSections + i]);
                usedBytes = new byte[2]
                {
                    sectionBytes[0],
                    sectionBytes[1]
                };
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, usedBytes, 0x48);

                //Param 6
                sectionBytes = BitConverter.GetBytes(FunctionParam4List[countOfAllMovementSections + i]);
                FunctionSection = Main.b_ReplaceBytes(FunctionSection, sectionBytes, 0x4C);
                int function = FunctionIDList[countOfAllMovementSections + i];
                if (comboBox1.Text == "Naruto Storm 1") {
                    if (function == 0x09 || function == 0x30 || function == 0x32 || function == 0x34 || function == 0x36 || function == 0x3B || FunctionDamageNameList[countOfAllMovementSections + i] != "") {
                        byte[] DamagePart = new byte[0x1F0];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x18);
                        //unknown 1
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x11, 0x00 }, 0x00);
                        //unknown 1
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x07, 0x00 }, 0x5C);
                        //unknown 2
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x3C, 0x00 }, 0x68);
                        //unknown 3
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x15, 0x00 }, 0x6C);
                        //unknown 4
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x0B, 0x00 }, 0x7C);
                        //unknown 5
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x04, 0x00 }, 0x80);
                        //unknown 7
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x06, 0x00 }, 0x94);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x64);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x60);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x8C);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x90);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }


                } else if (comboBox1.Text == "Naruto Storm 2/Gen") {
                    if (function == 0x17 || function == 0x19 || function == 0x1F || function == 0x2D || function == 0x74 || FunctionDamageNameList[countOfAllMovementSections + i] != "") {
                        byte[] DamagePart = new byte[0x1F0];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x18);
                        //unknown 1
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x11, 0x00 }, 0x00);
                        //unknown 1
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x07, 0x00 }, 0x5C);
                        //unknown 2
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x3C, 0x00 }, 0x68);
                        //unknown 3
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x15, 0x00 }, 0x6C);
                        //unknown 4
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x0B, 0x00 }, 0x7C);
                        //unknown 5
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x04, 0x00 }, 0x80);
                        //unknown 7
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x06, 0x00 }, 0x94);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x64);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x60);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x8C);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x90);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }
                } else if (comboBox1.Text == "Hack Versus") {
                    if (function == 0x12 || function == 0x14 || function == 0x16 || function == 0x18 || function == 0x1A || function == 0x1E || FunctionDamageNameList[countOfAllMovementSections + i] != "") {
                        byte[] DamagePart = new byte[0x1F0];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x18);
                        //unknown 1
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x11, 0x00 }, 0x00);
                        //unknown 1
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x07, 0x00 }, 0x5C);
                        //unknown 2
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x3C, 0x00 }, 0x68);
                        //unknown 3
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x15, 0x00 }, 0x6C);
                        //unknown 4
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x0B, 0x00 }, 0x7C);
                        //unknown 5
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x04, 0x00 }, 0x80);
                        //unknown 7
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x06, 0x00 }, 0x94);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x64);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x60);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x8C);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x90);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }
                } else if (comboBox1.Text == "Naruto Storm 3 old" || comboBox1.Text == "Naruto Storm 3 HD") {

                    if (function == 0x20 || function == 0x22 || function == 0x24 || function == 0x26 || function == 0x28 || function == 0x34 || function == 0xB3 || function == 0xB5 || function == 0x95 || FunctionDamageNameList[countOfAllMovementSections + i] != "") {
                        byte[] DamagePart = new byte[0x1F0];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x18);
                        //unknown 1
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x11, 0x00 }, 0x00);
                        //unknown 1
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x07, 0x00 }, 0x5C);
                        //unknown 2
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x3C, 0x00 }, 0x68);
                        //unknown 3
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x15, 0x00 }, 0x6C);
                        //unknown 4
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x0B, 0x00 }, 0x7C);
                        //unknown 5
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x04, 0x00 }, 0x80);
                        //unknown 7
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x06, 0x00 }, 0x94);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x64);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x60);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x8C);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x90);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }
                } else if (comboBox1.Text == "Naruto Storm Rev") {

                    if (function == 0x20 || function == 0x22 || function == 0x24 || function == 0x26 || function == 0x28 || function == 0x34 || function == 0xB3 || function == 0xB5 || function == 0x95 || function == 0xD4 || function == 0xD6 || function == 0xD8 || FunctionDamageNameList[countOfAllMovementSections + i] != "") {
                        byte[] DamagePart = new byte[0x1F0];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x18);
                        //unknown 1
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x11, 0x00 }, 0x00);
                        //unknown 1
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x07, 0x00 }, 0x5C);
                        //unknown 2
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x3C, 0x00 }, 0x68);
                        //unknown 3
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x15, 0x00 }, 0x6C);
                        //unknown 4
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x0B, 0x00 }, 0x7C);
                        //unknown 5
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x04, 0x00 }, 0x80);
                        //unknown 7
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x06, 0x00 }, 0x94);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x64);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x60);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x8C);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x90);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }

                } else if (comboBox1.Text == "JoJo EOH") {

                    if (function == 0x1D || function == 0x1F || function == 0x21 || function == 0x23 || function == 0x25 || function == 0x95 || function == 0x12A || FunctionDamageNameList[countOfAllMovementSections + i] != "") {
                        byte[] DamagePart = new byte[0x1F0];
                        byte[] OldFunctionSection = new byte[0];
                        byte[] Part1Section = new byte[0];
                        byte[] Part2Section = new byte[0];
                        OldFunctionSection = Main.b_AddBytes(OldFunctionSection, DamageListEOH[countOfAllMovementSections + i]);
                        Part1Section = Main.b_AddBytes(Part1Section, OldFunctionSection, 0, 0, 0x10);
                        Part1Section = Main.b_AddBytes(Part1Section, new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 });
                        Part2Section = Main.b_AddBytes(Part2Section, OldFunctionSection,0,0x10,0x68);
                        Part2Section = Main.b_AddBytes(Part2Section, new byte[4] { 0, 0, 0, 0});
                        Part2Section = Main.b_AddBytes(Part2Section, OldFunctionSection, 0, 0x68, 0x8C);
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Part1Section, 0x00);
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Part2Section, 0x18);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }
                } else if (comboBox1.Text == "Naruto Storm 4") {
                    if (function == 0xD1 || function == 0xD3 || function == 0xD5 || function == 0xD7 || function == 0xD9 || function == 0xC1 || function == 0xC3 || function == 0xC6 || function == 0xC8 || function == 0xCA || FunctionDamageNameList[countOfAllMovementSections + i] != "") {
                        byte[] DamagePart = new byte[0x1F0];
                        DamagePart = Main.b_ReplaceBytes(DamagePart, Encoding.ASCII.GetBytes(FunctionDamageNameList[countOfAllMovementSections + i]), 0x18);
                        //unknown 1
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x11, 0x00 }, 0x00);
                        //unknown 1
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x07, 0x00 }, 0x5C);
                        //unknown 2
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x3C, 0x00 }, 0x68);
                        //unknown 3
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x15, 0x00 }, 0x6C);
                        //unknown 4
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x0B, 0x00 }, 0x7C);
                        //unknown 5
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x04, 0x00 }, 0x80);
                        //unknown 7
                        DamagePart = Main.b_ReplaceBytes(DamagePart, new byte[2] { 0x06, 0x00 }, 0x94);
                        //Damage Value
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageValueList[countOfAllMovementSections + i]), 0x64);
                        //Horizontal push
                        DamagePart = Main.b_ReplaceBytes(DamagePart, BitConverter.GetBytes(DamageHorizontalPushList[countOfAllMovementSections + i]), 0x60);
                        //Hit count
                        sectionBytes = BitConverter.GetBytes(DamageHitCountList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x8C);
                        //Hit Frequency
                        sectionBytes = BitConverter.GetBytes(DamageHitFrequencyList[countOfAllMovementSections + i]);
                        usedBytes = new byte[2]
                        {
                            sectionBytes[0],
                            sectionBytes[1]
                        };
                        DamagePart = Main.b_ReplaceBytes(DamagePart, usedBytes, 0x90);
                        FunctionSection = Main.b_AddBytes(FunctionSection, DamagePart);
                    }
                }
                if (portedFunction != -1) {
                    JoJoASBR_GeneratedCode = Main.b_AddBytes(JoJoASBR_GeneratedCode, FunctionSection);
                } else {
                    newSectionCount--;
                    bool skip = false;
                    if (SkippedFunctions.Count >= 1) {
                        for (int c = 0; c < SkippedFunctions.Count; c++) {
                            if (SkippedFunctions[c] == function.ToString("X2")) {
                                skip = true;
                            }
                        }
                    }
                    if (!skip) {
                        SkippedFunctions.Add(function.ToString("X2"));
                    }
                    //sounds bytes
                    if (codeWasRemoved == false) {
                        if (comboBox1.Text == "Naruto Storm 1") {
                            if (function == 0x26 || function == 0x4F || function == 0x67)
                                codeWasRemoved = false;
                            else
                                codeWasRemoved = true;
                        } else if (comboBox1.Text == "Naruto Storm 2/Gen") {
                            if (function == 0x65 || function == 0x66 || function == 0x67 || function == 0x68 || function == 0x97)
                                codeWasRemoved = false;
                            else
                                codeWasRemoved = true;
                        } else if (comboBox1.Text == "Naruto Storm 3 old" || comboBox1.Text == "Naruto Storm 3 HD" || comboBox1.Text == "Naruto Storm Rev") {
                            if (function == 0x7C || function == 0x7D || function == 0x7E || function == 0x7F || function == 0x80 || function == 0x81 || function == 0x82)
                                codeWasRemoved = false;
                            else
                                codeWasRemoved = true;
                        } else if (comboBox1.Text == "JoJo EOH") {
                            if (function == 0xF1 || function == 0x128)
                                codeWasRemoved = false;
                            else
                                codeWasRemoved = true;
                        } else if (comboBox1.Text == "Naruto Storm 4") {
                            if (function == 0x8D || function == 0x8E || function == 0x8F || function == 0x90 || function == 0x91 || function == 0x92 || function == 0x93)
                                codeWasRemoved = false;
                            else
                                codeWasRemoved = true;
                        } else if (comboBox1.Text == "Hack Versus") {
                            codeWasRemoved = true;
                        }
                    }
                }

            }
            //section count
            sectionBytes = BitConverter.GetBytes(newSectionCount);
            usedBytes = new byte[2]
            {
                sectionBytes[0],
                sectionBytes[1]
            };
            JoJoASBR_GeneratedCode = Main.b_ReplaceBytes(JoJoASBR_GeneratedCode, usedBytes, 0x6C);
            ConvertedSection = JoJoASBR_GeneratedCode;
            string code = "";
            for (int i = 0; i < JoJoASBR_GeneratedCode.Length; i++) {
                code = code + JoJoASBR_GeneratedCode[i].ToString("X2") + " ";
            }
            textBox6.Text = textBox6.Text + code;
            string listFunc = "";
            for (int i = 0; i < SkippedFunctions.Count; i++) {
                listFunc = listFunc + SkippedFunctions[i] + ", ";
            }
            if (codeWasRemoved && checkBox2.Checked == true) {
                string test = "Some sections were removed cuz they had unknown functions:\n\n" + listFunc + "\n\nIf you know what values can be used on place of skipped, share info in modding group!";
                MessageBox.Show(test);
            }

            if (ConvertedSection.Length != 0 && PRMFileOpened == true) {
                button2.Enabled = true;
            }
            MessageBox.Show("Code was generated!");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            PL_ANM_Name = textBox1.Text;
            ListPL_ANM_Names[0] = textBox1.Text;
            PL_ANM_NEXT_Name = textBox3.Text;
            PL_ANM_PREV_Name = textBox2.Text;
            PL_ANM_DMG_Name = textBox4.Text;
            animationName = textBox7.Text;
            ID_PRMFile = (int)numericUpDown1.Value;
            GenerateStorm4Code();
            MessageBox.Show("Names were changed");
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                removeSoundSection = true;
            else
                removeSoundSection = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && countOfSection > 0 && comboBox2.Text== "Naruto Storm 4")
            {
                if (comboBox3.SelectedIndex != -1)
                {
                    //int indexList = tool.anm_list.Items.Count - 1;
                    byte[] actualSection = Main.b_StringToBytes(textBox6.Text);
                    for (int i = 0; i<countOfSection; i++)
                    {
                        if (!ListPL_ANM_Names[i].Contains("SCENE_BEGIN") && !ListPL_ANM_Names[i].Contains("LOSE")) 
                        {
                            tool.anm_list.Items.Add(ListPL_ANM_Names[i]);
                            //tool.plAnmList.Add(new List<byte[]>());
                            //tool.movementList.Add(new List<List<byte[]>>());
                            int a = comboBox3.SelectedIndex;
                            // Add this pl_anm's header to plAnmList
                            List<byte> planmheader = new List<byte>();
                            for (int y = 0; y < 0xD4; y++) {
                                planmheader.Add(actualSection[y]);
                            }
                            //MessageBox.Show(Main.b_ReadString(planmheader.ToArray(), 0));
                            tool.plAnmList[a].Add(planmheader.ToArray());
                            tool.movementList[a].Add(new List<byte[]>());

                            int index = 0x50;
                            byte m_movcount = (byte)Main.b_ReadIntFromTwoBytes(actualSection, index);
                            index = 0xD4;
                            for (int y = 0; y < m_movcount; y++) {
                                List<byte> movementsection = new List<byte>();

                                // Default movement section length is 0x40
                                int sectionLength = 0x40;

                                int function = Main.b_ReadIntFromTwoBytes(actualSection, 0x22);

                                switch (function) 
                                {
                                    case 0x83:
                                        if (index + 0x40 < actualSection.Length) 
                                        {
                                            string str = Main.b_ReadString(actualSection, index + 0x40);
                                            if (str == "SPSKILL_END") sectionLength = 0xA0;
                                        }
                                        break;
                                    case 0x8A:
                                    case 0xC1:
                                    case 0xC3:
                                    case 0xC6:
                                    case 0xC8:
                                    case 0xCA:
                                    case 0xD1:
                                    case 0xD3:
                                    case 0xD5:
                                    case 0xD7:
                                    case 0xD9:
                                        sectionLength = 0xA0;
                                        break;
                                    case 0xA0:
                                    case 0xA1:
                                    case 0xA2:
                                    case 0xA3:
                                    case 0xA4:
                                    case 0xA5:
                                    case 0xA6:
                                        if (index + 0x40 < actualSection.Length) 
                                        {
                                            string str = Main.b_ReadString(actualSection, index + 0x40);
                                            if (str.Length >= 7 && str.Substring(0, 7) == "SKL_ATK") sectionLength = 0xA0;
                                        }
                                        break;
                                }
                                if (index + 0x40 < actualSection.Length) 
                                {
                                    string str = Main.b_ReadString(actualSection, index + 0x40);
                                    if (str.Length > 3 && (str.Substring(0, 3) == "DMG" || str.Substring(0, 3) == "DAM" || str.Substring(0, 3) == "SKL" || str.Substring(0, 3) == "SPS")) {
                                        sectionLength = 0xA0;
                                    }
                                }

                                for (int z = 0; z < sectionLength; z++) movementsection.Add(actualSection[z + index]);
                                index = index + sectionLength;

                                // Add to master list
                                tool.movementList[a][tool.movementList[a].Count - 1].Add(movementsection.ToArray());
                            }
                            if (actualSection.Length - index >= 0xD4) 
                            {

                                byte[] Analysed_PL_ANM_Section = new byte[0];
                                Analysed_PL_ANM_Section = Main.b_AddBytes(Analysed_PL_ANM_Section, actualSection, 0, index);
                                actualSection = Analysed_PL_ANM_Section;
                            }
                            
                        } 
                        else 
                        {
                            tool.anm_list.Items.Add(ListPL_ANM_Names[i]);
                            int a = comboBox3.SelectedIndex;
                            // Add this pl_anm's header to plAnmList
                            List<byte> planmheader = new List<byte>();
                            for (int y = 0; y < 0xD4; y++) {
                                planmheader.Add(actualSection[y]);
                            }
                            //MessageBox.Show(Main.b_ReadString(planmheader.ToArray(), 0));
                            tool.plAnmList[a].Add(planmheader.ToArray());
                            tool.movementList[a].Add(new List<byte[]>());

                            int index = 0x50;
                            byte m_movcount = (byte)Main.b_ReadIntFromTwoBytes(actualSection, index);
                            index = 0xD4;
                            for (int y = 0; y < m_movcount; y++) {
                                List<byte> movementsection = new List<byte>();

                                // Default movement section length is 0x40
                                int sectionLength = 0x40;

                                int function = Main.b_ReadIntFromTwoBytes(actualSection, 0x22);

                                switch (function) {
                                    case 0x83:
                                        if (index + 0x40 < actualSection.Length) {
                                            string str = Main.b_ReadString(actualSection, index + 0x40);
                                            if (str == "SPSKILL_END") sectionLength = 0xA0;
                                        }
                                        break;
                                    case 0x8A:
                                    case 0xC1:
                                    case 0xC3:
                                    case 0xC6:
                                    case 0xC8:
                                    case 0xCA:
                                    case 0xD1:
                                    case 0xD3:
                                    case 0xD5:
                                    case 0xD7:
                                    case 0xD9:
                                        sectionLength = 0xA0;
                                        break;
                                    case 0xA0:
                                    case 0xA1:
                                    case 0xA2:
                                    case 0xA3:
                                    case 0xA4:
                                    case 0xA5:
                                    case 0xA6:
                                        if (index + 0x40 < actualSection.Length) {
                                            string str = Main.b_ReadString(actualSection, index + 0x40);
                                            if (str.Length >= 7 && str.Substring(0, 7) == "SKL_ATK") sectionLength = 0xA0;
                                        }
                                        break;
                                }
                                if (index + 0x40 < actualSection.Length) {
                                    string str = Main.b_ReadString(actualSection, index + 0x40);
                                    if (str.Length > 3 && (str.Substring(0, 3) == "DMG" || str.Substring(0, 3) == "DAM" || str.Substring(0, 3) == "SKL" || str.Substring(0, 3) == "SPS")) {
                                        sectionLength = 0xA0;
                                    }
                                }

                                for (int z = 0; z < sectionLength; z++) movementsection.Add(actualSection[z + index]);
                                index = index + sectionLength;

                                // Add to master list
                                tool.movementList[a][tool.movementList[a].Count - 1].Add(movementsection.ToArray());
                            }
                            if (actualSection.Length - index >= 0xD4) {

                                byte[] Analysed_PL_ANM_Section = new byte[0];
                                Analysed_PL_ANM_Section = Main.b_AddBytes(Analysed_PL_ANM_Section, actualSection, 0, index);
                                actualSection = Analysed_PL_ANM_Section;
                            }
                            tool.anm_list.Items.RemoveAt(tool.anm_list.Items.Count - 1);
                            tool.plAnmList[a].RemoveAt(tool.plAnmList[a].Count - 1);
                            tool.movementList[a].RemoveAt(tool.movementList[a].Count - 1);
                        }
                    }
                    tool.listBox1.SelectedIndex = comboBox3.SelectedIndex;
                    tool.anm_list.SelectedIndex = tool.anm_list.Items.Count - 1 ;
                    MessageBox.Show("Section were added to PRM file");
                }
                else
                {
                    MessageBox.Show("Select ver section where it should be putted.");
                }
            }
            else
            {
                MessageBox.Show("You have to generate code first!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string list = "";
            for (int i=0; i<Program.ME_S1_LIST.Length; i++)
            {
                list = list + i.ToString("X2") + " - " + Program.ME_S1_LIST[i] + "\n";
            }
            Clipboard.SetText(list);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
