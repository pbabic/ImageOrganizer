using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOrganizer
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            if (!((bool)Properties.Settings.Default["agreement"]) && MessageBox.Show("This application is provided AS IS. Great effort is invested searching for any application malfunctioning and fixing them.\n\n" +
                            "I do not accept any responsibility for eventual errors or loss of files that could happen using this application.\n\nClicking Ok you are agreeing to these terms.\n\n",
                            "DISCLAIMER", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                return;
            }
            
            Properties.Settings.Default["agreement"] = true;
            Properties.Settings.Default.Save();

            Logger.Setup();
            AppDomain.CurrentDomain.FirstChanceException += FirstChanceHandler;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());            
        }

        static void FirstChanceHandler(object source, FirstChanceExceptionEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logger.Error(e.Exception);
        }
    }
}
