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
            CultureInfo newCultureInfo = new System.Globalization.CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = newCultureInfo;
            Thread.CurrentThread.CurrentUICulture = newCultureInfo;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormMain application = new FormMain();
            Global.GlobalFormMain = application;
            Application.Run(application);
        }
    }
}
