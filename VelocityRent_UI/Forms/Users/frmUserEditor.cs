using DTO;
using DTO.Person;
using DTO.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Velocity_Rent.Enums;
using Velocity_Rent.Forms.People;
using VelocityRent.Entities.Enums;
using VelocityRent_DLL.Interfaces;

namespace Velocity_Rent.Forms.Users
{
    public partial class frmUserEditor : Form
    {

        #region Dependencies

        private readonly IServiceProvider _provider;
        private readonly IUserService _userService;
        private readonly IPersonService _personService;

        #endregion

        #region State

        private readonly enFormMode _mode;
        private readonly int _userID;

        private PersonDto _selectedPerson;
        private bool _isPasswordVisible = false;
        #endregion

        #region Constructors
        public frmUserEditor(
            int userID,
            IServiceProvider provider,
            IUserService userService,
            IPersonService personService)
        {
            InitializeComponent();

            _userID = userID;

            _provider = provider;
            _userService = userService;
            _personService = personService;
            _mode = enFormMode.Update;
        }

        public frmUserEditor(
            IServiceProvider provider,
            IUserService userService,
            IPersonService personService)
        {
            InitializeComponent();

            _provider = provider;
            _userService = userService;
            _personService = personService;

            _mode = enFormMode.Add;
        }

        #endregion

        #region Form Initialization
        private void frmUserEditor_Load(object sender, EventArgs e)
        {
            ConfigureForm();

            if (_mode == enFormMode.Update)
                LoadUserForEditing();
        }
        private void ConfigureForm()
        {
            if (_mode == enFormMode.Add)
                ConfigureAddMode();
            else
                ConfigureUpdateMode();
        }
        private void ConfigureAddMode()
        {
            lblMode.Text = "Add";
            lblMode.Location = new Point(243, 49);

            lblSubMode.Text = "New User";
            lblSubMode.Location = new Point(295, 49);

            lblSidebarMode.Text = "Add";
            lblBrief.Text = "Create a new user account\r \n and asign a role .";

            btnSave.Text = "Add User";
            txtPersonID.Enabled = true;

            btnChangePassword.Visible = false;
            ActiveControl = btnSave;
        }
        private void ConfigureUpdateMode()
        {
            lblMode.Text = "Update";
            lblMode.Location = new Point(243, 49);

            lblSubMode.Text = "User";
            lblSubMode.Location = new Point(295, 49);

            lblSidebarMode.Text = "Update";
            lblBrief.Text = "Update user\r \n in the system.";

            btnSave.Text = "Update User";

            txtPersonID.Enabled = false;
            txtPassword.Enabled = false;

            btnSearch.Enabled = false;
            btnChangePassword.Visible = false;

            cbUserRole.Enabled = false;
        }
        private void btnCancel_Click(object sender, EventArgs e) => Close();

        #endregion

        #region Load Existing User

        private void LoadUserForEditing()
        {
            UserDto user = _userService.GetUserByID(_userID);

            if(user == null)
            {
                ShowError($"User with ID {_userID} was not found.");
                Close();
                return;    
            }

            PopulateUserFields(user);
        }
        private void PopulateUserFields(UserDto user)
        {
            txtPersonID.Text = user.ID.ToString();
            txtUsername.Text = user.Username; 
            cbUserRole.Text = user.Role.ToString();
        }

        #endregion

        #region Create / Upadte 
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_mode == enFormMode.Add)
                CreateNewUser();
            else
                UpdateUser();
        }
        private void CreateNewUser()
        {
            if (!ValidateChildren())
            {
                ShowError("Invalid User Data!");
                return;
            }

            AddUserDto user = CreateUserDto();

            int userID = _userService.AddUser(user);

            if(userID <= 0)
            {
                ShowError("Filled created user please try again !");
                return;
            }

            MessageBox.Show(
           $"User created successfully.\n User ID: {userID}",
           "Success",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);

            Close();
        }
        private void UpdateUser()
        {
            if (!ValidateChildren())
            {
                ShowError("Invalid User Data!");
                return;
            }

            UpdateUserDto user = CreateUpdateUserDto();

            bool success = _userService.UpdateUser(user);

            if (!success)
            {
                ShowError("Filled Updated user please try again !");
                return;
            }

            MessageBox.Show(
           $"User updated successfully.\n User ID: {_userID}",
           "Success",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);

            Close();
        }
        #endregion

        #region User DTO

        private AddUserDto CreateUserDto()
        {
            return new AddUserDto
            {
                PersonID = Convert.ToInt32(txtPersonID.Text),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                UserRole = (enUserRole)Enum.Parse( typeof(enUserRole),cbUserRole.Text)
            };
        }
        private UpdateUserDto CreateUpdateUserDto()
        {
            return new UpdateUserDto(_userID)
            {
                Username = txtUsername.Text,
                UserRole = (enUserRole)Enum.Parse(typeof(enUserRole), cbUserRole.Text)
            };
        }

        #endregion

        #region Actions
        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;
            txtPassword.PasswordChar = _isPasswordVisible ? '\0' : '*';
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var frm = _provider.GetRequiredService<frmPersonDirectory>();
            frm.SelectedPerson += ReciveSelectedPerson;
            frm.ShowDialog();
        }
        private void ReciveSelectedPerson(PersonDto person)
        {
            _selectedPerson = person;
            txtPersonID.Text = person.ID.ToString();
        }

        #endregion

        #region Validators

        private void txtPersonID_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(txtPersonID, string.Empty);

            if (string.IsNullOrWhiteSpace(txtPersonID.Text))
            {
                errorProvider.SetError(txtPersonID, "Person ID is required!");
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(txtPersonID.Text, out int personID))
            {
                errorProvider.SetError(txtPersonID, "Person ID must be a valid number!");
                e.Cancel = true;
                return;
            }

            if (!_personService.Exists(personID))
            {
                errorProvider.SetError(txtPersonID, "Person ID does not exist in the system!");
                e.Cancel = false;
                return;
            }

            if (_personService.HasUser(personID))
            {
                errorProvider.SetError(txtPersonID, "This person already has a user!");
                e.Cancel = true;
                return;
            }
        }
        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(txtUsername, string.Empty);
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, "Username is required!");
                e.Cancel = true;
                return;
            }
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(txtPassword, string.Empty);

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Password is required!");
                e.Cancel = true;
                return;
            }

            if (txtPassword.Text.Trim().Length < 8)
            {
                errorProvider.SetError(txtPassword, "Password can not be less than 8 char!");
                e.Cancel = true;
                return;
            }
        }
        private void cbUserRole_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(cbUserRole, string.Empty);

            if (string.IsNullOrWhiteSpace(cbUserRole.Text))
            {
                errorProvider.SetError(cbUserRole, "User role is required!");
                e.Cancel = false;
                return;
            }
        }
        #endregion

        #region Helper

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

    }

}
