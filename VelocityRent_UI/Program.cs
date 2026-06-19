using AutoMapper;
using System;
using System.Windows.Forms;
using Velocity_Rent.Login_Form;
using VelocityRent_DLL.Mappings;


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
            MappingService.Configure();
            Application.Run(new frmMain());
            //Application.Run(new frmLogin());
        }
    }
}
