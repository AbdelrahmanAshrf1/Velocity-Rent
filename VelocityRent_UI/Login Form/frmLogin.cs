using DTO.User;
using Guna.UI2.WinForms;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Velocity_Rent.Session;
using VelocityRent_DLL.Interfaces;

namespace Velocity_Rent.Login_Form
{
    public partial class frmLogin : Form
    {
        #region Constants

        private const string LinkedInURL = "https://www.linkedin.com/in/abdulrhman-ashraf-71bb68254/";

        #endregion

        #region Dependencies

        private readonly IUserService _userService;
        private readonly IRememberMeService _rememberMeService;

        #endregion

        #region Constructor

        public frmLogin(
            IUserService userService,
            IRememberMeService rememberMeService)
        {
            InitializeComponent();

            _userService = userService;
            _rememberMeService = rememberMeService;
        }

        #endregion

        #region Authentication

        private void Login()
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Invalid login data.");
                return;
            }

            LoginDto dto = CreateLoginDto();

            Result<UserDto> result = _userService.Login(dto);

            if (!result.IsSuccess)
            {
                ShowError(result.Message);
                return;
            }

            HandleRememberMe(result.Data);
            OpenMainForm(result.Data);
        }
        private LoginDto CreateLoginDto()
        {
            return new LoginDto
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text
            };
        }
        private void HandleRememberMe(UserDto dto)
        {
            if (chkRemmberMe.Checked)
                _rememberMeService.Save(dto.Username);
            else
                _rememberMeService.Clear();
        }
        private void OpenMainForm(UserDto user)
        {
            CurrentSession.CurrentUser = user;

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Validation

        private bool ValidateRequiredTextBox(Guna2TextBox textBox,string message)
        {
            bool valid = !string.IsNullOrWhiteSpace(textBox.Text);
            errorProvider1.SetError(textBox, valid ? "" : message);
            return valid;
        }
        private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !ValidateRequiredTextBox(txtUsername,"Username is required");
        }
        private void txtPassword_Validating(object sender,System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !ValidateRequiredTextBox( txtPassword, "Password is required");
        }

        #endregion

        #region UI Events

        private void btnLogin_Click(object sender, EventArgs e) => Login();
        private void lblContactUs_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = LinkedInURL,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        #endregion

        #region Form Events

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string username = _rememberMeService.Load();

            if (!string.IsNullOrEmpty(username))
            {
                txtUsername.Text = username;
                chkRemmberMe.Checked = true;
            }
        }

        #endregion

        #region Helpers

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        #endregion
    }
}

