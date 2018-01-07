using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.ListBox;
using System.Resources;
using System.Globalization;

namespace TestPlatform.Views.ListsPages
{
    public partial class ListManagment : UserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        string listPath = Global.testFilesPath + Global.listFolderName, suffix;
        string[] filePaths;
        public ListManagment(string suffix)
        {
            InitializeComponent();
            this.suffix = suffix;
            loadExistingList();
        }

        private void existingList_Click(object sender, EventArgs e)
        {
            if (suffix == "_audio" || suffix == "_image")
            {
                int index = existingList.SelectedIndex;
                existingList.ClearSelected();
                if (index != -1)
                {
                    string selected = existingList.Items[index].ToString();
                    if (selected.Contains("   "))
                    {
                        while (existingList.Items[index].ToString().Contains("   "))
                        {
                            index--;
                        }
                    }
                    do
                    {
                        existingList.SetSelected(index++, true);
                    } while (index < existingList.Items.Count && existingList.Items[index].ToString().Contains("   "));
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void deletingList_Click(object sender, EventArgs e)
        {
            if (suffix == "_audio" || suffix == "_image")
            {
                int index = deletingList.SelectedIndex;
                deletingList.ClearSelected();
                if (index != -1)
                {
                    string selected = deletingList.Items[index].ToString();
                    if (selected.Contains("   "))
                    {
                        while (deletingList.Items[index].ToString().Contains("   "))
                        {
                            index--;
                        }
                    }
                    do
                    {
                        deletingList.SetSelected(index++, true);
                    } while (index < deletingList.Items.Count && deletingList.Items[index].ToString().Contains("   "));
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void toDelete_Click(object sender, EventArgs e)
        {
            SelectedObjectCollection selected = existingList.SelectedItems;
            while(selected.Count != 0)
            {
                deletingList.Items.Add(selected[0].ToString());
                existingList.Items.Remove(selected[0]);
            }
        }

        private void toExisting_Click(object sender, EventArgs e)
        {
            SelectedObjectCollection selected = deletingList.SelectedItems;
            while (selected.Count != 0)
            {
                existingList.Items.Add(selected[0].ToString());
                deletingList.Items.Remove(selected[0]);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (suffix == "_audio" || suffix == "_image")
            {
                if (deletingList.Items.Count > 0)
                {
                    int count = 0;
                    string currentDirectory = "";
                    do
                    {
                        if (!deletingList.Items[count].ToString().Contains("   "))
                        {
                            currentDirectory = deletingList.Items[count++].ToString() + suffix;
                        }
                        else
                        {
                            if (File.Exists(listPath + currentDirectory + "\\" + deletingList.Items[count].ToString().Trim()))
                            {
                                File.Delete(listPath + currentDirectory + "\\" + deletingList.Items[count].ToString().Trim());
                            }
                            else
                            {
                                /*do nothing*/
                            }
                            count++;
                        }
                    } while (count < deletingList.Items.Count);
                    count = 0;
                    do
                    {
                        if (Directory.Exists(listPath + deletingList.Items[count].ToString() + suffix))
                        {
                            Directory.Delete(listPath + deletingList.Items[count].ToString() + suffix);
                        }
                        count++;
                    } while (count < deletingList.Items.Count);

                }
            }
            else
            {
                for (int count = 0; count < deletingList.Items.Count; count++)
                {
                    try
                    {
                        File.Delete(listPath + deletingList.Items[count].ToString() + ".lst");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            deletingList.Items.Clear();
            MessageBox.Show(LocRM.GetString("listsDeleted", currentCulture));
        }

        private void loadExistingList()
        {
            if (suffix == "_audio" || suffix == "_image")
            {
                if (Directory.Exists(listPath))
                {
                    filePaths = Directory.GetDirectories(listPath, ("*" + suffix));
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        var option = Path.GetFileName(filePaths[i]).Split('_');
                        existingList.Items.Add(option[0]);
                        string[] files = Directory.GetFiles(filePaths[i]);
                        for (int j = 0; j < files.Length; j++)
                        {
                            string fileName = String.Format("   {0}", Path.GetFileName(files[j]));
                            existingList.Items.Add(fileName);
                        }
                    }
                }
            }
            else if (suffix == "_words_color")
            {
                filePaths = Directory.GetFiles(listPath, ("*_words.lst"), SearchOption.AllDirectories);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    var option = Path.GetFileNameWithoutExtension(filePaths[i]).Split('_');
                    existingList.Items.Add(option[0] + "_words");
                    if (File.Exists(listPath + option[0] + "_color.lst"))
                    {
                        existingList.Items.Add(option[0] + "_color");
                    }
                }

                filePaths = Directory.GetFiles(listPath, ("*_color.lst"), SearchOption.AllDirectories);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    var option = Path.GetFileNameWithoutExtension(filePaths[i]).Split('_');
                    if (!existingList.Items.Contains(option[0] + "_color"))
                    {
                        existingList.Items.Add(option[0] + "_color");
                    }
                }
            }
            else
            {
                MessageBox.Show(new ArgumentException().ToString());
                this.Parent.Controls.Remove(this);
            }
        }
        
    }
}
