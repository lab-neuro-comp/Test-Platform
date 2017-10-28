using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TestPlatform.Models;
using System.IO;
using System.Globalization;
using System.Resources;

namespace TestPlatform.Views.ReactionPages
{
    public partial class ReactionResultUserControl : UserControl
    {
        private string path = Global.reactionTestFilesPath + Global.resultsFolderName;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public ReactionResultUserControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            string[] filePaths = null;

            string[] headers = ReactionTest.HeaderOutputFileText.Split('\t');

            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.AutoResizeColumns();
            foreach (var columnName in headers)
            {
                dataGridView1.Columns.Add(columnName, columnName); // Add header to table
                this.dataGridView1.Columns[columnName].Frozen = false;
            }

            if (Directory.Exists(path)) // Preenche comboBox com arquivos do tipo .txt no diretório dado
            {
                filePaths = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    fileNameBox.Items.Add(Path.GetFileNameWithoutExtension(filePaths[i]));
                }
            }
            else
            {
                MessageBox.Show("{0}" + LocRM.GetString("invalidPath", currentCulture), path);
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void fileNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            string[] line;
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
                                if (Validations.isHexPattern(cellArray[j]))
                                {
                                    dataGridView1.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml(cellArray[j]);
                                }
                            }
                        }
                    }
                }

                dataGridView1.AutoSize = false;
                dataGridView1.ScrollBars = ScrollBars.Both;
                dataGridView1.AutoResizeColumns();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void csvExportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string[] lines;

            saveFileDialog1.Filter = "Excel CSV (.csv)|*.csv"; // salva em .csvs
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = fileNameBox.Text;

            try
            {
                // checks if there are any results selected
                if (!(fileNameBox.SelectedIndex == -1))
                {
                    lines = ReactionProgram.readDataFile(path + "/" + fileNameBox.SelectedItem.ToString() + ".txt");
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK) // abre caixa para salvar
                    {
                        using (TextWriter tw = new StreamWriter(saveFileDialog1.FileName))
                        {
                            tw.WriteLine(ReactionTest.HeaderOutputFileText);
                            for (int i = 0; i < lines.Length; i++)
                            {
                                tw.WriteLine(lines[i]); // escreve linhas no novo arquivo
                            }
                            tw.Close();
                            MessageBox.Show("Arquivo exportado com sucesso!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show(LocRM.GetString("selectDataFile", currentCulture));
                }                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
