namespace ASUS_Firmware_Downloader
{
    partial class Form1
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.productImage = new System.Windows.Forms.PictureBox();
            this.productName = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.loading = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.download1 = new ASUS_Firmware_Downloader.Download();
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).BeginInit();
            this.SuspendLayout();
            // 
            // productImage
            // 
            this.productImage.Location = new System.Drawing.Point(12, 12);
            this.productImage.Name = "productImage";
            this.productImage.Size = new System.Drawing.Size(100, 100);
            this.productImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productImage.TabIndex = 0;
            this.productImage.TabStop = false;
            // 
            // productName
            // 
            this.productName.AutoSize = true;
            this.productName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.productName.Location = new System.Drawing.Point(118, 12);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(0, 29);
            this.productName.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listView1.Location = new System.Drawing.Point(12, 118);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(200, 380);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // loading
            // 
            this.loading.AutoSize = true;
            this.loading.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loading.Location = new System.Drawing.Point(12, 12);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(226, 24);
            this.loading.TabIndex = 0;
            this.loading.Text = "載入產品列表中....";
            this.loading.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // download1
            // 
            this.download1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.download1.Location = new System.Drawing.Point(232, 118);
            this.download1.Name = "download1";
            this.download1.Size = new System.Drawing.Size(559, 377);
            this.download1.Source = "";
            this.download1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 510);
            this.Controls.Add(this.download1);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.productName);
            this.Controls.Add(this.productImage);
            this.Name = "Form1";
            this.Text = "ASUS韌體下載器";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox productImage;
        private System.Windows.Forms.Label productName;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label loading;
        private System.Windows.Forms.ImageList imageList1;
        private Download download1;
    }
}

