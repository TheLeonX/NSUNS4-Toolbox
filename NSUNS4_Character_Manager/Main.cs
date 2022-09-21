using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using NSUNS4_Character_Manager.Tools;
using System.Globalization;
using System.Text;

namespace NSUNS4_Character_Manager
{
    public class Main : Form
    {
        private IContainer components = null;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem setDefaultPathsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button button8;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem addCostumeToolStripMenuItem;
        private ToolStripMenuItem addNewCharacterToolStripMenuItem;
        PrivateFontCollection pfc = new PrivateFontCollection();
        public static string ConfigPath = AppDomain.CurrentDomain.BaseDirectory + "\\config.txt";
        public static string datawin32Path = "[null]";
        public static string chaPath = "[null]";
        public static string dppPath = "[null]";
        public static string pspPath = "[null]";
        public static string unlPath = "[null]";
        public static string iconPath = "[null]";
        public static string cspPath = "[null]";
        public static string awakeAuraPath = "[null]";
        public static string ougiFinishPath = "[null]";
        public static string skillCustomizePath = "[null]";
        public static string spSkillCustomizePath = "[null]";
        public static string afterAttachObjectPath = "[null]";
        public static string appearanceAnmPath = "[null]";
        public static string stageInfoPath = "[null]";
        public static string battleParamPath = "[null]";
        public static string episodeParamPath = "[null]";
        public static string episodeMovieParamPath = "[null]";
        public static string messageInfoPath = "[null]";
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button15;
        private Button button16;
        private Button button18;
        private Button button20;
        private Button button21;
        private Button button19;
        private Button button14;
        private Button button17;
        private Button button22;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private Button button24;
        private Button button23;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripMenuItem addingCharacterWoReplacingToolStripMenuItem;
        public byte[] PRMEditorCopiedSection;
        public byte[] TheValue
        {
            get { return PRMEditorCopiedSection; }
            set { }
        }

        public Main()
        {
            InitializeComponent();

            if (File.Exists(ConfigPath) == false)
            {
                CreateConfig();
            }
            else
            {
                LoadConfig();
            }
        }

        void CreateConfig()
        {
            List<string> cfg = new List<string>();
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            cfg.Add("[null]");
            File.WriteAllLines(ConfigPath, cfg.ToArray());
            MessageBox.Show("Config file created.");
        }

        void SaveConfig()
        {
            List<string> cfg = new List<string>();
            cfg.Add(datawin32Path);
            cfg.Add(chaPath);
            cfg.Add(dppPath);
            cfg.Add(pspPath);
            cfg.Add(unlPath);
            cfg.Add(cspPath);
            cfg.Add(iconPath);
            cfg.Add(awakeAuraPath);
            cfg.Add(ougiFinishPath);
            cfg.Add(skillCustomizePath);
            cfg.Add(spSkillCustomizePath);
            cfg.Add(afterAttachObjectPath);
            cfg.Add(appearanceAnmPath);
            cfg.Add(stageInfoPath);
            cfg.Add(battleParamPath);
            cfg.Add(episodeParamPath);
            cfg.Add(episodeMovieParamPath);
            cfg.Add(messageInfoPath);
            File.WriteAllLines(ConfigPath, cfg.ToArray());
            MessageBox.Show("Config file saved.");
        }

        public static void LoadConfig()
        {
            string[] cfg = File.ReadAllLines(ConfigPath);
            if (cfg.Length > 0) datawin32Path = cfg[0];
            if (cfg.Length > 1) chaPath = cfg[1];
            if (cfg.Length > 2) dppPath = cfg[2];
            if (cfg.Length > 3) pspPath = cfg[3];
            if (cfg.Length > 4) unlPath = cfg[4];
            if (cfg.Length > 5) cspPath = cfg[5];
            if (cfg.Length > 6) iconPath = cfg[6];
            if (cfg.Length > 7) awakeAuraPath = cfg[7];
            if (cfg.Length > 8) ougiFinishPath = cfg[8];
            if (cfg.Length > 9) skillCustomizePath = cfg[9];
            if (cfg.Length > 10) spSkillCustomizePath = cfg[10];
            if (cfg.Length > 11) afterAttachObjectPath = cfg[11];
            if (cfg.Length > 12) appearanceAnmPath = cfg[12];
            if (cfg.Length > 13) stageInfoPath = cfg[13];
            if (cfg.Length > 14) battleParamPath = cfg[14];
            if (cfg.Length > 15) episodeParamPath = cfg[15];
            if (cfg.Length > 16) episodeMovieParamPath = cfg[16];
            if (cfg.Length > 17) messageInfoPath = cfg[17];
            MessageBox.Show("Loaded paths.");
        }

