/*
 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace ASUS_Firmware_Downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        List<string[]> products = new List<string[]>();
        private void Form1_Load(object sender, EventArgs e)
        {
            loading.Visible = true;
            WebClient GetProductList = new WebClient();
            byte[] Data =GetProductList.DownloadData($@"https://www.asus.com/tw/OfficialSiteAPI.asmx/GetModelResults?WebsiteId=7&ProductLevel2Id=1&FiltersCategory=&Filters=&Sort=3&PageNumber=1&PageSize=20");
            string json_source = Encoding.UTF8.GetString(Data);
            ModelResults modelResults = JsonConvert.DeserializeObject<ModelResults>(json_source);
            foreach(ModelObj ma in modelResults.Result.Obj)
            {
                string productName = "";
                string imageurl="";
                string HashId = "";
                string producturl = "";
                HashId = ma.PDHashedId;
                productName = ma.PDMarketName;
                imageurl = ma.ImageUrl;
                producturl = ma.Url;
                ListViewItem lvi = new ListViewItem();
                lvi.Text = productName;
                listView1.Items.Add(lvi);
                products.Add(new string[] { productName, imageurl, HashId , producturl });
            }
            LoadNonShowProduct();
            loading.Visible = false;

        }
        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                loading.Visible = true;

                productImage.ImageLocation = $@"https://www.asus.com{products[listView1.SelectedItems[0].Index][1]}";
                productName.Text = products[listView1.SelectedItems[0].Index][0];
                WebClient webClient = new WebClient();
                string HashId = products[listView1.SelectedItems[0].Index][2];
                string ProductUrl = products[listView1.SelectedItems[0].Index][3];
                byte[] Data = webClient.DownloadData($@"https://www.asus.com/support/api/product.asmx/GetPDDrivers?cpu=&osid=32&website=tw&pdhashedid={HashId}&callback=supportpdpage");
                download1.Source = Encoding.UTF8.GetString(Data);
                download1.ProductUrl = ProductUrl;
                loading.Visible = false;
            }
        }
        private void LoadNonShowProduct()
        {
            WebClient webClient = new WebClient();
            string jsonSource = webClient.DownloadString($@"https://app.yuanstudio.cc/ApplicationData/ASUSFirmwareDownloader/nonshowProduct.json");
           


            notshowProduct[] nonShowProducts = JsonConvert.DeserializeObject<notshowProduct[]>(jsonSource);
            foreach(notshowProduct nsp in nonShowProducts)
            {
                string productName = "";
                string imageurl = "";
                string HashId = "";
                string producturl = "";
                HashId = nsp.HashId;
                productName = nsp.Name;
                imageurl = nsp.imageUrl;
                producturl = $@"http:{nsp.ProductUrl}";
                ListViewItem lvi = new ListViewItem();
                lvi.Text = productName;
                listView1.Items.Add(lvi);
                products.Add(new string[] { productName, imageurl, HashId , producturl });
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = $@"http://app.yuanstudio.cc";
            process.Start();
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(download1.DownloadListControl.Count > 0)
            {
                if (MessageBox.Show($"目前仍有{download1.DownloadListControl.Count}個下載正在進行中，您確定要關閉本程式嗎?", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) return;
                e.Cancel = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            
        }
    }
}
