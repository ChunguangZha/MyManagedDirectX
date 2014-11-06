namespace fractal
{
    partial class fractalF
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Excute = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveWorth = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.JubuExcute = new System.Windows.Forms.Button();
            this.ClearRich = new System.Windows.Forms.Button();
            this.surfaceDraw = new System.Windows.Forms.Button();
            this.ContourMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(251, 21);
            this.textBox1.TabIndex = 0;
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(330, 24);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(88, 24);
            this.OpenButton.TabIndex = 1;
            this.OpenButton.Text = "打开";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Excute
            // 
            this.Excute.Location = new System.Drawing.Point(330, 325);
            this.Excute.Name = "Excute";
            this.Excute.Size = new System.Drawing.Size(82, 24);
            this.Excute.TabIndex = 2;
            this.Excute.Text = "全部确定";
            this.Excute.UseVisualStyleBackColor = true;
            this.Excute.Click += new System.EventHandler(this.Excute_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Location = new System.Drawing.Point(35, 78);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(383, 231);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "原值：";
            // 
            // SaveWorth
            // 
            this.SaveWorth.Location = new System.Drawing.Point(140, 373);
            this.SaveWorth.Name = "SaveWorth";
            this.SaveWorth.Size = new System.Drawing.Size(82, 26);
            this.SaveWorth.TabIndex = 5;
            this.SaveWorth.Text = "保存";
            this.SaveWorth.UseVisualStyleBackColor = true;
            this.SaveWorth.Click += new System.EventHandler(this.SaveWorth_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(32, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "自仿射分形曲面插值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(36, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "局部邻域数据个数：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(164, 326);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(72, 21);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "2";
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // JubuExcute
            // 
            this.JubuExcute.Location = new System.Drawing.Point(242, 326);
            this.JubuExcute.Name = "JubuExcute";
            this.JubuExcute.Size = new System.Drawing.Size(82, 23);
            this.JubuExcute.TabIndex = 9;
            this.JubuExcute.Text = "局部确定";
            this.JubuExcute.UseVisualStyleBackColor = true;
            this.JubuExcute.Click += new System.EventHandler(this.JubuExcute_Click);
            // 
            // ClearRich
            // 
            this.ClearRich.Location = new System.Drawing.Point(39, 372);
            this.ClearRich.Name = "ClearRich";
            this.ClearRich.Size = new System.Drawing.Size(82, 27);
            this.ClearRich.TabIndex = 10;
            this.ClearRich.Text = "清空";
            this.ClearRich.UseVisualStyleBackColor = true;
            this.ClearRich.Click += new System.EventHandler(this.ClearRich_Click);
            // 
            // surfaceDraw
            // 
            this.surfaceDraw.Location = new System.Drawing.Point(330, 371);
            this.surfaceDraw.Name = "surfaceDraw";
            this.surfaceDraw.Size = new System.Drawing.Size(94, 27);
            this.surfaceDraw.TabIndex = 16;
            this.surfaceDraw.Text = "画曲面图";
            this.surfaceDraw.UseVisualStyleBackColor = true;
            this.surfaceDraw.Click += new System.EventHandler(this.surfaceDraw_Click);
            // 
            // ContourMap
            // 
            this.ContourMap.Location = new System.Drawing.Point(232, 372);
            this.ContourMap.Name = "ContourMap";
            this.ContourMap.Size = new System.Drawing.Size(92, 26);
            this.ContourMap.TabIndex = 15;
            this.ContourMap.Text = "画等值线";
            this.ContourMap.UseVisualStyleBackColor = true;
            this.ContourMap.Click += new System.EventHandler(this.ContourMap_Click);
            // 
            // fractalF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fracture_Identification.Properties.Resources.bg_03;
            this.ClientSize = new System.Drawing.Size(434, 408);
            this.Controls.Add(this.surfaceDraw);
            this.Controls.Add(this.ContourMap);
            this.Controls.Add(this.ClearRich);
            this.Controls.Add(this.JubuExcute);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SaveWorth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Excute);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.textBox1);
            this.Name = "fractalF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fractal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Excute;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveWorth;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button JubuExcute;
        private System.Windows.Forms.Button ClearRich;
        private System.Windows.Forms.Button surfaceDraw;
        private System.Windows.Forms.Button ContourMap;
    }
}

