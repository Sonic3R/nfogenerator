using Services;
using Services.Exceptions.Template;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace NFOGenerator_Desktop
{
    public partial class Form1 : Form
    {
        private string _gameGenre;
        private IWebDriver _driver;

        public Form1()
        {
            InitializeComponent();
            _driver = new ChromeDriver();

            FormClosing += Form1_Closing;
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

                _gameGenre = string.Join(", ", model.Data.Genres.Select(g => g.Description));

                IDictionary<string, string> dict = new Dictionary<string, string>
                {
                    { "poster", $"[img={model.Data.Header_image.WithoutQueryString()}]" },
                    { "title", $"[size=4]{model.Data.Name}[/size]" },
                    { "genre", string.IsNullOrWhiteSpace(_gameGenre) ? 
                        string.Empty : 
                        $"[size=2]Genre: [color=orange]{string.Join(", ", model.Data.Genres.Select(g=>g.Description))}[/color][/size]"},
                    { "description", model.Data.Short_description.ToBbcode() },
                    { "pc_requirements", model.Data.Pc_requirements.Minimum.ToBbcode() },
                    { "screenshots", screens },
                    { "youtube", video },
                    { "url", $"http://store.steampowered.com/app/{model.Data.Steam_appid}/" }
                };

                txtResult.Text = TemplateManager.RenderTemplate(dict);

                if (!string.IsNullOrWhiteSpace(txtResult.Text))
                {
                    launchToFL.Enabled = true;
                }
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

        private void launchToFL_Click(object sender, EventArgs e)
        {
            launchToFL.Enabled = false;
            txtSteamUrl.Text = string.Empty;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "torrent files (*.torrent)|*.torrent";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string user = ConfigurationManager.AppSettings["flUser"];

                    _driver.Navigate().GoToUrl("https://filelist.ro/login.php");
                    _driver.FindElement(By.Id("username")).SendKeys(user);

                    string password = Crypto.DecryptStringAES(ConfigurationManager.AppSettings["flPassword"], ConfigurationManager.AppSettings["encryptPassword"]);
                    _driver.FindElement(By.Id("password")).SendKeys(password);
                    _driver.FindElement(By.Id("password")).SendKeys(OpenQA.Selenium.Keys.Enter);

                    _driver.Navigate().GoToUrl("https://filelist.ro/upload.php");
                    _driver.FindElement(By.Name("file")).SendKeys(dialog.FileName);
                    _driver.FindElement(By.Name("name")).SendKeys(Path.GetFileName(dialog.FileName));
                    _driver.FindElement(By.Name("type")).SendKeys("Jocuri PC");
                    _driver.FindElement(By.Name("description")).SendKeys(_gameGenre);
                    _driver.FindElement(By.Name("descr")).SendKeys(txtResult.Text);

                    _driver.FindElement(By.Name("epenis")).SendKeys(user);
                    _driver.FindElement(By.XPath("//*[@id=\"maincolumn\"]/div/div[5]/div/form/table/tbody/tr[10]/td/input[1]")).Click();

                    txtResult.Text = string.Empty;
                }
            }
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(_driver != null)
            {
                _driver.Dispose();
            }
        }
    }
}
