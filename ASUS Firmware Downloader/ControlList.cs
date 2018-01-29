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
using System.Diagnostics;

namespace ASUS_Firmware_Downloader
{
    public partial class ControlList : UserControl
    {
        public ControlList()
        {
            InitializeComponent();
            MaxSize = 0;
        }
        public List<Control> list = new List<Control>();
        public int Count { get { return list.Count; } }
        public int MaxSize { get; set; }
        public void Add(Control control)
        {
            list.Add(control);
            control.Location = new Point(0, MaxSize + 6);
            panel1.Controls.Add(control);
            MaxSize += control.Size.Height + 6;
        }
        public void Remove(Control control)
        {
            list.Remove(control);
            int index = panel1.Controls.IndexOf(control);
            panel1.Controls.Remove(control);
            for(int i = index; i < panel1.Controls.Count; i++)
            {
                panel1.Controls[i].Location = new Point(panel1.Controls[i].Location.X, panel1.Controls[i].Location.Y - (control.Size.Height + 6));
            }
            MaxSize -= (control.Size.Height + 6);
        }
        private void ControlList_Load(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Clear()
        {
            this.panel1.Controls.Clear();
            list.Clear();
            MaxSize = 0;
        }
    }
}
