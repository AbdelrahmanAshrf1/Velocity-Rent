using Guna.UI2.WinForms;

namespace Velocity_Rent.Map.Controls
{
    partial class ucMapWithSearch
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
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMapWithSearch));
            this.sataPanel1 = new SATAUiFramework.SATAPanel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblLocation = new System.Windows.Forms.Label();
            this.gbMapContainer = new Guna.UI2.WinForms.Guna2GroupBox();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.guna2Elipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.txtSearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbSuggestionList = new Guna.UI2.WinForms.Guna2GroupBox();
            this.suggestionList = new Velocity_Rent.Map.Controls.ucSuggestionsList();
            this.sataPanel1.SuspendLayout();
            this.gbMapContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbSuggestionList.SuspendLayout();
            this.SuspendLayout();
            // 
            // sataPanel1
            // 
            this.sataPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.sataPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(22)))));
            this.sataPanel1.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 10;
            borderRadius1.BottomRight = 10;
            borderRadius1.TopLeft = 10;
            borderRadius1.TopRight = 10;
            this.sataPanel1.BorderRadius = borderRadius1;
            this.sataPanel1.BorderThickness = 0;
            this.sataPanel1.Controls.Add(this.gbSuggestionList);
            this.sataPanel1.Controls.Add(this.guna2Separator1);
            this.sataPanel1.Controls.Add(this.txtSearchBox);
            this.sataPanel1.Controls.Add(this.pictureBox1);
            this.sataPanel1.Controls.Add(this.lblLocation);
            this.sataPanel1.Controls.Add(this.gbMapContainer);
            resources.ApplyResources(this.sataPanel1, "sataPanel1");
            this.sataPanel1.Name = "sataPanel1";
            // 
            // guna2Separator1
            // 
            resources.ApplyResources(this.guna2Separator1, "guna2Separator1");
            this.guna2Separator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.guna2Separator1.Name = "guna2Separator1";
            // 
            // lblLocation
            // 
            resources.ApplyResources(this.lblLocation, "lblLocation");
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.ForeColor = System.Drawing.Color.White;
            this.lblLocation.Name = "lblLocation";
            // 
            // gbMapContainer
            // 
            resources.ApplyResources(this.gbMapContainer, "gbMapContainer");
            this.gbMapContainer.BackColor = System.Drawing.Color.Transparent;
            this.gbMapContainer.BorderColor = System.Drawing.Color.Transparent;
            this.gbMapContainer.BorderRadius = 20;
            this.gbMapContainer.BorderThickness = 3;
            this.gbMapContainer.Controls.Add(this.webView21);
            this.gbMapContainer.CustomBorderColor = System.Drawing.Color.Transparent;
            this.gbMapContainer.CustomBorderThickness = new System.Windows.Forms.Padding(1);
            this.gbMapContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbMapContainer.Name = "gbMapContainer";
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            resources.ApplyResources(this.webView21, "webView21");
            this.webView21.Name = "webView21";
            this.webView21.ZoomFactor = 1D;
            // 
            // guna2Elipse
            // 
            this.guna2Elipse.BorderRadius = 30;
            this.guna2Elipse.TargetControl = this.webView21;
            // 
            // txtSearchBox
            // 
            resources.ApplyResources(this.txtSearchBox, "txtSearchBox");
            this.txtSearchBox.Animated = true;
            this.txtSearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(22)))));
            this.txtSearchBox.BorderColor = System.Drawing.Color.Silver;
            this.txtSearchBox.BorderRadius = 10;
            this.txtSearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchBox.DefaultText = "";
            this.txtSearchBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(22)))));
            this.txtSearchBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.txtSearchBox.ForeColor = System.Drawing.Color.White;
            this.txtSearchBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.txtSearchBox.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearchBox.IconLeft")));
            this.txtSearchBox.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.txtSearchBox.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtSearchBox.IconLeftSize = new System.Drawing.Size(24, 24);
            this.txtSearchBox.IconRight = ((System.Drawing.Image)(resources.GetObject("txtSearchBox.IconRight")));
            this.txtSearchBox.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.txtSearchBox.IconRightOffset = new System.Drawing.Point(10, 0);
            this.txtSearchBox.IconRightSize = new System.Drawing.Size(24, 24);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(162)))), ((int)(((byte)(170)))));
            this.txtSearchBox.PlaceholderText = "Search for addresses, cities, or points of interest...";
            this.txtSearchBox.SelectedText = "";
            this.txtSearchBox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.txtSearchBox.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(8);
            this.txtSearchBox.IconRightClick += new System.EventHandler(this.CurrentLocation);
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            this.txtSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBox_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // gbSuggestionList
            // 
            resources.ApplyResources(this.gbSuggestionList, "gbSuggestionList");
            this.gbSuggestionList.BorderColor = System.Drawing.Color.Transparent;
            this.gbSuggestionList.BorderRadius = 20;
            this.gbSuggestionList.Controls.Add(this.suggestionList);
            this.gbSuggestionList.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.gbSuggestionList.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.gbSuggestionList.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.gbSuggestionList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbSuggestionList.Name = "gbSuggestionList";
            // 
            // suggestionList
            // 
            resources.ApplyResources(this.suggestionList, "suggestionList");
            this.suggestionList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.suggestionList.Name = "suggestionList";
            // 
            // ucMapWithSearch
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.Controls.Add(this.sataPanel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.Name = "ucMapWithSearch";
            this.Load += new System.EventHandler(this.ucMapWithSearch_Load);
            this.sataPanel1.ResumeLayout(false);
            this.sataPanel1.PerformLayout();
            this.gbMapContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbSuggestionList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SATAUiFramework.SATAPanel sataPanel1;
        private Guna2Separator guna2Separator1;
        private Guna2TextBox txtSearchBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLocation;
        private Guna2GroupBox gbMapContainer;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Guna2Elipse guna2Elipse;
        private Guna2GroupBox gbSuggestionList;
        private ucSuggestionsList suggestionList;
    }
}
