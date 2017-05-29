/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.IO;
using System.Windows.Forms;

namespace TestPlatform
{
    static class MainClass
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
