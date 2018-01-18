namespace ASUS_Firmware_Downloader
{
    partial class Downloader
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
            this.size = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.Label();
            this.downloaded = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.speed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // size
            // 
            this.size.AutoSize = true;
            this.size.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size.Location = new System.Drawing.Point(9, 9);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(34, 15);
            this.size.TabIndex = 1;
            this.size.Text = "大小:";
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.path.Location = new System.Drawing.Point(9, 24);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(46, 15);
            this.path.TabIndex = 2;
            this.path.Text = "目的地:";
            // 
            // downloaded
            // 
            this.downloaded.AutoSize = true;
            this.downloaded.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloaded.Location = new System.Drawing.Point(9, 54);
            this.downloaded.Name = "downloaded";
            this.downloaded.Size = new System.Drawing.Size(46, 15);
            this.downloaded.TabIndex = 3;
            this.downloaded.Text = "已下載:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 76);
            this.progressBar1.Maximum = 10000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(446, 12);
            this.progressBar1.Step = 1000;
            this.progressBar1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(376, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 64);
            this.button2.TabIndex = 6;
            this.button2.Text = "終止下載";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speed.Location = new System.Drawing.Point(9, 39);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(34, 15);
            this.speed.TabIndex = 7;
            this.speed.Text = "速率:";
            // 
            // Downloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 97);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.downloaded);
            this.Controls.Add(this.path);
            this.Controls.Add(this.size);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Downloader";
            this.Text = "正在下載:";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label size;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Label downloaded;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label speed;
    }
}