namespace Velocity_Rent
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.sataDragControl1 = new SATAUiFramework.Controls.SATADragControl();
            this.sataEllipseControl2 = new SATAUiFramework.Controls.SATAEllipseControl();
            this.usSidebar1 = new Velocity_Rent.Main_Form.Controls.usSidebar();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(40)))), ((int)(((byte)(46)))));
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(189, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(8);
            this.panelContainer.Size = new System.Drawing.Size(1206, 820);
            this.panelContainer.TabIndex = 2;
            // 
            // sataDragControl1
            // 
            this.sataDragControl1.SelectControl = this.panelContainer;
            // 
            // usSidebar1
            // 
            this.usSidebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.usSidebar1.Location = new System.Drawing.Point(0, 0);
            this.usSidebar1.Name = "usSidebar1";
            this.usSidebar1.Size = new System.Drawing.Size(189, 820);
            this.usSidebar1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1395, 820);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.usSidebar1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Velocity Rent";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContainer;
        private SATAUiFramework.Controls.SATADragControl sataDragControl1;
        private SATAUiFramework.Controls.SATAEllipseControl sataEllipseControl2;
        private Main_Form.Controls.usSidebar usSidebar1;
    }
}

