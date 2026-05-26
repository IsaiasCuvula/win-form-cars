using Cars.Database;
using Cars.Forms;
using System;
using System.Windows.Forms;

namespace Cars
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            DatabaseHelper.InitializeDatabase();
            Application.Run(new FormLogin()); 
        }
    }
}