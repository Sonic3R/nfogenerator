using Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

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
    }
}
