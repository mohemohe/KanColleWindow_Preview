using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TweetSharp;

namespace KanColle
{
    public partial class Form8 : Form
    {
        string CurrentDir = Application.StartupPath;

        TwitterService service;

        string key;
        string secret;
        string token;
        string t_secret;

        string imgPath;
        string imgUri;

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            readSettings();

            twitterLogin();
        }

        void readSettings()
        {
            key = globVal._twitter_key;
            secret = globVal._twitter_secret;
            token = globVal._twitter_token;
            t_secret = globVal._twitter_t_secret;

            //MessageBox.Show(key + "\n" + secret + "\n" + token + "\n" + t_secret);
        }

        #region OAuth

        private void twitterLogin()
        {
            service = new TwitterService(key, secret);

            try
            {
                service.AuthenticateWith(token, t_secret);
            }
            catch
            {
                toolStripStatusLabel1.Text = "twitterに接続できませんでした";
                return;
            }

            toolStripStatusLabel1.Text = "twitterに接続しました";
        }

        #endregion

        //post
        private async void button1_Click(object sender, EventArgs e)
        {
            buttonsDisable();

            toolStripStatusLabel1.Text = "送信しています...";

            try
            {
                await TaskEx.Run(() => service.SendTweet(new SendTweetOptions { Status = textBox1.Text }));

                textBox1.Text = "";
            }
            catch (Exception)
            {

            }

            toolStripStatusLabel1.Text = "完了しました";

            buttonsEnable();
        }

        string uploadImage(string path)
        {
            byte[] response;
            string xmlRes;

            using (WebClient client = new WebClient())
            {
                var values = new NameValueCollection
                {
                    {
                        "image",
                        Convert.ToBase64String(File.ReadAllBytes(path))
                    }
                };

                client.Headers.Add("Authorization", "Client-ID bedb5a1394d747a");
                response = client.UploadValues("https://api.imgur.com/3/upload.xml", values);

                xmlRes = Encoding.UTF8.GetString(response);
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlRes);

            try
            {
                XmlElement xmlRoot = xmlDoc.DocumentElement;
                XmlNodeList xmlNode = xmlRoot.GetElementsByTagName("link");
                XmlElement uri = (XmlElement)xmlNode.Item(0);

                return uri.InnerText;
            }
            catch (System.Xml.XmlException)
            {
                return null;
            }
        }

        void buttonsDisable()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        void buttonsEnable()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 1;

            if (!(Directory.Exists(CurrentDir + "\\SS")))
            {
                try
                {
                    Directory.CreateDirectory(CurrentDir + "\\SS");
                }
                catch (Exception)
                {
                    MessageBox.Show("スクリーンショットがありません。");
                    return;
                }
            }

            while (true)
            {
                if (File.Exists(CurrentDir + "\\SS\\IMG_" + i + ".png"))
                {
                    i++;
                }
                else
                {
                    i--;
                    imgPath = CurrentDir + "\\SS\\IMG_" + i + ".png";

                    break;
                }
            }

            textBox2.Text = imgPath;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int length;

            length = 140 - textBox1.TextLength;
            label1.Text = length.ToString();

            if (length >= 0)
            {
                label1.ForeColor = Color.Black;
                button1.Enabled = true;
            }
            else
            {
                label1.ForeColor = Color.Red;
                button1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.AutoUpgradeEnabled = true;
            openFileDialog1.InitialDirectory = CurrentDir + "\\SS";
            openFileDialog1.FileName = "";

            openFileDialog1.ShowDialog();

            if (File.Exists(openFileDialog1.FileName) == true)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                buttonsDisable();

                toolStripStatusLabel1.Text = "画像をアップロードしています...";

                try
                {
                    imgPath = textBox2.Text;

                    await TaskEx.Run(() => imgUri = uploadImage(imgPath));

                    textBox1.Text += " " + imgUri;
                }
                catch
                {
                    MessageBox.Show("画像のアップロードに失敗しました。");
                    buttonsEnable();

                    return;
                }

                textBox2.Text = "";

                toolStripStatusLabel1.Text = "画像のアップロードが完了しました";

                buttonsEnable();
            }
        } 

    }
}
