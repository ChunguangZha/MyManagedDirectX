namespace fractal
{
    partial class FormGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGrid));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.RectGridData = new System.Windows.Forms.Button();
            this.ComboBoxMethord = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TbYj = new System.Windows.Forms.TextBox();
            this.tbMaxY = new System.Windows.Forms.TextBox();
            this.tbMinY = new System.Windows.Forms.TextBox();
            this.tbJX = new System.Windows.Forms.TextBox();
            this.tbMaxX = new System.Windows.Forms.TextBox();
            this.tbMinx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SaveFile = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.TBFacies = new System.Windows.Forms.TextBox();
            this.BTFacies = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TBBind = new System.Windows.Forms.TextBox();
            this.BTBind = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(132, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 21);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "原始数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RectGridData
            // 
            this.RectGridData.Location = new System.Drawing.Point(164, 405);
            this.RectGridData.Name = "RectGridData";
            this.RectGridData.Size = new System.Drawing.Size(90, 25);
            this.RectGridData.TabIndex = 2;
            this.RectGridData.Text = "网格化";
            this.RectGridData.UseVisualStyleBackColor = true;
            this.RectGridData.Click += new System.EventHandler(this.RectGridData_Click);
            // 
            // ComboBoxMethord
            // 
            this.ComboBoxMethord.FormattingEnabled = true;
            this.ComboBoxMethord.Location = new System.Drawing.Point(132, 55);
            this.ComboBoxMethord.Name = "ComboBoxMethord";
            this.ComboBoxMethord.Size = new System.Drawing.Size(264, 20);
            this.ComboBoxMethord.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "网格插值方法：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numericUpDownY);
            this.groupBox1.Controls.Add(this.numericUpDownX);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TbYj);
            this.groupBox1.Controls.Add(this.tbMaxY);
            this.groupBox1.Controls.Add(this.tbMinY);
            this.groupBox1.Controls.Add(this.tbJX);
            this.groupBox1.Controls.Add(this.tbMaxX);
            this.groupBox1.Controls.Add(this.tbMinx);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(29, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 126);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网格线索几何学";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "行数";
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(289, 87);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(69, 21);
            this.numericUpDownY.TabIndex = 15;
            this.numericUpDownY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownY.ValueChanged += new System.EventHandler(this.numericUpDownY_ValueChanged);
            this.numericUpDownY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownY_KeyUp);
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(289, 40);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(69, 21);
            this.numericUpDownX.TabIndex = 14;
            this.numericUpDownX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownX.ValueChanged += new System.EventHandler(this.numericUpDownX_ValueChanged);
            this.numericUpDownX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownX_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "间距";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "最大";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "最小";
            // 
            // TbYj
            // 
            this.TbYj.Location = new System.Drawing.Point(212, 86);
            this.TbYj.Name = "TbYj";
            this.TbYj.Size = new System.Drawing.Size(71, 21);
            this.TbYj.TabIndex = 10;
            // 
            // tbMaxY
            // 
            this.tbMaxY.Location = new System.Drawing.Point(135, 86);
            this.tbMaxY.Name = "tbMaxY";
            this.tbMaxY.Size = new System.Drawing.Size(71, 21);
            this.tbMaxY.TabIndex = 9;
            // 
            // tbMinY
            // 
            this.tbMinY.Location = new System.Drawing.Point(56, 86);
            this.tbMinY.Name = "tbMinY";
            this.tbMinY.Size = new System.Drawing.Size(71, 21);
            this.tbMinY.TabIndex = 8;
            // 
            // tbJX
            // 
            this.tbJX.Location = new System.Drawing.Point(212, 39);
            this.tbJX.Name = "tbJX";
            this.tbJX.Size = new System.Drawing.Size(71, 21);
            this.tbJX.TabIndex = 7;
            // 
            // tbMaxX
            // 
            this.tbMaxX.Location = new System.Drawing.Point(135, 39);
            this.tbMaxX.Name = "tbMaxX";
            this.tbMaxX.Size = new System.Drawing.Size(71, 21);
            this.tbMaxX.TabIndex = 6;
            // 
            // tbMinx
            // 
            this.tbMinx.Location = new System.Drawing.Point(58, 39);
            this.tbMinx.Name = "tbMinx";
            this.tbMinx.Size = new System.Drawing.Size(71, 21);
            this.tbMinx.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y方向:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "X方向:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.Controls.Add(this.SaveFile);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(30, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 69);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出网格文件";
            // 
            // SaveFile
            // 
            this.SaveFile.Location = new System.Drawing.Point(296, 28);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(58, 21);
            this.SaveFile.TabIndex = 1;
            this.SaveFile.Text = "保存";
            this.SaveFile.UseVisualStyleBackColor = true;
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(284, 21);
            this.textBox2.TabIndex = 0;
            // 
            // TBFacies
            // 
            this.TBFacies.Location = new System.Drawing.Point(120, 63);
            this.TBFacies.Name = "TBFacies";
            this.TBFacies.Size = new System.Drawing.Size(226, 21);
            this.TBFacies.TabIndex = 9;
            // 
            // BTFacies
            // 
            this.BTFacies.Location = new System.Drawing.Point(18, 63);
            this.BTFacies.Name = "BTFacies";
            this.BTFacies.Size = new System.Drawing.Size(89, 22);
            this.BTFacies.TabIndex = 8;
            this.BTFacies.Text = "岩相边界数据";
            this.BTFacies.UseVisualStyleBackColor = true;
            this.BTFacies.Click += new System.EventHandler(this.BTFacies_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = global::Fracture_Identification.Properties.Resources.bg_03;
            this.groupBox3.Controls.Add(this.TBBind);
            this.groupBox3.Controls.Add(this.BTBind);
            this.groupBox3.Controls.Add(this.TBFacies);
            this.groupBox3.Controls.Add(this.BTFacies);
            this.groupBox3.Location = new System.Drawing.Point(30, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 99);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "约束边界";
            // 
            // TBBind
            // 
            this.TBBind.Location = new System.Drawing.Point(119, 22);
            this.TBBind.Name = "TBBind";
            this.TBBind.Size = new System.Drawing.Size(227, 21);
            this.TBBind.TabIndex = 11;
            // 
            // BTBind
            // 
            this.BTBind.Location = new System.Drawing.Point(17, 22);
            this.BTBind.Name = "BTBind";
            this.BTBind.Size = new System.Drawing.Size(89, 22);
            this.BTBind.TabIndex = 10;
            this.BTBind.Text = "约束边界数据";
            this.BTBind.UseVisualStyleBackColor = true;
            this.BTBind.Click += new System.EventHandler(this.BTBind_Click);
            // 
            // FormGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fracture_Identification.Properties.Resources.bg_03;
            this.ClientSize = new System.Drawing.Size(423, 435);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxMethord);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.RectGridData);
            this.Name = "FormGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "网格值";
            this.Load += new System.EventHandler(this.FormGrid_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button RectGridData;
        private System.Windows.Forms.ComboBox ComboBoxMethord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbYj;
        private System.Windows.Forms.TextBox tbMaxY;
        private System.Windows.Forms.TextBox tbMinY;
        private System.Windows.Forms.TextBox tbJX;
        private System.Windows.Forms.TextBox tbMaxX;
        private System.Windows.Forms.TextBox tbMinx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SaveFile;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBFacies;
        private System.Windows.Forms.Button BTFacies;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TBBind;
        private System.Windows.Forms.Button BTBind;
    }
}