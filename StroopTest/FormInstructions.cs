/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System.IO;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormInstructions : Form
    {
        public FormInstructions(string fileInstructionPath)
        {
            InitializeComponent();

            string instructionsText = "Execute um teste com o atalho 'Ctrl + R'\nDefina o programa do teste com o atalho 'Ctrl + D'\nPara utilizar o software, execute-o uma primeira vez.\nA partir da primeira execução será criado o diretório\n'StroopTestFiles'\nno mesmo diretório em que o programa executa.\nTal diretório contém os subdiretórios:\n'data' - com os resultados das execuções;\n'prg' - contém os arquivos .prg onde estão escitos os programas;\n'lst' - contém os arquivos .lst onde estão escritas as listas";

            if (new FileInfo(fileInstructionPath).Length != 0)
            {
                string[] lines = File.ReadAllLines(fileInstructionPath);
                instructionsText = "";
                foreach (string line in lines)
                {
                    instructionsText = instructionsText + "\n" + line;
                }
            }
            
            richTextBox1.Text = instructionsText;
        }
    }
}
