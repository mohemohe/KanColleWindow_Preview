using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KanColle
{
    public partial class Form3 : Form
    {
        #region 変数（というか定数）

        int id;
        string[,] title = { {"2", "遠征 - 第2艦隊"},
                            {"4", "遠征 - 第3艦隊"},
                            {"6", "遠征 - 第4艦隊"},
                            {"8", "入渠 - ドック1"},
                            {"9", "入渠 - ドック2"},
                            {"11", "入渠 - ドック3"},
                            {"13", "入渠 - ドック4"},
                            {"22", "工廠 - ドック1"},
                            {"20", "工廠 - ドック2"},
                            {"18", "工廠 - ドック3"},
                            {"16", "工廠 - ドック4"} };

        string[] name = {   "----",
                            "1: 練習航海", 
                            "2: 長距離練習航海", 
                            "3: 警備任務", 
                            "4: 対潜警戒任務", 
                            "5: 海上護衛任務", 
                            "6: 防空射撃演習", 
                            "7: 観艦式予行", 
                            "8: 観艦式", 
                            "9: タンカー護衛任務", 
                            "10: 強行偵察任務", 
                            "11: ボーキサイト輸送任務",
                            "12: 資源輸送任務", 
                            "13: 鼠輸送作戦", 
                            "14: 包囲陸戦隊撤収作戦", 
                            "15: 囮機動部隊支援作戦", 
                            "16: 艦隊決戦援護作戦", 
                            "17: 敵地偵察作戦", 
                            "18: 航空機輸送作戦", 
                            "19: 北号作戦", 
                            "20: 潜水艦哨戒任務", 
                            "25: 通商破壊作戦", 
                            "26: 敵母港空襲作戦"   };

        int[,] time = new int[,] {  {0, 0, 0},
                                    {0, 15, 0},
                                    {0, 30, 0},
                                    {0, 20, 0},
                                    {0, 50, 0},
                                    {1, 30, 0},
                                    {0, 40, 0},
                                    {1, 0, 0},
                                    {3, 0, 0},
                                    {4, 0, 0},
                                    {1, 30, 0},
                                    {5, 0, 0},
                                    {8, 0, 0},
                                    {4, 0, 0},
                                    {6, 0, 0},
                                    {12, 0, 0},
                                    {15, 0, 0},
                                    {0, 45, 0},
                                    {5, 0, 0},
                                    {6, 0, 0},
                                    {2, 0, 0},
                                    {40, 0, 0},
                                    {80, 0, 0}  };

        #endregion

        public Form3(int _id)
        {
            InitializeComponent();

            int i;
            id = _id;

            for (i = 0; i <= 10; i++)
            {
                if (title[i, 0] == id.ToString())
                {
                    break;
                }
            }

            this.Text = title[i, 1];
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (id > 7)
            {
                groupBox2.Visible = false;
            }

            for (int i = 0; i <= name.Length - 1; i++)
            {
                comboBox1.Items.Add(name[i]);
            }

            this.ActiveControl = this.numericUpDown1;

            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown2.TabIndex = 2;
            this.numericUpDown3.TabIndex = 1;
            this.button1.TabIndex = 3;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = comboBox1.SelectedIndex;

            numericUpDown1.Value = time[select, 0];
            numericUpDown2.Value = time[select, 2];
            numericUpDown3.Value = time[select, 1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                globVal.enseiName = comboBox1.SelectedItem.ToString();
            }
            catch
            {
                if (id < 7)
                {
                    globVal.enseiName = "----";
                }
                else
                {
                    globVal.enseiName = "";
                }
            }
            
            globVal.enseiTime_hour = (int)numericUpDown1.Value;
            globVal.enseiTime_minute = (int)numericUpDown3.Value;
            globVal.enseiTime_second = (int)numericUpDown2.Value;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
