using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Velocity_Rent.Bookings;
using Velocity_Rent.Customers;
using Velocity_Rent.Main_Form.Controls;
using Velocity_Rent.Maintenance;
using Velocity_Rent.Properties;
using Velocity_Rent.Settings;
using Velocity_Rent.Users;
using Velocity_Rent.Vehicles;
using SButton = FrameworkTest.SATAButton;

namespace Velocity_Rent
{
    public partial class frmMain : Form
    {
        private readonly Dictionary<SButton, Image> _NormalIcon = new Dictionary<SButton, Image>();
        private readonly Dictionary<SButton, Image> _ActivIcon = new Dictionary<SButton, Image>();
        public frmMain()
        {
            InitializeComponent();
            usSidebar1.NavigationRequested += UcSidebar1_NavigationRequested;
            LoadForm(new frmHome());
        }
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
                case "Settings":
                    form = new frmSettings(); break;
                default:
                    form = null;break;
            }

            if(form != null) LoadForm(form);
        }

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
    }
}
