using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace KanColle
{
    public partial class Form7 : Form
    {
        string CurrentDir = Application.StartupPath;

        globVal cv = new globVal();

        int currentPage = 0;
        bool complete = false;

        string txt1;
        string txt2 = "The MIT License (MIT)\n\nCopyright ©  2013 もっへもへ\n\n以下に定める条件に従い、本ソフトウェアおよび関連文書のファイル（以下「ソフトウェア」）の複製を取得するすべての人に対し、ソフトウェアを無制限に扱うことを無償で許可します。これには、ソフトウェアの複製を使用、複写、変更、結合、掲載、頒布、サブライセンス、および/または販売する権利、およびソフトウェアを提供する相手に同じことを許可する権利も無制限に含まれます。\n\n上記の著作権表示および本許諾表示を、ソフトウェアのすべての複製または重要な部分に記載するものとします。\n\nソフトウェアは「現状のまま」で、明示であるか暗黙であるかを問わず、何らの保証もなく提供されます。ここでいう保証とは、商品性、特定の目的への適合性、および権利非侵害についての保証も含みますが、それに限定されるものではありません。 作者または著作権者は、契約行為、不法行為、またはそれ以外であろうと、ソフトウェアに起因または関連し、あるいはソフトウェアの使用またはその他の扱いによって生じる一切の請求、損害、その他の義務について何らの責任も負わないものとします。";
        int labelHeight;
        bool txtToggle = false;

        public Form7()
        {
            InitializeComponent();
        }

        //タブと枠を隠す
        private void Form7_Load(object sender, EventArgs e)
        {
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Top = -5;

            if(File.Exists(CurrentDir + "\\SE\\se01.wav"))
            {
                textBox4.Text = CurrentDir + "\\SE\\se01.wav";
            }
            else
            {
                checkBox5.Checked = false;
            }        
        }

        void writeSettings()
        {
            globVal._agree = complete;

            globVal._checkUpdate = checkBox4.Checked;
            globVal._allowUpdate = checkBox1.Checked;
            globVal._showTimer = checkBox3.Checked;
            globVal._moveTimer = checkBox2.Checked;
            globVal.moveForm2 = checkBox2.Checked;

            globVal._playSound = checkBox5.Checked;
            try
            {
                globVal._soundPath1 = arPath.relativePath(CurrentDir, textBox4.Text);
            }
            catch
            {
                globVal._soundPath1 = "";
            }

            bool success = cv.writeSettings();

            if (success == false)
            {
                MessageBox.Show("フォルダに書き込み権限がありません。\n書き込み可能なフォルダで実行してください。");

                Environment.Exit(0);
            }
        }

        #region 終了処理

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (complete == true)
            {
                Application.Restart();
                Environment.Exit(0);
            }

            DialogResult result = MessageBox.Show("終了しますか？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region タブ移動

        private void button2_Click(object sender, EventArgs e)
        {
            if (complete == true)
            {
                writeSettings();

                this.Close();
            }

            currentPage++;

            tabControl1.SelectedIndex = currentPage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentPage--;

            tabControl1.SelectedIndex = currentPage;
        }

        #endregion

        //UI制御
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            complete = false;
            button2.Text = "次へ(&N) >";


            if (currentPage == 0)
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }

            if (currentPage == 0 && (!(radioButton3.Checked)))
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }

            if (currentPage == 1 && (!(radioButton2.Checked)))
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }

            if (currentPage == tabControl1.TabPages.Count - 1)
            {
                complete = true;

                button2.Text = "完了(&C)";
            }
            
        }

        //同意・非同意
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked && tabControl1.SelectedIndex == 1)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        //規約まとめ
        private void button4_Click(object sender, EventArgs e)
        {
            if (txtToggle == false)
            {
                txt1 = label7.Text;
                labelHeight = label7.Height;

                label7.Text = txt2;
                label7.Height = 200;
                button4.Text = "英原文を表示";

                txtToggle = true;
            }
            else
            {
                label7.Height = labelHeight;
                label7.Text = txt1;
                button4.Text = "日本語訳を表示";

                txtToggle = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked && tabControl1.SelectedIndex == 0)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.AutoUpgradeEnabled = true;
            openFileDialog1.InitialDirectory = CurrentDir + "\\SE";
            openFileDialog1.FileName = "";

            openFileDialog1.ShowDialog();

            if (File.Exists(openFileDialog1.FileName) == true)
            {
                textBox4.Text = openFileDialog1.FileName;
            }
        }

    }
}
