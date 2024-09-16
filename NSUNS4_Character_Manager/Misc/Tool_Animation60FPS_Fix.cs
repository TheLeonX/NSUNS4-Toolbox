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

namespace NSUNS4_Character_Manager.Misc {
    public partial class Tool_Animation60FPS_Fix : Form {
        public Tool_Animation60FPS_Fix() {
            InitializeComponent();
        }

        private void Tool_Animation60FPS_Fix_DragDrop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] files_anim = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files_anim) {
                    DirectoryInfo d = new DirectoryInfo(filePath);
                    FileInfo[] Files = d.GetFiles("*.anm", SearchOption.AllDirectories);

                    for (int x = 0; x < Files.Count(); x++) {
                        byte[] animation_file = File.ReadAllBytes(Files[x].FullName);
                        byte[] updated_animation_file = new byte[0];
                        int EntryCount = Main.b_ReadIntRevFromTwoBytes(animation_file, 0x08);
                        int ClumpCount = Main.b_ReadIntRevFromTwoBytes(animation_file, 0x0C);
                        int OtherEntryCount = Main.b_ReadIntRevFromTwoBytes(animation_file, 0x0E);
                        int CoordCount = Main.b_ReadIntRev(animation_file, 0x10);
                        int EntryPosition = 0x14;
                        for (int clump = 0; clump < ClumpCount; clump++) {
                            EntryPosition += 0x04;
                            int BoneCount = Main.b_ReadIntRevFromTwoBytes(animation_file, EntryPosition);
                            EntryPosition += 0x02;
                            int ModelCount = Main.b_ReadIntRevFromTwoBytes(animation_file, EntryPosition);
                            EntryPosition += 0x02;
                            EntryPosition += (BoneCount + ModelCount) * 0x04;
                        }
                        EntryPosition += OtherEntryCount * 0x04;
                        EntryPosition += CoordCount * 0x08;
                        updated_animation_file = Main.b_AddBytes(updated_animation_file, animation_file, 0, 0, EntryPosition);
                        for (int entry = 0; entry < EntryCount; entry++) {
                            //MessageBox.Show(entry.ToString("X2"));
                            int EntryLastPosition = EntryPosition;
                            int ClumpIndex = Main.b_ReadIntRevFromTwoBytes(animation_file, EntryLastPosition);
                            EntryLastPosition += 0x02;
                            int CoordIndex = Main.b_ReadIntRevFromTwoBytes(animation_file, EntryLastPosition);
                            EntryLastPosition += 0x02;
                            int EntryFormat = Main.b_ReadIntRevFromTwoBytes(animation_file, EntryLastPosition);
                            EntryLastPosition += 0x02;
                            int CurveCount = Main.b_ReadIntRevFromTwoBytes(animation_file, EntryLastPosition);
                            EntryLastPosition += 0x02;

                            List<int> CurveFrameCountList = new List<int>();
                            List<int> CurveFormatList = new List<int>();

                            byte[] EntryHeader = new byte[0];
                            for (int curveHeader = 0; curveHeader < CurveCount; curveHeader++) {
                                int CurveIndex = Main.b_ReadIntRevFromTwoBytes(animation_file, EntryLastPosition);
                                EntryLastPosition += 0x02;
                                int CurveFormat = Main.b_ReadIntRevFromTwoBytes(animation_file, EntryLastPosition);
                                EntryLastPosition += 0x02;
                                int FrameCount = Main.b_ReadIntRevFromTwoBytes(animation_file, EntryLastPosition);
                                EntryLastPosition += 0x04;
                                CurveFormatList.Add(CurveFormat);
                                CurveFrameCountList.Add(FrameCount);
                            }
                            EntryHeader = Main.b_ReadByteArray(animation_file, EntryPosition, 8);
                            if (EntryFormat != 0x04) {
                                for (int curveHeader = 0; curveHeader < CurveCount; curveHeader++) {
                                    switch (CurveFormatList[curveHeader]) {
                                        case 0x5:
                                        case 0x8:
                                        case 0x15:
                                            EntryLastPosition += 0x0C * CurveFrameCountList[curveHeader];
                                            break;
                                        case 0x6:
                                            EntryLastPosition += 0x10 * CurveFrameCountList[curveHeader];
                                            break;
                                        case 0xA:
                                            EntryLastPosition += 0x14 * CurveFrameCountList[curveHeader];
                                            break;
                                        case 0xB:
                                        case 0x16:
                                        case 0x18:
                                            EntryLastPosition += 0x4 * CurveFrameCountList[curveHeader];
                                            break;
                                        case 0xC:
                                            EntryLastPosition += 0x8 * CurveFrameCountList[curveHeader];
                                            break;
                                        case 0xF:
                                            EntryLastPosition += 0x2 * CurveFrameCountList[curveHeader];
                                            if (CurveFrameCountList[curveHeader] % 2 != 0) {
                                                EntryLastPosition += 0x2;
                                            }
                                            break;
                                        case 0x10:
                                            EntryLastPosition += 0x6 * CurveFrameCountList[curveHeader];
                                            if (CurveFrameCountList[curveHeader] % 2 != 0) {
                                                EntryLastPosition += 0x2;
                                            }
                                            break;
                                        case 0x11:
                                            EntryLastPosition += 0x8 * CurveFrameCountList[curveHeader];
                                            break;
                                        case 0x14:
                                            EntryLastPosition += 0x3 * CurveFrameCountList[curveHeader];
                                            EntryLastPosition += CurveFrameCountList[curveHeader] % 4;
                                            break;
                                        case 0x1D:
                                            EntryLastPosition += 0x2 * CurveFrameCountList[curveHeader];
                                            if (CurveFrameCountList[curveHeader] % 4 != 0) {
                                                EntryLastPosition += 0x2;
                                            }
                                            break;
                                    }
                                }
                                //MessageBox.Show("Entry position = " + EntryPosition.ToString("X2")+", EntryLastPosition = " + EntryLastPosition.ToString("X2"));
                                updated_animation_file = Main.b_AddBytes(updated_animation_file, Main.b_ReadByteArray(animation_file, EntryPosition, EntryLastPosition - EntryPosition));
                                EntryPosition = EntryLastPosition;
                            } else {
                                updated_animation_file = Main.b_AddBytes(updated_animation_file, EntryHeader);
                                for (int curveHeader = 0; curveHeader < CurveCount; curveHeader++) {
                                    byte[] byteCurveIndex = new byte[2] {
                                            BitConverter.GetBytes(curveHeader)[1],
                                            BitConverter.GetBytes(curveHeader)[0]
                                        };
                                    updated_animation_file = Main.b_AddBytes(updated_animation_file, byteCurveIndex);
                                    if (CurveFormatList[curveHeader] != 0x16) {
                                        byte[] byteCurveFormat = new byte[2] {
                                            BitConverter.GetBytes(CurveFormatList[curveHeader])[1],
                                            BitConverter.GetBytes(CurveFormatList[curveHeader])[0]
                                        };
                                        byte[] byteCurveCount = new byte[2] {
                                            BitConverter.GetBytes(CurveFrameCountList[curveHeader])[1],
                                            BitConverter.GetBytes(CurveFrameCountList[curveHeader])[0]
                                        };
                                        updated_animation_file = Main.b_AddBytes(updated_animation_file, byteCurveFormat);
                                        updated_animation_file = Main.b_AddBytes(updated_animation_file, byteCurveCount);
                                    } else {
                                        byte[] byteCurveCount = new byte[2] {
                                            BitConverter.GetBytes((CurveFrameCountList[curveHeader] * 2) + 1)[1],
                                            BitConverter.GetBytes((CurveFrameCountList[curveHeader] * 2) + 1)[0]
                                        };
                                        updated_animation_file = Main.b_AddBytes(updated_animation_file, new byte[2] { 0x00, 0x0C });
                                        updated_animation_file = Main.b_AddBytes(updated_animation_file, byteCurveCount);
                                    }
                                    updated_animation_file = Main.b_AddBytes(updated_animation_file, new byte[2] { 0x00, 0x0C });
                                }
                                for (int curveHeader = 0; curveHeader < CurveCount; curveHeader++) {


                                    switch (CurveFormatList[curveHeader]) {
                                        case 0xC:
                                            for (int c = 0; c < CurveFrameCountList[curveHeader]; c++) {

                                                updated_animation_file = Main.b_AddBytes(updated_animation_file, Main.b_ReadByteArray(animation_file, EntryLastPosition, 8));
                                                EntryLastPosition += 0x8;
                                            }
                                            break;
                                        case 0x18:
                                            for (int c = 0; c < CurveFrameCountList[curveHeader]; c++) {

                                                updated_animation_file = Main.b_AddBytes(updated_animation_file, Main.b_ReadByteArray(animation_file, EntryLastPosition, 4));
                                                EntryLastPosition += 0x4;
                                            }
                                            break;
                                        case 0xB:
                                            for (int c = 0; c < CurveFrameCountList[curveHeader]; c++) {

                                                updated_animation_file = Main.b_AddBytes(updated_animation_file, Main.b_ReadByteArray(animation_file, EntryLastPosition, 4));
                                                EntryLastPosition += 0x4;
                                            }
                                            break;
                                        case 0x16:
                                            float value = 0;
                                            for (int c = 0; c < CurveFrameCountList[curveHeader]; c++) {
                                                value = Main.b_ReadFloatRev(animation_file, EntryLastPosition);

                                                updated_animation_file = Main.b_AddBytes(updated_animation_file, BitConverter.GetBytes(c * 0x64), 1);
                                                updated_animation_file = Main.b_AddBytes(updated_animation_file, BitConverter.GetBytes(value), 1);
                                                updated_animation_file = Main.b_AddBytes(updated_animation_file, BitConverter.GetBytes((c * 0x64) + 0x32), 1);
                                                updated_animation_file = Main.b_AddBytes(updated_animation_file, BitConverter.GetBytes(value),1);
                                                EntryLastPosition += 0x04;
                                            }
                                            updated_animation_file = Main.b_AddBytes(updated_animation_file, new byte[4] {0xFF,0xFF,0xFF,0xFF});
                                            updated_animation_file = Main.b_AddBytes(updated_animation_file, BitConverter.GetBytes(value),1);
                                            break;
                                    }
                                }
                                EntryPosition = EntryLastPosition;
                            }
                        }
                        File.WriteAllBytes(Files[x].FullName, updated_animation_file);
                    }

                }
                MessageBox.Show("Finished converting!");

            }
        }

        private void Tool_Animation60FPS_Fix_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        private void Tool_Animation60FPS_Fix_Load(object sender, EventArgs e) {

        }
    }
}
