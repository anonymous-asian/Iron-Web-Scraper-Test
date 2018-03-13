using System;
using System.Windows.Forms;

namespace Scrapper_Settings
{
    public partial class URL_Form : Form
    {
        //Website URL
        public string url = "";

        public URL_Form()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            url = urlTextBox.Text;
            Scrape_Form resultForm = new Scrape_Form(url);
            resultForm.StartPosition = FormStartPosition.CenterParent;
            resultForm.ShowDialog();
        }
    }
}
