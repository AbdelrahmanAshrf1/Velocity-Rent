using DTO.Address;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Velocity_Rent.Enums;
using Velocity_Rent.Forms.Map.Forms;
using VelocityRent_DLL.Interfaces;

namespace Velocity_Rent.Forms.Address
{
    public partial class frmAddressEditor : Form
    {
        #region Dependencies

        private readonly IAddressService _addressService;

        #endregion

        #region State

        private readonly enFormMode _mode;
        private readonly int _addressID;

        public event EventHandler<AddAddressDto> AddressAdded;
        public event EventHandler<UpdateAddressDto> AddressUpdated;

        #endregion

        #region Constructors

        public frmAddressEditor(IAddressService addressService)
        {
            InitializeComponent();
            _addressService = addressService;
            _mode = enFormMode.Add;
        }
        public frmAddressEditor(int AddressID, IAddressService addressService)
        {
            InitializeComponent();
            _addressService = addressService;
            _addressID = AddressID;
            _mode = enFormMode.Update;
        }

        #endregion

        #region Form Initialization
        private void frmAddressEditor_Load(object sender, EventArgs e)
        {
            ConfigureForm();
            if (_mode == enFormMode.Update)
                LoadAddressForEditing();
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
            lblMode.Location = new Point(424, 46);

            lblSubMode.Text = "New Address";
            lblSubMode.Location = new Point(486, 46);

            lblSidebarMode.Text = "Add";
            lblBrief.Text = "Add new address\r\n to the system.";

            btnSave.Text = "Add Address";
        }
        private void ConfigureUpdateMode()
        {
            lblMode.Text = "Update";
            lblMode.Location = new Point(424, 46);

            lblSubMode.Text = "Address";
            lblSubMode.Location = new Point(486, 46);

            lblSidebarMode.Text = "Update";
            lblBrief.Text = "Update address\r\n in the system.";

            btnSave.Text = "Save Changes";
        }
        private void LoadAddressForEditing()
        {
            AddressDto address = _addressService.GetByID(_addressID);
            
            if(address == null)
            {
                ShowError($"Address with ID {_addressID} was not found.");
                Close();
                return;
            }

            PopulateAddressFields(address);
        }
        private void PopulateAddressFields(AddressDto address)
        { 
            txtCity.Text = address.City;
            txtState.Text = address.State;
            txtZipCode.Text = address.ZipCode;
            txtCountry.Text = address.Country;
            txtLatitude.Text = address.Latitude.ToString(CultureInfo.InvariantCulture);
            txtLongitude.Text = address.Longitude.ToString(CultureInfo.InvariantCulture);
        }

        #endregion

        #region Map

        private void gbSearchAddressOnMap_Click(object sender, EventArgs e)
        {
            using (var picker = new frmMapPicker())
            {
                picker.OnAddressPicked += FillAddressFields;
                picker.ShowDialog(this); 
            }
        }
        private void FillAddressFields(AddAddressDto address)
        {
            txtCity.Text = address.City;
            txtState.Text = address.State;
            txtZipCode.Text = address.ZipCode;
            txtCountry.Text = address.Country;
            txtLatitude.Text = address.Latitude.ToString(CultureInfo.InvariantCulture);
            txtLongitude.Text = address.Longitude.ToString(CultureInfo.InvariantCulture);
        }

        #endregion

        #region Validation
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
        private void txtCity_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtCity, "City is required!");
        private void txtState_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtState, "State is required!");
        private void txtZipCode_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtZipCode, "Zip code is required!");
        private void txtCountry_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtCountry, "Country is required!");
        private void txtLatitude_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateDecimalTextBox(txtLatitude, "Latitude value is required!");
        private void txtLongitude_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateDecimalTextBox(txtLongitude, "Longitude value is required!");

        #endregion

        #region DTO Creation

        private AddAddressDto CreateAddAddressDto()
        {
            return new AddAddressDto()
            {
                City = txtCity.Text.Trim(),
                State = txtState.Text.Trim(),
                ZipCode = txtZipCode.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                Latitude = decimal.Parse(txtLatitude.Text,NumberStyles.Number,CultureInfo.InvariantCulture),
                Longitude = decimal.Parse(txtLatitude.Text,NumberStyles.Number,CultureInfo.InvariantCulture)
            };
        }
        private UpdateAddressDto CreateUpdateAddressDto()
        {
            return new UpdateAddressDto()
            {
                ID = _addressID,
                City = txtCity.Text.Trim(),
                State = txtState.Text.Trim(),
                ZipCode = txtZipCode.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                Latitude = decimal.Parse(txtLatitude.Text, NumberStyles.Number, CultureInfo.InvariantCulture),
                Longitude = decimal.Parse(txtLatitude.Text, NumberStyles.Number, CultureInfo.InvariantCulture)
            };
        }
        #endregion

        #region Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                ShowError("Invaild Address Data !");
                return;
            }

            if(_mode == enFormMode.Add)
            {
                AddAddressDto dto = CreateAddAddressDto();
                AddressAdded?.Invoke(this, dto);
            }
            else
            {
                UpdateAddressDto dto = CreateUpdateAddressDto();
                AddressUpdated?.Invoke(this, dto);
            }

             Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        #endregion

        #region Helper
        private void ShowError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        #endregion

    }
}
