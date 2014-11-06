namespace fractal
{
    partial class ContourPicture
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
            this.winChartViewer1 = new ChartDirector.WinChartViewer();
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // winChartViewer1
            // 
            this.winChartViewer1.Location = new System.Drawing.Point(36, 27);
            this.winChartViewer1.Name = "winChartViewer1";
            this.winChartViewer1.Size = new System.Drawing.Size(331, 219);
            this.winChartViewer1.TabIndex = 0;
            this.winChartViewer1.TabStop = false;
            // 
            // ContourPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 622);
            this.Controls.Add(this.winChartViewer1);
            this.Name = "ContourPicture";
            this.Text = "ContourPicture";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContourPicture_FormClosed);
            this.Load += new System.EventHandler(this.ContourPicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ChartDirector.WinChartViewer winChartViewer1;
    }
}