using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TestPlatform.Models;
using TestPlatform.Views;
using TestPlatform.Controllers;
using System.Globalization;
using System.Resources;
using System.Collections.Generic;

namespace TestPlatform
{
    public partial class FormImgConfig : UserControl
    {
        private ImageList imgsList = new ImageList();
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        private StrList imageList;
        private static int IMAGE = 0;
        private bool isListNameValid = false;

        public bool isValid()
        {
            return isListNameValid;
        }

        public FormImgConfig(string imgListEdit)
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            imgPathDataGridView.AllowDrop = true;
            imgPathDataGridView.RowTemplate.MinimumHeight = 120;
            
            labelEmpty.Visible = false;
            if (imgListEdit != "false")
            {
                openImgList();
            }
        }

        private void openImgList()
        {
                FormDefine defineFilePath = defineFilePath = new FormDefine(LocRM.GetString("imageList", currentCulture), Global.testFilesPath + Global.listFolderName, "dir","_image",true, false);
                var result = defineFilePath.ShowDialog();
                
                if (result == DialogResult.OK)
                {
                    string listName = defineFilePath.ReturnValue;
                    isListNameValid = true;
                    if (listName == "")
                    {
                        isListNameValid = false;
                        return;
                    }
                    imgListNameTextBox.Text = listName; // removes the _img identification from file while editing (when its saved it is always added again)
                    imageList = new StrList(listName, IMAGE);
                    string[] filePaths = imageList.ListContent.ToArray();
                    readImagesIntoDGV(filePaths, imgPathDataGridView);                  

                }
         
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openImagesDirectory();
        }

        // opens directory with images to be choosen by the list creator
        private void openImagesDirectory()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPeG;*.GIF;*.PNG|" + "All files (*.*)|*.*";
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] filePaths = openFileDialog.FileNames;
                    readImagesIntoDGV(filePaths, imgPathDataGridView);
                    selectedImageIntoPictureBox();
                }
            }
            catch (NullReferenceException)
            {
            }
            catch (FileLoadException ex)
            {
                throw new Exception(LocRM.GetString("imageFileError", currentCulture) + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void readImagesIntoDGV(string[] directory, DataGridView imagesDataGridView)
        {
            DataGridView dgv = imagesDataGridView;
            try
            {
                foreach (string file in directory)
                {
                    Image image = Image.FromFile(file);
                    dgv.Rows.Add(Path.GetFileNameWithoutExtension(file), image, file);
                    ((DataGridViewImageColumn)dgv.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    numberFiles.Text = imgPathDataGridView.RowCount.ToString();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // delete button click - deletes row from not empty dgv; refresh view
        private void deleteRow_Click(object sender, EventArgs e)
        {
            DataGridView dgv = imgPathDataGridView;
            DGVManipulation.DeleteDGVRow(dgv);
            numberFiles.Text = imgPathDataGridView.RowCount.ToString();
            if(imgPathDataGridView.RowCount == 0)
            {
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

        // pictureBox receives clicked rows img
        private void selectedImageIntoPictureBox()
        {
            if(imgPathDataGridView.CurrentRow != null)
            {
                pictureBox.Image = Image.FromFile(imgPathDataGridView.CurrentRow.Cells[2].Value.ToString());
            }
            
        }
        
        // button up click - moves selected row Upper
        private void btnUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = imgPathDataGridView;
            try
            {
                DGVManipulation.MoveDGVRowUp(dgv);
                if (imgPathDataGridView.CurrentRow.Cells.Count > 0)
                {
                    pictureBox.Image = Image.FromFile(dgv.CurrentRow.Cells[2].Value.ToString());
                }
            }
            catch { }
        }

        // button up click - moves selected row Down
        private void btnDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = imgPathDataGridView;
            try
            {
                DGVManipulation.MoveDGVRowDown(dgv);
                pictureBox.Image = Image.FromFile(dgv.CurrentRow.Cells[2].Value.ToString());
            }
            catch { }
        }

        // saves list into directory copying files inside lst directory
        private void saveButton_Click(object sender, EventArgs e)
        {
            bool hasValidFiles = true;
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                try
                {
                    List<string> content = new List<string>();
                    for (int i = 0; i < imgPathDataGridView.RowCount; i++)
                    {
                        if (!File.Exists(imgPathDataGridView.Rows[i].Cells[2].Value.ToString()))
                        {
                            hasValidFiles = false;
                        }
                        content.Add(imgPathDataGridView.Rows[i].Cells[2].Value.ToString());
                    }
                    imageList = new StrList(content, imgListNameTextBox.Text, "_image");

                    if (imageList.saveContent(hasValidFiles))
                    {
                        MessageBox.Show(LocRM.GetString("list", currentCulture) + imgListNameTextBox.Text + "_image" + LocRM.GetString("listSaveSuccess", currentCulture));
                        this.Parent.Controls.Remove(this);
                        ListController.recoverEditingProgram(imgListNameTextBox.Text);
                    }
                    else
                    {
                        MessageBox.Show(LocRM.GetString("list", currentCulture) + imgListNameTextBox.Text + "_image'" + LocRM.GetString("notCreated", currentCulture));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }               
            else
            {
                MessageBox.Show(LocRM.GetString("fieldNotRight", currentCulture));
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DataGridView dgv = imgPathDataGridView;
            AutoValidate = AutoValidate.Disable;
            try
            {
                DGVManipulation.CloseFormListNotEmpty(dgv);
                this.Parent.Controls.Remove(this);
                ListController.recoverEditingProgram(LocRM.GetString("open", currentCulture));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Parent.Controls.Remove(this);
            }
        }

        private void imgPathDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Left)
            {
                DataGridView dgv = imgPathDataGridView;
                try
                {
                    DGVManipulation.MoveDGVRowUp(dgv);
                }
                catch { }
            }
            if (e.Control && e.KeyCode == Keys.Right)
            {
                DataGridView dgv = imgPathDataGridView;
                try
                {
                    DGVManipulation.MoveDGVRowDown(dgv);
                }
                catch { }
            }
        }

        private void imgPathDataGridView_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            DataGridView dgv = imgPathDataGridView;
            if (dgv.RowCount <= 1)
            {
                pictureBox.Image = null;
                pictureBox.Refresh();
            }
        }

        private void listName_Validating(object sender,
                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidListName(imgListNameTextBox.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.imgListNameTextBox, errorMsg);
            }
        }

        private void listName_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.imgListNameTextBox, "");
        }

        public bool ValidListName(string name, out string errorMessage)
        {
            if (Validations.isEmpty(name))
            {
                errorMessage = LocRM.GetString("emptyListName", currentCulture);
                return false;
            }
            if (!Validations.isAlphanumeric(name))
            {
                errorMessage = LocRM.GetString("listNotAlphanumeric", currentCulture);
                return false;
            }
            errorMessage = "";
            return true;
        }

        private void listLength_Validated(object sender, System.EventArgs e)
        {
            labelEmpty.Visible = false;
        }

        public bool ValidListLength(int number, out string errorMessage)
        {
            if (number == 0)
            {
                errorMessage = LocRM.GetString("emptyList", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void listLength_Validating(object sender,
                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidListLength(imgPathDataGridView.RowCount, out errorMsg))
            {
                e.Cancel = true;
                labelEmpty.Text = errorMsg;
                labelEmpty.Visible = true;
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("imageConfigInstructions", currentCulture));
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
