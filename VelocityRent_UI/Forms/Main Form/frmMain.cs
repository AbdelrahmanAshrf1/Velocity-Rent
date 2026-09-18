using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Velocity_Rent.Bookings;
using Velocity_Rent.Customers;
using Velocity_Rent.Forms.People;
using Velocity_Rent.Login_Form;
using Velocity_Rent.Maintenance;
using Velocity_Rent.Session;
using Velocity_Rent.Settings;
using Velocity_Rent.Users;
using Velocity_Rent.Vehicles;
using SButton = FrameworkTest.SATAButton;

namespace Velocity_Rent
{
    public partial class frmMain : Form
    {

        #region Dependencies

        private readonly IServiceProvider _provider;

        #endregion

        #region Fields

        private readonly Dictionary<SButton, Image> _NormalIcon = new Dictionary<SButton, Image>();
        private readonly Dictionary<SButton, Image> _ActivIcon = new Dictionary<SButton, Image>();

        #endregion

        #region Constructor
        public frmMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _provider = serviceProvider;

            usSidebar1.NavigationRequested += UcSidebar1_NavigationRequested;
            usSidebar1.LogoutRequested += LogoutRequested;

            LoadForm(new frmHome());
        }

        #endregion

        #region Navigation
        private void UcSidebar1_NavigationRequested(object sender, string pageName)
        {
            Form form = null;

            switch (pageName)
            {
                case "Home":
                    form = new frmHome(); break;
                case "Users":
                    form = new frmUsers(); break;
                case "Customers":
                    form = new frmCustomers(); break;
                case "Vehicles":
                    form = new frmVehicles(); break;
                case "Bookings":
                    form = new frmBookings(); break;
                case "Maintenance":
                    form = new frmMaintenance(); break;
                case "People":
                    form = _provider.GetRequiredService<frmPersonDirectory>(); break;
                case "Settings":
                    form = new frmSettings(); break;
                default:
                    form = null; break;
            }

            if (form != null) LoadForm(form);
        }

        #endregion

        #region Authentication
        private void LogoutRequested(object sender, EventArgs e)
        {
            CurrentSession.Logout();
            Hide();

            using (var loginForm = _provider.GetRequiredService<frmLogin>())
            {
                loginForm.ShowDialog();
            }

            Close();
        }

        #endregion

        #region Form Management
        private void LoadForm(Form frm)
        {
            if (panelContainer.Controls.Count > 0 &&
                panelContainer.Controls[0].GetType() == frm.GetType()) return;

            panelContainer.Controls.Clear();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(frm);
            frm.Show();
        }

        #endregion
    }
}
