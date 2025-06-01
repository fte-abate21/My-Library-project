using System;
using System.Windows.Forms;

namespace MyLibrary
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Database.InitializeDatabase();  

            Application.Run(new LoginForm()); 
        }
    }
}
