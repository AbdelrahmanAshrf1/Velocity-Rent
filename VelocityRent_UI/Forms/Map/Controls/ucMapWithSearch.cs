using DTO.Address;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Velocity_Rent.Map.Services;
using Velocity_Rent.Map.Services.Interfaces;
using static Velocity_Rent.Map.Controls.ucSuggestionItem;

namespace Velocity_Rent.Map.Controls
{
    public partial class ucMapWithSearch : UserControl
    {
        private IMapService _mapService;

        private readonly string _mapboxToken = ConfigurationManager.AppSettings["MapboxAccessToken"];
        private Guid _sessionToken = Guid.NewGuid();
        private bool _hadTextLastChange = false; // tracks empty -> non-empty transitions

        private static readonly HttpClient _httpClient = CreateHttpClient();
        public event Action<AddAddressDto> OnAddressSelected;

        private CancellationTokenSource _searchCancellation = null;
        private string _query;
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
        private SuggestionItem ToSuggestion(MapboxSuggestion s)
        {
            string subtitle = !string.IsNullOrWhiteSpace(s.place_formatted)
                ? s.place_formatted
                : s.full_address
                  ?? s.context?.region?.name
                  ?? s.context?.country?.name
                  ?? "";

            return new SuggestionItem
            {
                Title = s.name,
                Subtitle = subtitle,
                Type = SuggestionType.Location,
                MapboxId = s.mapbox_id
            };
        }
        private void SetupSuggestionList()
        {
            suggestionList.OnSuggestionSelected += async (item) =>
            {
                txtSearchBox.Text = item.Title;
                suggestionList.Visible = false;
                if (string.IsNullOrEmpty(item.MapboxId)) return;

                var (lat, lon) = await RetrieveCoordinatesAsync(item.MapboxId);
                if (lat == null || lon == null) return;

                await _mapService.MoveToAsync(lat.Value, lon.Value);
            };
        }
        private async Task<(double? lat, double? lon)> RetrieveCoordinatesAsync(string mapboxId)
        {
            try
            {
                string url = $"https://api.mapbox.com/search/searchbox/v1/retrieve/{mapboxId}"
                    + $"?session_token={_sessionToken}"
                    + $"&access_token={_mapboxToken}";

                string json = await _httpClient.GetStringAsync(url);
                var parsed = JsonConvert.DeserializeObject<MapboxRetrieveResponse>(json);
                var feature = parsed?.features?.FirstOrDefault();
                var coords = feature?.geometry?.coordinates;

                if (coords == null || coords.Count < 2) return (null, null);

                // GeoJSON order is [longitude, latitude] — easy to flip by accident, double check this
                return (coords[1], coords[0]);
            }
            catch
            {
                return (null, null);
            }
        }
        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
            _query = txtSearchBox.Text;

            bool hasTextNow = !string.IsNullOrWhiteSpace(_query);
            if (hasTextNow && !_hadTextLastChange) _sessionToken = Guid.NewGuid();
            _hadTextLastChange = hasTextNow;

            if (string.IsNullOrWhiteSpace(_query))
            {
                timer.Stop();
                LoadFavoritesAndRecent();
                return;
            }

            if (_query.Length < 2)
            {
                timer.Stop();
                suggestionList.Visible = false;
                return;
            }
        }
        private async void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            await LoadSuggestionsAsync(_query);
        }
        private async Task LoadSuggestionsAsync(string query)
        {
            _searchCancellation?.Cancel();
            _searchCancellation?.Dispose();
            _searchCancellation = new CancellationTokenSource();
            CancellationToken token = _searchCancellation.Token;

            try
            {
                string url = "https://api.mapbox.com/search/searchbox/v1/suggest"
                      + $"?q={Uri.EscapeDataString(query)}"
                      + "&language=ar"
                      + "&country=eg"
                      + $"&session_token={_sessionToken}"
                      + $"&access_token={_mapboxToken}";

                HttpResponseMessage response = await _httpClient.GetAsync(url, token);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                var parsed = JsonConvert.DeserializeObject<MapboxSuggestResponse>(json);
                var suggestions = parsed?.suggestions ?? new List<MapboxSuggestion>();
                var items = suggestions.Select(ToSuggestion).ToList();

                var groups = new List<SuggestionGroup>
                {
                    CreateGroup("⭐ Favorites", SuggestionStorage.LoadFavorites()),
                    CreateGroup("📍 Results", items),
                    CreateGroup("🕒 Recent", SuggestionStorage.LoadHistory())
                }
                .Where(g => g.Items.Any())
                .ToList();

                if (query != txtSearchBox.Text) return;
                suggestionList.LoadSuggestionsGrouped(groups);
            }
            catch (TaskCanceledException) {}
        }
        public void LoadFavoritesAndRecent()
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
        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) suggestionList.Visible = false;
        }
        private async void CurrentLocation(object sender, EventArgs e)
        {
            await _mapService.MoveToCurrentLocationAsync();
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
                string url = "https://api.mapbox.com/search/geocode/v6/reverse"
                    + $"?longitude={lon.ToString(CultureInfo.InvariantCulture)}"
                    + $"&latitude={lat.ToString(CultureInfo.InvariantCulture)}"
                    + "&language=ar"
                    + $"&access_token={_mapboxToken}";

                string json = await _httpClient.GetStringAsync(url);
                var parsed = JsonConvert.DeserializeObject<MapboxRetrieveResponse>(json);
                var props = parsed?.features?.FirstOrDefault()?.properties;
                var ctx = props?.context;

                return new AddAddressDto
                {
                    City = ctx?.place?.name ?? string.Empty,
                    State = ctx?.region?.name ?? string.Empty,
                    ZipCode = ctx?.postcode?.name ?? string.Empty,
                    Country = ctx?.country?.name ?? string.Empty,
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
                _mapService.OnPointConfirmed += async (lat,lon) => await ResolveAndRaiseAddressAsync(lat, lon);
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
