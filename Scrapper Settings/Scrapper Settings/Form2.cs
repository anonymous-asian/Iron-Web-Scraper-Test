using System;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Linq;
using System.Collections.Generic;

namespace Scrapper_Settings
{
    public partial class Scrape_Form : Form
    {
        public Scrape_Form(string url)
        {
            InitializeComponent();
            Global.url = url;
            resultText.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Right |
                AnchorStyles.Left;
        }

        private async void Scrape_Results_Load(object sender, EventArgs e)
        {
            labelURL.Text = Global.url;

            HtmlWeb web = new HtmlWeb();
            //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //List of car objects that store car details
            List<Car> cars = new List<Car>();
            //Start web crawler asynchronously with return type void
            int pageNumber = 1;
            int[] ids = new[] { 1, 2, 3, 4, 5 };
            var doc = await Task.Factory.StartNew(() => web.Load(string.Format(Global.url + "{0}", pageNumber.ToString())));

            int carCount = 0;

            //Selects div that holds each car entry in the list
            foreach(var carNodes in doc.DocumentNode.SelectNodes("//*[@id]/div/div/div[2]"))
            {
                carCount++;
                //Create car object that stores:
                //link
                //color
                //transmission
                //mileage (int)
                //driveTrain
                //vin
                Car car = new Car();

                //Gets the first node with a link -> carNodes.SelectSingleNode(".//a")
                //Gets the href attribute from link node -> Attributes["href"].Value
                //In our case the first link node is the link to the car's detail page
                string linkEnd = carNodes.SelectSingleNode(".//a").Attributes["href"].Value;

                //Format the url
                //Link href only contains the last part of the link
                //Append it to http://car-website.com
                string url = Global.url.Substring(0, Global.url.LastIndexOf(".com")+4) + linkEnd;
                resultText.AppendText(Environment.NewLine + linkEnd + Environment.NewLine + url + Environment.NewLine);

                //Count the number of span nodes
                int count = 0;

                //Traverse the carNode for the car details
                foreach (var innerNode in carNodes.SelectNodes(".//*[contains('span', '')]"))
                {
                    count++;
                    resultText.AppendText(Environment.NewLine);
                    resultText.AppendText(innerNode.InnerHtml);
                }
                resultText.AppendText(count.ToString());
            }

            resultText.AppendText(Environment.NewLine + Environment.NewLine + "Car count: " + carCount.ToString());
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

    public class Global
    {
        public static string url = "";
    }

    public class Car
    {
        public string link { get; set; }
        public string color { get; set; }
        public string transmission { get; set; }
        public int mileage { get; set; }
        public string driveTrain { get; set; }
        public string vin { get; set; }
    }
}