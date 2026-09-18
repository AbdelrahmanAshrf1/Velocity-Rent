using DTO;
using DTO.Address;
using DTO.Person;
using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Velocity_Rent.Enums;
using Velocity_Rent.Forms.Address;
using VelocityRent_DLL.Interfaces;
using Image = System.Drawing.Image;

namespace Velocity_Rent.Forms.People
{
    public partial class frmPersonEditor : Form
    {
        #region Dependencies

        private readonly IAddressService _addressService;
        private readonly IPersonService _personService;
        private readonly IServiceProvider _provider;

        #endregion

        #region State

        private readonly enFormMode _mode;
        private readonly int _personID;
        private int _addressID;

        private string _imagePath;
        private string _originalImagePath;

        private AddAddressDto _newAddress;
        private UpdateAddressDto _updateAddress;

        #endregion

        #region Constructors

        public frmPersonEditor(
            IAddressService addressService,
            IPersonService personService,
            IServiceProvider provider)
        {
            InitializeComponent();

            _mode = enFormMode.Add;

            _addressService = addressService;
            _personService = personService;
            _provider = provider;
        }

        public frmPersonEditor(
            int personID,
            IAddressService addressService,
            IPersonService personService,
            IServiceProvider provider)
        {
            InitializeComponent();

            _personID = personID;
            _mode = enFormMode.Update;

            _addressService = addressService;
            _personService = personService;
            _provider = provider;
        }

        #endregion

        #region Form Initialization

        private void frmPersonEditor_Load(object sender, EventArgs e)
        {
            ConfigureForm();

            if (_mode == enFormMode.Update)
                LoadPersonForEditing();
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
            lblMode.Location = new Point(342, 46);

            lblSubMode.Text = "New Person";
            lblSubMode.Location = new Point(400, 46);

            lblSidebarMode.Text = "Add";
            lblBrief.Text = "Add a new person\r \n to the system.";

            btnSave.Text = "Add Person";
            btnOpenAddressForm.Text = "+ New Address";
        }
        private void ConfigureUpdateMode()
        {
            lblMode.Text = "Update";
            lblMode.Location = new Point(342, 49);

            lblSubMode.Text = "Person";
            lblSubMode.Location = new Point(446, 49);

            lblSidebarMode.Text = "Update";
            lblBrief.Text = "Update person\r\n in the system.";

            btnSave.Text = "Save Changes";
            btnOpenAddressForm.Text = "Update Address";
        }
        private void btnCancel_Click(object sender, EventArgs e) => Close();

        #endregion

        #region Load Existing Person & Address

        private void LoadPersonForEditing()
        {
            PersonDto person = _personService.GetPersonByID(_personID);

            if (person == null)
            {
                ShowError($"Person with ID {_personID} was not found.");
                Close();
                return;
            }

            _addressID = person.AddressID;

            PopulatePersonFields(person);
            LoadAddressForEditing();
        }
        private void PopulatePersonFields(PersonDto person)
        {
            txtFirstName.Text = person.FirstName;
            txtLastName.Text = person.LastName;
            txtEmail.Text = person.Email;
            txtPhone.Text = person.Phone;
            txtNationalID.Text = person.NationalID;
            dtDateOfBirth.Value = person.DateOfBirth;

            LoadPersonImage(person.ProfileImage);

            txtAddressID.Text = person.AddressID.ToString();
        }
        private void LoadPersonImage(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath)) return;

            _originalImagePath = imagePath;
            _imagePath = imagePath;

