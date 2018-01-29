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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace ASUS_Firmware_Downloader
{
    public partial class DownloadControl : UserControl
    {
        public DownloadControl(string version, string size, string url, string path)
        {
            InitializeComponent();
            URL = url;
            Path = path;
        }
        public string URL { get; set; }
        public string Path { get; set; }
        WebClient webClient = new WebClient();
        public void StartDownload()
        {
            lastRecvTime = DateTime.Now;
            webClient.DownloadFileAsync(new Uri(URL), Path);

            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;

        }
        public delegate void DownloadEvent(object sender);
        public event DownloadEvent StopDownloadEvent;
        public event DownloadEvent DownloadCompleted;
        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!stopped) DownloadCompleted?.Invoke(this);
        }
        long lastDownloadSize = 0;
        DateTime lastRecvTime;
        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            TimeSpan ts = DateTime.Now - lastRecvTime;
            if (ts.TotalSeconds > 1)
            {
                lastRecvTime = DateTime.Now;
                double speed = (e.BytesReceived - lastDownloadSize) / ts.TotalSeconds;
                Debug.Print(e.BytesReceived.ToString());
                this.speed.Text = $"速率:{bytesToStringFormat((long)speed)}";
                path.Text = $@"目的地:{Path}";
                lastDownloadSize = e.BytesReceived;
            }
            progressBar1.Value = (int)((double)e.BytesReceived / (double)e.TotalBytesToReceive * 10000);
            downloaded.Text = $@"已下載:{bytesToStringFormat(e.BytesReceived)}";
            size.Text = $"大小:{bytesToStringFormat(e.TotalBytesToReceive)}";

        }
        private string bytesToStringFormat(long bytes)//KiB MiB GiB TiB PiB EiB ZiB YiB 二進位字首 long max = 2^63 -1 ~-(2^63) int max2^31-1~-(2^31) 
        {

            if (Math.Round((double)bytes) < 1024)
            {
                return $"{(Math.Round((double)bytes, 2))}B";
            }
            else if (Math.Round((double)bytes) >= (1 << 10) && Math.Round((double)bytes) < (1 << 20))
            {
                return $"{Math.Round(Math.Round((double)bytes) / (double)(1 << 10), 2)}KiB";
            }
            else if (Math.Round((double)bytes) >= (1 << 20) && Math.Round((double)bytes) < (1 << 30))
            {
                return $"{Math.Round(Math.Round((double)bytes) / (double)(1 << 20), 2)}MiB";
            }
            else if (Math.Round((double)bytes) >= (1 << 30) && Math.Round((double)bytes) < ((long)1 << 40))
            {
                return $"{Math.Round(Math.Round((double)bytes) / (double)(1 << 30), 2)}GiB";
            }
            else if (Math.Round((double)bytes) >= ((long)1 << 40) && Math.Round((double)bytes) < ((long)1 << 50))
            {
                return $"{Math.Round(Math.Round((double)bytes) / (double)(1 << 40), 2)}TiB";
            }
            else if (Math.Round((double)bytes) >= ((long)1 << 50))
            {
                return $"{Math.Round(Math.Round((double)bytes) / (double)(1 << 50), 2)}PiB";
            }
            else
            {
                return $@"{Math.Round((double)bytes)}";
            }
        }
        bool stopped = false;
        public void StopDownload()
        {
            stopped = true;
            webClient.CancelAsync();
            StopDownloadEvent?.Invoke(this);
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("您確定要停止下載嗎?", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            StopDownload();
        }
        ~DownloadControl()
        {
            stopped = true;
            webClient.CancelAsync();
        }
    }
}
