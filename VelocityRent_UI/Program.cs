using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Velocity_Rent.Dependency_Injection;
using Velocity_Rent.Login_Form;

namespace Velocity_Rent
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var provider = DependencyInjection.ConfigureServices();

            Application.Run(provider.GetRequiredService<frmLogin>());
        }
    }
}
