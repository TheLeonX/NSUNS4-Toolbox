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
    public partial class Tool_conditionprmEditor : Form {
        public Tool_conditionprmEditor() {
            InitializeComponent();
        }

        public bool FileOpen = false;
        public string FilePath = "";
        public byte[] fileBytes = new byte[0];
        public int EntryCount = 0;

        public List<string> ConditionName_List = new List<string>();
        public List<int> ConditionDuration_List = new List<int>();
        public List<float> ConditionATK_List = new List<float>();
        public List<float> ConditionDEF_List = new List<float>();
        public List<float> ConditionSPD_List = new List<float>();
        public List<float> ConditionSPT_ATK_List = new List<float>();
        public List<float> ConditionHP_Recover_List = new List<float>();
        public List<float> ConditionPoison_List = new List<float>();
        public List<float> ConditionChakra_Recover_List = new List<float>();
        public List<float> ConditionChakra_Shave_List = new List<float>();
        public List<float> ConditionChakra_Revival_List = new List<float>();
        public List<float> ConditionChakra_Drain_List = new List<float>();
        public List<float> ConditionChakra_List = new List<float>();
        public List<float> ConditionChakra_Usage_List = new List<float>();
        public List<float> ConditionSupport_List = new List<float>();
        public List<float> ConditionTeam_List = new List<float>();
        public List<float> ConditionGuardBreak_List = new List<float>();
        public List<float> ConditionDodge_List = new List<float>();
        public List<bool> ConditionProjectile_List = new List<bool>();
        public List<bool> ConditionAutoDodge_List = new List<bool>();
        public List<bool> ConditionSeal_List = new List<bool>();
        public List<bool> ConditionSleep_List = new List<bool>();
        public List<bool> ConditionStun_List = new List<bool>();
        public List<int> ConditionFlashingType_List = new List<int>();
        public List<float> ConditionR_channel_List = new List<float>();
        public List<float> ConditionG_channel_List = new List<float>();
        public List<float> ConditionB_channel_List = new List<float>();
        public List<float> ConditionUnknown1_List = new List<float>();
        public List<float> ConditionFlashingInterval_List = new List<float>();
        public List<float> ConditionUnknown2_List = new List<float>();
        public List<float> ConditionOpacity_List = new List<float>();

        private void button5_Click(object sender, EventArgs e) {
            if (FileOpen) {
                int x = listBox1.SelectedIndex;
                if (x > -1 && x < listBox1.Items.Count) {
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = true;
                    MyDialog.ShowHelp = true;
                    MyDialog.AnyColor = true;
                    byte[] Color = new byte[4]
                        {
                    (byte)ConditionR_channel_List[x],
                    (byte)ConditionG_channel_List[x],
                    (byte)ConditionB_channel_List[x],
                        0x00
                        };
                    int color_int = Main.b_byteArrayToInt(Color);
                    MyDialog.CustomColors = new int[] { color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, color_int, };
                    if (MyDialog.ShowDialog() == DialogResult.OK) {
                        ConditionR_channel_List[x] = Convert.ToInt32(MyDialog.Color.R);
                        ConditionG_channel_List[x] = Convert.ToInt32(MyDialog.Color.G);
                        ConditionB_channel_List[x] = Convert.ToInt32(MyDialog.Color.B);

                    };
                } else {
                    MessageBox.Show("No condition selected...", "Warning");
                }
            } else {
                MessageBox.Show("No file loaded...", "Warning");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFile();
        }
        public void OpenFile(string basepath = "") {
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
            int file_ptr = Main.b_FindBytes(FileBytes, Encoding.ASCII.GetBytes("index"));




            EntryCount = Main.b_ReadInt(FileBytes, file_ptr + 0x65);
            for (int x2 = 0; x2 < EntryCount; x2++) {
                long _ptr = file_ptr + 0x69 + 0xB0 * x2;

                string ConditionName = Main.b_ReadString(FileBytes, (int)_ptr);
                int ConditionDuration = Main.b_ReadInt(FileBytes, (int)_ptr + 0x40);
                float ConditionATK = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x44);
                float ConditionDEF = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x48);
                float ConditionSPD = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x4C);
                float ConditionSPT_ATK = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x50);
                float ConditionHP_Recover = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x54);
                float ConditionPoison = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x58);
                float ConditionChakra_Recover = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x5C);
                float ConditionChakra_Shave = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x60);
                float ConditionChakra_Revival = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x64);
                float ConditionChakra_Drain = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x6C);
                float ConditionChakra = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x70);
                float ConditionChakra_Usage = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x74);
                float ConditionSupport = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x78);
                float ConditionTeam = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x7C);
                float ConditionGuardBreak = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x80);
                float ConditionDodge = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x84);
                bool ConditionProjectile = Convert.ToBoolean(Main.b_ReadIntFromTwoBytes(FileBytes, (int)_ptr + 0x88));
                bool ConditionAutoDodge = Convert.ToBoolean(Main.b_ReadIntFromTwoBytes(FileBytes, (int)_ptr + 0x8A));
                bool ConditionSeal = Convert.ToBoolean(Main.b_ReadIntFromTwoBytes(FileBytes, (int)_ptr + 0x8C));
                bool ConditionSleep = Convert.ToBoolean(Main.b_ReadIntFromTwoBytes(FileBytes, (int)_ptr + 0x8E));
                bool ConditionStun = Convert.ToBoolean(Main.b_ReadIntFromTwoBytes(FileBytes, (int)_ptr + 0x90));

                int ConditionFlashingType = Main.b_ReadIntFromTwoBytes(FileBytes, (int)_ptr + 0x92);
                float ConditionFlashing_R_channel = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x94);
                float ConditionFlashing_G_channel = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x98);
                float ConditionFlashing_B_channel = Main.b_ReadFloat(FileBytes, (int)_ptr + 0x9C);
                float ConditionFlashing_unknown1 = Main.b_ReadFloat(FileBytes, (int)_ptr + 0xA0);
                float ConditionFlashing_Interval = Main.b_ReadFloat(FileBytes, (int)_ptr + 0xA4);
                float ConditionFlashing_unknown2 = Main.b_ReadFloat(FileBytes, (int)_ptr + 0xA8);
                float ConditionFlashing_Opacity = Main.b_ReadFloat(FileBytes, (int)_ptr + 0xAC);


                ConditionName_List.Add(ConditionName);
                ConditionDuration_List.Add(ConditionDuration);
                ConditionATK_List.Add(ConditionATK);
                ConditionDEF_List.Add(ConditionDEF);
                ConditionSPD_List.Add(ConditionSPD);
                ConditionSPT_ATK_List.Add(ConditionSPT_ATK);
                ConditionHP_Recover_List.Add(ConditionHP_Recover);
                ConditionPoison_List.Add(ConditionPoison);
                ConditionChakra_Recover_List.Add(ConditionChakra_Recover);
                ConditionChakra_Shave_List.Add(ConditionChakra_Shave);
                ConditionChakra_Revival_List.Add(ConditionChakra_Revival);
                ConditionChakra_Drain_List.Add(ConditionChakra_Drain);
                ConditionChakra_List.Add(ConditionChakra);
                ConditionChakra_Usage_List.Add(ConditionChakra_Usage);
                ConditionSupport_List.Add(ConditionSupport);
                ConditionTeam_List.Add(ConditionTeam);
                ConditionGuardBreak_List.Add(ConditionGuardBreak);
                ConditionDodge_List.Add(ConditionDodge);
                ConditionProjectile_List.Add(ConditionProjectile);
                ConditionAutoDodge_List.Add(ConditionAutoDodge);
                ConditionSeal_List.Add(ConditionSeal);
                ConditionSleep_List.Add(ConditionSleep);
                ConditionStun_List.Add(ConditionStun);
                ConditionFlashingType_List.Add(ConditionFlashingType);
                ConditionR_channel_List.Add(ConditionFlashing_R_channel);
                ConditionG_channel_List.Add(ConditionFlashing_G_channel);
                ConditionB_channel_List.Add(ConditionFlashing_B_channel);
                ConditionUnknown1_List.Add(ConditionFlashing_unknown1);
                ConditionFlashingInterval_List.Add(ConditionFlashing_Interval);
                ConditionUnknown2_List.Add(ConditionFlashing_unknown2);
                ConditionOpacity_List.Add(ConditionFlashing_Opacity);

            }

            for (int x = 0; x < EntryCount; x++) {
                string NewItem = ConditionName_List[x];
                listBox1.Items.Add(NewItem);
            }
        }

        public void ClearFile() {

            EntryCount = 0;
            ConditionName_List = new List<string>();
            ConditionDuration_List = new List<int>();
            ConditionATK_List = new List<float>();
            ConditionDEF_List = new List<float>();
            ConditionSPD_List = new List<float>();
            ConditionSPT_ATK_List = new List<float>();
            ConditionHP_Recover_List = new List<float>();
            ConditionPoison_List = new List<float>();
            ConditionChakra_Recover_List = new List<float>();
            ConditionChakra_Shave_List = new List<float>();
            ConditionChakra_Revival_List = new List<float>();
            ConditionChakra_Drain_List = new List<float>();
            ConditionChakra_List = new List<float>();
            ConditionChakra_Usage_List = new List<float>();
            ConditionSupport_List = new List<float>();
            ConditionTeam_List = new List<float>();
            ConditionGuardBreak_List = new List<float>();
            ConditionDodge_List = new List<float>();
            ConditionProjectile_List = new List<bool>();
            ConditionAutoDodge_List = new List<bool>();
            ConditionSeal_List = new List<bool>();
            ConditionSleep_List = new List<bool>();
            ConditionStun_List = new List<bool>();
            ConditionFlashingType_List = new List<int>();
            ConditionR_channel_List = new List<float>();
            ConditionG_channel_List = new List<float>();
            ConditionB_channel_List = new List<float>();
            ConditionUnknown1_List = new List<float>();
            ConditionFlashingInterval_List = new List<float>();
            ConditionUnknown2_List = new List<float>();
            ConditionOpacity_List = new List<float>();
            listBox1.Items.Clear();
        }
        public void CloseFile() {
            ClearFile();
            FileOpen = false;
            FilePath = "";
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

        public void SaveFileAs(string basepath = "") {
            SaveFileDialog s = new SaveFileDialog();
            {
                s.DefaultExt = ".xfbin";
                s.Filter = "*.xfbin|*.xfbin";
            }
            if (basepath != "")
                s.FileName = basepath;
            else
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
            if (basepath == "")
                MessageBox.Show("File saved to " + FilePath + ".");
        }
        public byte[] ConvertToFile() {
            List<byte> file = new List<byte>();
            byte[] header = new byte[0x130]
            {
               0x4E,0x55,0x43,0x43,0x00,0x00,0x00,0x63,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xF4,0x00,0x00,0x00,0x03,0x00,0x63,0x40,0x00,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x3B,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x34,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x1A,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x4E,0x75,0x6C,0x6C,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x42,0x69,0x6E,0x61,0x72,0x79,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x50,0x61,0x67,0x65,0x00,0x6E,0x75,0x63,0x63,0x43,0x68,0x75,0x6E,0x6B,0x49,0x6E,0x64,0x65,0x78,0x00,0x00,0x44,0x3A,0x2F,0x4E,0x53,0x57,0x2F,0x70,0x61,0x72,0x61,0x6D,0x2F,0x70,0x6C,0x61,0x79,0x65,0x72,0x2F,0x43,0x6F,0x6E,0x76,0x65,0x72,0x74,0x65,0x72,0x2F,0x62,0x69,0x6E,0x2F,0x63,0x6F,0x6E,0x64,0x69,0x74,0x69,0x6F,0x6E,0x70,0x72,0x6D,0x2E,0x62,0x69,0x6E,0x00,0x00,0x63,0x6F,0x6E,0x64,0x69,0x74,0x69,0x6F,0x6E,0x70,0x72,0x6D,0x00,0x50,0x61,0x67,0x65,0x30,0x00,0x69,0x6E,0x64,0x65,0x78,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x63,0x42,0x00,0x00,0x01,0x47,0x48,0x00,0x00,0x00,0x01,0x00,0x63,0x42,0x00,0x00,0x01,0x47,0x44,0xDC,0x01,0x00,0x00
            };
            for (int x4 = 0; x4 < header.Length; x4++) {
                file.Add(header[x4]);
            }
            for (int x3 = 0; x3 < EntryCount * 0xB0; x3++) {
                file.Add(0);
            }
            int Section_size = 4;
            for (int x2 = 0; x2 < EntryCount; x2++) {
                Section_size += 0xB0;
                int _ptr = 0x130 + 0xB0 * x2;
                for (int a8 = 0; a8 < ConditionName_List[x2].Length; a8++) {
                    file[_ptr + a8] = (byte)ConditionName_List[x2][a8];
                }
                byte[] o_a = BitConverter.GetBytes(ConditionDuration_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x40] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionATK_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x44] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionDEF_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x48] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionSPD_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x4C] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionSPT_ATK_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x50] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionHP_Recover_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x54] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionPoison_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x58] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionChakra_Recover_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x5C] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionChakra_Shave_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x60] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionChakra_Revival_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x64] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionChakra_Drain_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x6C] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionChakra_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x70] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionChakra_Usage_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x74] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionSupport_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x78] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionTeam_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x7C] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionGuardBreak_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x80] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionDodge_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x84] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(Convert.ToInt32(ConditionProjectile_List[x2]));
                for (int a8 = 0; a8 < 2; a8++) {
                    file[_ptr + a8 + 0x88] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(Convert.ToInt32(ConditionAutoDodge_List[x2]));
                for (int a8 = 0; a8 < 2; a8++) {
                    file[_ptr + a8 + 0x8A] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(Convert.ToInt32(ConditionSeal_List[x2]));
                for (int a8 = 0; a8 < 2; a8++) {
                    file[_ptr + a8 + 0x8C] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(Convert.ToInt32(ConditionSleep_List[x2]));
                for (int a8 = 0; a8 < 2; a8++) {
                    file[_ptr + a8 + 0x8E] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(Convert.ToInt32(ConditionStun_List[x2]));
                for (int a8 = 0; a8 < 2; a8++) {
                    file[_ptr + a8 + 0x90] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionFlashingType_List[x2]);
                for (int a8 = 0; a8 < 2; a8++) {
                    file[_ptr + a8 + 0x92] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionR_channel_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x94] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionG_channel_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x98] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionB_channel_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0x9C] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionUnknown1_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0xA0] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionFlashingInterval_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0xA4] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionUnknown2_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0xA8] = o_a[a8];
                }
                o_a = BitConverter.GetBytes(ConditionOpacity_List[x2]);
                for (int a8 = 0; a8 < 4; a8++) {
                    file[_ptr + a8 + 0xAC] = o_a[a8];
                }
            }


            byte[] TUJ_sizeBytes1 = BitConverter.GetBytes(Section_size);
            byte[] TUJ_sizeBytes2 = BitConverter.GetBytes(Section_size + 4);
            for (int a20 = 0; a20 < 4; a20++) {
                file[0x11C + a20] = TUJ_sizeBytes2[3 - a20];
            }
            for (int a19 = 0; a19 < 4; a19++) {
                file[0x128 + a19] = TUJ_sizeBytes1[3 - a19];
            }
            byte[] countBytes = BitConverter.GetBytes(EntryCount);
            for (int a18 = 0; a18 < 4; a18++) {
                file[0x12C + a18] = countBytes[a18];
            }

            byte[] finalBytes = new byte[20]
            {
              0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x02,0x00,0x63,0x19,0x00,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x00
            };
            for (int x = 0; x < finalBytes.Length; x++) {
                file.Add(finalBytes[x]);
            }
            return file.ToArray();
        }
        private void Tool_conditionprmEditor_Load(object sender, EventArgs e) {
            if (File.Exists(Main.conditionprmPath)) {
                OpenFile(Main.conditionprmPath);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x!=-1) {
                textBox2.Text = ConditionName_List[x];
                numericUpDown2.Value = ConditionDuration_List[x];
                numericUpDown1.Value = (decimal)ConditionATK_List[x];
                numericUpDown3.Value = (decimal)ConditionDEF_List[x];
                numericUpDown4.Value = (decimal)ConditionSPD_List[x];
                numericUpDown5.Value = (decimal)ConditionSPT_ATK_List[x];
                numericUpDown6.Value = (decimal)ConditionHP_Recover_List[x];
                numericUpDown7.Value = (decimal)ConditionPoison_List[x];
                numericUpDown14.Value = (decimal)ConditionSupport_List[x];
                numericUpDown15.Value = (decimal)ConditionTeam_List[x];
                numericUpDown8.Value = (decimal)ConditionChakra_Recover_List[x];
                numericUpDown9.Value = (decimal)ConditionChakra_Shave_List[x];
                numericUpDown10.Value = (decimal)ConditionChakra_Revival_List[x];
                numericUpDown11.Value = (decimal)ConditionChakra_Drain_List[x];
                numericUpDown12.Value = (decimal)ConditionChakra_List[x];
                numericUpDown13.Value = (decimal)ConditionChakra_Usage_List[x];
                numericUpDown16.Value = (decimal)ConditionGuardBreak_List[x];
                numericUpDown17.Value = (decimal)ConditionDodge_List[x];
                checkBox1.Checked = ConditionProjectile_List[x];
                checkBox2.Checked = ConditionAutoDodge_List[x];
                checkBox3.Checked = ConditionSeal_List[x];
                checkBox4.Checked = ConditionSleep_List[x];
                checkBox5.Checked = ConditionStun_List[x];
                numericUpDown19.Value = (decimal)ConditionFlashingInterval_List[x];
                numericUpDown18.Value = (decimal)ConditionOpacity_List[x];
                numericUpDown20.Value = (decimal)ConditionUnknown1_List[x];
                numericUpDown21.Value = (decimal)ConditionUnknown2_List[x];

                if (ConditionFlashingType_List[x] == 0) {
                    comboBox1.SelectedIndex = 0;
                }
                else if (ConditionFlashingType_List[x] == 2) {
                    comboBox1.SelectedIndex = 1;
                }
                else {
                    comboBox1.SelectedIndex = 2;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                ConditionName_List.Add(textBox2.Text);
                ConditionDuration_List.Add((int)numericUpDown2.Value);
                ConditionATK_List.Add((float)numericUpDown1.Value);
                ConditionDEF_List.Add((float)numericUpDown3.Value);
                ConditionSPD_List.Add((float)numericUpDown4.Value);
                ConditionSPT_ATK_List.Add((float)numericUpDown5.Value);
                ConditionHP_Recover_List.Add((float)numericUpDown6.Value);
                ConditionPoison_List.Add((float)numericUpDown7.Value);
                ConditionSupport_List.Add((float)numericUpDown14.Value);
                ConditionTeam_List.Add((float)numericUpDown15.Value);
                ConditionChakra_Recover_List.Add((float)numericUpDown8.Value);
                ConditionChakra_Shave_List.Add((float)numericUpDown9.Value);
                ConditionChakra_Revival_List.Add((float)numericUpDown10.Value);
                ConditionChakra_Drain_List.Add((float)numericUpDown11.Value);
                ConditionChakra_List.Add((float)numericUpDown12.Value);
                ConditionChakra_Usage_List.Add((float)numericUpDown13.Value);
                ConditionGuardBreak_List.Add((float)numericUpDown16.Value);
                ConditionDodge_List.Add((float)numericUpDown17.Value);
                ConditionProjectile_List.Add(checkBox1.Checked);
                ConditionAutoDodge_List.Add(checkBox2.Checked);
                ConditionSeal_List.Add(checkBox3.Checked);
                ConditionSleep_List.Add(checkBox4.Checked);
                ConditionStun_List.Add(checkBox5.Checked);
                ConditionFlashingInterval_List.Add((float)numericUpDown19.Value);
                ConditionOpacity_List.Add((float)numericUpDown18.Value);
                ConditionUnknown1_List.Add((float)numericUpDown20.Value);
                ConditionUnknown2_List.Add((float)numericUpDown21.Value);

                if (comboBox1.SelectedIndex == 0)
                    ConditionFlashingType_List.Add(0);
                else if (comboBox1.SelectedIndex == 1)
                    ConditionFlashingType_List.Add(2);
                else
                    ConditionFlashingType_List.Add(3);

                EntryCount++;
                listBox1.Items.Add(textBox2.Text);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            else {
                MessageBox.Show("Select condition.");
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                ConditionName_List.RemoveAt(x);
                ConditionDuration_List.RemoveAt(x);
                ConditionATK_List.RemoveAt(x);
                ConditionDEF_List.RemoveAt(x);
                ConditionSPD_List.RemoveAt(x);
                ConditionSPT_ATK_List.RemoveAt(x);
                ConditionHP_Recover_List.RemoveAt(x);
                ConditionPoison_List.RemoveAt(x);
                ConditionSupport_List.RemoveAt(x);
                ConditionTeam_List.RemoveAt(x);
                ConditionChakra_Recover_List.RemoveAt(x);
                ConditionChakra_Shave_List.RemoveAt(x);
                ConditionChakra_Revival_List.RemoveAt(x);
                ConditionChakra_Drain_List.RemoveAt(x);
                ConditionChakra_List.RemoveAt(x);
                ConditionChakra_Usage_List.RemoveAt(x);
                ConditionGuardBreak_List.RemoveAt(x);
                ConditionDodge_List.RemoveAt(x);
                ConditionProjectile_List.RemoveAt(x);
                ConditionAutoDodge_List.RemoveAt(x);
                ConditionSeal_List.RemoveAt(x);
                ConditionSleep_List.RemoveAt(x);
                ConditionStun_List.RemoveAt(x);
                ConditionFlashingInterval_List.RemoveAt(x);
                ConditionOpacity_List.RemoveAt(x);
                ConditionUnknown1_List.RemoveAt(x);
                ConditionUnknown2_List.RemoveAt(x);
                ConditionFlashingType_List.RemoveAt(x);
                EntryCount--;
                listBox1.Items.RemoveAt(x);
                listBox1.SelectedIndex = x - 1;
            } else {
                MessageBox.Show("Select condition.");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                ConditionName_List[x] = textBox2.Text;
                ConditionDuration_List[x] = (int)numericUpDown2.Value;
                ConditionATK_List[x] = (float)numericUpDown1.Value;
                ConditionDEF_List[x] = (float)numericUpDown3.Value;
                ConditionSPD_List[x] = (float)numericUpDown4.Value;
                ConditionSPT_ATK_List[x] = (float)numericUpDown5.Value;
                ConditionHP_Recover_List[x] = (float)numericUpDown6.Value;
                ConditionPoison_List[x] = (float)numericUpDown7.Value;
                ConditionSupport_List[x] = (float)numericUpDown14.Value;
                ConditionTeam_List[x] = (float)numericUpDown15.Value;
                ConditionChakra_Recover_List[x] = (float)numericUpDown8.Value;
                ConditionChakra_Shave_List[x] = (float)numericUpDown9.Value;
                ConditionChakra_Revival_List[x] = (float)numericUpDown10.Value;
                ConditionChakra_Drain_List[x] = (float)numericUpDown11.Value;
                ConditionChakra_List[x] = (float)numericUpDown12.Value;
                ConditionChakra_Usage_List[x] = (float)numericUpDown13.Value;
                ConditionGuardBreak_List[x] = (float)numericUpDown16.Value;
                ConditionDodge_List[x] = (float)numericUpDown17.Value;
                ConditionProjectile_List[x] = checkBox1.Checked;
                ConditionAutoDodge_List[x] = checkBox2.Checked;
                ConditionSeal_List[x] = checkBox3.Checked;
                ConditionSleep_List[x] = checkBox4.Checked;
                ConditionStun_List[x] = checkBox5.Checked;
                ConditionFlashingInterval_List[x] = (float)numericUpDown19.Value;
                ConditionOpacity_List[x] = (float)numericUpDown18.Value;
                ConditionUnknown1_List[x] = (float)numericUpDown20.Value;
                ConditionUnknown2_List[x] = (float)numericUpDown21.Value;

                if (comboBox1.SelectedIndex == 0)
                    ConditionFlashingType_List[x] = 0;
                else if (comboBox1.SelectedIndex == 1)
                    ConditionFlashingType_List[x] = 2;
                else
                    ConditionFlashingType_List[x] = 3;

                listBox1.Items[x] = textBox2.Text;

            } else {
                MessageBox.Show("Select condition.");
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            if (textBox1.Text != "") {
                for (int x = 0; x<listBox1.Items.Count; x++) {
                    if (listBox1.Items[x].ToString().Contains(textBox1.Text)) {
                        listBox1.SelectedIndex = x;
                        break;
                    }
                }
            }
        }
    }
}
