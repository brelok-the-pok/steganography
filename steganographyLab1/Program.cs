using System;
using System.Windows.Forms;

namespace steganographyLab1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {
            string desktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm(desktopDirectory));
            Application.Run(new Form3());

        }
    }
}
