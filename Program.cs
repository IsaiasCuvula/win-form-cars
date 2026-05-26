using System;
using System.Windows.Forms;
using Cars.Database;

namespace Cars
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            DatabaseHelper.InitializeDatabase();
            Application.Run(new FormMenu());
        }
    }
}