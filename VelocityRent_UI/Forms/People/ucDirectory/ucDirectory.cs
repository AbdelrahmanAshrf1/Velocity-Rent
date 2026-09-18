using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Styles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Velocity_Rent.Controls.Directory
{
    /// <summary>
    /// Reusable grid + row actions + images + pagination.
    /// Configure<T>() defines the columns/actions once.
    /// SetData<T>() replaces the current rows.
    /// </summary>
    public class ucDirectory : UserControl
    {
        private const string ItemColumnName = "__DirectoryItem";
        private const string ActionPrefix = "__Action_";

        private DataTable _table;

        private readonly List<DirectoryColumnRuntime> _columns = new List<DirectoryColumnRuntime>();

        private readonly Dictionary<string, DirectoryActionRuntime> _actions =
            new Dictionary<string, DirectoryActionRuntime>(StringComparer.OrdinalIgnoreCase);

        private readonly List<Image> _generatedImages = new List<Image>();

        private int _pageSize = 10;
        private int _currentPage = 1;
        private int _totalPages = 1;

        private static readonly Color AccentDark = Color.FromArgb(223, 128, 12);

        private static readonly Color Border = Color.FromArgb(225, 226, 230);

        private static readonly Color Text = Color.FromArgb(35, 38, 43);

        private static readonly Color Muted = Color.FromArgb(105, 108, 116);

        private static readonly Color Surface = Color.White;

        private SfDataGrid _grid;
        private Label lblSummary;
        private Guna2GradientTileButton btnNext;
        private Guna2GradientTileButton btnBack;
        private FlowLayoutPanel _pagesPanel;

        public event EventHandler<DirectoryRowActionEventArgs> ActionClicked;

        public int PageSize
        {
            get { return _pageSize; }

            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value");

                _pageSize = value;
                _currentPage = 1;
                RebuildPage();
            }
        }

        public ucDirectory()
        {
            InitializeComponent();

            btnBack.Click += delegate
            {
                GoToPage(_currentPage - 1);
            };

            btnNext.Click += delegate
            {
                GoToPage(_currentPage + 1);
            };
        }

        public void Configure<T>(
            IEnumerable<DirectoryColumn<T>> columns,
            params DirectoryAction<T>[] actions)
        {
            if (columns == null)
                throw new ArgumentNullException("columns");

            var columnList = columns.ToList();

            var actionList = actions == null
                ? new List<DirectoryAction<T>>()
                : actions.ToList();

            if (columnList.Count == 0)
                throw new InvalidOperationException(
                    "At least one directory column is required.");

            if (columnList
                .GroupBy(x => x.Key, StringComparer.OrdinalIgnoreCase)
                .Any(g => g.Count() > 1))
            {
                throw new InvalidOperationException(
                    "Duplicate directory column key.");
            }

            if (actionList
                .GroupBy(x => x.Key, StringComparer.OrdinalIgnoreCase)
                .Any(g => g.Count() > 1))
            {
                throw new InvalidOperationException(
                    "Duplicate directory action key.");
            }

            ClearGeneratedImages();

            _columns.Clear();
            _actions.Clear();

            foreach (var column in columnList)
            {
                _columns.Add(new DirectoryColumnRuntime
                {
                    Key = column.Key,
                    HeaderText = column.HeaderText,
                    Width = column.Width,
                    Type = column.Type,
                    Value = item => column.Value((T)item),
                    PlaceholderImage = column.PlaceholderImage,
                    ImageSize = column.ImageSize
                });
            }

            foreach (var action in actionList)
            {
                _actions[GetActionMapping(action.Key)] =
                    new DirectoryActionRuntime
                    {
                        Key = action.Key,
                        Text = action.Text,
                        Width = action.Width,
                        IsEnabled = action.IsEnabled == null
                            ? null
                            : new Func<object, bool>(
                                item => action.IsEnabled((T)item))
                    };
            }

            _table = null;

            _grid.Columns.Clear();

            _currentPage = 1;
            _totalPages = 1;

            RebuildPage();
        }

        public void SetData<T>(IEnumerable<T> items)
        {
            if (_columns.Count == 0)
            {
                throw new InvalidOperationException(
                    "Call Configure<T>() before SetData<T>().");
            }

            BuildTable(
                (items ?? Enumerable.Empty<T>()).ToList());

            _currentPage = 1;

            _grid.Columns.Clear();

            RebuildPage();
        }

        private void BuildTable<T>(IList<T> items)
        {
            ClearGeneratedImages();

            _table = new DataTable();

            _table.Columns.Add(
                ItemColumnName,
                typeof(object));

            foreach (var column in _columns)
            {
                var dataColumn = _table.Columns.Add(
                    column.Key,
                    column.Type == DirectoryColumnType.Image
                        ? typeof(Image)
                        : typeof(string));

                dataColumn.ExtendedProperties["HeaderText"] =
                    column.HeaderText;

                dataColumn.ExtendedProperties["Width"] =
                    column.Width;
            }

            foreach (var pair in _actions)
            {
                var dataColumn = _table.Columns.Add(
                    pair.Key,
                    typeof(string));

                dataColumn.ExtendedProperties["HeaderText"] =
                    string.Empty;

                dataColumn.ExtendedProperties["Width"] =
                    pair.Value.Width;
            }

            foreach (var item in items)
            {
                var row = _table.NewRow();

                row[ItemColumnName] = item;

                foreach (var column in _columns)
                {
                    object value = column.Value(item);

                    if (column.Type == DirectoryColumnType.Image)
                    {
                        var image = CreateDirectoryImage(
                            value,
                            column.PlaceholderImage,
                            column.ImageSize);

                        row[column.Key] =
                            image == null
                                ? (object)DBNull.Value
                                : image;
                    }
                    else
                    {
                        row[column.Key] =
                            value == null
                                ? string.Empty
                                : Convert.ToString(value);
                    }
                }

                foreach (var pair in _actions)
                {
                    row[pair.Key] = pair.Value.Text;
                }

                _table.Rows.Add(row);
            }
        }

        public void RefreshData<T>(IEnumerable<T> items)
        {
            SetData(items);
        }

        private void EnsureGridColumns()
        {
            if (_grid.Columns.Count > 0)
                return;

            foreach (DataColumn column in _table.Columns)
            {
                if (column.ColumnName == ItemColumnName)
                    continue;

                DirectoryActionRuntime action;

                if (_actions.TryGetValue(
                    column.ColumnName,
                    out action))
                {
                    _grid.Columns.Add(
                        new GridButtonColumn
                        {
                            MappingName = column.ColumnName,
                            HeaderText = string.Empty,
                            Width = action.Width,
                            AllowSorting = false
                        });

                    continue;
                }

                string header =
                    Convert.ToString(
                        column.ExtendedProperties["HeaderText"]
                        ?? column.ColumnName);

                int width =
                    column.ExtendedProperties.ContainsKey("Width")
                        ? Convert.ToInt32(
                            column.ExtendedProperties["Width"])
                        : 100;

                if (column.DataType == typeof(Image))
                {
                    var gridImageColumn =
                        new GridImageColumn
                        {
                            MappingName = column.ColumnName,
                            HeaderText = header,
                            Width = width,
                            ImageLayout = ImageLayout.Center
                        };

                    _grid.Columns.Add(gridImageColumn);
                }
                else
                {
                    _grid.Columns.Add(
                        new GridTextColumn
                        {
                            MappingName = column.ColumnName,
                            HeaderText = header,
                            Width = width,
                            AllowSorting = false
                        });
                }
            }
        }

        private void RebuildPage()
        {
            if (_table == null)
            {
                _grid.DataSource = null;
                UpdatePager(0);
                return;
            }

            _totalPages =
                Math.Max(
                    1,
                    (int)Math.Ceiling(
                        _table.Rows.Count /
                        (double)_pageSize));

            if (_currentPage > _totalPages)
                _currentPage = _totalPages;

            EnsureGridColumns();

            int first =
                (_currentPage - 1) * _pageSize;

            var pageRows =
                _table
                    .AsEnumerable()
                    .Skip(first)
                    .Take(_pageSize)
                    .ToList();

            var pageTable = _table.Clone();

            foreach (var row in pageRows)
            {
                pageTable.ImportRow(row);
            }

            _grid.DataSource =
                pageTable.DefaultView;

            UpdatePager(_table.Rows.Count);
        }

        private void Grid_CellButtonClick( object sender, CellButtonClickEventArgs e)
        {
            if (e == null || e.Column == null) return;

            DirectoryActionRuntime action;

            if (!_actions.TryGetValue(e.Column.MappingName,out action)) return;


            object item = null;

            var dataRow = e.Record as Syncfusion.WinForms.DataGrid.DataRow;

            if (dataRow != null)
            {
                var rowView = dataRow.RowData as DataRowView;

                if (rowView != null &&
                    rowView.Row != null &&
                    rowView.Row.Table.Columns.Contains(ItemColumnName))
                {
                    item = rowView.Row[ItemColumnName];
                }
            }

            if (item == null ||
                item == DBNull.Value)
            {
                return;
            }

            if (action.IsEnabled != null && !action.IsEnabled(item)) return;

            var handler = ActionClicked;

            if (handler != null)
            {
                handler(this, new DirectoryRowActionEventArgs(item, action.Key));
            }
        }

        private void Grid_QueryButtonCellStyle(
            object sender,
            QueryButtonCellStyleEventArgs e)
        {
            if (e.Column == null ||
                !_actions.ContainsKey(
                    e.Column.MappingName))
            {
                return;
            }

            e.Style.BackColor =
                Color.FromArgb(255, 252, 247);

            e.Style.TextColor =
                AccentDark;
        }

        private void Grid_QueryImageCellStyle(
            object sender,
            QueryImageCellStyleEventArgs e)
        {
            if (e == null ||
                e.Column == null)
            {
                return;
            }

            /*
             * THIS IS THE IMPORTANT FIX.
             *
             * SfDataGrid gives us the DataRowView through e.Record.
             * The actual Image is stored inside the DataTable.
             * We explicitly give that Image to Syncfusion.
             */
            var rowView =
                e.Record as DataRowView;

            if (rowView == null ||
                rowView.Row == null)
            {
                return;
            }

            string mappingName =
                e.Column.MappingName;

            if (string.IsNullOrWhiteSpace(mappingName))
                return;

            if (!rowView.Row.Table.Columns.Contains(
                mappingName))
            {
                return;
            }

            object value =
                rowView.Row[mappingName];

            if (value == null ||
                value == DBNull.Value)
            {
                return;
            }

            var image =
                value as Image;

            if (image == null)
                return;

            e.Image = image;

            e.ImageLayout =
                ImageLayout.Center;

            // Prevent the underlying value from being
            // displayed as text beside the image.
            e.DisplayText =
                string.Empty;
        }

        private void Grid_QueryCellStyle(
            object sender,
            QueryCellStyleEventArgs e)
        {
            if (e.Column != null &&
                _actions.ContainsKey(
                    e.Column.MappingName))
            {
                e.Style.HorizontalAlignment =
                    HorizontalAlignment.Center;
            }
        }

        private void UpdatePager(int count)
        {
            int start =
                count == 0
                    ? 0
                    : ((_currentPage - 1) *
                       _pageSize) + 1;

            int end =
                count == 0
                    ? 0
                    : Math.Min(
                        _currentPage * _pageSize,
                        count);

            lblSummary.Text =
                string.Format(
                    "Showing {0}-{1} of {2} entries",
                    start,
                    end,
                    count);

            btnBack.Enabled =
                _currentPage > 1;

            btnNext.Enabled =
                _currentPage < _totalPages;

            _pagesPanel.Controls.Clear();

            foreach (int page in BuildPageNumbers())
            {
                _pagesPanel.Controls.Add(
                    CreatePageButton(page));
            }
        }

        private IEnumerable<int> BuildPageNumbers()
        {
            if (_totalPages <= 5)
            {
                for (int i = 1;
                    i <= _totalPages;
                    i++)
                {
                    yield return i;
                }

                yield break;
            }

            yield return 1;

            if (_currentPage > 3)
                yield return -1;

            int from =
                Math.Max(
                    2,
                    _currentPage - 1);

            int to =
                Math.Min(
                    _totalPages - 1,
                    _currentPage + 1);

            for (int i = from;
                i <= to;
                i++)
            {
                yield return i;
            }

            if (_currentPage <
                _totalPages - 2)
            {
                yield return -1;
            }

            yield return _totalPages;
        }

        private Guna2GradientTileButton CreatePageButton(
            int page)
        {
            if (page == -1)
            {
                return new Guna2GradientTileButton
                {
                    Text = "...",
                    Width = 32,
                    Height = 30,
                    BorderRadius = 7,
                    FillColor = Surface,
                    ForeColor = Muted,
                    Font = new Font(
                        "Segoe UI",
                        8.5F),
                    Margin =
                        new Padding(
                            2, 0, 2, 0),
                    TextFormatNoPrefix = true,
                    BorderThickness = 0
                };
            }

            bool selected =
                page == _currentPage;

            var button =
                new Guna2GradientTileButton
                {
                    Text = page.ToString(),
                    Width = 32,
                    Height = 30,
                    BorderRadius = 7,

                    FillColor =
                        selected
                            ? Color.FromArgb(
                                211, 74, 14)
                            : Surface,

                    FillColor2 =
                        selected
                            ? Color.FromArgb(
                                210, 130, 0)
                            : Surface,

                    ForeColor =
                        selected
                            ? Color.White
                            : Text,

                    Font =
                        new Font(
                            "Segoe UI Semibold",
                            8.5F,
                            FontStyle.Bold),

                    Margin =
                        new Padding(
                            2, 0, 2, 0),

                    Tag = page,

                    TextFormatNoPrefix = true,

                    GradientMode =
                        LinearGradientMode
                            .BackwardDiagonal,

                    BorderThickness =
                        selected ? 0 : 1,

                    BorderColor = Border
                };

            if (!selected)
            {
                button.HoverState.FillColor =
                    Color.FromArgb(
                        255, 247, 237);

                button.HoverState.ForeColor =
                    AccentDark;

                button.HoverState.BorderColor =
                    Color.FromArgb(
                        205, 168, 120);
            }

            button.Click += delegate
            {
                GoToPage(
                    (int)button.Tag);
            };

            return button;
        }

        private void GoToPage(int page)
        {
            if (page < 1 ||
                page > _totalPages ||
                page == _currentPage)
            {
                return;
            }

            _currentPage = page;

            RebuildPage();
        }

        private Image CreateDirectoryImage(
            object value,
            Image placeholder,
            int size)
        {
            Image source =
                value as Image;

            if (source == null &&
                value is string)
            {
                string path =
                    Convert.ToString(value);

                if (!string.IsNullOrWhiteSpace(path) &&
                    System.IO.File.Exists(path))
                {
                    try
                    {
                        using (var loaded =
                            Image.FromFile(path))
                        {
                            source =
                                new Bitmap(loaded);
                        }
                    }
                    catch
                    {
                        source = null;
                    }
                }
            }

            if (source == null)
                source = placeholder;

            if (source == null)
                return CreateFallbackAvatar(size);

            return CreateCircularImage(
                source,
                size);
        }

        private Image CreateFallbackAvatar(
            int size)
        {
            var bitmap =
                new Bitmap(
                    size,
                    size,
                    PixelFormat.Format32bppArgb);

            using (var g =
                Graphics.FromImage(bitmap))
            using (var bg =
                new SolidBrush(
                    Color.FromArgb(
                        237, 238, 240)))
            using (var gray =
                new SolidBrush(
                    Color.FromArgb(
                        183, 186, 192)))
            {
                g.SmoothingMode =
                    SmoothingMode.AntiAlias;

                g.FillEllipse(
                    bg,
                    0,
                    0,
                    size - 1,
                    size - 1);

                g.FillEllipse(
                    gray,
                    size * .34F,
                    size * .18F,
                    size * .32F,
                    size * .32F);

                g.FillEllipse(
                    gray,
                    size * .19F,
                    size * .52F,
                    size * .62F,
                    size * .35F);
            }

            _generatedImages.Add(bitmap);

            return bitmap;
        }

        private Image CreateCircularImage(
            Image source,
            int size)
        {
            var result =
                new Bitmap(
                    size,
                    size,
                    PixelFormat.Format32bppArgb);

            using (var g =
                Graphics.FromImage(result))
            using (var path =
                new GraphicsPath())
            {
                g.SmoothingMode =
                    SmoothingMode.AntiAlias;

                g.InterpolationMode =
                    InterpolationMode
                        .HighQualityBicubic;

                path.AddEllipse(
                    0,
                    0,
                    size - 1,
                    size - 1);

                g.SetClip(path);

                double scale =
                    Math.Max(
                        (double)size /
                        source.Width,
                        (double)size /
                        source.Height);

                int drawWidth =
                    (int)Math.Ceiling(
                        source.Width * scale);

                int drawHeight =
                    (int)Math.Ceiling(
                        source.Height * scale);

                int x =
                    (size - drawWidth) / 2;

                int y =
                    (size - drawHeight) / 2;

                g.DrawImage(
                    source,
                    new Rectangle(
                        x,
                        y,
                        drawWidth,
                        drawHeight));
            }

            _generatedImages.Add(result);

            return result;
        }

        private void ClearGeneratedImages()
        {
            foreach (var image in _generatedImages)
            {
                try
                {
                    image.Dispose();
                }
                catch
                {
                }
            }

            _generatedImages.Clear();
        }

        private static string GetActionMapping(
            string key)
        {
            return ActionPrefix + key;
        }

        protected override void Dispose(
            bool disposing)
        {
            if (disposing)
            {
                ClearGeneratedImages();

                if (_grid != null)
                {
                    _grid.CellButtonClick -=
                        Grid_CellButtonClick;

                    _grid.QueryButtonCellStyle -=
                        Grid_QueryButtonCellStyle;

                    _grid.QueryImageCellStyle -=
                        Grid_QueryImageCellStyle;

                    _grid.QueryCellStyle -=
                        Grid_QueryCellStyle;
                }
            }

            base.Dispose(disposing);
        }

        private sealed class DirectoryColumnRuntime
        {
            public string Key;
            public string HeaderText;
            public int Width;
            public DirectoryColumnType Type;
            public Func<object, object> Value;
            public Image PlaceholderImage;
            public int ImageSize;
        }

        private sealed class DirectoryActionRuntime
        {
            public string Key;
            public string Text;
            public int Width;
            public Func<object, bool> IsEnabled;
        }

        private void InitializeComponent()
        {
            this._grid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.lblSummary = new System.Windows.Forms.Label();
            this.btnNext = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.btnBack = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this._pagesPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AccessibleName = "Table";
            this._grid.AllowEditing = false;
            this._grid.AllowSorting = false;
            this._grid.AutoGenerateColumns = false;
            this._grid.HeaderRowHeight = 40;
            this._grid.Location = new System.Drawing.Point(0, 0);
            this._grid.Name = "_grid";
            this._grid.PreviewRowHeight = 85;
            this._grid.RowHeaderWidth = 40D;
            this._grid.RowHeight = 58;
            this._grid.Size = new System.Drawing.Size(860, 433);
            this._grid.Style.CellStyle.BackColor = System.Drawing.Color.White;
            this._grid.Style.CellStyle.Font.Facename = "Segoe UI";
            this._grid.Style.CellStyle.Font.Size = 9F;
            this._grid.Style.CellStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this._grid.Style.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this._grid.Style.HeaderStyle.FilterIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this._grid.Style.HeaderStyle.Font.Bold = true;
            this._grid.Style.HeaderStyle.Font.Facename = "Segoe UI Semibold";
            this._grid.Style.HeaderStyle.Font.Size = 9F;
            this._grid.Style.HeaderStyle.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this._grid.Style.HeaderStyle.TextColor = System.Drawing.Color.Black;
            this._grid.Style.SelectionStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this._grid.Style.SelectionStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this._grid.TabIndex = 0;
            this._grid.Text = "sfDataGrid1";
            this._grid.QueryCellStyle += new Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventHandler(this.Grid_QueryCellStyle);
            this._grid.QueryButtonCellStyle += new Syncfusion.WinForms.DataGrid.Events.QueryButtonCellStyleEventHandler(this.Grid_QueryButtonCellStyle);
            this._grid.CellButtonClick += new Syncfusion.WinForms.DataGrid.Events.CellButtonClickEventHandler(this.Grid_CellButtonClick);
            this._grid.QueryImageCellStyle += new Syncfusion.WinForms.DataGrid.Events.QueryImageCellStyleEventHandler(this.Grid_QueryImageCellStyle);
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(116)))));
            this.lblSummary.Location = new System.Drawing.Point(21, 458);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(48, 20);
            this.lblSummary.TabIndex = 1;
            this.lblSummary.Text = "label1";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(74)))), ((int)(((byte)(14)))));
            this.btnNext.BorderRadius = 15;
            this.btnNext.BorderThickness = 1;
            this.btnNext.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(74)))), ((int)(((byte)(14)))));
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.Transparent;
            this.btnNext.FillColor2 = System.Drawing.Color.Transparent;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnNext.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNext.ImageOffset = new System.Drawing.Point(9, 15);
            this.btnNext.ImageSize = new System.Drawing.Size(21, 21);
            this.btnNext.Location = new System.Drawing.Point(572, 454);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(93, 39);
            this.btnNext.TabIndex = 155;
            this.btnNext.Text = "Next >";
            this.btnNext.TextFormatNoPrefix = true;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(74)))), ((int)(((byte)(14)))));
            this.btnBack.BorderRadius = 15;
            this.btnBack.BorderThickness = 1;
            this.btnBack.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(74)))), ((int)(((byte)(14)))));
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.Transparent;
            this.btnBack.FillColor2 = System.Drawing.Color.Transparent;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBack.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBack.ImageOffset = new System.Drawing.Point(9, 15);
            this.btnBack.ImageSize = new System.Drawing.Size(21, 21);
            this.btnBack.Location = new System.Drawing.Point(233, 452);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(93, 41);
            this.btnBack.TabIndex = 156;
            this.btnBack.Text = "< Back";
            this.btnBack.TextFormatNoPrefix = true;
            // 
            // _pagesPanel
            // 
            this._pagesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pagesPanel.ForeColor = System.Drawing.Color.White;
            this._pagesPanel.Location = new System.Drawing.Point(348, 455);
            this._pagesPanel.Name = "_pagesPanel";
            this._pagesPanel.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this._pagesPanel.Size = new System.Drawing.Size(210, 35);
            this._pagesPanel.TabIndex = 157;
            this._pagesPanel.WrapContents = false;
            // 
            // ucDirectory
            // 
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this._pagesPanel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this._grid);
            this.Name = "ucDirectory";
            this.Size = new System.Drawing.Size(860, 500);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}