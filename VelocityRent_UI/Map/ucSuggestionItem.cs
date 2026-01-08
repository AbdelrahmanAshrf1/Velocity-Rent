using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Velocity_Rent.Properties;

namespace Velocity_Rent.Map.Controls
{
    public partial class ucSuggestionItem : UserControl
    {
        public enum SuggestionType
        {
            Location,
            Recent,
            Favorite,
            Nearby
        }
        public class SuggestionItem
        {
            public string Title { get; set; }
            public string Subtitle { get; set; } = "";
            public SuggestionType Type { get; set; } = SuggestionType.Location;
            public bool IsFavorite { get; set; }
            public double? Lat { get; set; }
            public double? Lon { get; set; }
        }

        private SuggestionItem _item;

        // events for handling control clicks
        public event Action<SuggestionItem> SuggestionItemClicked;
        public event Action<SuggestionItem> FavoriteIconClicked;

        public ucSuggestionItem(SuggestionItem item)
        {
            InitializeComponent();
            SetupUI(item);
            ConnectClickEvent();
        }
        private void SetupUI(SuggestionItem item)
        {

            _item = item;
            lblIcon.Text = TypeToEmoji(item.Type);
            lblTitle.Text = item.Title;
            lblSubtitle.Text = item.Subtitle;
            pbFavorite.Image = (item.IsFavorite) ? Resources.heart_filled : Resources.heart_outLine;
        }
        private string TypeToEmoji(SuggestionType k)
        {
            switch (k)
            {
                case SuggestionType.Location:return "📍";
                case SuggestionType.Nearby:return "🧭";
                case SuggestionType.Recent:return "🕒";
                case SuggestionType.Favorite:return "⭐";
                default: return "📍";
            }
        }
        private void ConnectClickEvent()
        {
            foreach (Control control in this.Controls)
                if(control != pbFavorite) control.Click += OnSuggestionItemClicked;
        }

        private void OnSuggestionItemClicked(object sender , EventArgs e) => SuggestionItemClicked?.Invoke(_item);
        private void pbFavorite_Click(object sender, EventArgs e) => FavoriteIconClicked?.Invoke(_item);
    }
}
