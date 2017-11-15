namespace NFOGenerator_Desktop
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.txtSteamUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.musicBtn = new System.Windows.Forms.Button();
            this.radioNfoStripper = new System.Windows.Forms.RadioButton();
            this.txtNfoResult = new System.Windows.Forms.TextBox();
            this.txtNfo = new System.Windows.Forms.TextBox();
            this.radioDisplayMusicData = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFolders = new System.Windows.Forms.DataGridView();
            this.btnDownload = new System.Windows.Forms.Button();
            this.testIt = new System.Windows.Forms.Button();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSteamUrl
            // 
            this.txtSteamUrl.Location = new System.Drawing.Point(141, 12);
            this.txtSteamUrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSteamUrl.Name = "txtSteamUrl";
            this.txtSteamUrl.Size = new System.Drawing.Size(493, 22);
            this.txtSteamUrl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Steam url";
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(641, 11);
            this.btnGetData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 2;
            this.btnGetData.Text = "Get data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(39, 55);
            this.txtResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(677, 584);
            this.txtResult.TabIndex = 3;
            // 
            // musicBtn
            // 
            this.musicBtn.Location = new System.Drawing.Point(39, 672);
            this.musicBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.musicBtn.Name = "musicBtn";
            this.musicBtn.Size = new System.Drawing.Size(219, 44);
            this.musicBtn.TabIndex = 7;
            this.musicBtn.Text = "Get music details";
            this.musicBtn.UseVisualStyleBackColor = true;
            this.musicBtn.Click += new System.EventHandler(this.musicBtn_Click);
            // 
            // radioNfoStripper
            // 
            this.radioNfoStripper.AutoSize = true;
            this.radioNfoStripper.Checked = true;
            this.radioNfoStripper.Location = new System.Drawing.Point(785, 14);
            this.radioNfoStripper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioNfoStripper.Name = "radioNfoStripper";
            this.radioNfoStripper.Size = new System.Drawing.Size(160, 21);
            this.radioNfoStripper.TabIndex = 8;
            this.radioNfoStripper.TabStop = true;
            this.radioNfoStripper.Text = "Display NFO stripper";
            this.radioNfoStripper.UseVisualStyleBackColor = true;
            // 
            // txtNfoResult
            // 
            this.txtNfoResult.Location = new System.Drawing.Point(785, 401);
            this.txtNfoResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNfoResult.Multiline = true;
            this.txtNfoResult.Name = "txtNfoResult";
            this.txtNfoResult.ReadOnly = true;
            this.txtNfoResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNfoResult.Size = new System.Drawing.Size(413, 315);
            this.txtNfoResult.TabIndex = 8;
            // 
            // txtNfo
            // 
            this.txtNfo.Location = new System.Drawing.Point(785, 55);
            this.txtNfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNfo.Multiline = true;
            this.txtNfo.Name = "txtNfo";
            this.txtNfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNfo.Size = new System.Drawing.Size(413, 317);
            this.txtNfo.TabIndex = 7;
            // 
            // radioDisplayMusicData
            // 
            this.radioDisplayMusicData.AutoSize = true;
            this.radioDisplayMusicData.Location = new System.Drawing.Point(1255, 7);
            this.radioDisplayMusicData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioDisplayMusicData.Name = "radioDisplayMusicData";
            this.radioDisplayMusicData.Size = new System.Drawing.Size(136, 21);
            this.radioDisplayMusicData.TabIndex = 10;
            this.radioDisplayMusicData.TabStop = true;
            this.radioDisplayMusicData.Text = "Display FTP stuff";
            this.radioDisplayMusicData.UseVisualStyleBackColor = true;
            this.radioDisplayMusicData.CheckedChanged += new System.EventHandler(this.radioDisplayMusicData_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(781, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Paste here the entire NFO to be stripped";
            // 
            // dgvFolders
            // 
            this.dgvFolders.AllowUserToAddRows = false;
            this.dgvFolders.AllowUserToDeleteRows = false;
            this.dgvFolders.AutoGenerateColumns = false;
            this.dgvFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pathDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn});
            this.dgvFolders.DataSource = this.dgvModelBindingSource;
            this.dgvFolders.Location = new System.Drawing.Point(1255, 34);
            this.dgvFolders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFolders.Name = "dgvFolders";
            this.dgvFolders.ReadOnly = true;
            this.dgvFolders.RowTemplate.Height = 24;
            this.dgvFolders.Size = new System.Drawing.Size(515, 606);
            this.dgvFolders.TabIndex = 12;
            this.dgvFolders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFolders_CellContentClick_1);
            this.dgvFolders.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFolders_CellContentClick);
            this.dgvFolders.SelectionChanged += new System.EventHandler(this.dgvFolders_SelectionChanged);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(1255, 661);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(511, 57);
            this.btnDownload.TabIndex = 13;
            this.btnDownload.Text = "Download nfo from selected folder";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // testIt
            // 
            this.testIt.Location = new System.Drawing.Point(286, 674);
            this.testIt.Name = "testIt";
            this.testIt.Size = new System.Drawing.Size(120, 44);
            this.testIt.TabIndex = 14;
            this.testIt.Text = "Launch to FL";
            this.testIt.UseVisualStyleBackColor = true;
            this.testIt.Click += new System.EventHandler(this.testIt_Click);
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.ReadOnly = true;
            this.pathDataGridViewTextBoxColumn.Visible = false;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dgvModelBindingSource
            // 
            this.dgvModelBindingSource.DataSource = typeof(NFOGenerator_Desktop.DgvModel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1781, 729);
            this.Controls.Add(this.testIt);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dgvFolders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNfoResult);
            this.Controls.Add(this.radioDisplayMusicData);
            this.Controls.Add(this.txtNfo);
            this.Controls.Add(this.radioNfoStripper);
            this.Controls.Add(this.musicBtn);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSteamUrl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Helper";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSteamUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button musicBtn;
        private System.Windows.Forms.RadioButton radioNfoStripper;
        private System.Windows.Forms.TextBox txtNfoResult;
        private System.Windows.Forms.TextBox txtNfo;
        private System.Windows.Forms.RadioButton radioDisplayMusicData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFolders;
        private System.Windows.Forms.BindingSource dgvModelBindingSource;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button testIt;
    }
}

