/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

namespace TestPlatform
{
    using System;
    using System.Windows.Forms;
    using System.Globalization;
    using System.Threading;
    using TestPlatform.Views;

    public static class MainClass
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("pt-BR");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormMain application = new FormMain();
            FileManipulation.GlobalFormMain = application;
            Application.Run(application);
        }
    }
}
