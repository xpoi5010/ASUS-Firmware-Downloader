namespace ASUS_Firmware_Downloader
{
    partial class DownloadList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.controlList1 = new ASUS_Firmware_Downloader.ControlList();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(408, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "全數清空";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // controlList1
            // 
            this.controlList1.BackColor = System.Drawing.Color.White;
            this.controlList1.Location = new System.Drawing.Point(12, 43);
            this.controlList1.MaxSize = 0;
            this.controlList1.Name = "controlList1";
            this.controlList1.Size = new System.Drawing.Size(471, 420);
            this.controlList1.TabIndex = 1;
            // 
            // DownloadList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(495, 472);
            this.Controls.Add(this.controlList1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "DownloadList";
            this.Text = "下載列表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadList_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private ControlList controlList1;
    }
}