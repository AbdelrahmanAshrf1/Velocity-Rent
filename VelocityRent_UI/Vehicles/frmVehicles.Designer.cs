namespace Velocity_Rent.Vehicles
{
    partial class frmVehicles
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
            this.label1 = new System.Windows.Forms.Label();
            this.plMain = new System.Windows.Forms.Panel();
            this.pbHomeIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.plMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHomeIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // sataEllipseControl1
            // 
            this.sataEllipseControl1.CornerRadius = 15;
            this.sataEllipseControl1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(65, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vehicles";
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.plMain.Controls.Add(this.pbHomeIcon);
            this.plMain.Controls.Add(this.label1);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(940, 696);
            this.plMain.TabIndex = 5;
            // 
            // pbHomeIcon
            // 
            this.pbHomeIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbHomeIcon.Image = global::Velocity_Rent.Properties.Resources.Car2_Sidebar;
            this.pbHomeIcon.ImageRotate = 0F;
            this.pbHomeIcon.Location = new System.Drawing.Point(27, 4);
            this.pbHomeIcon.Name = "pbHomeIcon";
            this.pbHomeIcon.Size = new System.Drawing.Size(32, 32);
            this.pbHomeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHomeIcon.TabIndex = 3;
            this.pbHomeIcon.TabStop = false;
            // 
            // frmVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 696);
            this.Controls.Add(this.plMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVehicles";
            this.Text = "frmVehicles";
            this.plMain.ResumeLayout(false);
            this.plMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHomeIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SATAUiFramework.Controls.SATAEllipseControl sataEllipseControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plMain;
        private Guna.UI2.WinForms.Guna2PictureBox pbHomeIcon;
    }
}