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

namespace ASUS_Firmware_Downloader
{
    public partial class DownloadList : Form
    {
        public DownloadList()
        {
            InitializeComponent();
        }
        public int Count { get { return controlList1.Count; } }
        public void AddDownload(string version, string size, string url, string path)
        {
            DownloadControl downloadControl = new DownloadControl(version, size, url, path);
            downloadControl.DownloadCompleted += DownloadCompleted;
            downloadControl.StopDownloadEvent += StopDownloadEvent;
            downloadControl.StartDownload();
            controlList1.Add(downloadControl);
        }

        private void StopDownloadEvent(object sender)
        {
            //listBox1.Items.Remove(sender);
            controlList1.Remove((Control)sender);
        }

        private void DownloadCompleted(object sender)
        {
            //listBox1.Items.Remove(sender);
            controlList1.Remove((Control)sender);
        }

        private void DownloadList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您確定要結束目前正在進行的下載?", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            for(int i =0;i<controlList1.list.Count;i++)
            {
                DownloadControl a = (DownloadControl)controlList1.list[i];
                a.StopDownload();
            }
            controlList1.Clear();
        }
    }
}
