/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Media;
using TestPlatform.Models;
using TestPlatform.Views;
using TestPlatform.Controllers;
using System.Resources;
using System.Globalization;

namespace TestPlatform
{
    public partial class FormShowData : UserControl
    {
        private StroopProgram program = new StroopProgram();
        private string path = Global.stroopTestFilesPath + Global.resultsFolderName;
        private SoundPlayer player = new SoundPlayer();
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public FormShowData()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            string[] filePaths = null;

            string localizedHeaders = LocRM.GetString("stroopResultHeader", currentCulture);
            string[] separators = { @"\t" };
            string[] headers = localizedHeaders.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var columnName in headers)
            {
                dataGridView1.Columns.Add(columnName, columnName); // Configura Cabeçalho na tabela
            }

            if (Directory.Exists(path)) // Preenche comboBox com arquivos do tipo .txt no diretório dado
            {
                filePaths = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    comboBox1.Items.Add(Path.GetFileNameWithoutExtension(filePaths[i]));
                }
            }
            else
            {
                MessageBox.Show("{0}"+ LocRM.GetString("invalidPath",currentCulture), path);
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
                            for (int j = 5; j < cellArray.Length; j++)
                            {
                                if (Validations.isHexPattern(cellArray[j]))
                                {
                                    dataGridView1.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml(cellArray[j]);
                                }
                            }
                        }
                        else if (cellArray.Length == (dataGridView1.ColumnCount - 1))
                        {
                            var index = line[i].IndexOf("\t");
                            if (index >= 0)
                            {
                                line[i] = line[i].Insert(index + "\t".Length, "-\t");
                            }
                            cellArray = line[i].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            dataGridView1.Rows.Add(cellArray);
                            for (int j = 5; j < cellArray.Length; j++)
                            {

                                if (Validations.isHexPattern(cellArray[j]))
                                {
                                    dataGridView1.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml(cellArray[j]);
                                }
                            }
                        }
                    }
                }
                // fills audio data grid view with .wav files in directory in case there are any matching the patter on combobox
                if (Directory.Exists(path)) 
                {
                    if(audioPathDataGridView.RowCount > 0)
                    {
                        audioPathDataGridView.Rows.Clear();
                        audioPathDataGridView.Refresh();
                    }
                    
                    filePaths = Directory.GetFiles(path, "audio_" + comboBox1.SelectedItem.ToString()+"*", SearchOption.AllDirectories);
                    DGVManipulation.ReadStringListIntoDGV(filePaths, audioPathDataGridView);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void exportCVSButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string[] lines;

            // salva file on .csv format
            saveFileDialog1.Filter = "Excel CSV (.csv)|*.csv"; 
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = comboBox1.Text;

            // only saves if there is one selected result to save
            if (!(comboBox1.SelectedIndex == -1))
            {
                lines = StroopProgram.readDataFile(path + "/" + comboBox1.SelectedItem.ToString() + ".txt");
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) // abre caixa para salvar
                {
                    using (TextWriter tw = new StreamWriter(saveFileDialog1.FileName))
                    {
                        tw.WriteLine(LocRM.GetString("stroopResultHeader", currentCulture));
                        for (int i = 0; i < lines.Length; i++)
                        {
                            // writing lines on new file
                            tw.WriteLine(lines[i]); 
                        }
                        tw.Close();
                        MessageBox.Show(LocRM.GetString("exportedFile", currentCulture));
                    }
                }
                
            }
            else
            {
                MessageBox.Show(LocRM.GetString("selectDataFile", currentCulture));
            } 
                       
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("showDataInstructions", currentCulture));
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
