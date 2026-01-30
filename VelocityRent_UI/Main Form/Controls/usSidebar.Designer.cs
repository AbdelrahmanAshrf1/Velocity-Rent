namespace Velocity_Rent.Main_Form.Controls
{
    partial class usSidebar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usSidebar));
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.plIndicator = new System.Windows.Forms.Panel();
            this.pnlUserInfo = new System.Windows.Forms.Panel();
            this.sataPictureBox1 = new SATAUiFramework.Controls.SATAPictureBox();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnHome = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnUsers = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnCustomers = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnVehicles = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnBookings = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnMaintenance = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSettings = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnViewLinkedinProfile = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.pnlSidebar = new SATAUiFramework.SATAPanel();
            this.btnFindNearestCar = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.btnContactMe = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.btnLogOut = new Guna.UI2.WinForms.Guna2GradientTileButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sataPictureBox1)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(25, -20);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(137, 118);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // plIndicator
            // 
            this.plIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(1)))));
            this.plIndicator.Location = new System.Drawing.Point(2, 243);
            this.plIndicator.Name = "plIndicator";
            this.plIndicator.Size = new System.Drawing.Size(5, 41);
            this.plIndicator.TabIndex = 1;
            // 
            // pnlUserInfo
            // 
            this.pnlUserInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlUserInfo.Controls.Add(this.sataPictureBox1);
            this.pnlUserInfo.Controls.Add(this.lblUserRole);
            this.pnlUserInfo.Controls.Add(this.lblUserName);
            this.pnlUserInfo.Location = new System.Drawing.Point(-1, 76);
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.pnlUserInfo.Size = new System.Drawing.Size(190, 159);
            this.pnlUserInfo.TabIndex = 8;
            // 
            // sataPictureBox1
            // 
            this.sataPictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.sataPictureBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.sataPictureBox1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.sataPictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.sataPictureBox1.BorderSize = 2;
            this.sataPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sataPictureBox1.GradientAngle = 90F;
            this.sataPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("sataPictureBox1.Image")));
            this.sataPictureBox1.Location = new System.Drawing.Point(55, 4);
            this.sataPictureBox1.Name = "sataPictureBox1";
            this.sataPictureBox1.Size = new System.Drawing.Size(80, 80);
            this.sataPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sataPictureBox1.TabIndex = 11;
            this.sataPictureBox1.TabStop = false;
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.ForeColor = System.Drawing.Color.White;
            this.lblUserRole.Location = new System.Drawing.Point(53, 123);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(85, 16);
            this.lblUserRole.TabIndex = 10;
            this.lblUserRole.Text = "Administrator";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(30, 97);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 21);
            this.lblUserName.TabIndex = 9;
            this.lblUserName.Text = "Abd Elrahman";
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.btnHome.CheckedState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHome.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHome.FillColor = System.Drawing.Color.Transparent;
            this.btnHome.FillColor2 = System.Drawing.Color.Transparent;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHome.ImageOffset = new System.Drawing.Point(7, 0);
            this.btnHome.Location = new System.Drawing.Point(12, 243);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(177, 41);
            this.btnHome.TabIndex = 10;
            this.btnHome.Text = "Home";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnUsers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.btnUsers.CheckedState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btnUsers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUsers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUsers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUsers.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUsers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUsers.FillColor = System.Drawing.Color.Transparent;
            this.btnUsers.FillColor2 = System.Drawing.Color.Transparent;
            this.btnUsers.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUsers.ImageOffset = new System.Drawing.Point(7, 0);
            this.btnUsers.Location = new System.Drawing.Point(12, 300);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(177, 41);
            this.btnUsers.TabIndex = 11;
            this.btnUsers.Text = "Users";
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.btnCustomers.CheckedState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btnCustomers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustomers.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustomers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCustomers.FillColor = System.Drawing.Color.Transparent;
            this.btnCustomers.FillColor2 = System.Drawing.Color.Transparent;
            this.btnCustomers.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCustomers.ForeColor = System.Drawing.Color.White;
            this.btnCustomers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomers.ImageOffset = new System.Drawing.Point(7, 0);
            this.btnCustomers.Location = new System.Drawing.Point(12, 347);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(177, 41);
            this.btnCustomers.TabIndex = 12;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.TextOffset = new System.Drawing.Point(10, 0);
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnVehicles
            // 
            this.btnVehicles.BackColor = System.Drawing.Color.Transparent;
            this.btnVehicles.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.btnVehicles.CheckedState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btnVehicles.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVehicles.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVehicles.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVehicles.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVehicles.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVehicles.FillColor = System.Drawing.Color.Transparent;
            this.btnVehicles.FillColor2 = System.Drawing.Color.Transparent;
            this.btnVehicles.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnVehicles.ForeColor = System.Drawing.Color.White;
            this.btnVehicles.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnVehicles.ImageOffset = new System.Drawing.Point(7, 0);
            this.btnVehicles.Location = new System.Drawing.Point(12, 394);
            this.btnVehicles.Name = "btnVehicles";
            this.btnVehicles.Size = new System.Drawing.Size(177, 41);
            this.btnVehicles.TabIndex = 13;
            this.btnVehicles.Text = "Vehicles";
            this.btnVehicles.TextOffset = new System.Drawing.Point(7, 0);
            this.btnVehicles.Click += new System.EventHandler(this.btnVehicles_Click);
            // 
            // btnBookings
            // 
            this.btnBookings.BackColor = System.Drawing.Color.Transparent;
            this.btnBookings.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.btnBookings.CheckedState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btnBookings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBookings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBookings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBookings.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBookings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBookings.FillColor = System.Drawing.Color.Transparent;
            this.btnBookings.FillColor2 = System.Drawing.Color.Transparent;
            this.btnBookings.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnBookings.ForeColor = System.Drawing.Color.White;
            this.btnBookings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBookings.ImageOffset = new System.Drawing.Point(7, 0);
            this.btnBookings.Location = new System.Drawing.Point(12, 441);
            this.btnBookings.Name = "btnBookings";
            this.btnBookings.Size = new System.Drawing.Size(177, 41);
            this.btnBookings.TabIndex = 14;
            this.btnBookings.Text = "Bookings";
            this.btnBookings.TextOffset = new System.Drawing.Point(10, 0);
            this.btnBookings.Click += new System.EventHandler(this.btnBookings_Click);
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.BackColor = System.Drawing.Color.Transparent;
            this.btnMaintenance.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.btnMaintenance.CheckedState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btnMaintenance.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMaintenance.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMaintenance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMaintenance.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMaintenance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMaintenance.FillColor = System.Drawing.Color.Transparent;
            this.btnMaintenance.FillColor2 = System.Drawing.Color.Transparent;
            this.btnMaintenance.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnMaintenance.ForeColor = System.Drawing.Color.White;
            this.btnMaintenance.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMaintenance.ImageOffset = new System.Drawing.Point(7, 0);
            this.btnMaintenance.Location = new System.Drawing.Point(12, 488);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(177, 41);
            this.btnMaintenance.TabIndex = 15;
            this.btnMaintenance.Text = "Maintenance";
            this.btnMaintenance.TextOffset = new System.Drawing.Point(15, 0);
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.btnSettings.CheckedState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btnSettings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettings.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnSettings.FillColor2 = System.Drawing.Color.Transparent;
            this.btnSettings.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSettings.ImageOffset = new System.Drawing.Point(7, 0);
            this.btnSettings.Location = new System.Drawing.Point(12, 535);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(177, 41);
            this.btnSettings.TabIndex = 16;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextOffset = new System.Drawing.Point(5, 0);
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnViewLinkedinProfile
            // 
            this.btnViewLinkedinProfile.BorderRadius = 10;
            this.btnViewLinkedinProfile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewLinkedinProfile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewLinkedinProfile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewLinkedinProfile.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewLinkedinProfile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewLinkedinProfile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.btnViewLinkedinProfile.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btnViewLinkedinProfile.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewLinkedinProfile.ForeColor = System.Drawing.Color.White;
            this.btnViewLinkedinProfile.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnViewLinkedinProfile.Location = new System.Drawing.Point(17, 687);
            this.btnViewLinkedinProfile.Name = "btnViewLinkedinProfile";
            this.btnViewLinkedinProfile.Size = new System.Drawing.Size(160, 37);
            this.btnViewLinkedinProfile.TabIndex = 17;
            this.btnViewLinkedinProfile.Text = "View LinkedIn Profile";
            this.btnViewLinkedinProfile.TextOffset = new System.Drawing.Point(0, 5);
            this.btnViewLinkedinProfile.Click += new System.EventHandler(this.btnFindNearestCar_Click);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.pnlSidebar.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(22)))));
            this.pnlSidebar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            borderRadius1.BottomLeft = 1;
            borderRadius1.BottomRight = 1;
            borderRadius1.TopLeft = 1;
            borderRadius1.TopRight = 1;
            this.pnlSidebar.BorderRadius = borderRadius1;
            this.pnlSidebar.BorderThickness = 0;
            this.pnlSidebar.Controls.Add(this.btnLogOut);
            this.pnlSidebar.Controls.Add(this.btnViewLinkedinProfile);
            this.pnlSidebar.Controls.Add(this.btnSettings);
            this.pnlSidebar.Controls.Add(this.btnMaintenance);
            this.pnlSidebar.Controls.Add(this.btnBookings);
            this.pnlSidebar.Controls.Add(this.btnVehicles);
            this.pnlSidebar.Controls.Add(this.btnCustomers);
            this.pnlSidebar.Controls.Add(this.btnUsers);
            this.pnlSidebar.Controls.Add(this.btnHome);
            this.pnlSidebar.Controls.Add(this.pnlUserInfo);
            this.pnlSidebar.Controls.Add(this.plIndicator);
            this.pnlSidebar.Controls.Add(this.pbLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(190, 820);
            this.pnlSidebar.TabIndex = 1;
            // 
            // btnFindNearestCar
            // 
            this.btnFindNearestCar.BorderRadius = 10;
            this.btnFindNearestCar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFindNearestCar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFindNearestCar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFindNearestCar.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFindNearestCar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFindNearestCar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.btnFindNearestCar.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btnFindNearestCar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnFindNearestCar.ForeColor = System.Drawing.Color.White;
            this.btnFindNearestCar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.btnFindNearestCar.Location = new System.Drawing.Point(17, 730);
            this.btnFindNearestCar.Name = "btnFindNearestCar";
            this.btnFindNearestCar.Size = new System.Drawing.Size(160, 37);
            this.btnFindNearestCar.TabIndex = 17;
            this.btnFindNearestCar.Text = "Find Nearest Car";
            // 
            // btnContactMe
            // 
            this.btnContactMe.BorderRadius = 10;
            this.btnContactMe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnContactMe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnContactMe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnContactMe.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnContactMe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnContactMe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.btnContactMe.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btnContactMe.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnContactMe.ForeColor = System.Drawing.Color.White;
            this.btnContactMe.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnContactMe.Location = new System.Drawing.Point(17, 730);
            this.btnContactMe.Name = "btnContactMe";
            this.btnContactMe.Size = new System.Drawing.Size(160, 37);
            this.btnContactMe.TabIndex = 17;
            this.btnContactMe.Text = "View LinkedIn Profile";
            this.btnContactMe.TextOffset = new System.Drawing.Point(0, 5);
            this.btnContactMe.Click += new System.EventHandler(this.btnFindNearestCar_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.btnLogOut.BorderRadius = 20;
            this.btnLogOut.BorderThickness = 2;
            this.btnLogOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogOut.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogOut.FillColor = System.Drawing.Color.Transparent;
            this.btnLogOut.FillColor2 = System.Drawing.Color.Transparent;
            this.btnLogOut.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnLogOut.Location = new System.Drawing.Point(17, 730);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(160, 44);
            this.btnLogOut.TabIndex = 18;
            this.btnLogOut.Text = "Log out";
            // 
            // usSidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pnlSidebar);
            this.Name = "usSidebar";
            this.Size = new System.Drawing.Size(190, 820);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlUserInfo.ResumeLayout(false);
            this.pnlUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sataPictureBox1)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel plIndicator;
        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Label lblUserName;
        private Guna.UI2.WinForms.Guna2GradientButton btnHome;
        private Guna.UI2.WinForms.Guna2GradientButton btnUsers;
        private Guna.UI2.WinForms.Guna2GradientButton btnCustomers;
        private Guna.UI2.WinForms.Guna2GradientButton btnVehicles;
        private Guna.UI2.WinForms.Guna2GradientButton btnBookings;
        private Guna.UI2.WinForms.Guna2GradientButton btnMaintenance;
        private Guna.UI2.WinForms.Guna2GradientButton btnSettings;
        private Guna.UI2.WinForms.Guna2GradientTileButton btnViewLinkedinProfile;
        private SATAUiFramework.SATAPanel pnlSidebar;
        private SATAUiFramework.Controls.SATAPictureBox sataPictureBox1;
        private Guna.UI2.WinForms.Guna2GradientTileButton btnFindNearestCar;
        private Guna.UI2.WinForms.Guna2GradientTileButton btnContactMe;
        private Guna.UI2.WinForms.Guna2GradientTileButton btnLogOut;
    }
}
