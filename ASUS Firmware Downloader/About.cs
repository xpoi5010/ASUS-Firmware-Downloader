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

namespace ASUS_Firmware_Downloader
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            string JSONSource = webClient.DownloadString("https://app.yuanstudio.cc/ApplicationData/Updata.json");
            UpdataInfo[] updataInfos = JsonConvert.DeserializeObject<UpdataInfo[]>(JSONSource);
            UpdataInfo updataInfo = Array.Find(updataInfos, x => x.ProductName == "ASUS Firmware Downloader");
            string NewestVersion = updataInfo.Version;
            if (NewestVersion != ProductVersion)
            {
                if (MessageBox.Show($"發現新版本!版本:{NewestVersion}已發布，您要現在下載嗎?", "發現更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                Updata updata = new Updata(updataInfo.DownloadUrl);
                button1.Text = "Found New Version!";
            }
            else
            {
                button1.Text = "本程式已經是最新版本";
            }
        }
    }
}
