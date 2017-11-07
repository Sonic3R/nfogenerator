using Services;
using Services.Exceptions.Template;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Threading;

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

                string screens = model.Data.Screenshots?.Length == 0 ? string.Empty :
                    string.Join(" ", model.Data.Screenshots.Select(s => $"[url={s.Path_full.WithoutQueryString()}][img={s.Path_thumbnail.WithoutQueryString()}][/url]"));

                string video = YoutubeManager.GetVideoByKeyword(model.Data.Name);
                if (!string.IsNullOrWhiteSpace(video))
                {
                    video = $"[video={video}]";
                }

                IDictionary<string, string> dict = new Dictionary<string, string>
                {
                    { "poster", $"[img={model.Data.Header_image.WithoutQueryString()}]" },
                    { "title", $"[size=4]{model.Data.Name}[/size]" },
                    { "nfo", "" },
                    { "description", model.Data.Short_description.ToBbcode() },
                    { "pc_requirements", model.Data.Pc_requirements.Minimum.ToBbcode() },
                    { "screenshots", screens },
                    { "youtube", video }
                };

                txtResult.Text = TemplateManager.RenderTemplate(dict);
            }
            catch (TemplateException templEx)
            {
                MessageBox.Show(templEx.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("An error occurred");
            }
        }

        private void txtNfo_TextChanged(object sender, EventArgs e)
        {
            string text = txtNfo.Text;

            txtNfoResult.Text = text.RemoveNonAscii().Trim();
        }

        private void musicBtn_Click(object sender, EventArgs e)
        {
            txtResult.Text = MusicManager.Load();
        }

        private void radioNfoStripper_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioDisplayMusicData_CheckedChanged(object sender, EventArgs e)
        {
            string items = MusicManager.Load();
            LoadData(items, string.Empty);
        }

        private void dgvFolders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvModel data = dgvFolders?.CurrentRow.DataBoundItem as DgvModel;
            if(data != null)
            {
                string items = MusicManager.Load(data.Path);
                LoadData(items, data.Path);
            }
        }

        private void LoadData(string items, string prevPath)
        {
            dgvFolders.DataBindings.Clear();

            if (!string.IsNullOrWhiteSpace(items))
            {
                List<DgvModel> model = new List<DgvModel>();

                string[] split = items.Split(new char[] { '\r', '\n' });
                foreach (string item in split)
                {
                    if (string.IsNullOrWhiteSpace(item))
                    {
                        continue;
                    }

                    model.Add(new DgvModel { Path = prevPath.TrimEnd('/') + "/" + item, Title = item });
                }

                dgvFolders.DataSource = model;
            }
        }
    }
}
