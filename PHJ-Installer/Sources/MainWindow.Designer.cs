namespace PHJ
{
    partial class PHJ
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PHJ));
            this.instProgress = new System.Windows.Forms.ProgressBar();
            this.instDetails = new System.Windows.Forms.Label();
            this.startInstall = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dnSpeed = new System.Windows.Forms.Label();
            this.dnPerc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InstallApache24Async = new System.ComponentModel.BackgroundWorker();
            this.InstallPHJAsync = new System.ComponentModel.BackgroundWorker();
            this.ExtractorApache24Async = new System.ComponentModel.BackgroundWorker();
            this.ExtractorPHJAsync = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.linkLocalhost = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // instProgress
            // 
            this.instProgress.BackColor = System.Drawing.Color.LemonChiffon;
            this.instProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instProgress.Location = new System.Drawing.Point(3, 285);
            this.instProgress.MarqueeAnimationSpeed = 1;
            this.instProgress.Name = "instProgress";
            this.instProgress.Size = new System.Drawing.Size(278, 14);
            this.instProgress.TabIndex = 2;
            // 
            // instDetails
            // 
            this.instDetails.AutoSize = true;
            this.instDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instDetails.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instDetails.Location = new System.Drawing.Point(3, 3);
            this.instDetails.Margin = new System.Windows.Forms.Padding(3);
            this.instDetails.Name = "instDetails";
            this.instDetails.Size = new System.Drawing.Size(165, 18);
            this.instDetails.TabIndex = 3;
            this.instDetails.Text = "Progress Details";
            // 
            // startInstall
            // 
            this.startInstall.BackColor = System.Drawing.Color.ForestGreen;
            this.startInstall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startInstall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startInstall.FlatAppearance.BorderSize = 0;
            this.startInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startInstall.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startInstall.ForeColor = System.Drawing.Color.White;
            this.startInstall.Location = new System.Drawing.Point(3, 3);
            this.startInstall.Name = "startInstall";
            this.startInstall.Size = new System.Drawing.Size(138, 54);
            this.startInstall.TabIndex = 0;
            this.startInstall.Text = "Begin Install";
            this.startInstall.UseVisualStyleBackColor = false;
            this.startInstall.Click += new System.EventHandler(this.StartInstall_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.instProgress, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 258F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 362);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.74627F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.25373F));
            this.tableLayoutPanel2.Controls.Add(this.startInstall, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 302);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(284, 60);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dnSpeed, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.dnPerc, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(147, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(134, 54);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dnSpeed
            // 
            this.dnSpeed.AutoSize = true;
            this.dnSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dnSpeed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dnSpeed.Location = new System.Drawing.Point(3, 27);
            this.dnSpeed.Name = "dnSpeed";
            this.dnSpeed.Size = new System.Drawing.Size(128, 27);
            this.dnSpeed.TabIndex = 1;
            this.dnSpeed.Text = "0.00 kB/s";
            this.dnSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dnPerc
            // 
            this.dnPerc.AutoSize = true;
            this.dnPerc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dnPerc.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dnPerc.Location = new System.Drawing.Point(3, 0);
            this.dnPerc.Name = "dnPerc";
            this.dnPerc.Size = new System.Drawing.Size(128, 27);
            this.dnPerc.TabIndex = 0;
            this.dnPerc.Text = "0 %";
            this.dnPerc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 258);
            this.panel1.TabIndex = 5;
            // 
            // InstallApache24Async
            // 
            this.InstallApache24Async.WorkerReportsProgress = true;
            this.InstallApache24Async.WorkerSupportsCancellation = true;
            this.InstallApache24Async.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InstallApache24Async_DoWork);
            this.InstallApache24Async.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.InstallApache24Async_ProgressChanged);
            this.InstallApache24Async.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.InstallApache24Async_RunWorkerCompleted);
            // 
            // InstallPHJAsync
            // 
            this.InstallPHJAsync.WorkerReportsProgress = true;
            this.InstallPHJAsync.WorkerSupportsCancellation = true;
            this.InstallPHJAsync.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InstallPHJAsync_DoWork);
            this.InstallPHJAsync.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.InstallPHJAsync_ProgressChanged);
            this.InstallPHJAsync.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.InstallPHJAsync_RunWorkerCompleted);
            // 
            // ExtractorApache24Async
            // 
            this.ExtractorApache24Async.WorkerReportsProgress = true;
            this.ExtractorApache24Async.WorkerSupportsCancellation = true;
            this.ExtractorApache24Async.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ExtractorApache24Async_DoWork);
            this.ExtractorApache24Async.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ExtractorApache24Async_ProgressChanged);
            this.ExtractorApache24Async.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ExtractorApache24Async_RunWorkerCompleted);
            // 
            // ExtractorPHJAsync
            // 
            this.ExtractorPHJAsync.WorkerReportsProgress = true;
            this.ExtractorPHJAsync.WorkerSupportsCancellation = true;
            this.ExtractorPHJAsync.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ExtractorPHJAsync_DoWork);
            this.ExtractorPHJAsync.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ExtractorPHJAsync_ProgressChanged);
            this.ExtractorPHJAsync.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ExtractorPHJAsync_RunWorkerCompleted);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.21127F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.78873F));
            this.tableLayoutPanel4.Controls.Add(this.instDetails, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.linkLocalhost, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 258);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(284, 24);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // linkLocalhost
            // 
            this.linkLocalhost.AutoSize = true;
            this.linkLocalhost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLocalhost.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.linkLocalhost.Location = new System.Drawing.Point(174, 0);
            this.linkLocalhost.Name = "linkLocalhost";
            this.linkLocalhost.Size = new System.Drawing.Size(107, 24);
            this.linkLocalhost.TabIndex = 4;
            this.linkLocalhost.TabStop = true;
            this.linkLocalhost.Text = "http://localhost/";
            this.linkLocalhost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLocalhost.Visible = false;
            this.linkLocalhost.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLocalhost_LinkClicked);
            // 
            // PHJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PHJ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHJ Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.phjInstall_FormClosing);
            this.Load += new System.EventHandler(this.phjInstall_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar instProgress;
        private System.Windows.Forms.Label instDetails;
        private System.Windows.Forms.Button startInstall;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label dnPerc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label dnSpeed;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker InstallApache24Async;
        private System.ComponentModel.BackgroundWorker InstallPHJAsync;
        private System.ComponentModel.BackgroundWorker ExtractorApache24Async;
        private System.ComponentModel.BackgroundWorker ExtractorPHJAsync;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.LinkLabel linkLocalhost;
    }
}

