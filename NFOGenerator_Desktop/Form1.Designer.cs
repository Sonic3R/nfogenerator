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
            this.dgvModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.launchToFL = new System.Windows.Forms.Button();
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
            this.btnGetData.Size = new System.Drawing.Size(75, 40);
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
            this.txtResult.Size = new System.Drawing.Size(803, 584);
            this.txtResult.TabIndex = 3;
            // 
            // dgvModelBindingSource
            // 
            this.dgvModelBindingSource.DataSource = typeof(NFOGenerator_Desktop.DgvModel);
            // 
            // launchToFL
            // 
            this.launchToFL.Enabled = false;
            this.launchToFL.Location = new System.Drawing.Point(722, 12);
            this.launchToFL.Name = "launchToFL";
            this.launchToFL.Size = new System.Drawing.Size(120, 39);
            this.launchToFL.TabIndex = 14;
            this.launchToFL.Text = "Launch to FL";
            this.launchToFL.UseVisualStyleBackColor = true;
            this.launchToFL.Click += new System.EventHandler(this.launchToFL_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 729);
            this.Controls.Add(this.launchToFL);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSteamUrl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Helper";
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSteamUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.BindingSource dgvModelBindingSource;
        private System.Windows.Forms.Button launchToFL;
    }
}

