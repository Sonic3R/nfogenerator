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
            this.dgvFolders = new System.Windows.Forms.DataGridView();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnGenerateNfo = new System.Windows.Forms.Button();
            this.txtMusicNfo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.dgvFolders.Location = new System.Drawing.Point(29, 47);
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
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(29, 659);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(280, 57);
            this.btnDownload.TabIndex = 13;
            this.btnDownload.Text = "Download nfo from selected folder";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnGenerateNfo
            // 
            this.btnGenerateNfo.Location = new System.Drawing.Point(333, 659);
            this.btnGenerateNfo.Name = "btnGenerateNfo";
            this.btnGenerateNfo.Size = new System.Drawing.Size(211, 57);
            this.btnGenerateNfo.TabIndex = 14;
            this.btnGenerateNfo.Text = "Generate nfo for music";
            this.btnGenerateNfo.UseVisualStyleBackColor = true;
            // 
            // txtMusicNfo
            // 
            this.txtMusicNfo.Location = new System.Drawing.Point(602, 47);
            this.txtMusicNfo.Multiline = true;
            this.txtMusicNfo.Name = "txtMusicNfo";
            this.txtMusicNfo.ReadOnly = true;
            this.txtMusicNfo.Size = new System.Drawing.Size(677, 606);
            this.txtMusicNfo.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 729);
            this.Controls.Add(this.txtMusicNfo);
            this.Controls.Add(this.btnGenerateNfo);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dgvFolders);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Helper";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvFolders;
        private System.Windows.Forms.BindingSource dgvModelBindingSource;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnGenerateNfo;
        private System.Windows.Forms.TextBox txtMusicNfo;
    }
}

