using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
