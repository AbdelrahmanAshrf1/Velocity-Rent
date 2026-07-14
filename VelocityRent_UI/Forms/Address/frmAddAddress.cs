using DTO.Address;
using System;
using System.Windows.Forms;
using Velocity_Rent.Forms.Map.Forms;

namespace Velocity_Rent.Forms.Address
{
    public partial class frmAddAddress : Form
    {
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
            txtLatitude.Text = dto.Latitude.ToString();
            txtLongitude.Text = dto.Longitude.ToString();
        }
    }
}
