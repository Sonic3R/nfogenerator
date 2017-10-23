using Services;
using Services.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFOGenerator_Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            string steamUrl = txtSteamUrl.Text;
            if (string.IsNullOrWhiteSpace(steamUrl))
            {
                MessageBox.Show("No steam url is provided");
                return;
            }

            try
            {
                string steamId = SteamManager.GetId(steamUrl);
                if (string.IsNullOrWhiteSpace(steamId))
                {
                    MessageBox.Show("No id found !");
                    return;
                }

                SteamModel model = SteamManager.LoadGameById(steamId);

                if (!model.Success)
                {
                    MessageBox.Show("No game found on steam");
                    return;
                }

                txtResult.Text = TemplateManager.GetTemplate();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("An error occurred");
            }
        }
    }
}
