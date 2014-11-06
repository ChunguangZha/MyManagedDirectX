namespace Fracture_Identification
{
    partial class frmPlainStressPara
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
            this.txtY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtThickness = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(160, 23);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(102, 21);
            this.txtY.TabIndex = 4;
            this.txtY.Text = "10000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "杨氏模量";
            // 
            // txtPr
            // 
            this.txtPr.Location = new System.Drawing.Point(160, 50);
            this.txtPr.Name = "txtPr";
            this.txtPr.Size = new System.Drawing.Size(102, 21);
            this.txtPr.TabIndex = 4;
            this.txtPr.Text = "0.24";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "泊松比";
            // 
            // txtThickness
            // 
            this.txtThickness.Location = new System.Drawing.Point(160, 77);
            this.txtThickness.Name = "txtThickness";
            this.txtThickness.Size = new System.Drawing.Size(102, 21);
            this.txtThickness.TabIndex = 4;
            this.txtThickness.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "厚度";
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(109, 134);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(112, 34);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // frmPlainStressPara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(358, 186);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtThickness);
            this.Controls.Add(this.txtPr);
            this.Controls.Add(this.txtY);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPlainStressPara";
            this.ShowIcon = false;
            this.Text = "平面应力法参数输入";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtThickness;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_OK;
    }
}