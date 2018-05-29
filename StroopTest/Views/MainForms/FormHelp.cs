/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TestPlatform.Models;

namespace TestPlatform
{
    public partial class FormInstructions : Form
    {
        public FormInstructions(string instructionsText)
        {
            InitializeComponent();
            helpBrowser.DocumentText = instructionsText;
        }

        public FormInstructions(string instructionsText, string[] lines)
        {
            InitializeComponent();
            if (lines.Length != 0)
            {
                instructionsText = "";
                foreach (string line in lines)
                {
                    instructionsText = instructionsText + "\n" + line;
                }
            }
            helpBrowser.DocumentText = instructionsText;
        }

        private void FormInstructions_Resize(object sender, EventArgs e)
        {
            Size newSize = this.Size;
            newSize.Height -= 46; //making sure that content will not be hidden due over size
            newSize.Width -= 28; //making sure that content will not be hidden due over size
            helpBrowser.Size = newSize;
        }
    }
}
