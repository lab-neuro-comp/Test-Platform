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
        private bool firstOpenFlag = true;

        public FormImgConfig(string imagesFolderPath, string imgListEdit)
        {
            InitializeComponent();
            path = imagesFolderPath;

            imgPathDataGridView.AllowDrop = true;
            imgPathDataGridView.RowTemplate.MinimumHeight = 120;
            if (imgListEdit != "false")
            {
                insertListForEdition();
            }
        }

        private void insertListForEdition()
        {
            Close();
            throw new NotImplementedException();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openImagesDirectory();
        }

        private void openImagesDirectory()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPeG;*.GIF;*.PNG|" + "All files (*.*)|*.*";
            try
            {
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
                            throw new Exception ("Não pode apresentar a imagem: " + file.Substring(file.LastIndexOf('/'))
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

                selectedImageIntoPictureBox();
                if (firstOpenFlag) { WindowState = FormWindowState.Maximized; firstOpenFlag = false; }
                
            }
            catch (NullReferenceException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void deleteRow_Click(object sender, EventArgs e)
        {
            DataGridView dgv = imgPathDataGridView;
            if(dgv.RowCount == 1)
            {
                pictureBox.Image = null;
                pictureBox.Refresh();
            }
            DGVManipulation.deleteDGVRow(dgv);
        }

        private void imgPathDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedImageIntoPictureBox();
        }

        private void imgPathDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedImageIntoPictureBox();
        }

        private void imgPathDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            selectedImageIntoPictureBox();
        }

        private void selectedImageIntoPictureBox()
        {
            pictureBox.Image = Image.FromFile(imgPathDataGridView.CurrentRow.Cells[2].Value.ToString());
        }
        
        private void btnUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = imgPathDataGridView;
            try
            {
                DGVManipulation.moveDGVRowUp(dgv);
                pictureBox.Image = Image.FromFile(dgv.CurrentRow.Cells[2].Value.ToString());
            }
            catch { }
        }

        

        private void btnDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = imgPathDataGridView;
            try
            {
                DGVManipulation.moveDGVRowDown(dgv);
                pictureBox.Image = Image.FromFile(dgv.CurrentRow.Cells[2].Value.ToString());
            }
            catch { }
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            DataGridView dgv = imgPathDataGridView;
            DGVManipulation.saveColumnToListFile(dgv, 2, path, imgListNameTextBox.Text + "_img");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void imgPathDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Left)
            {
                DataGridView dgv = imgPathDataGridView;
                try
                {
                    DGVManipulation.moveDGVRowUp(dgv);
                }
                catch { }
            }
            if (e.Control && e.KeyCode == Keys.Right)
            {
                DataGridView dgv = imgPathDataGridView;
                try
                {
                    DGVManipulation.moveDGVRowDown(dgv);
                }
                catch { }
            }
        }
    }
}
