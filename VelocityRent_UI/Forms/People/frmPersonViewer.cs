using DTO.Address;
using DTO.Person;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Velocity_Rent.Properties;
using VelocityRent_DLL.Interfaces;

namespace Velocity_Rent.Forms.People
{
    public partial class frmPersonViewer : Form
    {
        #region Dependencies

        private readonly IServiceProvider _provider;
        private readonly IPersonService _personService;
        private readonly IAddressService _addressService;

        #endregion

        #region Fields

        private readonly int _personID;
        private PersonDto _person;

        private int _addressID;
        private AddressDto _address;
        #endregion

        #region Constructor
        public frmPersonViewer(
            int personId,
            IServiceProvider provider,
            IPersonService personService,
            IAddressService addressService)
        {
            InitializeComponent();

            _personID = personId;
            _provider = provider;
            _personService = personService;
            _addressService = addressService;
        }
        #endregion

        #region Form Initialization 
        private void frmPersonViewer_Load(object sender, EventArgs e)
        {
            LoadPeronalInformation();
            PopulatePersonalFields();
        }
        private void LoadPeronalInformation()
        {
            LoadPerson();
            LoadPersonalAddress();
        }
        private void LoadPerson()
        {
            PersonDto person = _personService.GetPersonByID(_personID);

            if (person == null)
            {
                ShowError($"Person with ID {_personID} was not found.");
                Close();
                return;
            }

            _person = person;
            _addressID = person.AddressID;
        }
        private void LoadPersonalAddress()
        {
            AddressDto address = _addressService.GetByID(_addressID);

            if (address == null)
            {
                ShowError($"Address with ID {_addressID} was not found.");
                Close();
                return;
            }

            _address = address;
        }
        private void PopulatePersonalFields()
        {
            // Person
            lblFirstName.Text = _person.FirstName;
            lblLastName.Text = _person.LastName;
            lblEmail.Text = _person.Email;
            lblPhone.Text = _person.Phone;
            lblDateOfBirth.Text = _person.DateOfBirth.ToString();
            lblNationalID.Text = _person.NationalID;

            if (!string.IsNullOrEmpty(_person.ProfileImage))
                pbProfileImage.ImageLocation = _person.ProfileImage;
            else
                pbProfileImage.Image = Resources.DefaultPerson;

            // Address
            lblCountry.Text = _address.Country;
            lblCity.Text = _address.City;
            lblState.Text = _address.State;
            lblZipCode.Text = _address.ZipCode;
            lblLatitude.Text = _address.Latitude.ToString();
            lblLongitude.Text = _address.Longitude.ToString();
            lblFullAddress.Text = $"{lblCountry.Text}, {lblCity}";
        }

        #endregion

        #region Buttons / Actions
        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            var frm = ActivatorUtilities.CreateInstance<frmPersonEditor>(_provider, _personID);
            frm.ShowDialog();
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            var frm = _provider.GetRequiredService<frmPersonEditor>();
            frm.ShowDialog();
        }
        private void btnBack_Click(object sender, EventArgs e) => Close();

        #endregion

        #region Helper

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }




        #endregion

    }
}
