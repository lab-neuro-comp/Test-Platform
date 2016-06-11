/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormLstImgConfig : Form
    {
        private List<string> imgsDirList = new List<string>();
        private ImageList imgsList = new ImageList();
        private string path;

        public FormLstImgConfig(string imagesFolderPath)
        {
            path = imagesFolderPath;
            InitializeComponent();
        }

        private void FormLstImgConfig_Load(object sender, EventArgs e)
        {
            InitializeOpenFileDialog();
        }

        private void InitializeOpenFileDialog()
        {
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPeG;*.GIF;*.PNG|" + "All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Navegador Imagens";

            imgsList.ColorDepth = ColorDepth.Depth16Bit;

        }

        private void selectFiles(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                imgListView.Clear();

                foreach (string file in openFileDialog1.FileNames)
                {
                    try
                    {
                        imgsDirList.Add(Path.GetFullPath(file));
                        imgsList.Images.Add(Image.FromFile(file));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não pode apresentar a imagem: " + file.Substring(file.LastIndexOf('\\'))
                            + ". Você pode não ter permissão para ler este arquivo ou ele pode estar corrompido.\n" + ex.Message);
                    }
                }
                
                imgListView.Alignment = ListViewAlignment.Default;
                imgsList.ImageSize = new Size(256, 256);
                imgListView.LargeImageList = imgsList;

                for (int j = 0; j < this.imgsList.Images.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j;
                    item.Text = "Texto que antecede esta Imagem";
                    imgListView.Items.Add(item);
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            while (imgListView.SelectedItems.Count > 0)
            {
                ListViewItem item = imgListView.SelectedItems[0];

                for (int i = item.Index + 1; i < imgListView.Items.Count; i++) { imgListView.Items[i].ImageIndex--; } // Ajuste de índices

                imgListView.Items.Remove(item);

                Image img = imgsList.Images[item.ImageIndex];
                imgsList.Images.RemoveAt(item.ImageIndex);
                imgsDirList.RemoveAt(item.ImageIndex);
                img.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    throw new Exception("Nome do(s) arquivo(s) deve ser preenchido");
                }
                else
                {
                    if ((MessageBox.Show("Deseja salvar o arquivo " + textBox1.Text + ".lst?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK))
                    {
                        if (File.Exists(path + textBox1.Text + ".lst"))
                        {
                            DialogResult dialogResult = MessageBox.Show("Uma lista com este nome já existe.\nDeseja sobrescrevê-la?", "", MessageBoxButtons.OKCancel);
                            if (dialogResult == DialogResult.Cancel)
                            {
                                throw new Exception("A lista não será salva!");
                            }
                        }

                        StreamWriter wr = new StreamWriter(path + textBox1.Text + ".lst");

                        for (int i = 0; i < imgsDirList.Count; i++)
                        {
                            wr.WriteLine(imgsDirList[i]);
                        }
                        
                        wr.Close();
                        MessageBox.Show("A lista " + textBox1.Text + ".lst foi salva com sucesso no diretório\n" + path);
                    }
                    else
                    {
                        throw new Exception("A lista de cores não foi salva!");
                    }
                }
                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
