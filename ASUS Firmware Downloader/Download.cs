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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Diagnostics;
namespace ASUS_Firmware_Downloader
{
    public partial class Download : UserControl
    {
        public Download()
        {
            InitializeComponent();
            DownloadListControl = new DownloadList();
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
        public string ProductUrl { get; set; }
        private void process()
        {
            listBox1.Items.Clear();
            Firmwares.Clear();
            if (JSON_source == "") return;
            string temp = JSON_source.Replace("supportpdpage(", "");
            string JSONSource = temp.Remove(temp.Length - 1);
            DriverResults driverResults = JsonConvert.DeserializeObject<DriverResults>(JSONSource);
            foreach(DriverObj obj in driverResults.Result.Obj)
            {
                if (obj.Name == "韌體")
                {
                    DriverFile[] driverFiles = obj.Files;
                    foreach(DriverFile df in driverFiles)
                    {
                        string Version = df.Version;
                        string Title = df.Title;
                        string Description = df.Description;
                        string FileSize = df.FileSize;
                        string ReleaseDate = df.ReleaseDate;
                        DriverDownloadUrl DownloadUrl = df.DownloadUrl;
                        string globaluri = DownloadUrl.Global;
                        Firmwares.Add(new string[] { Version, Title, Description, FileSize, ReleaseDate, globaluri });
                        listBox1.Items.Add(Version);
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
                filesize.Text = $@"檔案大小:{Firmwares[index][3].Replace(" GBytes"," GiB")}";
                size = Firmwares[index][3];
                date.Text = $@"更新日期:{Firmwares[index][4]}";
                temp_url = Firmwares[index][5];
            }
        }
        public DownloadList DownloadListControl { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            if (temp_url == "") return;
            if(MessageBox.Show($"您確定要下載此韌體嗎?這將會占用您電腦{size.Replace("GBytes","GiB")}的空間。", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "請選擇您要存放韌體的位置。";
                sfd.Filter = "zip文件|*.zip";
                string[] StringArray = temp_url.Split(("/").ToCharArray());
                sfd.FileName = StringArray[StringArray.Count() - 1];
                if (sfd.ShowDialog()== DialogResult.OK)
                {
                    if (DownloadListControl.Count >= 2)
                    {
                        MessageBox.Show("基於WebClient的限制，一個ip最多僅能同時下載兩個韌體。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DownloadListControl.AddDownload(firmware, size, temp_url, sfd.FileName);
                    DownloadListControl.Show();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DownloadListControl.Show();
        }

        private void Download_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process process = new Process() { };
            process.StartInfo.FileName = ProductUrl;
            process.Start();
        }
    }
}
