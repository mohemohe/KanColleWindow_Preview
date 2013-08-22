namespace KanColle
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.艦これの再起動ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.再読み込みToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ログイン画面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dMMポイント購入画面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ツールToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.タイマーToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.艦これタイマーを起動ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.設定CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.艦これうぃんどうについてToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.運営鎮守府からのお知らせToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(436, 241);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10);
            this.label1.Size = new System.Drawing.Size(436, 241);
            this.label1.TabIndex = 1;
            this.label1.Text = "読み込み中...";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.表示ToolStripMenuItem,
            this.ツールToolStripMenuItem,
            this.ヘルプHToolStripMenuItem,
            this.sSToolStripMenuItem,
            this.toolStripMenuItem5,
            this.toolStripMenuItem4});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(436, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.艦これの再起動ToolStripMenuItem,
            this.終了ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 艦これの再起動ToolStripMenuItem
            // 
            this.艦これの再起動ToolStripMenuItem.Name = "艦これの再起動ToolStripMenuItem";
            this.艦これの再起動ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.艦これの再起動ToolStripMenuItem.Text = "艦これの再起動(&S)";
            this.艦これの再起動ToolStripMenuItem.Click += new System.EventHandler(this.艦これの再起動ToolStripMenuItem_Click);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.終了ToolStripMenuItem.Text = "終了(&X)";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // 表示ToolStripMenuItem
            // 
            this.表示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.再読み込みToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ログイン画面ToolStripMenuItem,
            this.dMMポイント購入画面ToolStripMenuItem});
            this.表示ToolStripMenuItem.Name = "表示ToolStripMenuItem";
            this.表示ToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.表示ToolStripMenuItem.Text = "表示(&V)";
            // 
            // 再読み込みToolStripMenuItem
            // 
            this.再読み込みToolStripMenuItem.Name = "再読み込みToolStripMenuItem";
            this.再読み込みToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.再読み込みToolStripMenuItem.Text = "再読み込み(&R)";
            this.再読み込みToolStripMenuItem.Click += new System.EventHandler(this.再読み込みToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 6);
            // 
            // ログイン画面ToolStripMenuItem
            // 
            this.ログイン画面ToolStripMenuItem.Name = "ログイン画面ToolStripMenuItem";
            this.ログイン画面ToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.ログイン画面ToolStripMenuItem.Text = "ログイン画面";
            this.ログイン画面ToolStripMenuItem.Click += new System.EventHandler(this.ログイン画面ToolStripMenuItem_Click);
            // 
            // dMMポイント購入画面ToolStripMenuItem
            // 
            this.dMMポイント購入画面ToolStripMenuItem.Name = "dMMポイント購入画面ToolStripMenuItem";
            this.dMMポイント購入画面ToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.dMMポイント購入画面ToolStripMenuItem.Text = "DMMポイント購入画面";
            this.dMMポイント購入画面ToolStripMenuItem.Click += new System.EventHandler(this.dMMポイント購入画面ToolStripMenuItem_Click);
            // 
            // ツールToolStripMenuItem
            // 
            this.ツールToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.タイマーToolStripMenuItem,
            this.艦これタイマーを起動ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.設定CToolStripMenuItem});
            this.ツールToolStripMenuItem.Name = "ツールToolStripMenuItem";
            this.ツールToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.ツールToolStripMenuItem.Text = "ツール(&T)";
            // 
            // タイマーToolStripMenuItem
            // 
            this.タイマーToolStripMenuItem.Name = "タイマーToolStripMenuItem";
            this.タイマーToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.タイマーToolStripMenuItem.Text = "簡易タイマー";
            this.タイマーToolStripMenuItem.Click += new System.EventHandler(this.タイマーToolStripMenuItem_Click);
            // 
            // 艦これタイマーを起動ToolStripMenuItem
            // 
            this.艦これタイマーを起動ToolStripMenuItem.Name = "艦これタイマーを起動ToolStripMenuItem";
            this.艦これタイマーを起動ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.艦これタイマーを起動ToolStripMenuItem.Text = "艦これタイマーを起動";
            this.艦これタイマーを起動ToolStripMenuItem.Click += new System.EventHandler(this.艦これタイマーを起動ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(171, 6);
            // 
            // 設定CToolStripMenuItem
            // 
            this.設定CToolStripMenuItem.Name = "設定CToolStripMenuItem";
            this.設定CToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.設定CToolStripMenuItem.Text = "設定(&C)";
            this.設定CToolStripMenuItem.Click += new System.EventHandler(this.設定CToolStripMenuItem_Click);
            // 
            // ヘルプHToolStripMenuItem
            // 
            this.ヘルプHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ヘルプToolStripMenuItem,
            this.艦これうぃんどうについてToolStripMenuItem,
            this.toolStripMenuItem2,
            this.運営鎮守府からのお知らせToolStripMenuItem});
            this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            this.ヘルプHToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // ヘルプToolStripMenuItem
            // 
            this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
            this.ヘルプToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ヘルプToolStripMenuItem.Text = "ヘルプ サイト";
            this.ヘルプToolStripMenuItem.Click += new System.EventHandler(this.ヘルプToolStripMenuItem_Click);
            // 
            // 艦これうぃんどうについてToolStripMenuItem
            // 
            this.艦これうぃんどうについてToolStripMenuItem.Name = "艦これうぃんどうについてToolStripMenuItem";
            this.艦これうぃんどうについてToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.艦これうぃんどうについてToolStripMenuItem.Text = "艦これ☆うぃんどう について";
            this.艦これうぃんどうについてToolStripMenuItem.Click += new System.EventHandler(this.艦これうぃんどうについてToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(199, 6);
            // 
            // 運営鎮守府からのお知らせToolStripMenuItem
            // 
            this.運営鎮守府からのお知らせToolStripMenuItem.Name = "運営鎮守府からのお知らせToolStripMenuItem";
            this.運営鎮守府からのお知らせToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.運営鎮守府からのお知らせToolStripMenuItem.Text = "運営鎮守府からのお知らせ";
            this.運営鎮守府からのお知らせToolStripMenuItem.Click += new System.EventHandler(this.運営鎮守府からのお知らせToolStripMenuItem_Click);
            // 
            // sSToolStripMenuItem
            // 
            this.sSToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sSToolStripMenuItem.Name = "sSToolStripMenuItem";
            this.sSToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.sSToolStripMenuItem.Text = "[SS]";
            this.sSToolStripMenuItem.Click += new System.EventHandler(this.sSToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItem5.Text = "[tweet]";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(49, 20);
            this.toolStripMenuItem4.Text = "[⇱⇲]";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(436, 241);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "艦隊これくしょん～艦これ～";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 艦これの再起動ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ツールToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 再読み込みToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem タイマーToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ログイン画面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 艦これタイマーを起動ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 艦これうぃんどうについてToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 運営鎮守府からのお知らせToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 設定CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem dMMポイント購入画面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
    }
}