            SetPersonImage(_imagePath);
        }
        private void LoadAddressForEditing()
        {
            AddressDto address = _addressService.GetByID(_addressID);

            if (address == null)
            {
                ShowError($"Address with ID {_addressID} was not found.");
                Close();
                return;
            }

            _updateAddress = new UpdateAddressDto
            {
                ID = _addressID,
                City = address.City,
                State = address.State,
                ZipCode = address.ZipCode,
                Country = address.Country,
                Latitude = address.Latitude,
                Longitude = address.Longitude
            };
        }

        #endregion

        #region Profile Image

        private Image LoadImage(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (Image image = Image.FromStream(stream))
                {
                    return new Bitmap(image);
                }
            }
        }
        private void SetPersonImage(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) return;

            Image oldImage = pbPersonImage.Image;

            pbPersonImage.Image = LoadImage(path);
            pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;

            if (oldImage != null) oldImage.Dispose();
        }
        private string CopyImageToPeopleFolder(string sourcePath)
        {
            string folder = Path.Combine(Application.StartupPath,"Images", "People");
            Directory.CreateDirectory(folder);
            string extension = Path.GetExtension(sourcePath);
            string fileName = Guid.NewGuid().ToString("N") + extension;
            string destinationPath = Path.Combine(folder, fileName);
            File.Copy(sourcePath, destinationPath, true);

            return destinationPath;
        }
        private string PrepareImageForSaving()
        {
            if (string.IsNullOrWhiteSpace(_imagePath) || !File.Exists(_imagePath)) return null;
            return CopyImageToPeopleFolder(_imagePath);
        }
        private bool HasImageChanged()
        {
            return !string.Equals(_imagePath,  _originalImagePath, StringComparison.OrdinalIgnoreCase);
        }
        private void DeleteImage(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath)) return;


            try
            {
                File.Delete(imagePath);
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        #endregion

        #region Create / Update

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_mode == enFormMode.Add)
                CreateNewPerson();
            else
                UpdatePerson();
        }
        private void CreateNewPerson()
        {
            if (!ValidateFields()) return;

            string savedImagePath = null;

            try
            {
             
                savedImagePath = PrepareImageForSaving();

                AddPersonDto dto = CreatePersonDto(savedImagePath);

                CreatePersonRequest request = new CreatePersonRequest
                {
                    PersonDto = dto,
                    AddressDto = _newAddress
                };

                Result<int> result = _personService.CreatePerson(request);

                if (!result.IsSuccess)
                {
                    DeleteImage(savedImagePath);
                    ShowError(result.Message);
                    return;
                }

                MessageBox.Show(
                    $"Person created successfully.\nPerson ID: {result.Data}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                DeleteImage(savedImagePath);
                ShowError(ex.Message);
            }
        }
        private void UpdatePerson()
        {
            if (!ValidateFields()) return;

            if (_updateAddress == null)
            {
                ShowError("Address information is missing.");
                return;
            }

            string newImagePath = _originalImagePath;

            try
            {
                bool imageChanged = HasImageChanged();

                if (imageChanged)
                {
                    newImagePath = PrepareImageForSaving();

                    if (string.IsNullOrWhiteSpace(newImagePath))
                    {
                        ShowError("The selected profile image could not be saved.");
                        return;
                    }
                }

                UpdatePersonDto dto = CreateUpdatePersonDto(newImagePath);

                UpdatePersonRequest request = new UpdatePersonRequest
                {
                    PersonDto = dto,
                    AddressDto = _updateAddress
                };

                Result<bool> result = _personService.UpdatePerson(request);

                if (!result.IsSuccess)
                {
                    if (imageChanged) DeleteImage(newImagePath);

                    ShowError(result.Message);
                    return;
                }

                if (imageChanged) DeleteImage(_originalImagePath);

                MessageBox.Show(
                    "Person updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                if (!string.Equals(newImagePath, _originalImagePath,StringComparison.OrdinalIgnoreCase))
                {
                    DeleteImage(newImagePath);
                }

                ShowError(ex.Message);
            }
        }

        #endregion

        #region Person DTO

        private AddPersonDto CreatePersonDto(string imagePath)
        {
            return new AddPersonDto
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                DateOfBirth = dtDateOfBirth.Value.Date,
                NationalID = txtNationalID.Text.Trim(),

                ProfileImage = imagePath
            };
        }
        private UpdatePersonDto CreateUpdatePersonDto(string imagePath)
        {
            return new UpdatePersonDto(_personID)
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                DateOfBirth = dtDateOfBirth.Value.Date,

                ProfileImage = imagePath
            };
        }

        #endregion

        #region Address

        private void btnOpenAddressForm_Click(object sender, EventArgs e)
        {
            ConfigureAddressForm();
        }
        private void ConfigureAddressForm()
        {
            if (_mode == enFormMode.Add)
                ConfigureAddressFormAddMode();
            else
                ConfigureAddressFormUpdateMode();
        }
        private void ConfigureAddressFormAddMode()
        {
            var frm = _provider.GetRequiredService<frmAddressEditor>();
            frm.AddressAdded += AddressAdded;
            frm.ShowDialog(this);
        }
        private void ConfigureAddressFormUpdateMode()
        {
            var frm = ActivatorUtilities.CreateInstance<frmAddressEditor>( _provider, _addressID);
            frm.AddressUpdated += AddressUpdated;
            frm.ShowDialog(this);
        }
        private void AddressAdded(object sender,AddAddressDto dto) => _newAddress = dto;
        private void AddressUpdated(object sender,UpdateAddressDto dto) => _updateAddress = dto;

        #endregion

        #region Profile Image Selection

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Profile Image";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (dialog.ShowDialog() != DialogResult.OK) return;

                _imagePath = dialog.FileName;

                SetPersonImage(_imagePath);
            }
        }

        #endregion

        #region Validation

        private bool ValidateFields()
        {
            if (!ValidateChildren())
            {
                ShowError("Invalid Person Data!");
                return false;
            }

            if (_mode == enFormMode.Add)
            {
                if (_newAddress == null)
                {
                    ShowError("Please create or select an address.");
                    return false;
                }
            }
            else
            {
                if (_updateAddress == null)
                {
                    ShowError("Address information is missing.");
                    return false;
                }
            }

            return true;
        }

        private bool ValidateRequiredTextBox(Guna2TextBox textBox, string message)
        {
            bool valid = !string.IsNullOrWhiteSpace(textBox.Text);
            errorProvider.SetError(textBox, valid ? "" : message);
            return valid;
        }
        private bool ValidateDateTimePicker(Guna2DateTimePicker dateTimePicker, string message)
        {
            bool valid = dateTimePicker.Value.Year <= DateTime.Now.Year - 18;
            errorProvider.SetError(dateTimePicker, valid ? "" : message);
            return valid;
        }
        private void txtFirstName_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtFirstName, "First name is required!");
        private void txtLastName_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtLastName, "Last name is required!");
        private void txtEmail_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtEmail, "Email is required!");
        private void txtPhone_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtPhone, "Phone is required!");
        private void dtDateOfBirth_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateDateTimePicker(dtDateOfBirth, "Date is required!"); 
        private void txtNationalID_Validating(object sender, CancelEventArgs e) => e.Cancel = !ValidateRequiredTextBox(txtNationalID, "National ID is required!");

        #endregion

        #region Helper

        private void ShowError(string message)
        {
            MessageBox.Show( message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        #endregion
    }
}
