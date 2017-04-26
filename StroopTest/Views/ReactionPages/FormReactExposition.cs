using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestPlatform.Models;

namespace TestPlatform.Views
{
    public partial class FormReactExposition : Form
    {
        ReactionProgram programInUse = new ReactionProgram();
        private static float elapsedTime;               
        private string path;                           
        private List<string> outputContent;            
        private string outputDataPath;                
        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        private string startTime;
        private string outputFile;


        public FormReactExposition(string defaultPath)
        {
            path = defaultPath;
            outputDataPath = defaultPath + "/data";
            startTime = hour + "_" + minutes + "_" + seconds;
            InitializeComponent();
        }
    }
}
