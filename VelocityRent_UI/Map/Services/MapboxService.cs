using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velocity_Rent.Map.Services.Interfaces;

namespace Velocity_Rent.Map.Services
{
    public class MapboxService : IMapService
    {
        private WebView2 _webView;
        private bool _isInitialized = false;
        public bool IsMapReady { get; private set; }

        public async Task InitializeAsync(WebView2 webView)
        {
            if(_isInitialized) return;  

            _isInitialized = true;
            _webView = webView;

            await _webView.EnsureCoreWebView2Async();
            _webView.WebMessageReceived += OnMessageRecived;
            await webView.CoreWebView2.Profile.ClearBrowsingDataAsync(Microsoft.Web.WebView2.Core.CoreWebView2BrowsingDataKinds.AllSite);
            string mapPath = Path.Combine(System.Windows.Forms.Application.StartupPath, @"map\Services\WebFiles", "map.html");
            _webView.Source = new Uri(mapPath);
        }
        private void OnMessageRecived(object sender , CoreWebView2WebMessageReceivedEventArgs e )
        {
            if (e.TryGetWebMessageAsString() == "MAP_READY") IsMapReady = true;
        }
        public async Task MoveToAsync(double lat,double lon,int zoom = 14)
        {
            if (!IsMapReady) return;

            string latString = lat.ToString("F6", CultureInfo.InvariantCulture);
            string lonString = lon.ToString("F6", CultureInfo.InvariantCulture);

            string script = $"window.moveMap({latString},{lonString},{zoom})";
            await _webView.CoreWebView2.ExecuteScriptAsync(script);
        }
    }
}
