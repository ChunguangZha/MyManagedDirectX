namespace Fracture_Identification
{
    partial class frmPrincipalCurvatures
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
            this.btnFracIden = new System.Windows.Forms.Button();
            this.btnMaxCur = new System.Windows.Forms.Button();
            this.btnMinCur = new System.Windows.Forms.Button();
            this.txtNX = new System.Windows.Forms.TextBox();
            this.txtNY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFracData = new System.Windows.Forms.TextBox();
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
            // btnFracIden
            // 
            this.btnFracIden.Enabled = false;
            this.btnFracIden.Location = new System.Drawing.Point(29, 206);
            this.btnFracIden.Name = "btnFracIden";
            this.btnFracIden.Size = new System.Drawing.Size(96, 34);
            this.btnFracIden.TabIndex = 2;
            this.btnFracIden.Text = "裂缝识别";
            this.btnFracIden.UseVisualStyleBackColor = true;
            this.btnFracIden.Click += new System.EventHandler(this.btnFracIden_Click);
            // 
            // btnMaxCur
            // 
            this.btnMaxCur.Enabled = false;
            this.btnMaxCur.Location = new System.Drawing.Point(29, 274);
            this.btnMaxCur.Name = "btnMaxCur";
            this.btnMaxCur.Size = new System.Drawing.Size(96, 33);
            this.btnMaxCur.TabIndex = 3;
            this.btnMaxCur.Text = "最大曲率作图";
            this.btnMaxCur.UseVisualStyleBackColor = true;
            this.btnMaxCur.Click += new System.EventHandler(this.btnMaxCur_Click);
            // 
            // btnMinCur
            // 
            this.btnMinCur.Enabled = false;
            this.btnMinCur.Location = new System.Drawing.Point(29, 329);
            this.btnMinCur.Name = "btnMinCur";
            this.btnMinCur.Size = new System.Drawing.Size(96, 33);
            this.btnMinCur.TabIndex = 3;
            this.btnMinCur.Text = "最小曲率作图";
            this.btnMinCur.UseVisualStyleBackColor = true;
            this.btnMinCur.Click += new System.EventHandler(this.btnMinCur_Click);
            // 
            // txtNX
            // 
            this.txtNX.Location = new System.Drawing.Point(125, 97);
            this.txtNX.Name = "txtNX";
            this.txtNX.ReadOnly = true;
            this.txtNX.Size = new System.Drawing.Size(102, 21);
            this.txtNX.TabIndex = 4;
            // 
            // txtNY
            // 
            this.txtNY.Location = new System.Drawing.Point(125, 142);
            this.txtNY.Name = "txtNY";
            this.txtNY.ReadOnly = true;
            this.txtNY.Size = new System.Drawing.Size(102, 21);
            this.txtNY.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "x方向网格数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "y方向网格数";
            // 
            // txtFracData
            // 
            this.txtFracData.Location = new System.Drawing.Point(131, 214);
            this.txtFracData.Name = "txtFracData";
            this.txtFracData.ReadOnly = true;
            this.txtFracData.Size = new System.Drawing.Size(190, 21);
            this.txtFracData.TabIndex = 1;
            // 
            // frmPrincipalCurvatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(796, 459);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNY);
            this.Controls.Add(this.txtNX);
            this.Controls.Add(this.btnMinCur);
            this.Controls.Add(this.btnMaxCur);
            this.Controls.Add(this.btnFracIden);
            this.Controls.Add(this.txtFracData);
            this.Controls.Add(this.txtGridData);
            this.Controls.Add(this.btnReadGridData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPrincipalCurvatures";
            this.ShowIcon = false;
            this.Text = "主曲率法";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadGridData;
        private System.Windows.Forms.TextBox txtGridData;
        private System.Windows.Forms.Button btnFracIden;
        private System.Windows.Forms.Button btnMaxCur;
        private System.Windows.Forms.Button btnMinCur;
        private System.Windows.Forms.TextBox txtNX;
        private System.Windows.Forms.TextBox txtNY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFracData;
    }
}