        // Add costume
        private void addCostumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dppPath == "[null]" || pspPath == "[null]" || cspPath == "[null]" || iconPath == "[null]" || chaPath == "[null]")
            {
                MessageBox.Show("Please select your default path to data_win32 to use this function.");
                return;
            }

            Tool_AddCostume add = new Tool_AddCostume(this);
            add.ShowDialog();
        }

        private void addNewCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dppPath == "[null]" || pspPath == "[null]" || cspPath == "[null]" || chaPath == "[null]")
            {
                MessageBox.Show("Please select your default path to data_win32 to use this function.");
                return;
            }

            Tool_AddCharacter add = new Tool_AddCharacter(this);
            add.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tool_CharacodeEditor characodeeditor = new Tool_CharacodeEditor();
            characodeeditor.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tool_UnlockCharaTotalEditor unlockCharaTotalEditor = new Tool_UnlockCharaTotalEditor();
            unlockCharaTotalEditor.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tool_PlayerSettingParamEditor playerSettingParamEditor = new Tool_PlayerSettingParamEditor();
            playerSettingParamEditor.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tool_RosterEditor tool_RosterEditor = new Tool_RosterEditor();
            tool_RosterEditor.Show();
        }

        public static byte[] b_ReadByteArray(byte[] actual, int index, int count)
        {
            List<byte> a = new List<byte>();
            for (int x = 0; x < count; x++)
            {
                a.Add(actual[index + x]);
            }
            return a.ToArray();
        }
        public static byte[] b_ReadByteArrayOfString(byte[] actual, int index)
        {
            List<byte> a = new List<byte>();
            int count = 65535;
            for (int x = 0; x < count; x++)
            {
                if (actual[index + x] != 0)
                    a.Add(actual[index + x]);
                else
                    x = count;
            }
            return a.ToArray();
        }
        public static int b_byteArrayToInt(byte[] actual)
        {
            int a = 0;
            return actual[0] + actual[1] * 256 + actual[2] * 65536 + actual[3] * 16777216;
        }
        public static int b_byteArrayToIntTwoBytes(byte[] actual)
        {
            int a = 0;
            return actual[0] + actual[1] * 256;
        }
        public static int b_byteArrayToIntRevTwoBytes(byte[] actual)
        {
            int a = 0;
            return actual[3] + actual[2] * 256;
        }
        public static int b_byteArrayToIntRev(byte[] actual)
        {
            int a = 0;
            return actual[3] + actual[2] * 256 + actual[1] * 65536 + actual[0] * 16777216;
        }

        public static int b_ReadInt(byte[] fileBytes, int index)
        {
            return Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, index, 4));
        }
        public static int b_ReadIntFromTwoBytes(byte[] fileBytes, int index)
        {
            return Main.b_byteArrayToIntTwoBytes(Main.b_ReadByteArray(fileBytes, index, 2));
        }
        public static int b_ReadIntRevFromTwoBytes(byte[] fileBytes, int index)
        {
            return Main.b_byteArrayToIntRevTwoBytes(Main.b_ReadByteArray(fileBytes, index, 2));
        }
        public static int b_ReadIntRev(byte[] fileBytes, int index)
        {
            return Main.b_byteArrayToIntRev(Main.b_ReadByteArray(fileBytes, index, 4));
        }

        public static float b_ReadFloat(byte[] actual, int index)
        {
            float a = -1f;
            return BitConverter.ToSingle(actual, index);
        }

        public static string b_ReadString(byte[] actual, int index, int count = -1)
        {
            string a = "";
            if (count == -1)
            {
                for (int x2 = index; x2 < actual.Length; x2++)
                {
                    if (actual[x2] != 0)
                    {
                        string str = a;
                        char c = (char)actual[x2];
                        a = str + c;
                    }
                    else
                    {
                        x2 = actual.Length;
                    }
                }
            }
            else
            {
                for (int x = index; x < count; x++)
                {
                    string str2 = a;
                    char c = (char)actual[x];
                    a = str2 + c;
                }
            }
            return a;
        }
        public static string b_ReadString2(byte[] actual, int index, int count = -1)
        {
            string a = "";
            if (count == -1)
            {
                for (int x2 = index; x2 < actual.Length; x2++)
                {
                    if (actual[x2] != 0)
                    {
                        string str = a;
                        char c = (char)actual[x2];
                        a = str + c;
                    }
                    else
                    {
                        x2 = actual.Length;
                    }
                }
            }
            else
            {
                for (int x = index; x < index + count; x++)
                {
                    string str2 = a;
                    char c = (char)actual[x];
                    a = str2 + c;
                }
            }
            return a;
        }
        public static byte[] b_ReplaceBytes(byte[] actual, byte[] bytesToReplace, int Index, int Invert = 0)
        {
            if (Invert == 0)
            {
                for (int x2 = 0; x2 < bytesToReplace.Length; x2++)
                {
                    actual[Index + x2] = bytesToReplace[x2];
                }
            }
            else
            {
                for (int x = 0; x < bytesToReplace.Length; x++)
                {
                    actual[Index + x] = bytesToReplace[bytesToReplace.Length - 1 - x];
                }
            }
            return actual;
        }

        public static byte[] b_ReplaceString(byte[] actual, string str, int Index, int Count = -1)
        {
            if (Count == -1)
            {
                for (int x2 = 0; x2 < str.Length; x2++)
                {
                    actual[Index + x2] = (byte)str[x2];
                }
            }
            else
            {
                for (int x = 0; x < Count; x++)
                {
                    if (str.Length > x)
                    {
                        actual[Index + x] = (byte)str[x];
                    }
                    else
                    {
                        actual[Index + x] = 0;
                    }
                }
            }
            return actual;
        }
        public static string b_ReplaceRealString(string actual, string str, int Index, int Count = -1)
        {
            char[] test = actual.ToCharArray();
            string output = "";
            if (Count == -1)
            {
                for (int x2 = 0; x2 < str.Length; x2++)
                {

                    test[Index + x2] = str[x2];
                }
            }
            else
            {
                for (int x = 0; x < Count; x++)
                {
                    if (str.Length > x)
                    {
                        test[Index + x] = str[x];
                    }
                    else
                    {
                        test[Index + x] = '\0';
                    }
                }
            }
            for (int i = 0; i < test.Length; i++)
            {
                output = output + test[i];
            }
            return output;
        }
        internal static byte[] b_AddBytes(object p)
        {
            throw new NotImplementedException();
        }

        public static byte[] b_AddBytes(byte[] actual, byte[] bytesToAdd, int Reverse = 0, int index = 0, int count = -1)
        {
            List<byte> a = actual.ToList();
            if (Reverse == 0)
            {
                if (count == -1) count = bytesToAdd.Length;
                //            for (int x = index; x < index + count; x++)
                //{
                //	a.Add(bytesToAdd[x]);
                //}
                for (int x = index; x < count; x++)
                {
                    a.Add(bytesToAdd[x]);
                }
            }
            else
            {
                if (count == -1) count = bytesToAdd.Length;
                //            for (int x = index; x < index + count; x++)
                //{
                //	a.Add(bytesToAdd[bytesToAdd.Length - 1 - x]);
                //}
                for (int x = index; x < count; x++)
                {
                    a.Add(bytesToAdd[bytesToAdd.Length - 1 - x]);
                }
            }
            return a.ToArray();
        }

        public static byte[] b_AddInt(byte[] actual, int _num)
        {
            List<byte> a = actual.ToList();
            byte[] b = BitConverter.GetBytes(_num);
            for (int x = 0; x < 4; x++)
            {
                a.Add(b[x]);
            }
            return a.ToArray();
        }

        public static byte[] b_StringToBytes(string hexstr)
        {
            int length = hexstr.Length;
            string NewCode = "";
            for (int i = 0; i < length; i++)
            {
                if (hexstr[i] != (char)32)
                {
                    NewCode = NewCode + hexstr[i];
                }
            }
            if (string.IsNullOrWhiteSpace(NewCode))
                throw new ArgumentNullException("Wrong Format");

            if ((NewCode.Length % 2) != 0)
                throw new ArgumentException("Wrong Format");

            var arr = new byte[NewCode.Length / 2];

            for (int i = 0, j = 0; j < NewCode.Length; i++, j += 2)
            {
                var bstr = NewCode.Substring(j, 2);
                arr[i] = byte.Parse(bstr, NumberStyles.AllowHexSpecifier);
            }

            return arr;
        }

        public static byte[] b_AddString(byte[] actual, string _str, int count = -1)
        {
            List<byte> a = actual.ToList();
            for (int x2 = 0; x2 < _str.Length; x2++)
            {
                a.Add((byte)_str[x2]);
            }
            for (int x = _str.Length; x < count; x++)
            {
                a.Add(0);
            }
            return a.ToArray();
        }

        public static byte[] b_AddFloat(byte[] actual, float f)
        {
            List<byte> a = actual.ToList();
            byte[] floatBytes = BitConverter.GetBytes(f);
            for (int x = 0; x < 4; x++)
            {
                a.Add(floatBytes[x]);
            }
            return a.ToArray();
        }

        public static int b_FindBytes(byte[] actual, byte[] bytes, int index = 0)
        {
            int actualIndex = index;
            byte[] actualBytes = new byte[bytes.Length];
            bool found = false;
            bool f = false;

            int foundIndex = -1;

            for (int a = actualIndex; a < (actual.Length - bytes.Length); a++)
            {
                f = true;

                for (int x = 0; x < bytes.Length; x++)
                {
                    actualBytes[x] = actual[a + x];

                    if (actualBytes[x] != bytes[x])
                    {
                        x = bytes.Length;
                        f = false;
                    }
                }

                if (f)
                {
                    found = true;
                    foundIndex = a;
                    a = actual.Length;
                }
            }

            return foundIndex;
        }
        public static bool b_FindBytesBool(byte[] actual, byte[] bytes, int index = 0)
        {
            int actualIndex = index;
            byte[] actualBytes = new byte[bytes.Length];
            bool found = false;
            bool f = false;

            int foundIndex = -1;

            for (int a = actualIndex; a < (actual.Length - bytes.Length); a++)
            {
                f = true;

                for (int x = 0; x < bytes.Length; x++)
                {
                    actualBytes[x] = actual[a + x];

                    if (actualBytes[x] != bytes[x])
                    {
                        x = bytes.Length;
                        f = false;
                    }
                }

                if (f)
                {
                    found = true;
                    foundIndex = a;
                    a = actual.Length;
                }
            }

            return found;
        }
        public static int b_FindString(string actual, string str, int index = 0)
        {
            int actualIndex = index;
            char[] actualString = new char[str.Length];
            bool found = false;
            bool f = false;

            int foundIndex = -1;

            for (int a = actualIndex; a < (actual.Length - str.Length); a++)
            {
                f = true;

                for (int x = 0; x < str.Length; x++)
                {
                    actualString[x] = actual[a + x];

                    if (actualString[x] != str[x])
                    {
                        x = str.Length;
                        f = false;
                    }
                }

                if (f)
                {
                    found = true;
                    foundIndex = a;
                    a = actual.Length;
                }
            }

            return foundIndex;
        }
        public static List<int> b_FindBytesList(byte[] actual, byte[] bytes, int index = 0)
        {
            int actualIndex = index;
            List<int> indexes = new List<int>();

            int lastFound = 0;
            while (lastFound != -1)
            {
                lastFound = b_FindBytes(actual, bytes, actualIndex);
                if (lastFound != -1)
                {
                    actualIndex = lastFound + 1;
                    indexes.Add(lastFound);
                }
            }

            return indexes;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Naruto: Storm 4 Character Manager made by Zealot Tormunds and was edited by TheLeonX");
        }

        public void SetPath(string f)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.ShowDialog();

            switch (f)
            {
                case "characode":
                    chaPath = o.FileName;
                    break;
                case "dpp":
                    dppPath = o.FileName;
                    break;
                case "psp":
                    pspPath = o.FileName;
                    break;
                case "unlock":
                    unlPath = o.FileName;
                    break;
                case "csp":
                    cspPath = o.FileName;
                    break;
                case "icon":
                    iconPath = o.FileName;
                    break;
            }

            SaveConfig();
        }


        private void pathToDatawin32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void setCharacodebinxfbinDefaultPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPath("characode");
        }

        private void setDuelPlayerParamDefaultPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPath("dpp");
        }

        private void setPlayerSettingParamDefaultPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPath("psp");
        }

        private void pathToUnlockCharaTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPath("unlock");
        }

        private void pathToCharacterSelectParamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPath("csp");
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        //public static CRC32(string str)
        //{

        //}

        public static int SearchStringIndex(List<string> FunctionList, string member_name, int Count, int Selected)
        {
            for (int x = 0; x < Count; x++)
            {
                /*if (FunctionList[x] == member_name + "*" + add)
                {
                    return x;
                }*/
                string mainString = FunctionList[x];
                string subString = member_name;
                int index = mainString.ToLower().IndexOf(subString.ToLower());
                if (index!=-1 && Selected <x)
                {
                    return x;
                }

            }
            return -1;
        }
        public static int SearchByteIndex(List<byte[]> FunctionList, int member_index, int Count, int Selected)
        {
            for (int x = 0; x < Count; x++)
            {
                if (Main.b_byteArrayToInt(FunctionList[x]) == member_index)
                {
                    return x;
                }

            }
            return -1;
        }
        private void button4_Click(object sender, EventArgs e)
		{
			Tool_DuelPlayerParamEditor t = new Tool_DuelPlayerParamEditor();
			t.Show();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDefaultPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCostumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addingCharacterWoReplacingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button24 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(299, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Character ID Manager\r\n(Characode.bin.xfbin)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button2.Location = new System.Drawing.Point(3, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(299, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "Costume Editor\r\n(PlayerSettingParam.xfbin)\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button3.Location = new System.Drawing.Point(3, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(299, 38);
            this.button3.TabIndex = 3;
            this.button3.Text = "Character Roster Manager\r\n(CharacterSelectParam.xfbin)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button4.Location = new System.Drawing.Point(3, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(299, 41);
            this.button4.TabIndex = 4;
            this.button4.Text = "Character Setting Editor\r\n(DuelPlayerParam.xfbin)\r\n";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button5.Location = new System.Drawing.Point(301, 116);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(299, 38);
            this.button5.TabIndex = 5;
            this.button5.Text = "Character Unlocks Editor\r\n(UnlockCharaTotal.xfbin)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(5, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(610, 30);
            this.button6.TabIndex = 6;
            this.button6.Text = "Import (.ns4) file";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(314, 35);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(301, 30);
            this.button7.TabIndex = 7;
            this.button7.Text = "Export (.ns4) costume";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(626, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDefaultPathsToolStripMenuItem});
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // setDefaultPathsToolStripMenuItem
            // 
            this.setDefaultPathsToolStripMenuItem.Name = "setDefaultPathsToolStripMenuItem";
            this.setDefaultPathsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.setDefaultPathsToolStripMenuItem.Text = "Set default path to data_win32";
            this.setDefaultPathsToolStripMenuItem.Click += new System.EventHandler(this.setDefaultPathsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCostumeToolStripMenuItem,
            this.addNewCharacterToolStripMenuItem});
            this.toolsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // addCostumeToolStripMenuItem
            // 
            this.addCostumeToolStripMenuItem.Name = "addCostumeToolStripMenuItem";
            this.addCostumeToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.addCostumeToolStripMenuItem.Text = "Add new costume (Experimental)";
            this.addCostumeToolStripMenuItem.Click += new System.EventHandler(this.addCostumeToolStripMenuItem_Click);
            // 
            // addNewCharacterToolStripMenuItem
            // 
            this.addNewCharacterToolStripMenuItem.Name = "addNewCharacterToolStripMenuItem";
            this.addNewCharacterToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.addNewCharacterToolStripMenuItem.Text = "Add new character (Experimental)";
            this.addNewCharacterToolStripMenuItem.Click += new System.EventHandler(this.addNewCharacterToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addingCharacterWoReplacingToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // addingCharacterWoReplacingToolStripMenuItem
            // 
            this.addingCharacterWoReplacingToolStripMenuItem.Name = "addingCharacterWoReplacingToolStripMenuItem";
            this.addingCharacterWoReplacingToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.addingCharacterWoReplacingToolStripMenuItem.Text = "Adding Character w/o replacing";
            this.addingCharacterWoReplacingToolStripMenuItem.Click += new System.EventHandler(this.addingCharacterWoReplacingToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button8.Location = new System.Drawing.Point(301, 227);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(299, 38);
            this.button8.TabIndex = 11;
            this.button8.Text = "Spcload Editor";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button9.Location = new System.Drawing.Point(3, 153);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(299, 38);
            this.button9.TabIndex = 12;
            this.button9.Text = "Ninjutsu editor\r\n(SkillCustomizeParam.xfbin)";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button10.Location = new System.Drawing.Point(301, 153);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(299, 38);
            this.button10.TabIndex = 13;
            this.button10.Text = "Ultimate Jutsu Editor\r\n(SpSkillCustomizeParam.xfbin)\r\n";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button11.Location = new System.Drawing.Point(3, 227);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(299, 38);
            this.button11.TabIndex = 14;
            this.button11.Text = "Prm Moveset Editor";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(5, 35);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(310, 30);
            this.button12.TabIndex = 16;
            this.button12.Text = "Export (.ns4) character";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(3, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(299, 38);
            this.button13.TabIndex = 18;
            this.button13.Text = "Xfbin Texture Replacer";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button15.Location = new System.Drawing.Point(301, 3);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(299, 38);
            this.button15.TabIndex = 20;
            this.button15.Text = "Player Icon Editor\r\n(player_icon.xfbin)\r\n";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button16.Location = new System.Drawing.Point(301, 41);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(299, 38);
            this.button16.TabIndex = 21;
            this.button16.Text = "Aura Editor\r\n(awakeAura.xfbin)\r\n";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(3, 38);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(597, 38);
            this.button18.TabIndex = 23;
            this.button18.Text = "Sound editor [NUS3BANK]";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(3, 3);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(598, 38);
            this.button20.TabIndex = 25;
            this.button20.Text = "StageInfo/AdvStageInfo editor";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button21.Location = new System.Drawing.Point(3, 190);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(299, 38);
            this.button21.TabIndex = 26;
            this.button21.Text = "afterAttachObject Editor";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button19
            // 
            this.button19.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button19.Location = new System.Drawing.Point(301, 79);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(299, 38);
            this.button19.TabIndex = 27;
            this.button19.Text = "Finish Scene Editor\r\n(OugiFinishParam.xfbin)";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.button14.Location = new System.Drawing.Point(301, 190);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(299, 38);
            this.button14.TabIndex = 28;
            this.button14.Text = "appearanceAnm Editor";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click_1);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(301, 3);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(299, 38);
            this.button17.TabIndex = 29;
            this.button17.Text = "MessageInfo Editor";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click_2);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(3, 3);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(598, 38);
            this.button22.TabIndex = 30;
            this.button22.Text = "StoryMode Editor\r\n(battleParam.xfbin)";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click_3);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(626, 565);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(618, 539);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "For modders";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(612, 533);
            this.tabControl2.TabIndex = 31;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button15);
            this.tabPage3.Controls.Add(this.button11);
            this.tabPage3.Controls.Add(this.button16);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button10);
            this.tabPage3.Controls.Add(this.button14);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.button19);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button21);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(604, 507);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Character Managment";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button20);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(604, 507);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Stage Managment";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button24);
            this.tabPage5.Controls.Add(this.button23);
            this.tabPage5.Controls.Add(this.button22);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(604, 507);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Story Mode Managment";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(3, 76);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(598, 38);
            this.button24.TabIndex = 32;
            this.button24.Text = "Episode Movie Editor\r\n(episodeMovieParam.bin.xfbin)";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Visible = false;
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(3, 39);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(598, 38);
            this.button23.TabIndex = 31;
            this.button23.Text = "Episode Editor\r\n(episodeParam.bin.xfbin)";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Visible = false;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button13);
            this.tabPage6.Controls.Add(this.button17);
            this.tabPage6.Controls.Add(this.button18);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(604, 507);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Other tools";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button12);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(618, 539);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "For players";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(461, 6);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(158, 15);
            this.linkLabel1.TabIndex = 32;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Join Discord modding group";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(381, 6);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(74, 15);
            this.linkLabel2.TabIndex = 33;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "ModdingAPI";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 589);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Naruto: Storm 4 Toolbox v5.0 (TheLeonX\'s build)";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void button8_Click(object sender, EventArgs e)
        {
            Tool_SpcloadEditor s = new Tool_SpcloadEditor();
            s.Show();
        }

        // Export .ns4 character
        private void button7_Click(object sender, EventArgs e)
        {
            Functions.Tool_ExportCostume ec = new Functions.Tool_ExportCostume();
            ec.ShowDialog();
        }

        // Import .ns4
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Multiselect = true;
            o.ShowDialog();

            int errors = 0;
            int total = o.FileNames.Length;

            for(int a = 0; a < o.FileNames.Length; a++)
            {
                byte[] fileBytes = File.ReadAllBytes(o.FileNames[a]);
                string filetype = Main.b_ReadString(fileBytes, 0);
                
                switch(filetype)
                {
                    default:
                        MessageBox.Show("Error importing " + o.FileNames[a] + ": not a valid .ns4 file.");
                        break;
                    case "NS4CS":
                        ImportCostume(fileBytes, o.FileNames[a]);
                        break;
                }
            }

            MessageBox.Show("Finished importing files (" + (total - errors).ToString() + " without errors out of " + total.ToString() + ")");
        }

        void ImportCostume(byte[] fileBytes, string filepath)
        {
            int actualindex = 6;
            string basechar = "";
            string costname = "";
            byte[] costfile = new byte[0];

            basechar = Main.b_ReadString(fileBytes, actualindex);
            actualindex = actualindex + basechar.Length + 1;

            costname = Main.b_ReadString(fileBytes, actualindex);
            actualindex = actualindex + costname.Length + 1;

            int fileLen = Main.b_ReadInt(fileBytes, actualindex);
            actualindex = actualindex + 4;

            costfile = Main.b_ReadByteArray(fileBytes, actualindex, fileLen);
            File.WriteAllBytes(datawin32Path + "/spc/" + costname + "bod1.xfbin", costfile);

            Tool_AddCostume t = new Tool_AddCostume(this);
            t.w_base.Text = basechar;
            t.w_model.Text = costname;
            int ret = t.AddCostume();

            switch(ret)
            {
                case 1:
                    MessageBox.Show("Error importing " + filepath + ": base character " + basechar + " not found in duelPlayerParam.");
                    break;
                case 2:
                    MessageBox.Show("Error importing " + filepath + ": base character " + basechar + " has its costume list full.");
                    break;
                case 3:
                    MessageBox.Show("Error importing " + filepath + ": base character " + basechar + " not found in playerSettingParam.");
                    break;
                case 4:
                    MessageBox.Show("Error importing " + filepath + ": base character " + basechar + " not found in characterSelectParam.");
                    break;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Misc.Tool_TextureReplacer t = new Misc.Tool_TextureReplacer();
            t.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Misc.Tool_PathList t = new Misc.Tool_PathList();
            t.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Tools.Tool_MovesetCoder t = new Tools.Tool_MovesetCoder();
            t.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Tool_IconEditor s = new Tool_IconEditor();
            s.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Tool_SkillCustomizeParamEditor_new s = new Tool_SkillCustomizeParamEditor_new();
            s.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Tool_AwakeAuraEditor s = new Tool_AwakeAuraEditor();
            s.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Tool_SpSkillCustomizeParamEditor s = new Tool_SpSkillCustomizeParamEditor();
            s.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This tool can use any file, but supported only WAV, BNSF and IDSP\n\nIf you want to convert .WAV file to .BNSF,\nmake sure you .WAV file has 16bit,48000hz and mono settings or sound will not work");
            Misc.Tool_nus3bankEditor s = new Misc.Tool_nus3bankEditor();
            s.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Misc.Tool_StageInfoEditor s = new Misc.Tool_StageInfoEditor();
            s.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Tool_afterAttachObject s = new Tool_afterAttachObject();
            s.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            Tool_OugiFinishParamEditor s = new Tool_OugiFinishParamEditor();
            s.Show();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            Tool_appearenceAnmEditor s = new Tool_appearenceAnmEditor();
            s.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pathToPlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPath("icon");
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            Tool_appearenceAnmEditor s = new Tool_appearenceAnmEditor();
            s.Show();
        }

        public static List<long> crc32_table()
        {
            var a = new List<long>();
            foreach (var i in Enumerable.Range(0, 256))
            {
                var k = i << 24;
                foreach (var _ in Enumerable.Range(0, 8))
                {
                    if (Convert.ToBoolean(k & 0x80000000))
                        k = k << 1 ^ 0x4c11db7;
                    else
                        k = k << 1;
                }
                a.Add(k & 0xffffffff);
            }
            return a;
        }

        public static byte[] crc32(string str)
        {
            byte[] bytestream = Encoding.ASCII.GetBytes(str);
            var crc_table = crc32_table();
            var crc = 0xffffffff;
            foreach (var bytes in bytestream) {
                var lookup_index = (crc >> 24 ^ bytes) & 0xff;
                crc = (uint)((crc & 0xffffff) << 8 ^ crc_table[(int)lookup_index]);
            }
            crc = ~crc & 0xffffffff;
            return BitConverter.GetBytes(crc);
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            //string str = textBox1.Text;
            //MessageBox.Show(BitConverter.ToString(crc32(str)));
        }

        private void button17_Click_2(object sender, EventArgs e)
        {
            Tool_MessageInfoEditor s = new Tool_MessageInfoEditor();
            s.Show();
        }

        private void button22_Click_2(object sender, EventArgs e)
        {
        }

        private void button22_Click_3(object sender, EventArgs e) {
            Tool_battleParamEditor s = new Tool_battleParamEditor();
            s.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://discord.gg/brN9cZxAqm");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/zealottormunds/ns4moddingapi/releases");
        }

        private void addingCharacterWoReplacingToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("For adding character w/o replacing existing character, you need to add entries in Characode, playerSettingParam, duelPlayerParam, skillCustomizeParam, spSkillCustomizeParam and characterSelectParam, but you also need to install ModdingAPI for it!");
        }

        private void setDefaultPathsToolStripMenuItem_Click(object sender, EventArgs e) {
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog c = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
            c.IsFolderPicker = true;

            if (c.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok) {
                datawin32Path = c.FileName;
            }
            chaPath = datawin32Path + "\\spc\\characode.bin.xfbin";
            dppPath = datawin32Path + "\\spc\\duelPlayerParam.xfbin";
            pspPath = datawin32Path + "\\spc\\WIN64\\playerSettingParam.bin.xfbin";
            unlPath = datawin32Path + "\\duel\\WIN64\\unlockCharaTotal.bin.xfbin";
            cspPath = datawin32Path + "\\ui\\max\\select\\WIN64\\characterSelectParam.xfbin";
            iconPath = datawin32Path + "\\spc\\WIN64\\player_icon.xfbin";
            awakeAuraPath = datawin32Path + "\\spc\\WIN64\\awakeAura.xfbin";
            ougiFinishPath = datawin32Path + "\\rpg\\param\\WIN64\\OugiFinishParam.bin.xfbin";
            skillCustomizePath = datawin32Path + "\\spc\\WIN64\\skillCustomizeParam.xfbin";
            spSkillCustomizePath = datawin32Path + "\\spc\\WIN64\\spSkillCustomizeParam.xfbin";
            afterAttachObjectPath = datawin32Path + "\\spc\\WIN64\\afterAttachObject.xfbin";
            appearanceAnmPath = datawin32Path + "\\spc\\WIN64\\appearanceAnm.xfbin";
            stageInfoPath = datawin32Path + "\\stage\\WIN64\\StageInfo.bin.xfbin";
            battleParamPath = datawin32Path + "\\rpg\\WIN64\\battleParam.xfbin";
            episodeParamPath = datawin32Path + "\\rpg\\param\\WIN64\\episodeParam.bin.xfbin";
            episodeMovieParamPath = datawin32Path + "\\rpg\\param\\WIN64\\episodeMovieParam.bin.xfbin";
            messageInfoPath = datawin32Path + "\\message";

            SaveConfig();
        }

        private void button12_Click(object sender, EventArgs e) {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog();
            if (f.SelectedPath != "")
                datawin32Path = f.SelectedPath;
            else {
                MessageBox.Show("For using that function, you need to select your data_win32 directory with mod");
                return;
            }
            Functions.Tool_ExportCharacter s = new Functions.Tool_ExportCharacter();
            s.ShowDialog();
        }
    }
}
