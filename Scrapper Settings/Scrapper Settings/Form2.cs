using System;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;

namespace Scrapper_Settings
{
    public partial class Scrape_Form : Form
    {
        DataTable table;
        HtmlWeb web = new HtmlWeb();
        string url = "";
        public Scrape_Form(string url)
        {
            InitializeComponent();
            this.url = url;
            
            resultText.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Right |
                AnchorStyles.Left;
        }

        private void InitTable()
        {
            table = new DataTable("CarDataTable");
            table.Columns.Add("Page", typeof(string));
            table.Columns.Add("Link", typeof(string));
            dataTable.DataSource = table;
        }

        private async void Scrape_Results_Load(object sender, EventArgs e)
        {
            //Set url label
            labelURL.Text = url;
            
            //Create data table
            InitTable();
            
            //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //List of car objects that store car details
            List<Car> cars = new List<Car>();

            int carCount = 0;

            //Stopwatch of total elapsed time
            Stopwatch totalTime = new Stopwatch();
            totalTime.Start();
            
            //Asynchronously call every page
            Parallel.For(1, 50, i =>
            {
                //Load page i of the dealership inventory page
                var doc = web.Load(string.Format(url + "{0}", i.ToString()));
                
                //Keep track of the elapsed process time of the Task
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                //Selects div that holds each car entry in the list
                foreach (var carNodes in doc.DocumentNode.SelectNodes("//*[@id]/div/div/div[2]"))
                {
                    //Check to make sure node exist
                    //If it doesn't it means the page doesn't have any cars
                    if (carNodes.SelectSingleNode(".//a") != null)
                    {
                        //Create car object that stores:
                        //link
                        //color
                        //transmission
                        //mileage (int)
                        //driveTrain
                        //vin
                        Car car = new Car();

                        carCount++;

                        //Gets the first node with a link -> carNodes.SelectSingleNode(".//a")
                        //Gets the href attribute from link node -> Attributes["href"].Value
                        //In our case the first link node is the link to the car's detail page
                        string linkEnd = carNodes.SelectSingleNode(".//a").GetAttributeValue("href", "");
                        string newUrl = "";
                        //Format the url
                        if(linkEnd.Contains(".com"))
                        {
                            //Does nothing because string url is already formatted
                            newUrl = linkEnd;
                        } else
                        {
                            //Link href only contains the last part of the link
                            //Append it to http://car-website.com
                            newUrl = url.Substring(0, url.LastIndexOf(".com") + 4) + linkEnd;
                        }
                        //resultText.AppendText(Environment.NewLine + linkEnd + Environment.NewLine + url + Environment.NewLine);
                        Console.WriteLine(Environment.NewLine + Environment.NewLine + "Page " + i + " result: " + Environment.NewLine + newUrl);

                        table.Rows.Add("Page " + i.ToString(), newUrl);

                        //Count the number of span nodes
                        int count = 0;

                        //Traverse the carNode for the car details
                        foreach (var innerNode in carNodes.SelectNodes(".//*[contains('span', '')]"))
                        {
                            count++;
                            //resultText.AppendText(Environment.NewLine);
                            //resultText.AppendText(innerNode.InnerHtml);
                        }
                        //resultText.AppendText(count.ToString());
                    }
                    //resultText.AppendText(Environment.NewLine + Environment.NewLine + "Car count: " + carCount.ToString());
                    //resultText.AppendText(Environment.NewLine + "Page #" + i + Environment.NewLine);

                    stopwatch.Stop();
                    Console.WriteLine("Page " + i + " completed in: " + stopwatch.Elapsed);
                    Console.WriteLine(url + "{0}", i.ToString());
                    Console.WriteLine(Environment.NewLine + "||---------------------------------------------------------------------------------------------------------------------------------------||" + Environment.NewLine);
                }
            });
            totalTime.Stop();
            resultText.Text = "Total web scraper time: " + totalTime.Elapsed;
            resultText.AppendText(Environment.NewLine + "Total cars: " + carCount.ToString());
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