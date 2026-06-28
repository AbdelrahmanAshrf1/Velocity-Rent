using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Velocity_Rent.Dependency_Injection;
using Velocity_Rent.Login_Form;
using Velocity_Rent_DAL.Interfaces;
using Velocity_Rent_DAL.Repositories;
using VelocityRent.Validators.Validators.User;
using VelocityRent_DLL.Services;


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

            var provider = DependencyInjection.Configure();

            Application.Run(provider.GetRequiredService<frmLogin>());
        }
    }
}
