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
            this.txtSteamUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtNfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNfoResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSteamUrl
            // 
            this.txtSteamUrl.Location = new System.Drawing.Point(142, 12);
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
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(677, 661);
            this.txtResult.TabIndex = 3;
            // 
            // txtNfo
            // 
            this.txtNfo.Location = new System.Drawing.Point(822, 55);
            this.txtNfo.Multiline = true;
            this.txtNfo.Name = "txtNfo";
            this.txtNfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNfo.Size = new System.Drawing.Size(948, 317);
            this.txtNfo.TabIndex = 4;
            this.txtNfo.TextChanged += new System.EventHandler(this.txtNfo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(819, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Paste here the entire NFO to be stripped";
            // 
            // txtNfoResult
            // 
            this.txtNfoResult.Location = new System.Drawing.Point(822, 398);
            this.txtNfoResult.Multiline = true;
            this.txtNfoResult.Name = "txtNfoResult";
            this.txtNfoResult.ReadOnly = true;
            this.txtNfoResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNfoResult.Size = new System.Drawing.Size(948, 318);
            this.txtNfoResult.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 728);
            this.Controls.Add(this.txtNfoResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNfo);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSteamUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSteamUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtNfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNfoResult;
    }
}

