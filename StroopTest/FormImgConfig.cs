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
            if (imgPathDataGridView.RowCount > 1)
            {
                foreach (DataGridViewRow item in this.imgPathDataGridView.SelectedRows)
                {
                    imgPathDataGridView.Rows.RemoveAt(item.Index);
                }
            }
            else
            {
                imgPathDataGridView.Rows.Clear();
                imgPathDataGridView.Refresh();
                pictureBox.Image = null;
                pictureBox.Refresh();
            }
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
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == 0)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.Rows.Insert(rowIndex - 1, selectedRow);
                dgv.ClearSelection();
                dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
                pictureBox.Image = Image.FromFile(dgv.CurrentRow.Cells[2].Value.ToString());
            }
            catch { }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = imgPathDataGridView;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.Rows.Insert(rowIndex + 1, selectedRow);
                dgv.ClearSelection();
                dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
                pictureBox.Image = Image.FromFile(dgv.CurrentRow.Cells[2].Value.ToString());
            }
            catch { }
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "List (.lst)|*.lst"; // salva em .lst
            saveFileDialog1.RestoreDirectory = true;

            try
            {
                if (string.IsNullOrWhiteSpace(imgListNameTextBox.Text))
                {
                    throw new Exception("Preencha o campo com o nome do arquivo!");
                }

                if (File.Exists(path + imgListNameTextBox.Text + ".lst"))
                {
                    DialogResult dr = MessageBox.Show("Uma lista com este nome já existe.\nDeseja sobrescrevê-la?", "", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.Cancel)
                    {
                        throw new Exception("A lista de imagens não será salva!");
                    }
                }

                StreamWriter w1 = new StreamWriter(path + imgListNameTextBox.Text + ".lst");
                for (int i = 0; i < imgPathDataGridView.RowCount; i++)
                {
                    w1.WriteLine(imgPathDataGridView.Rows[i].Cells[2].Value.ToString());
                }
                w1.Close();
                MessageBox.Show("A lista " + imgListNameTextBox.Text + ".lst foi salva com sucesso no diretório\n" + path);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
