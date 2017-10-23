using Services;
using Services.Exceptions.Template;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

                IDictionary<string, string> dict = new Dictionary<string, string>
                {
                    { "poster", model.Data.Header_image },
                    { "title", model.Data.Name },
                    { "nfo", "" },
                    { "description", model.Data.Short_description },
                    { "pc_requirements", model.Data.Pc_requirements.Minimum },
                    { "screenshots", "" },
                    { "youtube", "" }
                };

                txtResult.Text = TemplateManager.RenderTemplate(dict);
            }
            catch(TemplateException templEx)
            {
                MessageBox.Show(templEx.Message);
            }            
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("An error occurred");
            }
        }
    }
}
