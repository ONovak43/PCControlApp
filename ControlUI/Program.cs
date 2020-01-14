using System;
using System.Windows.Forms;

namespace ControlUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the text connection
            ControlLibrary.GlobalConfig.InitializeConnections();

            Application.Run(new ComputerViewForm());
        }
    }
}
