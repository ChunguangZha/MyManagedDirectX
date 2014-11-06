namespace Fracture_Identification
{
    partial class frmRSFractal
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
            this.zedGraphRS = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRSDataFile = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnReadRSData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtBoxDimF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResTop = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResBottom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIntTop = new System.Windows.Forms.TextBox();
            this.txtIntBottom = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zedGraphRS
            // 
            this.zedGraphRS.Location = new System.Drawing.Point(392, 51);
            this.zedGraphRS.Name = "zedGraphRS";
            this.zedGraphRS.ScrollGrace = 0D;
            this.zedGraphRS.ScrollMaxX = 0D;
            this.zedGraphRS.ScrollMaxY = 0D;
            this.zedGraphRS.ScrollMaxY2 = 0D;
            this.zedGraphRS.ScrollMinX = 0D;
            this.zedGraphRS.ScrollMinY = 0D;
            this.zedGraphRS.ScrollMinY2 = 0D;
            this.zedGraphRS.Size = new System.Drawing.Size(481, 378);
            this.zedGraphRS.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据文件";
            // 
            // txtRSDataFile
            // 
            this.txtRSDataFile.Location = new System.Drawing.Point(44, 76);
            this.txtRSDataFile.Name = "txtRSDataFile";
            this.txtRSDataFile.ReadOnly = true;
            this.txtRSDataFile.Size = new System.Drawing.Size(228, 21);
            this.txtRSDataFile.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnReadRSData
            // 
            this.btnReadRSData.Location = new System.Drawing.Point(273, 74);
            this.btnReadRSData.Name = "btnReadRSData";
            this.btnReadRSData.Size = new System.Drawing.Size(38, 22);
            this.btnReadRSData.TabIndex = 3;
            this.btnReadRSData.Text = "...";
            this.btnReadRSData.UseVisualStyleBackColor = true;
            this.btnReadRSData.Click += new System.EventHandler(this.btnReadRSData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "分形维数：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "R/S分形";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(50, 366);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "方法2（英文书）";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(181, 232);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 30);
            this.button3.TabIndex = 7;
            this.button3.Text = "线性拟合";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtBoxDimF
            // 
            this.txtBoxDimF.Location = new System.Drawing.Point(119, 288);
            this.txtBoxDimF.Name = "txtBoxDimF";
            this.txtBoxDimF.ReadOnly = true;
            this.txtBoxDimF.Size = new System.Drawing.Size(90, 21);
            this.txtBoxDimF.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "地层顶深";
            // 
            // txtResTop
            // 
            this.txtResTop.Location = new System.Drawing.Point(107, 120);
            this.txtResTop.Name = "txtResTop";
            this.txtResTop.ReadOnly = true;
            this.txtResTop.Size = new System.Drawing.Size(69, 21);
            this.txtResTop.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "地层底深";
            // 
            // txtResBottom
            // 
            this.txtResBottom.Location = new System.Drawing.Point(242, 120);
            this.txtResBottom.Name = "txtResBottom";
            this.txtResBottom.ReadOnly = true;
            this.txtResBottom.Size = new System.Drawing.Size(69, 21);
            this.txtResBottom.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "区间顶深";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "区间底深";
            // 
            // txtIntTop
            // 
            this.txtIntTop.Location = new System.Drawing.Point(107, 170);
            this.txtIntTop.Name = "txtIntTop";
            this.txtIntTop.Size = new System.Drawing.Size(69, 21);
            this.txtIntTop.TabIndex = 10;
            // 
            // txtIntBottom
            // 
            this.txtIntBottom.Location = new System.Drawing.Point(242, 170);
            this.txtIntBottom.Name = "txtIntBottom";
            this.txtIntBottom.Size = new System.Drawing.Size(69, 21);
            this.txtIntBottom.TabIndex = 11;
            this.txtIntBottom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIntBottom_KeyDown);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(205, 367);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 28);
            this.button4.TabIndex = 12;
            this.button4.Text = "区间顶=底赋值";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmRSFractal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(927, 479);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtIntBottom);
            this.Controls.Add(this.txtIntTop);
            this.Controls.Add(this.txtResBottom);
            this.Controls.Add(this.txtResTop);
            this.Controls.Add(this.txtBoxDimF);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReadRSData);
            this.Controls.Add(this.txtRSDataFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraphRS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRSFractal";
            this.ShowIcon = false;
            this.Text = "R/S分形法";
            this.Load += new System.EventHandler(this.frmRSFractal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphRS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRSDataFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnReadRSData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtBoxDimF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResBottom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIntTop;
        private System.Windows.Forms.TextBox txtIntBottom;
        private System.Windows.Forms.Button button4;
    }
}