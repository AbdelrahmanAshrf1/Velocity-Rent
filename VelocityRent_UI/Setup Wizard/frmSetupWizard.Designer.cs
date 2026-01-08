namespace Velocity_Rent.Setup_Wizard
{
    partial class frmSetupWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetupWizard));
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.sataEllipseControl1 = new SATAUiFramework.Controls.SATAEllipseControl();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.sataDragControl1 = new SATAUiFramework.Controls.SATADragControl();
            this.sataDragControl2 = new SATAUiFramework.Controls.SATADragControl();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(103)))), ((int)(((byte)(48)))));
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(242, 605);
            this.pnlSidebar.TabIndex = 0;
            // 
            // sataEllipseControl1
            // 
            this.sataEllipseControl1.CornerRadius = 100;
            this.sataEllipseControl1.TargetControl = this;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(73)))), ((int)(((byte)(18)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(655, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 1;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(73)))), ((int)(((byte)(18)))));
            this.guna2ControlBox2.Location = new System.Drawing.Point(706, 12);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 2;
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.pnlContainer.Controls.Add(this.guna2ControlBox1);
            this.pnlContainer.Controls.Add(this.guna2ControlBox2);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(242, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(763, 605);
            this.pnlContainer.TabIndex = 3;
            // 
            // sataDragControl1
            // 
            this.sataDragControl1.SelectControl = this.pnlContainer;
            // 
            // sataDragControl2
            // 
            this.sataDragControl2.SelectControl = this.pnlSidebar;
            // 
            // frmSetupWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 605);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetupWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSetupWizard";
            this.pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private SATAUiFramework.Controls.SATAEllipseControl sataEllipseControl1;
        private System.Windows.Forms.Panel pnlContainer;
        private SATAUiFramework.Controls.SATADragControl sataDragControl1;
        private SATAUiFramework.Controls.SATADragControl sataDragControl2;
    }
}