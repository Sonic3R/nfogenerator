using Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Text;
using Services.Music;

namespace NFOGenerator_Desktop
{
    public partial class Form1 : Form
    {
        private string _gameGenre;

        public Form1()
        {
            InitializeComponent();

            string items = MusicManager.Load();
            LoadData(items, string.Empty);
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
                    const string nfoExt = "nfo";
                    const string imgExt = "jpg";

                    if (data != null)
                    {
                        string items = MusicManager.Load(data.Path);
                        if (!string.IsNullOrWhiteSpace(items))
                        {
                            List<DgvModel> modelList = ToModel(items, data.Path);
                            foreach (DgvModel model in modelList)
                            {
                                if (Path.GetExtension(model.Path).TrimStart('.').Equals(nfoExt, StringComparison.OrdinalIgnoreCase) ||
                                    Path.GetExtension(model.Path).TrimStart('.').Equals(imgExt, StringComparison.OrdinalIgnoreCase))
                                {
                                    model.DownloadedAs = MusicManager.DownloadFile(model.Path, ConfigurationManager.AppSettings["downloadMusicNfoPath"]);
                                }
                            }

                            btnGenerateNfo.Enabled = true;
                        }
                    }
                }

                MessageBox.Show("Download complete !");
            }
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

        private void btnGenerateNfo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "nfo files (*.nfo)|*.nfo";
                dialog.RestoreDirectory = true;
                dialog.Multiselect = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var files = dialog.FileNames;
                    var sb = new StringBuilder();
                    sb.AppendLine("[center]");

                    foreach (var file in files)
                    {
                        string scene = FileParser.GetScene(file);
                        FileParser parser = null;

                        switch (scene)
                        {
                            case "talion":
                                parser = new TalionParser(file);
                                break;

                            case "mms":
                                parser = new MmsParser(file);
                                break;

                            case "dh":
                                parser = new DhParser(file);
                                break;

                            case "fast4u":
                                parser = new Fast4UParser(file);
                                break;

                            case "enslave":
                                parser = new EnslaveParser(file);
                                break;

                            case "sfh":
                                parser = new SfhParser(file);
                                break;

                            case "zzzz":
                                parser = new ZzzzParser(file);
                                break;

                            case "bb8":
                                parser = new Bb8Parser(file);
                                break;

                            case "cue":
                                parser = new CueParser(file);
                                break;

                            case "r35":
                                parser = new R35Parser(file);
                                break;

                            default:
                                parser = new DefaultParser(file);
                                break;
                        }

                        if (parser == null)
                        {
                            continue;
                        }

                        parser.LoadData();

                        if (parser.IsEmpty)
                        {
                            continue;
                        }

                        IDictionary<string, string> dict = new Dictionary<string, string>
                            {
                                { "title", $"[size=5]{parser.Title?.Trim() }[/size]" },
                                { "artist", $"[size=4]{parser.Artist?.Trim()}[/size]" },
                                { "genre", $"Genre: {parser.Genre?.Trim()}" },
                                { "quality", $"Quality: {parser.Quality?.Trim()}" },
                                { "length", $"Duration: {parser.Length?.Trim() }" },
                                { "tracklist", parser.TrackList == null ? "" : $"Track list:\r\n{string.Join("\r\n", parser.TrackList) }" }
                            };

                        sb.AppendLine(TemplateManager.RenderTemplate(dict, ETemplateType.MUSIC));
                    }

                    sb.AppendLine("[/center]");
                    txtMusicNfo.Text = sb.ToString();
                }
            }
        }
    }
}
