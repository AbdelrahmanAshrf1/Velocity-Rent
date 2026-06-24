using DTO;
using Guna.UI2.WinForms;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Velocity_Rent.Login_Form
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void lblContactUs_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.linkedin.com/in/abdulrhman-ashraf-71bb68254/",
                UseShellExecute = true
            });
        }

        private void btnViewLinkedinProfile_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                AddUserDto userDto = new AddUserDto();
                userDto.Username = username;
            }
            else
                MessageBox.Show("Invalid login data Please try agin !","failed login",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void ValidateField(Guna2TextBox field,string errorMessage)
        {
            if (string.IsNullOrEmpty(field.Text))
                errorProvider1.SetError(field, errorMessage);
            else
                errorProvider1.SetError(field, null);
        }

        private void txtUsername_Validated(object sender, EventArgs e) => ValidateField(txtUsername, "Please enter a vaild Username !");
        private void txtPassword_Validated(object sender, EventArgs e) => ValidateField(txtPassword, "Wrong Password !");

    }
}
