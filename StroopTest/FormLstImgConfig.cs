using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

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
    }
}
