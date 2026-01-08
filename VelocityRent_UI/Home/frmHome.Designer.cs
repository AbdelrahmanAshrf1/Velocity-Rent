namespace Velocity_Rent
{
    partial class frmHome
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
            this.sataEllipseControl1 = new SATAUiFramework.Controls.SATAEllipseControl();
            this.ucMapWithSearch1 = new Velocity_Rent.Map.Controls.ucMapWithSearch();
            this.SuspendLayout();
            // 
            // sataEllipseControl1
            // 
            this.sataEllipseControl1.CornerRadius = 15;
            this.sataEllipseControl1.TargetControl = this;
            // 
            // ucMapWithSearch1
            // 
            this.ucMapWithSearch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.ucMapWithSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMapWithSearch1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.ucMapWithSearch1.Location = new System.Drawing.Point(0, 0);
            this.ucMapWithSearch1.Margin = new System.Windows.Forms.Padding(0);
            this.ucMapWithSearch1.Name = "ucMapWithSearch1";
            this.ucMapWithSearch1.Size = new System.Drawing.Size(1000, 710);
            this.ucMapWithSearch1.TabIndex = 0;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1000, 710);
            this.Controls.Add(this.ucMapWithSearch1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHome";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion
        private SATAUiFramework.Controls.SATAEllipseControl sataEllipseControl1;
        private Map.Controls.ucMapWithSearch ucMapWithSearch;
        private Map.Controls.ucMapWithSearch ucMapWithSearch1;
    }
}