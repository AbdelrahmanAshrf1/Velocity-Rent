using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Velocity_Rent.Map.Controls.ucSuggestionItem;

namespace Velocity_Rent.Map.Controls
{
     public partial class ucSuggestionsList : UserControl
     {
        public event Action<SuggestionItem> OnSuggestionSelected;
        public ucSuggestionsList()
        {
            InitializeComponent();

            this.BringToFront();
            this.Visible = false;
        }

        /// <summary>
        /// Load suggestions grouped into sections.
        /// Call with grouped items ( "Nearby", "Recent", "Favorites", and general results)
        /// </summary>
        public void LoadSuggestionsGrouped(List<SuggestionGroup> groups)
        {
            if (groups == null)
            {
                HideAnimated();
                return;
            }

            pnlFlow.SuspendLayout();
            pnlFlow.Controls.Clear();


            foreach (SuggestionGroup group in groups)
            {
                if (group.Items == null || group.Items.Count == 0) continue;

                pnlFlow.Controls.Add(CreateGroupHeader(group.Title));
                foreach (SuggestionItem item in group.Items) AddSuggestionItem(item);
            }

            pnlFlow.ResumeLayout();
            ShowAnimated(CalculateHeight());
        }

        private void AddSuggestionItem(SuggestionItem item)
        {
            var newItem = new ucSuggestionItem(item);

            newItem.SuggestionItemClicked += (selectedItem) =>
            {
                SuggestionStorage.SaveToHistory(selectedItem);
                HideAnimated();

                // Bubble up to Parent (Map)
                OnSuggestionSelected?.Invoke(selectedItem);
            };

            newItem.FavoriteIconClicked += (favItem) => SuggestionStorage.ToggleFavorite(favItem);

            // separator
            var sep = new Panel
            {
                Height = 2,
                Width = newItem.Width,
                BackColor = Color.FromArgb(18, 18, 22),
                Dock = DockStyle.Bottom,
                Margin = new Padding(0)
            };

            var outer = new Panel
            {
                Width = this.Width - this.Padding.Horizontal,
                Height = newItem.Height + sep.Height,
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };

            outer.Controls.Add(newItem);
            outer.Controls.Add(sep);

            pnlFlow.Controls.Add(outer);
        }

        #region Animation helpers

        // for animation
        private int _targetHeight = 0;
        private int _animationStep = 18;
        private const int _minListHeight = 60;
        private const int _maxListHeight = 320;
        private Control CreateGroupHeader(string groupTitle)
        {
            return new Label
            {
                Text = groupTitle,
                AutoSize = false,
                Height = 28,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(120, 120, 120),
                Padding = new Padding(8, 0, 0, 0),
                BackColor = Color.Transparent,
                Margin = new Padding(0, 6, 0, 6)
            };
        }
        private int CalculateHeight()
        {
            int totalHeight = pnlFlow.Padding.Vertical;

            foreach (Control c in pnlFlow.Controls)
            {
                if (!c.Visible) continue;
                totalHeight += c.Height + c.Margin.Vertical;
            }
            return Math.Min(_maxListHeight, Math.Max(_minListHeight, totalHeight));
        }
        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            if (Height < _targetHeight)
                Height = Math.Min(Height + _animationStep, _targetHeight);
            else if (Height > _targetHeight)
                Height = Math.Max(Height - _animationStep, _targetHeight);
            else
            {
                _animationTimer.Stop();
                if (_targetHeight == 0)this.Visible = false;
            }
        }
        private void ShowAnimated(int targetHeight)
        {
            if(this.Height ==  targetHeight && this.Visible) return;

            this.BringToFront();
            this.Visible = true;
            _targetHeight = targetHeight;
            _animationTimer.Start();
        }
        private void HideAnimated()
        {
            _targetHeight = 0;
            _animationTimer.Start();
        }

        #endregion

    }
}
