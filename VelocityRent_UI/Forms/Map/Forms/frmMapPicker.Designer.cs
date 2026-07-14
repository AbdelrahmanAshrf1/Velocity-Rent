namespace Velocity_Rent.Forms.Map.Forms
{
    partial class frmMapPicker
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
            this.ucMapWithSearch = new Velocity_Rent.Map.Controls.ucMapWithSearch();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.SuspendLayout();
            // 
            // ucMapWithSearch
            // 
            this.ucMapWithSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.ucMapWithSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMapWithSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.ucMapWithSearch.Location = new System.Drawing.Point(0, 0);
            this.ucMapWithSearch.Margin = new System.Windows.Forms.Padding(0);
            this.ucMapWithSearch.Name = "ucMapWithSearch";
            this.ucMapWithSearch.Size = new System.Drawing.Size(1000, 710);
            this.ucMapWithSearch.TabIndex = 0;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.ucMapWithSearch;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // frmMapPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 710);
            this.Controls.Add(this.ucMapWithSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMapPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMapPicker";
            this.ResumeLayout(false);

        }

        #endregion

        private Velocity_Rent.Map.Controls.ucMapWithSearch ucMapWithSearch;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}