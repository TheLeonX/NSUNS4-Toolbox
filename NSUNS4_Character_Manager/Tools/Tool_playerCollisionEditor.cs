using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSUNS4_Character_Manager.Tools
{
    public partial class Tool_playerCollisionEditor : Form
    {
        public Tool_MovesetCoder tool;
        public int EntryCount;
        [Serializable]
        public class PRMcollision {
            public int Type;
            public int State;
            public int EnablerBone;
            public long Radius;
            public long YPos;
            public long ZPos;
            public string BoneName;
        }
        public List<PRMcollision> collisionSection = new List<PRMcollision>();
        /*public List<int> collisionSecTypeValue = new List<int>();
        public List<int> collisionSecStateValue = new List<int>();
        public List<int> collisionSecEnablerBoneValue = new List<int>();
        public List<long> collisionSecRadiusValue = new List<long>();
        public List<long> collisionSecYPosValue = new List<long>();
        public List<long> collisionSecZPosValue = new List<long>();
        public List<string> collisionSecBoneName = new List<string>();*/
        public Tool_playerCollisionEditor(Tool_MovesetCoder t, List<int> collisionSecTypeValueList, List<int> collisionSecStateValueList, List<int> collisionSecEnablerBoneValueList, List<long> collisionSecRadiusValueList, List<long> collisionSecYPosValueList, List<long> collisionSecZPosValueList, List<string> collisionSecBoneNameList, int count)
        {
            InitializeComponent();
            tool = t;
            EntryCount = count;
            collisionSection = new List<PRMcollision>();
            for (int h = 0; h< collisionSecTypeValueList.Count; h++) {
                PRMcollision Entry = new PRMcollision();
                Entry.Type = collisionSecTypeValueList[h].DeepClone();
                Entry.State = collisionSecStateValueList[h].DeepClone();
                Entry.EnablerBone = collisionSecEnablerBoneValueList[h].DeepClone();
                Entry.Radius = collisionSecRadiusValueList[h].DeepClone();
                Entry.YPos = collisionSecYPosValueList[h].DeepClone();
                Entry.ZPos = collisionSecZPosValueList[h].DeepClone();
                Entry.BoneName = collisionSecBoneNameList[h].DeepClone();
                collisionSection.Add(Entry);
            }

            for (int x = 0; x < EntryCount; x++)
            {
                string TypeSection = "";
                string StateSection = "";
                string LoadBone = "";
                if (collisionSection[x].Type == 0)
                    TypeSection = "collision";
                else if (collisionSection[x].Type == 1)
                    TypeSection = "hurtbox";
                else if (collisionSection[x].Type == 2)
                    TypeSection = "tracker";

                if (collisionSection[x].State == 2)
                    StateSection = "normal mode";
                else if (collisionSection[x].State == 3)
                    StateSection = "awakening mode";
                else
                    StateSection = "unknown";

                if (collisionSection[x].EnablerBone == 0)
                {
                    LoadBone = "enabled, hurtbox loaded: " + collisionSection[x].BoneName;
                }    
                else if (collisionSection[x].EnablerBone == 1)
                    LoadBone = "disabled";

                listBox1.Items.Add("Type: "+ TypeSection + ", State: " + StateSection + ", hurtbox: " + LoadBone);
            }
        }

        private void Tool_playerCollisionEditor_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox1.Text = "";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                comboBox1.SelectedIndex = collisionSection[listBox1.SelectedIndex].Type;
                numericUpDown1.Value = collisionSection[listBox1.SelectedIndex].State;
                comboBox2.SelectedIndex = collisionSection[listBox1.SelectedIndex].EnablerBone;
                textBox1.Text = collisionSection[listBox1.SelectedIndex].BoneName;
                numericUpDown2.Value = collisionSection[listBox1.SelectedIndex].Radius;
                numericUpDown3.Value = collisionSection[listBox1.SelectedIndex].YPos;
                numericUpDown4.Value = collisionSection[listBox1.SelectedIndex].ZPos;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                /*string BoneName = "";
                bool boneNameFiled = true;
                if (comboBox2.SelectedIndex == 0 && textBox1.Text != "")
                    BoneName = textBox1.Text;
                else if (comboBox2.SelectedIndex == 0 && textBox1.Text == "")
                {
                    MessageBox.Show("You should write bone name");
                    boneNameFiled = false;
                } 
                else
                    BoneName = "";

                if(boneNameFiled)
                {
                    collisionSecTypeValue.Add(comboBox1.SelectedIndex);
                    collisionSecStateValue.Add((int)numericUpDown1.Value);
                    collisionSecEnablerBoneValue.Add(comboBox2.SelectedIndex);
                    collisionSecBoneName.Add(BoneName);
                    collisionSecRadiusValue.Add((long)numericUpDown2.Value);
                    collisionSecYPosValue.Add((long)numericUpDown3.Value);
                    collisionSecZPosValue.Add((long)numericUpDown4.Value);
                    EntryCount++;

                    string TypeSection = "";
                    string StateSection = "";
                    string LoadBone = "";
                    if (collisionSecTypeValue[EntryCount - 1] == 0)
                        TypeSection = "collision";
                    else if (collisionSecTypeValue[EntryCount - 1] == 1)
                        TypeSection = "hurtbox";
                    else if (collisionSecTypeValue[EntryCount - 1] == 2)
                        TypeSection = "tracker";

                    if (collisionSecStateValue[EntryCount - 1] == 2)
                        StateSection = "normal mode";
                    else if (collisionSecStateValue[EntryCount - 1] == 3)
                        StateSection = "awakening mode";
                    else
                        StateSection = "unknown";

                    if (collisionSecEnablerBoneValue[EntryCount - 1] == 0)
                    {
                        LoadBone = "enabled, hurtbox loaded: " + collisionSecBoneName[EntryCount - 1];
                    }
                    else if (collisionSecEnablerBoneValue[EntryCount - 1] == 1)
                        LoadBone = "disabled";

                    listBox1.Items.Add("Type: " + TypeSection + ", State: " + StateSection + ", hurtbox: " + LoadBone);
                    listBox1.SelectedIndex = EntryCount - 1;
                }*/
                collisionSection.Add(collisionSection[listBox1.SelectedIndex].DeepClone());
                listBox1.Items.Add(listBox1.Items[listBox1.SelectedIndex]);
                listBox1.SelectedIndex = EntryCount - 1;
                EntryCount++;


            }
            else
            {
                PRMcollision Entry = new PRMcollision();
                collisionSection.Add(Entry.DeepClone());
                EntryCount++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string BoneName = "";
                bool boneNamefiled = true;
                if (comboBox2.SelectedIndex == 0 && textBox1.Text != "")
                    BoneName = textBox1.Text;
                else if (comboBox2.SelectedIndex == 0 && textBox1.Text == "")
                {
                    MessageBox.Show("You should write bone name");
                    boneNamefiled = false;
                } 
                else
                    BoneName = "";
                if (boneNamefiled)
                {
                    collisionSection[listBox1.SelectedIndex].Type = comboBox1.SelectedIndex;
                    collisionSection[listBox1.SelectedIndex].State = (int)numericUpDown1.Value;
                    collisionSection[listBox1.SelectedIndex].EnablerBone = comboBox2.SelectedIndex;
                    collisionSection[listBox1.SelectedIndex].BoneName = BoneName;
                    collisionSection[listBox1.SelectedIndex].Radius = (long)numericUpDown2.Value;
                    collisionSection[listBox1.SelectedIndex].YPos = (long)numericUpDown3.Value;
                    collisionSection[listBox1.SelectedIndex].ZPos = (long)numericUpDown4.Value;

                    string TypeSection = "";
                    string StateSection = "";
                    string LoadBone = "";
                    if (collisionSection[listBox1.SelectedIndex].Type == 0)
                        TypeSection = "collision";
                    else if (collisionSection[listBox1.SelectedIndex].Type == 1)
                        TypeSection = "hurtbox";
                    else if (collisionSection[listBox1.SelectedIndex].Type == 2)
                        TypeSection = "tracker";

                    if (collisionSection[listBox1.SelectedIndex].State == 2)
                        StateSection = "normal mode";
                    else if (collisionSection[listBox1.SelectedIndex].State == 3)
                        StateSection = "awakening mode";
                    else
                        StateSection = "unknown";

                    if (collisionSection[listBox1.SelectedIndex].EnablerBone == 0)
                    {
                        LoadBone = "enabled, hurtbox loaded: " + collisionSection[listBox1.SelectedIndex].BoneName;
                    }
                    else if (collisionSection[listBox1.SelectedIndex].EnablerBone == 1)
                        LoadBone = "disabled";

                    listBox1.Items[listBox1.SelectedIndex] = "Type: " + TypeSection + ", State: " + StateSection + ", hurtbox: " + LoadBone;
                }
            }
                
            else
            {
                MessageBox.Show("Select entry");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int index = listBox1.SelectedIndex;
                collisionSection.RemoveAt(listBox1.SelectedIndex);
                EntryCount--;
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.SelectedIndex = index - 1;
            }
            else
            {
                MessageBox.Show("Select entry");
            }
        }

        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool.collisionSecTypeValue.Clear();
            tool.collisionSecStateValue.Clear();
            tool.collisionSecEnablerBoneValue.Clear();
            tool.collisionSecBoneName.Clear();
            tool.collisionSecRadiusValue.Clear();
            tool.collisionSecYPosValue.Clear();
            tool.collisionSecZPosValue.Clear();

            for (int c=0; c<EntryCount; c++) {
                tool.collisionSecTypeValue.Add(collisionSection[c].Type.DeepClone());
                tool.collisionSecStateValue.Add(collisionSection[c].State.DeepClone());
                tool.collisionSecEnablerBoneValue.Add(collisionSection[c].EnablerBone.DeepClone());
                tool.collisionSecBoneName.Add(collisionSection[c].BoneName.DeepClone());
                tool.collisionSecRadiusValue.Add(collisionSection[c].Radius.DeepClone());
                tool.collisionSecYPosValue.Add(collisionSection[c].YPos.DeepClone());
                tool.collisionSecZPosValue.Add(collisionSection[c].ZPos.DeepClone());

            }
            tool.collisionSecCount = EntryCount;
            tool.collisionChanged = true;
            MessageBox.Show("Collision data saved.");
        }
    }
}
