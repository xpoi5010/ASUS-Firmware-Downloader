using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yuan.Text.Format.JSON;

namespace ASUS_Firmware_Downloader
{
    public partial class Download : UserControl
    {
        public Download()
        {
            InitializeComponent();
        }
        private string JSON_source = "";
        private List<string[]> Firmwares = new List<string[]>();
        private List<object[]> cache = new List<object[]>();
        public string Source
        {
            get
            {
                return JSON_source;
            }
            set
            {
                JSON_source = value;
                process();
            }
        }
        private void process()
        {
            listBox1.Items.Clear();
            Firmwares.Clear();
            if (JSON_source == "") return;
            
            
                string temp = JSON_source.Replace("supportpdpage(", "");
                JSONItem ji = new JSONItem(temp.Remove(temp.Length - 1));
                if (ji.ItemType == JSONItemType.Object)
                {
                    JSONObject jo = (JSONObject)ji.Item;
                    JSONItem result = jo["Result"].Value;
                    if (result.ItemType == JSONItemType.Object)
                    {
                        JSONObject joo = (JSONObject)result.Item;
                        JSONItem Obj = joo["Obj"].Value;
                        if (Obj.ItemType == JSONItemType.Array)
                        {
                            JSONArray ja = (JSONArray)Obj.Item;
                            foreach (JSONItem sub in ja)
                            {
                                if (sub.ItemType == JSONItemType.Object)
                                {
                                    JSONObject objsubobj = (JSONObject)sub.Item;
                                    string name1 = (string)objsubobj["Name"].Value.Item;
                                    if (name1 == "韌體")
                                    {
                                        JSONArray Files = (JSONArray)objsubobj["Files"].Value.Item;

                                        foreach (JSONItem file in Files)
                                        {
                                            if (file.ItemType == JSONItemType.Object)
                                            {
                                                JSONObject fileobj = (JSONObject)file.Item;
                                                string Version = (string)fileobj["Version"].Value.Item;
                                                string Title = (string)fileobj["Title"].Value.Item;
                                                string Description = (string)fileobj["Description"].Value.Item;
                                                string FileSize = (string)fileobj["FileSize"].Value.Item;
                                                string ReleaseDate = (string)fileobj["ReleaseDate"].Value.Item;
                                                JSONObject DownloadUrl = (JSONObject)fileobj["DownloadUrl"].Value.Item;
                                                string globaluri = (string)DownloadUrl["Global"].Value.Item;
                                                Firmwares.Add(new string[] { Version, Title, Description, FileSize, ReleaseDate, globaluri });
                                                listBox1.Items.Add(Version);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                
               
            }
        }
        string temp_url = "";
        string firmware = "";
        string size = "";
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                int index = listBox1.SelectedIndex;
                version.Text = $@"韌體版本:{Firmwares[index][0]}";
                firmware = Firmwares[index][0];
                //title.Text = $@"{Firmwares[index][1]}";
                description.Text = $@"{Firmwares[index][2].Replace("<br/>","\r\n")}";
                filesize.Text = $@"檔案大小:{Firmwares[index][3]}";
                size = Firmwares[index][3];
                date.Text = $@"更新日期:{Firmwares[index][4]}";
                temp_url = Firmwares[index][5];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"您確定要下載此韌體嗎?這將會占用您電腦{size}的空間。", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "請選擇您要存放韌體的位置。";
                sfd.Filter = "zip文件|*.zip";
                string[] StringArray = temp_url.Split(("/").ToCharArray());
                sfd.FileName = StringArray[StringArray.Count() - 1];
                if (sfd.ShowDialog()== DialogResult.OK)
                {
                    Downloader downloader = new Downloader(firmware, size, temp_url, sfd.FileName);
                    downloader.StartDownload();
                    if(downloader.ShowDialog()== DialogResult.OK)
                    {
                        MessageBox.Show("下載完成。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
