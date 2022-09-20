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
        public List<int> collisionSecTypeValue = new List<int>();
        public List<int> collisionSecStateValue = new List<int>();
        public List<int> collisionSecEnablerBoneValue = new List<int>();
        public List<long> collisionSecRadiusValue = new List<long>();
        public List<long> collisionSecYPosValue = new List<long>();
        public List<long> collisionSecZPosValue = new List<long>();
        public List<string> collisionSecBoneName = new List<string>();
        public Tool_playerCollisionEditor(Tool_MovesetCoder t, List<int> collisionSecTypeValueList, List<int> collisionSecStateValueList, List<int> collisionSecEnablerBoneValueList, List<long> collisionSecRadiusValueList, List<long> collisionSecYPosValueList, List<long> collisionSecZPosValueList, List<string> collisionSecBoneNameList, int count)
        {
            InitializeComponent();
            tool = t;
            EntryCount = count;
            collisionSecTypeValue = collisionSecTypeValueList;
            collisionSecStateValue = collisionSecStateValueList;
            collisionSecEnablerBoneValue = collisionSecEnablerBoneValueList;
            collisionSecRadiusValue = collisionSecRadiusValueList;
            collisionSecYPosValue = collisionSecYPosValueList;
            collisionSecZPosValue = collisionSecZPosValueList;
            collisionSecBoneName = collisionSecBoneNameList;
            for (int x = 0; x < EntryCount; x++)
            {
                string TypeSection = "";
                string StateSection = "";
                string LoadBone = "";
                if (collisionSecTypeValue[x] == 0)
                    TypeSection = "collision";
                else if (collisionSecTypeValue[x] == 1)
                    TypeSection = "hurtbox";
                else if (collisionSecTypeValue[x] == 2)
                    TypeSection = "tracker";

                if (collisionSecStateValue[x] == 2)
                    StateSection = "normal mode";
                else if (collisionSecStateValue[x] == 3)
                    StateSection = "awakening mode";
                else
                    StateSection = "unknown";

                if (collisionSecEnablerBoneValue[x] == 0)
                {
                    LoadBone = "enabled, hurtbox loaded: " + collisionSecBoneName[x];
                }    
                else if (collisionSecEnablerBoneValue[x] == 1)
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
                comboBox1.SelectedIndex = collisionSecTypeValue[listBox1.SelectedIndex];
                numericUpDown1.Value = collisionSecStateValue[listBox1.SelectedIndex];
                comboBox2.SelectedIndex = collisionSecEnablerBoneValue[listBox1.SelectedIndex];
                textBox1.Text = collisionSecBoneName[listBox1.SelectedIndex];
                numericUpDown2.Value = collisionSecRadiusValue[listBox1.SelectedIndex];
                numericUpDown3.Value = collisionSecYPosValue[listBox1.SelectedIndex];
                numericUpDown4.Value = collisionSecZPosValue[listBox1.SelectedIndex];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                string BoneName = "";
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
                }
                
            }
            else
            {
                MessageBox.Show("Can't create new section.");
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
                    collisionSecTypeValue[listBox1.SelectedIndex] = comboBox1.SelectedIndex;
                    collisionSecStateValue[listBox1.SelectedIndex] = (int)numericUpDown1.Value;
                    collisionSecEnablerBoneValue[listBox1.SelectedIndex] = comboBox2.SelectedIndex;
                    collisionSecBoneName[listBox1.SelectedIndex] = BoneName;
                    collisionSecRadiusValue[listBox1.SelectedIndex] = (long)numericUpDown2.Value;
                    collisionSecYPosValue[listBox1.SelectedIndex] = (long)numericUpDown3.Value;
                    collisionSecZPosValue[listBox1.SelectedIndex] = (long)numericUpDown4.Value;

                    string TypeSection = "";
                    string StateSection = "";
                    string LoadBone = "";
                    if (collisionSecTypeValue[listBox1.SelectedIndex] == 0)
                        TypeSection = "collision";
                    else if (collisionSecTypeValue[listBox1.SelectedIndex] == 1)
                        TypeSection = "hurtbox";
                    else if (collisionSecTypeValue[listBox1.SelectedIndex] == 2)
                        TypeSection = "tracker";

                    if (collisionSecStateValue[listBox1.SelectedIndex] == 2)
                        StateSection = "normal mode";
                    else if (collisionSecStateValue[listBox1.SelectedIndex] == 3)
                        StateSection = "awakening mode";
                    else
                        StateSection = "unknown";

                    if (collisionSecEnablerBoneValue[listBox1.SelectedIndex] == 0)
                    {
                        LoadBone = "enabled, hurtbox loaded: " + collisionSecBoneName[listBox1.SelectedIndex];
                    }
                    else if (collisionSecEnablerBoneValue[listBox1.SelectedIndex] == 1)
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
                collisionSecTypeValue.RemoveAt(listBox1.SelectedIndex);
                collisionSecStateValue.RemoveAt(listBox1.SelectedIndex);
                collisionSecEnablerBoneValue.RemoveAt(listBox1.SelectedIndex);
                collisionSecBoneName.RemoveAt(listBox1.SelectedIndex);
                collisionSecRadiusValue.RemoveAt(listBox1.SelectedIndex);
                collisionSecYPosValue.RemoveAt(listBox1.SelectedIndex);
                collisionSecZPosValue.RemoveAt(listBox1.SelectedIndex);
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
            tool.collisionSecTypeValue = collisionSecTypeValue;
            tool.collisionSecStateValue = collisionSecStateValue;
            tool.collisionSecEnablerBoneValue = collisionSecEnablerBoneValue;
            tool.collisionSecBoneName = collisionSecBoneName;
            tool.collisionSecRadiusValue = collisionSecRadiusValue;
            tool.collisionSecYPosValue = collisionSecYPosValue;
            tool.collisionSecZPosValue = collisionSecZPosValue;
            tool.collisionSecCount = EntryCount;
            tool.collisionChanged = true;
            MessageBox.Show("Collision data saved.");
        }
    }
}
