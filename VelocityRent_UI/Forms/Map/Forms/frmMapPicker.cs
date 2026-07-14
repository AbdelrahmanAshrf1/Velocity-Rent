using DTO.Address;
using System;
using System.Windows.Forms;

namespace Velocity_Rent.Forms.Map.Forms
{
    public partial class frmMapPicker : Form
    {
        public event Action<AddAddressDto> OnAddressPicked;
        public frmMapPicker()
        {
            InitializeComponent();
            ucMapWithSearch.OnAddressSelected += (dto) =>
            {
                OnAddressPicked?.Invoke(dto);
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }
    }
}
