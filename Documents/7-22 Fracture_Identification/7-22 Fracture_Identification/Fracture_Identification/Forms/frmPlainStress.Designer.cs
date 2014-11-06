namespace Fracture_Identification
{
    partial class frmPlainStress
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
            this.btnReadGridData = new System.Windows.Forms.Button();
            this.txtGridData = new System.Windows.Forms.TextBox();
            this.btnShearAnalysis = new System.Windows.Forms.Button();
            this.btnMaxStress = new System.Windows.Forms.Button();
            this.btnMinStress = new System.Windows.Forms.Button();
            this.txtNX = new System.Windows.Forms.TextBox();
            this.txtNY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFracData = new System.Windows.Forms.TextBox();
            this.btnMaxShearing = new System.Windows.Forms.Button();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtThickness = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReadGridData
            // 
            this.btnReadGridData.Location = new System.Drawing.Point(29, 32);
            this.btnReadGridData.Name = "btnReadGridData";
            this.btnReadGridData.Size = new System.Drawing.Size(84, 32);
            this.btnReadGridData.TabIndex = 0;
            this.btnReadGridData.Text = "网格化数据";
            this.btnReadGridData.UseVisualStyleBackColor = true;
            this.btnReadGridData.Click += new System.EventHandler(this.btnReadGridData_Click);
            // 
            // txtGridData
            // 
            this.txtGridData.Location = new System.Drawing.Point(119, 39);
            this.txtGridData.Name = "txtGridData";
            this.txtGridData.ReadOnly = true;
            this.txtGridData.Size = new System.Drawing.Size(190, 21);
            this.txtGridData.TabIndex = 1;
            // 
            // btnShearAnalysis
            // 
            this.btnShearAnalysis.Enabled = false;
            this.btnShearAnalysis.Location = new System.Drawing.Point(29, 246);
            this.btnShearAnalysis.Name = "btnShearAnalysis";
            this.btnShearAnalysis.Size = new System.Drawing.Size(96, 34);
            this.btnShearAnalysis.TabIndex = 2;
            this.btnShearAnalysis.Text = "构造应力分析";
            this.btnShearAnalysis.UseVisualStyleBackColor = true;
            this.btnShearAnalysis.Click += new System.EventHandler(this.btnShearAnalysis_Click);
            // 
            // btnMaxStress
            // 
            this.btnMaxStress.Enabled = false;
            this.btnMaxStress.Location = new System.Drawing.Point(29, 306);
            this.btnMaxStress.Name = "btnMaxStress";
            this.btnMaxStress.Size = new System.Drawing.Size(106, 33);
            this.btnMaxStress.TabIndex = 3;
            this.btnMaxStress.Text = "最大主应力作图";
            this.btnMaxStress.UseVisualStyleBackColor = true;
            this.btnMaxStress.Click += new System.EventHandler(this.btnMaxCur_Click);
            // 
            // btnMinStress
            // 
            this.btnMinStress.Enabled = false;
            this.btnMinStress.Location = new System.Drawing.Point(29, 345);
            this.btnMinStress.Name = "btnMinStress";
            this.btnMinStress.Size = new System.Drawing.Size(106, 33);
            this.btnMinStress.TabIndex = 3;
            this.btnMinStress.Text = "最小主应力作图";
            this.btnMinStress.UseVisualStyleBackColor = true;
            this.btnMinStress.Click += new System.EventHandler(this.btnMinCur_Click);
            // 
            // txtNX
            // 
            this.txtNX.Location = new System.Drawing.Point(119, 79);
            this.txtNX.Name = "txtNX";
            this.txtNX.ReadOnly = true;
            this.txtNX.Size = new System.Drawing.Size(102, 21);
            this.txtNX.TabIndex = 4;
            // 
            // txtNY
            // 
            this.txtNY.Location = new System.Drawing.Point(119, 106);
            this.txtNY.Name = "txtNY";
            this.txtNY.ReadOnly = true;
            this.txtNY.Size = new System.Drawing.Size(102, 21);
            this.txtNY.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "x方向网格数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "y方向网格数";
            // 
            // txtFracData
            // 
            this.txtFracData.Location = new System.Drawing.Point(131, 254);
            this.txtFracData.Name = "txtFracData";
            this.txtFracData.ReadOnly = true;
            this.txtFracData.Size = new System.Drawing.Size(190, 21);
            this.txtFracData.TabIndex = 1;
            // 
            // btnMaxShearing
            // 
            this.btnMaxShearing.Enabled = false;
            this.btnMaxShearing.Location = new System.Drawing.Point(29, 384);
            this.btnMaxShearing.Name = "btnMaxShearing";
            this.btnMaxShearing.Size = new System.Drawing.Size(106, 33);
            this.btnMaxShearing.TabIndex = 3;
            this.btnMaxShearing.Text = "最大剪应力作图";
            this.btnMaxShearing.UseVisualStyleBackColor = true;
            this.btnMaxShearing.Click += new System.EventHandler(this.btnMinCur_Click);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(119, 153);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(102, 21);
            this.txtY.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "杨氏模量";
            // 
            // txtPr
            // 
            this.txtPr.Location = new System.Drawing.Point(119, 180);
            this.txtPr.Name = "txtPr";
            this.txtPr.Size = new System.Drawing.Size(102, 21);
            this.txtPr.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "泊松比";
            // 
            // txtThickness
            // 
            this.txtThickness.Location = new System.Drawing.Point(119, 207);
            this.txtThickness.Name = "txtThickness";
            this.txtThickness.Size = new System.Drawing.Size(102, 21);
            this.txtThickness.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "厚度";
            // 
            // frmPlainStress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(796, 459);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtThickness);
            this.Controls.Add(this.txtPr);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtNY);
            this.Controls.Add(this.txtNX);
            this.Controls.Add(this.btnMaxShearing);
            this.Controls.Add(this.btnMinStress);
            this.Controls.Add(this.btnMaxStress);
            this.Controls.Add(this.btnShearAnalysis);
            this.Controls.Add(this.txtFracData);
            this.Controls.Add(this.txtGridData);
            this.Controls.Add(this.btnReadGridData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPlainStress";
            this.ShowIcon = false;
            this.Text = "平面应力法";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadGridData;
        private System.Windows.Forms.TextBox txtGridData;
        private System.Windows.Forms.Button btnShearAnalysis;
        private System.Windows.Forms.Button btnMaxStress;
        private System.Windows.Forms.Button btnMinStress;
        private System.Windows.Forms.TextBox txtNX;
        private System.Windows.Forms.TextBox txtNY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFracData;
        private System.Windows.Forms.Button btnMaxShearing;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtThickness;
        private System.Windows.Forms.Label label5;
    }
}