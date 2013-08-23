using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanColle
{
    public partial class Form2 : Form
    {
        #region 変数・定数

        string CurrentDir = Application.StartupPath;
        private System.Media.SoundPlayer player = null;

        public static DateTime dtnull = DateTime.MinValue;
        public static TimeSpan tsnull = TimeSpan.Parse("00:00:00");
        DateTime now;

        DateTime datetime2 = dtnull;
        DateTime datetime4 = dtnull;
        DateTime datetime6 = dtnull;
        DateTime datetime8 = dtnull;
        DateTime datetime9 = dtnull;
        DateTime datetime11 = dtnull;
        DateTime datetime13 = dtnull;
        DateTime datetime22 = dtnull;
        DateTime datetime20 = dtnull;
        DateTime datetime18 = dtnull;
        DateTime datetime16 = dtnull;

        TimeSpan spantime2;
        TimeSpan spantime4;
        TimeSpan spantime6;
        TimeSpan spantime8;
        TimeSpan spantime9;
        TimeSpan spantime11;
        TimeSpan spantime13;
        TimeSpan spantime22;
        TimeSpan spantime20;
        TimeSpan spantime18;
        TimeSpan spantime16;

        string name2;
        string name4;
        string name6;

        bool waitPlay2 = false;
        bool waitPlay4 = false;
        bool waitPlay6 = false;
        bool waitPlay8 = false;
        bool waitPlay9 = false;
        bool waitPlay11 = false;
        bool waitPlay13 = false;
        bool waitPlay22 = false;
        bool waitPlay20 = false;
        bool waitPlay18 = false;
        bool waitPlay16 = false;

        string end = "完了しました";
        string none = "----";

        #endregion

        #region 設定の読み書き

        void readSettings()
        {
            name2 = globVal._name1_2;
            name4 = globVal._name1_3;
            name6 = globVal._name1_4;

            datetime2 = globVal._datetime1_2;
            datetime4 = globVal._datetime1_3;
            datetime6 = globVal._datetime1_4;
            datetime8 = globVal._datetime2_1;
            datetime9 = globVal._datetime2_2;
            datetime11 = globVal._datetime2_3;
            datetime13 = globVal._datetime2_4;
            datetime22 = globVal._datetime3_1;
            datetime20 = globVal._datetime3_2;
            datetime18 = globVal._datetime3_3;
            datetime16 = globVal._datetime3_4;
        }

        void writeSettings()
        {
            globVal._name1_2 = name2;
            globVal._name1_3 = name4;
            globVal._name1_4 = name6;

            globVal._datetime1_2 = datetime2;
            globVal._datetime1_3 = datetime4;
            globVal._datetime1_4 = datetime6;
            globVal._datetime2_1 = datetime8;
            globVal._datetime2_2 = datetime9;
            globVal._datetime2_3 = datetime11;
            globVal._datetime2_4 = datetime13;
            globVal._datetime3_1 = datetime22;
            globVal._datetime3_2 = datetime20;
            globVal._datetime3_3 = datetime18;
            globVal._datetime3_4 = datetime16;
        }

        public void applyUI()
        {
            checkBox1.Checked = globVal.moveForm2;
            checkBox2.Checked = globVal._playSound;
        }

        #endregion

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //初回だけ設定ファイルがないとエラーを吐くから
            try
            {
                readSettings();
                applyUI();
            }
            catch (Exception)
            {
                
            }

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                globVal._moveTimer = true;
            }
            else
            {
                globVal._moveTimer = false; 
            }
        }

        #region クリックで登録

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                resist(2);
            }
            else if (((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) && label2.Text == end)
            {
                datetime2 = dtnull;
                spantime2 = tsnull;
                name2 = "";

                label2.ForeColor = Color.Black;
                label2.Text = none;
            }

            writeSettings();
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                resist(4);
            }
            else if (((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) && label4.Text == end)
            {
                datetime4 = dtnull;
                spantime4 = tsnull;
                name4 = "";

                label4.ForeColor = Color.Black;
                label4.Text = none;
            }

            writeSettings();
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                resist(6);
            }
            else if (((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) && label6.Text == end)
            {
                datetime6 = dtnull;
                spantime6 = tsnull;
                name6 = "";

                label6.ForeColor = Color.Black;
                label6.Text = none;
            }

            writeSettings();
        }

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                resist(8);
            }
            else if (((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) && label8.Text == end)
            {
                datetime8 = dtnull;
                spantime8 = tsnull;

                label8.ForeColor = Color.Black;
                label8.Text = none;
            }

            writeSettings();
        }

        private void label9_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                resist(9);
            }
            else if (((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) && label9.Text == end)
            {
                datetime9 = dtnull;
                spantime9 = tsnull;

                label9.ForeColor = Color.Black;
                label9.Text = none;
            }

            writeSettings();
        }

        private void label11_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                resist(11);
            }
            else if (((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) && label11.Text == end)
            {
                datetime11 = dtnull;
                spantime11 = tsnull;

                label11.ForeColor = Color.Black;
                label11.Text = none;
            }

            writeSettings();
        }

        private void label13_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                resist(13);
            }
            else if (((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) && label13.Text == end)
            {
                datetime13 = dtnull;
                spantime13 = tsnull;

                label13.ForeColor = Color.Black;
                label13.Text = none;
            }

            writeSettings();
        }

        private void label22_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                resist(22);
            }
            else if (((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) && label22.Text == end)
            {
                datetime22 = dtnull;
                spantime22 = tsnull;

                label22.ForeColor = Color.Black;
                label22.Text = none;
            }

            writeSettings();
        }

        private void label20_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                resist(20);
            }
            else if (((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) && label20.Text == end)
            {
                datetime20 = dtnull;
                spantime20 = tsnull;

                label20.ForeColor = Color.Black;
                label20.Text = none;
            }

            writeSettings();
        }

        private void label18_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                resist(18);
            }
            else if (((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) && label18.Text == end)
            {
                datetime18 = dtnull;
                spantime18 = tsnull;

                label18.ForeColor = Color.Black;
                label18.Text = none;
            }

            writeSettings();
        }

        private void label16_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                resist(16);
            }
            else if (((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) && label16.Text == end)
            {
                datetime16 = dtnull;
                spantime16 = tsnull;

                label16.ForeColor = Color.Black;
                label16.Text = none;
            }

            writeSettings();
        }

        #endregion

        /// <summary>
        /// 登録画面表示
        /// </summary>
        /// <param name="id">ラベルの識別ID</param>
        void resist(int id)
        {
            Form3 form3 = new Form3(id);
            form3.StartPosition = FormStartPosition.CenterParent;
            form3.ShowDialog(this);

            if (form3.DialogResult == DialogResult.OK)
            {
                remain(id);
            }

            form3.Dispose();
        }

        /// <summary>
        /// 終了予定時刻を登録
        /// </summary>
        /// <param name="id">ラベルの識別ID</param>
        void remain(int id)
        {
            now = DateTime.Now;

            switch (id)
            {
                case 2:
                    name2 = globVal.enseiName;
                    datetime2 = now;
                    datetime2 = datetime2.AddHours(globVal.enseiTime_hour);
                    datetime2 = datetime2.AddMinutes(globVal.enseiTime_minute);
                    datetime2 = datetime2.AddSeconds(globVal.enseiTime_second);
                    break;

                case 4:
                    name4 = globVal.enseiName;
                    datetime4 = now;
                    datetime4 = datetime4.AddHours(globVal.enseiTime_hour);
                    datetime4 = datetime4.AddMinutes(globVal.enseiTime_minute);
                    datetime4 = datetime4.AddSeconds(globVal.enseiTime_second);
                    break;

                case 6:
                    name6 = globVal.enseiName;
                    datetime6 = now;
                    datetime6 = datetime6.AddHours(globVal.enseiTime_hour);
                    datetime6 = datetime6.AddMinutes(globVal.enseiTime_minute);
                    datetime6 = datetime6.AddSeconds(globVal.enseiTime_second);
                    break;

                case 8:
                    datetime8 = now;
                    datetime8 = datetime8.AddHours(globVal.enseiTime_hour);
                    datetime8 = datetime8.AddMinutes(globVal.enseiTime_minute);
                    datetime8 = datetime8.AddSeconds(globVal.enseiTime_second);
                    break;

                case 9:
                    datetime9 = now;
                    datetime9 = datetime9.AddHours(globVal.enseiTime_hour);
                    datetime9 = datetime9.AddMinutes(globVal.enseiTime_minute);
                    datetime9 = datetime9.AddSeconds(globVal.enseiTime_second);
                    break;

                case 11:
                    datetime11 = now;
                    datetime11 = datetime11.AddHours(globVal.enseiTime_hour);
                    datetime11 = datetime11.AddMinutes(globVal.enseiTime_minute);
                    datetime11 = datetime11.AddSeconds(globVal.enseiTime_second);
                    break;

                case 13:
                    datetime13 = now;
                    datetime13 = datetime13.AddHours(globVal.enseiTime_hour);
                    datetime13 = datetime13.AddMinutes(globVal.enseiTime_minute);
                    datetime13 = datetime13.AddSeconds(globVal.enseiTime_second);
                    break;

                case 22:
                    datetime22 = now;
                    datetime22 = datetime22.AddHours(globVal.enseiTime_hour);
                    datetime22 = datetime22.AddMinutes(globVal.enseiTime_minute);
                    datetime22 = datetime22.AddSeconds(globVal.enseiTime_second);
                    break;

                case 20:
                    datetime20 = now;
                    datetime20 = datetime20.AddHours(globVal.enseiTime_hour);
                    datetime20 = datetime20.AddMinutes(globVal.enseiTime_minute);
                    datetime20 = datetime20.AddSeconds(globVal.enseiTime_second);
                    break;

                case 18:
                    datetime18 = now;
                    datetime18 = datetime18.AddHours(globVal.enseiTime_hour);
                    datetime18 = datetime18.AddMinutes(globVal.enseiTime_minute);
                    datetime18 = datetime18.AddSeconds(globVal.enseiTime_second);
                    break;

                case 16:
                    datetime16 = now;
                    datetime16 = datetime16.AddHours(globVal.enseiTime_hour);
                    datetime16 = datetime16.AddMinutes(globVal.enseiTime_minute);
                    datetime16 = datetime16.AddSeconds(globVal.enseiTime_second);
                    break;
            }
        }

        //別スレッドの計算開始
        private async void timer1_Tick(object sender, EventArgs e)
        {
            await TaskEx.Run(() => calcRemain());
            applyLabel();
        }

        //残り時間を計算
        void calcRemain()
        {
            now = DateTime.Now;

            if (datetime2 != dtnull)
            {
                spantime2 = datetime2 - now;
            }

            if (datetime4 != dtnull)
            {
                spantime4 = datetime4 - now;
            }

            if (datetime6 != dtnull)
            {
                spantime6 = datetime6 - now;
            }

            if (datetime8 != dtnull)
            {
                spantime8 = datetime8 - now;
            }

            if (datetime9 != dtnull)
            {
                spantime9 = datetime9 - now;
            }

            if (datetime11 != dtnull)
            {
                spantime11 = datetime11 - now;
            }

            if (datetime13 != dtnull)
            {
                spantime13 = datetime13 - now;
            }

            if (datetime22 != dtnull)
            {
                spantime22 = datetime22 - now;
            }

            if (datetime20 != dtnull)
            {
                spantime20 = datetime20 - now;
            }

            if (datetime18 != dtnull)
            {
                spantime18 = datetime18 - now;
            }

            if (datetime16 != dtnull)
            {
                spantime16 = datetime16 - now;
            }
        }

        //labelに反映
        void applyLabel()
        {
            if (spantime2 != tsnull)
            {
                if (spantime2 > tsnull)
                {
                    label2.ForeColor = Color.Black;
                    label2.Text = spantime2.ToString("hh\\:mm\\:ss") + "\n" + name2;
                    
                    waitPlay2 = true;
                }
                else
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = end;

                    if (player == null && waitPlay2 == true)
                    {
                        playSound();
                        player = null;
                    }

                    waitPlay2 = false;
                }
            }

            if (spantime4 != tsnull)
            {
                if (spantime4 > tsnull)
                {
                    label4.ForeColor = Color.Black;
                    label4.Text = spantime4.ToString("hh\\:mm\\:ss") + "\n" + name4;
                    
                    waitPlay4 = true;
                }
                else
                {
                    label4.ForeColor = Color.Red;
                    label4.Text = end;

                    if (player == null && waitPlay4 == true)
                    {
                        playSound();
                        player = null;
                    }

                    waitPlay4 = false;
                }
            }

            if (spantime6 != tsnull)
            {
                if (spantime6 > tsnull)
                {
                    label6.ForeColor = Color.Black;
                    label6.Text = spantime6.ToString("hh\\:mm\\:ss") + "\n" + name6;

                    waitPlay6 = true;
                }
                else
                {
                    label6.ForeColor = Color.Red;
                    label6.Text = end;

                    if (player == null && waitPlay6 == true)
                    {
                        playSound();
                        player = null;
                    }

                    waitPlay6 = false;
                }
            }

            if (spantime8 != tsnull)
            {
                if (spantime8 > tsnull)
                {
                    label8.ForeColor = Color.Black;
                    label8.Text = spantime8.ToString("hh\\:mm\\:ss");

                    waitPlay8 = true;
                }
                else
                {
                    label8.ForeColor = Color.Red;
                    label8.Text = end;

                    if (player == null && waitPlay8 == true)
                    {
                        playSound();
                        player = null;
                    }
                    
                    waitPlay8 = false;
                }
            }

            if (spantime9 != tsnull)
            {
                if (spantime9 > tsnull)
                {
                    label9.ForeColor = Color.Black;
                    label9.Text = spantime9.ToString("hh\\:mm\\:ss");

                    waitPlay9 = true;
                }
                else
                {
                    label9.ForeColor = Color.Red;
                    label9.Text = end;

                    if (player == null && waitPlay9 == true)
                    {
                        playSound();
                        player = null;
                    }

                    waitPlay9 = false;
                }
            }

            if (spantime11 != tsnull)
            {
                if (spantime11 > tsnull)
                {
                    label11.ForeColor = Color.Black;
                    label11.Text = spantime11.ToString("hh\\:mm\\:ss");

                    waitPlay11 = true;
                }
                else
                {
                    label11.ForeColor = Color.Red;
                    label11.Text = end;

                    if (player == null && waitPlay11 == true)
                    {
                        playSound();
                        player = null;
                    }

                    waitPlay11 = false;
                }
            }

            if (spantime13 != tsnull)
            {
                if (spantime13 > tsnull)
                {
                    label13.ForeColor = Color.Black;
                    label13.Text = spantime13.ToString("hh\\:mm\\:ss");

                    waitPlay13 = true;
                }
                else
                {
                    label13.ForeColor = Color.Red;
                    label13.Text = end;

                    if (player == null && waitPlay13 == true)
                    {
                        playSound();
                        player = null;
                    }

                    waitPlay13 = false;
                }
            }

            if (spantime22 != tsnull)
            {
                if (spantime22 > tsnull)
                {
                    label22.ForeColor = Color.Black;
                    label22.Text = spantime22.ToString("hh\\:mm\\:ss");

                    waitPlay22 = true;
                }
                else
                {
                    label22.ForeColor = Color.Red;
                    label22.Text = end;

                    if (player == null && waitPlay22 == true)
                    {
                        playSound();
                        player = null;
                    }

                    waitPlay22 = false;
                }
            }

            if (spantime20 != tsnull)
            {
                if (spantime20 > tsnull)
                {
                    label20.ForeColor = Color.Black;
                    label20.Text = spantime20.ToString("hh\\:mm\\:ss");

                    waitPlay20 = true;
                }
                else
                {
                    label20.ForeColor = Color.Red;
                    label20.Text = end;

                    if (player == null && waitPlay20 == true)
                    {
                        playSound();
                        player = null;
                    }

                    waitPlay20 = false;
                }
            }

            if (spantime18 != tsnull)
            {
                if (spantime18 > tsnull)
                {
                    label18.ForeColor = Color.Black;
                    label18.Text = spantime18.ToString("hh\\:mm\\:ss");

                    waitPlay18 = true;
                }
                else
                {
                    label18.ForeColor = Color.Red;
                    label18.Text = end;

                    if (player == null && waitPlay18 == true)
                    {
                        playSound();
                        player = null;
                    }

                    waitPlay18 = false;
                }
            }

            if (spantime16 != tsnull)
            {
                if (spantime16 > tsnull)
                {
                    label16.ForeColor = Color.Black;
                    label16.Text = spantime16.ToString("hh\\:mm\\:ss");

                    waitPlay16 = true;
                }
                else
                {
                    label16.ForeColor = Color.Red;
                    label16.Text = end;

                    if (player == null && waitPlay16 == true)
                    {
                        playSound();
                        player = null;
                    }

                    waitPlay16 = false;
                }
            }
        }

        //きたない
        void playSound()
        {
            if (globVal._playSound == true)
            {
                string soundPath1;

                try
                {
                    soundPath1 = arPath.absolutePath(CurrentDir, globVal._soundPath1);
                }
                catch
                {
                    soundPath1 = "";
                }

                if (File.Exists(soundPath1) == true)
                {
                    try
                    {
                        player = new System.Media.SoundPlayer(soundPath1);
                        player.Play();
                    }
                    catch
                    {

                    }
                }

                //try
                //{
                //    player = new System.Media.SoundPlayer(CurrentDir + "\\SE\\se01.wav");
                //    player.Play();
                //}
                //catch
                //{

                //}
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                globVal._playSound = true;
            }
            else
            {
                globVal._playSound = false;
            }
        }
    }    
}
