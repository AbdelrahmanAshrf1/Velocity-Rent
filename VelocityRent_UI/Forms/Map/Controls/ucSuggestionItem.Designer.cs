namespace Velocity_Rent.Map.Controls
{
    partial class ucSuggestionItem
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
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            this.pnlContainer = new SATAUiFramework.SATAPanel();
            this.pbFavorite = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavorite)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.pnlContainer.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(22)))));
            this.pnlContainer.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 10;
            borderRadius1.BottomRight = 10;
            borderRadius1.TopLeft = 10;
            borderRadius1.TopRight = 10;
            this.pnlContainer.BorderRadius = borderRadius1;
            this.pnlContainer.BorderThickness = 0;
            this.pnlContainer.Controls.Add(this.pbFavorite);
            this.pnlContainer.Controls.Add(this.lblSubtitle);
            this.pnlContainer.Controls.Add(this.lblTitle);
            this.pnlContainer.Controls.Add(this.lblIcon);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(335, 69);
            this.pnlContainer.TabIndex = 0;
            // 
            // pbFavorite
            // 
            this.pbFavorite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFavorite.BackColor = System.Drawing.Color.Transparent;
            this.pbFavorite.Image = global::Velocity_Rent.Properties.Resources.heart_outLine;
            this.pbFavorite.ImageRotate = 0F;
            this.pbFavorite.Location = new System.Drawing.Point(294, 17);
            this.pbFavorite.Name = "pbFavorite";
            this.pbFavorite.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbFavorite.Size = new System.Drawing.Size(34, 34);
            this.pbFavorite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbFavorite.TabIndex = 11;
            this.pbFavorite.TabStop = false;
            this.pbFavorite.Click += new System.EventHandler(this.pbFavorite_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.Silver;
            this.lblSubtitle.Location = new System.Drawing.Point(47, 33);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(221, 16);
            this.lblSubtitle.TabIndex = 10;
            this.lblSubtitle.Text = "Subtitle";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(47, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 20);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Title";
            // 
            // lblIcon
            // 
            this.lblIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIcon.ForeColor = System.Drawing.Color.Silver;
            this.lblIcon.Location = new System.Drawing.Point(7, 13);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(34, 34);
            this.lblIcon.TabIndex = 8;
            this.lblIcon.Text = "i";
            this.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucSuggestionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainer);
            this.Name = "ucSuggestionItem";
            this.Size = new System.Drawing.Size(335, 69);
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFavorite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SATAUiFramework.SATAPanel pnlContainer;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbFavorite;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIcon;
    }
}
