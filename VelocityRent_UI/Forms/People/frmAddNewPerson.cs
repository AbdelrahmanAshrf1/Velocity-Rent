using DTO;
using DTO.Address;
using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Velocity_Rent.Forms.Address;
using VelocityRent_DLL.Interfaces;

namespace Velocity_Rent.Forms.People
{
    public partial class frmAddNewPerson : Form
    {
        private readonly IAddressService _addressService;
        private readonly IPersonService _personService;
        private readonly IServiceProvider _provider;

        private AddAddressDto _addAddressDto;
        private int _addressId;

        public frmAddNewPerson(
            IAddressService addressService,
            IPersonService personService,
            IServiceProvider provider)
        {
            InitializeComponent();

            _addressService = addressService;
            _personService = personService;
            _provider = provider;
        }

        private void ShowError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private bool ValidateRequiredTextBox(Guna2TextBox textBox, string message)
        {
            bool vaild = !string.IsNullOrWhiteSpace(textBox.Text);
            errorProvider.SetError(textBox, vaild ? "" : message);
            return vaild;
        }
        private bool ValidateDateTimePicker(Guna2DateTimePicker dateTimePicker, string message)
        {
            bool vaild = dateTimePicker.Value.Year <= DateTime.Now.Year - 18;
            errorProvider.SetError(dateTimePicker, vaild ? "" : message);
            return vaild;
        }
        private bool ValidateIntegerTextBox(Guna2TextBox textBox, string message)
        {
            bool vaild = int.TryParse(textBox.Text, out _);
            errorProvider.SetError(textBox, vaild ? "" : message);
            return vaild;
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtFirstName, "First name is required!");
        private void txtLastName_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtLastName, "Last name is required!");
        private void txtEmail_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtEmail, "Email is required!");
        private void txtPhone_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtPhone, "Phone is required!");
        private void dtDateOfBirth_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateDateTimePicker(dtDateOfBirth, "Date is required!");
        private void txtNationalID_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtNationalID, "National ID is required!");
        private void txtAddressID_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateIntegerTextBox(txtAddressID, "Address ID is required!");

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Profile Image";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pbPersonImage.ImageLocation = dialog.FileName;
                    pbPersonImage.Load();
                }
            }
        }

        private bool ValidateFields()
        {
            if (!ValidateChildren())
            {
                ShowError("Invalid Person Data!");
                return false;
            }
            else if (_addAddressDto == null)
            {
                ShowError("Please create or select an address.");
                return false;
            }
            return true;
        }

        private bool CreatePersonalAddress()
        {
            int addressID = _addressService.AddAddress(_addAddressDto);
            if(addressID == -1)
            {
                ShowError("Can not create an address.");
                return false;
            }
            _addressId = addressID;
            return true;
        }

        private AddPersonDto CreatePersonDto()
        {
            return new AddPersonDto()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                DateOfBirth = dtDateOfBirth.Value,
                NationalID = txtNationalID.Text,
                AddressID = _addressId,
                ProfileImage = pbPersonImage.ImageLocation
            };
        }

        private bool CreatePersonEntity()
        {
            var personDto = CreatePersonDto();
            int id = _personService.AddPerson(personDto);
            if (id == -1)
            {
                ShowError("Can not create a person.");
                return false;
            }
            return true;
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;
            if(!CreatePersonalAddress()) return;

            CreatePersonEntity();

        }
        private void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            var frm = _provider.GetRequiredService<frmAddAddress>();
            frm.AfterSelectAddress += GetAddAddressDto;
            frm.ShowDialog(this);
        }

        private void GetAddAddressDto(object sender , AddAddressDto e) => _addAddressDto = e;

    
    }
}
