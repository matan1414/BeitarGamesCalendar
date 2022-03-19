using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;


namespace BeitarGamesCalendar
{
    public partial class Form1 : Form
    {
        string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        DataTable table = new DataTable();
        public StreamWriter sw;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_URL.Text = "https://www.beitarfc.co.il/%d7%9e%d7%a9%d7%97%d7%a7%d7%99%d7%9d/";
            CreateAppartmentsDataTableColumns();
        }

        private void CreateAppartmentsDataTableColumns()
        {
            //create columns of DataTable
            table.Columns.Add("Query ID", typeof(string));
            table.Columns.Add("Fixture", typeof(string));
            table.Columns.Add("Home", typeof(string));
            table.Columns.Add("Out", typeof(string));
            table.Columns.Add("Stadium", typeof(string));
            table.Columns.Add("Date", typeof(string));
            table.Columns.Add("Hour", typeof(string));
        }

        private void CreateCarsDataTableColumns()
        {
            //create columns of DataTable
            table.Columns.Add("Query ID", typeof(string));
            table.Columns.Add("Make", typeof(string));
            table.Columns.Add("Model", typeof(string));
            table.Columns.Add("Year", typeof(string));
            table.Columns.Add("Yad", typeof(string));
            table.Columns.Add("SMK", typeof(string));
            //table.Columns.Add("Kilometerage", typeof(string));
            table.Columns.Add("Price", typeof(string));
        }

        private void SaveTableToCSV(DataTable _data_table)
        {
            try
            {
                for (int i = 0; i < _data_table.Columns.Count; i++)
                {
                    sw.Write(_data_table.Columns[i]);
                    if (i < _data_table.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }

                sw.Write(sw.NewLine);
                foreach (DataRow dr in _data_table.Rows)
                {
                    for (int i = 0; i < _data_table.Columns.Count; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            string value = dr[i].ToString();
                            if (value.Contains(','))
                            {
                                value = String.Format("\"{0}\"", value);
                                sw.Write(value);
                            }
                            else
                            {
                                sw.Write(dr[i].ToString());
                            }
                        }
                        if (i < _data_table.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
                table.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button_ExportToCSV_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(desktop_path + "\\Yad2");

            string output_filepath = desktop_path + "\\Yad2\\" + DateTime.Now.ToString("dd.MM.yyyy - HH;mm;ss") + ".csv";

            sw = new StreamWriter(output_filepath, true, Encoding.UTF8);

            //sw = File.CreateText(output_filepath);       //create stream writer
            SaveTableToCSV(table);

        }

        private void button_StartFetchAppartments_Click(object sender, EventArgs e)
        {
            string url = textBox_URL.Text;

            CreateAppartmentsDataTableColumns();


        }

        private void button_StartFecthCarsYad2_Click(object sender, EventArgs e)
        {
            /*           string url = textBox_URL.Text;
                       var web = new HtmlWeb();
                       HtmlAgilityPack.HtmlDocument doc = web.Load(url);


                       CreateCarsDataTableColumns();

                       for (int i = 0; i < 40; i++)
                       {
                       }

                       MessageBox.Show("Cars Yad2 Fetching finished!");
           */

        }

        private void button_StartFetch_Click(object sender, EventArgs e)
        {
            string url = textBox_URL.Text;

            //loop on num of pages
            for (int page = 0; page < Int32.Parse(textBox_Pages.Text); page++)
            {
                var web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(url);

                //loop on number of queries
                for (int i = 1; i < 7; i++)
                {
                    string query_id =  i.ToString();
                    string item_url = "https://www.yad2.co.il/item/" + query_id;
                    var item_web = new HtmlWeb();
                    Thread.Sleep(1000);
                    HtmlAgilityPack.HtmlDocument item_doc = item_web.Load(item_url);

                    //fetching for main page:
                    //string _street_addr = doc.DocumentNode.SelectNodes("//*[@id=\"feed_item_" + i + "_title\"]/span[1]")[0].InnerText;
                    //*[@id="page_content"]/div/div/div[2]/div[1]/div/div[3]/div[1]
                    string fixture = doc.DocumentNode.SelectNodes("//*[@id=\"page_content\"]/div/div/div[2]/div[" + i + "]/div/div[3]/div[1]")[0].InnerText;
                    string home = doc.DocumentNode.SelectNodes("//*[@id=\"page_content\"]/div/div/div[2]/div[" + i + "]/div/div[2]/div[1]")[0].InnerText;
                    //*[@id="page_content"]/div/div/div[2]/div[1]/div/div[2]/div[1]
                    //*[@id="page_content"]/div/div/div[2]/div[2]/div/div[2]/div[1]
                    string _out = doc.DocumentNode.SelectNodes("//*[@id=\"page_content\"]/div/div/div[2]/div[" + i + "]/div/div[2]/div[2]")[0].InnerText;
                    string stadium = doc.DocumentNode.SelectNodes("//*[@id=\"page_content\"]/div/div/div[2]/div[" + i + "]/div/div[3]/div[2]")[0].InnerText;
                    string date = doc.DocumentNode.SelectNodes("//*[@id=\"page_content\"]/div/div/div[2]/div[" + i + "]/div/div[3]/div[3]")[0].InnerText;
                    //string _price_per_month = doc.DocumentNode.SelectNodes("//*[@id=\"feed_item_" + i + "_price\"]")[0].InnerText;
                    //string hour = Regex.Replace(_price_per_month, @"\s+", " ");

                    table.Rows.Add(query_id, fixture, home, _out, stadium, date);

                }
            }

            MessageBox.Show("Fetching finished!");

        }
    }
}
