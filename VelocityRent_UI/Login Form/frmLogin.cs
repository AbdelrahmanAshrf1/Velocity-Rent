using DTO.User;
using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Velocity_Rent.Session;
using VelocityRent_DLL.Interfaces;

namespace Velocity_Rent.Login_Form
{
    public partial class frmLogin : Form
    {
        private const string LinkedInURL = "https://www.linkedin.com/in/abdulrhman-ashraf-71bb68254/";
        private const string InvalidLoginMessage = "Invalid username or password.";

        private readonly IUserService _userService;
        private readonly IServiceProvider _provider;
        private readonly IRememberMeService _rememberMeService;
        public frmLogin(
            IUserService userService,
            IServiceProvider provider,
            IRememberMeService rememberMeService)
        {
            InitializeComponent();
            _userService = userService;
            _provider = provider;
            _rememberMeService = rememberMeService;
        }

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

        private void ShowError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void OpenMainForm(UserDto user)
        {
            CurrentSession.CurrentUser = user;
            var frm = _provider.GetRequiredService<frmMain>();
            frm.FormClosed += (s, e) => Close();
            frm.Show();
            Hide();
        }

        private LoginDto CreateLoginDto()
        {
            return  new LoginDto()
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
        private void Login()
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Invalid login data.");
                return;
            }
         
            LoginDto dto = CreateLoginDto();

            Result<UserDto> result = _userService.Login(dto);

            if (!result.Success)
            {
                ShowError(result.Message);
                return;
            }

            HandleRememberMe(result.Data);
            OpenMainForm(result.Data);
        }

        private void btnLogin_Click(object sender, EventArgs e) => Login();

        private bool ValidateRequiredTextBox(Guna2TextBox textBox,string message)
        {
            bool vaild = !string.IsNullOrWhiteSpace(textBox.Text);
            errorProvider1.SetError(textBox, vaild ? "" : message);
            return vaild;
        }

        private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtUsername, "Username is required");
        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtPassword, "Password is required");

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string username = _rememberMeService.Load();

            if (!string.IsNullOrEmpty(username))
            {
                txtUsername.Text = username;
                chkRemmberMe.Checked = true;
            }
        }
    }
}
