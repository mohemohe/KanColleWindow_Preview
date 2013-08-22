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
    public partial class Form6 : Form
    {
        Uri uri;

        public Form6(Uri _uri)
        {
            InitializeComponent();

            uri = _uri;
        }

        void UIsizeCalc()
        {
            webBrowser1.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - toolStrip1.Height);
            toolStripComboBox1.Size = new Size(toolStrip1.Width - (4 * toolStripButton1.Size.Width + 4 * toolStripSeparator1.Size.Width), toolStripComboBox1.Height);
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            UIsizeCalc();

            webBrowser1.Url = uri;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            toolStripComboBox1.Text = webBrowser1.Url.ToString();

            if (webBrowser1.DocumentTitle != null)
            {
                this.Text = webBrowser1.DocumentTitle;
            }
            else
            {
                this.Text = webBrowser1.Url.ToString();
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.Text = "...";
        }

        private void Form6_Resize(object sender, EventArgs e)
        {
            UIsizeCalc();
        }

        private void Form6_ResizeEnd(object sender, EventArgs e)
        {
            webBrowser1.ScrollBarsEnabled = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Uri navUri = new Uri(toolStripComboBox1.Text);
                webBrowser1.Url = navUri;
            }
            catch (Exception)
            {
                
            }
        }

        private void toolStripComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Uri navUri = new Uri(toolStripComboBox1.Text);
                    webBrowser1.Url = navUri;
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}
