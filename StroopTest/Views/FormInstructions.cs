/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.IO;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormInstructions : Form
    {
        public FormInstructions(string instructionsText)
        {
            InitializeComponent();
            webBrowser1.DocumentText = instructionsText;
        }

        public FormInstructions(string instructionsText, string fileInstructionPath)
        {
            InitializeComponent();
            if (new FileInfo(fileInstructionPath).Length != 0)
            {
                string[] lines = File.ReadAllLines(fileInstructionPath);
                instructionsText = "";
                foreach (string line in lines)
                {
                    instructionsText = instructionsText + "\n" + line;
                }
            }
            webBrowser1.DocumentText = instructionsText;
        }
        
    }
}
