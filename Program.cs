using System;
using System.Windows.Forms;
using Lab3Assignment.Views;

namespace Lab3Assignment
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
