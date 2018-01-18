using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yuan.Text.Format.JSON;
using System.Net;
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
            string json_source = System.Text.Encoding.UTF8.GetString(Data);
            JSONItem ji = new JSONItem(json_source);
            switch (ji.ItemType)
            {
                case (JSONItemType.Object):
                
                    foreach(JSONSubObject jsb in ((JSONObject)ji.Item).Items)
                    {
                        if(jsb.Name== "Result")
                        {
                            JSONItem jii = jsb.Value;
                            JSONObject jo = (JSONObject)jii.Item;
                            foreach(JSONSubObject jsoo in jo.Items)
                            {
                                if (jsoo.Name == "Obj" && jsoo.Value.ItemType== JSONItemType.Array)
                                {
                                    JSONArray jaa = (JSONArray)jsoo.Value.Item;
                                    foreach(JSONItem jiji in jaa)
                                    {
                                        string productName = "";
                                        string imageurl = "";
                                        string HashId = "";
                                        JSONObject jojo = (JSONObject)jiji.Item;
                                        HashId = (string)jojo["PDHashedId"].Value.Item;
                                        productName = (string)jojo["PDMarketName"].Value.Item;
                                        imageurl = (string)jojo["ImageUrl"].Value.Item;
                                        ListViewItem lvi = new ListViewItem();
                                        lvi.Text = productName;
                                        listView1.Items.Add(lvi);
                                        products.Add(new string[] { productName , imageurl, HashId });
                                    }
                                }
                            }
                        }
                    }
                    break;
                case (JSONItemType.Array):
                    break;
            }
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
                byte[] Data = webClient.DownloadData($@"https://www.asus.com/support/api/product.asmx/GetPDDrivers?cpu=&osid=32&website=tw&pdhashedid={HashId}&callback=supportpdpage");
                download1.Source = Encoding.UTF8.GetString(Data);
                loading.Visible = false;
            }
        }
    }
}
