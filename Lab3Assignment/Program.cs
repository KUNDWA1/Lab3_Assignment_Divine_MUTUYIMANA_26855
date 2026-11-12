using System;
using System.Windows.Forms;
using EventConnect.Views;

namespace EventConnect
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
