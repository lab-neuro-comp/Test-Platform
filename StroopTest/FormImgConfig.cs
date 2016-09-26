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
            
            imgPathListView.AllowDrop = true;
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
                        /*
                        var listViewItem = new ListViewItem(new[] {Path.GetFileNameWithoutExtension(file), Path.GetFullPath(file)});
                        imgPathListView.Items.Add(listViewItem);*/
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não pode apresentar a imagem: " + file.Substring(file.LastIndexOf('/'))
                                        + ". Você pode não ter permissão para ler este arquivo ou ele pode estar corrompido.\n" + ex.Message);
                    }

                    DataTable dt = new DataTable();
                    dt.Columns.Add("values");
                    /*
                    foreach (string items in description)
                    {
                        DataRow row = dt.NewRow();
                        dt.Rows.Add(items);
                    }
                    this.dataGridView2.DataSource = dt;*/
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void imgPathListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pictureBox.Image = Image.FromFile();
        }
    }
}
