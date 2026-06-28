using DTO.User;
using Guna.UI2.WinForms;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Velocity_Rent.Session;
using VelocityRent_DLL.Services;

namespace Velocity_Rent.Login_Form
{
    public partial class frmLogin : Form
    {
        private const string LinkedInURL = "https://www.linkedin.com/in/abdulrhman-ashraf-71bb68254/";
        private const string InvalidLoginMessage = "Invalid username or password.";

        private readonly UserService _userService;
        public frmLogin(UserService userService)
        {
            InitializeComponent();
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
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
            frmMain frm = new frmMain();
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

        private void Login()
        {
            if (ValidateChildren())
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

    }
}
