using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NSUNS4_Character_Manager
{
    public partial class Tool_SpcloadEditor : Form
    {
        public Tool_SpcloadEditor()
        {
            InitializeComponent();
        }

        string fileName = "";
        string prmName = "";
        bool fileOpen = false;
        byte[] fileBytes = new byte[0];
        public int entryCount = 0;
        /*public List<string> pathList = new List<string>();
        public List<string> nameList = new List<string>();
        public List<byte> typeList = new List<byte>();
        public List<byte[]> loadcondList = new List<byte[]>();*/
        [Serializable]
        public class spcloadEntry {
            public string path;
            public string name;
            public int type;
            public int loadcond;
            public int costumeIndex;
        }
        public List<spcloadEntry> spcloadParam = new List<spcloadEntry>();

        public void OpenFile(string basepath = "")
        {
            OpenFileDialog o = new OpenFileDialog();
            if (basepath != "") {
                o.FileName = basepath;
            } else {
                o.ShowDialog();
            }

            if (o.FileName == "" || File.Exists(o.FileName) == false) return;
            fileName = o.FileName;

            fileBytes = File.ReadAllBytes(fileName);
            int fileSectionIndex = XfbinParser.GetFileSectionIndex(fileBytes);
            int startIndex = fileSectionIndex + 0x1C;
            int fileIndex = startIndex;

            // Check for NUCC in header
            if (!(fileBytes.Length > 0x44 && Main.b_ReadString(fileBytes, 0, 4) == "NUCC"))
            {
                MessageBox.Show("Not a valid .xfbin file.");
                return;
            }

            // Get character name
            prmName = XfbinParser.GetNameList(fileBytes)[0];
            prmName = prmName.Substring(0, prmName.Length - 0x8);
            textBox3.Text = prmName;

            // Get entry count
            entryCount = fileBytes[fileSectionIndex + 0x1C];

            for(int x = 0; x < entryCount; x++)
            {
                spcloadEntry spcload_entry = new spcloadEntry();


                fileIndex = startIndex + (0x50 * x);
                int strIndex = fileIndex + 0x8;
                string path = Main.b_ReadString(fileBytes, strIndex);
                spcload_entry.path = path;

                strIndex = strIndex + 0x20;
                string name = Main.b_ReadString(fileBytes, strIndex);
                spcload_entry.name = name;

                strIndex = strIndex + 0x20;
                spcload_entry.type = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, strIndex, 4));

                strIndex = strIndex + 0x4;
                spcload_entry.costumeIndex = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, strIndex, 4));

                strIndex = strIndex + 0x4;
                spcload_entry.loadcond = Main.b_byteArrayToInt(Main.b_ReadByteArray(fileBytes, strIndex, 4));

                listBox1.Items.Add(path + "/" + name);
                spcloadParam.Add(spcload_entry);
            }

            fileOpen = true;
        }

        void CloseFile()
        {
            fileName = "";
            prmName = "";
            fileOpen = false;
            fileBytes = new byte[0];
            entryCount = 0;
            spcloadParam.Clear();

            listBox1.SelectedIndex = -1;
            listBox1.Items.Clear();
            textBox3.Clear();
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            numericUpDown1.Value = 0;
        }

        void SaveFile(string oldname = "")
        {
            if (fileOpen == false) return;

            if (oldname == "")
            {
                oldname = fileName;
                // Do backup
                if (File.Exists(oldname + ".bak")) File.Delete(oldname + ".bak");
                File.Copy(oldname, oldname + ".bak");
            }

            // Create new file
            List<byte> newFile = new List<byte>();

            // Copy old header
            int pathSectionIndex = XfbinParser.GetPathSectionIndex(fileBytes) + 1;
            for(int x = 0; x < pathSectionIndex; x++) newFile.Add(fileBytes[x]);

            byte[] actualFile = newFile.ToArray();
            int totalSize = actualFile.Length;

            // Create xfbin path and xfbin name strings
            string xfbinPathString = "Z:/param/player/converter/bin/" + prmName + "/" + prmName + "prm_load.bin";
            string xfbinNameString = prmName + "prm_load";

            // Add path section of xfbin
            int newPathSectionSize = xfbinPathString.Length + 1;
            actualFile = Main.b_AddString(actualFile, xfbinPathString);
            actualFile = Main.b_AddBytes(actualFile, new byte[] { 0 });

            totalSize = totalSize + newPathSectionSize;

            // Add name section of xfbin
            int newNameSectionSize = 1 + xfbinNameString.Length + 1 + "Page0".Length + 1 + "Index".Length + 1;

            actualFile = Main.b_AddBytes(actualFile, new byte[] { 0 });
            actualFile = Main.b_AddString(actualFile, xfbinNameString);
            actualFile = Main.b_AddBytes(actualFile, new byte[] { 0 });

            actualFile = Main.b_AddString(actualFile, "Page0");
            actualFile = Main.b_AddBytes(actualFile, new byte[] { 0 });

            actualFile = Main.b_AddString(actualFile, "index");
            actualFile = Main.b_AddBytes(actualFile, new byte[] { 0 });

            totalSize = totalSize + newNameSectionSize;

            // Add extra bytes to have a size divisible by 4
            while (totalSize % 4 != 0)
            {
                actualFile = Main.b_AddBytes(actualFile, new byte[] { 0 });
                totalSize++;
            }

            // Add binary 1 section of xfbin
            int newBin1SectionSize = 0x30;
            int newBin1SectionIndex = totalSize;
            for(int x = 0; x < 0x30; x++) actualFile = Main.b_AddBytes(actualFile, new byte[] { 0 });
            actualFile[totalSize + 0xF] = 0x1;
            actualFile[totalSize + 0x13] = 0x1;
            actualFile[totalSize + 0x17] = 0x1;
            actualFile[totalSize + 0x1B] = 0x2;
            actualFile[totalSize + 0x23] = 0x2;
            actualFile[totalSize + 0x27] = 0x3;
            actualFile[totalSize + 0x2F] = 0x3;
            totalSize = totalSize + newBin1SectionSize;

            // Add binary 2 section of xfbin
            int newBin2SectionSize = 0x10;
            int newBin2SectionIndex = totalSize;
            actualFile = Main.b_AddBytes(actualFile, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x03 });
            totalSize = totalSize + newBin2SectionSize;

            // Add file header
            actualFile = Main.b_AddBytes(actualFile, new byte[] { 00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x63, 0x00, 0x00, 0x00, 0x00, 0x08, 0x78,
                0x00, 0x00, 0x00, 0x01, 0x00, 0x63, 0x00, 0x00, 0x00, 0x00, 0x08, 0x74 });
            totalSize = totalSize + 0x1C;

            int prmLoadIndex = totalSize;
            actualFile = Main.b_AddBytes(actualFile, new byte[] { (byte)spcloadParam.Count });
            actualFile = Main.b_AddBytes(actualFile, new byte[] { 0x00, 0x00, 0x00});

            for (int x = 0; x < spcloadParam.Count; x++)
            {
                // Add path
                actualFile = Main.b_AddBytes(actualFile, new byte[] { 0x3F, 0x00, 0x00, 0x00 });
                actualFile = Main.b_AddString(actualFile, spcloadParam[x].path);
                for (int y = 0; y < 0x20 - spcloadParam[x].path.Length; y++) actualFile = Main.b_AddBytes(actualFile, new byte[] { 0 });

                // Add name
                actualFile = Main.b_AddString(actualFile, spcloadParam[x].name);
                for (int y = 0; y < 0x20 - spcloadParam[x].name.Length; y++) actualFile = Main.b_AddBytes(actualFile, new byte[] { 0 });

                // Add type and loading state
                actualFile = Main.b_AddBytes(actualFile, BitConverter.GetBytes(spcloadParam[x].type));
                actualFile = Main.b_AddBytes(actualFile, BitConverter.GetBytes(spcloadParam[x].costumeIndex));
                actualFile = Main.b_AddBytes(actualFile, BitConverter.GetBytes(spcloadParam[x].loadcond));
            }

            // Add EOF
            actualFile = Main.b_AddBytes(actualFile, new byte[] { 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x02, 0x00, 0x63, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00 });

            // Fix sizes
            actualFile = Main.b_ReplaceBytes(actualFile, BitConverter.GetBytes(newPathSectionSize + 1), 0x28, 1);
            actualFile = Main.b_ReplaceBytes(actualFile, BitConverter.GetBytes(newNameSectionSize), 0x30, 1);
            actualFile = Main.b_ReplaceBytes(actualFile, BitConverter.GetBytes(4 + (spcloadParam.Count * 0x50)), prmLoadIndex - 0x4, 1);
            actualFile = Main.b_ReplaceBytes(actualFile, BitConverter.GetBytes(8 + (spcloadParam.Count * 0x50)), prmLoadIndex - 0x4 - 0xC, 1);
            // Save file
            File.WriteAllBytes(fileName, actualFile);
            MessageBox.Show("File saved.");
        }

        void SaveFileAs()
        {
            SaveFileDialog s = new SaveFileDialog();
            s.ShowDialog();

            if (s.FileName == "") return;

            string oldname = fileName;
            fileName = s.FileName;

            SaveFile(oldname);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileOpen) CloseFile();

            OpenFile();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileOpen == false) return;
            CloseFile();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileOpen == false) return;

            if(listBox1.SelectedIndex == -1)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedIndex = -1;
                numericUpDown1.Value = 0;
                numericUpDown2.Value = -1;
            }
            else
            {
                int x = listBox1.SelectedIndex;
                textBox1.Text = spcloadParam[x].path;
                textBox2.Text = spcloadParam[x].name;
                comboBox1.SelectedIndex = spcloadParam[x].type;
                numericUpDown1.Value = (decimal)spcloadParam[x].loadcond;
                numericUpDown2.Value = (decimal)spcloadParam[x].costumeIndex;
            }
        }

        // Add entry
        private void button1_Click(object sender, EventArgs e)
        {
            if (fileOpen == false) return;

            spcloadEntry entry = new spcloadEntry();
            entry.path = "spc";
            entry.name = "filename";
            entry.type = 1;
            entry.loadcond = 3;
            entry.costumeIndex = -1;

            spcloadParam.Add(entry);

            listBox1.Items.Add("spc/filename");
            listBox1.SelectedIndex = spcloadParam.Count() - 1;
        }

        // Remove entry
        private void button2_Click(object sender, EventArgs e)
        {
            if (fileOpen == false || listBox1.SelectedIndex == -1) return;

            int x = listBox1.SelectedIndex;
            spcloadParam.RemoveAt(x);

            if (x == listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex = x - 1;
                listBox1.Items.RemoveAt(x);
            }
            else
            {
                listBox1.Items.RemoveAt(x);
                listBox1.SelectedIndex = x;
            }
        }

        // Save entry
        private void button3_Click(object sender, EventArgs e)
        {
            if (fileOpen == false || listBox1.SelectedIndex == -1) return;

            int x = listBox1.SelectedIndex;
            spcloadParam[x].path = textBox1.Text;
            spcloadParam[x].name = textBox2.Text;
            spcloadParam[x].type = (int)comboBox1.SelectedIndex;
            spcloadParam[x].loadcond = (int)numericUpDown1.Value;
            spcloadParam[x].costumeIndex = (int)numericUpDown2.Value;
            listBox1.Items[x] = textBox1.Text + "/" + textBox2.Text;
        }

        // Save prm name
        private void button4_Click(object sender, EventArgs e)
        {
            if (fileOpen == false || textBox3.Text == "") return;

            prmName = textBox3.Text;
        }

        private void saeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileOpen == false) return;

            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileOpen == false) return;

            SaveFileAs();
        }

        private void Tool_SpcloadEditor_Load(object sender, EventArgs e) {

        }

        public void MoveEntryUp() {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                if (x > 0) {
                    spcloadEntry entry = spcloadParam[x];
                    spcloadEntry new_entry = spcloadParam[x - 1];

                    spcloadParam[x] = new_entry.DeepClone();
                    spcloadParam[x - 1] = entry.DeepClone();
                    listBox1.Items[x] = spcloadParam[x].path + "/" + spcloadParam[x].name;
                    listBox1.Items[x - 1] = spcloadParam[x - 1].path + "/" + spcloadParam[x - 1].name;

                    listBox1.SelectedIndex = x - 1;
                }
            } else
                MessageBox.Show("Select entry");
        }

        public void MoveEntryDown() {
            int x = listBox1.SelectedIndex;
            if (x != -1) {
                if (x < listBox1.Items.Count) {
                    spcloadEntry entry = spcloadParam[x];
                    spcloadEntry new_entry = spcloadParam[x + 1];

                    spcloadParam[x] = new_entry.DeepClone();
                    spcloadParam[x + 1] = entry.DeepClone();

                    listBox1.SelectedIndex = x + 1;
                    listBox1.Items[x] = spcloadParam[x].path + "/" + spcloadParam[x].name;
                    listBox1.Items[x+1] = spcloadParam[x + 1].path + "/" + spcloadParam[x + 1].name;
                }
            } else
                MessageBox.Show("Select entry");
        }

        private void button5_Click(object sender, EventArgs e) {
            MoveEntryUp();
        }

        private void button6_Click(object sender, EventArgs e) {
            MoveEntryDown();
        }
    }
}
