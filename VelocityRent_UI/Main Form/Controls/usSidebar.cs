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
using Velocity_Rent.Maintenance;
using Velocity_Rent.Properties;
using Velocity_Rent.Settings;
using Velocity_Rent.Users;
using Velocity_Rent.Vehicles;
using GButton = Guna.UI2.WinForms.Guna2GradientButton;

namespace Velocity_Rent.Main_Form.Controls
{
    public partial class usSidebar : UserControl
    {
        private int _TargetTop;

        public event EventHandler<string> NavigationRequested;
        public usSidebar()
        {
            InitializeComponent();
            InitializeState();
        }

        private void InitializeState()
        {
            plIndicator.Height = btnHome.Height;
            plIndicator.Top = btnHome.Top;
            plIndicator.Left = 0;

            ActivateButton(btnHome);
        }
        private void MoveNavIndicator(GButton button)
        {
            _TargetTop = button.Top;
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            int speed = 5;
            if (plIndicator.Top != _TargetTop)
                plIndicator.Top += Math.Sign(_TargetTop - plIndicator.Top) * speed;

            if (Math.Abs(plIndicator.Top - _TargetTop) < speed)
            {
                plIndicator.Top = _TargetTop;
                timer.Stop();
            }
        }
        private void ActivateButton(GButton button)
        {
            // Reset To Default.
            foreach (Control control in pnlSidebar.Controls)
            {
                if (control is GButton btn && btn.Name != "btnViewLinkedinProfile")
                {
                    btn.FillColor = Color.Transparent;
                    btn.FillColor2 = Color.Transparent; 
                }
            }

            // Active Button.
            button.FillColor = Color.FromArgb(255, 190, 80);
            button.FillColor2 = Color.FromArgb(210, 130, 0);
        }
        private void HandleNavigation(GButton button, string formName)
        {
            ActivateButton(button);
            MoveNavIndicator(button);
            NavigationRequested?.Invoke(this, formName);
        }

        private void btnHome_Click(object sender, EventArgs e) => HandleNavigation(btnHome, "Home");
        private void btnUsers_Click(object sender, EventArgs e) => HandleNavigation(btnUsers, "Users");
        private void btnCustomers_Click(object sender, EventArgs e) => HandleNavigation(btnCustomers, "Customers");
        private void btnVehicles_Click(object sender, EventArgs e) => HandleNavigation(btnVehicles, "Vehicles");
        private void btnBookings_Click(object sender, EventArgs e) => HandleNavigation(btnBookings, "Bookings");
        private void btnMaintenance_Click(object sender, EventArgs e) => HandleNavigation(btnMaintenance, "Maintenance");
        private void btnSettings_Click(object sender, EventArgs e) => HandleNavigation(btnSettings, "Settings");

        private void btnFindNearestCar_Click(object sender, EventArgs e)
        {
            string url = "https://www.linkedin.com/in/abdulrhman-ashraf-71bb68254/";

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open LinkedIn profile.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
