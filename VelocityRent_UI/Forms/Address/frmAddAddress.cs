using DTO.Address;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Velocity_Rent.Forms.Map.Forms;

namespace Velocity_Rent.Forms.Address
{
    public partial class frmAddAddress : Form
    {
        public event EventHandler<AddAddressDto> AfterSelectAddress;
        public frmAddAddress()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
        private void gbSearchAddressOnMap_Click(object sender, EventArgs e)
        {
            using (var picker = new frmMapPicker())
            {
                picker.OnAddressPicked += FillAddressFields;
                picker.ShowDialog(this); // modal - blocks until picker closes
            }
        }
        private void FillAddressFields(AddAddressDto dto)
        {
            txtCity.Text = dto.City;
            txtState.Text = dto.State;
            txtZipCode.Text = dto.ZipCode;
            txtCountry.Text = dto.Country;
            txtLatitude.Text = dto.Latitude.ToString(CultureInfo.InvariantCulture);
            txtLongitude.Text = dto.Longitude.ToString(CultureInfo.InvariantCulture);
        }
        private bool ValidateRequiredTextBox(Guna2TextBox textBox, string message)
        {
            bool vaild = !string.IsNullOrWhiteSpace(textBox.Text);
            errorProvider.SetError(textBox, vaild ? "" : message);
            return vaild;
        }
        private bool ValidateDecimalTextBox(Guna2TextBox textBox, string message)
        {
            bool valid = decimal.TryParse(textBox.Text, out _);
            errorProvider.SetError(textBox, valid ? "" : message);
            return valid;
        }
        private AddAddressDto CreateAddressDto()
        {
            return new AddAddressDto()
            {
                City = txtCity.Text,
                State = txtState.Text,
                ZipCode = txtZipCode.Text,
                Country = txtCountry.Text,
                Latitude = Convert.ToDecimal(txtLatitude.Text),
                Longitude = Convert.ToDecimal(txtLongitude.Text)
            };
        }
        private void btnCreateAddress_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                ShowError("Invaild Address Data !");
                return;
            }

            var addAddressDto = CreateAddressDto();

            AfterSelectAddress?.Invoke(this, addAddressDto);
            Close();
        }
        private void ShowError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void txtCity_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtCity, "City is required!");
        private void txtState_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtState, "State is required!");
        private void txtZipCode_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtZipCode, "Zip code is required!");
        private void txtCountry_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtCountry, "Country is required!");
        private void txtLatitude_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateDecimalTextBox(txtLatitude, "Latitude value is required!");
        private void txtLongitude_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateDecimalTextBox(txtLongitude, "Longitude value is required!");
        
    }
}
