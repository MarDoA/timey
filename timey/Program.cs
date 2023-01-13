using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace timey
{
    internal static class Program
    {
        public static bool openAdminForm { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            openAdminForm = false;
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            if (openAdminForm)
            {
                Application.Run(new Form2());
            }
        }
    }    
}