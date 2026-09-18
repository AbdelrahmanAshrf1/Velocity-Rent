using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
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

            pnlFlow.HandleCreated += (s, e) => HideVerticalScrollBar();
            pnlFlow.SizeChanged += (s, e) => HideVerticalScrollBar();
            pnlFlow.Layout += (s, e) => HideVerticalScrollBar();
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
            HideVerticalScrollBar();
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
        private const int _minListHeight = 60;
        private const int _maxListHeight = 520;
        private const int SB_VERT = 1;

        [DllImport("user32.dll")]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
        private void HideVerticalScrollBar()
        {
            if (pnlFlow.IsHandleCreated) ShowScrollBar(pnlFlow.Handle, SB_VERT, false);
        }
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
                Margin = new Padding(0, 6, 0, 6),
                Width = pnlFlow.ClientSize.Width
            };
        }
        private int CalculateHeight()
        {
            int totalHeight = pnlFlow.PreferredSize.Height + Padding.Vertical;
            return Math.Min(_maxListHeight, Math.Max(_minListHeight, totalHeight));
        }
        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            int diff = _targetHeight - Height;

            if (Math.Abs(diff) < 3)
            {
                Height = _targetHeight;
                _animationTimer.Stop();

                if (_targetHeight == 0)
                    Visible = false;

                return;
            }

            Height += diff / 4;
        }
        private void ShowAnimated(int targetHeight)
        {
            if(this.Height ==  targetHeight && this.Visible) return;

            this.BringToFront();
            this.Visible = true;
            _animationTimer.Stop();
            _targetHeight = targetHeight;
            _animationTimer.Start();
        }
        private void HideAnimated()
        {
            _animationTimer.Stop();
            _targetHeight = 0;
            _animationTimer.Start();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            foreach (Control control in pnlFlow.Controls)
            {
                control.Width = pnlFlow.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            }
        }
        #endregion

    }
}
