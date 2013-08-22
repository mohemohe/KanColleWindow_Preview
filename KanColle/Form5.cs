using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TweetSharp;

namespace KanColle
{
    public partial class Form5 : Form
    {
        #region 変数・定数

        string CurrentDir = Application.StartupPath;

        //一般
        bool checkUpdate;
        bool allowUpdate;
        bool showTimer;
        bool moveTimer;
        bool playSound;
        string soundPath1;

        //レイアウト
        int formAlgo;
        int formSizeX;
        int formSizeY;
        int offsetX;
        int offsetY;

        string str1;
        string str2;
        string str4;
        string str3;

        //twitter連携

        static string key = "V4cTr9omBIOx1tDImO7Ug";
        string _key;
        static string secret = "ieJHxvor6GkatnbpfJkwMQGaapyJC8WwVGBY9Gw3jaI";
        string _secret;
        string pin;
        TwitterService service;
        OAuthRequestToken requestToken;
        OAuthAccessToken access;
        string token;
        string t_secret;
        bool auth;

        #endregion

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            tabControl1.ItemSize = new Size(0, 1);
            panel1.Width = this.ClientSize.Width;

            InitializeUI();
            readSettings();
            applyUI();
        }

        void InitializeUI()
        {
            listBox1.SelectedIndex = 0;
            comboBox1.SelectedIndex = 1;
        }

        #region 設定の読み書き

        void readSettings()
        {
            //一般
            checkUpdate = globVal._checkUpdate;
            allowUpdate = globVal._allowUpdate;
            showTimer = globVal._showTimer;
            moveTimer = globVal.moveForm2;
            playSound = globVal._playSound;
            soundPath1 = globVal._soundPath1;

            //レイアウト
            formAlgo = globVal._formAlgo;
            formSizeX = globVal._formSizeX;
            formSizeY = globVal._formSizeY;
            offsetX = globVal._offsetX;
            offsetY = globVal._offsetY;

            //twitter連携
            auth = globVal._twitter_auth;
        }

        void writeSettings()
        {
            //一般
            globVal._checkUpdate = checkBox4.Checked;
            globVal._allowUpdate = checkBox1.Checked;
            globVal._showTimer = checkBox3.Checked;
            globVal.moveForm2 = checkBox2.Checked;
            globVal._moveTimer = globVal.moveForm2;
            globVal._playSound = checkBox5.Checked;
            globVal._soundPath1 = soundPath1;

            //レイアウト
            globVal._formAlgo = comboBox1.SelectedIndex;
            globVal._formSizeX = trackBar1.Value;
            globVal._formSizeY = trackBar2.Value;
            globVal._offsetX = trackBar4.Value;
            globVal._offsetY = trackBar3.Value;

            //twitter連携
            globVal._twitter_auth = auth;
            if (auth == true)
            {
                globVal._twitter_key = key;
                globVal._twitter_secret = secret;
                globVal._twitter_token = token;
                globVal._twitter_t_secret = t_secret;
            }
            else
            {
                globVal._twitter_key = "null";
                globVal._twitter_secret = "null";
                globVal._twitter_token = "null";
                globVal._twitter_t_secret = "null";
            }
        }

        #endregion

        //UI反映
        void applyUI()
        {
            //一般
            checkBox4.Checked = checkUpdate;
            checkBox1.Checked = allowUpdate;
            checkBox3.Checked = showTimer;
            checkBox2.Checked = globVal.moveForm2;
            checkBox5.Checked = playSound;
            try
            {
                textBox4.Text = arPath.absolutePath(CurrentDir, soundPath1);
            }
            catch
            {
                
            }

            //レイアウト
            comboBox1.SelectedIndex = formAlgo;
            trackBar1.Value = formSizeX;
            trackBar2.Value = formSizeY;
            trackBar4.Value = offsetX;
            trackBar3.Value = offsetY;

            calcLayout();

            label1.Text = "幅: " + str1;
            label2.Text = "高さ: " + str2;
            label4.Text = "X方向: " + str4;
            label3.Text = "Y方向: " + str3;

            //twitter連携
            if (auth == true)
            {
                label9.Text = "認証済みです";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button4.Enabled = false;
                button3.Enabled = false;

                button5.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
            }
        }

        //タブ切り替え
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = listBox1.SelectedIndex;
        }

        #region レイアウト

        void calcLayout()
        {
            if (trackBar1.Value > 0)
            {
                str1 = "+" + trackBar1.Value.ToString();
            }
            else
            {
                str1 = trackBar1.Value.ToString();
            }

            if (trackBar2.Value > 0)
            {
                str2 = "+" + trackBar2.Value.ToString();
            }
            else
            {
                str2 = trackBar2.Value.ToString();
            }

            if (trackBar4.Value > 0)
            {
                str4 = "+" + trackBar4.Value.ToString();
            }
            else
            {
                str4 = trackBar4.Value.ToString();
            }

            if (trackBar3.Value > 0)
            {
                str3 = "+" + trackBar3.Value.ToString();
            }
            else
            {
                str3 = trackBar3.Value.ToString();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            calcLayout();

            label1.Text = "幅: " + str1;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            calcLayout();

            label2.Text = "高さ: " + str2;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            calcLayout();

            label4.Text = "X方向: " + str4;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            calcLayout();

            label3.Text = "Y方向: " + str3;
        }

        #endregion

        #region twitter連携

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                _key = key;
                _secret = secret;
            }
            else
            {
                _key = textBox1.Text;
                _secret = textBox2.Text;
            }

            service = new TwitterService(_key, _secret);
            requestToken = service.GetRequestToken();
            Uri uri = service.GetAuthenticationUrl(requestToken);

            Process.Start(uri.ToString());

            textBox3.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pin = textBox3.Text;

            service = new TwitterService(_key, _secret);

            try
            {
                access = service.GetAccessToken(requestToken, pin);
            }
            catch (Exception)
            {
                label9.Text = "認証に失敗しました";
                return;
            }

            token = access.Token;
            t_secret = access.TokenSecret;

            try
            {
                service.AuthenticateWith(token, t_secret);
            }
            catch
            {
                label9.Text = "認証に失敗しました";
                return;
            }

            auth = true;
            label9.Text = "認証済みです";

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            button5.Enabled = true;
        }

        #endregion

        //キャンセル
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //OK
        private void button2_Click(object sender, EventArgs e)
        {
            globVal cv = new globVal();

            writeSettings();
            cv.writeSettings();

            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            auth = false;
            label9.Text = "認証されていません";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            button4.Enabled = true;

            button5.Enabled = false;
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
                soundPath1 = arPath.relativePath(CurrentDir, textBox4.Text);
            }
        }

    }
}
