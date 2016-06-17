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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
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
                    imgListView.Items.Add(item);
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e) // remove os itens selecionados
        {
            try
            {
                while (imgListView.SelectedItems.Count > 0) // para a lista de itens selecionados
                {
                    ListViewItem item = imgListView.SelectedItems[0]; // item recebe o primeiro da lista

                    for (int i = item.Index + 1; i < imgListView.Items.Count; i++) { imgListView.Items[i].ImageIndex--; } // ajuste dos índices

                    imgListView.Items.Remove(item); // remove item da ListView

                    Image img = imgsList.Images[item.ImageIndex];
                    img.Dispose();
                    
                    imgsList.Images.RemoveAt(item.ImageIndex); // remove item da ImagesList
                    imgsDirList.RemoveAt(item.ImageIndex); // remove diretorio do item na lista de diretorios
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) // Salva
        {
            try
            {
                if(string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    throw new Exception("Nome do arquivo deve ser preenchido");
                }
                else
                {
                    if ((MessageBox.Show("Deseja salvar o arquivo " + textBox1.Text + ".lst?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK))
                    {
                        if (File.Exists(path + textBox1.Text + ".lst"))
                        {
                            DialogResult d1 = MessageBox.Show("Uma lista com este nome já existe.\nDeseja sobrescrevê-la?", "", MessageBoxButtons.OKCancel);
                            if (d1 == DialogResult.Cancel)
                            {
                                throw new Exception("A lista de imagens não será salva!");
                            }
                        }

                        StreamWriter w1 = new StreamWriter(path + textBox1.Text + ".lst");
                        for (int i = 0; i < imgsDirList.Count; i++)
                        {
                            w1.WriteLine(imgsDirList[i]);
                        }
                        w1.Close();
                        
                        MessageBox.Show("A lista " + textBox1.Text + ".lst foi salva com sucesso no diretório\n" + path);
                    }
                    else
                    {
                        throw new Exception("A lista de imagens não foi salva!");
                    }
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
