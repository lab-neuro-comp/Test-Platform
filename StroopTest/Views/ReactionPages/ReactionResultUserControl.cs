﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Models;
using System.IO;
using System.Text.RegularExpressions;
using StroopTest.Models;

namespace TestPlatform.Views.ReactionPages
{
    public partial class ReactionResultUserControl : UserControl
    {
        private string path;

        public ReactionResultUserControl(string dataFolderPath)
        {
            InitializeComponent();

            Location = new Point(395, 50);
            string[] filePaths = null;
            path = dataFolderPath;

            string[] headers = ReactionTest.HeaderOutputFileText.Split('\t');
            foreach (var columnName in headers)
            {
                dataGridView1.Columns.Add(columnName, columnName); // Configura Cabeçalho na tabela
            }

            if (Directory.Exists(dataFolderPath)) // Preenche comboBox com arquivos do tipo .txt no diretório dado
            {
                filePaths = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    fileNameBox.Items.Add(Path.GetFileNameWithoutExtension(filePaths[i]));
                }
            }
            else
            {
                Console.WriteLine("{0} é um caminho inválido!.", dataFolderPath);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void fileNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            string[] line;
            string[] filePaths = null;
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                line = Program.readDataFile(path + "/" + fileNameBox.SelectedItem.ToString() + ".txt");
                if (line.Count() > 0)
                {
                    for (int i = 0; i < line.Count(); i++)
                    {
                        string[] cellArray = line[i].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (cellArray.Length == dataGridView1.Columns.Count)
                        {
                            dataGridView1.Rows.Add(cellArray);
                            for (int j = 0; j < cellArray.Length; j++)
                            {
                                if (Validations.allHexPattern(cellArray))
                                {
                                    dataGridView1.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml(cellArray[j]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}