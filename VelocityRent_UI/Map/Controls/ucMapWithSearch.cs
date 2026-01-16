using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        private IMapService _mapService;
        public ucMapWithSearch()
        {
            InitializeComponent();
            SetupSuggestionList();
        }
        public class NominatimResult
        {
            public string display_name { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
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
            suggestionList.OnSuggestionSelected += (item) =>
            {
                txtSearchBox.Text = item.Title;

                if (item.Lat.HasValue && item.Lon.HasValue)
                    _mapService.MoveToAsync(item.Lat.Value, item.Lon.Value);

                suggestionList.Visible = false;
            };
        }

        private async void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearchBox.Text;

            if (string.IsNullOrWhiteSpace(query))
                LoadFavoritesAndRecent();

            if (query.Length < 2)
            {
                suggestionList.Visible = false;
                return;
            }

            await LoadSuggestionsAsync(query);
        }
        private void LoadFavoritesAndRecent()
        {
            var Groups = new List<SuggestionGroup>()
            {
                CreateGroup("⭐ Favorites",SuggestionStorage.LoadFavorites()),
                CreateGroup("🕒 Recent",SuggestionStorage.LoadHistory()),
            }.Where(group => group.Items.Any()).ToList();

            if (Groups.Any())
                suggestionList.LoadSuggestionsGrouped(Groups);
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
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0)");
                    client.DefaultRequestHeaders.Add("Accept-Language", "en");

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
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("https://ipinfo.io/json");

                    dynamic info = JsonConvert.DeserializeObject(json);
                    string loc = info.loc;

                    string[] parts = loc.Split(',');
                    double lat = double.Parse(parts[0]);
                    double lon = double.Parse(parts[1]);

                    _mapService.MoveToAsync(lat, lon);
                }
            }
            catch
            {
                MessageBox.Show("Unable to detect current location.");
            }
        }
        private async void ucMapWithSearch_Load(object sender, EventArgs e)
        {
            _mapService = new MapboxService();
            await _mapService.InitializeAsync(webView21);
        }
    }
   }
