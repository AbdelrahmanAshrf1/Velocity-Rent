using DTO.Address;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Velocity_Rent.Map.Services;
using Velocity_Rent.Map.Services.Interfaces;
using static Velocity_Rent.Map.Controls.ucSuggestionItem;

namespace Velocity_Rent.Map.Controls
{
    public partial class ucMapWithSearch : UserControl
    {
        private static readonly HttpClient _httpClient = CreateHttpClient();
        private IMapService _mapService;
        public event Action<AddAddressDto> OnAddressSelected;
        public ucMapWithSearch()
        {
            InitializeComponent();
            SetupSuggestionList();
        }

        private static HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0)");
            client.DefaultRequestHeaders.Add("Accept-Language", "en");
            return client;
        }

        public class NominatimResult
        {
            public string display_name { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
        }
        public class NominatimAddress
        {
            public string city { get; set; }
            public string town { get; set; }
            public string village { get; set; }
            public string state { get; set; }
            public string postcode { get; set; }
            public string country { get; set; }
        }
        public class NominatimReverseResult
        {
            public string display_name { get; set; }
            public NominatimAddress address { get; set; }
        }

        private SuggestionItem ToSuggestion(NominatimResult r)
        {
            return new SuggestionItem
            {
                Title = r.display_name,
                Subtitle = $"{r.lat}, {r.lon}",
                Type = SuggestionType.Location,
                Lat = double.TryParse(r.lat, out var la) ? la : (double?)null,
                Lon = double.TryParse(r.lon, out var lo) ? lo : (double?)null
            };
        }
        private void SetupSuggestionList()
        {
            suggestionList.OnSuggestionSelected += async (item) =>
            {
                txtSearchBox.Text = item.Title;
                suggestionList.Visible = false;

                if (!item.Lat.HasValue || !item.Lon.HasValue) return;

                await _mapService.MoveToAsync(item.Lat.Value, item.Lon.Value);
                await ResolveAndRaiseAddressAsync(item.Lat.Value, item.Lon.Value);

            };
        }

        private async void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearchBox.Text;

            if (string.IsNullOrWhiteSpace(query))
            {
                LoadFavoritesAndRecent();
                return;
            }

            if (query.Length < 2)
            {
                suggestionList.Visible = false;
                return;
            }

            await LoadSuggestionsAsync(query);
        }
        private void LoadFavoritesAndRecent()
        {
            var groups = new List<SuggestionGroup>()
            {
                CreateGroup("⭐ Favorites", SuggestionStorage.LoadFavorites()),
                CreateGroup("🕒 Recent", SuggestionStorage.LoadHistory())
            }.Where(group => group.Items.Any()).ToList();

            if (groups.Any())
                suggestionList.LoadSuggestionsGrouped(groups);
            else
                suggestionList.Visible = false;
        }
        private SuggestionGroup CreateGroup(string title,List<SuggestionItem> list)
        {
            return new SuggestionGroup { Title = title, Items = list }; 
        }
        private async Task LoadSuggestionsAsync(string query)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://nominatim.openstreetmap.org/search?q={Uri.EscapeDataString(query)}&format=json&limit=7";
                    string json = await client.GetStringAsync(url);
                    var results = JsonConvert.DeserializeObject<List<NominatimResult>>(json);
                    var items = results.Select(ToSuggestion).ToList();

                    var groups = new List<SuggestionGroup>
                    {
                        CreateGroup("⭐ Favorites", SuggestionStorage.LoadFavorites()),
                        CreateGroup("📍 Results", items),
                        CreateGroup("🕒 Recent", SuggestionStorage.LoadHistory())
                    }.Where(g => g.Items.Any()).ToList();

                    suggestionList.LoadSuggestionsGrouped(groups);
                }
            }
            catch { suggestionList.Visible = false;}
        }
        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) suggestionList.Visible = false;
        }
        private async void CurrentLocation(object sender, EventArgs e)
        {
            try
            {
                string json = await _httpClient.GetStringAsync("https://ipinfo.io/json");

                dynamic info = JsonConvert.DeserializeObject(json);
                string loc = info.loc;

                string[] parts = loc.Split(',');
                double lat = double.Parse(parts[0], CultureInfo.InvariantCulture);
                double lon = double.Parse(parts[1], CultureInfo.InvariantCulture);

                await _mapService.MoveToAsync(lat, lon);
                await ResolveAndRaiseAddressAsync(lat, lon);
            }
            catch
            {
                MessageBox.Show("Unable to detect current location.");
            }
        }

        private async Task ResolveAndRaiseAddressAsync(double lat, double lon)
        {
            var dto = await ReverseGeocodeAsync(lat, lon);
            OnAddressSelected?.Invoke(dto);
        }

        private async Task<AddAddressDto> ReverseGeocodeAsync(double lat, double lon)
        {
            try
            {
                string url = $"https://nominatim.openstreetmap.org/reverse?lat={lat}&lon={lon}&format=json&addressdetails=1";
                string json = await _httpClient.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<NominatimReverseResult>(json);
                var addr = result?.address ?? new NominatimAddress();

                return new AddAddressDto
                {
                    City = addr.city ?? addr.town ?? addr.village ?? string.Empty,
                    State = addr.state ?? string.Empty,
                    ZipCode = addr.postcode ?? string.Empty,
                    Country = addr.country ?? string.Empty,
                    Latitude = (decimal)lat,
                    Longitude = (decimal)lon
                };
            }
            catch
            {
                return new AddAddressDto
                {
                    Latitude = (decimal)lat,
                    Longitude = (decimal)lon
                };
            }
        }
        private bool IsInDesignMode()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return true;

            if (this.DesignMode)
                return true;

            if (this.Site != null && this.Site.DesignMode)
                return true;

            if (Process.GetCurrentProcess().ProcessName.Equals("devenv", StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }
        private async void ucMapWithSearch_Load(object sender, EventArgs e)
        {
            if (IsInDesignMode()) return;

            try
            {
                _mapService = new MapboxService();
                await _mapService.InitializeAsync(webView21);
            }
            catch (Exception ex)
            {
                // Never let this bubble up as unhandled — especially not inside a designer host.
                System.Diagnostics.Debug.WriteLine($"Map init failed: {ex}");
            }
        }
    }
   }
