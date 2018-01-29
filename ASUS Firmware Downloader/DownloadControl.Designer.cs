namespace ASUS_Firmware_Downloader
{
    partial class DownloadControl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.speed = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.downloaded = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.Label();
            this.size = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speed.Location = new System.Drawing.Point(6, 36);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(35, 17);
            this.speed.TabIndex = 13;
            this.speed.Text = "速率:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(373, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 64);
            this.button2.TabIndex = 12;
            this.button2.Text = "終止下載";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 73);
            this.progressBar1.Maximum = 10000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(446, 12);
            this.progressBar1.Step = 1000;
            this.progressBar1.TabIndex = 11;
            // 
            // downloaded
            // 
            this.downloaded.AutoSize = true;
            this.downloaded.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloaded.Location = new System.Drawing.Point(6, 51);
            this.downloaded.Name = "downloaded";
            this.downloaded.Size = new System.Drawing.Size(47, 17);
            this.downloaded.TabIndex = 10;
            this.downloaded.Text = "已下載:";
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.path.Location = new System.Drawing.Point(6, 21);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(47, 17);
            this.path.TabIndex = 9;
            this.path.Text = "目的地:";
            // 
            // size
            // 
            this.size.AutoSize = true;
            this.size.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size.Location = new System.Drawing.Point(6, 6);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(35, 17);
            this.size.TabIndex = 8;
            this.size.Text = "大小:";
            // 
            // DownloadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.speed);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.downloaded);
            this.Controls.Add(this.path);
            this.Controls.Add(this.size);
            this.Name = "DownloadControl";
            this.Size = new System.Drawing.Size(462, 93);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label speed;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label downloaded;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Label size;
    }
}
