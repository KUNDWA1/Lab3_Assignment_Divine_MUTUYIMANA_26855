using EventConnect;
using Lab3Assignment.Views; // Changed from EventConnect to Lab3Assignment
using System;
using System.Windows.Forms;

namespace Lab3Assignment // Changed from EventConnect to Lab3Assignment
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm()); // Starts the app
        }
    }
}