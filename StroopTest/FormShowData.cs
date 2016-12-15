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

namespace StroopTest
{
    public partial class FormShowData : Form
    {
        private StroopProgram program = new StroopProgram();
        private string path;
        private SoundPlayer Player = new SoundPlayer();
        private string hexPattern = "^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$";
        private string instructionsText = HelpData.ShowDataInstructions;
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
            string[] line;
            try
            {
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

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(instructionsText);
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void playCurrentAudio()
        {
            string[] filePath;
            string program, user, date,hour,new_hour,new_date,archive_name;
            program = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            user = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            date = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            new_date = date[0].ToString() + date[1].ToString() + "."+ date[3].ToString() + date[4].ToString();
            hour = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            new_hour = hour[0].ToString() + hour[1].ToString() + "h" + hour[3].ToString() + hour[4].ToString() + "." + hour[6].ToString() + hour[7].ToString();
            archive_name = "audio_"+user+"_"+program + "_" + new_date + "_" + new_hour+".wav";
            filePath = Directory.GetFiles(path, archive_name, SearchOption.AllDirectories);
            Player.SoundLocation = filePath[0];
            Player.Play();
        }
        private void audiobutton_Click(object sender, EventArgs e)
        {
            playCurrentAudio();
        }

    }
}
