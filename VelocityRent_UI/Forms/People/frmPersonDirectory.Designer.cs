namespace Velocity_Rent.Forms.People
{
    partial class frmPersonDirectory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonDirectory));
            this.sataEllipseControl1 = new SATAUiFramework.Controls.SATAEllipseControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this._btnAddPerson = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this._cmbSort = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this._cmbActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.plMain = new System.Windows.Forms.Panel();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this._personGrid = new Velocity_Rent.Controls.Directory.ucDirectory();
            this._searchDebounce = new System.Windows.Forms.Timer(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.plMain.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sataEllipseControl1
            // 
            this.sataEllipseControl1.CornerRadius = 15;
            this.sataEllipseControl1.TargetControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(48, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(223, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "Directory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.label3.Location = new System.Drawing.Point(135, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "List of Registered Individuals";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox1.BorderRadius = 12;
            this.guna2GroupBox1.Controls.Add(this._btnAddPerson);
            this.guna2GroupBox1.Controls.Add(this._cmbSort);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this._cmbActive);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this._txtSearch);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.guna2GroupBox1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(48, 127);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(866, 80);
            this.guna2GroupBox1.TabIndex = 4;
            // 
            // _btnAddPerson
            // 
            this._btnAddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddPerson.BackColor = System.Drawing.Color.WhiteSmoke;
            this._btnAddPerson.BorderRadius = 7;
            this._btnAddPerson.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this._btnAddPerson.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this._btnAddPerson.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this._btnAddPerson.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this._btnAddPerson.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this._btnAddPerson.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(74)))), ((int)(((byte)(14)))));
            this._btnAddPerson.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this._btnAddPerson.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this._btnAddPerson.ForeColor = System.Drawing.Color.White;
            this._btnAddPerson.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this._btnAddPerson.ImageSize = new System.Drawing.Size(0, 0);
            this._btnAddPerson.Location = new System.Drawing.Point(684, 30);
            this._btnAddPerson.Name = "_btnAddPerson";
            this._btnAddPerson.Size = new System.Drawing.Size(168, 38);
            this._btnAddPerson.TabIndex = 162;
            this._btnAddPerson.Text = "+ Add New Person";
            this._btnAddPerson.TextFormatNoPrefix = true;
            // 
            // _cmbSort
            // 
            this._cmbSort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._cmbSort.BackColor = System.Drawing.Color.WhiteSmoke;
            this._cmbSort.BorderColor = System.Drawing.Color.Gray;
            this._cmbSort.BorderRadius = 9;
            this._cmbSort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbSort.FillColor = System.Drawing.Color.WhiteSmoke;
            this._cmbSort.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._cmbSort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._cmbSort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._cmbSort.ForeColor = System.Drawing.Color.Black;
            this._cmbSort.ItemHeight = 30;
            this._cmbSort.Items.AddRange(new object[] {
            "Name(A-Z)"});
            this._cmbSort.Location = new System.Drawing.Point(514, 32);
            this._cmbSort.Name = "_cmbSort";
            this._cmbSort.Size = new System.Drawing.Size(145, 36);
            this._cmbSort.StartIndex = 0;
            this._cmbSort.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.label6.Location = new System.Drawing.Point(515, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Sort By";
            // 
            // _cmbActive
            // 
            this._cmbActive.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._cmbActive.BackColor = System.Drawing.Color.WhiteSmoke;
            this._cmbActive.BorderColor = System.Drawing.Color.Gray;
            this._cmbActive.BorderRadius = 9;
            this._cmbActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cmbActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbActive.FillColor = System.Drawing.Color.WhiteSmoke;
            this._cmbActive.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._cmbActive.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._cmbActive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._cmbActive.ForeColor = System.Drawing.Color.Black;
            this._cmbActive.ItemHeight = 30;
            this._cmbActive.Items.AddRange(new object[] {
            "City / Coverment"});
            this._cmbActive.Location = new System.Drawing.Point(305, 32);
            this._cmbActive.Name = "_cmbActive";
            this._cmbActive.Size = new System.Drawing.Size(184, 36);
            this._cmbActive.StartIndex = 0;
            this._cmbActive.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.label5.Location = new System.Drawing.Point(306, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Filter By";
            // 
            // _txtSearch
            // 
            this._txtSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this._txtSearch.BorderColor = System.Drawing.Color.Gray;
            this._txtSearch.BorderRadius = 9;
            this._txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtSearch.DefaultText = "";
            this._txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this._txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this._txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this._txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this._txtSearch.FillColor = System.Drawing.Color.WhiteSmoke;
            this._txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("_txtSearch.IconLeft")));
            this._txtSearch.IconLeftOffset = new System.Drawing.Point(10, 0);
            this._txtSearch.Location = new System.Drawing.Point(18, 30);
            this._txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this._txtSearch.PlaceholderText = "Search by name, ID, or phone...\n";
            this._txtSearch.SelectedText = "";
            this._txtSearch.Size = new System.Drawing.Size(262, 38);
            this._txtSearch.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.label4.Location = new System.Drawing.Point(19, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Search Bar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.label1.Location = new System.Drawing.Point(131, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person";
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.plMain.Controls.Add(this.guna2GroupBox2);
            this.plMain.Controls.Add(this.label1);
            this.plMain.Controls.Add(this.guna2GroupBox1);
            this.plMain.Controls.Add(this.label3);
            this.plMain.Controls.Add(this.label2);
            this.plMain.Controls.Add(this.pictureBox1);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(958, 743);
            this.plMain.TabIndex = 5;
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.guna2GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox2.BorderRadius = 12;
            this.guna2GroupBox2.BorderThickness = 3;
            this.guna2GroupBox2.Controls.Add(this._personGrid);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox2.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.guna2GroupBox2.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox2.Location = new System.Drawing.Point(46, 230);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(866, 506);
            this.guna2GroupBox2.TabIndex = 6;
            // 
            // _personGrid
            // 
            this._personGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this._personGrid.BackColor = System.Drawing.Color.White;
            this._personGrid.Location = new System.Drawing.Point(3, 3);
            this._personGrid.MinimumSize = new System.Drawing.Size(500, 250);
            this._personGrid.Name = "_personGrid";
            this._personGrid.Padding = new System.Windows.Forms.Padding(3);
            this._personGrid.PageSize = 10;
            this._personGrid.Size = new System.Drawing.Size(860, 500);
            this._personGrid.TabIndex = 5;
            // 
            // _searchDebounce
            // 
            this._searchDebounce.Interval = 250;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this._personGrid;
            // 
            // frmPersonDirectory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(958, 743);
            this.Controls.Add(this.plMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPersonDirectory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.plMain.ResumeLayout(false);
            this.plMain.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SATAUiFramework.Controls.SATAEllipseControl sataEllipseControl1;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2GradientTileButton _btnAddPerson;
        private Guna.UI2.WinForms.Guna2ComboBox _cmbSort;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox _cmbActive;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox _txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controls.Directory.ucDirectory _personGrid;
        private System.Windows.Forms.Timer _searchDebounce;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}