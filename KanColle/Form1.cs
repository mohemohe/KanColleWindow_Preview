using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace KanColle
{
    public partial class Form1 : Form
    {
        #region 変数・定数

        public string CurrentDir = Application.StartupPath;
        public Uri gameUri = new Uri("http://www.dmm.com/netgame/social/-/gadgets/=/app_id=854854/");
        public Uri loginUri = new Uri("https://www.dmm.com/my/-/login/");
        public Uri logoutUri = new Uri("http://www.dmm.com/my/-/login/logout/");
        public Uri rootUri = new Uri("http://www.dmm.com/");
        private bool _allowUpdate;
        private bool _checkUpdate;
        private bool agree;
        private bool changeSize = false;
        private string CurrentTmp;
        private int CurrentVer;
        private globVal cv = new globVal();
        private string DownloadTmp;
        private Form form2 = new Form2();
        private int formAlgo;
        private int formSizeX;
        private int formSizeY;
        private bool formTransform;
        private bool login = true;
        private Size loginSize;
        private bool moveTimer;
        private int offsetX;
        private int offsetY;
        private Size playSize;
        private int sHeight;
        private bool showTimer;
        private int sWidth;
        private bool twitter_auth;
        private string UpdateTmp;
        private int UpdateVer;

        #endregion 変数・定数

        public Form1()
        {
            InitializeComponent();

            InitializeProgram();

            try
            {
                readSettings();
            }
            catch (Exception)
            {
            }

            checkAgree();

            if (_checkUpdate == true)
            {
                checkUpdate();
            }

            InitializeUI();
            applyValue();
        }

        private void applyUI()
        {
            try
            {
                webBrowser1.Document.Body.Style = "Zoom: " + 100 + "%;";
                webBrowser1.Document.Body.Style = "overflow:hidden";

                if (webBrowser1.Url == rootUri)
                {
                    this.ClientSize = loginSize;
                }

                if (webBrowser1.Url != gameUri)
                {
                    this.ClientSize = loginSize;
                    webBrowser1.Document.Window.ScrollTo(100 + offsetX, 125 + offsetX);
                }

                if (webBrowser1.Url == gameUri)
                {
                    this.ClientSize = playSize;
                    webBrowser1.Document.Window.ScrollTo(70 + offsetX, 52 + offsetY);
                }
            }
            catch (Exception)
            {
            }
            form2_Move();
        }

        private void applyUpdate()
        {
            string UpdateAppDir;
            string AppDirName;
            string AppName;

            DialogResult result = MessageBox.Show("艦これ☆うぃんどう のアップデートが見つかりました。\nバージョン " + DownloadTmp + "\n\n今すぐアップデートしますか？",
                                                    "アップデート",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Asterisk);

            if (result == DialogResult.No)
            {
                return;
            }

            MessageBox.Show("バックグラウンドで自動的にアップデートされます。");

            try
            {
                using (StreamReader sr = new StreamReader(CurrentDir + "\\tmp\\version.txt", Encoding.GetEncoding("UTF-8")))
                {
                    Microsoft.VisualBasic.Devices.Network network = new Microsoft.VisualBasic.Devices.Network();
                    network.DownloadFile(
                        "http://ghippos.net/softwareupdate/KanColleWindow_latest.zip",
                        CurrentDir + "\\tmp\\update\\KanColleWindow_latest.zip",
                        "", "",
                        false, 6000, true);
                }
            }
            catch (Exception)
            {
                //後片付け
                DirectoryInfo backup = new DirectoryInfo(CurrentDir + "\\tmp\\update");
                backup.Delete(true);

                MessageBox.Show("エラーが発生しました\nアップデートを中止します。");

                return;
            }

            //zip解凍
            Zip.UnZIP(CurrentDir + "\\tmp\\update\\KanColleWindow_latest.zip", CurrentDir + "\\tmp\\update");

            //新バージョンのフォルダのパスを作る
            UpdateAppDir = CurrentDir + "\\tmp\\update\\KanColleWindow_latest";

            //exeが格納されているフォルダの名前を作る
            AppDirName = CurrentDir.Substring(CurrentDir.Substring(0, CurrentDir.LastIndexOf("\\")).Length + 1);

            //exeが格納されているフォルダと同じ名前にする
            Directory.Move(UpdateAppDir, CurrentDir + "\\tmp\\update\\" + AppDirName);
            UpdateAppDir = CurrentDir + "\\tmp\\update\\" + AppDirName;

            //exe自身のファイル名を取得
            AppName = Application.ExecutablePath.Substring(CurrentDir.Length + 1);

            //上書きできるように調整
            //File.Move(AppName, "gHipposMC.old");
            string[] exeFiles = Directory.GetFiles(CurrentDir, "*.exe");
            string[] dllFiles = Directory.GetFiles(CurrentDir, "*.dll");

            for (int i = 0; i <= exeFiles.Length - 1; i++)
            {
                File.Move(exeFiles[i], exeFiles[i] + ".old");
            }

            for (int i = 0; i <= dllFiles.Length - 1; i++)
            {
                File.Move(dllFiles[i], dllFiles[i] + ".old");
            }

            //新バージョンのファイルをコピー
            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(UpdateAppDir, CurrentDir.Substring(0, CurrentDir.LastIndexOf("\\")) + "\\" + AppDirName, true);
            }
            catch (Exception)
            {
                //後片付け
                //File.Move("gHipposMC.old", AppName);
                for (int i = 0; i <= exeFiles.Length; i++)
                {
                    File.Move(exeFiles[i] + ".old", exeFiles[i]);
                }

                for (int i = 0; i <= dllFiles.Length; i++)
                {
                    File.Move(dllFiles[i] + ".old", dllFiles[i]);
                }

                DirectoryInfo backup = new DirectoryInfo(CurrentDir + "\\tmp\\update");
                backup.Delete(true);

                MessageBox.Show("エラーが発生しました\nアップデートを中止します。");

                return;
            }

            //新バージョンで起動し直す
            Process.Start("KanColleWindow.exe", "/update " + Process.GetCurrentProcess().Id);
            Environment.Exit(0);
        }

        private void applyValue()
        {
            loginSize = new Size(450 + formSizeX, 250 + formSizeY);
            playSize = new Size(800 + formSizeX, 500 + formSizeY);
        }

        private void checkAgree()
        {
            if (agree == false)
            {
                Form7 form7 = new Form7();
                form7.StartPosition = FormStartPosition.CenterParent;
                form7.ShowDialog(this);

                form7.Dispose();
            }
        }

        private void checkUpdate()
        {
            string tmp;

            //サーバー上のtxtをダウンロード
            try
            {
                Microsoft.VisualBasic.Devices.Network network = new Microsoft.VisualBasic.Devices.Network();
                network.DownloadFile(
                    "http://ghippos.net/softwareupdate/KanColleWindow.txt", CurrentDir + "\\tmp\\version.txt",
                    "", "",
                    false, 5000, true);
            }
            catch (Exception)
            {
                return;
            }

            //UTF-8で読み込む（まさか読み取り権限無いとかあり得ないよね）
            try
            {
                using (StreamReader sr = new StreamReader(CurrentDir + "\\tmp\\version.txt", Encoding.GetEncoding("UTF-8")))
                {
                    DownloadTmp = sr.ReadLine();
                }
            }
            catch (Exception)
            {
                return;
            }

            //X.X.X.Xを整数に直す
            CurrentTmp = globVal.CurrentVer;
            UpdateTmp = DownloadTmp;

            CurrentVer = Convert.ToInt32(CurrentTmp.Replace(".", null));
            UpdateVer = Convert.ToInt32(UpdateTmp.Replace(".", null));

            //UpdateVer以上なら抜ける
            if (CurrentVer >= UpdateVer)
            {
                return;
            }
            if (_allowUpdate == true)
            {
                applyUpdate();
                return;
            }
            else
            {
                using (StreamReader sr = new StreamReader(CurrentDir + "\\tmp\\version.txt", Encoding.GetEncoding("UTF-8")))
                {
                    tmp = sr.ReadToEnd();
                }

                DialogResult result = MessageBox.Show("艦これ☆うぃんどう のアップデートが見つかりました。\nバージョン " + tmp + "\n\nダウンロードしますか？",
                                                        "アップデート",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Asterisk);

                if (result == DialogResult.Yes)
                {
                    Process.Start("http://ghippos.net/download.php?url=http://ghippos.net/softwareupdate/KanColleWindow_latest.zip");
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
        }

        //終了できるようにする
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            form2.Close();

            saveSettings();

            form2.Dispose();

            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sHeight = Screen.GetWorkingArea(this).Height;
            sWidth = Screen.GetWorkingArea(this).Width;

            form2_Move();

            this.ClientSize = loginSize;
            webBrowser1.Url = gameUri;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                double zoomBase = (sHeight / (500.00 + formSizeY));
                string zoom = zoomBase.ToString();
                int zoomInt = Convert.ToInt32(zoomBase);

                webBrowser1.Document.Body.Style = "width:800px;Zoom: " + zoom + ";overflow:hidden;";
                webBrowser1.Document.Window.ScrollTo(0, Convert.ToInt32((52 + offsetY) * zoomBase) + menuStrip1.Height);
                toolStripMenuItem4.Enabled = false;
            }
            else
            {
                if (formTransform == true)
                {
                }
                else
                {
                    applyUI();
                }

                formTransform = false;
                toolStripMenuItem4.Enabled = true;
            }
        }

        private void InitializeProgram()
        {
            //自分自身のAssemblyを取得
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();

            //バージョンの取得
            System.Version ver = asm.GetName().Version;
            globVal.CurrentVer = ver.ToString();

            //後始末できないからしかたないね
            try
            {
                DirectoryInfo temp = new System.IO.DirectoryInfo(CurrentDir + "\\tmp\\update");
                temp.Delete(true);
            }
            catch (Exception)
            {
            }
            try
            {
                string[] oldFiles = Directory.GetFiles(CurrentDir + "\\", "*.old");

                for (int i = 0; i <= oldFiles.Length - 1; i++)
                {
                    FileInfo temp = new System.IO.FileInfo(oldFiles[i]);
                    temp.Delete();
                }
            }
            catch (Exception)
            {
            }
        }

        private void InitializeUI()
        {
            //タイマー用意
            form2.Owner = this;
            form2.Show();

            if (showTimer == true)
            {
                form2.Opacity = 1;
            }
            else
            {
                form2.Visible = false;
                form2.Opacity = 1;
            }
        }

        //電の本気を見るのです☆
        private void notyet()
        {
            MessageBox.Show("まだなのです");
        }
        private void readSettings()
        {
            cv.readSettings();

            agree = globVal._agree;
            _checkUpdate = globVal._checkUpdate;
            _allowUpdate = globVal._allowUpdate;

            formAlgo = globVal._formAlgo;
            showTimer = globVal._showTimer;
            moveTimer = globVal._moveTimer;
            formSizeX = globVal._formSizeX;
            formSizeY = globVal._formSizeY;
            offsetX = globVal._offsetX;
            offsetY = globVal._offsetY;

            twitter_auth = globVal._twitter_auth;
        }

        private void reloadSettings()
        {
            agree = globVal._agree;
            _checkUpdate = globVal._checkUpdate;
            _allowUpdate = globVal._allowUpdate;

            formAlgo = globVal._formAlgo;
            showTimer = globVal._showTimer;
            moveTimer = globVal._moveTimer;
            formSizeX = globVal._formSizeX;
            formSizeY = globVal._formSizeY;
            offsetX = globVal._offsetX;
            offsetY = globVal._offsetY;

            twitter_auth = globVal._twitter_auth;
        }

        private void saveSettings()
        {
            bool success = cv.writeSettings();

            if (success == false)
            {
                MessageBox.Show("フォルダに書き込み権限がありません。\n書き込み可能なフォルダで実行してください。\n\n設定は全て破棄されます。");

                Environment.Exit(0);
            }
        }

        //読み込み後のURIの振り分け、フォームのサイズ変更
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Document.Body.Style = "Zoom: " + 100 + "%;overflow:hidden;";
            toolStripMenuItem4.Enabled = false;

            if (webBrowser1.Url == rootUri)
            {
                this.ClientSize = loginSize;
                form2_Move();

                if (login == true)
                {
                    webBrowser1.Url = gameUri;
                    return;
                }
                else
                {
                    login = true;
                    webBrowser1.Url = loginUri;
                }
            }

            if (webBrowser1.Url != gameUri)
            {
                this.MaximizeBox = false;
                this.ClientSize = loginSize;
                form2_Move();

                webBrowser1.Document.Window.ScrollTo(100 + offsetX, 125 + offsetX);
            }

            if (webBrowser1.Url == gameUri)
            {
                this.MaximizeBox = true;
                this.ClientSize = playSize;
                form2_Move();

                webBrowser1.Document.Window.ScrollTo(70 + offsetX, 52 + offsetY);

                toolStripMenuItem4.Enabled = true;
            }

            label1.SendToBack();
        }
        #region メニューバー

        private void dMMポイント購入画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri("http://www.dmm.com/netgame/-/basket/=/");

            Form form6 = new Form6(uri);
            form6.Show();
        }

        //スクリーンショット取得
        private void sSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle rc = this.RectangleToScreen(webBrowser1.Bounds);
            Rectangle rcm = this.RectangleToScreen(menuStrip1.Bounds);
            Bitmap bmp = new Bitmap(rc.Width, rc.Height - rcm.Height, PixelFormat.Format32bppArgb);
            int i = 1;

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(rc.X, rc.Y + rcm.Height, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);
            }

            if (!(Directory.Exists(CurrentDir + "\\SS")))
            {
                try
                {
                    Directory.CreateDirectory(CurrentDir + "\\SS");
                }
                catch (Exception)
                {
                    return;
                }
            }

            while (true)
            {
                if (!(File.Exists(CurrentDir + "\\SS\\IMG_" + i + ".png")))
                {
                    break;
                }
                else
                {
                    i++;
                }
            }

            try
            {
                bmp.Save(CurrentDir + "\\SS\\IMG_" + i + ".png", ImageFormat.Png);

                System.Media.SystemSounds.Asterisk.Play();
            }
            catch (Exception)
            {
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            formTransform = true;

            if (changeSize == false)
            {
                this.ClientSize = new Size(800 + formSizeX, 720 + formSizeY);
                webBrowser1.Document.Window.ScrollTo(70, 52);

                changeSize = true;
            }
            else
            {
                this.ClientSize = new Size(800 + formSizeX, 500 + formSizeY);
                webBrowser1.Document.Window.ScrollTo(70, 52);

                changeSize = false;
            }
        }

        //twitter連携
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (twitter_auth == true)
            {
                Form8 form8 = new Form8();
                form8.StartPosition = FormStartPosition.CenterParent;
                form8.ShowDialog(this);

                form8.Dispose();
            }
            else
            {
                MessageBox.Show("twitterのアカウントが登録されていません。\n設定メニューから登録してください。");
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            label1.BringToFront();
        }

        private void タイマーToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2.Visible = true;

            form2_Move();
        }

        private void ヘルプToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://ghippos.net/app/kancollewnd/");
        }

        private void ログイン画面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login = false;

            label1.BringToFront();
            webBrowser1.Url = logoutUri;
        }

        private void 運営鎮守府からのお知らせToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri("http://www.dmm.com/netgame/social/community/-/topic/=/cid=100/tid=922/");

            Form form6 = new Form6(uri);
            form6.Show();
        }

        private void 艦これうぃんどうについてToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.StartPosition = FormStartPosition.CenterParent;
            form4.ShowDialog(this);

            form4.Dispose();
        }

        private void 艦これタイマーを起動ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process kct = new Process();
                kct.StartInfo.FileName = CurrentDir + "\\kct\\kct.exe";
                kct.StartInfo.UseShellExecute = false;
                kct.StartInfo.WorkingDirectory = CurrentDir + "\\kct";

                kct.Start();
                kct.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("起動できませんでした。\nkct フォルダに kct.exe を置いてください。");
            }
        }

        private void 艦これの再起動ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveSettings();

            Application.Restart();
            Environment.Exit(0);
        }

        private void 再読み込みToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = webBrowser1.Url;
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void 設定CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.StartPosition = FormStartPosition.CenterParent;
            form5.ShowDialog(this);

            form5.Dispose();

            reloadSettings();
            applyValue();
            applyUI();

            ((Form2)Application.OpenForms["Form2"]).applyUI();
        }
        #endregion メニューバー

        #region 簡易タイマーを同時に移動

        private void Form1_Move(object sender, EventArgs e)
        {
            form2_Move();
        }

        private void form2_Move()
        {
            if (form2 != null && globVal._moveTimer == true)
            {
                if (formAlgo == 0)
                {
                    form2.Left = this.Left + this.Width + SystemInformation.FrameBorderSize.Width;
                }

                if (formAlgo == 1)
                {
                    form2.Left = this.Left + this.ClientSize.Width + (3 * SystemInformation.FixedFrameBorderSize.Width);
                }

                if (formAlgo == 2)
                {
                    form2.Left = this.Left + this.ClientSize.Width + 16;
                }

                form2.Top = this.Top;
            }
        }

        #endregion 簡易タイマーを同時に移動
    }
}