using System;
using System.Windows.Forms;
using System.IO;

namespace Scrapper_Settings
{
    public partial class Scrape_Form : Form
    {
        string url = "";

        public Scrape_Form(string url)
        {
            InitializeComponent();
            this.url = url;
        }

        private void Scrape_Results_Load(object sender, EventArgs e)
        {
            labelURL.Text = url;
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText("scrape.txt", resultText.Text);
        }
    }
}
