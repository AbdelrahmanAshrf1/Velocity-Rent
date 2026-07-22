using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Velocity_Rent.Map.Services.Interfaces;

namespace Velocity_Rent.Map.Services
{
    public class MapboxService : IMapService
    {
        private WebView2 _webView;
        private bool _isInitialized = false;
        public bool IsMapReady { get; private set; }
        public event Action<double, double> OnPointConfirmed;

        public async Task InitializeAsync(WebView2 webView)
        {
            if(_isInitialized) return;  

            _isInitialized = true;
            _webView = webView;

            await _webView.EnsureCoreWebView2Async();
            string token = ConfigurationManager.AppSettings["MapboxAccessToken"];
            _webView.WebMessageReceived += OnMessageRecived;
            await webView.CoreWebView2.Profile.ClearBrowsingDataAsync(Microsoft.Web.WebView2.Core.CoreWebView2BrowsingDataKinds.AllSite);
            string mapPath = Path.Combine(Application.StartupPath,@"Forms\Map\Services\WebFiles","map.html");
            await _webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(
                $"window.mapboxToken = '{token}';");

            _webView.Source = new Uri(mapPath);
        }
        private void OnMessageRecived(object sender , CoreWebView2WebMessageReceivedEventArgs e )
        {
            string message = e.TryGetWebMessageAsString();

            if (message == "MAP_READY")
            { 
                IsMapReady = true;
                return;
            }

            try
            {
                var parsed = JsonConvert.DeserializeObject<JObject>(message);
                string type = parsed["type"]?.ToString();

                if(type == "PIN_SELECTED")
                {
                    double lat = parsed["lat"].Value<double>();
                    double lon = parsed["lon"].Value<double>();
                    OnPointConfirmed?.Invoke(lat, lon);
                }
            }
            catch
            {}
        }
        public async Task MoveToAsync(double lat,double lon,int zoom = 14)
        {
            if (!IsMapReady) return;

            string latString = lat.ToString("F6", CultureInfo.InvariantCulture);
            string lonString = lon.ToString("F6", CultureInfo.InvariantCulture);

            string script = $"window.moveMap({latString},{lonString},{zoom})";
            await _webView.CoreWebView2.ExecuteScriptAsync(script);
        }

        public async Task MoveToCurrentLocationAsync()
        {
            if (!IsMapReady) return;
            await _webView.CoreWebView2.ExecuteScriptAsync("moveToCurrentLocation();");
        }
    }
}
