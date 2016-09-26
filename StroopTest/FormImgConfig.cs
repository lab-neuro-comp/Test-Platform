using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormImgConfig : Form
    {
        private List<string> pathList = new List<string>();
        private ImageList imgsList = new ImageList();
        private string path;

        public FormImgConfig(string imagesFolderPath)
        {
            InitializeComponent();
            path = imagesFolderPath;

            imgPathDataGridView.AllowDrop = true;
            imgPathDataGridView.RowTemplate.MinimumHeight = 120;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openImagesDirectory();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        
        private void imgPathDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox.Image = Image.FromFile(imgPathDataGridView.CurrentRow.Cells[2].Value.ToString());
        }
        
        private void openImagesDirectory()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    try
                    {
                        pathList.Add(Path.GetFullPath(file));
                        Image image = Image.FromFile(Path.GetFullPath(file));
                        imgPathDataGridView.Rows.Add(Path.GetFileNameWithoutExtension(file), image, Path.GetFullPath(file));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não pode apresentar a imagem: " + file.Substring(file.LastIndexOf('/'))
                                        + ". Você pode não ter permissão para ler este arquivo ou ele pode estar corrompido.\n" + ex.Message);
                    }
                }
            }

            for (int i = 0; i < imgPathDataGridView.Columns.Count; i++)
            if (imgPathDataGridView.Columns[i] is DataGridViewImageColumn)
            {
                ((DataGridViewImageColumn)imgPathDataGridView.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                break;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.imgPathDataGridView.SelectedRows)
            {
                imgPathDataGridView.Rows.RemoveAt(item.Index);
            }
        }
    }
}
