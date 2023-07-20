using NSUNS4_Character_Manager.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace NSUNS4_Character_Manager
{
	public class Tool_DuelPlayerParamEditor : Form
	{
		public bool FileOpen = false;
		public string FilePath = "";
		public int EntryCount = 0;
        /*public List<string> BinPath = new List<string>();
		public List<string> BinName = new List<string>();
		public List<byte[]> Data = new List<byte[]>();
		public List<string> CharaList = new List<string>();
		public List<string[]> CostumeList = new List<string[]>();
		public List<string[]> AwkCostumeList = new List<string[]>();
		public List<string> DefaultAssist1 = new List<string>();
		public List<string> DefaultAssist2 = new List<string>();
		public List<string> AwkAction = new List<string>();
		public List<string[]> ItemList = new List<string[]>();
		public List<byte[]> ItemCount = new List<byte[]>();
        public List<string> Partner = new List<string>();
		public List<byte[]> SettingList = new List<byte[]>();
		public List<byte[]> AwaSettingList = new List<byte[]>();
		public List<byte[]> Setting2List = new List<byte[]>();
		public List<int> EnableAwaSkillList = new List<int>();
		public List<int> VictoryAngleList = new List<int>();
		public List<int> VictoryPosList = new List<int>();
		public List<int> VictoryUnknownList = new List<int>();*/
        [Serializable]
        public class duelPlayerParamEntry {
			public string BinPath;
			public string BinName;
			public byte[] Data = new byte[0];
			public string CharaList;
			public string[] CostumeList;
			public string[] AwkCostumeList;
			public string DefaultAssist1;
			public string DefaultAssist2;
            public string AwkAction;
            public string[] ItemList;
			public byte[] ItemCount = new byte[0];
			public string Partner;
			public byte[] SettingList = new byte[0];
			public byte[] AwaSettingList = new byte[0];
			public byte[] Setting2List = new byte[0];
			public int EnableAwaSkillList;
			public int VictoryAngleList;
			public int VictoryPosList;
			public int VictoryUnknownList;
		}

		public List<duelPlayerParamEntry> duelPlayerParam = new List<duelPlayerParamEntry>();

		private IContainer components = null;
		public ListBox listBox1;
		private Button button1;
		private Button button2;
		private Button button3;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem newToolStripMenuItem;
		private ToolStripMenuItem openToolStripMenuItem;
		private ToolStripMenuItem saveToolStripMenuItem;
		private ToolStripMenuItem saveAsToolStripMenuItem;
		private ToolStripMenuItem closeToolStripMenuItem;
		private Label label1;
		private TextBox w_characodeid;
		private Button b_costumeids;
		private Button b_awkcostumeids;
		private TextBox w_awkaction;
		private Label label2;
		private TextBox w_defaultassist1;
		private Label label3;
		private TextBox w_defaultassist2;
		private Label label4;
		private TextBox w_item1;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
		private NumericUpDown w_itemc1;
		private NumericUpDown w_itemc2;
		private TextBox w_item2;
		private NumericUpDown w_itemc3;
		private TextBox w_item3;
		private NumericUpDown w_itemc4;
        private TextBox w_charaprmbas;
        private Label label9;
        private TextBox w_partner;
        private Label label10;
        private TextBox Search_TB;
        private Button Search;
        private Button button4;
        private ToolStripMenuItem itemListToolStripMenuItem;
        private Label label11;
        private NumericUpDown v_enableAwaSkill;
        private Label label12;
        private NumericUpDown v_vic_cam_angle;
        private Label label13;
        private NumericUpDown v_vic_cam_pos;
        private Label label14;
        private NumericUpDown v_cam_unk;
        private Label label15;
        private Button button5;
        private Button button6;
        private TextBox w_item4;

		public Tool_DuelPlayerParamEditor()
		{
			InitializeComponent();
		}

		public void NewFile()
		{
			FileOpen = true;
			FilePath = "";
			EntryCount = 0;
			listBox1.ClearSelected();
			listBox1.Items.Clear();
			EntryCount = 1;

			duelPlayerParam = new List<duelPlayerParamEntry>();
            duelPlayerParamEntry dpp_entry = new duelPlayerParamEntry();

			dpp_entry.BinPath = "Z:/param/player/Converter/bin/1newprm_bas.bin";
            dpp_entry.BinName = "1newprm_bas";
			dpp_entry.Data= new byte[760]
            {
                50,
                110,
                114,
                116,
                0,
                0,
                0,
                0,
                50,
                110,
                114,
                116,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                100,
                110,
                114,
                107,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                100,
                110,
                114,
                100,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                50,
                110,
                114,
                113,
                0,
                0,
                0,
                0,
                50,
                110,
                114,
                113,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                50,
                110,
                114,
                113,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                50,
                110,
                114,
                113,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                168,
                192,
                1,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                45,
                1,
                0,
                0,
                0,
                0,
                0,
                0,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                0,
                0,
                0,
                0,
                50,
                115,
                107,
                114,
                0,
                0,
                0,
                0,
                50,
                107,
                107,
                115,
                0,
                0,
                0,
                0,
                160,
                0,
                148,
                0,
                148,
                0,
                40,
                0,
                45,
                0,
                110,
                0,
                0,
                0,
                0,
                66,
                0,
                0,
                200,
                66,
                0,
                0,
                128,
                63,
                0,
                0,
                128,
                63,
                0,
                0,
                128,
                63,
                0,
                0,
                128,
                63,
                0,
                0,
                128,
                63,
                0,
                0,
                128,
                63,
                0,
                0,
                128,
                63,
                65,
                87,
                65,
                75,
                69,
                95,
                50,
                78,
                82,
                71,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                32,
                66,
                70,
                0,
                14,
                0,
                25,
                0,
                15,
                0,
                0,
                0,
                0,
                63,
                66,
                65,
                84,
                84,
                76,
                69,
                95,
                73,
                84,
                69,
                77,
                49,
                53,
                48,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                2,
                0,
                66,
                65,
                84,
                84,
                76,
                69,
                95,
                73,
                84,
                69,
                77,
                57,
                48,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                2,
                0,
                66,
                65,
                84,
                84,
                76,
                69,
                95,
                73,
                84,
                69,
                77,
                57,
                57,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                2,
                0,
                66,
                65,
                84,
                84,
                76,
                69,
                95,
                73,
                84,
                69,
                77,
                49,
                52,
                52,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                2,
                0,
                0,
                0,
                0,
                66,
                0,
                0,
                200,
                66,
                70,
                0,
                14,
                0,
                25,
                0,
                15,
                0,
                0,
                0,
                0,
                63,
                0,
                0,
                0,
                63,
                0,
                0,
                64,
                63,
                102,
                102,
                230,
                63,
                0,
                0,
                160,
                64,
                0,
                0,
                0,
                64,
                0,
                0,
                128,
                63,
                0,
                0,
                128,
                63,
                0,
                0,
                112,
                65,
                0,
                0,
                0,
                64,
                0,
                0,
                0,
                0,
                1,
                0,
                0,
                0,
                1,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                205,
                204,
                204,
                61,
                205,
                204,
                204,
                61,
                154,
                153,
                153,
                62,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0
            };
            dpp_entry.CharaList = "1new";
			string[] costumes = new string[20];
			for (int x4 = 0; x4 < 20; x4++)
			{
				costumes[x4] = "";
			}
            dpp_entry.CostumeList = costumes;
			string[] awkcostumes = new string[20];
			for (int x3 = 0; x3 < 20; x3++)
			{
				awkcostumes[x3] = "";
			}
            dpp_entry.AwkCostumeList = awkcostumes;
			dpp_entry.DefaultAssist1 = "";
            dpp_entry.DefaultAssist2 = "";
            dpp_entry.AwkAction = "";
            string[] items = new string[4];
			for (int x2 = 0; x2 < 4; x2++)
			{
				items[x2] = "";
			}
            dpp_entry.ItemList = items;
			byte[] itemc = new byte[4];
			for (int x = 0; x < 4; x++)
			{
				itemc[x] = 0;
			}
            dpp_entry.ItemCount = itemc;
            dpp_entry.Partner = "";
			duelPlayerParam.Add(dpp_entry);
            listBox1.Items.Add(dpp_entry.BinName);
		}

        /*public void OpenFile(string basepath = "")
		{
			OpenFileDialog o = new OpenFileDialog();
			{
				o.DefaultExt = ".xfbin";
				o.Filter = "*.xfbin|*.xfbin";
			}

			if (basepath == "")
            {
                o.ShowDialog();
            }
            else
            {
                o.FileName = basepath;
            }

			if (!(o.FileName != "") || !File.Exists(o.FileName))
			{
				return;
			}
			FileOpen = true;

			listBox1.Items.Clear();
			EntryCount = 0;
            duelPlayerParam = new List<duelPlayerParamEntry>();
            duelPlayerParamEntry dpp_entry = new duelPlayerParamEntry();
            
            FilePath = o.FileName;
			byte[] FileBytes = File.ReadAllBytes(FilePath);
			EntryCount = Main.b_byteArrayToIntRev(Main.b_ReadByteArray(FileBytes, 36, 4)) - 1;
            for (int x2 = 0; x2 < EntryCount; x2++) {
                duelPlayerParam.Add(dpp_entry);
            }
            //if (this.Visible) MessageBox.Show("This file contains " + EntryCount.ToString("X2") + " entries.");
            int Index3 = 128;
			for (int x3 = 0; x3 < EntryCount; x3++)
			{
				string path = Main.b_ReadString(FileBytes, Index3);
				duelPlayerParam[x3].BinPath = path;
				Index3 = Index3 + path.Length + 1;
			}
			Index3++;
			for (int x2 = 0; x2 < EntryCount; x2++)
			{
				string name = Main.b_ReadString(FileBytes, Index3);
				if (name == "Page0")
					x2++;
                if (name == "index")
                    x2++;
                duelPlayerParam[x2].BinName = name;
				Index3 = Index3 + name.Length + 1;
			}
			int StartOfFile = 68 + Main.b_byteArrayToIntRev(Main.b_ReadByteArray(FileBytes, 16, 4));
			for (int x = 0; x < EntryCount; x++)
			{
				List<byte> data = new List<byte>();
				for (int y = 0; y < 760; y++)
				{
					data.Add(FileBytes[StartOfFile + 760 * x + 48 * x + y]);
				}
                duelPlayerParam[x].Data = data.ToArray();
				int _ptr = StartOfFile + 760 * x + 48 * x;
				string characodeid = Main.b_ReadString(FileBytes, _ptr);
				string[] costumeid = new string[20];
				for (int c2 = 0; c2 < 20; c2++)
				{
					costumeid[c2] = "";
					string cid = Main.b_ReadString(FileBytes, _ptr + 8 + 8 * c2);
					if (cid != "")
					{
						costumeid[c2] = cid;
					}
				}
				string[] awkcostumeid = new string[20];
				for (int c = 0; c < 20; c++)
				{
					awkcostumeid[c] = "";
					string awkcid = Main.b_ReadString(FileBytes, _ptr + 168 + 8 * c);
					if (awkcid != "")
					{
						awkcostumeid[c] = awkcid;
					}
				}
				string defAssist3 = Main.b_ReadString(FileBytes, _ptr + 420);
				string defAssist2 = Main.b_ReadString(FileBytes, _ptr + 428);
				string awkaction = Main.b_ReadString(FileBytes, _ptr + 484);
				string[] itemlist = new string[4];
				byte[] itemcount = new byte[4];
				for (int i = 0; i < 4; i++)
				{
					itemlist[i] = "";
					itemcount[i] = 0;
					string item = Main.b_ReadString(FileBytes, _ptr + 516 + 32 * i);
					byte count = FileBytes[_ptr + 546 + 32 * i];
					if (item != "")
					{
						itemlist[i] = item;
						itemcount[i] = count;
					}
				}
                duelPlayerParam[x].SettingList = Main.b_ReadByteArray(FileBytes, _ptr + 448, 36);
                duelPlayerParam[x].Setting2List = Main.b_ReadByteArray(FileBytes, _ptr + 500, 16);
                duelPlayerParam[x].EnableAwaSkillList = FileBytes[_ptr + 0x153];
                duelPlayerParam[x].VictoryAngleList = FileBytes[_ptr + 0x1B8];
                duelPlayerParam[x].VictoryPosList = FileBytes[_ptr + 0x1B6];
                duelPlayerParam[x].VictoryUnknownList = FileBytes[_ptr + 0x1B4];

                duelPlayerParam[x].AwaSettingList = Main.b_ReadByteArray(FileBytes, _ptr + 644, 84);
				string partner = Main.b_ReadString(FileBytes, _ptr + 328);
                duelPlayerParam[x].CharaList = characodeid;
                duelPlayerParam[x].CostumeList = costumeid;
                duelPlayerParam[x].AwkCostumeList = awkcostumeid;
                duelPlayerParam[x].DefaultAssist1 = defAssist3;
                duelPlayerParam[x].DefaultAssist2 = defAssist2;
                duelPlayerParam[x].AwkAction = awkaction;
                duelPlayerParam[x].ItemList = itemlist;
                duelPlayerParam[x].ItemCount = itemcount;
                duelPlayerParam[x].Partner = partner;
                listBox1.Items.Add(duelPlayerParam[x].BinName);
			}
			Index3++;
		}*/

        public void OpenFile(string basepath = "") {
            OpenFileDialog o = new OpenFileDialog();
            {
                o.DefaultExt = ".xfbin";
                o.Filter = "*.xfbin|*.xfbin";
            }

            if (basepath == "") {
                o.ShowDialog();
            } else {
                o.FileName = basepath;
            }

            if (!(o.FileName != "") || !File.Exists(o.FileName)) {
                return;
            }
            FileOpen = true;

            listBox1.Items.Clear();
            EntryCount = 0;
            duelPlayerParam.Clear();
            FilePath = o.FileName;
            byte[] FileBytes = File.ReadAllBytes(FilePath);
            EntryCount = Main.b_byteArrayToIntRev(Main.b_ReadByteArray(FileBytes, 36, 4)) - 1;
            //if (this.Visible) MessageBox.Show("This file contains " + EntryCount.ToString("X2") + " entries.");
            int Index3 = 128;
            for (int x3 = 0; x3 < EntryCount; x3++) {
                duelPlayerParam.Add(new duelPlayerParamEntry());
            }
            for (int x3 = 0; x3 < EntryCount; x3++) {
                string path = Main.b_ReadString(FileBytes, Index3);
				duelPlayerParam[x3].BinPath = path;
                Index3 = Index3 + path.Length + 1;
            }
            Index3++;
			List<string> binName = new List<string>();
            for (int x2 = 0; x2 < EntryCount + 2; x2++) {
                string name = Main.b_ReadString(FileBytes, Index3);
                binName.Add(name);
                Index3 = Index3 + name.Length + 1;
            }
            binName.RemoveAt(1);
            binName.RemoveAt(1);
            for (int x2 = 0; x2 < EntryCount; x2++) {
                duelPlayerParam[x2].BinName = binName[x2];
            }

            int StartOfFile = 68 + Main.b_byteArrayToIntRev(Main.b_ReadByteArray(FileBytes, 16, 4));
            for (int x = 0; x < EntryCount; x++) {
                List<byte> data = new List<byte>();
                for (int y = 0; y < 760; y++) {
                    data.Add(FileBytes[StartOfFile + 760 * x + 48 * x + y]);
                }
                duelPlayerParam[x].Data = data.ToArray();
                int _ptr = StartOfFile + 760 * x + 48 * x;
                string characodeid = Main.b_ReadString(FileBytes, _ptr);
                string[] costumeid = new string[20];
                for (int c2 = 0; c2 < 20; c2++) {
                    costumeid[c2] = "";
                    string cid = Main.b_ReadString(FileBytes, _ptr + 8 + 8 * c2);
                    if (cid != "") {
                        costumeid[c2] = cid;
                    }
                }
                string[] awkcostumeid = new string[20];
                for (int c = 0; c < 20; c++) {
                    awkcostumeid[c] = "";
                    string awkcid = Main.b_ReadString(FileBytes, _ptr + 168 + 8 * c);
                    if (awkcid != "") {
                        awkcostumeid[c] = awkcid;
                    }
                }
                string defAssist3 = Main.b_ReadString(FileBytes, _ptr + 420);
                string defAssist2 = Main.b_ReadString(FileBytes, _ptr + 428);
                string awkaction = Main.b_ReadString(FileBytes, _ptr + 484);
                string[] itemlist = new string[4];
                byte[] itemcount = new byte[4];
                for (int i = 0; i < 4; i++) {
                    itemlist[i] = "";
                    itemcount[i] = 0;
                    string item = Main.b_ReadString(FileBytes, _ptr + 516 + 32 * i);
                    byte count = FileBytes[_ptr + 546 + 32 * i];
                    if (item != "") {
                        itemlist[i] = item;
                        itemcount[i] = count;
                    }
                }
                duelPlayerParam[x].SettingList = Main.b_ReadByteArray(FileBytes, _ptr + 448, 36);
                duelPlayerParam[x].Setting2List = Main.b_ReadByteArray(FileBytes, _ptr + 500, 16);
                duelPlayerParam[x].EnableAwaSkillList = FileBytes[_ptr + 0x153];
                duelPlayerParam[x].VictoryAngleList = FileBytes[_ptr + 0x1B8];
                duelPlayerParam[x].VictoryPosList = FileBytes[_ptr + 0x1B6];
                duelPlayerParam[x].VictoryUnknownList = FileBytes[_ptr + 0x1B4];

                duelPlayerParam[x].AwaSettingList = Main.b_ReadByteArray(FileBytes, _ptr + 644, 84);
                string partner = Main.b_ReadString(FileBytes, _ptr + 328);
                duelPlayerParam[x].CharaList = characodeid;
                duelPlayerParam[x].CostumeList = costumeid;
                duelPlayerParam[x].AwkCostumeList = awkcostumeid;
                duelPlayerParam[x].DefaultAssist1 = defAssist3;
                duelPlayerParam[x].DefaultAssist2 = defAssist2;
                duelPlayerParam[x].AwkAction = awkaction;
                duelPlayerParam[x].ItemList = itemlist;
                duelPlayerParam[x].ItemCount = itemcount;
                duelPlayerParam[x].Partner = partner;
                listBox1.Items.Add(duelPlayerParam[x].BinName);
            }
            Index3++;
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

		public void SaveFileAs(string basepath = "")
		{
			SaveFileDialog s = new SaveFileDialog();
			{
				s.DefaultExt = ".xfbin";
				s.Filter = "*.xfbin|*.xfbin";
			}
			if (basepath != "")
				s.FileName = basepath;
			else
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
			if (basepath == "")
				MessageBox.Show("File saved to " + FilePath + ".");
		}

		public void CloseFile()
		{
			NewFile();
			FileOpen = false;
			FilePath = "";
		}

		public void AddEntry()
		{
			int actualEntry = EntryCount;
			EntryCount++;
            duelPlayerParamEntry dpp_entry = new duelPlayerParamEntry();
            dpp_entry.BinPath = "Z:/param/player/Converter/bin/" + w_charaprmbas.Text + "prm_bas.bin";
            dpp_entry.BinName = w_charaprmbas.Text + "prm_bas";
			if (listBox1.SelectedIndex != -1)
			{
                dpp_entry.Data = duelPlayerParam[listBox1.SelectedIndex].Data;
			}
			else
			{
                dpp_entry.Data = new byte[760]
				{
					50,
					110,
					114,
					116,
					0,
					0,
					0,
					0,
					50,
					110,
					114,
					116,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					100,
					110,
					114,
					107,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					100,
					110,
					114,
					100,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					50,
					110,
					114,
					113,
					0,
					0,
					0,
					0,
					50,
					110,
					114,
					113,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					50,
					110,
					114,
					113,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					50,
					110,
					114,
					113,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					168,
					192,
					1,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					45,
					1,
					0,
					0,
					0,
					0,
					0,
					0,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					0,
					0,
					0,
					0,
					50,
					115,
					107,
					114,
					0,
					0,
					0,
					0,
					50,
					107,
					107,
					115,
					0,
					0,
					0,
					0,
					160,
					0,
					148,
					0,
					148,
					0,
					40,
					0,
					45,
					0,
					110,
					0,
					0,
					0,
					0,
					66,
					0,
					0,
					200,
					66,
					0,
					0,
					128,
					63,
					0,
					0,
					128,
					63,
					0,
					0,
					128,
					63,
					0,
					0,
					128,
					63,
					0,
					0,
					128,
					63,
					0,
					0,
					128,
					63,
					0,
					0,
					128,
					63,
					65,
					87,
					65,
					75,
					69,
					95,
					50,
					78,
					82,
					71,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					32,
					66,
					70,
					0,
					14,
					0,
					25,
					0,
					15,
					0,
					0,
					0,
					0,
					63,
					66,
					65,
					84,
					84,
					76,
					69,
					95,
					73,
					84,
					69,
					77,
					49,
					53,
					48,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					2,
					0,
					66,
					65,
					84,
					84,
					76,
					69,
					95,
					73,
					84,
					69,
					77,
					57,
					48,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					2,
					0,
					66,
					65,
					84,
					84,
					76,
					69,
					95,
					73,
					84,
					69,
					77,
					57,
					57,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					2,
					0,
					66,
					65,
					84,
					84,
					76,
					69,
					95,
					73,
					84,
					69,
					77,
					49,
					52,
					52,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					2,
					0,
					0,
					0,
					0,
					66,
					0,
					0,
					200,
					66,
					70,
					0,
					14,
					0,
					25,
					0,
					15,
					0,
					0,
					0,
					0,
					63,
					0,
					0,
					0,
					63,
					0,
					0,
					64,
					63,
					102,
					102,
					230,
					63,
					0,
					0,
					160,
					64,
					0,
					0,
					0,
					64,
					0,
					0,
					128,
					63,
					0,
					0,
					128,
					63,
					0,
					0,
					112,
					65,
					0,
					0,
					0,
					64,
					0,
					0,
					0,
					0,
					1,
					0,
					0,
					0,
					1,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					205,
					204,
					204,
					61,
					205,
					204,
					204,
					61,
					154,
					153,
					153,
					62,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0
				};
			}
            dpp_entry.CharaList = w_characodeid.Text;

			string[] costumes = new string[20];
			for (int x = 0; x < 20; x++)
			{
                costumes[x] = duelPlayerParam[listBox1.SelectedIndex].CostumeList[x];
			}
            dpp_entry.CostumeList = costumes;

			string[] awkcostumes = new string[20];
			for (int x = 0; x < 20; x++)
			{
                awkcostumes[x] = duelPlayerParam[listBox1.SelectedIndex].AwkCostumeList[x];
			}
            dpp_entry.AwkCostumeList = awkcostumes;

            dpp_entry.DefaultAssist1 = w_defaultassist1.Text;
            dpp_entry.DefaultAssist2 = w_defaultassist2.Text;
            dpp_entry.AwkAction = w_awkaction.Text;
            dpp_entry.ItemList = new string[4]
			{
				w_item1.Text,
				w_item2.Text,
				w_item3.Text,
				w_item4.Text
			};
            dpp_entry.ItemCount = new byte[4]
			{
				(byte)w_itemc1.Value,
				(byte)w_itemc2.Value,
				(byte)w_itemc3.Value,
				(byte)w_itemc4.Value
			};
			byte[] add_setting1List = duelPlayerParam[listBox1.SelectedIndex].SettingList;
			byte[] add_setting2List = duelPlayerParam[listBox1.SelectedIndex].Setting2List;
			byte[] add_settingAwaList = duelPlayerParam[listBox1.SelectedIndex].AwaSettingList;
			int add_EnableAwaSkill = duelPlayerParam[listBox1.SelectedIndex].EnableAwaSkillList;

			int add_VictoryAngle = duelPlayerParam[listBox1.SelectedIndex].VictoryAngleList;
			int add_VictoryPos = duelPlayerParam[listBox1.SelectedIndex].VictoryPosList;
			int add_VictoryUnknown = duelPlayerParam[listBox1.SelectedIndex].VictoryUnknownList;
            dpp_entry.VictoryAngleList = add_VictoryAngle;
            dpp_entry.VictoryPosList = add_VictoryPos;
            dpp_entry.VictoryUnknownList = add_VictoryUnknown;
            dpp_entry.SettingList=add_setting1List;
            dpp_entry.Setting2List = add_setting2List;
            dpp_entry.EnableAwaSkillList = add_EnableAwaSkill;
            dpp_entry.AwaSettingList = add_settingAwaList;
            dpp_entry.Partner = w_partner.Text;
			listBox1.Items.Add(dpp_entry.BinName);
			duelPlayerParam.Add(dpp_entry);
			listBox1.SelectedIndex = actualEntry;
		}

		public void RemoveEntry()
		{
			if (listBox1.Items.Count > 1)
			{
				int x = listBox1.SelectedIndex;
				if (x != -1)
				{
					if (listBox1.SelectedIndex > 0)
					{
						listBox1.SelectedIndex--;
					}
					else
					{
						listBox1.ClearSelected();
					}
					EntryCount--;
                    duelPlayerParam.RemoveAt(x);
                    listBox1.Items.RemoveAt(x);
				}
				else
				{
					MessageBox.Show("No entry selected...");
				}
			}
			else
			{
				MessageBox.Show("You can't remove the last entry of this file.");
			}
		}

		public void EditEntry()
		{
			int x = listBox1.SelectedIndex;
			if (x != -1)
			{
                duelPlayerParam[x].BinPath = "Z:/param/player/Converter/bin/" + w_charaprmbas.Text + "prm_bas.bin";
                duelPlayerParam[x].BinName = w_charaprmbas.Text + "prm_bas";
                duelPlayerParam[x].CharaList = w_characodeid.Text;
                duelPlayerParam[x].DefaultAssist1 = w_defaultassist1.Text;
                duelPlayerParam[x].DefaultAssist2 = w_defaultassist2.Text;
                duelPlayerParam[x].AwkAction = w_awkaction.Text;

                duelPlayerParam[x].EnableAwaSkillList = (int)v_enableAwaSkill.Value;
                duelPlayerParam[x].VictoryAngleList = (int)v_vic_cam_angle.Value;
                duelPlayerParam[x].VictoryPosList = (int)v_vic_cam_pos.Value;
                duelPlayerParam[x].VictoryUnknownList = (int)v_cam_unk.Value;
                duelPlayerParam[x].ItemList = new string[4]
				{
					w_item1.Text,
					w_item2.Text,
					w_item3.Text,
					w_item4.Text
				};
                duelPlayerParam[x].ItemCount = new byte[4]
				{
					(byte)w_itemc1.Value,
					(byte)w_itemc2.Value,
					(byte)w_itemc3.Value,
					(byte)w_itemc4.Value
				};
                duelPlayerParam[x].Partner = w_partner.Text;
                listBox1.Items[x] = duelPlayerParam[x].BinName;
			}
			else
			{
				MessageBox.Show("No entry selected...");
			}
		}

		public byte[] ConvertToFile()
		{
            // Build the header
			int totalLength4 = 0;

            byte[] fileBytes36 = new byte[0];
			fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[127]
			{
				78,
				85,
				67,
				67,
				0,
				0,
				0,
				121,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				73,
				216,
				0,
				0,
				0,
				3,
				0,
				121,
				20,
				2,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				59,
				0,
				0,
				0,
				219,
				0,
				0,
				39,
				47,
				0,
				0,
				0,
				221,
				0,
				0,
				10,
				71,
				0,
				0,
				0,
				221,
				0,
				0,
				10,
				92,
				0,
				0,
				3,
				104,
				0,
				0,
				0,
				0,
				110,
				117,
				99,
				99,
				67,
				104,
				117,
				110,
				107,
				78,
				117,
				108,
				108,
				0,
				110,
				117,
				99,
				99,
				67,
				104,
				117,
				110,
				107,
				66,
				105,
				110,
				97,
				114,
				121,
				0,
				110,
				117,
				99,
				99,
				67,
				104,
				117,
				110,
				107,
				80,
				97,
				103,
				101,
				0,
				110,
				117,
				99,
				99,
				67,
				104,
				117,
				110,
				107,
				73,
				110,
				100,
				101,
				120,
				0
			});

            int PtrNucc = fileBytes36.Length;
			fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[1]);

            for (int x6 = 0; x6 < EntryCount; x6++)
			{
				fileBytes36 = Main.b_AddString(fileBytes36, duelPlayerParam[x6].BinPath);
				fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[1]);
			}

            int PtrPath = fileBytes36.Length;
			fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[1]);

            for (int x5 = 0; x5 < 1; x5++)
			{
				fileBytes36 = Main.b_AddString(fileBytes36, duelPlayerParam[x5].BinName);
				fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[1]);
			}

            fileBytes36 = Main.b_AddString(fileBytes36, "Page0");
			fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[1]);
			fileBytes36 = Main.b_AddString(fileBytes36, "index");
			fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[1]);

            for (int x4 = 1; x4 < EntryCount; x4++)
			{
				fileBytes36 = Main.b_AddString(fileBytes36, duelPlayerParam[x4].BinName);
				fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[1]);
			}

            int PtrName = fileBytes36.Length;
			totalLength4 = PtrName;
			int AddedBytes = 0;

            while (fileBytes36.Length % 4 != 0)
			{
				AddedBytes++;
				fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[1]);
			}

            // Build bin1
            totalLength4 = fileBytes36.Length;
			fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[48]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				3
			});

            for (int x3 = 1; x3 < EntryCount; x3++)
			{
				int actualEntry = x3 - 1;
				fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4]
				{
					0,
					0,
					0,
					1
				});
				byte[] xbyte = BitConverter.GetBytes(2 + actualEntry);
				byte[] ybyte = BitConverter.GetBytes(4 + actualEntry);
				fileBytes36 = Main.b_AddBytes(fileBytes36, xbyte, 1);
				fileBytes36 = Main.b_AddBytes(fileBytes36, ybyte, 1);
			}

			int PtrSection = fileBytes36.Length;
			fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[16]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				3
			});
			for (int x2 = 1; x2 < EntryCount; x2++)
			{
				int actualEntry2 = x2 - 1;
				fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4]);
				byte[] xbyte2 = BitConverter.GetBytes(4 + actualEntry2);
				fileBytes36 = Main.b_AddBytes(fileBytes36, xbyte2, 1);
				fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4]
				{
					0,
					0,
					0,
					2
				});
				fileBytes36 = Main.b_AddBytes(fileBytes36, new byte[4]
				{
					0,
					0,
					0,
					3
				});
			}

			totalLength4 = fileBytes36.Length;

			int PathLength = PtrPath - 127;
			int NameLength = PtrName - PtrPath;
			int Section1Length = PtrSection - PtrName - AddedBytes;
			int FullLength = totalLength4 - 68 + 40;
			int ReplaceIndex8 = 16;
			byte[] buffer8 = BitConverter.GetBytes(FullLength);
			fileBytes36 = Main.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
			ReplaceIndex8 = 36;
			buffer8 = BitConverter.GetBytes(EntryCount + 1);
			fileBytes36 = Main.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
			ReplaceIndex8 = 40;
			buffer8 = BitConverter.GetBytes(PathLength);
			fileBytes36 = Main.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
			ReplaceIndex8 = 44;
			buffer8 = BitConverter.GetBytes(EntryCount + 3);
			fileBytes36 = Main.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
			ReplaceIndex8 = 48;
			buffer8 = BitConverter.GetBytes(NameLength);
			fileBytes36 = Main.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
			ReplaceIndex8 = 52;
			buffer8 = BitConverter.GetBytes(EntryCount + 3);
			fileBytes36 = Main.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
			ReplaceIndex8 = 56;
			buffer8 = BitConverter.GetBytes(Section1Length);
			fileBytes36 = Main.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
			ReplaceIndex8 = 60;
			buffer8 = BitConverter.GetBytes(EntryCount * 4);
			fileBytes36 = Main.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
			for (int x = 0; x < EntryCount; x++)
			{
				fileBytes36 = ((x != 0) ? Main.b_AddBytes(fileBytes36, new byte[48]
				{
					0,
					0,
					0,
					8,
					0,
					0,
					0,
					2,
					0,
					99,
					0,
					0,
					0,
					0,
					0,
					4,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					99,
					0,
					0,
					0,
					0,
					2,
					252,
					0,
					0,
					0,
					1,
					0,
					99,
					0,
					0,
					0,
					0,
					2,
					248
				}) : Main.b_AddBytes(fileBytes36, new byte[40]
				{
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					121,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					99,
					0,
					0,
					0,
					0,
					2,
					252,
					0,
					0,
					0,
					1,
					0,
					99,
					0,
					0,
					0,
					0,
					2,
					248
				}));
				fileBytes36 = Main.b_AddBytes(fileBytes36, duelPlayerParam[x].Data.ToArray());
				int _ptr = 68 + FullLength + 48 * x + 760 * x;
				fileBytes36 = Main.b_ReplaceString(fileBytes36, duelPlayerParam[x].CharaList, _ptr, 8);
				for (int i = 0; i < 20; i++)
				{
					fileBytes36 = Main.b_ReplaceString(fileBytes36, duelPlayerParam[x].CostumeList[i], _ptr + 8 + 8 * i, 8);
					fileBytes36 = Main.b_ReplaceString(fileBytes36, duelPlayerParam[x].AwkCostumeList[i], _ptr + 168 + 8 * i, 8);
				}

				fileBytes36 = Main.b_ReplaceBytes(fileBytes36, new byte[1] { (byte)duelPlayerParam[x].EnableAwaSkillList }, _ptr + 0x153);
				fileBytes36 = Main.b_ReplaceBytes(fileBytes36, new byte[1] { (byte)duelPlayerParam[x].VictoryUnknownList }, _ptr + 0x1B4);
				fileBytes36 = Main.b_ReplaceBytes(fileBytes36, new byte[1] { (byte)duelPlayerParam[x].VictoryPosList }, _ptr + 0x1B6);
				fileBytes36 = Main.b_ReplaceBytes(fileBytes36, new byte[1] { (byte)duelPlayerParam[x].VictoryAngleList }, _ptr + 0x1B8);
				fileBytes36 = Main.b_ReplaceString(fileBytes36, duelPlayerParam[x].DefaultAssist1, _ptr + 420, 8);
				fileBytes36 = Main.b_ReplaceString(fileBytes36, duelPlayerParam[x].DefaultAssist2, _ptr + 428, 8);
				fileBytes36 = Main.b_ReplaceString(fileBytes36, duelPlayerParam[x].AwkAction, _ptr + 484, 16);
				fileBytes36 = Main.b_ReplaceBytes(fileBytes36, duelPlayerParam[x].SettingList, _ptr + 448);
				fileBytes36 = Main.b_ReplaceBytes(fileBytes36, duelPlayerParam[x].Setting2List, _ptr + 500);
				fileBytes36 = Main.b_ReplaceBytes(fileBytes36, duelPlayerParam[x].AwaSettingList, _ptr + 644);
				fileBytes36 = Main.b_ReplaceString(fileBytes36, duelPlayerParam[x].ItemList[0], _ptr + 516, 16);
				fileBytes36[_ptr + 546] = duelPlayerParam[x].ItemCount[0];
				fileBytes36 = Main.b_ReplaceString(fileBytes36, duelPlayerParam[x].ItemList[1], _ptr + 548, 16);
				fileBytes36[_ptr + 578] = duelPlayerParam[x].ItemCount[1];
				fileBytes36 = Main.b_ReplaceString(fileBytes36, duelPlayerParam[x].ItemList[2], _ptr + 580, 16);
				fileBytes36[_ptr + 610] = duelPlayerParam[x].ItemCount[2];
				fileBytes36 = Main.b_ReplaceString(fileBytes36, duelPlayerParam[x].ItemList[3], _ptr + 612, 16);
				fileBytes36[_ptr + 642] = duelPlayerParam[x].ItemCount[3];
				fileBytes36 = Main.b_ReplaceString(fileBytes36, duelPlayerParam[x].Partner, _ptr + 328, 8);
            }
			return Main.b_AddBytes(fileBytes36, new byte[20]
			{
				0,
				0,
				0,
				8,
				0,
				0,
				0,
				2,
				0,
				99,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0
			});
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				DialogResult msg = MessageBox.Show("Are you sure you want to create a new file?", "", MessageBoxButtons.OKCancel);
				if (msg == DialogResult.OK)
				{
					NewFile();
				}
			}
			else
			{
				NewFile();
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				DialogResult msg = MessageBox.Show("Are you sure you want to open a new file?", "", MessageBoxButtons.OKCancel);
				if (msg == DialogResult.OK)
				{
					CloseFile();
					OpenFile();
				}
			}
			else
			{
				OpenFile();
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				DialogResult msg = MessageBox.Show("Are you sure you want to discard this file?", "", MessageBoxButtons.OKCancel);
				if (msg == DialogResult.OK)
				{
					CloseFile();
				}
			}
			else
			{
				MessageBox.Show("No file loaded...");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				AddEntry();
			}
			else
			{
				MessageBox.Show("No file loaded...");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				EditEntry();
			}
			else
			{
				MessageBox.Show("No file loaded...");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (FileOpen)
			{
				RemoveEntry();
			}
			else
			{
				MessageBox.Show("No file loaded...");
			}
		}

		private void b_costumeids_Click(object sender, EventArgs e)
		{
			int x = listBox1.SelectedIndex;
			if (x != -1)
			{
				Tool_DuelPlayerParamEditor_Costumes t = new Tool_DuelPlayerParamEditor_Costumes(duelPlayerParam[x].CostumeList.ToArray(), this, x);
				t.ShowDialog();
			}
			else
			{
				MessageBox.Show("No entry selected...");
			}
		}

		private void b_awkcostumeids_Click(object sender, EventArgs e)
		{
			int x = listBox1.SelectedIndex;
			if (x != -1)
			{
				Tool_DuelPlayerParamEditor_Costumes t = new Tool_DuelPlayerParamEditor_Costumes(duelPlayerParam[x].AwkCostumeList.ToArray(), this, x, 0);
				t.ShowDialog();
			}
			else
			{
				MessageBox.Show("No entry selected...");
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			int x = listBox1.SelectedIndex;
			if (x != -1)
			{
                w_charaprmbas.Text = duelPlayerParam[x].BinName.Substring(0, duelPlayerParam[x].BinName.Length - 7);
                w_characodeid.Text = duelPlayerParam[x].CharaList;
				w_defaultassist1.Text = duelPlayerParam[x].DefaultAssist1;
				w_defaultassist2.Text = duelPlayerParam[x].DefaultAssist2;
				w_awkaction.Text = duelPlayerParam[x].AwkAction;
				w_item1.Text = duelPlayerParam[x].ItemList[0];
				w_itemc1.Value = duelPlayerParam[x].ItemCount[0];
				w_item2.Text = duelPlayerParam[x].ItemList[1];
				w_itemc2.Value = duelPlayerParam[x].ItemCount[1];
				w_item3.Text = duelPlayerParam[x].ItemList[2];
				w_itemc3.Value = duelPlayerParam[x].ItemCount[2];
				w_item4.Text = duelPlayerParam[x].ItemList[3];
				w_itemc4.Value = duelPlayerParam[x].ItemCount[3];
                w_partner.Text = duelPlayerParam[x].Partner;
				v_enableAwaSkill.Value = duelPlayerParam[x].EnableAwaSkillList;
				v_vic_cam_angle.Value = duelPlayerParam[x].VictoryAngleList;
				v_vic_cam_pos.Value = duelPlayerParam[x].VictoryPosList;
				v_cam_unk.Value = duelPlayerParam[x].VictoryUnknownList;

			}
			else
			{
                w_charaprmbas.Text = "";
				w_characodeid.Text = "";
				w_defaultassist1.Text = "";
				w_defaultassist2.Text = "";
				w_awkaction.Text = "";
				w_item1.Text = "";
				w_itemc1.Value = 0m;
				w_item2.Text = "";
				w_itemc2.Value = 0m;
				w_item3.Text = "";
				w_itemc3.Value = 0m;
				w_item4.Text = "";
				w_itemc4.Value = 0m;
                w_partner.Text = "";
				v_enableAwaSkill.Value = 0;
				v_vic_cam_angle.Value = 0;
				v_vic_cam_pos.Value = 0;
				v_cam_unk.Value = 0;
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.w_characodeid = new System.Windows.Forms.TextBox();
            this.b_costumeids = new System.Windows.Forms.Button();
            this.b_awkcostumeids = new System.Windows.Forms.Button();
            this.w_awkaction = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.w_defaultassist1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.w_defaultassist2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.w_item1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.w_itemc1 = new System.Windows.Forms.NumericUpDown();
            this.w_itemc2 = new System.Windows.Forms.NumericUpDown();
            this.w_item2 = new System.Windows.Forms.TextBox();
            this.w_itemc3 = new System.Windows.Forms.NumericUpDown();
            this.w_item3 = new System.Windows.Forms.TextBox();
            this.w_itemc4 = new System.Windows.Forms.NumericUpDown();
            this.w_item4 = new System.Windows.Forms.TextBox();
            this.w_charaprmbas = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.w_partner = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Search_TB = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.v_enableAwaSkill = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.v_vic_cam_angle = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.v_vic_cam_pos = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.v_cam_unk = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.w_itemc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_itemc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_itemc3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_itemc4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_enableAwaSkill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_vic_cam_angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_vic_cam_pos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_cam_unk)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(13, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(276, 480);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 520);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Duplicate Entry";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 520);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save Entry";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 542);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(292, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Remove Entry";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.itemListToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(669, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.closeToolStripMenuItem.Text = "Close File";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // itemListToolStripMenuItem
            // 
            this.itemListToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.itemListToolStripMenuItem.Name = "itemListToolStripMenuItem";
            this.itemListToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.itemListToolStripMenuItem.Text = "Item list";
            this.itemListToolStripMenuItem.Click += new System.EventHandler(this.itemListToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Characode ID";
            // 
            // w_characodeid
            // 
            this.w_characodeid.Location = new System.Drawing.Point(312, 91);
            this.w_characodeid.MaxLength = 8;
            this.w_characodeid.Name = "w_characodeid";
            this.w_characodeid.Size = new System.Drawing.Size(353, 23);
            this.w_characodeid.TabIndex = 6;
            // 
            // b_costumeids
            // 
            this.b_costumeids.Location = new System.Drawing.Point(312, 118);
            this.b_costumeids.Name = "b_costumeids";
            this.b_costumeids.Size = new System.Drawing.Size(353, 23);
            this.b_costumeids.TabIndex = 7;
            this.b_costumeids.Text = "Edit costume ids";
            this.b_costumeids.UseVisualStyleBackColor = true;
            this.b_costumeids.Click += new System.EventHandler(this.b_costumeids_Click);
            // 
            // b_awkcostumeids
            // 
            this.b_awkcostumeids.Location = new System.Drawing.Point(312, 147);
            this.b_awkcostumeids.Name = "b_awkcostumeids";
            this.b_awkcostumeids.Size = new System.Drawing.Size(353, 23);
            this.b_awkcostumeids.TabIndex = 8;
            this.b_awkcostumeids.Text = "Edit awakening costume ids";
            this.b_awkcostumeids.UseVisualStyleBackColor = true;
            this.b_awkcostumeids.Click += new System.EventHandler(this.b_awkcostumeids_Click);
            // 
            // w_awkaction
            // 
            this.w_awkaction.Location = new System.Drawing.Point(312, 199);
            this.w_awkaction.MaxLength = 15;
            this.w_awkaction.Name = "w_awkaction";
            this.w_awkaction.Size = new System.Drawing.Size(353, 23);
            this.w_awkaction.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Awakening action (optional, from conditionparam)";
            // 
            // w_defaultassist1
            // 
            this.w_defaultassist1.Location = new System.Drawing.Point(313, 329);
            this.w_defaultassist1.MaxLength = 8;
            this.w_defaultassist1.Name = "w_defaultassist1";
            this.w_defaultassist1.Size = new System.Drawing.Size(120, 23);
            this.w_defaultassist1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Default assist 1:";
            // 
            // w_defaultassist2
            // 
            this.w_defaultassist2.Location = new System.Drawing.Point(437, 329);
            this.w_defaultassist2.MaxLength = 8;
            this.w_defaultassist2.Name = "w_defaultassist2";
            this.w_defaultassist2.Size = new System.Drawing.Size(110, 23);
            this.w_defaultassist2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Default assist 2:";
            // 
            // w_item1
            // 
            this.w_item1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.w_item1.Location = new System.Drawing.Point(313, 246);
            this.w_item1.MaxLength = 15;
            this.w_item1.Name = "w_item1";
            this.w_item1.Size = new System.Drawing.Size(128, 23);
            this.w_item1.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Item 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(498, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Item 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(498, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Item 4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(312, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Item 3";
            // 
            // w_itemc1
            // 
            this.w_itemc1.Location = new System.Drawing.Point(447, 246);
            this.w_itemc1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.w_itemc1.Name = "w_itemc1";
            this.w_itemc1.Size = new System.Drawing.Size(48, 23);
            this.w_itemc1.TabIndex = 24;
            // 
            // w_itemc2
            // 
            this.w_itemc2.Location = new System.Drawing.Point(615, 246);
            this.w_itemc2.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.w_itemc2.Name = "w_itemc2";
            this.w_itemc2.Size = new System.Drawing.Size(48, 23);
            this.w_itemc2.TabIndex = 26;
            // 
            // w_item2
            // 
            this.w_item2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.w_item2.Location = new System.Drawing.Point(501, 246);
            this.w_item2.MaxLength = 15;
            this.w_item2.Name = "w_item2";
            this.w_item2.Size = new System.Drawing.Size(107, 23);
            this.w_item2.TabIndex = 25;
            // 
            // w_itemc3
            // 
            this.w_itemc3.Location = new System.Drawing.Point(447, 287);
            this.w_itemc3.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.w_itemc3.Name = "w_itemc3";
            this.w_itemc3.Size = new System.Drawing.Size(48, 23);
            this.w_itemc3.TabIndex = 28;
            // 
            // w_item3
            // 
            this.w_item3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.w_item3.Location = new System.Drawing.Point(313, 287);
            this.w_item3.MaxLength = 15;
            this.w_item3.Name = "w_item3";
            this.w_item3.Size = new System.Drawing.Size(128, 23);
            this.w_item3.TabIndex = 27;
            // 
            // w_itemc4
            // 
            this.w_itemc4.Location = new System.Drawing.Point(615, 287);
            this.w_itemc4.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.w_itemc4.Name = "w_itemc4";
            this.w_itemc4.Size = new System.Drawing.Size(48, 23);
            this.w_itemc4.TabIndex = 30;
            // 
            // w_item4
            // 
            this.w_item4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.w_item4.Location = new System.Drawing.Point(501, 287);
            this.w_item4.MaxLength = 15;
            this.w_item4.Name = "w_item4";
            this.w_item4.Size = new System.Drawing.Size(107, 23);
            this.w_item4.TabIndex = 29;
            // 
            // w_charaprmbas
            // 
            this.w_charaprmbas.Location = new System.Drawing.Point(312, 50);
            this.w_charaprmbas.MaxLength = 8;
            this.w_charaprmbas.Name = "w_charaprmbas";
            this.w_charaprmbas.Size = new System.Drawing.Size(353, 23);
            this.w_charaprmbas.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(313, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 15);
            this.label9.TabIndex = 31;
            this.label9.Text = "Character ID for prmbas";
            // 
            // w_partner
            // 
            this.w_partner.Location = new System.Drawing.Point(552, 329);
            this.w_partner.MaxLength = 8;
            this.w_partner.Name = "w_partner";
            this.w_partner.Size = new System.Drawing.Size(107, 23);
            this.w_partner.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(551, 313);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 15);
            this.label10.TabIndex = 33;
            this.label10.Text = "Partner:";
            // 
            // Search_TB
            // 
            this.Search_TB.Location = new System.Drawing.Point(15, 565);
            this.Search_TB.MaxLength = 15;
            this.Search_TB.Name = "Search_TB";
            this.Search_TB.Size = new System.Drawing.Size(177, 23);
            this.Search_TB.TabIndex = 36;
            this.Search_TB.TextChanged += new System.EventHandler(this.Search_TB_TextChanged);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(191, 565);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(115, 23);
            this.Search.TabIndex = 35;
            this.Search.Text = "Search Character ID";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 15.5F);
            this.button4.Location = new System.Drawing.Point(308, 519);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(353, 68);
            this.button4.TabIndex = 37;
            this.button4.Text = "Value Settings";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(313, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 15);
            this.label11.TabIndex = 38;
            this.label11.Text = "Enable awakening skill:";
            // 
            // v_enableAwaSkill
            // 
            this.v_enableAwaSkill.Hexadecimal = true;
            this.v_enableAwaSkill.Location = new System.Drawing.Point(313, 370);
            this.v_enableAwaSkill.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.v_enableAwaSkill.Name = "v_enableAwaSkill";
            this.v_enableAwaSkill.Size = new System.Drawing.Size(118, 23);
            this.v_enableAwaSkill.TabIndex = 39;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(436, 372);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 15);
            this.label12.TabIndex = 40;
            this.label12.Text = "(00 - disabled, 01+ enabled)";
            // 
            // v_vic_cam_angle
            // 
            this.v_vic_cam_angle.Location = new System.Drawing.Point(312, 416);
            this.v_vic_cam_angle.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.v_vic_cam_angle.Name = "v_vic_cam_angle";
            this.v_vic_cam_angle.Size = new System.Drawing.Size(118, 23);
            this.v_vic_cam_angle.TabIndex = 42;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(312, 401);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 15);
            this.label13.TabIndex = 41;
            this.label13.Text = "Victory camera angle:";
            // 
            // v_vic_cam_pos
            // 
            this.v_vic_cam_pos.Location = new System.Drawing.Point(435, 416);
            this.v_vic_cam_pos.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.v_vic_cam_pos.Name = "v_vic_cam_pos";
            this.v_vic_cam_pos.Size = new System.Drawing.Size(118, 23);
            this.v_vic_cam_pos.TabIndex = 44;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(435, 401);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 15);
            this.label14.TabIndex = 43;
            this.label14.Text = "Victory camera pos (Y):";
            // 
            // v_cam_unk
            // 
            this.v_cam_unk.Location = new System.Drawing.Point(559, 416);
            this.v_cam_unk.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.v_cam_unk.Name = "v_cam_unk";
            this.v_cam_unk.Size = new System.Drawing.Size(102, 23);
            this.v_cam_unk.TabIndex = 46;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(559, 401);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 15);
            this.label15.TabIndex = 45;
            this.label15.Text = "Unknown value:";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.button5.Location = new System.Drawing.Point(289, 38);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(18, 250);
            this.button5.TabIndex = 47;
            this.button5.Text = "▲";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(289, 286);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(17, 233);
            this.button6.TabIndex = 48;
            this.button6.Text = "▼";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Tool_DuelPlayerParamEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 592);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.v_cam_unk);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.v_vic_cam_pos);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.v_vic_cam_angle);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.v_enableAwaSkill);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Search_TB);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.w_partner);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.w_charaprmbas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.w_itemc4);
            this.Controls.Add(this.w_item4);
            this.Controls.Add(this.w_itemc3);
            this.Controls.Add(this.w_item3);
            this.Controls.Add(this.w_itemc2);
            this.Controls.Add(this.w_item2);
            this.Controls.Add(this.w_itemc1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.w_item1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.w_defaultassist2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.w_defaultassist1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.w_awkaction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.b_awkcostumeids);
            this.Controls.Add(this.b_costumeids);
            this.Controls.Add(this.w_characodeid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Tool_DuelPlayerParamEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duel Player Param Editor";
            this.Load += new System.EventHandler(this.Tool_DuelPlayerParamEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.w_itemc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_itemc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_itemc3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_itemc4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_enableAwaSkill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_vic_cam_angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_vic_cam_pos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_cam_unk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void Tool_DuelPlayerParamEditor_Load(object sender, EventArgs e)
        {
			if (File.Exists(Main.dppPath)) {
				OpenFile(Main.dppPath);
			}
        }

        private void Search_Click(object sender, EventArgs e)
        {
			if (FileOpen)
			{
				if (Search_TB.Text != "")
				{
					/*if (Main.SearchStringIndex(BinName, Search_TB.Text, EntryCount, listBox1.SelectedIndex) != -1)
					{
						listBox1.SelectedIndex = Main.SearchStringIndex(BinName, Search_TB.Text, EntryCount, listBox1.SelectedIndex);
					}
					else
					{
						if (Main.SearchStringIndex(BinName, Search_TB.Text, EntryCount, 0) != -1)
						{
							listBox1.SelectedIndex = Main.SearchStringIndex(BinName, Search_TB.Text, EntryCount, -1);
						}
						else
						{
							MessageBox.Show("Section with that name doesn't exist in file");
						}
					}*/
					int sel_entry = listBox1.SelectedIndex;
					if (sel_entry < 0)
						sel_entry = 0;
                    for (int c = sel_entry; c<listBox1.Items.Count; c++) {
						if (listBox1.Items[c].ToString().Contains(Search_TB.Text)) {
							listBox1.SelectedIndex = c;
							return;
						}
                    }
                    for (int c = 0; c< sel_entry; c++) {
                        if (listBox1.Items[c].ToString().Contains(Search_TB.Text)) {
                            listBox1.SelectedIndex = c;
                            return;
                        }
                    }
					MessageBox.Show("Entry doesn't exist in file with that name");
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

        private void Search_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
			int x = listBox1.SelectedIndex;
			if (x != -1)
			{
				Tool_DuelPlayerParamEditor_settings s = new Tool_DuelPlayerParamEditor_settings(duelPlayerParam[x].SettingList, duelPlayerParam[x].Setting2List, duelPlayerParam[x].AwaSettingList, duelPlayerParam[x].BinName, this, x);
				s.ShowDialog();
			}
			else
			{
				MessageBox.Show("No entry selected...");
			}
		}

        private void itemListToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Tool_DSP_ItemList s = new Tool_DSP_ItemList();
			s.Show();
		}

		void EntryMoveUp() {
			int x = listBox1.SelectedIndex;
			if (x != -1) {
				if (x > 0) {
					duelPlayerParamEntry dpp_entry = duelPlayerParam[x];
                    duelPlayerParamEntry new_dpp_entry = duelPlayerParam[x-1];

					duelPlayerParam[x] = new_dpp_entry;
					duelPlayerParam[x - 1] = dpp_entry;
					listBox1.Items[x] = duelPlayerParam[x].BinName.DeepClone();
                    listBox1.Items[x-1] = duelPlayerParam[x-1].BinName.DeepClone();
					listBox1.SelectedIndex = x - 1;
                }
			} else {
				MessageBox.Show("Select entry.");
			}
		}
        void EntryMoveDown() {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                if (x < listBox1.Items.Count) {
                    duelPlayerParamEntry dpp_entry = duelPlayerParam[x];
                    duelPlayerParamEntry new_dpp_entry = duelPlayerParam[x + 1];

                    duelPlayerParam[x] = new_dpp_entry;
                    duelPlayerParam[x + 1] = dpp_entry;
                    listBox1.Items[x] = duelPlayerParam[x].BinName.DeepClone();
                    listBox1.Items[x + 1] = duelPlayerParam[x + 1].BinName.DeepClone();
                    listBox1.SelectedIndex = x + 1;
                }
            } else {
                MessageBox.Show("Select entry.");
            }
        }
        private void button5_Click(object sender, EventArgs e) {
			EntryMoveUp();
        }

        private void button6_Click(object sender, EventArgs e) {
			EntryMoveDown();
        }
    }
}
