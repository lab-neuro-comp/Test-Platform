/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormShowData : Form
    {
        private StroopProgram program = new StroopProgram();
        private string path;
        private string hexPattern = "^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$";

        public FormShowData(string dataFolderPath)
        {
            InitializeComponent();

            string[] filePaths = null;
            path = dataFolderPath;

            string[] headers = program.HeaderOutputFile.Split('\t');
            foreach (var columnName in headers)
            {
                dataGridView1.Columns.Add(columnName, columnName); // Configura Cabeçalho na tabela
            }

            if (Directory.Exists(dataFolderPath)) // Preenche comboBox com arquivos do tipo .txt no diretório dado
            {
                filePaths = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    comboBox1.Items.Add(Path.GetFileNameWithoutExtension(filePaths[i]));
                }
            }
            else
            {
                Console.WriteLine("{0} é um caminho inválido!.", dataFolderPath);
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            string[] lines;
            try
            {
                lines = StroopProgram.readDataFile(path + "/" + comboBox1.SelectedItem.ToString() + ".txt");
                if (lines.Count() > 0)
                {
                    for(int i = 0; i < lines.Count(); i++)
                    {
                        string[] cellArray = lines[i].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                        if (cellArray.Length == dataGridView1.Columns.Count) { dataGridView1.Rows.Add(cellArray); }
                        
                        if (Regex.IsMatch(cellArray[cellArray.Length - 2], hexPattern))
                        {
                            dataGridView1.Rows[i].Cells[dataGridView1.Columns.Count - 1].Style.BackColor = ColorTranslator.FromHtml(cellArray[cellArray.Length - 1]);
                        }
                    }
                    /*
                    foreach (var cellValues in lines) // Se o item selecionado muda, atualiza-se a tabela de dados de acordo com o selecionado
                    {
                        var cellArray = cellValues.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (cellArray.Length == dataGridView1.Columns.Count)
                            dataGridView1.Rows.Add(cellArray);
                    }
                    */
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string[] lines;

            saveFileDialog1.Filter = "Excel CSV (.csv)|*.csv"; // salva em .csvs
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = comboBox1.Text;

            try
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    throw new Exception("Selecione um arquivo de dados!");
                }
                
                lines = StroopProgram.readDataFile(path + "/" + comboBox1.SelectedItem.ToString() + ".txt");
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) // abre caixa para salvar
                {
                    using (TextWriter tw = new StreamWriter(saveFileDialog1.FileName))
                    {
                        tw.WriteLine(program.HeaderOutputFile);
                        for (int i = 0; i < lines.Length; i++)
                        {
                            tw.WriteLine(lines[i]); // escreve linhas no novo arquivo
                        }
                        tw.Close();
                        MessageBox.Show("Arquivo exportado com sucesso!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
