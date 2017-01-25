using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StroopTest.Controllers
{
    class ExpositionController
    {
        public static string[] shuffleArray(string[] array, int expectedLength, int rndSeed) // randomiza Vetor - parâmetros: vetor / tamanho esperado do vetor randomizado
        {
            List<string> randomArray = new List<string>();
            Random rnd = new Random(DateTime.Now.Millisecond + expectedLength + rndSeed);

            if (expectedLength == array.Count()) // se pretende-se manter o mesmo tamanho do vetor, não há repetições
            {
                randomArray = array.OrderBy(x => rnd.Next()).ToList();
            }
            else
            {
                for (int i = 0; i < expectedLength; i++) // se não o vetor aleatório será preenchido com valores aleatórios do original, podendo haver repetições
                {
                    randomArray.Add(array[rnd.Next(array.Length)]);
                }
            }
            return randomArray.ToArray();
        }
    }
}
