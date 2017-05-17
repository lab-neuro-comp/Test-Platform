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
using System.Media;
using StroopTest.Models;
using StroopTest.Views;
using StroopTest.Controllers;

namespace StroopTest
{
    public partial class FormShowData : UserControl
    {
        private StroopProgram program = new StroopProgram();
        private string path;
        private string hexPattern = "^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$";
        private string instructionsText = HelpData.ShowDataInstructions;
        private SoundPlayer player = new SoundPlayer();

        public FormShowData(string dataFolderPath)
        {
            InitializeComponent();

            Location = new Point(395, 50);
            string[] filePaths = null;
            path = dataFolderPath;

            string[] headers = program.HeaderOutputFileText.Split('\t');
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
            string[] line;
            string[] filePaths = null;
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                line = StroopProgram.readDataFile(path + "/" + comboBox1.SelectedItem.ToString() + ".txt");
                if (line.Count() > 0)
                {
                    for(int i = 0; i < line.Count(); i++)
                    {
                        string[] cellArray = line[i].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (cellArray.Length == dataGridView1.Columns.Count) {
                            dataGridView1.Rows.Add(cellArray);
                            for (int j = 0; j < cellArray.Length; j++)
                            {
                                if (Regex.IsMatch(cellArray[j], hexPattern))
                                {
                                    dataGridView1.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml(cellArray[j]);
                                }
                            }
                        }
                    }
                }
                if (Directory.Exists(path)) // Preenche dgv com arquivos do tipo .wav no diretório dado que possua o padrao da comboBox
                {
                    audioPathDataGridView.Rows.Clear();
                    audioPathDataGridView.Refresh();
                    filePaths = Directory.GetFiles(path, "audio_" + comboBox1.SelectedItem.ToString()+"*", SearchOption.AllDirectories);
                    DGVManipulation.readStringListIntoDGV(filePaths, audioPathDataGridView);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void exportCVSButton_Click(object sender, EventArgs e)
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
                        tw.WriteLine(program.HeaderOutputFileText);
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

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(instructionsText);
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void audioPathDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            playCurrentAudio();
        }

        private void playAudioButton_Click(object sender, EventArgs e)
        {
            playCurrentAudio();
        }

        private void playCurrentAudio()
        {
            player.SoundLocation = audioPathDataGridView.CurrentRow.Cells[1].Value.ToString();
            player.Play();
        }

        private void stopAudio_Click(object sender, EventArgs e)
        {
            player.Stop();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Parent.Controls.Remove(this);
        }
    }
}
