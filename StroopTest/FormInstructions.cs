using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormInstructions : Form
    {
        public FormInstructions(string fileInstructionPath)
        {
            InitializeComponent();

            string instructionsText = "Para utilizar o software, execute-o uma primeira vez.\nA partir da primeira execução será criado o diretório de data no mesmo diretório em que o programa executa.\n\nDentro da pasta 'data' estão as subpastas:\n\n- 'prg' onde devem ser dispostos os programas a serem executados;\n- 'lst' conterá as listas (de imagens, cores ou palavras) a serem utilizadas pelo programa;\n- 'results' armazena os resultados obtidos após a execução do programa.\n\n\nPara escrever um novo programa, escreva os parâmetro a seguir linearmente em um editor de texto. Tais parâmetros devem ser separados por espaçamentos tab; Note que o nome do programa deve ser igual ao nome do arquivo (sem terminação '.prg');\n\nParâmetros:\n(1) Nome do Programa\n(2) Numero de Exposicoes\n(3) Tempo de Exposicao\n(4) Exposicao Aleatoria\n(5) Tempo de Intervalo\n(6) Tempo de Intervalo Aleatorio(nao implementado - manter false)\n(7) Lista de Palavras(nome da lista - deve estar no diretorio Stroop criado pelo programa)\n(8) ListaCores\n(9) Cor de Fundo\n(10) Captura de Áudio(não implementado - manter false)\n(11) Mostrar Legenda\n(12) Lugar Legenda\n(13) Cor Legenda\n(14) Tipo Exposicao\n(15) Lista Imagem\n(16) Ponto de Fixacao";

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
