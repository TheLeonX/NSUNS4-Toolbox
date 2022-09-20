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
    public partial class Tool_DuelPlayerParamEditor_settings : Form
    {

        public List<float> Speed_List = new List<float>();
        public byte[] ListSave1 = new byte[36];
        public byte[] ListSave2 = new byte[16];
        public byte[] ListSaveAwa = new byte[84];
        public int set_index = 0;

        public Tool_DuelPlayerParamEditor tool;

        public Tool_DuelPlayerParamEditor_settings()
        {
            InitializeComponent();
        }
		public Tool_DuelPlayerParamEditor_settings(byte[] list, byte[] list2, byte[] awalist, string BinName, Tool_DuelPlayerParamEditor t, int Index, int Mode = -1)
		{
			InitializeComponent();
            char_id.Text = BinName;
            ListSave1 = list;
            ListSave2 = list2;
            ListSaveAwa = awalist;
            set_index = Index;
            tool = t;
            byte[] Speed = new byte[4]
                {
                    list[0],
                    list[1],
                    list[2],
                    list[3]
                };
            float SpeedValueFloat = Main.b_ReadFloat(Speed, 0);
            spd_value.Value = (decimal)SpeedValueFloat;

            byte[] CkrDashSpeed = new byte[4]
            {
                    list[4],
                    list[5],
                    list[6],
                    list[7]
            };
            float CkrDashSpeedValueFloat = Main.b_ReadFloat(CkrDashSpeed, 0);
            ckrspd_v.Value = (decimal)CkrDashSpeedValueFloat;
            byte[] guarddamage = new byte[4]
            {
                    list[8],
                    list[9],
                    list[10],
                    list[11]
            };
            float guarddamageValueFloat = Main.b_ReadFloat(guarddamage, 0);
            grddmg_v.Value = (decimal)guarddamageValueFloat;

            byte[] unknown_1 = new byte[4]
            {
                    list[12],
                    list[13],
                    list[14],
                    list[15]
            };
            float unknown_1_ValueFloat = Main.b_ReadFloat(unknown_1, 0);
            unk1_v.Value = (decimal)unknown_1_ValueFloat;

            byte[] attack = new byte[4]
            {
                    list[16],
                    list[17],
                    list[18],
                    list[19]
            };
            float attackValueFloat = Main.b_ReadFloat(attack, 0);
            atk_v.Value = (decimal)attackValueFloat;
            byte[] defense = new byte[4]
            {
                    list[20],
                    list[21],
                    list[22],
                    list[23]
            };
            float defenseValueFloat = Main.b_ReadFloat(defense, 0);
            def_v.Value = (decimal)defenseValueFloat;
            byte[] assistdamage = new byte[4]
            {
                    list[24],
                    list[25],
                    list[26],
                    list[27]
            };
            float assistdamageValueFloat = Main.b_ReadFloat(assistdamage, 0);
            admg_v.Value = (decimal)assistdamageValueFloat;
            byte[] itemduration = new byte[4]
            {
                    list[28],
                    list[29],
                    list[30],
                    list[31]
            };
            float itemdurationValueFloat = Main.b_ReadFloat(itemduration, 0);
            item_v.Value = (decimal)itemdurationValueFloat;
            byte[] chakraCharge = new byte[4]
            {
                    list[32],
                    list[33],
                    list[34],
                    list[35]
            };
            float chakraChargeValueFloat = Main.b_ReadFloat(chakraCharge, 0);
            ckrcrgspd_v.Value = (decimal)chakraChargeValueFloat;

            byte[] AwaSpeed = new byte[4]
               {
                    awalist[0],
                    awalist[1],
                    awalist[2],
                    awalist[3]
               };
            float AwaSpeedValueFloat = Main.b_ReadFloat(AwaSpeed, 0);
            awaspd_value.Value = (decimal)AwaSpeedValueFloat;
            byte[] AwaCkrDashSpeed = new byte[4]
              {
                    awalist[4],
                    awalist[5],
                    awalist[6],
                    awalist[7]
              };
            float AwaCkrDashSpeedValueFloat = Main.b_ReadFloat(AwaCkrDashSpeed, 0);
            awackrspd_value.Value = (decimal)AwaCkrDashSpeedValueFloat;

            byte[] CountHP = new byte[4]
              {
                    list2[0],
                    list2[1],
                    list2[2],
                    list2[3]
              };
            float CountHPValueFloat = Main.b_ReadFloat(CountHP, 0);
            start_awa_v.Value = (decimal)CountHPValueFloat;
            byte[] ExtraAbilityCD = new byte[4]
              {
                    awalist[80],
                    awalist[81],
                    awalist[82],
                    awalist[83]
              };
            float ExtraAbilityCDValueFloat = Main.b_ReadFloat(ExtraAbilityCD, 0);
            ex_ab_cd_v.Value = (decimal)ExtraAbilityCDValueFloat;
            air_dsh_spd_v.Value = list2[4];
            air_dsh_d_v.Value = list2[6];
            gr_ckr_dsh_d_v.Value = list2[8];
            awa_air_dsh_spd_v.Value = awalist[8];
            awa_air_dsh_d_v.Value = awalist[10];
            awa_gr_ckr_dsh_d_v.Value = awalist[12];
            if (awalist[64]==0x01)
            {
                awa_debuff_cb.Checked = true;
            }
            else
            {
                awa_debuff_cb.Checked = false;
            }
        }
        private void Tool_DuelPlayerParamEditor_settings_Load(object sender, EventArgs e)
        {

        }

        private void spd_value_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float Speed = (float)spd_value.Value;
            float CkrDashSpeed = (float)ckrspd_v.Value;
            float guarddamage = (float)grddmg_v.Value;
            float unknown_1 = (float)unk1_v.Value;
            float attack = (float)atk_v.Value;
            float defense = (float)def_v.Value;
            float assistdamage = (float)admg_v.Value;
            float itemduration = (float)item_v.Value;
            float chakraCharge = (float)ckrcrgspd_v.Value;
            float AwaSpeed = (float)awaspd_value.Value;
            float AwaCkrDashSpeed = (float)awackrspd_value.Value;
            float CountHP = (float)start_awa_v.Value;
            float ExtraAbilityCD = (float)ex_ab_cd_v.Value;
            byte[] SpeedByte = new byte[4];
            SpeedByte = BitConverter.GetBytes(Speed);
            byte[] CkrDashSpeedByte = new byte[4];
            CkrDashSpeedByte = BitConverter.GetBytes(CkrDashSpeed);
            byte[] guarddamageByte = new byte[4];
            guarddamageByte = BitConverter.GetBytes(guarddamage);
            byte[] unknown_1Byte = new byte[4];
            unknown_1Byte = BitConverter.GetBytes(unknown_1);
            byte[] attackByte = new byte[4];
            attackByte = BitConverter.GetBytes(attack);
            byte[] defenseByte = new byte[4];
            defenseByte = BitConverter.GetBytes(defense);
            byte[] assistdamageByte = new byte[4];
            assistdamageByte = BitConverter.GetBytes(assistdamage);
            byte[] itemdurationByte = new byte[4];
            itemdurationByte = BitConverter.GetBytes(itemduration);
            byte[] chakraChargeByte = new byte[4];
            chakraChargeByte = BitConverter.GetBytes(chakraCharge);
            byte[] newListSave1 = new byte[36]
            {
                SpeedByte[0],
                SpeedByte[1],
                SpeedByte[2],
                SpeedByte[3],
                CkrDashSpeedByte[0],
                CkrDashSpeedByte[1],
                CkrDashSpeedByte[2],
                CkrDashSpeedByte[3],
                guarddamageByte[0],
                guarddamageByte[1],
                guarddamageByte[2],
                guarddamageByte[3],
                unknown_1Byte[0],
                unknown_1Byte[1],
                unknown_1Byte[2],
                unknown_1Byte[3],
                attackByte[0],
                attackByte[1],
                attackByte[2],
                attackByte[3],
                defenseByte[0],
                defenseByte[1],
                defenseByte[2],
                defenseByte[3],
                assistdamageByte[0],
                assistdamageByte[1],
                assistdamageByte[2],
                assistdamageByte[3],
                itemdurationByte[0],
                itemdurationByte[1],
                itemdurationByte[2],
                itemdurationByte[3],
                chakraChargeByte[0],
                chakraChargeByte[1],
                chakraChargeByte[2],
                chakraChargeByte[3]
            };
            byte[] AwaSpeedByte = new byte[4];
            AwaSpeedByte = BitConverter.GetBytes(AwaSpeed);
            byte[] AwaCkrDashSpeedByte = new byte[4];
            AwaCkrDashSpeedByte = BitConverter.GetBytes(AwaCkrDashSpeed);
            byte[] ExtraAbilityCDByte = new byte[4];
            ExtraAbilityCDByte = BitConverter.GetBytes(ExtraAbilityCD);
            byte[] CountHPByte = new byte[4];
            CountHPByte = BitConverter.GetBytes(CountHP);
            if (awa_debuff_cb.Checked == true)
            {
                ListSaveAwa[64] = 1;
            }
            else
            {
                ListSaveAwa[64] = 0;
            }
            byte[] newListSave2 = new byte[16]
            {
                CountHPByte[0],
                CountHPByte[1],
                CountHPByte[2],
                CountHPByte[3],
                (byte)air_dsh_spd_v.Value,
                ListSave2[5],
                (byte)air_dsh_d_v.Value,
                ListSave2[7],
                (byte)gr_ckr_dsh_d_v.Value,
                ListSave2[9],
                ListSave2[10],
                ListSave2[11],
                ListSave2[12],
                ListSave2[13],
                ListSave2[14],
                ListSave2[15],
            };
            byte[] newListSaveAwa = new byte[84]
            {
                AwaSpeedByte[0],
                AwaSpeedByte[1],
                AwaSpeedByte[2],
                AwaSpeedByte[3],
                AwaCkrDashSpeedByte[0],
                AwaCkrDashSpeedByte[1],
                AwaCkrDashSpeedByte[2],
                AwaCkrDashSpeedByte[3],
                (byte)awa_air_dsh_spd_v.Value,
                ListSaveAwa[9],
                (byte)awa_air_dsh_d_v.Value,
                ListSaveAwa[11],
                (byte)awa_gr_ckr_dsh_d_v.Value,
                ListSaveAwa[13],
                ListSaveAwa[14],
                ListSaveAwa[15],
                ListSaveAwa[16],
                ListSaveAwa[17],
                ListSaveAwa[18],
                ListSaveAwa[19],
                ListSaveAwa[20],
                ListSaveAwa[21],
                ListSaveAwa[22],
                ListSaveAwa[23],
                ListSaveAwa[24],
                ListSaveAwa[25],
                ListSaveAwa[26],
                ListSaveAwa[27],
                ListSaveAwa[28],
                ListSaveAwa[29],
                ListSaveAwa[30],
                ListSaveAwa[31],
                ListSaveAwa[32],
                ListSaveAwa[33],
                ListSaveAwa[34],
                ListSaveAwa[35],
                ListSaveAwa[36],
                ListSaveAwa[37],
                ListSaveAwa[38],
                ListSaveAwa[39],
                ListSaveAwa[40],
                ListSaveAwa[41],
                ListSaveAwa[42],
                ListSaveAwa[43],
                ListSaveAwa[44],
                ListSaveAwa[45],
                ListSaveAwa[46],
                ListSaveAwa[47],
                ListSaveAwa[48],
                ListSaveAwa[49],
                ListSaveAwa[50],
                ListSaveAwa[51],
                ListSaveAwa[52],
                ListSaveAwa[53],
                ListSaveAwa[54],
                ListSaveAwa[55],
                ListSaveAwa[56],
                ListSaveAwa[57],
                ListSaveAwa[58],
                ListSaveAwa[59],
                ListSaveAwa[60],
                ListSaveAwa[61],
                ListSaveAwa[62],
                ListSaveAwa[63],
                ListSaveAwa[64],
                ListSaveAwa[65],
                ListSaveAwa[66],
                ListSaveAwa[67],
                ListSaveAwa[68],
                ListSaveAwa[69],
                ListSaveAwa[70],
                ListSaveAwa[71],
                ListSaveAwa[72],
                ListSaveAwa[73],
                ListSaveAwa[74],
                ListSaveAwa[75],
                ListSaveAwa[76],
                ListSaveAwa[77],
                ListSaveAwa[78],
                ListSaveAwa[79],
                ExtraAbilityCDByte[0],
                ExtraAbilityCDByte[1],
                ExtraAbilityCDByte[2],
                ExtraAbilityCDByte[3],
            };

            tool.SettingList[set_index] = newListSave1;
            tool.Setting2List[set_index] = newListSave2;
            tool.AwaSettingList[set_index] = newListSaveAwa;
            MessageBox.Show("Settings saved correctly.");
        }
    }
}
