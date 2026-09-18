using DTO.Person;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Velocity_Rent.Controls.Directory;
using Velocity_Rent.Properties;
using VelocityRent_DLL.Interfaces;

namespace Velocity_Rent.Forms.People
{
    public partial class frmPersonDirectory : Form
    {
        #region Fields
        private readonly IServiceProvider _provider;
        private readonly IPersonService _personService;
        private List<PersonDto> _persons;

        #endregion


        #region Events

        public event Action<PersonDto> SelectedPerson;

        #endregion


        #region Constructor

        public frmPersonDirectory(
            IServiceProvider provider,
            IPersonService personService)
        {
            InitializeComponent();

            _provider = provider;
            _personService = personService;

            BuildPersonDirectory();
            WireEvents();
            LoadActiveFilter();
            ApplyQuery();
        }

        #endregion


        #region Directory Configuration

        private void BuildPersonDirectory()
        {

            _personGrid.Configure<PersonDto>(
                new[]
                {

                    DirectoryColumn<PersonDto>.Image("ProfileImage","",62,p => p.ProfileImage,46,Resources.DefaultPerson),
                    DirectoryColumn<PersonDto>.Text("FullName","Full Name",170,p => p.FullName),
                    DirectoryColumn<PersonDto>.Text("NationalID","National ID",130,p => p.NationalID),
                    DirectoryColumn<PersonDto>.Text("Email","Email",195, p => p.Email),
                    DirectoryColumn<PersonDto>.Text("Phone","Phone",125, p => p.Phone),
                },

                DirectoryAction<PersonDto>.Button("View","View",60),
                DirectoryAction<PersonDto>.Button("Edit","Edit",60),
                DirectoryAction<PersonDto>.Button("Select","Select",60)
            );

            _personGrid.ActionClicked += PersonGrid_ActionClicked;
            _persons = _personService.GetAllPersons();
            _personGrid.SetData(_persons);
        }

        #endregion


        #region Events Wiring

        private void WireEvents()
        {
            _searchDebounce.Tick += SearchDebounce_Tick;
            _txtSearch.TextChanged += Search_TextChanged;
            _cmbActive.SelectedIndexChanged += Filters_Changed;
            _cmbSort.SelectedIndexChanged += Filters_Changed;
            _btnAddPerson.Click += BtnAddPerson_Click;
        }

        #endregion


        #region Search & Filtering

        private void Search_TextChanged(object sender, EventArgs e)
        {
            _searchDebounce.Stop();
            _searchDebounce.Start();
        }
        private void SearchDebounce_Tick(object sender, EventArgs e)
        {
            _searchDebounce.Stop();
            ApplyQuery();
        }
        private void Filters_Changed(object sender, EventArgs e) => ApplyQuery();
        private void ApplyQuery()
        {
            IEnumerable<PersonDto> query = _persons;

            string search = _txtSearch.Text.Trim();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p =>
                    Contains(p.FullName, search)
                    ||
                    Contains(p.NationalID, search)
                    ||
                    Contains(p.Phone, search));
            }


            bool ascending = _cmbSort == null || _cmbSort.SelectedIndex <= 0;

            query = ascending ? query.OrderBy(p => p.FullName)
                    : query.OrderByDescending(p => p.FullName);

            _personGrid.SetData(query.ToList());
        }

        private static bool Contains(string value, string search)
        {
            return !string.IsNullOrEmpty(value)
                && value.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void LoadActiveFilter()
        {
            _cmbActive.Items.Clear();

            _cmbActive.Items.Add("All Cities");
            _cmbActive.Items.Add("Active");
            _cmbActive.Items.Add("Not Active");

            _cmbActive.SelectedIndex = 0;
        }

        #endregion


        #region Grid Actions
        private void PersonGrid_ActionClicked(object sender, DirectoryRowActionEventArgs e)
        {
            if (e == null) return;

            var person = e.GetItem<PersonDto>();

            if (person == null) return;

            switch (e.ActionKey)
            {
                case "View":
                    ViewPerson(person);
                    break;

                case "Edit":
                    EditPerson(person);
                    break;

                case "Select":
                    SelectPerson(person);
                    break;

            }
        }

        #endregion


        #region Person Actions

        private void ViewPerson(PersonDto person)
        {
            var frm = ActivatorUtilities.CreateInstance<frmPersonViewer>(_provider, person.ID);
            frm.ShowDialog(this);
        }
        private void EditPerson(PersonDto person)
        {
            var frm = ActivatorUtilities.CreateInstance<frmPersonEditor>(_provider, person.ID);
            frm.ShowDialog(this);

        }
        private void SelectPerson(PersonDto person)
        {
            SelectedPerson?.Invoke(person);
            Close();
        }

        private void BtnAddPerson_Click(object sender, EventArgs e)
        {
            var frm = _provider.GetRequiredService<frmPersonEditor>();
            frm.ShowDialog();
        }

        #endregion
    }
}