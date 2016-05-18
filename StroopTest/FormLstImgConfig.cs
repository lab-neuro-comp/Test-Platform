/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormLstImgConfig : Form
    {
        
        private FolderBrowserDialog folderBrowserDialog1;
        DirectoryInfo dir;
        private string folderName;

        public FormLstImgConfig(string imagesFolderPath)
        {
            InitializeComponent();
        }
        
        private void FormLstImgConfig_Load(object sender, EventArgs e)
        {

            folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
            }

            dir = new DirectoryInfo(folderName);

            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    this.imageList1.Images.Add(Image.FromFile(file.FullName));
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }

            this.imgListView.View = View.LargeIcon;
            this.imageList1.ImageSize = new System.Drawing.Size(128, 128);
            this.imgListView.LargeImageList = this.imageList1;
            this.imgListView.Alignment = ListViewAlignment.Default;

            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                imgListView.Items.Add(item);
            }
        }

        private void imgListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void listItensFromFolder(string path)
        {
            DirectoryInfo d = new DirectoryInfo(@path);//Assuming Test is your Folder
            //var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
            //var files = GetFilesFrom(searchFolder, filters, false);
            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files
            string str = "";
            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;
            }
        }

    }
}
