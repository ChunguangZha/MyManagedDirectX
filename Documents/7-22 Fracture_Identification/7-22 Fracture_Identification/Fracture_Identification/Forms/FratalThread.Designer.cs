namespace Fracture_Identification
{
    partial class FratalThread
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FractalInsertExcute = new System.Windows.Forms.Button();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.d = new System.Windows.Forms.TextBox();
            this.OpenFradata = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.SaveFra = new System.Windows.Forms.Button();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = global::Fracture_Identification.Properties.Resources.bg_03;
            this.groupBox3.Controls.Add(this.FractalInsertExcute);
            this.groupBox3.Controls.Add(this.textBox13);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.textBox12);
            this.groupBox3.Controls.Add(this.d);
            this.groupBox3.Controls.Add(this.OpenFradata);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Location = new System.Drawing.Point(-5, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 293);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "自仿射分形曲线插值";
            // 
            // FractalInsertExcute
            // 
            this.FractalInsertExcute.Location = new System.Drawing.Point(203, 266);
            this.FractalInsertExcute.Name = "FractalInsertExcute";
            this.FractalInsertExcute.Size = new System.Drawing.Size(67, 27);
            this.FractalInsertExcute.TabIndex = 6;
            this.FractalInsertExcute.Text = "确定";
            this.FractalInsertExcute.UseVisualStyleBackColor = true;
            this.FractalInsertExcute.Click += new System.EventHandler(this.FractalInsertExcute_Click);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(129, 104);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(111, 21);
            this.textBox13.TabIndex = 11;
            this.textBox13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox13_KeyPress);
            this.textBox13.Leave += new System.EventHandler(this.textBox13_Leave);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label30.Location = new System.Drawing.Point(22, 104);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 14);
            this.label30.TabIndex = 9;
            this.label30.Text = "两数据点之";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label31.Location = new System.Drawing.Point(22, 118);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(91, 14);
            this.label31.TabIndex = 10;
            this.label31.Text = "间插值个数：";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label27.Location = new System.Drawing.Point(24, 48);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(49, 14);
            this.label27.TabIndex = 0;
            this.label27.Text = "原值：";
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.Location = new System.Drawing.Point(77, 45);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(111, 21);
            this.textBox12.TabIndex = 1;
            // 
            // d
            // 
            this.d.Location = new System.Drawing.Point(129, 168);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(111, 21);
            this.d.TabIndex = 8;
            this.d.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.d_KeyPress);
            // 
            // OpenFradata
            // 
            this.OpenFradata.Location = new System.Drawing.Point(198, 46);
            this.OpenFradata.Name = "OpenFradata";
            this.OpenFradata.Size = new System.Drawing.Size(76, 20);
            this.OpenFradata.TabIndex = 2;
            this.OpenFradata.Text = "打开";
            this.OpenFradata.UseVisualStyleBackColor = true;
            this.OpenFradata.Click += new System.EventHandler(this.OpenFradata_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label29.Location = new System.Drawing.Point(17, 169);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(105, 14);
            this.label29.TabIndex = 7;
            this.label29.Text = "垂直比例因子：";
            // 
            // SaveFra
            // 
            this.SaveFra.Location = new System.Drawing.Point(440, 286);
            this.SaveFra.Name = "SaveFra";
            this.SaveFra.Size = new System.Drawing.Size(82, 24);
            this.SaveFra.TabIndex = 15;
            this.SaveFra.Text = "保存";
            this.SaveFra.UseVisualStyleBackColor = true;
            this.SaveFra.Click += new System.EventHandler(this.SaveFra_Click);
            // 
            // richTextBox6
            // 
            this.richTextBox6.Enabled = false;
            this.richTextBox6.Location = new System.Drawing.Point(282, 41);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.Size = new System.Drawing.Size(240, 237);
            this.richTextBox6.TabIndex = 14;
            this.richTextBox6.Text = "";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label28.Location = new System.Drawing.Point(287, 17);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 14);
            this.label28.TabIndex = 13;
            this.label28.Text = "输出：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FratalThread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fracture_Identification.Properties.Resources.bg_03;
            this.ClientSize = new System.Drawing.Size(535, 315);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.SaveFra);
            this.Controls.Add(this.richTextBox6);
            this.Controls.Add(this.label28);
            this.Name = "FratalThread";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FratalThread";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button FractalInsertExcute;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox d;
        private System.Windows.Forms.Button OpenFradata;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button SaveFra;
        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}