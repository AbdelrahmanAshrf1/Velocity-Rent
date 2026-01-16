namespace Velocity_Rent.Map.Controls
{
    partial class ucSuggestionsList
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
            this.sataEllipse = new SATAUiFramework.Controls.SATAEllipseControl();
            this._animationTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // sataEllipse
            // 
            this.sataEllipse.CornerRadius = 20;
            this.sataEllipse.TargetControl = this;
            // 
            // _animationTimer
            // 
            this._animationTimer.Interval = 12;
            this._animationTimer.Tick += new System.EventHandler(this.AnimTimer_Tick);
            // 
            // pnlFlow
            // 
            this.pnlFlow.AutoSize = true;
            this.pnlFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(22)))));
            this.pnlFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlFlow.Location = new System.Drawing.Point(6, 6);
            this.pnlFlow.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFlow.Name = "pnlFlow";
            this.pnlFlow.Size = new System.Drawing.Size(328, 62);
            this.pnlFlow.TabIndex = 1;
            this.pnlFlow.WrapContents = false;
            // 
            // ucSuggestionsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.pnlFlow);
            this.Name = "ucSuggestionsList";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(340, 74);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SATAUiFramework.Controls.SATAEllipseControl sataEllipse;
        private System.Windows.Forms.Timer _animationTimer;
        private System.Windows.Forms.FlowLayoutPanel pnlFlow;
    }
}
