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
using System.Threading;
using System.Text.RegularExpressions;
using Services.Parsers;
using System.Threading.Tasks;

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
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 0;

            FormClosing += Form1_Closing;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                progressBar.BeginInvoke(new Action(() =>
                {
                    progressBar.Style = ProgressBarStyle.Marquee;
                }));
            });

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

                string screens = string.Empty;
                if (model.Data.Screenshots != null && model.Data.Screenshots.Length > 0)
                {
                    int take = model.Data.Screenshots.Length < 6 ? model.Data.Screenshots.Length : 6;
                    screens = string.Join(" ", model.Data.Screenshots.Take(take).Select(s => $"[url={s.Path_full.WithoutQueryString()}][img={s.Path_thumbnail.WithoutQueryString()}][/url]"));
                }

                string video = YoutubeManager.GetVideoByKeyword(model.Data.Name);
                if (!string.IsNullOrWhiteSpace(video))
                {
                    video = $"[video={video}]";
                }

                _gameGenre = string.Join(", ", model.Data.Genres.Select(g => g.Description));
                string installNotes = null;

                using(OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Filter = "nfo file (*.nfo)|*.nfo";
                    dialog.RestoreDirectory = true;

                    if(dialog.ShowDialog() == DialogResult.OK)
                    {
                        NfoParser parser = GetParser(dialog.FileName);

                        if (parser != null)
                        {
                            installNotes = parser.InstallNotes;
                        }
                    }
                }

                IDictionary<string, string> dict = new Dictionary<string, string>
                {
                    { "poster", $"[img={model.Data.Header_image.WithoutQueryString()}]" },
                    { "title", $"[size=4]{model.Data.Name}[/size]" },
                    { "genre", string.IsNullOrWhiteSpace(_gameGenre) ?
                        string.Empty :
                        $"[size=2]Genre: {_gameGenre}[/size]"},
                    { "description", model.Data.Short_description.ToBbcode() },
                    { "pc_requirements", model.Data.Pc_requirements.Minimum.ToBbcode() },
                    { "screenshots", screens },
                    { "youtube", video },
                    { "installnotes", installNotes?.Trim()?.RemoveNonAscii()?.Trim() },
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

            try {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Filter = "torrent file (*.torrent)|*.torrent";
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

                        Thread.Sleep(3000);

                        var id = ExtractIdFromUrl(_driver.Url);
                        if (!string.IsNullOrWhiteSpace(id))
                        {
                            _driver.Navigate().GoToUrl("https://filelist.ro/edit.php?id=" + id);
                            IWebElement checkbox = _driver.FindElement(By.Name("visible"));
                            if (!checkbox.Selected)
                            {
                                checkbox.Click();
                            }

                            _driver.FindElement(By.XPath("//*[@id=\"btnedit\"]")).Click();
                        }

                        txtResult.Text = string.Empty;

                        Task.Run(() =>
                        {
                            progressBar.BeginInvoke(new Action(() =>
                            {
                                progressBar.Style = ProgressBarStyle.Continuous;
                                progressBar.Value = 0;
                            }));
                        });
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                _driver.Dispose();
                _driver = null;
            }
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(_driver != null)
            {
                _driver.Dispose();
            }
        }

        private static string ExtractIdFromUrl(string url)
        {
            var regex = new Regex(@"http(s)?:\/\/filelist\.ro\/details\.php\?id=(\d+)");
            var match = regex.Match(url);

            if (match.Success)
            {
                return match.Groups[2].Value;
            }

            return string.Empty;
        }

        private static NfoParser GetParser(string filename)
        {
            string release = Path.GetFileNameWithoutExtension(filename);
            switch(release.ToLower())
            {
                case "skidrow":
                    return new SkidrowParser(filename);

                case "codex":
                    return new CodexParser(filename);

                case "reloaded":
                    return new ReloadedParser(filename);

                case "plaza":
                    return new PlazaParser(filename);

                case "hi2u":
                    return new Hi2uParser(filename);
            }

            return null;
        }
    }
}
