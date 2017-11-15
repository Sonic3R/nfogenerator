using Services;
using Services.Exceptions.Template;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

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
                    { "genre", $"[size=2]Genre: [color=orange]{string.Join(", ", model.Data.Genres.Select(g=>g.Description))}[/color][/size]"},
                    { "description", model.Data.Short_description.ToBbcode() },
                    { "pc_requirements", model.Data.Pc_requirements.Minimum.ToBbcode() },
                    { "screenshots", screens },
                    { "youtube", video },
                    { "url", $"http://store.steampowered.com/app/{model.Data.Steam_appid}/" }
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

        private void dgvFolders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvModel data = dgvFolders?.CurrentRow.DataBoundItem as DgvModel;
            if (data != null)
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
                dgvFolders.DataSource = ToModel(items, prevPath);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvFolders.SelectedRows;
            if (selectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    DgvModel data = row.DataBoundItem as DgvModel;
                    const string extension = "nfo";

                    if (data != null)
                    {
                        string items = MusicManager.Load(data.Path);
                        if (!string.IsNullOrWhiteSpace(items))
                        {
                            List<DgvModel> modelList = ToModel(items, data.Path);
                            foreach (DgvModel model in modelList)
                            {
                                if (Path.GetExtension(model.Path).TrimStart('.').Equals(extension, StringComparison.OrdinalIgnoreCase))
                                {
                                    MusicManager.DownloadFile(model.Path, @"C:\Users\mteodorescu\Downloads\pics\");
                                }

                            }
                        }
                    }
                }
            }
        }

        private void radioDisplayMusicData_CheckedChanged(object sender, EventArgs e)
        {
            string items = MusicManager.Load();
            LoadData(items, string.Empty);
        }

        private List<DgvModel> ToModel(string items, string prevPath)
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

            return model;
        }

        /// <summary>
        /// select once time the cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFolders_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dgvFolders.Rows[e.RowIndex].Selected = true;
        }

        private void dgvFolders_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection cells = dgvFolders.SelectedCells;
            foreach (DataGridViewCell cell in cells)
            {
                dgvFolders.Rows[cell.RowIndex].Selected = true;
            }
        }

        private void testIt_Click(object sender, EventArgs e)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://filelist.ro/login.php");
                driver.FindElement(By.Id("username")).SendKeys("Megatron4FL");

                string password = Crypto.DecryptStringAES(ConfigurationManager.AppSettings["flPassword"], ConfigurationManager.AppSettings["encryptPassword"]);
                driver.FindElement(By.Id("password")).SendKeys(password);
                driver.FindElement(By.Id("password")).SendKeys(OpenQA.Selenium.Keys.Enter);
            }
        }
    }
}
