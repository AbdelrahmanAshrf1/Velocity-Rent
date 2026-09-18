using DTO.Person;
using System;
using System.Drawing;
using System.Windows.Forms;
using Velocity_Rent.Session;
using VelocityRent_DLL.Interfaces;
using GButton = Guna.UI2.WinForms.Guna2GradientButton;

namespace Velocity_Rent.Main_Form.Controls
{
    public partial class usSidebar : UserControl
    {
        #region Dependencies

        private readonly IPersonService _personService;

        #endregion

        #region Fields

        private int _TargetTop;

        #endregion

        #region Events

        public event EventHandler<string> NavigationRequested;
        public event EventHandler LogoutRequested;

        #endregion

        #region Constructor

        public usSidebar(IPersonService personService)
        {
            InitializeComponent();

            _personService = personService;

            InitializeState();
            LoadLoggedInUserInfo();
        }

        #endregion

        #region Initialization

        private void InitializeState()
        {
            plIndicator.Height = btnHome.Height;
            plIndicator.Top = btnHome.Top;
            plIndicator.Left = 0;

            ActivateButton(btnHome);
        }

        #endregion

        #region User Information

        private void LoadLoggedInUserInfo()
        {
            lblUserName.Text = CurrentSession.CurrentUser.Username;
            lblUserRole.Text = CurrentSession.CurrentUser.Role;

            LoadUserProfileImage();
        }
        private void LoadUserProfileImage()
        {
            int personID = CurrentSession.CurrentUser.PersonID;
            PersonDto person = _personService.GetPersonByID(personID);

            string imagePath = person.ProfileImage;

            if (!string.IsNullOrWhiteSpace(imagePath))
            {
                using (var image = Image.FromFile(imagePath))
                {
                    pbUserImage.Image = new Bitmap(image);
                }
            }
        }

        #endregion

        #region Navigation

        private void HandleNavigation(GButton button, string formName)
        {
            ActivateButton(button);
            MoveNavIndicator(button);

            NavigationRequested?.Invoke(this, formName);
        }

        private void ActivateButton(GButton button)
        {
            // Reset to default.
            foreach (Control control in pnlSidebar.Controls)
            {
                if (control is GButton btn &&
                    btn.Name != "btnViewLinkedinProfile")
                {
                    btn.FillColor = Color.Transparent;
                    btn.FillColor2 = Color.Transparent;
                }
            }

            // Activate selected button.
            button.FillColor = Color.FromArgb(255, 190, 80);
            button.FillColor2 = Color.FromArgb(210, 130, 0);
        }

        #endregion

        #region Navigation Events

        private void btnHome_Click(object sender, EventArgs e) => HandleNavigation(btnHome, "Home");
        private void btnUsers_Click(object sender, EventArgs e) => HandleNavigation(btnUsers, "Users");
        private void btnCustomers_Click(object sender, EventArgs e) => HandleNavigation(btnCustomers, "Customers");
        private void btnVehicles_Click(object sender, EventArgs e) => HandleNavigation(btnVehicles, "Vehicles");
        private void btnBookings_Click(object sender, EventArgs e) => HandleNavigation(btnBookings, "Bookings");
        private void btnMaintenance_Click(object sender, EventArgs e) => HandleNavigation(btnMaintenance, "Maintenance");
        private void btnPeople_Click(object sender, EventArgs e) => HandleNavigation(btnPeople, "People");
        private void btnSettings_Click(object sender, EventArgs e) => HandleNavigation(btnSettings, "Settings");

        #endregion

        #region Animation

        private void MoveNavIndicator(GButton button)
        {
            _TargetTop = button.Top;
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            int speed = 5;

            if (plIndicator.Top != _TargetTop)
            {
                plIndicator.Top += Math.Sign(_TargetTop - plIndicator.Top) * speed;
            }

            if (Math.Abs(plIndicator.Top - _TargetTop) < speed)
            {
                plIndicator.Top = _TargetTop;
                timer.Stop();
            }
        }

        #endregion

        #region External Links

        private void btnViewLinkedinProfile_Click(object sender, EventArgs e)
        {
            string url = "https://www.linkedin.com/in/abdulrhman-ashraf-71bb68254/";

            try
            {
                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
            }
            catch
            {
                MessageBox.Show(
                    "Unable to open LinkedIn profile.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Logout

        private void btnLogout_Click(object sender, EventArgs e)
            => LogoutRequested?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}
