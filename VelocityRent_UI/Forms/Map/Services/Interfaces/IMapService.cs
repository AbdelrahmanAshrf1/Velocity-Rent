using Microsoft.Web.WebView2.WinForms;
using System.Threading.Tasks;

namespace Velocity_Rent.Map.Services.Interfaces
{
    public interface IMapService
    {
        bool IsMapReady { get; }
        Task InitializeAsync(WebView2 webView);
        Task MoveToAsync(double lat, double lon, int zoom = 14);
    }
}
